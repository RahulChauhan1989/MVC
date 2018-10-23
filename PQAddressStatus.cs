using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQAddressStatus
    {
        public PQAddressStatus()
        {
            AddressStatusRowID = 0;
            AddressRowID = 0;
            DEMgrAllocatedBy = 0;
            DETLAllocatedTo = 0;
            DETMCheckStatus = string.Empty;
            DETMAllocatedTo = 0;
            DETMQCCheckStatus = string.Empty;
            DETMQCAllocatedTo = 0;
            MgrCheckStatus = string.Empty;
            MgrAllocatedTo = 0;
            TLCheckStatus = string.Empty;
            TLAllocatedTo = 0;
            TMCheckStatus = string.Empty;
            TMAllocatedTo = 0;
            TMQCCheckStatus = string.Empty;
            TMQCAllocatedTo = 0;
            PTRMgrCheckStatus = string.Empty;
            PTRMgrAllocatedTo = 0;
            PTRTLCheckStatus = string.Empty;
            PTRTLAllocatedTo = 0;
            PTRTMCheckStatus = string.Empty;
            PTRTMAllocatedTo = 0;
            InfSuffRaiseRemarks = string.Empty;
            InfSuffRaiseBy = 0;
            InfSuffClearComments = string.Empty;
            InfSuffClearBy = 0;
            ClientInfSuffClearComments = string.Empty;
            StoppedCheckRemarks = string.Empty;
            StoppedCheckBy = 0;
            StoppedCheckClearComments = string.Empty;
            StoppedCheckClearBy = 0;
            RWCheckStatus = string.Empty;
            ReportWritterBy = 0;
            RWQCMgrCheckStatus = string.Empty;
            RWQCManagerBy = 0;
            RWQCTLCheckStatus = string.Empty;
            RWQCTeamLeaderBy = 0;
            RWQCTMCheckStatus = string.Empty;
            RWQCTeamMemberBy = 0;
            ReportSendStatus = string.Empty;
            OTherCheckStatus = string.Empty;
            OTherMemberBy = 0;
            OTher1CheckStatus = string.Empty;
            OTher1MemberBy = 0;
            Remarks = string.Empty;
        }

        public int AddressStatusRowID { get; set; }

        public int AddressRowID { get; set; }
        public virtual PQAddress PQAddress { get; set; }
        
        public short DEMgrAllocatedBy { get; set; }
        public short DETLAllocatedTo { get; set; }

        public string DETMCheckStatus { get; set; }
        public short DETMAllocatedTo { get; set; }
        public DateTime? DETMAllocatedDate { get; set; }

        public string DETMQCCheckStatus { get; set; }
        public short DETMQCAllocatedTo { get; set; }
        public DateTime? DETMQCAllocatedDate { get; set; }

        public string MgrCheckStatus { get; set; }
        public short MgrAllocatedTo { get; set; }
        public DateTime? MgrAllocatedDate { get; set; }

        public string TLCheckStatus { get; set; }
        public short TLAllocatedTo { get; set; }
        public DateTime? TLAllocatedDate { get; set; }

        public string TMCheckStatus { get; set; }
        public short TMAllocatedTo { get; set; }
        public DateTime? TMAllocatedDate { get; set; }

        public string TMQCCheckStatus { get; set; }
        public short TMQCAllocatedTo { get; set; }
        public DateTime? TMQCAllocatedDate { get; set; }

        //Partner Verification
        public string PTRMgrCheckStatus { get; set; }
        public short PTRMgrAllocatedTo { get; set; }
        public DateTime? PTRMgrAllocatedDate { get; set; }

        public string PTRTLCheckStatus { get; set; }
        public short PTRTLAllocatedTo { get; set; }
        public DateTime? PTRTLAllocatedDate { get; set; }

        public string PTRTMCheckStatus { get; set; }
        public short PTRTMAllocatedTo { get; set; }
        public DateTime? PTRTMAllocatedDate { get; set; }

        //Insuff Raise
        public string InfSuffRaiseRemarks { get; set; }
        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }

        //Insuff Clear
        public string InfSuffClearComments { get; set; }
        public short InfSuffClearBy { get; set; }
        public DateTime? InfSuffClearDate { get; set; }

        //Insuff Clear By Client
        public string ClientInfSuffClearComments { get; set; }
        public DateTime? ClienInfSuffClearDate { get; set; }

        //Stopped Check
        public string StoppedCheckRemarks { get; set; }
        public short StoppedCheckBy { get; set; }
        public DateTime? StoppedCheckDate { get; set; }

        //Stopped Check Clear
        public string StoppedCheckClearComments { get; set; }
        public short StoppedCheckClearBy { get; set; }
        public DateTime? StoppedCheckClearDate { get; set; }
        
        public string RWCheckStatus { get; set; }
        public short ReportWritterBy { get; set; }
        public DateTime? ReportWritterDate { get; set; }

        public string RWQCMgrCheckStatus { get; set; }
        public short RWQCManagerBy { get; set; }
        public DateTime? RWQCManagerDate { get; set; }

        public string RWQCTLCheckStatus { get; set; }
        public short RWQCTeamLeaderBy { get; set; }
        public DateTime? RWQCTeamLeaderDate { get; set; }

        public string RWQCTMCheckStatus { get; set; }
        public short RWQCTeamMemberBy { get; set; }
        public DateTime? RWQCTeamMemberDate { get; set; }

        public string ReportSendStatus { get; set; }
        public DateTime? ReportSendDate { get; set; }

        public string OTherCheckStatus { get; set; }
        public short OTherMemberBy { get; set; }
        public DateTime? OTherMemberDate { get; set; }

        public string OTher1CheckStatus { get; set; }
        public short OTher1MemberBy { get; set; }
        public DateTime? OTher1MemberDate { get; set; }

        public string Remarks { get; set; }
    }
}
