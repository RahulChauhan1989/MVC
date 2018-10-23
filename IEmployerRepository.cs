using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IEmployerRepository
    {
        bool IsEmployerExist(string EmployerName);

        bool IsEmployerExist(int EmployerRowID, string EmployerName);

        void AddEmployer(AddEmployerViewModel model);

        UpdateEmployerViewModel GetEmployerForUpdateById(short EmployerRowID);

        EmployerViewModel GetEmployerForDetailsById(short EmployerRowID);

        void UpdateEmployer(UpdateEmployerViewModel model);

        void ActiveEmployer(short id = 0, string checkeds = "");

        void DeleteEmployer(short CRowID);

        int SaveChanges();

        IEnumerable<EmployerViewModel> GetEmployers();

        IEnumerable<EmployerExportViewModel> GetEmployeresForExport();

        EmployerListPagedModel GetEmployer(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
        EmployerListPagedModel GetBeyondEmployer(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
