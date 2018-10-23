using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public class SubCheckFamilyRepository : ISubCheckFamilyRepository
    {
        DataContext db;
        public SubCheckFamilyRepository()
        {
            db = new DataContext();
        }

        public void AddSubCheckFamily(AddSubCheckFamilyViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterSubCheckFamily entity = new MasterSubCheckFamily();
                    entity.SubCheckName = model.SubCheckName;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.InternalTAT = model.InternalTAT;
                    entity.TAT = model.TAT;
                    entity.CostPerCase = model.CostParCase;
                    db.MasterSubCheckFamilies.Add(entity);
                }
                else
                {
                    throw new Exception("Sub Check Family could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSubCheckFamily(short CFRowID)
        {
            try
            {
                var entity = db.MasterSubCheckFamilies.Find(CFRowID);
                if (entity != null)
                {
                    db.MasterSubCheckFamilies.Remove(entity);
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SubCheckFamilyViewModel> GetSubCheckFamily()
        {
            try
            {
                return db.MasterSubCheckFamilies.Where(c => c.Status == 1 && c.CheckFamilyRowID != 39).Select(c =>
                new SubCheckFamilyViewModel
                {
                    SubCheckFamilyRowID = c.SubCheckRowID,
                    SubCheckName = c.SubCheckName,
                    CheckFamilyRowID=c.CheckFamilyRowID,
                    CostParCase =c.CostPerCase,
                    InternalTAT =c.InternalTAT,
                    TAT =c.TAT,
                    Status = c.Status
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SubCheckFamilyExportViewModel> GetSubCheckFamiliesForExport()
        {
            try
            {
                return db.MasterSubCheckFamilies.Select(c =>
                new SubCheckFamilyExportViewModel
                {
                    RowID = c.SubCheckRowID,
                    Name = c.SubCheckName,
                    CheckFamilyName = c.MasterCheckFamily.CheckFamilyName,
                    CostParCase = c.CostPerCase,
                    InternalTAT = c.InternalTAT,
                    TAT = c.TAT                   
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SubCheckFamilyListPagedModel GetSubCheckFamily(int pageNo, int pageSize, string sort, string sortDir,short CheckFamilyRowID=0, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterSubCheckFamily> data = db.MasterSubCheckFamilies.Where(a=>a.MasterCheckFamily.Status==1);
                if (!string.IsNullOrEmpty(Search) || CheckFamilyRowID > 0)
                {
                    if (CheckFamilyRowID > 0)
                    {
                        data = data.Where(d => d.CheckFamilyRowID == CheckFamilyRowID);
                    }
                    if (!string.IsNullOrEmpty(Search))
                    {
                        data = data.Where(d => d.SubCheckName.Contains(Search));
                    }
                }
                //if (!string.IsNullOrEmpty(Search) && CheckFamilyRowID > 0)
                //{
                //    data = data.Where(c => c.MasterCheckFamily.CheckFamilyRowID == CheckFamilyRowID && c.SubCheckName.ToString().Contains(Search));
                //}

                switch (sort)
                {
                    case "subcheckname":
                        data = sortDir == "asc" ? data.OrderBy(c => c.SubCheckName) : data.OrderByDescending(c => c.SubCheckName);
                        break;
                    case "checkfamilyname":
                        data = sortDir == "asc" ? data.OrderBy(c => c.MasterCheckFamily.CheckFamilyName) : data.OrderByDescending(c => c.MasterCheckFamily.CheckFamilyName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(c => c.SubCheckName) : data.OrderByDescending(c => c.SubCheckName);
                        break;
                }
                SubCheckFamilyListPagedModel model = new SubCheckFamilyListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.SubCheckFamily = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new SubCheckFamilyViewModel
                {
                    SubCheckFamilyRowID = item.SubCheckRowID,
                    SubCheckName = item.SubCheckName,
                    MasterCheckFamilyName = item.MasterCheckFamily.CheckFamilyName,
                    Status = item.Status,
                    CostParCase = item.CostPerCase,
                    InternalTAT = item.InternalTAT,
                    TAT = item.TAT
                   
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateSubCheckFamilyViewModel GetSubCheckFamilyForUpdateById(short CFRowID)
        {
            try
            {
                UpdateSubCheckFamilyViewModel model = new UpdateSubCheckFamilyViewModel();
                var entity = db.MasterSubCheckFamilies.Find(CFRowID);
                if (entity != null)
                {
                    model.SubCheckFamilyRowID = entity.SubCheckRowID;
                    model.SubCheckName = entity.SubCheckName;
                    model.CheckFamilyRowID = entity.CheckFamilyRowID;
                    model.CostParCase = entity.CostPerCase;
                    model.InternalTAT = entity.InternalTAT;
                    model.TAT = entity.TAT;
                    model.Status = entity.Status;

                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsSubCheckFamilyExist(string SubCheckName, short CheckFamilyId, short SubCheckId)
        {
            try
            {
                var SubCheck = db.MasterSubCheckFamilies
                    .Where(s => (s.SubCheckName.Trim().ToLower() == SubCheckName.Trim().ToLower() && s.MasterCheckFamily.CheckFamilyRowID == CheckFamilyId) && s.SubCheckRowID != SubCheckId)
                    .FirstOrDefault();

                if (SubCheck != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        public bool IsSubCheckFamilyExist(string SubCheckName, short id)
        {
            try
            {
                var SubCheckFamily = db.MasterSubCheckFamilies.Where(c => c.SubCheckName.Trim().ToLower() == SubCheckName.Trim().ToLower()).FirstOrDefault();
                if (SubCheckFamily != null && SubCheckFamily.SubCheckName.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveChanges()
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

        public void UpdateSubCheckFamily(UpdateSubCheckFamilyViewModel model)
        {
            try
            {
                if (model != null && model.SubCheckFamilyRowID > 0)
                {
                    db.MasterSubCheckFamilies.Single(c => c.SubCheckRowID == model.SubCheckFamilyRowID).SubCheckName = model.SubCheckName;
                    db.MasterSubCheckFamilies.Single(c => c.SubCheckRowID == model.SubCheckFamilyRowID).CheckFamilyRowID = model.CheckFamilyRowID;
                    db.MasterSubCheckFamilies.Single(c => c.SubCheckRowID == model.SubCheckFamilyRowID).CostPerCase = model.CostParCase;
                    db.MasterSubCheckFamilies.Single(c => c.SubCheckRowID == model.SubCheckFamilyRowID).InternalTAT = model.InternalTAT;
                    db.MasterSubCheckFamilies.Single(c => c.SubCheckRowID == model.SubCheckFamilyRowID).TAT = model.TAT;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveSubCheckFamily(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterSubCheckFamilies.Single(b => b.SubCheckRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Sub Check Family could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
