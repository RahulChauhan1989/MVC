using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BranchOfficeViewModel
    {
        [Display(Name = "ID")]
        public short BORowID { get; set; }

        public short CompanyRowID { get; set; }

        [Display(Name = "Name")]
        public string BOName { get; set; }

        [Display(Name = "Address")]
        public string BOAddress { get; set; }

        [Display(Name = "Contact Person Name")]
        public string BOConcernPersonName { get; set; }

        [Display(Name = "Contact Number")]        
        public string BOContactNumber { get; set; }

        [Display(Name = "Email")]        
        public string BOEmailId { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class AddBranchOfficeViewModel
    {
        [ScaffoldColumn(false)]
        public short BORowID { get; set; }

        public short CompanyRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name :")]
        public string BOName { get; set; }


        [MaxLength(300)]
        [Display(Name = "Address :")]
        public string BOAddress { get; set; }

        [MaxLength(100)]
        [Display(Name = "Contact Person Name :")]        
        public string BOConcernPersonName { get; set; }

        [MaxLength(15)]        
        [Display(Name = "Contact Number :")]
        [RegularExpression(@"(?:\s+|)((0|(?:(\+|)91))(?:\s|-)*(?:(?:\d(?:\s|-)*\d{9})|(?:\d{2}(?:\s|-)*\d{8})|(?:\d{3}(?:\s|-)*\d{7}))|\d{10})(?:\s+|)", ErrorMessage = "Please enter correct Contact Number")]
        public string BOContactNumber { get; set; }

        [MaxLength(50)]
        [Display(Name = "Email :")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string BOEmailId { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateBranchOfficeViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public short BORowID { get; set; }

        public short CompanyRowID { get; set; }

        [Required]
        [Display(Name = "Name :")]
        public string BOName { get; set; }

        [Display(Name = "Address :")]
        [MaxLength(300)]
        public string BOAddress { get; set; }

        [Display(Name = "Contact Person Name :")]
        [MaxLength(100)]
        public string BOConcernPersonName { get; set; }

        [Display(Name = "Contact Number :")]
        [MaxLength(15)]
       
        public string BOContactNumber { get; set; }

        [Display(Name = "Email :")]
        [MaxLength(50)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string BOEmailId { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class BranchOfficeExportViewModel
    {        
        public short RowID { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string ConcernPersonName { get; set; }
        
        public string ContactNumber { get; set; }

        public string EmailId { get; set; }

    }

    public class BranchOfficeListPagedModel
    {
        public IEnumerable<BranchOfficeViewModel> BranchOffices { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class BranchOfficeDDLViewModel
    {
        public short BORowID { get; set; }

        public string BOName { get; set; }
    }
}
