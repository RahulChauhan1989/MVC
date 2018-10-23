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
   public class TempPQCriminalViewModel
    {
    }

    public class AddTempPQCriminalViewModel
    {
        [Display(Name ="ID")]
        public int CriminalRowID { get; set; }

        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public short CheckFamilyRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string UniqueComponentID { get; set; }

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

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? CRV_Period_Of_StayFrom { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? CRV_Period_Of_StayTo { get; set; }

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

        public short ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
       
        [ScaffoldColumn(false)]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    //public class TempPQUpdateCriminalViewModel
    //{
    //    [Display(Name = "ID")]
    //    public int CriminalRowID { get; set; }

    //    public short ClientRowID { get; set; }
    //    public int PersonalRowID { get; set; }
    //    public int ClientPackageRowID { get; set; }
    //    public short CheckFamilyRowID { get; set; }
    //    public short SubCheckRowID { get; set; }
    //    public string UniqueComponentID { get; set; }

    //    [Display(Name = "Candidate Name ")]
    //    public string CRV_Cand_Name { get; set; }// Text Field

    //    [Display(Name = "Securitas Reference ID ")]
    //    public string CRV_Sec_Ref_No { get; set; }// Text Field

    //    [Display(Name = "Date of Birth ")]
    //    public DateTime? CRV_DOB { get; set; }// date  Text Field

    //    [Display(Name = "Father's Name ")]
    //    public string CRV_Father_Name { get; set; }// Text Field

    //    [Display(Name = "First Name")]
    //    public string CRV_First_Name { get; set; }// Text Field

    //    [Display(Name = "Last Name")]
    //    public string CRV_Last_Name { get; set; }// Text Field

    //    [Display(Name = "Nationality")]
    //    public string CRV_Nationality { get; set; }// Text Field

    //    [Display(Name = "Name Changed effective from MM/YY")]
    //    public DateTime? CRV_Name_Chngd_Effect_Frm { get; set; }// Date  Text Field

    //    [Display(Name = "Nationality as on Passport (Applicable for Passport only)")]
    //    public string CRV_Nationality_On_Passport { get; set; }// Text Field

    //    [Display(Name = "Country of issue (Applicable for ID provided)")]
    //    public string CRV_Country_of_Issue { get; set; }// Text Field

    //    [Display(Name = "Address Type")]
    //    public string CRV_Addr_Type { get; set; }// Drop down - Current / Previous / Permanent / Intermediate 

    //    [Display(Name = "Current Address")]
    //    public string CRV_Current_Addr { get; set; }// Text Area

    //    [Display(Name = "Previous Address 1")]
    //    public string CRV_Prev_Addr1 { get; set; }// Text Area

    //    [Display(Name = "Previous Address 2")]
    //    public string CRV_Prev_Addr2 { get; set; }// Text Area

    //    [Display(Name = "Previous Address 3")]
    //    public string CRV_Prev_Addr3 { get; set; }// Text Area

    //    [Display(Name = "Previous Address 4")]
    //    public string CRV_Prev_Addr4 { get; set; }// Text Area

    //    [Display(Name = "Permanent Address")]
    //    public string CRV_Permanent_Addr { get; set; }// Text Area

    //    [Display(Name = "")]
    //    public string CRV_Period_Of_Stay { get; set; }// Date To & From Calender 

    //    public DateTime? CRV_Period_Of_StayFrom { get; set; }
    //    public DateTime? CRV_Period_Of_StayTo { get; set; }

    //    [Display(Name = "Gender")]
    //    public string CRV_Gender { get; set; }// drop down

    //    [Display(Name = "Identity Number")]
    //    public string CRV_Identity_No { get; set; }// Text Area

    //    [Display(Name = "Identity Provider")]
    //    public string CRV_Identity_Prov { get; set; }// List Box Multiple selection 

    //    [Display(Name = "Doc Received")]
    //    public string CRV_Doc_Received { get; set; }// List Box Multiple selection  

    //    [Display(Name = "Identity Proof")]
    //    public byte CRV_IdentityProof { get; set; }                      // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool CRV_IdentityProofBool
    //    {
    //        get { return CRV_IdentityProof > 0; }
    //        set { CRV_IdentityProof = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase IdentityDoc { get; set; }

    //    [Display(Name = "Address Proof")]
    //    public byte CRV_AddressProof { get; set; }                       // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool CRV_AddressProofBool
    //    {
    //        get { return CRV_AddressProof > 0; }
    //        set { CRV_AddressProof = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase AddressProofDoc { get; set; }

    //    [Display(Name = "Authrized Letter")]
    //    public byte CRV_AuthrizedLetter { get; set; }                    // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool CRV_AuthrizedLetterBool
    //    {
    //        get { return CRV_AuthrizedLetter > 0; }
    //        set { CRV_AuthrizedLetter = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase AuthrizedLetterDoc { get; set; }

    //    [Display(Name = "Other Proof")]
    //    public byte CRV_OtherProof { get; set; }                         // CheckBox     Default - 0 otherwise 1 
    //    [NotMapped]
    //    public bool CRV_OtherProofBool
    //    {
    //        get { return CRV_OtherProof > 0; }
    //        set { CRV_OtherProof = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase OtherProofDoc { get; set; }

    //    [Display(Name = "Others")]
    //    public string CRV_Others { get; set; }// Text Field

    //    [Display(Name = "Others2")]
    //    public string CRV_Others2 { get; set; }// Text Field

    //    [Display(Name = "Others3")]
    //    public string CRV_Others3 { get; set; }// Text Field

    //    [Display(Name = "Others4")]
    //    public string CRV_Others4 { get; set; }// Text Field

    //    [Display(Name = "Others5")]
    //    public string CRV_Others5 { get; set; }// Drop down 

    //    [Display(Name = "Others6")]
    //    public string CRV_Others6 { get; set; }// Text Field

    //    [Display(Name = "Others7")]
    //    public string CRV_Others7 { get; set; }// Text Field

    //    [Display(Name = "Others8")]
    //    public string CRV_Others8 { get; set; }// Text Field

    //    [Display(Name = "Others9")]
    //    public string CRV_Others9 { get; set; }// Text Field

    //    [Display(Name = "Others10")]
    //    public string CRV_Others10 { get; set; }// Drop down 

    //    [Display(Name = "CompanyId No :")]
    //    public string ATA_CID_No { get; set; }                  //TextBox

    //    [Display(Name = "Company Address :")]
    //    public string ATA_Cmpny_Addr { get; set; }              //TextArea        

    //    public short ModifiedBy { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public short MgrAllocatedBy { get; set; }
    //    public short MgrAllocatedTo { get; set; }
    //    public DateTime? MgrAllocatedDate { get; set; }

    //    [ScaffoldColumn(false)]
    //    public string CheckStatus { get; set; }

    //    [ScaffoldColumn(false)]
    //    public string CaseStatus { get; set; }

    //    [ScaffoldColumn(false)]
    //    public string Remarks { get; set; }

    //    [ScaffoldColumn(false)]
    //    public byte Status { get; set; }
    //}

    public class TempUpdateCriminalRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int CriminalRowID { get; set; }

        public short ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class TempPQCriminalList
    {
        public short AntecedentRowId { get; set; }
        public string AntecedentName { get; set; }
        public string FieldName { get; set; }
        public byte AntecedentTypeRowId { get; set; }
    }
}
