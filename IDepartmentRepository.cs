using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
  public interface IDepartmentsRepository
    {
        bool IsDepartmentExist(string DepartmentName);

        void AddDepartment(AddDepartmentViewModel model);

        UpdateDepartmentViewModel GetDepartmentForUpdateById(short DepartmentRowID);

        void UpdateDepartment(UpdateDepartmentViewModel model);

        void DeleteDepartment(short CRowID);

        int SaveChanges();

        void ActiveDepartment(short id = 0, string checkeds = "");

        IEnumerable<DepartmentViewModel> GetDepartments();

        IEnumerable<DepartmentExportViewModel> GetDepartmentesForExport();

        DepartmentListPagedModel GetDepartment(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
