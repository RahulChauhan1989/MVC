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
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        DataContext db;

        public BranchOfficeRepository()
        {
            db = new DataContext();
        }
        public void AddBranchOffice(AddBranchOfficeViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterCompanyBranch entity = new MasterCompanyBranch();
                    entity.BOName = model.BOName;
                    entity.BOAddress = model.BOAddress;
                    entity.BOConcernPersonName = model.BOConcernPersonName;
                    entity.BOContactNumber = model.BOContactNumber;
                    entity.BOEmailId = model.BOEmailId;
                    entity.CompanyRowID = model.CompanyRowID;
                    db.MasterCompanyBranches.Add(entity);
                }
                else
                {
                    throw new Exception("Branch office could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteBranchOffice(short BORowID)
        {
            try
            {
                var entity = db.MasterCompanyBranches.Find(BORowID);

                if (entity != null)
                {
                    db.MasterCompanyBranches.Remove(entity);
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

        public UpdateBranchOfficeViewModel GetBranchOfficeForUpdateById(short BORowID)
        {
            try
            {
                UpdateBranchOfficeViewModel model = new UpdateBranchOfficeViewModel();
                var entity = db.MasterCompanyBranches.Find(BORowID);

                if (entity != null)
                {
                    model.BORowID = entity.BORowID;
                    model.BOName = entity.BOName;
                    model.BOAddress = entity.BOAddress;
                    model.BOConcernPersonName = entity.BOConcernPersonName;
                    model.BOContactNumber = entity.BOContactNumber;
                    model.BOEmailId = entity.BOEmailId;
                    model.CompanyRowID = entity.CompanyRowID;
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

        public void UpdateBranchOffice(UpdateBranchOfficeViewModel model)
        {
            try
            {
                if (model != null && model.BORowID > 0)
                {
                    db.MasterCompanyBranches.Single(b => b.BORowID == model.BORowID).BOName = model.BOName;
                    db.MasterCompanyBranches.Single(b => b.BORowID == model.BORowID).BOAddress = model.BOAddress;
                    db.MasterCompanyBranches.Single(b => b.BORowID == model.BORowID).BOConcernPersonName = model.BOConcernPersonName;
                    db.MasterCompanyBranches.Single(b => b.BORowID == model.BORowID).BOContactNumber = model.BOContactNumber;
                    db.MasterCompanyBranches.Single(b => b.BORowID == model.BORowID).BOEmailId = model.BOEmailId;

                }
                else
                {
                    throw new Exception("Branch office could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<BranchOfficeViewModel> GetBranchOffices()
        {
            try
            {
                return db.MasterCompanyBranches.Select(b => new BranchOfficeViewModel { BORowID = b.BORowID, BOName = b.BOName, BOAddress = b.BOAddress, BOConcernPersonName = b.BOConcernPersonName, BOContactNumber = b.BOContactNumber, BOEmailId = b.BOEmailId, CompanyRowID = b.CompanyRowID, Status = b.Status }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<BranchOfficeExportViewModel> GetBranchOfficesForExport()
        {
            try
            {
                return db.MasterCompanyBranches.Select(b => new BranchOfficeExportViewModel {RowID = b.BORowID, Name = b.BOName, Address = b.BOAddress, ConcernPersonName = b.BOConcernPersonName, ContactNumber = b.BOContactNumber, EmailId = b.BOEmailId}).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public BranchOfficeListPagedModel GetBranchOffices(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterCompanyBranch> data = db.MasterCompanyBranches.Where(b => b.CompanyRowID == CId);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.BOName.ToString().Contains(Search) || b.BOAddress.ToString().Contains(Search) || b.BOConcernPersonName.ToString().Contains(Search) || b.BOContactNumber.ToString().Contains(Search) || b.BOEmailId.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "boname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.BOName) : data.OrderByDescending(d => d.BOName);
                        break;
                    case "BOaddress":
                        data = sortDir == "asc" ? data.OrderBy(d => d.BOAddress) : data.OrderByDescending(d => d.BOAddress);
                        break;
                    case "BOCPName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.BOConcernPersonName) : data.OrderByDescending(d => d.BOConcernPersonName);
                        break;
                    case "BOCNumber":
                        data = sortDir == "asc" ? data.OrderBy(d => d.BOContactNumber) : data.OrderByDescending(d => d.BOContactNumber);
                        break;
                    case "BOemailId":
                        data = sortDir == "asc" ? data.OrderBy(d => d.BOEmailId) : data.OrderByDescending(d => d.BOEmailId);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.BOName) : data.OrderByDescending(d => d.BOName);
                        break;
                }

                BranchOfficeListPagedModel model = new BranchOfficeListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.BranchOffices = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new BranchOfficeViewModel
                {
                    BORowID = item.BORowID,
                    BOName = item.BOName,
                    BOAddress = item.BOAddress,
                    BOConcernPersonName = item.BOConcernPersonName,
                    BOContactNumber = item.BOContactNumber,
                    BOEmailId = item.BOEmailId,
                    Status = item.Status,
                    CompanyRowID = item.CompanyRowID

                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsBranchOfficeExist(string BranchName)
        {
            try
            {
                var branch = db.MasterCompanyBranches.Where(b => b.BOName.Trim().ToLower() == BranchName.Trim().ToLower()).FirstOrDefault();
                if (branch != null)
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

        public bool IsBranchOfficeExist(string BOName, short BORowID)
        {
            try
            {
                var branch = db.MasterCompanyBranches.Where(b => b.BOName.Trim().ToLower() == BOName.Trim().ToLower() && b.BORowID != BORowID).FirstOrDefault();
                if (branch != null)
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

        public void ActiveBranchOffice(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds!=null)
                {
                    db.MasterCompanyBranches.Single(b => b.BORowID == id).Status =Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Branch office could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
