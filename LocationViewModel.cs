using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class LocationViewModel
    {
        [Display(Name ="ID")]
        public int LocationRowID { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        [Display(Name = "Pin Code")]
        public int PinCode { get; set; }

        public short? DistrictRowID { get; set; }

        [Display(Name = "District Name")]
        public string DistrictName { get; set; }

        public short? StateRowID { get; set; }

        [Display(Name = "State Name")]
        public string StateName { get; set; }

        public short? CountryRowID { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        public byte? Status { get; set; }
    }

    public class AddLocationViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int LocationRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Location Name :")]
        public string LocationName { get; set; }
                
        [RegularExpression(@"^([1-9])([0-9]){5}$", ErrorMessage = "Please enter valid pincode")]
        [Range(110001, 860000)]
        [Display(Name = "Pin Code :")]
        public int PinCode { get; set; }

        [Required(ErrorMessage = "Please Select District")]
        [Display(Name = "Select District :")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "Select State :")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Select Country :")]
        public short CountryRowID { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateLocationViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int LocationRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Location :")]
        public string LocationName { get; set; }

        [RegularExpression(@"^([1-9])([0-9]){5}$", ErrorMessage = "Please enter valid pincode")]
        [Range(110001, 860000)]
        [Display(Name = "PinCode :")]
        public int PinCode { get; set; }

        [Required(ErrorMessage ="Please Select District")]
        [Display(Name = "Select District :")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "Select State :")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Select Country :")]
        public short CountryRowID { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class LocationExportViewModel
    {
       
        public int RowID { get; set; }

        public string CountryName { get; set; }

        public string StateName { get; set; }

        public string DistrictName { get; set; }

        public string LocationName { get; set; }
      
        public int PinCode { get; set; }
        
    }

    public class LocationDDLViewModel
    {
        public int LocationRowID { get; set; }

        [Display(Name = "Location Name :")]
        public string LocationName { get; set; }
    }

    public class LocationListPagedModel
    {
        public IEnumerable<LocationViewModel> Locations { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

}
