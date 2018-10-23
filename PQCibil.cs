using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQCibil
    {
        public PQCibil()
        {
            CibilRowID = 0;
            ClientRowID = 0;
            PersonalRowID = 0;
            ClientPackageRowID = 0;
            CheckFamilyRowID = 0;
            SubCheckRowID = 0;
            UniqueComponentID = string.Empty;

            CC_Cand_Name = string.Empty;
            CC_Sec_Ref_Id = string.Empty;
            CC_PanNo = string.Empty;
            CC_CIBIL_Rpt = string.Empty;
            CC_CIBIL_Score = string.Empty;
            CC_PANCard = 0;
            CC_OtherProof = 0;
            CC_Others = string.Empty;
            CC_Others2 = string.Empty;
            ATA_CID_No = string.Empty;
            ATA_Cmpny_Addr = string.Empty;
            
            CreatedBy = 0;
            ModifiedBy = 0;
            Status = 0;
            MgrAllocatedBy = 0;
            MgrAllocatedTo = 0;
            TLAllocatedBy = 0;
            TLAllocatedTo = 0;
            TMAllocatedBy = 0;
            TMAllocatedTo = 0;
            TMQCAllocatedBy = 0;
            TMQCAllocatedTo = 0;
            PVMgrAllocatedBy = 0;
            PVMgrAllocatedTo = 0;
            PVTLAllocatedBy = 0;
            PVTLAllocatedTo = 0;
            PVTMAllocatedBy = 0;
            PVTMAllocatedTo = 0;
            PVTMQCAllocatedBy = 0;
            PVTMQCAllocatedTo = 0;
            PVFVAllocatedBy = 0;
            PVFVQAllocatedTo = 0;
            Verify = 0;
            VerifiedBy = 0;
            InfSuffRaiseBy = 0;
            InfSuffClearBy = 0;
            StoppedCheckStatus = 0;
            StoppedCheckBy = 0;
            StoppedCheckClearBy = 0;
            ReportWritterBy = 0;
            RWQCManageBy = 0;
            RWQCTeamLeaderBy = 0;
            RWQCTeamMemberBy = 0;

            CheckStatus = string.Empty;
            CaseStatus = string.Empty;
            Remarks = string.Empty;
            Mailto = string.Empty;
            MailtoClient = string.Empty;
            MailedBy = string.Empty;
            ClientComment = string.Empty;
            INFRemarks = string.Empty;
        }

        public int CibilRowID { get; set; }

        #region Common for all Checks 

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public int PersonalRowID { get; set; }
        public virtual PQPersonal PQPersonal { get; set; }

        public int ClientPackageRowID { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public short SubCheckRowID { get; set; }
        public virtual MasterSubCheckFamily MasterSubCheckFamily { get; set; }

        public string UniqueComponentID { get; set; }

        #endregion

        public string CC_Cand_Name { get; set; }
        public string CC_Sec_Ref_Id { get; set; }
        public string CC_PanNo { get; set; }
        public string CC_CIBIL_Rpt { get; set; }
        public string CC_CIBIL_Score { get; set; }
        public byte CC_PANCard { get; set; }
        public byte CC_OtherProof { get; set; }
        public string CC_Others { get; set; }
        public string CC_Others2 { get; set; }
        public string ATA_CID_No { get; set; }
        public string ATA_Cmpny_Addr { get; set; }

        //following properties not show on page
        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }
        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string CheckStatus { get; set; }
        public string CaseStatus { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }

        public short MgrAllocatedBy { get; set; }
        public short MgrAllocatedTo { get; set; }
        public DateTime? MgrAllocatedDate { get; set; }
        public short TLAllocatedBy { get; set; }
        public short TLAllocatedTo { get; set; }
        public DateTime? TLAllocatedDate { get; set; }
        public short TMAllocatedBy { get; set; }
        public short TMAllocatedTo { get; set; }
        public DateTime? TMAllocatedDate { get; set; }
        public short TMQCAllocatedBy { get; set; }
        public short TMQCAllocatedTo { get; set; }
        public DateTime? TMQCAllocatedDate { get; set; }

        public short PVMgrAllocatedBy { get; set; }
        public short PVMgrAllocatedTo { get; set; }
        public DateTime? PVMgrAllocatedDate { get; set; }
        public short PVTLAllocatedBy { get; set; }
        public short PVTLAllocatedTo { get; set; }
        public DateTime? PVTLAllocatedDate { get; set; }
        public short PVTMAllocatedBy { get; set; }
        public short PVTMAllocatedTo { get; set; }
        public DateTime? PVTMAllocatedDate { get; set; }
        public short PVTMQCAllocatedBy { get; set; }
        public short PVTMQCAllocatedTo { get; set; }
        public DateTime? PVTMQCAllocatedDate { get; set; }
        public short PVFVAllocatedBy { get; set; }
        public short PVFVQAllocatedTo { get; set; }
        public DateTime? PVFVAllocatedDate { get; set; }

        public byte Verify { get; set; }            //1 or 0
        public short VerifiedBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public short InfSuffClearBy { get; set; }
        public DateTime? InfSuffClearDate { get; set; }

        public string Mailto { get; set; }
        public string MailtoClient { get; set; }
        public string MailedBy { get; set; }
        public string ClientComment { get; set; }
        public DateTime? ClienINFClearDate { get; set; }
        public string INFRemarks { get; set; }

        public byte StoppedCheckStatus { get; set; }
        public short StoppedCheckBy { get; set; }
        public DateTime? StoppedCheckDate { get; set; }
        public short StoppedCheckClearBy { get; set; }
        public DateTime? StoppedCheckClearDate { get; set; }

        public short ReportWritterBy { get; set; }
        public DateTime? ReportWritterDate { get; set; }

        public short RWQCManageBy { get; set; }
        public DateTime? RWQCManageDate { get; set; }
        public short RWQCTeamLeaderBy { get; set; }
        public DateTime? RWQCTeamLeaderDate { get; set; }
        public short RWQCTeamMemberBy { get; set; }
        public DateTime? RWQCTeamMemberDate { get; set; }
    }
}
