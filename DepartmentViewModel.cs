using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
   public class DepartmentViewModel
    {
        [Display(Name ="ID")]
        public byte DepartmentRowID { get; set; }
        
        [Display(Name = "Name ")]
        public string DepartmentName { get; set; }

        public byte? Status { get; set; }
    }
    public class AddDepartmentViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public byte DepartmentRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string DepartmentName { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }
    public class UpdateDepartmentViewModel
    {
        [Required]
        [Display(Name = "ID :")]
        [ScaffoldColumn(false)]
        public byte DepartmentRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string DepartmentName { get; set; }

        [ScaffoldColumn(false)] 
        public byte? Status { get; set; }
    }

    public class DepartmentExportViewModel
    {     
        public byte RowID { get; set; }
       
        public string Department{ get; set; }
    }

    public class DepartmentListPagedModel
    {
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    public class DepartmentDDLViewModel
    {
        public byte DepartmentRowID { get; set; }

        [Display(Name = "Department Name :")]
        public string DepartmentName { get; set; }
    }
}
