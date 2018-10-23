using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IDistrictRepository
    {
        bool IsDistrictExist(string DistrictName);

        IEnumerable<DistrictExportViewModel> GetDistrictesForExport();

        void AddDistrict(AddDistrictViewModel model);

        UpdateDistrictViewModel GetDistrictForUpdateById(short DistrictRowID);

        void UpdateDistrict(UpdateDistrictViewModel model);

        void ActiveDistrict(short id = 0, string checkeds = "");

        void DeleteDistrict(short DistrictRowID);

        int SaveChanges();

        DistrictListPagedModel GetDistricts(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        List<DistrictForCheckBoxViewModel> GetDistrictForCheckbox(short countryRowID, short[] stateRowID);
    }
}
