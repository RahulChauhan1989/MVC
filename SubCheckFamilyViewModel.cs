using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class SubCheckFamilyViewModel
    {
        [Display(Name ="ID")]
        public short SubCheckFamilyRowID { get; set; }

        [Display(Name = "Sub Check")]
        public string SubCheckName { get; set; }

        public short CheckFamilyRowID { get; set; }

        [Display(Name = "Check Family")]
        public string MasterCheckFamilyName { get; set; }

        [Display(Name = "Internal TAT")]
        public byte InternalTAT { get; set; }

        [Display(Name = "TAT")]
        public byte TAT { get; set; }

        [Display(Name = "Cost Per Case")]
        public double CostParCase { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class AddSubCheckFamilyViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short SubCheckFamilyRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string SubCheckName { get; set; }

        [Required]
        [Display(Name = "Check Family:")]
        public short CheckFamilyRowID { get; set; }

        [Display(Name = "Internal TAT :")]
        public byte InternalTAT { get; set; }

        [Display(Name ="TAT :")]
        public byte TAT { get; set; }

        [Display(Name = "Cost Per Case :")]
        public double CostParCase { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateSubCheckFamilyViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short SubCheckFamilyRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string SubCheckName { get; set; }
    
        [Required]
        [Display(Name = "Check Family :")]
        public short CheckFamilyRowID { get; set; }

        [Display(Name = "Internal TAT :")]
        public byte InternalTAT { get; set; }

        [Display(Name = "TAT :")]
        public byte TAT { get; set; }

        [Display(Name = "Cost Per Case :")]
        public double CostParCase { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class SubCheckFamilyExportViewModel
    {        
        public short RowID { get; set; }
       
        public string Name { get; set; }

        public string CheckFamilyName { get; set; }
        
        public byte InternalTAT { get; set; }
       
        public byte TAT { get; set; }
        
        public double CostParCase { get; set; }
        
    }

    public class SubCheckFamilyListPagedModel
    {
        public IEnumerable<SubCheckFamilyViewModel> SubCheckFamily { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class pkgSubCheckFamilyViewModel
    {
        [Display(Name = "ID")]
        public short SubCheckFamilyRowID { get; set; }

        [Display(Name = "Sub Check")]
        public string SubCheckName { get; set; }

        public short CheckFamilyRowID { get; set; }

        public Boolean SubChkPkg { get; set; }

        public short NoofEntries { get; set; }

        public double BillingPerCase { get; set; }

        public byte ReportSequence { get; set; }

        public byte TemplateName { get; set; }

        [Display(Name = "Internal TAT")]
        public byte InternalTAT { get; set; }

        [Display(Name = "TAT")]
        public byte TAT { get; set; }

        [Display(Name = "Cost Per Case")]
        public double CostParCase { get; set; }
        
    }


    public class SubCheckFamilyForDDLViewModel
    {
        [Display(Name = "ID")]
        public short SubCheckRowID { get; set; }

        [Display(Name = "Sub Check")]
        public string SubCheckName { get; set; }
    }
}
