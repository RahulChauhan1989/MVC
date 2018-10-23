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
    public class DesignationRepository : IDesignationRepository
    {
        DataContext db;

        public DesignationRepository()
        {
            db = new DataContext();
        }

        public void AddDesignation(AddDesignationViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterDesignation entity = new MasterDesignation();
                    entity.DesignationName = model.DesignationName;
                    entity.DepartmentRowID = model.DepartmentRowID;

                    db.MasterDesignations.Add(entity);
                }
                else
                {
                    throw new Exception("Designation could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteDesignation(short CRowID)
        {
            try
            {
                var entity = db.MasterDesignations.Find(CRowID);
                if (entity != null)
                {
                    db.MasterDesignations.Remove(entity);
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

        public IEnumerable<DesignationViewModel> GetDesignations()
        {
            try
            {
                return db.MasterDesignations.Select(c => new DesignationViewModel { DesignationRowID = c.DesignationRowID, DesignationName = c.DesignationName, DepartmentName = c.MasterDepartment.DepartmentName, Status = c.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DesignationExportViewModel> GetDesignationsForExport()
        {
            try
            {
                return db.MasterDesignations.Select(c => new DesignationExportViewModel { RowID = c.DesignationRowID,Department=c.MasterDepartment.DepartmentName,Designation=c.DesignationName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DesignationListPagedModel GetDesignation(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterDesignation> data = db.MasterDesignations;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.DesignationName.ToString().Contains(Search) || b.MasterDepartment.DepartmentName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "DesignationName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.DesignationName) : data.OrderByDescending(d => d.DesignationName);
                        break;
                    case "departmentname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.MasterDepartment.DepartmentName) : data.OrderByDescending(d => d.MasterDepartment.DepartmentName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.DesignationName) : data.OrderByDescending(d => d.DesignationName);
                        break;
                }

                DesignationListPagedModel model = new DesignationListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Designations = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new DesignationViewModel
                {
                    DesignationRowID = item.DesignationRowID,
                    DesignationName = item.DesignationName,
                    DepartmentRowID = item.MasterDepartment.DepartmentRowID,
                    DepartmentName = item.MasterDepartment.DepartmentName,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateDesignationViewModel GetDesignationForUpdateById(short DesignationRowID)
        {
            try
            {
                UpdateDesignationViewModel model = new UpdateDesignationViewModel();
                var entity = db.MasterDesignations.Find(DesignationRowID);

                if (entity != null)
                {
                    model.DesignationRowID = entity.DesignationRowID;
                    model.DesignationName = entity.DesignationName;
                    model.DepartmentRowID = entity.DepartmentRowID;
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

        public bool IsDesignationExist(string DesignationName, byte? DepartmentRowID)
        {
            try
            {
                var Designation = db.MasterDesignations.Where(c => c.DesignationName.Trim().ToLower() == DesignationName.Trim().ToLower()&&c.MasterDepartment.DepartmentRowID==DepartmentRowID).FirstOrDefault();
                if (Designation != null && Designation.DesignationName.Length > 0)
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

        public bool IsDesignationExist(UpdateDesignationViewModel model)
        {
            try
            {
                var Designation = db.MasterDesignations.Where(c => c.DesignationName.Trim().ToLower() == model.DesignationName.Trim().ToLower() && c.DepartmentRowID == model.DepartmentRowID && c.DesignationRowID != model.DesignationRowID).FirstOrDefault();
                if (Designation != null)
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

        public void UpdateDesignation(UpdateDesignationViewModel model)
        {
            try
            {
                if (model != null && model.DesignationRowID > 0)
                {
                    db.MasterDesignations.Single(c => c.DesignationRowID == model.DesignationRowID).DesignationName = model.DesignationName;
                    db.MasterDesignations.Single(c => c.DesignationRowID == model.DesignationRowID).DepartmentRowID = model.DepartmentRowID;
                }
                else
                {
                    throw new Exception("Designation could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveDesignation(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db. MasterDesignations.Single(b => b.DesignationRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Designation could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
