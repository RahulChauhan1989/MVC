using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IDesignationRepository
    {
        bool IsDesignationExist(string DesignationName, byte? DepartmentRowID);

        void AddDesignation(AddDesignationViewModel model);

        UpdateDesignationViewModel GetDesignationForUpdateById(short DesignationRowIDRowID);

        void UpdateDesignation(UpdateDesignationViewModel model);

        void DeleteDesignation(short CRowID);

        int SaveChanges();

        void ActiveDesignation(short id = 0, string checkeds = "");


        IEnumerable<DesignationViewModel> GetDesignations();

        IEnumerable<DesignationExportViewModel> GetDesignationsForExport();

        DesignationListPagedModel GetDesignation(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
