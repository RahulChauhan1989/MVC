using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ICategoryRepository
    {
        bool IsCategoryExist(string CategoryName);

        void AddCategory(AddCategoryViewModel model);

        UpdateCategoryViewModel GetCategoryForUpdateById(short CategoryRowIDRowID);

        void UpdateCategory(UpdateCategoryViewModel model);

        void DeleteCategory(short CRowID);

        int SaveChanges();

        IEnumerable<CategoryViewModel> GetCategorys();

        void ActiveCategory(short id = 0, string checkeds = "");

        IEnumerable<CategoryExportViewModel> GetCategoriesForExport();

        CategoryListPagedModel GetCategory(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
