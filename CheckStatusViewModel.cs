using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ViewModels
{
    public class CheckStatusViewModel
    {
        [ScaffoldColumn(false)]
        public int CheckStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public int CheckDepartmentRowId { get; set; }

        [ScaffoldColumn(false)]
        public short DEMgrAllocatedBy { get; set; }
        [ScaffoldColumn(false)]
        public short DETLAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string DETMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short DETMAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DETMAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string DETMQCCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short DETMQCAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DETMQCAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string MgrCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short MgrAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? MgrAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string TLCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short TLAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? TLAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string TMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short TMAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? TMAllocatedDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string TMQCCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short TMQCAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? TMQCAllocatedDate { get; set; }

        //Physical Verification
        [MaxLength(20)]
        public string PVMgrCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PVMgrAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PVMgrAllocatedDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PVTLCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PVTLAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PVTLAllocatedDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PVTMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PVTMAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PVTMAllocatedDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PVTMQCCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PVTMQCAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PVTMQCAllocatedDate { get; set; }

        //Partner Verification

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PTRMgrCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PTRMgrAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PTRMgrAllocatedDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PTRTLCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PTRTLAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PTRTLAllocatedDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PTRTMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PTRTMAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PTRTMAllocatedDate { get; set; }

        //Insuff Raise

        [ScaffoldColumn(false)]
        [MaxLength(200)]
        public string InfSuffRaiseRemarks { get; set; }

        [ScaffoldColumn(false)]
        public short InfSuffRaiseBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? InfSuffRaisedDate { get; set; }

        //Insuff Clear

        [ScaffoldColumn(false)]
        [MaxLength(200)]
        public string InfSuffClearComments { get; set; }

        [ScaffoldColumn(false)]
        public short InfSuffClearBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? InfSuffClearDate { get; set; }

        //Insuff Clear By Client

        [ScaffoldColumn(false)]
        [MaxLength(200)]
        public string ClientInfSuffClearComments { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ClienInfSuffClearDate { get; set; }

        //Stopped Check

        [ScaffoldColumn(false)]
        [MaxLength(200)]
        public string StoppedCheckRemarks { get; set; }

        [ScaffoldColumn(false)]
        public short StoppedCheckBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? StoppedCheckDate { get; set; }

        //Stopped Check Clear

        [ScaffoldColumn(false)]
        [MaxLength(200)]
        public string StoppedCheckClearComments { get; set; }

        [ScaffoldColumn(false)]
        public short StoppedCheckClearBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? StoppedCheckClearDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string RWCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short ReportWritterBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ReportWritterDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string RWQCMgrCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short RWQCManagerBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? RWQCManagerDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string RWQCTLCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short RWQCTeamLeaderBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? RWQCTeamLeaderDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string RWQCTMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short RWQCTeamMemberBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? RWQCTeamMemberDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string ReportSendStatus { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ReportSendDate { get; set; }


        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string OTherCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short OTherMemberBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? OTherMemberDate { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string OTher1CheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short OTher1MemberBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? OTher1MemberDate { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(200)]
        public string Remarks { get; set; }
    }

    public class CheckStatusDETMViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }               
     
        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string DETMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short DETMAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DETMAllocatedDate { get; set; }
    }
    public class CheckStatusDETMQCViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string DETMQCCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short DETMQCAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DETMQCAllocatedDate { get; set; }
    }
    public class CheckStatusMgrViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string MgrCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short MgrAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? MgrAllocatedDate { get; set; }
    }

    public class CheckStatusTLViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string TLCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short TLAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? TLAllocatedDate { get; set; }
    }

    public class CheckStatusTMViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string TMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short TMAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? TMAllocatedDate { get; set; }
    }

    public class CheckStatusTMQCViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string TMQCCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short TMQCAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? TMQCAllocatedDate { get; set; }
    }
    public class CheckStatusPVMgrViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [MaxLength(20)]
        public string PVMgrCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PVMgrAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PVMgrAllocatedDate { get; set; }
    }
    public class CheckStatusPVTLViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PVTLCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PVTLAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PVTLAllocatedDate { get; set; }
    }
    public class CheckStatusPVTMViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PVTMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PVTMAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PVTMAllocatedDate { get; set; }
    }
    public class CheckStatusPVTMVQCViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PVTMQCCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PVTMQCAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PVTMQCAllocatedDate { get; set; }
    }
    public class CheckStatusPTRMgrViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }
        
        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PTRMgrCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PTRMgrAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PTRMgrAllocatedDate { get; set; }
    }
    public class CheckStatusPTRTLViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PTRTLCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PTRTLAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PTRTLAllocatedDate { get; set; }

    }
    public class CheckStatusPTRTMViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string PTRTMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short PTRTMAllocatedTo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? PTRTMAllocatedDate { get; set; }

    }
    public class CheckStatusInfRaiseViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string InfSuffRaiseRemarks { get; set; }

        [ScaffoldColumn(false)]
        public short InfSuffRaiseBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? InfSuffRaisedDate { get; set; }
        
    }
    public class CheckStatusClientInfSuffClearViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string ClientInfSuffClearComments { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ClienInfSuffClearDate { get; set; }

    }
    public class CheckStatusStoppedCheckViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string StoppedCheckRemarks { get; set; }

        [ScaffoldColumn(false)]
        public short StoppedCheckBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? StoppedCheckDate { get; set; }

    }
    public class CheckStatusStoppedCheckClearViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string StoppedCheckClearComments { get; set; }

        [ScaffoldColumn(false)]
        public short StoppedCheckClearBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? StoppedCheckClearDate { get; set; }

    }
    public class CheckStatusRWViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string RWCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short ReportWritterBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ReportWritterDate { get; set; }

    }
    public class CheckStatusRWQCMgrViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string RWQCMgrCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short RWQCManagerBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? RWQCManagerDate { get; set; }

    }
    public class CheckStatusRWQCTLViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string RWQCTLCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short RWQCTeamLeaderBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? RWQCTeamLeaderDate { get; set; }
    }
    public class CheckStatusRWQCTMViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string RWQCTMCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short RWQCTeamMemberBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? RWQCTeamMemberDate { get; set; }
    }

    public class CheckStatusReportSendViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string ReportSendStatus { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ReportSendDate { get; set; }
    }

    public class CheckStatusOTherCheckViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string OTherCheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short OTherMemberBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? OTherMemberDate { get; set; }
    }
    public class CheckStatusOTher1CheckViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int EmploymentStatusRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string OTher1CheckStatus { get; set; }

        [ScaffoldColumn(false)]
        public short OTher1MemberBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? OTher1MemberDate { get; set; }
    }

}
