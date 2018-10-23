using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
   public class PQClientLoginViewModel
    {
        public int ClientUserRowID { get; set; }
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public string ClientBranch { get; set; }
        public string UserID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte Status { get; set; }
        public byte SentMailStatus { get; set; }
        public DateTime? SentMailDate { get; set; }
    }

    public class ClientLoginDetailsForMailViewModel
    {
        public int ClientUserRowID { get; set; }
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public string UserID { get; set; }
        public string UPass { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? BlockedDate { get; set; }
        public short UnBlockedBy { get; set; }
        public DateTime? UnBlockedDate { get; set; }
        public string UType { get; set; }
        public string UserType { get; set; }
        public byte Status { get; set; }
        public byte SentMailStatus { get; set; }
        public string SentMailStatusYesNo { get; set; }
        public DateTime? SentMailDate { get; set; }
        public string Remarks { get; set; }
        public short CreatedUserId { get; set; }
    }

    public class AddPQClientLoginViewModel
    {
        [Display(Name ="ID")]
        [ScaffoldColumn(false)]
        public int ClientUserRowID { get; set; }

        [Required]
        [Display(Name = "Client Name :")]
        public short ClientRowID { get; set; }     
        public string ClientName { get; set; }

        [Display(Name ="Branch Office")]
        public string ClientBranch { get; set; }

        [Required]
        [Display(Name = "User ID :")]
        public string UserID { get; set; }

        [Required]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&_]).*$", ErrorMessage = "Please enter password between 6 to 50 character and password must contain at least one one Lower case letter, one Upper case letter, one Digit and one Special (!@#$%^&_) Characters.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long. and must start with an alphabet.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string UPass { get; set; }

        [Display(Name = "Created By :")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Time :")]
        public DateTime? CreatedTime { get; set; }

        [Display(Name = "Modified Time :")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "Blocked Date :")]
        public DateTime? BlockedDate { get; set; }

        [Display(Name = "UnBlocked By :")]
        public short UnBlockedBy { get; set; }

        [Display(Name = "UnBlocked Date :")]
        public DateTime? UnBlockedDate { get; set; }

        [Display(Name = "User Type :")]
        public string UType { get; set; }

        [Display(Name = "User Type :")]
        public string UserType { get; set; }

        [Display(Name = "Status :")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [Display(Name = "Sent Mail Status :")]
        public byte SentMailStatus { get; set; }

        [Display(Name = "Sent Mail Date :")]
        public DateTime? SentMailDate { get; set; }

        [Display(Name = "Remarks :")]
        public string Remarks { get; set; }

        [Display(Name = "Created User Id :")]
        public short CreatedUserId { get; set; }


    }

    public class UpdatePQClientLoginViewModel
    {
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int ClientUserRowID { get; set; }

        [Required]
        [Display(Name = "Client Name :")]
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "User ID :")]
        public string UserID { get; set; }

        [Required]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&_]).*$", ErrorMessage = "Please enter password between 6 to 50 character and password must contain at least one one Lower case letter, one Upper case letter, one Digit and one Special (!@#$%^&_) Characters.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long. and must start with an alphabet.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string UPass { get; set; }

        [Display(Name = "Created By :")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Time :")]
        public DateTime? CreatedTime { get; set; }

        [Display(Name = "Modified Time :")]
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "Blocked Date :")]
        public DateTime? BlockedDate { get; set; }

        [Display(Name = "UnBlocked By :")]
        public short UnBlockedBy { get; set; }

        [Display(Name = "UnBlocked Date :")]
        public DateTime? UnBlockedDate { get; set; }

        [Display(Name = "User Type :")]
        public string UType { get; set; }

        [Display(Name = "User Type :")]
        public string UserType { get; set; }

        [Display(Name = "Status :")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [Display(Name = "Sent Mail Status :")]
        public byte SentMailStatus { get; set; }

        [Display(Name = "Sent Mail Date :")]
        public DateTime? SentMailDate { get; set; }

        [Display(Name = "Remarks :")]
        public string Remarks { get; set; }

        [Display(Name = "Created User Id :")]
        public short CreatedUserId { get; set; }
    }

    public class UpdateClientSendMailStatusViewModel
    {
        public int ClientUserRowID { get; set; }
        public byte SentMailStatus { get; set; }
        public DateTime? SentMailDate { get; set; }
    }

    public class SendClientLoginInfoViewModel
    {
        public string ClientSpocName { get; set; }
        public string ClientSpocEmail { get; set; }
        public string UserID { get; set; }
        public string UPass { get; set; }
    }

    public class ClientDDLViewModel
    {
        [Display(Name = "Client Name")]
        public int ClientRowID { get; set; }
        public string ClientName { get; set; }
    }

    public class ClientDesignationsDDLViewModel
    {
        [Display(Name = "Designation Name")]
        public short DesignationRowID { get; set; }

        public string DesignationName { get; set; }
    }

    public class PQClientUserListPagedModel
    {
        public IEnumerable<PQClientLoginViewModel> ClientUsers { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class UnBlockedClientUsersViewModel
    {
        public short ClientUserRowID { get; set; }

        public short UnBlockedBy { get; set; }

        public DateTime? UnBlockedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class UnBlockedPartnerUsersViewModel
    {
        public short PartnerUsersRowID { get; set; }

        public short UnBlockedBy { get; set; }

        public DateTime? UnBlockedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class ExportClientLoginViewModel
    {
        public int ClientUserRowID { get; set; }       
        public string ClientName { get; set; }       
        public string UserID { get; set; }
        public string CreatedBy { get; set; }       
        public string SentMailStatus { get; set; }
        public DateTime? SentMailDate { get; set; }
    }

}
