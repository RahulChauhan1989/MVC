using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class SeverityGridViewModel
    {
        [Display(Name ="ID")]
        public byte SeverityGridRowId { get; set; }

        [Display(Name = "Severity Grid")]
        public string SeverityGrid { get; set; }

        [Display(Name = "Color Name ")]
        public string ColorName { get; set; }

        [Display(Name = "Color Code")]
        public string ColorCode { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class AddSeverityGridViewModel
    {
        [Display(Name = "ID")]
        public byte SeverityGridRowId { get; set; }

        [Required]
        [Display(Name = "Severity Grid")]
        public string SeverityGrid { get; set; }

        [Display(Name = "Color Name ")]
        public string ColorName { get; set; }

        [Required]
        [Display(Name = "Color Code")]
        public string ColorCode { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class UpdateSeverityGridViewModel
    {
        [Display(Name = "ID")]
        public byte SeverityGridRowId { get; set; }

        [Required]
        [Display(Name = "Severity Grid")]
        public string SeverityGrid { get; set; }

        [Display(Name = "Color Name ")]
        public string ColorName { get; set; }

        [Required]
        [Display(Name = "Color Code")]
        public string ColorCode { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class SeverityGridExportViewModel
    {      
        public byte RowID { get; set; }
       
        public string SeverityGrid { get; set; }
       
        public string ColorName { get; set; }
     
        public string ColorCode { get; set; }
    }

    public class SeverityGridDDLViewModel
    {
        [Display(Name = "Severity Grid :")]
        public byte SeverityGridRowId { get; set; }

        public string SeverityGridName { get; set; }
    }

    public class SeverityGridListPagedModel
    {
        public IEnumerable<SeverityGridViewModel> SeverityGrids { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
