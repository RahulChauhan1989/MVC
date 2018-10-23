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
    public class AddTempPQNationalIdentityViewModel
    {
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }

        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public short CheckFamilyRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string UniqueComponentID { get; set; }

        [MaxLength(100)]
        [Display(Name = "Candidate Name :")]
        public string NIC_Cand_Name { get; set; }//text file

        [MaxLength(50)]
        [Display(Name = "Securitas Reference Id :")]
        public string NIC_Sec_Ref_Id { get; set; }//Date

        [Display(Name = "DOB :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NIC_DOB { get; set; }//Date

        [Display(Name = "Date of Birth :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NIC_DOB1 { get; set; }//text file 

        [MaxLength(50)]
        [Display(Name = "ID Number :")]
        public string NIC_ID_No { get; set; }//text file

        [Display(Name = "Date of Issue :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NIC_Date_Issue { get; set; }//text file

        [Display(Name = "Expiry Date :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NIC_Expiry_Date { get; set; }//text file

        [MaxLength(20)]
        [Display(Name = "Passport Number :")]
        public string NIC_Passport_No { get; set; }//text file

        [MaxLength(50)]
        [Display(Name = "SSN Number :")]
        public string NIC_SSN_NO { get; set; }//text file

        [MaxLength(20)]
        [Display(Name = "PAN Number :")]
        public string NIC_Pan_No { get; set; }//text file

        [MaxLength(20)]
        [Display(Name = "Voter ID Number :")]
        public string NIC_Voter_Id_No { get; set; }//text file

        [MaxLength(20)]
        [Display(Name = "Driving Liscense Number :")]
        public string NIC_Dvng_Liscense_No { get; set; }//text file

        [MaxLength(20)]
        [Display(Name = "Aadhaar Card Number :")]
        public string NIC_Aadhar_Card_No { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Place of Issue :")]
        public string NIC_Place_Issue { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Place of Residence :")]
        public string NIC_Place_Residnce { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Type of ID Card :")]
        public string NIC_Type_Id_Card { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Registration Document Type :")]
        public string NIC_Reg_Doc_Type { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Registration No. :")]
        public string NIC_RegNo { get; set; }//text file

        [MaxLength(10)]
        [Display(Name = "Pin Code")]
        public string NIC_PinCode { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Name of the Key Personnel :")]
        public string NIC_Name_Key_Personnel { get; set; }//text file

        [MaxLength(50)]
        [Display(Name = "Alias First Name :")]
        public string NIC_AliasFname { get; set; }//text file

        [MaxLength(50)]
        [Display(Name = "Alias Last Name(s) :")]
        public string NIC_Alias_Lname { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Country of issue (Applicable for Passport only) :")]
        public string NIC_Country_Iss_Passport { get; set; }//text file

        [MaxLength(20)]
        [Display(Name = "Gender :")]
        public string NIC_Gender { get; set; }//Drop down

        [MaxLength(50)]
        [Display(Name = "ID Card No. :")]
        public string NIC_Id_CardNo { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Identity Provided :")]
        public string NIC_Identity_Prov { get; set; }//text file

        [Display(Name = "Name Changed effective from MM/YY :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NIC_Name_Changed_Effect_Frm { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Nationality (Applicable for Passport only) :")]
        public string NIC_Nationality { get; set; }//text file

        [MaxLength(200)]
        [Display(Name = "Other Details :")]
        public string NIC_OtherDetails { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 2 :")]
        public string NIC_OtherDetails2 { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 3 :")]
        public string NIC_OtherDetails3 { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 4 :")]
        public string NIC_OtherDetails4 { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 5 :")]
        public string NIC_OtherDetails5 { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 6 :")]
        public string NIC_OtherDetails6 { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 7 :")]
        public string NIC_OtherDetails7 { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 8 :")]
        public string NIC_OtherDetails8 { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 9 :")]
        public string NIC_OtherDetails9 { get; set; }//text Area

        [MaxLength(200)]
        [Display(Name = "Other Details 10 :")]
        public string NIC_OtherDetails10 { get; set; }//text Area

        [MaxLength(100)]
        [Display(Name = "CID No :")]
        public string ATA_CID_No { get; set; }//text file

        [MaxLength(100)]
        [Display(Name = "Company Address :")]
        public string ATA_Cmpny_Addr { get; set; }//text file

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } 

        [Display(Name ="Check Status : ")]
        public string CheckStatus { get; set; }
       
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }
        public byte Status { get; set; }



    }

    //public class TempUpdatePQNationalIdentityViewModel
    //{
    //    [Display(Name = "ID")]
    //    [ScaffoldColumn(false)]
    //    public int NationalIdentityRowID { get; set; }

    //    public short ClientRowID { get; set; }
    //    public int PersonalRowID { get; set; }
    //    public int ClientPackageRowID { get; set; }
    //    public short CheckFamilyRowID { get; set; }
    //    public short SubCheckRowID { get; set; }
    //    public string UniqueComponentID { get; set; }

    //    [Display(Name = "Candidate Name :")]
    //    public string NIC_Cand_Name { get; set; }//text file

    //    [Display(Name = "Securitas Reference Id :")]
    //    public string NIC_Sec_Ref_Id { get; set; }//Date

    //    [Display(Name = "DOB :")]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? NIC_DOB { get; set; }//Date

    //    [Display(Name = "Date of Birth :")]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? NIC_DOB1 { get; set; }//text file

    //    [Display(Name = "ID Number :")]
    //    public string NIC_ID_No { get; set; }//text file

    //    [Display(Name = "Date of Issue :")]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? NIC_Date_Issue { get; set; }//text file

    //    [Display(Name = "Expiry Date :")]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? NIC_Expiry_Date { get; set; }//text file

    //    [Display(Name = "Passport Number :")]
    //    public string NIC_Passport_No { get; set; }//text file

    //    [Display(Name = "SSN Number :")]
    //    public string NIC_SSN_NO { get; set; }//text file

    //    [Display(Name = "PAN Number :")]
    //    public string NIC_Pan_No { get; set; }//text file

    //    [Display(Name = "Voter ID Number :")]
    //    public string NIC_Voter_Id_No { get; set; }//text file

    //    [Display(Name = "Driving Liscense Number :")]
    //    public string NIC_Dvng_Liscense_No { get; set; }//text file

    //    [Display(Name = "Aadhaar Card Number :")]
    //    public string NIC_Aadhar_Card_No { get; set; }//text file

    //    [Display(Name = "Place of Issue :")]
    //    public string NIC_Place_Issue { get; set; }//text file

    //    [Display(Name = "Place of Residence :")]
    //    public string NIC_Place_Residnce { get; set; }//text file

    //    [Display(Name = "Type of ID Card :")]
    //    public string NIC_Type_Id_Card { get; set; }//text file

    //    [Display(Name = "Registration Document Type :")]
    //    public string NIC_Reg_Doc_Type { get; set; }//text file

    //    [Display(Name = "Registration No. :")]
    //    public string NIC_RegNo { get; set; }//text file

    //    [Display(Name = "Pin Code")]
    //    public string NIC_PinCode { get; set; }//text file

    //    [Display(Name = "Name of the Key Personnel :")]
    //    public string NIC_Name_Key_Personnel { get; set; }//text file

    //    [Display(Name = "Alias First Name :")]
    //    public string NIC_AliasFname { get; set; }//text file

    //    [Display(Name = "Alias Last Name(s) :")]
    //    public string NIC_Alias_Lname { get; set; }//text file

    //    [Display(Name = "Country of issue (Applicable for Passport only) :")]
    //    public string NIC_Country_Iss_Passport { get; set; }//text file

    //    [Display(Name = "Gender :")]
    //    public string NIC_Gender { get; set; }//Drop down

    //    [Display(Name = "ID Card No. :")]
    //    public string NIC_Id_CardNo { get; set; }//text file

    //    [Display(Name = "Identity Provided :")]
    //    public string NIC_Identity_Prov { get; set; }//text file

    //    [Display(Name = "Name Changed effective from MM/YY :")]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? NIC_Name_Changed_Effect_Frm { get; set; }//text file

    //    [Display(Name = "Nationality (Applicable for Passport only) :")]
    //    public string NIC_Nationality { get; set; }//text file

    //    [Display(Name = "Other Details :")]
    //    public string NIC_OtherDetails { get; set; }//text Area

    //    [Display(Name = "Other Details 2 :")]
    //    public string NIC_OtherDetails2 { get; set; }//text Area

    //    [Display(Name = "Other Details 3 :")]
    //    public string NIC_OtherDetails3 { get; set; }//text Area

    //    [Display(Name = "Other Details 4 :")]
    //    public string NIC_OtherDetails4 { get; set; }//text Area

    //    [Display(Name = "Other Details 5 :")]
    //    public string NIC_OtherDetails5 { get; set; }//text Area

    //    [Display(Name = "Other Details 6 :")]
    //    public string NIC_OtherDetails6 { get; set; }//text Area

    //    [Display(Name = "Other Details 7 :")]
    //    public string NIC_OtherDetails7 { get; set; }//text Area

    //    [Display(Name = "Other Details 8 :")]
    //    public string NIC_OtherDetails8 { get; set; }//text Area

    //    [Display(Name = "Other Details 9 :")]
    //    public string NIC_OtherDetails9 { get; set; }//text Area

    //    [Display(Name = "Other Details 10 :")]
    //    public string NIC_OtherDetails10 { get; set; }//text Area

    //    [Display(Name = "CID No :")]
    //    public string ATA_CID_No { get; set; }//text file

    //    [Display(Name = "Company Address :")]
    //    public string ATA_Cmpny_Addr { get; set; }//text file


    //    [Display(Name = "Aadhaar Card :")]
    //    public byte NIC_AadhaarCard { get; set; } // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool NIC_AadhaarCardBool
    //    {
    //        get { return NIC_AadhaarCard > 0; }
    //        set { NIC_AadhaarCard = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase AadhaarCardDoc { get; set; }

    //    [Display(Name = "Driving License :")]
    //    public byte NIC_DrivingLicense { get; set; } // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool NIC_DrivingLicenseBool
    //    {
    //        get { return NIC_DrivingLicense > 0; }
    //        set { NIC_DrivingLicense = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase DrivingLicenseDoc { get; set; }

    //    [Display(Name = "PAN Card :")]
    //    public byte NIC_PANCard { get; set; } // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool NIC_PANCardBool
    //    {
    //        get { return NIC_PANCard > 0; }
    //        set { NIC_PANCard = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase PANCardDoc { get; set; }

    //    [Display(Name = "Passport :")]
    //    public byte NIC_Passport { get; set; } // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool NIC_PassportBool
    //    {
    //        get { return NIC_Passport > 0; }
    //        set { NIC_Passport = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase PassportDoc { get; set; }

    //    [Display(Name = "Voter Id :")]
    //    public byte NIC_VoterID { get; set; } // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool NIC_VoterIDBool
    //    {
    //        get { return NIC_VoterID > 0; }
    //        set { NIC_VoterID = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase VoterIDDoc { get; set; }

    //    [Display(Name = "Other Proof :")]
    //    public byte NIC_OtherProof { get; set; } // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool NIC_OtherProofBool
    //    {
    //        get { return NIC_OtherProof > 0; }
    //        set { NIC_OtherProof = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase OtherProofDoc { get; set; }

    //    public short ModifiedBy { get; set; }
    //    public DateTime? ModifiedDate { get; set; }
    //    public DateTime? OutDate { get; set; }
    //    public DateTime? InternalOutDate { get; set; }

    //    public short MgrAllocatedBy { get; set; }
    //    public short MgrAllocatedTo { get; set; }
    //    public DateTime? MgrAllocatedDate { get; set; }

    //    [Display(Name = "Check Status : ")]
    //    public string CheckStatus { get; set; }

    //    [Display(Name = "Case Status : ")]
    //    public string CaseStatus { get; set; }

    //    [Display(Name = "Remarks : ")]
    //    public string Remarks { get; set; }
    //    public byte Status { get; set; }



    //}

    public class TempUpdateNationalIRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }

        public short ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class TempPQNationalIdentityList
    {
        public short AntecedentRowId { get; set; }
        public string AntecedentName { get; set; }
        public string FieldName { get; set; }
        public byte AntecedentTypeRowId { get; set; }
    }


}
