using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class ClientLoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string CRPUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string CRPPassWord { get; set; }
    }
    
    public class ClientUserLoggedViewModel
    {
        public int ClientUserRowID { get; set; }
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public string ClientBranch { get; set; }
        public string ClientSubGroupName { get; set; }
        public string LocationName { get; set; }
        public byte HRApprovalRequired { get; set; }
        public string Abbreviation { get; set; }
        public byte CodeGeneration { get; set; }
        public string UserID { get; set; }
        public string UPass { get; set; }
        public string CSpocName { get; set; }
        public string CSpocEmailID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte Status { get; set; }
    }
    
    public class UpdateClientUserBlockStatusViewModel
    {
        public int ClientUserRowID { get; set; }
        public string UserID { get; set; }
        public DateTime? BlockedDate { get; set; }
        public byte Status { get; set; }
    }

}
