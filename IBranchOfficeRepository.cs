using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IBranchOfficeRepository
    {
        bool IsBranchOfficeExist(string BranchName);

        bool IsBranchOfficeExist(string BOName, short BORowID);

        void AddBranchOffice(AddBranchOfficeViewModel model);

        UpdateBranchOfficeViewModel GetBranchOfficeForUpdateById(short BORowID);

        IEnumerable<BranchOfficeExportViewModel> GetBranchOfficesForExport();

        void UpdateBranchOffice(UpdateBranchOfficeViewModel model);

        void DeleteBranchOffice(short BORowID);

        void ActiveBranchOffice(short id = 0, string checkeds="");

        int SaveChanges();
        
        IEnumerable<BranchOfficeViewModel> GetBranchOffices();

        BranchOfficeListPagedModel GetBranchOffices(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0);
    }
}
