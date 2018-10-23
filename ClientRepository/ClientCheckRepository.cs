using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public class ClientCheckRepository : IClientCheckRepository
    {
        DataContext db;
        public ClientCheckRepository()
        {
            db = new DataContext();
        }

        public void AddClientCheck(AddClientCheckViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientCheck entity = new PQClientCheck();
                    entity.ClientRowID = model.ClientRowID;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.SubCheckRowID = model.SubCheckRowID;
                    entity.ReportSequence = model.ReportSequence;
                    entity.TAT = model.TAT;
                    entity.InternalTAT = model.InternalTAT;
                    entity.SelectedTemplate = model.SelectedTemplate;
                    entity.CostPerCheck = model.CostPerCheck;
                    entity.BillingPerCheck = model.BillingPerCheck;
                    entity.AntecedentSelected = model.AntecedentSelected;

                    db.PQClientChecks.Add(entity);
                }
                else
                {
                    throw new Exception("Fill All Required Fields!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ClientCheckViewModel> GetChecksByClientId(short CId = 0)
        {
            try
            {
                return db.PQClientChecks.Include("MasterCheckFamily").Include("MasterSubCheckFamily")
                    .Where(p => p.ClientRowID == CId)
                    .Select(item => new ClientCheckViewModel
                    {
                        ClientCheckRowID = item.ClientCheckRowID,
                        ClientRowID = item.ClientRowID,
                        CheckFamilyRowID = item.CheckFamilyRowID,
                        CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                        SubCheckRowID = item.SubCheckRowID,
                        SubCheckFamillyName = item.MasterSubCheckFamily.SubCheckName,
                        ReportSequence = item.ReportSequence,
                        TAT = item.TAT,
                        InternalTAT = item.InternalTAT,
                        SelectedTemplate = item.SelectedTemplate,
                        CostPerCheck = item.CostPerCheck,
                        BillingPerCheck = item.BillingPerCheck,
                        AntecedentSelected = item.AntecedentSelected,
                        AddedDate = item.AddedDate,
                        Status = item.Status,
                    }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClientCheckListPagedModel GetClientChecks(int pageNo, int pageSize, string sort, string sortDir, short CId = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientCheck> data = db.PQClientChecks.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientRowID == CId);

                switch (sort)
                {
                    case "CheckFamily":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CheckFamilyRowID) : data.OrderByDescending(d => d.CheckFamilyRowID);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.CheckFamilyRowID) : data.OrderByDescending(d => d.CheckFamilyRowID);
                        break;
                }

                ClientCheckListPagedModel model = new ClientCheckListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientChecks = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientCheckViewModel
                {
                    ClientCheckRowID = item.ClientCheckRowID,
                    ClientRowID = item.ClientRowID,
                    CheckFamilyRowID = item.CheckFamilyRowID,
                    CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                    SubCheckRowID = item.SubCheckRowID,
                    SubCheckFamillyName = item.MasterSubCheckFamily.SubCheckName,
                    ReportSequence = item.ReportSequence,
                    TAT = item.TAT,
                    InternalTAT = item.InternalTAT,
                    SelectedTemplate = item.SelectedTemplate,
                    CostPerCheck = item.CostPerCheck,
                    BillingPerCheck = item.BillingPerCheck,
                    AntecedentSelected=item.AntecedentSelected,
                    AddedDate=item.AddedDate,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClientCheckViewModel GetChecksDetailsById(int ChkId = 0)
        {
            try
            {
                return db.PQClientChecks.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientCheckRowID == ChkId)
                    .Select(item => new ClientCheckViewModel
                    {
                        ClientCheckRowID = item.ClientCheckRowID,
                        ClientRowID = item.ClientRowID,
                        CheckFamilyRowID = item.CheckFamilyRowID,
                        CheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                        SubCheckRowID = item.SubCheckRowID,
                        SubCheckFamillyName = item.MasterSubCheckFamily.SubCheckName,
                        ReportSequence = item.ReportSequence,
                        TAT = item.TAT,
                        InternalTAT = item.InternalTAT,
                        SelectedTemplate = item.SelectedTemplate,
                        CostPerCheck = item.CostPerCheck,
                        BillingPerCheck = item.BillingPerCheck,
                        AntecedentSelected = item.AntecedentSelected,
                        AddedDate = item.AddedDate,
                        Status = item.Status,
                    }).FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateAntecedentCheck(int id = 0)
        {
            try
            {
                if (id != 0)
                {
                    db.PQClientChecks.Single(b => b.ClientCheckRowID == id).AntecedentSelected = 1;
                }
                else
                {
                    throw new Exception("Package Antecedent could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveChange()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public bool IsExistSubCheck(short ClientRowId = 0, short CheckFamilyId = 0, short SubCheckRowId = 0)
        {
            try
            {
                bool ret = false;
                var data = db.PQClientChecks.Where(c => c.ClientRowID == ClientRowId && c.CheckFamilyRowID == CheckFamilyId && c.SubCheckRowID == SubCheckRowId).FirstOrDefault();
                if (data !=null)
                {
                    ret = true;
                }
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region *****Temp *******
        public bool IsExistTempSubCheck(short ClientRowId = 0, short CheckFamilyId = 0, short SubCheckRowId = 0)
        {
            try
            {
                bool ret = false;
                var data = db.PQClientChecks.Where(c => c.ClientRowID == ClientRowId && c.CheckFamilyRowID == CheckFamilyId && c.SubCheckRowID == SubCheckRowId).FirstOrDefault();
                if (data != null)
                {
                    ret = true;
                }
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion
    }
}
