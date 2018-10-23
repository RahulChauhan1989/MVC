using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CountryViewModel
    {
        [Display(Name = "ID")]
        public short CountryRowID { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Display(Name = "Country Calling Code")]
        public string CountryCallingCode { get; set; }

        [Display(Name = "International Dialing Prefix")]
        public string InternationalDialingPrefix { get; set; }

        public byte? Status { get; set; }
    }

    public class AddCountryViewModel
    {
        [ScaffoldColumn(false)]
        public short CountryRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string CountryName { get; set; }

        [MaxLength(10)]
        [Display(Name = "Code :")]
        public string CountryCode { get; set; }

        [MaxLength(10)]
        [Display(Name = "Calling Code :")]
        public string CountryCallingCode { get; set; }

        [MaxLength(10)]
        [Display(Name = "International Dialing Prefix :")]
        public string InternationalDialingPrefix { get; set; }


        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateCountryViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public short CountryRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string CountryName { get; set; }

        [MaxLength(10)]
        [Display(Name = "Code :")]
        public string CountryCode { get; set; }

        [MaxLength(10)]
        [Display(Name = "Calling Code :")]
        public string CountryCallingCode { get; set; }

        [MaxLength(10)]
        [Display(Name = "International Dialing Prefix :")]
        public string InternationalDialingPrefix { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class CountryListPagedModel
    {
        public IEnumerable<CountryViewModel> Countries { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class CountryExportViewModel
    {    
        public short CountryRowID { get; set; }
        
        public string CountryName { get; set; }
      
        public string CountryCode { get; set; }
       
        public string CountryCallingCode { get; set; }
      
        public string InternationalDialingPrefix { get; set; }        
    }

    public class CountryDDLViewModel
    {        
        public short CountryRowID { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }        
    }
}
