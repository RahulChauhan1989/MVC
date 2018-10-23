using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class StateViewModel
    {
        [Display(Name ="ID")]
        public short StateRowID { get; set; }

        [Display(Name = "State Name")]
        public string StateName { get; set; }
                
        public short CountryRowID { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        public byte? Status { get; set; }
    }

    public class AddStateViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short StateRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string StateName { get; set; }

        [Required(ErrorMessage ="Please Select Country")]
        [Display(Name = "Select Country")]
        public short CountryRowID { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateStateViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short StateRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Please Select  Country")]
        [Display(Name = "Select Country")]
        public short CountryRowID { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class StateExportViewModel
    {       
        public short RowID { get; set; }

        public string CountryName { get; set; }

        public string StateName { get; set; }         
       
    }

    public class StateListPagedModel
    {
        public IEnumerable<StateViewModel> States { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class StateDDLViewModel
    {        
        public short StateRowID { get; set; }

        [Display(Name = "State Name :")]
        public string StateName { get; set; }
    }

    public class StateForCheckBoxViewModel
    {
        public short StateRowID { get; set; }

        [Display(Name = "State Name :")]
        public string StateName { get; set; }

        public bool StateIsChecked { get; set; }
    }

    public class StateCheckBoxList
    {
        public List<StateForCheckBoxViewModel> checkBoxList { get; set; }
    }
}
