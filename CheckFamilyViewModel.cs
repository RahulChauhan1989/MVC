using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CheckFamilyViewModel
    {
        [Display(Name ="ID")]
        public short CheckFamilyRowID { get; set; }

        [Display(Name = "Check Family Name")]
        public string CheckFamilyName { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class AddCheckFamilyViewModel
    {
       
        [Display(Name = "ID")]
        public short CheckFamilyRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string CheckFamilyName { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateCheckFamilyViewModel
    {
      
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short CheckFamilyRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Check Family Name")]
        public string CheckFamilyName { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class CheckFamilyExportViewModel
    {
        public short RowID { get; set; }
        
        public string Name { get; set; }

    }

    public class CheckFamilyListPagedModel
    {
        public IEnumerable<CheckFamilyViewModel> CheckFamily { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class CheckFamilyDDLViewModel
    {
        public short CheckFamilyRowID { get; set; }

        [Display(Name = "CheckFamily Name")]
        public string CheckFamilyName { get; set; }
    }

    public class PkgCheckFamilyViewModel
    {
        [Display(Name = "ID")]
        public short CheckFamilyRowID { get; set; }

        [Display(Name = "Check Family Name")]
        public string CheckFamilyName { get; set; }

        public byte PkgChkRepoSequence { get; set; }

        public Boolean PkgChk { get; set; }
    }

}
