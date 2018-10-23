using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels.ProvidedInfoViewModel
{
    public class PQReferenceViewModel
    {
        public int ReferenceRowID { get; set; }

        #region Common for all Checks 

        [ScaffoldColumn(false)]
        public short ClientRowID { get; set; }

        [ScaffoldColumn(false)]
        public int PersonalRowID { get; set; }

        [ScaffoldColumn(false)]
        public int ClientPackageRowID { get; set; }

        [ScaffoldColumn(false)]
        public short CheckFamilyRowID { get; set; }

        [ScaffoldColumn(false)]
        public short SubCheckRowID { get; set; }

        [ScaffoldColumn(false)]
        [MaxLength(20)]
        public string UniqueComponentID { get; set; }

        //public IEnumerable<CheckActionHistoryViewModel> CheckActionHistories { get; set; }
        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

        #endregion

        [MaxLength(100)]
        [Display(Name= "Candidate Name")]
        public string RV_CandidateName { get; set; }      //text field

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID")]
        public string RV_Sec_Ref_Id { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Name of Organisation")]
        public string RV_OrganisationName { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee Name")]
        public string RV_RefereeName { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee Designation")]
        public string RV_Refere_Desig { get; set; }      //text field

        [MaxLength(200)]
        [Display(Name = "Referee Address")]
        public string RV_Refere_Add { get; set; }      //text field

        [MaxLength(20)]
        [Display(Name = "Referee's mobile number")]
        public string RV_Refre_MobNo { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee's Email id")]
        public string RV_Refre_Eid { get; set; }      //text field

        [MaxLength(200)]
        [Display(Name = "How long have you known her/him?")]
        public string RV_Know_Long { get; set; }      // text Area

        [MaxLength(100)]
        [Display(Name = "Tenure of the Employee")]
        public string RV_Tenure_Emp { get; set; }      // to & from calender

        [MaxLength(100)]
        [Display(Name = "Designation")]
        public string RV_Dsg_RC { get; set; }      // text field

        [MaxLength(50)]
        [Display(Name = "Cost to Company")]
        public string RV_CTC { get; set; }      // text field

        [MaxLength(200)]
        [Display(Name = "Reason for leaving")]
        public string RV_Reason_Leav { get; set; }      // text Area

        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase OtherProofDoc { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Details1")]
        public string RV_OtherDetails { get; set; }     // text

        [MaxLength(200)]
        [Display(Name = "Other Details2")]
        public string RV_OtherDetails2 { get; set; }    //Text

        [MaxLength(200)]
        [Display(Name = "Other Details3")]
        public string RV_OtherDetails3 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details4")]
        public string RV_OtherDetails4 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details5")]
        public string RV_OtherDetails5 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details6")]
        public string RV_OtherDetails6 { get; set; }    // text

        [MaxLength(200)]
        [Display(Name = "Other Details7")]
        public string RV_OtherDetails7 { get; set; }    //Text

        [MaxLength(200)]
        [Display(Name = "Other Details8")]
        public string RV_OtherDetails8 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details9")]
        public string RV_OtherDetails9 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details10")]
        public string RV_OtherDetails10 { get; set; }   //text

        [MaxLength(50)]
        [Display(Name = "CID No")]
        public string ATA_CID_No { get; set; }          //text filed

        [MaxLength(200)]
        [Display(Name = "Company Address")]
        public string ATA_Cmpny_Addr { get; set; }    //text filed

        //following properties not show on page
        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }

        public short MgrAllocatedBy { get; set; }
        public short MgrAllocatedTo { get; set; }
        public DateTime? MgrAllocatedDate { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

        [MaxLength(20)]
        [Display(Name = "Case Status : ")]
        public string ReWorkCheckStatus { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }

        [MaxLength(200)]
        [Display(Name = "Reason : ")]
        public string INFRemarks { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        public byte Status { get; set; }
    }
        
    public class PQUpdateReferenceViewModel
    {
        public int ReferenceRowID { get; set; }

        #region Common for all Checks 
        [ScaffoldColumn(false)]
        public short ClientRowID { get; set; }

        [ScaffoldColumn(false)]
        public int PersonalRowID { get; set; }

        [ScaffoldColumn(false)]
        public int ClientPackageRowID { get; set; }

        [ScaffoldColumn(false)]
        public short CheckFamilyRowID { get; set; }

        [ScaffoldColumn(false)]
        public short SubCheckRowID { get; set; }

        public string UniqueComponentID { get; set; }

        //public IEnumerable<CheckActionHistoryViewModel> CheckActionHistories { get; set; }
        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

        #endregion

        [MaxLength(100)]
        [Display(Name = "Candidate Name")]
        public string RV_CandidateName { get; set; }      //text field

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID")]
        public string RV_Sec_Ref_Id { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Name of Organisation")]
        public string RV_OrganisationName { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee Name")]
        public string RV_RefereeName { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee Designation")]
        public string RV_Refere_Desig { get; set; }      //text field

        [MaxLength(200)]
        [Display(Name = "Referee Address")]
        public string RV_Refere_Add { get; set; }      //text field

        [MaxLength(20)]
        [Display(Name = "Referee's mobile number")]
        public string RV_Refre_MobNo { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee's Email id")]
        public string RV_Refre_Eid { get; set; }      //text field

        [MaxLength(200)]
        [Display(Name = "How long have you known her/him?")]
        public string RV_Know_Long { get; set; }      // text Area

        [MaxLength(100)]
        [Display(Name = "Tenure of the Employee")]
        public string RV_Tenure_Emp { get; set; }      // to & from calender
        
        [MaxLength(100)]
        [Display(Name = "Designation")]
        public string RV_Dsg_RC { get; set; }      // text field

        [MaxLength(50)]
        [Display(Name = "Cost to Company")]
        public string RV_CTC { get; set; }      // text field

        [MaxLength(200)]
        [Display(Name = "Reason for leaving")]
        public string RV_Reason_Leav { get; set; }      // text Area

        [MaxLength(200)]
        [Display(Name = "Other Details1")]
        public string RV_OtherDetails { get; set; }     // text

        [MaxLength(200)]
        [Display(Name = "Other Details2")]
        public string RV_OtherDetails2 { get; set; }    //Text

        [MaxLength(200)]
        [Display(Name = "Other Details3")]
        public string RV_OtherDetails3 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details4")]
        public string RV_OtherDetails4 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details5")]
        public string RV_OtherDetails5 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details6")]
        public string RV_OtherDetails6 { get; set; }    // text

        [MaxLength(200)]
        [Display(Name = "Other Details7")]
        public string RV_OtherDetails7 { get; set; }    //Text

        [MaxLength(200)]
        [Display(Name = "Other Details8")]
        public string RV_OtherDetails8 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details9")]
        public string RV_OtherDetails9 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details10")]
        public string RV_OtherDetails10 { get; set; }   //text

        [MaxLength(50)]
        [Display(Name = "CID No")]
        public string ATA_CID_No { get; set; }          //text filed

        [MaxLength(200)]
        [Display(Name = "Company Address")]
        public string ATA_Cmpny_Addr { get; set; }    //text filed

        //following properties not show on page
        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }
        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short MgrAllocatedBy { get; set; }
        public short MgrAllocatedTo { get; set; }
        public DateTime? MgrAllocatedDate { get; set; }

        [MaxLength(20)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

        [MaxLength(20)]
        [Display(Name = "Case Status : ")]
        public string ReWorkCheckStatus { get; set; }

        [Display(Name = "If Reject : ")]
        public string RejectionReason { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        public byte Status { get; set; }
    }

    public class UpdateRefrnceRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int ReferenceRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public string INFRemarks { get; set; }


        [MaxLength(20)]
        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }
    
    public class PQUpdateReferenceManagerViewModel
    {
        [ScaffoldColumn(false)]
        public int ReferenceRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short TLAllocatedBy { get; set; }
        public short TLAllocatedTo { get; set; }
        public DateTime? TLAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
    }

    public class PQUpdateReferenceTeamLeaderViewModel
    {
        [ScaffoldColumn(false)]
        public int ReferenceRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short TMAllocatedBy { get; set; }
        public short TMAllocatedTo { get; set; }
        public DateTime? TMAllocatedDate { get; set; }

        public short TMQCAllocatedBy { get; set; }
        public short TMQCAllocatedTo { get; set; }
        public DateTime? TMQCAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
    }

    public class PQUpdateReferenceTeamMemberViewModel
    {
        [ScaffoldColumn(false)]
        public int ReferenceRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short TMAllocatedTo { get; set; }
        public DateTime? TMAllocatedDate { get; set; }

        public string PVMgrCheckStatus { get; set; }
        public short PVMgrAllocatedTo { get; set; }
        public DateTime? PVMgrAllocatedDate { get; set; }

        public string ActionRemark { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
    }

    public class PQReferenceInsuffViewModel
    {
        public int ReferenceRowID { get; set; }

        #region Common for all Checks 

        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public int PersonalRowID { get; set; }
        public string CandidateName { get; set; }

        public string CompanyRefNo { get; set; }

        public int ClientPackageRowID { get; set; }
        public string ClientPackageName { get; set; }

        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }


        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        public string UniqueComponentID { get; set; }

        #endregion     

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }
        public string CheckStatus { get; set; }
        public string ReWorkCheckStatus { get; set; }
        public string InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public string INFRemarks { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }
    }

    public class UpdatePQReferenceInsuffClearViewModel
    {
        public int ReferenceRowID { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
        public string ReWorkCheckStatus { get; set; }
        public short SubCheckRowID { get; set; }
        public string UniqueComponentID { get; set; }
        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public short InfSuffClearBy { get; set; }
        public DateTime? InfSuffClearDate { get; set; }

        [Display(Name = "Insuff Remarks : ")]
        public string INFRemarks { get; set; }

        //public IEnumerable<CheckActionHistoryViewModel> CheckActionHistories { get; set; }
    }

    public class PQReferenceInsuffListPagedModel
    {
        public IEnumerable<PQReferenceInsuffViewModel> PQAllInsuffReferences { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    public class ViewReferenceViewModel
    {
        [ScaffoldColumn(false)]
        [Required]
        public int ReferenceRowID { get; set; }

        [Required]
        public short ClientRowID { get; set; }

        [Required]
        public int PersonalRowID { get; set; }

        [Required]
        public int ClientPackageRowID { get; set; }

        [Required]
        public short CheckFamilyRowID { get; set; }

        [Required]
        public short SubCheckRowID { get; set; }

        [MaxLength(200)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

        [MaxLength(200)]
        [Required]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

    }
}
