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
  
    public class AddPQCriminalViewModel
    {
        [ScaffoldColumn(false)]
        public int CriminalRowID { get; set; }

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

       // public IEnumerable<CheckActionHistoryViewModel> CheckActionHistories { get; set; }
        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Candidate Name ")]
        public string CRV_Cand_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID ")]
        public string CRV_Sec_Ref_No { get; set; }// Text Field

        [Display(Name = "Date of Birth ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CRV_DOB { get; set; }// date  Text Field

        [MaxLength(100)]
        [Display(Name = "Father's Name ")]
        public string CRV_Father_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string CRV_First_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string CRV_Last_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Nationality")]
        public string CRV_Nationality { get; set; }// Text Field

        [Display(Name = "Name Changed effective from MM/YY")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CRV_Name_Chngd_Effect_Frm { get; set; }// Date  Text Field

        [MaxLength(50)]
        [Display(Name = "Nationality as on Passport (Applicable for Passport only)")]
        public string CRV_Nationality_On_Passport { get; set; }// Text Field

        [MaxLength(100)]
        [Display(Name = "Country of issue (Applicable for ID provided)")]
        public string CRV_Country_of_Issue { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Address Type")]
        public string CRV_Addr_Type { get; set; }// Drop down - Current / Previous / Permanent / Intermediate 

        [MaxLength(200)]
        [Display(Name = "Current Address")]
        public string CRV_Current_Addr { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Previous Address 1")]
        public string CRV_Prev_Addr1 { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Previous Address 2")]
        public string CRV_Prev_Addr2 { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Previous Address 3")]
        public string CRV_Prev_Addr3 { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Previous Address 4")]
        public string CRV_Prev_Addr4 { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Permanent Address")]
        public string CRV_Permanent_Addr { get; set; }// Text Area

        [MaxLength(100)]
        [Display(Name = "CRV_Period_Of_Stay")]
        public string CRV_Period_Of_Stay { get; set; }// Date To & From Calender 
   
        [MaxLength(20)]
        [Display(Name = "Gender")]
        public string CRV_Gender { get; set; }// drop down

        [MaxLength(100)]
        [Display(Name = "Identity Number")]
        public string CRV_Identity_No { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Identity Provider")]
        public string CRV_Identity_Prov { get; set; }// List Box Multiple selection 

        [MaxLength(200)]
        [Display(Name = "Doc Received")]
        public string CRV_Doc_Received { get; set; }// List Box Multiple selection          

        [MaxLength(200)]
        [Display(Name = "Others")]
        public string CRV_Others { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others2")]
        public string CRV_Others2 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others3")]
        public string CRV_Others3 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others4")]
        public string CRV_Others4 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others5")]
        public string CRV_Others5 { get; set; }// Drop down 

        [MaxLength(200)]
        [Display(Name = "Others6")]
        public string CRV_Others6 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others7")]
        public string CRV_Others7 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others8")]
        public string CRV_Others8 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others9")]
        public string CRV_Others9 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others10")]
        public string CRV_Others10 { get; set; }// Drop down 

        [MaxLength(50)]
        [Display(Name = "CompanyId No :")]
        public string ATA_CID_No { get; set; }                  //TextBox

        [MaxLength(200)]
        [Display(Name = "Company Address :")]
        public string ATA_Cmpny_Addr { get; set; }              //TextArea


        [ScaffoldColumn(false)]
        public short CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }

        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }

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
        [Display(Name ="Reason : ")]
        public string INFRemarks { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class PQUpdateCriminalViewModel
    {
        [ScaffoldColumn(false)]
        public int CriminalRowID { get; set; }

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

        [MaxLength(100)]
        [Display(Name = "Candidate Name ")]
        public string CRV_Cand_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID ")]
        public string CRV_Sec_Ref_No { get; set; }// Text Field

        [Display(Name = "Date of Birth ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CRV_DOB { get; set; }// date  Text Field

        [MaxLength(100)]
        [Display(Name = "Father's Name ")]
        public string CRV_Father_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string CRV_First_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string CRV_Last_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Nationality")]
        public string CRV_Nationality { get; set; }// Text Field

        [Display(Name = "Name Changed effective from MM/YY")]
        public DateTime? CRV_Name_Chngd_Effect_Frm { get; set; }// Date  Text Field

        [MaxLength(50)]
        [Display(Name = "Nationality as on Passport (Applicable for Passport only)")]
        public string CRV_Nationality_On_Passport { get; set; }// Text Field

        [MaxLength(100)]
        [Display(Name = "Country of issue (Applicable for ID provided)")]
        public string CRV_Country_of_Issue { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Address Type")]
        public string CRV_Addr_Type { get; set; }// Drop down - Current / Previous / Permanent / Intermediate 

        [MaxLength(200)]
        [Display(Name = "Current Address")]
        public string CRV_Current_Addr { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Previous Address 1")]
        public string CRV_Prev_Addr1 { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Previous Address 2")]
        public string CRV_Prev_Addr2 { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Previous Address 3")]
        public string CRV_Prev_Addr3 { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Previous Address 4")]
        public string CRV_Prev_Addr4 { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Permanent Address")]
        public string CRV_Permanent_Addr { get; set; }// Text Area

        [MaxLength(100)]
        [Display(Name = "CRV_Period_Of_Stay")]
        public string CRV_Period_Of_Stay { get; set; }// Date To & From Calender        

        [MaxLength(20)]
        [Display(Name = "Gender")]
        public string CRV_Gender { get; set; }// drop down

        [MaxLength(100)]
        [Display(Name = "Identity Number")]
        public string CRV_Identity_No { get; set; }// Text Area

        [MaxLength(200)]
        [Display(Name = "Identity Provider")]
        public string CRV_Identity_Prov { get; set; }// List Box Multiple selection 

        [MaxLength(200)]
        [Display(Name = "Doc Received")]
        public string CRV_Doc_Received { get; set; }// List Box Multiple selection  

        [MaxLength(200)]
        [Display(Name = "Others")]
        public string CRV_Others { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others2")]
        public string CRV_Others2 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others3")]
        public string CRV_Others3 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others4")]
        public string CRV_Others4 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others5")]
        public string CRV_Others5 { get; set; }// Drop down 

        [MaxLength(200)]
        [Display(Name = "Others6")]
        public string CRV_Others6 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others7")]
        public string CRV_Others7 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others8")]
        public string CRV_Others8 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others9")]
        public string CRV_Others9 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others10")]
        public string CRV_Others10 { get; set; }// Drop down 

        [MaxLength(50)]
        [Display(Name = "CompanyId No :")]
        public string ATA_CID_No { get; set; }                  //TextBox

        [MaxLength(200)]
        [Display(Name = "Company Address :")]
        public string ATA_Cmpny_Addr { get; set; }              //TextArea        

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short MgrAllocatedBy { get; set; }
        public short MgrAllocatedTo { get; set; }
        public DateTime? MgrAllocatedDate { get; set; }

        [MaxLength(20)]
        public string CheckStatus { get; set; }

        [MaxLength(20)]
        public string ReWorkCheckStatus { get; set; }

        [MaxLength(500)]
        [Display(Name = "If Reject : ")]
        public string RejectionReason { get; set; }

        [MaxLength(200)]
        public string Remarks { get; set; }


        public byte Status { get; set; }
    }

    public class PQUpdateCriminalManagerViewModel
    {
        [ScaffoldColumn(false)]
        public int CriminalRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short TLAllocatedBy { get; set; }
        public short TLAllocatedTo { get; set; }
        public DateTime? TLAllocatedDate { get; set; }

        [MaxLength()]
        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQUpdateCriminalTeamLeaderViewModel
    {
        [ScaffoldColumn(false)]
        public int CriminalRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
        public short TMAllocatedTo { get; set; }
        public DateTime? TMAllocatedDate { get; set; }
        public short TMQCAllocatedTo { get; set; }
        public DateTime? TMQCAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQUpdateCriminalTeamMemberViewModel
    {
        [ScaffoldColumn(false)]
        public int CriminalRowID { get; set; }

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

    public class UpdateCriminalRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int CriminalRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public string INFRemarks { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }
    
    public class PQCriminalInsuffViewModel
    {
        public int CriminalRowID { get; set; }

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

    public class UpdatePQCriminalInsuffClearViewModel
    {
        public int CriminalRowID { get; set; }
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

    public class PQCriminalInsuffListPagedModel
    {
        public IEnumerable<PQCriminalInsuffViewModel> PQAllInsuffCriminals { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    public class ViewCriminalViewModel
    {
        [ScaffoldColumn(false)]
        [Required]
        public int CriminalRowID { get; set; }

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
