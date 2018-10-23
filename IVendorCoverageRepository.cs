using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IVendorCoverageRepository
    {      
        bool IsCoverageChecksExist(short VendorRowID, short CheckFamilyRowID,short StateRowID);

        void AddVendorCoverage(AddVendorCoverageViewModel model);

        UpdateVendorCoverageViewModel GetVendorCoverageForUpdateById(int VendorRowID);

        void UpdateVendorCoverage(UpdateVendorCoverageViewModel model);

        void ActiveVendorCoverage(short id = 0, string checkeds = "");

        int SaveChanges();

        IEnumerable<VendorCoverageViewModel> GetVendorCoverages();

        VendorCoverageListPagedModel GetVendorCoverages(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short VID = 0);        
    }
}
