using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IVCoverageDistrictRepository
    {
        bool IsVCCoverageChecksExist(int VendorCoverageRowID, short DistrictRowID);

        void AddVendorCoverageDistrict(AddVCDistrictViewModel model);

        UpdateVCDistrictViewModel GetVendorCoverageDistrictForUpdateById(int VendorRowID);

        void UpdateVendorCoverageDistrict(UpdateVCDistrictViewModel model);

        void ActiveVendorCoverageDistrict(short id = 0, string checkeds = "");

        int SaveChanges();

        IEnumerable<VCDistrictViewModel> GetVendorCoverageDistricts();

        VCDistrictListPagedModel GetVendorCoverageDistricts(int pageNo, int pageSize, string sort, string sortDir, string Search = "", int vcoverageid = 0);
    }
}
