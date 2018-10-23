using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IVendorRepository
    {
        bool IsVendorExist(string VendorName);

        bool IsVendorExist(short VendorRowID, string VendorName);

        void AddVendor(AddVendorViewModel model);

        UpdateVendorViewModel GetVendorForUpdateById(short VendorRowID);

        void UpdateVendor(UpdateVendorViewModel model);

        void DeleteVendor(short CRowID);

        int SaveChanges();

        void ActiveVendor(short id = 0, string checkeds = "");

        IEnumerable<VendorViewModel> GetVendors();

        IEnumerable<VendorExportViewModel> GetVendoresForExport();

        VendorListPagedModel GetVendor(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        short GetLastVendorIdByName(string VName = "");

        VendorViewModel GetVendorForDetailsById(short VendorRowID);
        
    }
}
