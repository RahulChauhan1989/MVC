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
    public class CheckFamilyRepository : ICheckFamilyRepository
    {
        DataContext db;
        public CheckFamilyRepository()
        {
            db = new DataContext();
        }

        public void AddCheckFamily(AddCheckFamilyViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterCheckFamily entity = new MasterCheckFamily();
                    entity.CheckFamilyName = model.CheckFamilyName;

                    db.MasterCheckFamilies.Add(entity);
                }
                else
                {
                    throw new Exception("Check Family could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCheckFamily(short CFRowID)
        {
            try
            {
                var entity = db.MasterCheckFamilies.Find(CFRowID);
                if (entity != null)
                {
                    db.MasterCheckFamilies.Remove(entity);
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

        public IEnumerable<CheckFamilyViewModel> GetCheckFamily()
        {
            try
            {
                return db.MasterCheckFamilies.Where(c=>c.Status==1 && c.CheckFamilyRowID != 39).Select(c => new CheckFamilyViewModel
                {
                    CheckFamilyRowID = c.CheckFamilyRowID,
                    CheckFamilyName = c.CheckFamilyName,
                    Status = c.Status }
                ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CheckFamilyExportViewModel> GetCheckFamiliesForExport()
        {
            try
            {
                return db.MasterCheckFamilies.Select(c => new CheckFamilyExportViewModel { RowID = c.CheckFamilyRowID, Name = c.CheckFamilyName }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CheckFamilyListPagedModel GetCheckFamily(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterCheckFamily> data = db.MasterCheckFamilies;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(c => c.CheckFamilyName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "CheckFamilyName":
                        data = sortDir == "asc" ? data.OrderBy(c => c.CheckFamilyName) : data.OrderByDescending(c => c.CheckFamilyName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(c => c.CheckFamilyName) : data.OrderByDescending(c => c.CheckFamilyName);
                        break;
                }
                CheckFamilyListPagedModel model = new CheckFamilyListPagedModel();

                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.CheckFamily = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new CheckFamilyViewModel
                {
                    CheckFamilyRowID = item.CheckFamilyRowID,
                    CheckFamilyName = item.CheckFamilyName,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateCheckFamilyViewModel GetCheckFamilyForUpdateById(short CFRowID)
        {
            try
            {
                UpdateCheckFamilyViewModel model = new UpdateCheckFamilyViewModel();
                var entity = db.MasterCheckFamilies.Find(CFRowID);
                if (entity != null)
                {
                    model.CheckFamilyRowID = entity.CheckFamilyRowID;
                    model.CheckFamilyName = entity.CheckFamilyName;
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

        public bool IsCheckFamilyExist(string CheckFamilyName)
        {
            try
            {
                var CheckFamily = db.MasterCheckFamilies.Where(c => c.CheckFamilyName.Trim().ToLower() == CheckFamilyName.Trim().ToLower()).FirstOrDefault();
                if (CheckFamily != null && CheckFamily.CheckFamilyName.Length > 0)
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

        public void UpdateCheckFamily(UpdateCheckFamilyViewModel model)
        {
            try
            {
                if (model != null && model.CheckFamilyRowID > 0)
                {
                    db.MasterCheckFamilies.Single(c => c.CheckFamilyRowID == model.CheckFamilyRowID).CheckFamilyName = model.CheckFamilyName;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveCheckFamily(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterCheckFamilies.Single(b => b.CheckFamilyRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Check Family could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
