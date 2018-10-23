using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class PQCibilVer
    {
        public PQCibilVer()
        {
            CibilVerRowID = 0;
            CibilRowID = 0;

            CC_Cand_Name       = string.Empty;
            CC_PanNo           = string.Empty;
            CC_CIBIL_Rpt       = string.Empty;
            CC_CIBIL_Score     = string.Empty;
            CC_CIBIL_Score1    = string.Empty;
            CC_CIBIL_Rpt1      = string.Empty;
            CC_PANCard = 0;
            CC_OtherProof = 0;
            CC_Others          = string.Empty;
            CC_Others2         = string.Empty;
            CC_Others3         = string.Empty;
            CC_Others4         = string.Empty;
            CC_Others5         = string.Empty;
            CC_Others6         = string.Empty;
            CC_Others7         = string.Empty;

            ATA_CID_No = string.Empty;
            ATA_Cmpny_Addr = string.Empty;
            ATA_ApprxEmpWorking = string.Empty;
            ATA_Cmpny_Website = string.Empty;
            ATA_Decoy_Call = string.Empty;
            ATA_Reverse_Directory = string.Empty;
            ATA_Residcl_Commrcl = string.Empty;
            ATA_Stock_Exchnge = string.Empty;
            ATA_Telphne_Directry_Srch = string.Empty;
            ATA_Yellow_Pages = string.Empty;
            ATA_Who_Domain = string.Empty;
            ATA_GoogleSearch = string.Empty;
            ATA_InfrastructureOfCmp = string.Empty;
            ATA_Just_Dial = string.Empty;
            ATA_Neighbor_Check1 = string.Empty;
            ATA_NASCOM_Empanelment = string.Empty;
            ATA_Photograph = string.Empty;
            ATA_Physical_Site = string.Empty;
            ATA_Reg_Company = string.Empty;
            ATA_PO_Courier_Check = string.Empty;
            ATA_Network_Sol = string.Empty;

            TypeRevert = string.Empty;
            CheckStatus = string.Empty;
            CaseStatus = string.Empty;
            ColorName = string.Empty;
            Remarks = string.Empty;
            Status = 0;

            VerifiedBy = 0;
            VerifierDesignation = string.Empty;
            VerifierContactNo = string.Empty;
            VerifierMobileNo = string.Empty;
            VerifierEmailId = string.Empty;
        }

        public int CibilVerRowID { get; set; }

        public int CibilRowID { get; set; }
        public virtual PQCibil PQCibil { get; set; }

        public string CC_Cand_Name       { get; set; }
        public string CC_PanNo           { get; set; }
        public string CC_CIBIL_Rpt       { get; set; }
        public string CC_CIBIL_Score     { get; set; }
        public string CC_CIBIL_Score1    { get; set; }
        public string CC_CIBIL_Rpt1      { get; set; }
        public byte   CC_PANCard         { get; set; }
        public byte   CC_OtherProof      { get; set; }
        public string CC_Others          { get; set; }
        public string CC_Others2         { get; set; }
        public string CC_Others3         { get; set; }
        public string CC_Others4         { get; set; }
        public string CC_Others5         { get; set; }
        public string CC_Others6         { get; set; }
        public string CC_Others7         { get; set; }

        public string ATA_CID_No                    { get; set; }              //TextBox
        public string ATA_Cmpny_Addr                { get; set; }              //TextArea
        public string ATA_ApprxEmpWorking           { get; set; }              //TextBox
        public string ATA_Cmpny_Website             { get; set; }              //TextArea
        public string ATA_Decoy_Call                { get; set; }              //TextArea
        public string ATA_Reverse_Directory         { get; set; }              //TextArea
        public string ATA_Residcl_Commrcl           { get; set; }              //TextArea
        public string ATA_Stock_Exchnge             { get; set; }              //TextArea
        public string ATA_Telphne_Directry_Srch     { get; set; }              //TextArea
        public string ATA_Yellow_Pages              { get; set; }              //TextArea
        public string ATA_Who_Domain                { get; set; }              //TextArea
        public string ATA_GoogleSearch              { get; set; }              //TextArea
        public string ATA_InfrastructureOfCmp       { get; set; }              //TextArea
        public string ATA_Just_Dial                 { get; set; }              //TextArea
        public string ATA_Neighbor_Check1           { get; set; }              //TextArea
        public string ATA_NASCOM_Empanelment        { get; set; }              //TextArea
        public string ATA_Photograph                { get; set; }              //TextArea
        public string ATA_Physical_Site             { get; set; }              //TextArea
        public string ATA_Reg_Company               { get; set; }              //TextArea
        public string ATA_PO_Courier_Check          { get; set; }              //TextArea
        public string ATA_Network_Sol               { get; set; }              //TextArea
        
        public string TypeRevert { get; set; }
        public string CheckStatus { get; set; }
        public string CaseStatus { get; set; }
        public string ColorName { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }

        public short VerifiedBy { get; set; }
        public string VerifierDesignation { get; set; }
        public string VerifierContactNo { get; set; }
        public string VerifierMobileNo { get; set; }
        public string VerifierEmailId { get; set; }
        public DateTime? VerifiedDate { get; set; }
    }
}
