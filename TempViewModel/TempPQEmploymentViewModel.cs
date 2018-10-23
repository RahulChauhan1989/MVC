using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels.TempViewModel
{
   public class AddTempEmploymentViewModel
    {
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

        [MaxLength(20)]
        [ScaffoldColumn(false)]
        public string UniqueComponentID { get; set; }

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

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? EV_EmploymentPeriodfrom { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? EV_EmploymentPeriodTo { get; set; }

        [MaxLength(100)]
        //[ScaffoldColumn(false)]
        [Display(Name = "Tenure the candidate has worked : ")]
        public string EV_CandidateTenureWorked { get; set; }// To & from calender 

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? EV_CandidateTenureWorkedfrom { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? EV_CandidateTenureWorkedTo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Tenure of the Employee : ")]
        public string EV_EmployeeTenure { get; set; }// To & from calender 

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? EV_EmployeeTenurefrom { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? EV_EmployeeTenureTo { get; set; }

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

        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }

        [ScaffoldColumn(false)]
        public short CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        public short ModifiedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

        public byte SelectOtherEmployer { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Other Employer Details : ")]
        public string Remarks { get; set; }       

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

    }

    //public class TempUpdateEmploymentViewModel
    //{
    //    [ScaffoldColumn(false)]
    //    [Display(Name = "ID")]
    //    public int EmploymentRowID { get; set; }
    //    public short ClientRowID { get; set; }
    //    public int PersonalRowID { get; set; }
    //    public int ClientPackageRowID { get; set; }
    //    public short CheckFamilyRowID { get; set; }
    //    public short SubCheckRowID { get; set; }

    //    public string UniqueComponentID { get; set; }

    //    [Display(Name = "Candidate Name : ")]
    //    public string EV_CandidateName { get; set; }   // Text Filed      

    //    [Display(Name = "Securitas Reference ID : ")]
    //    public string EV_SecuritasReferenceID { get; set; }   // Text Filed 

    //    [Display(Name = "Name of Organisation : ")]
    //    public string EV_OrganisationName { get; set; }   // Drop down - Auto populated from employer master 

    //    [Display(Name = "Company Location : ")]
    //    public string EV_CmpLocation { get; set; }// Drop Down -Location filter from employer master 

    //    [Display(Name = "Name and Address of the company : ")]
    //    public string EV_CmpNameAddress { get; set; }// Drop Down -Auto populated from employer master 

    //    [Display(Name = "Name of Employee : ")]
    //    public string EV_EmployeeName { get; set; }//  Text Field 

    //    [Display(Name = "Employee Code : ")]
    //    public string EV_EmployeeCode { get; set; }//  Text Field 

    //    [Display(Name = "Period of Employment : ")]
    //    public string EV_EmploymentPeriod { get; set; }// To & from calender 

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? EV_EmploymentPeriodfrom { get; set; }

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? EV_EmploymentPeriodTo { get; set; }

    //    [Display(Name = "Tenure the candidate has worked : ")]
    //    public string EV_CandidateTenureWorked { get; set; }// To & from calender 

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? EV_CandidateTenureWorkedfrom { get; set; }

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? EV_CandidateTenureWorkedTo { get; set; }

    //    [Display(Name = "Tenure of the Employee : ")]
    //    public string EV_EmployeeTenure { get; set; }// To & from calender 

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? EV_EmployeeTenurefrom { get; set; }

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? EV_EmployeeTenureTo { get; set; }

    //    [Display(Name = "Designation : ")]
    //    public string EV_Designation { get; set; }// Text Filed 

    //    [Display(Name = "Type of Employment (Permanent/ Temporary/ Contractual) : ")]
    //    public string EV_EmpType { get; set; }// drop down -Permanent / Temporary / contractual

    //    [Display(Name = "Department : ")]
    //    public string EV_Department { get; set; }// Text Filed

    //    [Display(Name = "Cost to Company : ")]
    //    public string EV_CmpCost { get; set; }// Text Filed

    //    [Display(Name = "Last drawn salary by the Applicant (Annual Gross) : ")]
    //    public string EV_last_sal { get; set; }// Text Filed

    //    [Display(Name = "Reason for leaving : ")]
    //    public string EV_leavingReason { get; set; }// Text Filed

    //    [Display(Name = "Reason for Subject's discontinuance from service : ")]
    //    public string EV_DiscontinueServiceReason { get; set; }// Text Filed

    //    [Display(Name = "Reporting Manager Name : ")]
    //    public string EV_ReportingManagerName { get; set; }// Text Filed

    //    [Display(Name = "Reporting Manager Name and Phone No : ")]
    //    public string EV_Rptng_Mgr_Name_Ph { get; set; }// Text Filed

    //    [Display(Name = "Reporting Manager's name and contact details : ")]
    //    public string EV_Rptng_Mgr_Name_ConDet { get; set; }// Text Filed

    //    [Display(Name = "Subject's reporting Manager (Please specify name, designation and email id/Phone No.) : ")]
    //    public string EV_Sub_Rptng_Mgr_Name_Dsg_EidPh { get; set; }// Text Filed

    //    [Display(Name = "Supervisor : ")]
    //    public string EV_Supervisor { get; set; }// Text Filed

    //    [Display(Name = "Supervisor: (Please Specify Name & Designation) : ")]
    //    public string EV_Sup_Name_Dsg { get; set; }// Text Filed

    //    [Display(Name = "Exit Formalities : ")]
    //    public string EV_FormalitiesExit { get; set; }// Text Filed

    //    [Display(Name = "Full & Final Formalities : ")]
    //    public string EV_FullFinalFormalities { get; set; }// Text Filed

    //    [Display(Name = "Any Exit formalities pending : ")]
    //    public string EV_ExitFormalitiesPending { get; set; }// Text Filed

    //    [Display(Name = "Duties & responsibilities handled : ")]
    //    public string EV_HandledResponsibilities { get; set; }// Text Filed

    //    [Display(Name = "Responsibilities handled : ")]
    //    public string EV_ResponsibilitiesHandled { get; set; }// Text Filed

    //    [Display(Name = "Expr Letter : ")]
    //    public byte EV_ExprLetter { get; set; }      // CheckBox     Default - 0 otherwise 1

    //    [NotMapped]
    //    public bool EV_ExprLetterBool
    //    {
    //        get { return EV_ExprLetter > 0; }
    //        set { EV_ExprLetter = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase ExprLetterDoc { get; set; }

    //    [Display(Name = "Reliev Letter : ")]
    //    public byte EV_RelievLetter { get; set; }    // CheckBox     Default - 0 otherwise 1

    //    [NotMapped]
    //    public bool EV_RelievLetterBool
    //    {
    //        get { return EV_RelievLetter > 0; }
    //        set { EV_RelievLetter = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase RelievLetterDoc { get; set; }

    //    [Display(Name = "Offer Letter : ")]
    //    public byte EV_OfferLetter { get; set; }     // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool EV_OfferLetterBool
    //    {
    //        get { return EV_OfferLetter > 0; }
    //        set { EV_OfferLetter = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase OfferLetterDoc { get; set; }

    //    [Display(Name = "Appoint Letter : ")]
    //    public byte EV_AppointLetter { get; set; }   // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool EV_AppointLetterBool
    //    {
    //        get { return EV_AppointLetter > 0; }
    //        set { EV_AppointLetter = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase AppointLetterDoc { get; set; }

    //    [Display(Name = "Other Proof : ")]
    //    public byte EV_OtherProof { get; set; }      // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool EV_OtherProofBool
    //    {
    //        get { return EV_OtherProof > 0; }
    //        set { EV_OtherProof = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase OtherProofDoc { get; set; }

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails { get; set; }// text Area

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails2 { get; set; }// text Area

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails3 { get; set; }// text Area


    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails4 { get; set; }// text Area

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails5 { get; set; }// text Area

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails6 { get; set; }// text Area

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails7 { get; set; }// text Area

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails8 { get; set; }// text Area

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails9 { get; set; }// text Area

    //    [Display(Name = "Other Details : ")]
    //    public string EV_OtherDetails10 { get; set; }// text Area

    //    [Display(Name = "CompanyId No : ")]
    //    public string ATA_CID_No { get; set; }// Text Filed

    //    [Display(Name = "Company Address : ")]
    //    public string ATA_Cmpny_Addr { get; set; }//Text Filed

    //    [ScaffoldColumn(false)]
    //    public short ModifiedBy { get; set; }

    //    [ScaffoldColumn(false)]
    //    public DateTime? ModifiedDate { get; set; }

    //    public short MgrAllocatedBy { get; set; }
    //    public short MgrAllocatedTo { get; set; }
    //    public DateTime? MgrAllocatedDate { get; set; }

    //    [ScaffoldColumn(false)]
    //    [Display(Name = "Check Status : ")]
    //    public string CheckStatus { get; set; }

    //    [ScaffoldColumn(false)]
    //    [Display(Name = "Case Status : ")]
    //    public string CaseStatus { get; set; }

    //    [ScaffoldColumn(false)]
    //    [Display(Name = "Remarks : ")]
    //    public string Remarks { get; set; }

    //    [ScaffoldColumn(false)]
    //    public DateTime? OutDate { get; set; }

    //    [ScaffoldColumn(false)]
    //    public DateTime? InternalOutDate { get; set; }

    //    [ScaffoldColumn(false)]
    //    public byte Status { get; set; }

    //}

    public class TempUpdateEmploymentRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int EmploymentRowID { get; set; }

        public short ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class TempPQEmploymentList
    {       
        public short AntecedentRowId { get; set; }
        public string AntecedentName { get; set; }
        public string FieldName { get; set; }
        public byte AntecedentTypeRowId { get; set; }
       
    }

    public class TempEmploymentDDLViewModel
    {
      
        [Display(Name = "Client Name")]
        public int EmploymentRowID { get; set; }
        public string EmploymentName { get; set; }
    }

    public class TempEmployeeAddressAndLocation
    {
        public string Address { get; set; }
        public string Location { get; set; }
    }
}
