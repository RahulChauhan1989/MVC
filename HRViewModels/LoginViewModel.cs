using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.HRViewModels
{
    public class CompanyLoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string CRPUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string CRPPassWord { get; set; }
    }
    
    public class CompanyUserLoggedViewModel
    {
        public short WebUserRowID { get; set; }
        
        public short TeamMemberRoWID { get; set; }
        public string TeamMemberName { get; set; }
        public string TeamMemberEmail { get; set; }              
        public string CRPUserName { get; set; }                
        public string CRPPassWord { get; set; }                
        public byte IsExportedExcel { get; set; }        
        public byte IsExportedWord { get; set; }        
        public byte IsExportedPDF { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte Status { get; set; }
    }

    public class UpdateCompanyUserBlockStatusViewModel
    {
        public short WebUserRowID { get; set; }
        public string CRPUserName { get; set; }
        public DateTime? BlockedDate { get; set; }
        public byte Status { get; set; }
    }
}
