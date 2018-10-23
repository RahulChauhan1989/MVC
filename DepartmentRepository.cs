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
    public class DepartmentRepository : IDepartmentsRepository
    {
        DataContext db;
        public DepartmentRepository()
        {
            db = new DataContext();
        }
        public void AddDepartment(AddDepartmentViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterDepartment entity = new MasterDepartment();
                    entity.DepartmentName = model.DepartmentName;
                    db.MasterDepartments.Add(entity);
                }
                else
                {
                    throw new Exception("Department could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteDepartment(short CRowID)
        {
            try
            {
                var entity = db.MasterDepartments.Find(CRowID);
                if (entity != null)
                {
                    db.MasterDepartments.Remove(entity);
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

        public IEnumerable<DepartmentViewModel> GetDepartments()
        {
            try
            {
                return db.MasterDepartments.Select(c => new DepartmentViewModel { DepartmentRowID = c.DepartmentRowID, DepartmentName = c.DepartmentName, Status = c.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DepartmentExportViewModel> GetDepartmentesForExport()
        {
            try
            {
                return db.MasterDepartments.Select(c => new DepartmentExportViewModel { RowID = c.DepartmentRowID, Department = c.DepartmentName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DepartmentListPagedModel GetDepartment(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterDepartment> data = db.MasterDepartments;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.DepartmentName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "DepartmentName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.DepartmentName) : data.OrderByDescending(d => d.DepartmentName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.DepartmentName) : data.OrderByDescending(d => d.DepartmentName);
                        break;
                }

                DepartmentListPagedModel model = new DepartmentListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Departments = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new DepartmentViewModel
                {
                    DepartmentRowID = item.DepartmentRowID,
                    DepartmentName = item.DepartmentName,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateDepartmentViewModel GetDepartmentForUpdateById(short DepartmentRowID)
        {
            try
            {
                UpdateDepartmentViewModel model = new UpdateDepartmentViewModel();
                var entity = db.MasterDepartments.Find(DepartmentRowID);

                if (entity != null)
                {
                    model.DepartmentRowID = entity.DepartmentRowID;
                    model.DepartmentName = entity.DepartmentName;
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

        public bool IsDepartmentExist(string DepartmentName)
        {
            try
            {
                var Department = db.MasterDepartments.Where(c => c.DepartmentName.Trim().ToLower() == DepartmentName.Trim().ToLower()).FirstOrDefault();
                if (Department != null && Department.DepartmentName.Length > 0)
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

        public void UpdateDepartment(UpdateDepartmentViewModel model)
        {
            try
            {
                if (model != null && model.DepartmentRowID > 0)
                {
                    db.MasterDepartments.Single(c => c.DepartmentRowID == model.DepartmentRowID).DepartmentName = model.DepartmentName;
                }
                else
                {
                    throw new Exception("Department could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveDepartment(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterDepartments.Single(b => b.DepartmentRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Department could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
