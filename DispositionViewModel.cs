using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DispositionViewModel
    {
        [Display(Name = "ID")]
        public short DispositionRowId { get; set; }

        [Display(Name = "Disposition")]
        public string Disposition { get; set; }

        [Display(Name = "Check Family")]
        public short CheckFamilyRowID { get; set; }

        public string CheckFamilyName { get; set; }

        [Display(Name = "Severity Grid")]
        public byte SeverityGridRowId { get; set; }

        public byte IsSetDefalut { get; set; }

        [Display(Name = "Severity Grid")]
        public string SeverityGridName { get; set; }
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class DispositionDDLViewModel
    {
        public short DispositionRowId { get; set; }
      
        public string Disposition { get; set; }
    }

    public class AddDispositionViewModel
    {
        //[ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short DispositionRowId { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Disposition :")]
        [RegularExpression(@"(?:\s*[a-zA-Z0-9\,\ /\.]{2,}\s*)*", ErrorMessage = "Special Charactor not allowed!")]
        public string Disposition { get; set; }

        [Required]
        [Display(Name = "Check Family :")]
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }

        [Required]
        [Display(Name = "Severity Grid :")]
        public byte SeverityGridRowId { get; set; }
        public string SeverityGridName { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class UpdateDispositionViewModel
    {

        [Display(Name = "ID")]
        public short DispositionRowId { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(Name = "Disposition :")]
        [RegularExpression(@"(?:\s*[a-zA-Z0-9\,\ /\.]{2,}\s*)*", ErrorMessage = "Special Charactor not allowed!")]
        public string Disposition { get; set; }

        [Required]
        [Display(Name = "Check Family :")]
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }

        [Required]
        [Display(Name = "Severity Grid :")]
        public byte SeverityGridRowId { get; set; }
        public string SeverityGridName { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }


    public class DispositionListPagedModel
    {
        public IEnumerable<DispositionViewModel> Dispositions { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class DispositionExportViewModel
    {       
        public short RowID { get; set; }
       
        public string Disposition { get; set; }      
       
        public string CheckFamilyName { get; set; }      
      
        public string SeverityGridName { get; set; }
        
    }

    //public class AutoCmplteDispositionViewModel
    //{
    //     [Display(Name = "Disposition")]
    //    public string Disposition { get; set; }
    //}
}
