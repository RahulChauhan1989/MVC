using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
   public class VendorCoverageViewModel
    {
        [Display(Name = "ID")]
        public int VendorCoverageRowID { get; set; }

        [Display(Name = "Vendor")]
        public short VendorRowID { get; set; }

        [Display(Name = "CheckFamily")]
        public short CheckFamilyRowID { get; set; }

        [Display(Name = "CheckFamily")]
        public string CheckFamilyName { get; set; }

        [Display(Name = "Country Name")]
        public short CountryRowID { get; set; }
        public string CountryName { get; set; }

        [Display(Name = "State")]
        public short StateRowID { get; set; }
        public string StateName { get; set; }

        [Display(Name = "VendorCost")]
        public double VendorCost { get; set; }

        [Display(Name = "Additional Costing")]
        public byte AdditionalCosting { get; set; }

        [Display(Name = "AdditionalCost")]
        public double AdditionalCost { get; set; }

        [Display(Name = "Level-1 TAT")]
        public byte Level1TAT { get; set; }

        [Display(Name = "Level-2 TAT")]
        public byte Level2TAT { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }
    }
   public class AddVendorCoverageViewModel
    {
        [Display(Name = "ID : ")]
        public int VendorCoverageRowID { get; set; }

        [Required]
        [Display(Name = "Vendor : ")]
        public short VendorRowID { get; set; }

        [Required(ErrorMessage = "Please select CheckFamily")]
        [Display(Name = "CheckFamily : ")]
        public short CheckFamilyRowID { get; set; }

        [Display(Name = "Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Please select state")]
        [Display(Name = "State : ")]
        public short StateRowID { get; set; }
        public string CoverageStateIds { get; set; }

        [Required(ErrorMessage = "Please enter Vendor Cost")]
        [Display(Name = "Vendor Cost : ")]
        public double VendorCost { get; set; }

        [Display(Name = "Additional Costing : ")]
        public byte AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost : ")]
        public double AdditionalCost { get; set; }

        [Display(Name = "Level-1 TAT : ")]
        public byte Level1TAT { get; set; }

        [Display(Name = "Level-2 TAT : ")]
        public byte Level2TAT { get; set; }

        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    public class UpdateVendorCoverageViewModel
    {
        [Required]
        [Display(Name = "ID : ")]
        public int VendorCoverageRowID { get; set; }

        [Required]
        [Display(Name = "Vendor : ")]
        public short VendorRowID { get; set; }

        [Required(ErrorMessage = "Please select CheckFamily")]
        [Display(Name = "CheckFamily : ")]
        public short CheckFamilyRowID { get; set; }

        [Display(Name = "Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Please select state")]
        [Display(Name = "State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please enter Vendor Cost")]
        [Display(Name = "Vendor Cost : ")]
        public double VendorCost { get; set; }

        [Display(Name = "Additional Costing : ")]
        public byte AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost : ")]
        public double AdditionalCost { get; set; }

        [Display(Name = "Level-1 TAT : ")]
        public byte Level1TAT { get; set; }

        [Display(Name = "Level-2 TAT : ")]
        public byte Level2TAT { get; set; }

        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class VendorCoverageListPagedModel
    {
        public IEnumerable<VendorCoverageViewModel> VendorCoverages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
