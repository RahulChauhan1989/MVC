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
    public class ClientPackageRepository : IClientPackageRepository
    {
        DataContext db;
        public ClientPackageRepository()
        {
            db = new DataContext();
        }
        public void AddClientPackage(AddClientPackageViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientPackage entity = new PQClientPackage();
                    entity.ClientPackageName = model.ClientPackageName;
                    entity.ClientRowID = model.ClientRowID;
                    entity.CheckFamilyRowID = model.CheckFamilyRowID;
                    entity.SubCheckRowID = model.SubCheckRowID;
                    entity.ReportSequence = model.ReportSequence;
                    entity.TAT = model.TAT;
                    entity.InternalTAT = model.InternalTAT;
                    entity.BillingPerCheck = model.BillingPerCheck;
                    entity.CostPerCheck = model.CostPerCheck;
                    entity.AntecedentSelected = model.AntecedentSelected;
                    entity.SelectedTemplate = model.SelectedTemplate;
                    entity.AddedDate = DateTime.Now;

                    db.PQClientPackages.Add(entity);
                }
                else
                {
                    throw new Exception("Package Name could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientPackageViewModel> GetPackagesByClientId(short CId = 0)
        {
            try
            {
                return db.PQClientPackages.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientRowID == CId)
                     .Select(item => new ClientPackageViewModel
                     {
                         ClientPackageRowID = item.ClientPackageRowID,
                         ClientPackageName = item.ClientPackageName,
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
                         AddedDate = item.AddedDate,
                         AntecedentSelected = item.AntecedentSelected,
                         Status = item.Status,
                     }).ToList();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public ClientPackageListPagedModel GetClientPackages(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientPackage> data = db.PQClientPackages.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientRowID == CId);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.ClientPackageName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "PackageName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientPackageName) : data.OrderByDescending(d => d.ClientPackageName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientPackageName) : data.OrderByDescending(d => d.ClientPackageName);
                        break;
                }

                ClientPackageListPagedModel model = new ClientPackageListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientPackages = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientPackageViewModel
                {
                    ClientPackageRowID = item.ClientPackageRowID,
                    ClientPackageName = item.ClientPackageName,
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
                    AddedDate = item.AddedDate,
                    AntecedentSelected = item.AntecedentSelected,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PackageListPagedModel GetPackages(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientPackage> data = db.PQClientPackages
                    .Include("MasterCheckFamily")
                    .Include("MasterSubCheckFamily")
                    .GroupBy(p => new { p.ClientPackageName })
                    .Select(m => m.FirstOrDefault());

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.ClientPackageName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "PackageName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientPackageName) : data.OrderByDescending(d => d.ClientPackageName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.ClientPackageName) : data.OrderByDescending(d => d.ClientPackageName);
                        break;
                }

                PackageListPagedModel model = new PackageListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Packages = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new ClientPackageViewModel
                {
                    ClientPackageRowID = item.ClientPackageRowID,
                    ClientPackageName = item.ClientPackageName,
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
                    AddedDate = item.AddedDate,
                    AntecedentSelected = item.AntecedentSelected,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientPackageViewModel> GetPackageDetailsByPackageName(string PackageName = "")
        {
            try
            {
                return db.PQClientPackages.Where(item => item.Status == 1 && item.ClientPackageName == PackageName)
                     .Select(item => new ClientPackageViewModel
                     {
                         ClientPackageRowID = item.ClientPackageRowID,
                         ClientPackageName = item.ClientPackageName,
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
                         AddedDate = item.AddedDate,
                         AntecedentSelected = item.AntecedentSelected,
                         Status = item.Status,
                     }
                    ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClientPackageViewModel GetPackageDetailsById(int CPId = 0)
        {
            try
            {
                return db.PQClientPackages.Include("MasterCheckFamily").Include("MasterSubCheckFamily").Where(p => p.ClientPackageRowID == CPId)
                     .Select(item => new ClientPackageViewModel
                     {
                         ClientPackageRowID = item.ClientPackageRowID,
                         ClientPackageName = item.ClientPackageName,
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
                         AddedDate = item.AddedDate,
                         AntecedentSelected = item.AntecedentSelected,
                         Status = item.Status,
                     }).FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateAntecedentPackage(int id = 0)
        {
            try
            {
                if (id != 0)
                {
                    db.PQClientPackages.Single(b => b.ClientPackageRowID == id).AntecedentSelected = 1;
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

        public bool IsPackageExist(string PackageName)
        {
            try
            {
                var CPackageName = db.PQClientPackages.Where(c => c.ClientPackageName.Trim().ToLower() == PackageName.Trim().ToLower()).FirstOrDefault();
                if (CPackageName != null && CPackageName.ClientPackageName.Length > 0)
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

    }
}
