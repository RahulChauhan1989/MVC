using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class VCDistrictViewModel
    {
        [Display(Name ="ID")]
        public int VCDistrictRowID { get; set; }

        [Display(Name = "Vendor Coverage")]
        public int VendorCoverageRowID { get; set; }

        [Display(Name = "State")]
        public short StateRowID { get; set; }
        public string StateName { get; set; }

        [Display(Name = "District")]
        public short DistrictRowID { get; set; }
        public string DistrictName { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class AddVCDistrictViewModel
    {
        [Display(Name = "ID : ")]
        public int VCDistrictRowID { get; set; }

        [Display(Name = "Vendor : ")]
        public short VendorRowID { get; set; }

        [Display(Name = "Vendor Coverage : ")]
        public int VendorCoverageRowID { get; set; }

        [Display(Name = "Country : ")]
        public short CountryRowID { get; set; }
        public string CountryName { get; set; }

        [Display(Name = "State : ")]
        public short StateRowID { get; set; }
        public string StateName { get; set; }
        
        [Display(Name = "District : ")]
        public short DistrictRowID { get; set; }

        public string CoverageDistrictIds { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class UpdateVCDistrictViewModel
    {
       
        [Display(Name = "ID : ")]
        public int VCDistrictRowID { get; set; }

        [Display(Name = "Vendor : ")]
        public short VendorRowID { get; set; }

        [Display(Name = "Vendor Coverage : ")]
        public int VendorCoverageRowID { get; set; }

        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }
        public string CoverageDistrictIds { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class VCDistrictListPagedModel
    {
        public IEnumerable<VCDistrictViewModel> VCoverageDistricts { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        [Display(Name = "Vendor : ")]
        public short VendorRowID { get; set; }

        [Display(Name = "Vendor Coverage : ")]
        public int VendorCoverageRowID { get; set; }
    }
}
