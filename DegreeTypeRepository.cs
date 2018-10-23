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
    public class DegreeTypeRepository : IDegreeTypeRepository
    {
        DataContext db;
        public DegreeTypeRepository()
        {
            db = new DataContext();
        }

        public void AddDegreeType(AddDegreeTypeViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterDegreeType entity = new MasterDegreeType();
                    entity.DegreeType = model.DegreeType;
                    db.MasterDegreeTypes.Add(entity);
                }
                else
                {
                    throw new Exception("DegreeType could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteDegreeType(short CRowID)
        {
            try
            {
                var entity = db.MasterDegreeTypes.Find(CRowID);
                if (entity != null)
                {
                    db.MasterDegreeTypes.Remove(entity);
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

        public IEnumerable<DegreeTypeViewModel> GetDegreeTypes()
        {
            try
            {
                return db.MasterDegreeTypes.Select(c => new DegreeTypeViewModel
                {
                    DegreeRowID = c.DegreeRowID,
                    DegreeType = c.DegreeType,
                    Status = c.Status
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<DegreeViewModel> GetDegreeForExport()
        {
            try
            {
                return db.MasterDegreeTypes.Select(c => new DegreeViewModel { RowID = c.DegreeRowID,Degree=c.DegreeType }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DegreeTypeListPagedModel GetDegreeType(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterDegreeType> data = db.MasterDegreeTypes;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.DegreeType.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "DegreeType":
                        data = sortDir == "asc" ? data.OrderBy(d => d.DegreeType) : data.OrderByDescending(d => d.DegreeType);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.DegreeType) : data.OrderByDescending(d => d.DegreeType);
                        break;
                }

                DegreeTypeListPagedModel model = new DegreeTypeListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.DegreeTypes = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new DegreeTypeViewModel
                {
                    DegreeRowID = item.DegreeRowID,
                    DegreeType = item.DegreeType,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateDegreeTypeViewModel GetDegreeTypeForUpdateById(short DegreeTypeRowID)
        {
            try
            {
                UpdateDegreeTypeViewModel model = new UpdateDegreeTypeViewModel();
                var entity = db.MasterDegreeTypes.Find(DegreeTypeRowID);

                if (entity != null)
                {
                    model.DegreeRowID = entity.DegreeRowID;
                    model.DegreeType = entity.DegreeType;
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

        public bool IsDegreeTypeExist(string DegreeType)
        {
            try
            {
                var Degree = db.MasterDegreeTypes.Where(c => c.DegreeType.Trim().ToLower() == DegreeType.Trim().ToLower()).FirstOrDefault();
                if (Degree != null && Degree.DegreeType.Length > 0)
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

        public void UpdateDegreeType(UpdateDegreeTypeViewModel model)
        {
            try
            {
                if (model != null && model.DegreeRowID > 0)
                {
                    db.MasterDegreeTypes.Single(c => c.DegreeRowID == model.DegreeRowID).DegreeType = model.DegreeType;
                }
                else
                {
                    throw new Exception("DegreeType could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveDegree(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterDegreeTypes.Single(b => b.DegreeRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Degree could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
