using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name ="ID")]
        public byte CategoryRowID { get; set; }
        
        [Display(Name = "Name :")]
        public string CategoryName { get; set; }

        public byte? Status { get; set; }
    }

    public class AddCategoryViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public byte CategoryRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name:")]
        public string CategoryName { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateCategoryViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public byte CategoryRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name:")]
        public string CategoryName { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class CategoryExportViewModel
    {    
        public byte RowID { get; set; }
   
        public string Name { get; set; }
    }

    public class CategoryListPagedModel
    {
        public IEnumerable<CategoryViewModel> Category { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class CategoryDDLViewModel
    {
        public byte CategoryRowID { get; set; }

        [Display(Name = "Category:")]
        public string CategoryName { get; set; }
    }
}
