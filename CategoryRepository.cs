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
    public class CategoryRepository : ICategoryRepository
    {
        DataContext db;
        public CategoryRepository()
        {
            db = new DataContext();
        }
        public void AddCategory(AddCategoryViewModel model)
        {
            try
            {
                if (model != null)
                {
                    MasterCategory entity = new MasterCategory();
                    entity.CategoryName = model.CategoryName;
                    db.MasterCategories.Add(entity);
                }
                else
                {
                    throw new Exception("Category could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCategory(short CRowID)
        {
            try
            {
                var entity = db.MasterCategories.Find(CRowID);
                if (entity != null)
                {
                    db.MasterCategories.Remove(entity);
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

        public IEnumerable<CategoryViewModel> GetCategorys()
        {
            try
            {
                return db.MasterCategories.Select(c => new CategoryViewModel { CategoryRowID = c.CategoryRowID, CategoryName = c.CategoryName, Status = c.Status }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CategoryExportViewModel> GetCategoriesForExport()
        {
            try
            {
                return db.MasterCategories.Select(c => new  CategoryExportViewModel { RowID = c.CategoryRowID,Name=c.CategoryName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CategoryListPagedModel GetCategory(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<MasterCategory> data = db.MasterCategories;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.CategoryName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "CategoryName":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CategoryName) : data.OrderByDescending(d => d.CategoryName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.CategoryName) : data.OrderByDescending(d => d.CategoryName);
                        break;
                }

                CategoryListPagedModel model = new CategoryListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.Category = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new CategoryViewModel
                {
                    CategoryRowID = item.CategoryRowID,
                    CategoryName = item.CategoryName,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateCategoryViewModel GetCategoryForUpdateById(short CategoryRowID)
        {
            try
            {
                UpdateCategoryViewModel model = new UpdateCategoryViewModel();
                var entity = db.MasterCategories.Find(CategoryRowID);

                if (entity != null)
                {
                    model.CategoryRowID = entity.CategoryRowID;
                    model.CategoryName = entity.CategoryName;
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

        public bool IsCategoryExist(string CategoryName)
        {
            try
            {
                var category = db.MasterCategories.Where(c => c.CategoryName.Trim().ToLower() == CategoryName.Trim().ToLower()).FirstOrDefault();
                if (category != null && category.CategoryName.Length > 0)
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

        public void UpdateCategory(UpdateCategoryViewModel model)
        {
            try
            {
                if (model != null && model.CategoryRowID > 0)
                {
                    db.MasterCategories.Single(c => c.CategoryRowID == model.CategoryRowID).CategoryName = model.CategoryName;
                }
                else
                {
                    throw new Exception("Category could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveCategory(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.MasterCategories.Single(b => b.CategoryRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Category could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
