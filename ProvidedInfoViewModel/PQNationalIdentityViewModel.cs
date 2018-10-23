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
    public class AddPQNationalIdentityViewModel
    {
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }

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
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name ="Check Status : ")]
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

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class UpdatePQNationalIdentityViewModel
    {
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }

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

        [MaxLength(20)]
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

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }

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

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class UpdateNationalIRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }

        [MaxLength()]
        public string INFRemarks { get; set; }


        [MaxLength()]
        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }
    public class PQUpdateNationalIdentityManagerViewModel
    {
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short TLAllocatedBy { get; set; }
        public short TLAllocatedTo { get; set; }
        public DateTime? TLAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
    }

    public class PQUpdateNationalIdentityTeamLeaderViewModel
    {
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }

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

    public class PQUpdateNationalIdentityTeamMemberViewModel
    {
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }

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

    public class PQNationalIdentityInsuffViewModel
    {
        public int NationalIdentityRowID { get; set; }

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

    public class UpdatePQNationalIdentityInsuffClearViewModel
    {
        [ScaffoldColumn(false)]
        public int NationalIdentityRowID { get; set; }
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

    public class PQNationalIdentityInsuffListPagedModel
    {
        public IEnumerable<PQNationalIdentityInsuffViewModel> PQAllInsuffNationalIdentities { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    public class ViewNationalIdentityViewModel
    {
        [ScaffoldColumn(false)]
        [Required]
        public int NationalIdentityRowID { get; set; }

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
