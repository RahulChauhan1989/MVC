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
    public class PQEmploymentViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int EmploymentRowID { get; set; }

        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public int PersonalRowID { get; set; }
        public string CandidateName { get; set; }

        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        public string CompanyRefNo { get; set; }

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }        
        public string CheckStatus { get; set; }        
        public string CaseStatus { get; set; }

    }

    public class AddEmploymentViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int EmploymentRowID { get; set; }

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
        [Display(Name = "Candidate Name : ")]
        public string EV_CandidateName { get; set; }   // Text Filed      

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID : ")]
        public string EV_SecuritasReferenceID { get; set; }   // Text Filed 

        [MaxLength(100)]
        [Display(Name = "Name of Organisation : ")]
        public string EV_OrganisationName { get; set; }   // Drop down - Auto populated from employer master 

        [MaxLength(100)]
        [Display(Name = "Company Location : ")]
        public string EV_CmpLocation { get; set; }// Drop Down -Location filter from employer master 

        [MaxLength(200)]
        [Display(Name = "Name and Address of the company : ")]
        public string EV_CmpNameAddress { get; set; }// Drop Down -Auto populated from employer master 

        [MaxLength(100)]
        [Display(Name = "Name of Employee : ")]
        public string EV_EmployeeName { get; set; }//  Text Field 

        [MaxLength(50)]
        [Display(Name = "Employee Code : ")]
        public string EV_EmployeeCode { get; set; }//  Text Field 

        [MaxLength(100)]
        [Display(Name = "Period of Employment : ")]
        public string EV_EmploymentPeriod { get; set; }// To & from calender 

        [MaxLength(100)]
        [ScaffoldColumn(false)]
        [Display(Name = "Tenure the candidate has worked : ")]
        public string EV_CandidateTenureWorked { get; set; }// To & from calender 
        
        [MaxLength(100)]
        [Display(Name = "Tenure of the Employee : ")]
        public string EV_EmployeeTenure { get; set; }// To & from calender 

        [MaxLength(50)]
        [Display(Name = "Designation : ")]
        public string EV_Designation { get; set; }// Text Filed 

        [MaxLength(50)]
        [Display(Name = "Type of Employment (Permanent/ Temporary/ Contractual) : ")]
        public string EV_EmpType { get; set; }// drop down -Permanent / Temporary / contractual

        [MaxLength(100)]
        [Display(Name = "Department : ")]
        public string EV_Department { get; set; }// Text Filed

        [MaxLength(50)]
        [Display(Name = "Cost to Company : ")]
        public string EV_CmpCost { get; set; }// Text Filed

        [MaxLength(50)]
        [Display(Name = "Last drawn salary by the Applicant (Annual Gross) : ")]
        public string EV_last_sal { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reason for leaving : ")]
        public string EV_leavingReason { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reason for Subject's discontinuance from service : ")]
        public string EV_DiscontinueServiceReason { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reporting Manager Name : ")]
        public string EV_ReportingManagerName { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reporting Manager Name and Phone No : ")]
        public string EV_Rptng_Mgr_Name_Ph { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reporting Manager's name and contact details : ")]
        public string EV_Rptng_Mgr_Name_ConDet { get; set; }// Text Filed

        [MaxLength(200)]
        [Display(Name = "Subject's reporting Manager (Please specify name, designation and email id/Phone No.) : ")]
        public string EV_Sub_Rptng_Mgr_Name_Dsg_EidPh { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Supervisor : ")]
        public string EV_Supervisor { get; set; }// Text Filed

        [MaxLength(150)]
        [Display(Name = "Supervisor: (Please Specify Name & Designation) : ")]
        public string EV_Sup_Name_Dsg { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Exit Formalities : ")]
        public string EV_FormalitiesExit { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Full & Final Formalities : ")]
        public string EV_FullFinalFormalities { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Any Exit formalities pending : ")]
        public string EV_ExitFormalitiesPending { get; set; }// Text Filed

        [MaxLength(200)]
        [Display(Name = "Duties & responsibilities handled : ")]
        public string EV_HandledResponsibilities { get; set; }// Text Filed

        [MaxLength(200)]
        [Display(Name = "Responsibilities handled : ")]
        public string EV_ResponsibilitiesHandled { get; set; }// Text Filed


        //[ValidateLargeFileCandidateUploadDocs]
        //public HttpPostedFileBase OtherProofDoc { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails2 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails3 { get; set; }// text Area


        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails4 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails5 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails6 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails7 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails8 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails9 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails10 { get; set; }// text Area

        [MaxLength(50)]
        [Display(Name = "CompanyId No : ")]
        public string ATA_CID_No { get; set; }// Text Filed

        [MaxLength(200)]
        [Display(Name = "Company Address : ")]
        public string ATA_Cmpny_Addr { get; set; }//Text Filed

        [ScaffoldColumn(false)]
        public short CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }

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

        [Display(Name ="Other Employer Details : ")]
        public string OtherEmployer { get; set; }
        public byte SelectOtherEmployer { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }
        
        public DateTime? OutDate { get; set; }
        
        public DateTime? InternalOutDate { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

    }

    public class UpdateEmploymentViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int EmploymentRowID { get; set; }

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

        [MaxLength(100)]
        [Display(Name = "Candidate Name : ")]
        public string EV_CandidateName { get; set; }   // Text Filed      

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID : ")]
        public string EV_SecuritasReferenceID { get; set; }   // Text Filed 

        [MaxLength(100)]
        [Display(Name = "Name of Organisation : ")]
        public string EV_OrganisationName { get; set; }   // Drop down - Auto populated from employer master 

        public string OrganisationName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Company Location : ")]
        public string EV_CmpLocation { get; set; }// Drop Down -Location filter from employer master 

        [MaxLength(200)]
        [Display(Name = "Name and Address of the company : ")]
        public string EV_CmpNameAddress { get; set; }// Drop Down -Auto populated from employer master 

        [MaxLength(100)]
        [Display(Name = "Name of Employee : ")]
        public string EV_EmployeeName { get; set; }//  Text Field 

        [MaxLength(50)]
        [Display(Name = "Employee Code : ")]
        public string EV_EmployeeCode { get; set; }//  Text Field 

        [MaxLength(100)]
        [Display(Name = "Period of Employment : ")]
        public string EV_EmploymentPeriod { get; set; }// To & from calender 
        
        [MaxLength(100)]
        [Display(Name = "Tenure the candidate has worked : ")]
        public string EV_CandidateTenureWorked { get; set; }// To & from calender        

        [MaxLength(100)]
        [Display(Name = "Tenure of the Employee : ")]
        public string EV_EmployeeTenure { get; set; }// To & from calender 

        [MaxLength(50)]
        [Display(Name = "Designation : ")]
        public string EV_Designation { get; set; }// Text Filed 

        [MaxLength(50)]
        [Display(Name = "Type of Employment (Permanent/ Temporary/ Contractual) : ")]
        public string EV_EmpType { get; set; }// drop down -Permanent / Temporary / contractual

        [MaxLength(100)]
        [Display(Name = "Department : ")]
        public string EV_Department { get; set; }// Text Filed

        [MaxLength(50)]
        [Display(Name = "Cost to Company : ")]
        public string EV_CmpCost { get; set; }// Text Filed

        [MaxLength(50)]
        [Display(Name = "Last drawn salary by the Applicant (Annual Gross) : ")]
        public string EV_last_sal { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reason for leaving : ")]
        public string EV_leavingReason { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reason for Subject's discontinuance from service : ")]
        public string EV_DiscontinueServiceReason { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reporting Manager Name : ")]
        public string EV_ReportingManagerName { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reporting Manager Name and Phone No : ")]
        public string EV_Rptng_Mgr_Name_Ph { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Reporting Manager's name and contact details : ")]
        public string EV_Rptng_Mgr_Name_ConDet { get; set; }// Text Filed

        [MaxLength(200)]
        [Display(Name = "Subject's reporting Manager (Please specify name, designation and email id/Phone No.) : ")]
        public string EV_Sub_Rptng_Mgr_Name_Dsg_EidPh { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Supervisor : ")]
        public string EV_Supervisor { get; set; }// Text Filed

        [MaxLength(150)]
        [Display(Name = "Supervisor: (Please Specify Name & Designation) : ")]
        public string EV_Sup_Name_Dsg { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Exit Formalities : ")]
        public string EV_FormalitiesExit { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Full & Final Formalities : ")]
        public string EV_FullFinalFormalities { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Any Exit formalities pending : ")]
        public string EV_ExitFormalitiesPending { get; set; }// Text Filed

        [MaxLength(100)]
        [Display(Name = "Duties & responsibilities handled : ")]
        public string EV_HandledResponsibilities { get; set; }// Text Filed

        [MaxLength(200)]
        [Display(Name = "Responsibilities handled : ")]
        public string EV_ResponsibilitiesHandled { get; set; }// Text Filed


        //[ValidateLargeFileCandidateUploadDocs]
        //public HttpPostedFileBase OtherProofDoc { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails2 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails3 { get; set; }// text Area


        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails4 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails5 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails6 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails7 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails8 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails9 { get; set; }// text Area

        [MaxLength(200)]
        [Display(Name = "Other Details : ")]
        public string EV_OtherDetails10 { get; set; }// text Area

        [MaxLength(50)]
        [Display(Name = "CompanyId No : ")]
        public string ATA_CID_No { get; set; }// Text Filed

        [MaxLength(200)]
        [Display(Name = "Company Address : ")]
        public string ATA_Cmpny_Addr { get; set; }//Text Filed

        [ScaffoldColumn(false)]
        public short ModifiedBy { get; set; }

        [ScaffoldColumn(false)]
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

        [Display(Name = "Other Employer Details : ")]
        public string OtherEmployer { get; set; }
        public byte SelectOtherEmployer { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }
        
        public DateTime? OutDate { get; set; }
        
        public DateTime? InternalOutDate { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

    }

    public class PQUpdateEmploymentManagerViewModel
    {
        [ScaffoldColumn(false)]
        public int EmploymentRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short TLAllocatedBy { get; set; }
        public short TLAllocatedTo { get; set; }
        public DateTime? TLAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQUpdateEmploymentTeamLeaderViewModel
    {
        [ScaffoldColumn(false)]
        public int EmploymentRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //public short TMAllocatedBy { get; set; }
        public short TMAllocatedTo { get; set; }
        public DateTime? TMAllocatedDate { get; set; }
        //public short TMQCAllocatedBy { get; set; }
        public short TMQCAllocatedTo { get; set; }
        public DateTime? TMQCAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
    }

    public class PQUpdateEmploymentTeamMemberViewModel
    {
        [ScaffoldColumn(false)]
        public int EmploymentRowID { get; set; }

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

    public class UpdateEmploymentRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int EmploymentRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public string INFRemarks { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQUpdateEmploymentResearcherViewModel
    {
        [ScaffoldColumn(false)]
        public int EmploymentRowID { get; set; }

        public string UniqueComponentID { get; set; }
        public int PersonalRowID { get; set; }
        public short SubCheckRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQEmploymentYTRClearViewModel
    {
        [ScaffoldColumn(false)]
        public int EmploymentRowID { get; set; }

        public string UniqueComponentID { get; set; }
        public int PersonalRowID { get; set; }
        public short SubCheckRowID { get; set; }

        [Display(Name = "Date Of Leaving : ")]
        public DateTime? DOL { get; set; }

        [Display(Name = "Upload Doc : ")]
        [ValidateImageFileAttribute]
        public HttpPostedFileBase UploadDoc { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string SecuritasRefID { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }
    public class EmploymentDDLViewModel
    {
        [Display(Name = "Client Name")]
        public int EmploymentRowID { get; set; }
        public string EmploymentName { get; set; }
    }

    public class EmployeeAddressAndLocation
    {
        public string Address { get; set; }
        public string Location { get; set; }
    }
    public class PQEmploymentListPagedModel
    {
        public IEnumerable<PQEmploymentViewModel> PQEmployments { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class PQEmploymentInsuffViewModel
    {
        public int EmploymentRowID { get; set; }

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

    public class UpdatePQEmploymentInsuffClearViewModel
    {
        public int EmploymentRowID { get; set; }
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

    public class PQEmploymentInsuffListPagedModel
    {
        public IEnumerable<PQEmploymentInsuffViewModel> PQAllInsuffEmployments { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    public class ViewEmploymentViewModel
    {
        [ScaffoldColumn(false)]
        [Required]
        public int EmploymentRowID { get; set; }

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
