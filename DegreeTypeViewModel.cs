using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DegreeTypeViewModel
    {
        [Display(Name = "ID")]
        public short DegreeRowID { get; set; }

        [Display(Name = "Degree Type")]
        public string DegreeType { get; set; }

        public byte? Status { get; set; }
    }
    public class AddDegreeTypeViewModel
    {
        [Display(Name = "ID")]
        public short DegreeRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Degree Type")]
        public string DegreeType { get; set; }

        public byte? Status { get; set; }
    }
    public class UpdateDegreeTypeViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short DegreeRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Degree Type")]
        public string DegreeType { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class DegreeViewModel
    {
        public short RowID { get; set; }

        public string Degree { get; set; }

    }

    public class DegreeTypeListPagedModel
    {
        public IEnumerable<DegreeTypeViewModel> DegreeTypes { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
