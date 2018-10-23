using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.HRViewModels
{
    public class UserLoginLogOutDetailViewModel
    {
        [Display(Name = "ID")]
        public short LogDetailRowID { get; set; }

        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Display(Name = "Login Type")]
        public string LoginType { get; set; }

        [Display(Name = "Loginid")]
        public string Loginid { get; set; }

        [Display(Name = "IPDetails")]
        public string IPDetails { get; set; }

        [Display(Name = "LoginDate")]
        public DateTime? LoginDate { get; set; }

        [Display(Name = "LoginTime")]
        public DateTime? LoginTime { get; set; }

        [Display(Name = "LogoutTime")]
        public DateTime? LogoutTime { get; set; }

        [Display(Name = "IPstatus")]
        public byte IPstatus { get; set; }

        [Display(Name = "LoginBy")]
        public string LoginBy { get; set; }
    }

    public class LoginLogOutDetailListPagedModel
    {
        public IEnumerable<UserLoginLogOutDetailViewModel> LoginLogOutDetails { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class AddUserLoggedInDetailViewModel
    {
        public AddUserLoggedInDetailViewModel()
        {
            LoginDetailRowID = 0;
            LoginName = string.Empty;
            LoginType = string.Empty;
            LoginId = string.Empty;
            LoginBy = string.Empty;
            IPDetails = string.Empty;
            LoginStatus = 1;
        }

        public int LoginDetailRowID { get; set; }
        public string LoginName { get; set; }
        public string LoginType { get; set; }
        public string LoginId { get; set; }
        public string LoginBy { get; set; }
        public string IPDetails { get; set; }
        public DateTime? LoginDate { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public byte LoginStatus { get; set; }
    }

    public class UpdateUserLogOutDetailViewModel
    {
        public UpdateUserLogOutDetailViewModel()
        {
            LoginDetailRowID = 0;
        }

        public int LoginDetailRowID { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
