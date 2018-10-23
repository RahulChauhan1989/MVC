using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DesignationViewModel
    {
        [Display(Name = "ID")]
        public byte DesignationRowID { get; set; }

        [Display(Name = "Designation ")]
        public string DesignationName { get; set; }
        [Display(Name = "Department ")]
        public byte? DepartmentRowID { get; set; }


        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        public byte? Status { get; set; }
    }

    public class AddDesignationViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public byte DesignationRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Designation :")]
        public string DesignationName { get; set; }

        public byte DepartmentRowID { get; set; }

        [Display(Name = "Department :")]
        public string DepartmentName { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateDesignationViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public byte DesignationRowID { get; set; }

        [Required]
        [Display(Name = "Designation :")]
        [MaxLength(100)]
        public string DesignationName { get; set; }

        [Required]
        [Display(Name = "Department :")]
        public byte DepartmentRowID { get; set; }

        public string DepartmentName { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class DesignationExportViewModel
    {
        public byte RowID { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }      

    }

    public class DesignationListPagedModel
    {
        public IEnumerable<DesignationViewModel> Designations { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class DesignationDDLViewModel
    {
        public byte DesignationRowID { get; set; }

        public byte DepartmentRowID { get; set; }

        [Display(Name = "Designation ")]
        public string DesignationName { get; set; }
    }
}
