using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.HRViewModels
{
    public class WebUserViewModel
    {
        [Display(Name = "ID")]
        public short WebUserRowID { get; set; }

        [Display(Name = "TeamMember")]
        public short TeamMemberRoWID { get; set; }
        public string TeamMemberName { get; set; }

        [Display(Name = "UserName")]
        public string CRPUserName { get; set; }

        [Display(Name = "PassWord")]
        public string CRPPassWord { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Blocked Date")]
        public DateTime? BlockedDate { get; set; }

        [Display(Name = "Password List")]
        public string PasswordList { get; set; }

        [Display(Name = "UnBlocked By")]
        public short UnBlockedBy { get; set; }

        [Display(Name = "UnBlocked Date")]
        public DateTime? UnBlockedDate { get; set; }
                
        [Display(Name = "Status")]
        public byte Status { get; set; }

        public byte IsExportedExcel { get; set; }
        public byte IsExportedWord { get; set; }
        public byte IsExportedPDF { get; set; }
    }

    public class WebUserExportViewModel
    {
        public short WebUserRowID { get; set; }
        
        public string TeamMemberName { get; set; }
        
        public string CRPUserName { get; set; }
        
        public string CRPPassWord { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public DateTime? ModifiedDate { get; set; }
        
        public DateTime? BlockedDate { get; set; }
                
        public short UnBlockedBy { get; set; }
        
        public DateTime? UnBlockedDate { get; set; }

        public string IsExportedExcel { get; set; }
        public string IsExportedWord { get; set; }
        public string IsExportedPDF { get; set; }

    }

    public class AddWebUserViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short WebUserRowID { get; set; }

        [Required(ErrorMessage ="Please Select Team Meamber!")]
        [Display(Name = "Select Team Member : ")]
        public short TeamMemberRoWID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "User Name : ")]
        public string CRPUserName { get; set; }

        [Required]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&_]).*$", ErrorMessage = "Please enter password between 6 to 50 character and password must contain at least one one Lower case letter, one Upper case letter, one Digit and one Special (!@#$%^&_) Characters.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long. and must start with an alphabet.", MinimumLength = 6)]
        [Display(Name = "Password : ")]
        [DataType(DataType.Password)]
        public string CRPPassWord { get; set; }
        
        [Display(Name = "Export Excel")]
        public byte IsExportedExcel { get; set; }
        [NotMapped]
        public bool IsExportedExcelBool
        {
            get { return IsExportedExcel > 0; }
            set { IsExportedExcel = value ? (byte)1 : (byte)0; }
        }

        [Display(Name = "Export Word")]
        public byte IsExportedWord { get; set; }
        [NotMapped]
        public bool IsExportedWordBool
        {
            get { return IsExportedWord > 0; }
            set { IsExportedWord = value ? (byte)1 : (byte)0; }
        }

        [Display(Name = "Export PDF")]
        public byte IsExportedPDF { get; set; }
        [NotMapped]
        public bool IsExportedPDFBool
        {
            get { return IsExportedPDF > 0; }
            set { IsExportedPDF = value ? (byte)1 : (byte)0; }
        }

        [ScaffoldColumn(false)]
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class UpdateWebUserViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short WebUserRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "User Name : ")]
        public string CRPUserName { get; set; }

        [Required]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&_]).*$", ErrorMessage = "Please enter password between 6 to 50 character and password must contain at least one one Lower case letter, one Upper case letter, one Digit and one Special (!@#$%^&_) Characters.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long. and must start with an alphabet.", MinimumLength = 6)]
        [Display(Name = "Password : ")]
        [DataType(DataType.Password)]
        public string CRPPassWord { get; set; }

        [Display(Name = "Export Excel")]
        public byte IsExportedExcel { get; set; }
        [NotMapped]
        public bool IsExportedExcelBool
        {
            get { return IsExportedExcel > 0; }
            set { IsExportedExcel = value ? (byte)1 : (byte)0; }
        }

        [Display(Name = "Export Word")]
        public byte IsExportedWord { get; set; }
        [NotMapped]
        public bool IsExportedWordBool
        {
            get { return IsExportedWord > 0; }
            set { IsExportedWord = value ? (byte)1 : (byte)0; }
        }

        [Display(Name = "Export PDF")]
        public byte IsExportedPDF { get; set; }
        [NotMapped]
        public bool IsExportedPDFBool
        {
            get { return IsExportedPDF > 0; }
            set { IsExportedPDF = value ? (byte)1 : (byte)0; }
        }

        [ScaffoldColumn(false)]
        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte Status { get; set; }
    }
    public class WebUserListPagedModel
    {
        public IEnumerable<WebUserViewModel> WebUsers { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class UnBlockedCompanyUserModel
    {
        [Display(Name = "ID")]
        public short WebUserRowID { get; set; }

        [Display(Name = "Team Member")]
        public short TeamMemberRoWID { get; set; }

        [Display(Name = "Team Member Name")]
        public string TeamMemberName { get; set; }

        [Display(Name = "User Name")]
        public string CRPUserName { get; set; }

        [Display(Name = "Blocked Date")]
        public DateTime? BlockedDate { get; set; }

        [Display(Name = "Email")]
        public string EmailID { get; set; }

        public string Activate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class UnBlockedCUListPagedModel
    {
        public IEnumerable<UnBlockedCompanyUserModel> UnBlockedCUsers { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class UnBlockedClientUserModel
    {       

        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class UnBlockedClintUListPagedModel
    {
        public IEnumerable<UnBlockedClientUserModel> UnBlockedClientUsers { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class UnBlockedUsersViewModel
    {
        public short WebUserRowID { get; set; }
      
        public short UnBlockedBy { get; set; } 

        public DateTime? UnBlockedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

}
