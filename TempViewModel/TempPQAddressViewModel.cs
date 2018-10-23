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
    public class TempPQAddressViewModel
    {
        public int AddressRowID { get; set; }

        #region Common for all Checks 

        [ScaffoldColumn(false)]
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public int PersonalRowID { get; set; }
        public string PersonalName { get; set; }

        public int ClientPackageRowID { get; set; }
        public string ClientPackageName { get; set; }

        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }

        [ScaffoldColumn(false)]
        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        [MaxLength(20)]
        [ScaffoldColumn(false)]
        public string UniqueComponentID { get; set; }

        #endregion

        [MaxLength(100)]
        [Display(Name = "Candidate Name :")]
        public string AV_Cand_Name { get; set; }            //TextBox

        [MaxLength(50)]
        [Display(Name = "Securitas Reference Nos :")]
        public string AV_Sec_Ref_No { get; set; }           //TextBox

        [MaxLength(200)]
        [Display(Name = "Address :")]
        public string AV_Add { get; set; }                  //TextArea

        [MaxLength(200)]
        [Display(Name = "Address Line 1 :")]
        public string AV_Add_Line1 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Address Line 2 :")]
        public string AV_Add_Line2 { get; set; }            //TextArea

        [MaxLength(100)]
        [Display(Name = "Building/Street Name :")]
        public string AV_Buldng_Street_name { get; set; }   //TextBox

        [Display(Name = "Country : ")]
        public short AV_Country { get; set; }

        [Display(Name = "State :")]
        public short AV_State { get; set; }                 // Drop Down - State ref id drop down//change add string to short  5-12-2016

        [Display(Name = "District :")]
        public short AV_District { get; set; }              // Drop Down - District ref id drop down //change add string to short  5-12-2016

        [Display(Name = "City :")]
        public int AV_City { get; set; }                    // Drop Down - City Master

        [Display(Name = "Pin Code :")]
        public int AV_Pincode { get; set; }                 //TextBox - Pincode ref id drop down//change add string to short  5-12-2016

        [MaxLength(100)]
        [Display(Name = "Landmark :")]
        public string AV_Landmark { get; set; }            //TextBox

        [MaxLength(100)]
        [Display(Name = "Address Type :")]
        public string AV_Add_Type { get; set; }             // Drop Down - Own/Rented/company provide/PG/Relative house/Others

        [MaxLength(100)]
        //[ScaffoldColumn(false)]
        [Display(Name = "Duration of Stay :")]
        public string AV_Dur_of_Stay { get; set; }          //To & From Calender

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? AV_Dur_of_StayFrom { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? AV_Dur_of_StayTo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Owner Name :")]
        public string AV_Owner_Name { get; set; }            //TextBox

        [MaxLength(20)]
        [Display(Name = "Owner Contact Nos :")]
        public string AV_Owner_ConNo { get; set; }            //TextBox

        [MaxLength(20)]
        [Display(Name = "Nick Name :")]
        public string AV_NickName { get; set; }                 //TextBox

        [MaxLength(50)]
        [Display(Name = "Name Changed and effective from (MM/YY) :")]
        public string AV_Name_Chngd_Effect_Frm { get; set; }    //TextBox 

        [MaxLength(200)]
        [Display(Name = "Documents provided as proof of the address :")]
        public string AV_Doc_Prov_Proof_Add { get; set; }    // drop down Documents provided as proof of the address- List of address proof

        [MaxLength(200)]
        [ScaffoldColumn(false)]
        public string AddressProofFileName { get; set; }    //Not Show on Page

        [MaxLength(200)]
        [Display(Name = "Document Details :")]
        public string AV_Doc_Details { get; set; }           //drop down Document Details - List of address proof        

        [MaxLength(200)]
        [ScaffoldColumn(false)]
        public string DocumentDetailsFileName { get; set; }    //Not Show on Page


        [MaxLength(200)]
        [Display(Name = "Other Details :")]
        public string AV_OtherDetails { get; set; }             //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 2 :")]
        public string AV_OtherDetails2 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 3 :")]
        public string AV_OtherDetails3 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 4 :")]
        public string AV_OtherDetails4 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 5 :")]
        public string AV_OtherDetails5 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 6 :")]
        public string AV_OtherDetails6 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 7 :")]
        public string AV_OtherDetails7 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 8 :")]
        public string AV_OtherDetails8 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 9 :")]
        public string AV_OtherDetails9 { get; set; }            //TextArea

        [MaxLength(200)]
        [Display(Name = "Other Details 10 :")]
        public string AV_OtherDetails10 { get; set; }           //TextArea

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

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Check Status : ")]
        [ScaffoldColumn(false)]
        public string CheckStatus { get; set; }

        [Display(Name = "Case Status : ")]
        [ScaffoldColumn(false)]
        public string CaseStatus { get; set; }    // Pending,DEO,D-1NF

        [Display(Name = "Remarks : ")]
        [ScaffoldColumn(false)]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

    }
    //public class TempPQUpdateAddressViewModel
    //{
    //    [ScaffoldColumn(false)]
    //    public int AddressRowID { get; set; }

    //    #region Common for all Checks 

    //    public short ClientRowID { get; set; }
    //    public string ClientName { get; set; }

    //    public int PersonalRowID { get; set; }
    //    public string PersonalName { get; set; }

    //    public int ClientPackageRowID { get; set; }
    //    public string ClientPackageName { get; set; }

    //    public short CheckFamilyRowID { get; set; }
    //    public string CheckFamilyName { get; set; }


    //    public short SubCheckRowID { get; set; }
    //    public string SubCheckName { get; set; }

    //    public string UniqueComponentID { get; set; }

    //    #endregion

    //    [Display(Name = "Candidate Name :")]
    //    public string AV_Cand_Name { get; set; }            //TextBox

    //    [Display(Name = "Securitas Reference Nos :")]
    //    public string AV_Sec_Ref_No { get; set; }           //TextBox

    //    [Display(Name = "Address :")]
    //    public string AV_Add { get; set; }                  //TextArea

    //    [Display(Name = "Address Line 1 :")]
    //    public string AV_Add_Line1 { get; set; }            //TextArea

    //    [Display(Name = "Address Line 2 :")]
    //    public string AV_Add_Line2 { get; set; }            //TextArea

    //    [Display(Name = "Building/Street Name :")]
    //    public string AV_Buldng_Street_name { get; set; }   //TextBox

    //    [Display(Name = "Country : ")]
    //    public short AV_Country { get; set; }

    //    [Display(Name = "State :")]
    //    public short AV_State { get; set; }                 // Drop Down - State ref id drop down//change add string to short  5-12-2016

    //    [Display(Name = "District :")]
    //    public short AV_District { get; set; }              // Drop Down - District ref id drop down //change add string to short  5-12-2016

    //    [Display(Name = "City :")]
    //    public int AV_City { get; set; }                    // Drop Down - City Master

    //    [Display(Name = "Pin Code :")]
    //    public int AV_Pincode { get; set; }                 //TextBox - Pincode ref id drop down//change add string to short  5-12-2016

    //    [Display(Name = "Landmark :")]
    //    public string AV_Landmark { get; set; }            //TextBox

    //    [Display(Name = "Address Type :")]
    //    public string AV_Add_Type { get; set; }             // Drop Down - Own/Rented/company provide/PG/Relative house/Others

    //    [Display(Name = "Duration of Stay :")]
    //    public string AV_Dur_of_Stay { get; set; }          //To & From Calender

    //    public DateTime? AV_Dur_of_StayFrom { get; set; }
    //    public DateTime? AV_Dur_of_StayTo { get; set; }

    //    [Display(Name = "Owner Name :")]
    //    public string AV_Owner_Name { get; set; }            //TextBox

    //    [Display(Name = "Owner Contact Nos :")]
    //    public string AV_Owner_ConNo { get; set; }            //TextBox

    //    [Display(Name = "Nick Name :")]
    //    public string AV_NickName { get; set; }                 //TextBox

    //    [Display(Name = "Name Changed and effective from (MM/YY) :")]
    //    public string AV_Name_Chngd_Effect_Frm { get; set; }    //TextBox 

    //    [Display(Name = "Documents provided as proof of the address :")]
    //    public string AV_Doc_Prov_Proof_Add { get; set; }    // drop down Documents provided as proof of the address- List of address proof

    //    [ScaffoldColumn(false)]
    //    public string AddressProofFileName { get; set; }    //Not Show on Page

    //    [Display(Name = "Document Details :")]
    //    public string AV_Doc_Details { get; set; }           //drop down Document Details - List of address proof        

    //    [ScaffoldColumn(false)]
    //    public string DocumentDetailsFileName { get; set; }    //Not Show on Page


    //    [Display(Name = "Ration Card :")]
    //    public byte AV_RationCard { get; set; }                  // CheckBox    Default- 0 otherwise 1
    //    [NotMapped]
    //    public bool AV_RationCardBool
    //    {
    //        get { return AV_RationCard > 0; }
    //        set { AV_RationCard = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase RationCardDoc { get; set; }

    //    [Display(Name = "Telephone Bill :")]
    //    public byte AV_TelephoneBill { get; set; }               // CheckBox    Default- 0 otherwise 1
    //    [NotMapped]
    //    public bool AV_TelephoneBillBool
    //    {
    //        get { return AV_TelephoneBill > 0; }
    //        set { AV_TelephoneBill = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase TelephoneDoc { get; set; }

    //    [Display(Name = "Rent Agreement :")]
    //    public byte AV_RentAgreement { get; set; }               // CheckBox    Default- 0 otherwise 1
    //    [NotMapped]
    //    public bool AV_RentAgreementBool
    //    {
    //        get { return AV_RentAgreement > 0; }
    //        set { AV_RentAgreement = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase RentAgreementDoc { get; set; }

    //    [Display(Name = "Passport :")]
    //    public byte AV_Passport { get; set; }                    // CheckBox    Default- 0 otherwise 1s

    //    [NotMapped]
    //    public bool AV_PassportBool
    //    {
    //        get { return AV_Passport > 0; }
    //        set { AV_Passport = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase AV_PassportDoces { get; set; }

    //    [Display(Name = "Electricity Bill :")]
    //    public byte AV_ElectricityBill { get; set; }             // CheckBox    Default- 0 otherwise 1
    //    [NotMapped]
    //    public bool AV_ElectricityBillBool
    //    {
    //        get { return AV_ElectricityBill > 0; }
    //        set { AV_ElectricityBill = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase ElectricityDoc { get; set; }

    //    [Display(Name = "Gas Supply Bill :")]
    //    public byte AV_GasSupplyBill { get; set; }               // CheckBox    Default- 0 otherwise 1
    //    [NotMapped]
    //    public bool AV_GasSupplyBillBool
    //    {
    //        get { return AV_GasSupplyBill > 0; }
    //        set { AV_GasSupplyBill = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase GasSupplyDoc { get; set; }

    //    [Display(Name = "Water Bill :")]
    //    public byte AV_WaterBill { get; set; }                   // CheckBox    Default- 0 otherwise 1
    //    [NotMapped]
    //    public bool AV_WaterBillBool
    //    {
    //        get { return AV_WaterBill > 0; }
    //        set { AV_WaterBill = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase WaterDoc { get; set; }

    //    [Display(Name = "Other Proof :")]
    //    public byte AV_OtherProof { get; set; }                  // CheckBox    Default- 0 otherwise 1
    //    [NotMapped]
    //    public bool AV_OtherProofBool
    //    {
    //        get { return AV_OtherProof > 0; }
    //        set { AV_OtherProof = value ? (byte)1 : (byte)0; }
    //    }

    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase OtherProofDoc { get; set; }

    //    [Display(Name = "Other Details :")]
    //    public string AV_OtherDetails { get; set; }             //TextArea

    //    [Display(Name = "Other Details 2 :")]
    //    public string AV_OtherDetails2 { get; set; }            //TextArea

    //    [Display(Name = "Other Details 3 :")]
    //    public string AV_OtherDetails3 { get; set; }            //TextArea

    //    [Display(Name = "Other Details 4 :")]
    //    public string AV_OtherDetails4 { get; set; }            //TextArea

    //    [Display(Name = "Other Details 5 :")]
    //    public string AV_OtherDetails5 { get; set; }            //TextArea

    //    [Display(Name = "Other Details 6 :")]
    //    public string AV_OtherDetails6 { get; set; }            //TextArea

    //    [Display(Name = "Other Details 7 :")]
    //    public string AV_OtherDetails7 { get; set; }            //TextArea

    //    [Display(Name = "Other Details 8 :")]
    //    public string AV_OtherDetails8 { get; set; }            //TextArea

    //    [Display(Name = "Other Details 9 :")]
    //    public string AV_OtherDetails9 { get; set; }            //TextArea

    //    [Display(Name = "Other Details 10 :")]
    //    public string AV_OtherDetails10 { get; set; }           //TextArea

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
    //    [Display(Name = "Check Status : ")]
    //    public string CheckStatus { get; set; }

    //    [ScaffoldColumn(false)]
    //    [Display(Name = "Case Status : ")]
    //    public string CaseStatus { get; set; }

    //    [ScaffoldColumn(false)]
    //    [Display(Name = "Remarks : ")]
    //    public string Remarks { get; set; }

    //    [ScaffoldColumn(false)]
    //    public byte Status { get; set; }

    //}
}
