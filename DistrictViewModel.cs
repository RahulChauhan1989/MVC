using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DistrictViewModel
    {
        [Display(Name = "ID")]
        public short DistrictRowID { get; set; }
      
        [Display(Name = "District ")]
        public string DistrictName { get; set; }

        public short StateRowID { get; set; }
        [Display(Name = "State ")]
        public string StateName { get; set; }

        public short CountryRowID { get; set; }
        [Display(Name = "Country ")]
        public string CountryName { get; set; }

        public byte? Status { get; set; }
    }

    public class AddDistrictViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short DistrictRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string DistrictName { get; set; }

        [Required(ErrorMessage ="Please Select State")]
        [Display(Name = "State :")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage ="Please Select Country")]
        [Display(Name = "Select Country :")]
        public short CountryRowID { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateDistrictViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short DistrictRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string DistrictName { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "Select State :")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Select Country :")]
        public short CountryRowID { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class DistrictExportViewModel
    {        
        public short RowID { get; set; }

        public string CountryName { get; set; }  
             
        public string StateName { get; set; }

        public string DistrictName { get; set; }
    }

    public class DistrictListPagedModel
    {
        public IEnumerable<DistrictViewModel> Districts { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class DistrictDDLViewModel
    {
        public short DistrictRowID { get; set; }

        [Display(Name = "District Name :")]
        public string DistrictName { get; set; }
    }

    public class DistrictForCheckBoxViewModel
    {
        public short DistrictRowID { get; set; }

        [Display(Name = "District Name :")]
        public string DistrictName { get; set; }

        public short StateRowID { get; set; }

        public string StateName { get; set; }

        public bool DistrictIsChecked { get; set; }
    }
    public class DistrictCheckBoxList
    {
        public List<DistrictForCheckBoxViewModel> checkBoxList { get; set; }
    }
}
