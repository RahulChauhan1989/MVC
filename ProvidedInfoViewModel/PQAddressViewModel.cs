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
    public class PQAddressViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

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

        public string MyProperty { get; set; }

        [Display(Name ="Country : ")]
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
        [ScaffoldColumn(false)]
        [Display(Name = "Duration of Stay :")]
        public string AV_Dur_of_Stay { get; set; }          //To & From Calender

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

        [Required]
        [MaxLength(20)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

        [MaxLength(20)]
        [Display(Name = "ReWork Check Status : ")]
        public string ReWorkCheckStatus { get; set; }    // Pending,DEO,D-1NF

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

    public class PQUpdateAddressViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

        #region Common for all Checks 

        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public int PersonalRowID { get; set; }
        public string PersonalName { get; set; }

        public int ClientPackageRowID { get; set; }
        public string ClientPackageName { get; set; }

        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }


        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        public string UniqueComponentID { get; set; }

        //public IEnumerable<CheckActionHistoryViewModel> CheckActionHistories { get; set; }
        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

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

        public short CountryName { get; set; }

        [Display(Name = "State :")]
        public short AV_State { get; set; }                 // Drop Down - State ref id drop down//change add string to short  5-12-2016

        public string StateName { get; set; }

        [Display(Name = "District :")]
        public short AV_District { get; set; }              // Drop Down - District ref id drop down //change add string to short  5-12-2016

        public string DistrictName { get; set; }

        [Display(Name = "City :")]
        public int AV_City { get; set; }                    // Drop Down - City Master

        public string CityName { get; set; }

        [Display(Name = "Pin Code :")]
        public int AV_Pincode { get; set; }                 //TextBox - Pincode ref id drop down//change add string to short  5-12-2016

        [MaxLength(100)]
        [Display(Name = "Landmark :")]
        public string AV_Landmark { get; set; }            //TextBox

        [MaxLength(100)]
        [Display(Name = "Address Type :")]
        public string AV_Add_Type { get; set; }             // Drop Down - Own/Rented/company provide/PG/Relative house/Others

        [MaxLength(100)]
        [Display(Name = "Duration of Stay :")]
        public string AV_Dur_of_Stay { get; set; }          //To & From Calender
               
        [MaxLength(100)]
        [Display(Name = "Owner Name :")]
        public string AV_Owner_Name { get; set; }            //TextBox

        [MaxLength(20)]
        [Display(Name = "Owner Contact Nos :")]
        public string AV_Owner_ConNo { get; set; }            //TextBox

        [MaxLength(50)]
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

        //[ValidateLargeFileCandidateUploadDocs]
        //public HttpPostedFileBase OtherProofDoc { get; set; }

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

        [MaxLength(200)]
        [Display(Name = "CompanyId No :")]
        public string ATA_CID_No { get; set; }                  //TextBox

        [MaxLength(200)]
        [Display(Name = "Company Address :")]
        public string ATA_Cmpny_Addr { get; set; }              //TextArea

        public short ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [MaxLength(200)]
        [Display(Name ="IF Reject : ")]
        public string RejectionReason { get; set; }

        public short MgrAllocatedBy { get; set; }
        public short MgrAllocatedTo { get; set; }
        public DateTime? MgrAllocatedDate { get; set; }

        [MaxLength(200)]
        [Display(Name ="Check Status : ")]
        public string CheckStatus { get; set; }

        [MaxLength(200)]
        [Display(Name = "Case Status : ")]
        public string CaseStatus { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

    }

    public class PQUpdateAddressManagerViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //public short TLAllocatedBy { get; set; }
        public short TLAllocatedTo { get; set; }
        public DateTime? TLAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }       

    }

    public class PQUpdateAddressTeamLeaderViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

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

    public class PQUpdateAddressTeamMemberViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //public short TMAllocatedTo { get; set; }
        //public DateTime? TMAllocatedDate { get; set; }

        //public string PTRMgrCheckStatus { get; set; }
        //public short PTRMgrAllocatedTo { get; set; }
        //public DateTime? PTRMgrAllocatedDate { get; set; }

        public string ActionRemark { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }
    }

    public class PQUpdateAddressStatusTeamMemberViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string PTRMgrCheckStatus { get; set; }
        public short PTRMgrAllocatedTo { get; set; }
        public DateTime? PTRMgrAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQUpdateAddressStatusPTRMgrViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string PTRTLCheckStatus { get; set; }
        public short PTRTLAllocatedTo { get; set; }
        public DateTime? PTRTLAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQUpdateAddressStatusPTRTLViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string PTRTMCheckStatus { get; set; }
        public short PTRTMAllocatedTo { get; set; }
        public DateTime? PTRTMAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class UpdateAddressRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int AddressRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public string INFRemarks { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQAntecedentList
    {
        public short AntecedentRowId { get; set; }
        public string AntecedentName  { get; set; }
        public string FieldName { get; set; }
        public byte AntecedentTypeRowId { get; set; }
       
    }

    public class PQAddressInsuffViewModel
    {
        public int AddressRowID { get; set; }

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

    public class UpdatePQAddressInsuffClearViewModel
    {
        public int AddressRowID { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string UniqueComponentID { get; set; }

        [Display(Name ="Check Status : ")]
        public string CheckStatus { get; set; }
        public string ReWorkCheckStatus { get; set; }
        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        //public short InfSuffRaiseBy { get; set; }
        //public DateTime? InfSuffRaisedDate { get; set; }
        public short InfSuffClearBy { get; set; }
        public DateTime? InfSuffClearDate { get; set; }
        
        [Display(Name ="Insuff Remarks : ")]
        public string INFRemarks { get; set; }

        //public IEnumerable<CheckActionHistoryViewModel> CheckActionHistories { get; set; }
    }

    public class PQAddressInsuffListPagedModel
    {
        public IEnumerable<PQAddressInsuffViewModel> PQAllInsuffAddresses { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }


    public class ViewAddressViewModel
    {
        [ScaffoldColumn(false)]
        [Required]
        public int AddressRowID { get; set; }
        
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

    public class PartnerDDLViewModel
    {
        [ScaffoldColumn(false)]
        public short PartnerRowId { get; set; }       
        public string PartnerName { get; set; }
    }
}
