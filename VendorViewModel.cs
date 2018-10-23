using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels
{
    public class VendorViewModel
    {
        [Display(Name = "ID")]
        public short VendorRowID { get; set; }

        [Display(Name = "Name")]
        public string VendorName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Country Name")]
        public short CountryRowID { get; set; }
        public string CountryName { get; set; }

        [Display(Name = "State Name")]
        public short StateRowID { get; set; }
        public string StateName { get; set; }

        [Display(Name = "District Name")]
        public short DistrictRowID { get; set; }
        public string DistrictName { get; set; }

        [Display(Name = "Location Name")]
        public int LocationRowID { get; set; }
        public string LocationName { get; set; }

        [Display(Name = "Mode Of Initiation")]
        public string ModeOfInitiation { get; set; }

        [Display(Name = "Contact Person")]
        public string VendorContactPerson { get; set; }

        [Display(Name = "Email")]
        public string VendorEmaiID { get; set; }

        [Display(Name = "Mobile No")]
        public string VendorMobileNo { get; set; }

        [Display(Name = "Contact No")]
        public string VendorContactNo { get; set; }

        [Display(Name = "Spoc Name")]
        public string SPOCToName { get; set; }

        [Display(Name = "SPOC Email")]
        public string SPOCToEmailId { get; set; }

        [Display(Name = "SPOC Contact No")]
        public string SPOCToContactNo { get; set; }

        [Display(Name = "SPOC MobileNo")]
        public string SPOCToMobileNo { get; set; }

        [Display(Name = "Special Instruction")]
        public string SpecialInstruction { get; set; }

        [Display(Name = "Mandatory Document")]
        public string MandatoryDocument { get; set; }

        [Display(Name = "Mode Of Payment")]
        public string ModeOfPayment { get; set; }

        [Display(Name = "Remark")]
        public string Other1 { get; set; }

        [Display(Name = "Other2")]
        public string Other2 { get; set; }

        [Display(Name = "Other3")]
        public string Other3 { get; set; }

        [Display(Name = "Other4")]
        public string Other4 { get; set; }

        [Display(Name = "Other5")]
        public string Other5 { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte? Status { get; set; }

        //New Fields Add 9 Nov 2016
        [Display(Name = "Favour Of")]
        public string FavourOf { get; set; }

        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [Display(Name = "Other Initiation")]
        public string OtherInitiation { get; set; }

        [Display(Name = "AccountNumber")]
        public string AccountNumber { get; set; }

        [Display(Name = "IFSCCode")]
        public string IFSCCode { get; set; }

        [Display(Name = "Payable AT")]
        public string PayableAT { get; set; }

        [Display(Name = "Pin Code")]
        public int PinCode { get; set; }

        [Display(Name = "Agreement Docs")]
        public string AgreementDocs { get; set; }

        [Display(Name = "Empanelment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EmpanelmentDate { get; set; }

        [Display(Name = "Renewal Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalDate { get; set; }

        [Display(Name = "Audit Status")]
        public string AuditStatus { get; set; }

        [Display(Name = "Audit Status Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AuditStatusDate { get; set; }

        [Display(Name = "Pan No : ")]
        public string PanNo { get; set; }

        [Display(Name = "Pan No : ")]
        public string PanDoc { get; set; }

        [Display(Name = "ID Proof No : ")]
        public string IDProofNo { get; set; }

        [Display(Name = "ID Proof No : ")]
        public string IDProofDoc { get; set; }

        [Display(Name = "Service Tax Certificate No : ")]
        public string RegistrationCertificateNo { get; set; }

        [Display(Name = "Registration Certificate No : ")]
        public string RegistrationCertificateDoc { get; set; }

        [Display(Name = "Registration Certificate No : ")]
        public string ServiceTaxCertificateNo { get; set; }

        [Display(Name = "Registration Certificate : ")]
        public string ServiceTaxCertificateDoc { get; set; }

    }

    public class AddVendorViewModel
    {

        [Display(Name = "ID")]
        public short VendorRowID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Name : ")]
        public string VendorName { get; set; }

        [MaxLength(200)]
        [Display(Name = "Address : ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Select Country")]
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Select State")]
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Select District")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Select Location")]
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Mode Of Initiation : ")]
        public string ModeOfInitiation { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Contact Person : ")]
        public string VendorContactPerson { get; set; }

        [Display(Name = "Email : ")]
        [MaxLength(250)]
        public string VendorEmaiID { get; set; }

        [Display(Name = "MobileNo : ")]
        [MaxLength(100)]
        public string VendorMobileNo { get; set; }

        [MaxLength(100)]
        [Display(Name = "ContactNo : ")]
        public string VendorContactNo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Spoc Name : ")]
        public string SPOCToName { get; set; }

        [Display(Name = "SPOC Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string SPOCToEmailId { get; set; }

        [MaxLength(20)]
        [Display(Name = "SPOC Contact No : ")]
        public string SPOCToContactNo { get; set; }

        [Display(Name = "SPOC MobileNo : ")]
        [StringLength(20)]
        //[RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string SPOCToMobileNo { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instruction : ")]
        public string SpecialInstruction { get; set; }

        [MaxLength(20)]
        [Display(Name = "Mode Of Payment : ")]
        public string ModeOfPayment { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remark : ")]
        public string Other1 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other2 : ")]
        public string Other2 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other3 : ")]
        public string Other3 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other4 : ")]
        public string Other4 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other5 : ")]
        public string Other5 { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status : ")]
        public byte? Status { get; set; }

        //New Fields Add 8 Nov 2016
        [MaxLength(200)]
        [Display(Name = "Favour Of : ")]
        public string FavourOf { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Initiation : ")]
        public string OtherInitiation { get; set; }

        [MaxLength(20)]
        [Display(Name = "Account Number : ")]
        public string AccountNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "IFSC Code : ")]
        public string IFSCCode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Payable AT : ")]
        public string PayableAT { get; set; }

        [Display(Name = "Pin Code : ")]
        public int PinCode { get; set; }

        [MaxLength(250)]
        [Display(Name = "Agreement Docs : ")]
        public string AgreementDocs { get; set; }

        [Required]
        [Display(Name = "Agreement Docs : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase AgreementDocImage { get; set; }

        [Display(Name = "Empanelment Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EmpanelmentDate { get; set; }

        [Display(Name = "Renewal Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalDate { get; set; }

        [MaxLength(20)]
        [Display(Name = "Audit Status : ")]
        public string AuditStatus { get; set; }

        [Display(Name = "Audit Status Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AuditStatusDate { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Pan No : ")]
        public string PanNo { get; set; }

        [Display(Name = "Pan No : ")]
        public string PanDoc { get; set; }

        [Required]
        [Display(Name = "Pan No : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase PanDocImage { get; set; }

        [Required]
        [Display(Name = "ID Proof No : ")]
        public string IDProofNo { get; set; }

        [Display(Name = "ID Proof No : ")]
        public string IDProofDoc { get; set; }

        [Required]
        [Display(Name = "ID Proof : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase IDProofDocImage { get; set; }

        [Display(Name = "Service Tax Certificate No : ")]
        public string RegistrationCertificateNo { get; set; }

        [Display(Name = "Registration Certificate No : ")]
        public string RegistrationCertificateDoc { get; set; }

        [Display(Name = "Registration Certificate No : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase RegistrationCertificateDocImage { get; set; }

        [Display(Name = "Registration Certificate No : ")]
        public string ServiceTaxCertificateNo { get; set; }

        [Display(Name = "Registration Certificate : ")]
        public string ServiceTaxCertificateDoc { get; set; }

        [Display(Name = "Registration Certificate : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase ServiceTaxCertificateDocImage { get; set; }

        [Display(Name = "Other Document : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase OtherDocImage { get; set; }
    }

    public class UpdateVendorViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public short VendorRowID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Name : ")]
        public string VendorName { get; set; }

        [MaxLength(200)]
        [Display(Name = "Address : ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Select Country")]
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }

        [Display(Name = "Country : ")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Select State")]
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Display(Name = "State : ")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Select District")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }

        [Display(Name = "District : ")]
        public string DistrictName { get; set; }

        [Required(ErrorMessage = "Select Location")]
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }

        [Display(Name = "Location : ")]
        public string LocationName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Mode Of Initiation : ")]
        public string ModeOfInitiation { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Contact Person : ")]
        public string VendorContactPerson { get; set; }

        [Display(Name = "Email : ")]
        [MaxLength(250)]
        public string VendorEmaiID { get; set; }

        [Display(Name = "MobileNo : ")]
        [MaxLength(100)]
        public string VendorMobileNo { get; set; }

        [MaxLength(100)]
        [Display(Name = "ContactNo : ")]
        public string VendorContactNo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Spoc Name : ")]
        public string SPOCToName { get; set; }

        [Display(Name = "SPOC Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string SPOCToEmailId { get; set; }

        [MaxLength(20)]
        [Display(Name = "SPOC Contact No : ")]
        public string SPOCToContactNo { get; set; }

        [Display(Name = "SPOC MobileNo : ")]
        [StringLength(20)]
        //[RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string SPOCToMobileNo { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instruction : ")]
        public string SpecialInstruction { get; set; }

        [MaxLength(20)]
        [Display(Name = "Mode Of Payment : ")]
        public string ModeOfPayment { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remark : ")]
        public string Other1 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other2 : ")]
        public string Other2 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other3 : ")]
        public string Other3 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other4 : ")]
        public string Other4 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other5 : ")]
        public string Other5 { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status : ")]
        public byte? Status { get; set; }

        //New Fields Add 8 Nov 2016
        [MaxLength(200)]
        [Display(Name = "Favour Of : ")]
        public string FavourOf { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Initiation : ")]
        public string OtherInitiation { get; set; }

        [MaxLength(20)]
        [Display(Name = "Account Number : ")]
        public string AccountNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "IFSC Code : ")]
        public string IFSCCode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Payable At : ")]
        public string PayableAT { get; set; }

        [Display(Name = "Pin Code : ")]
        public int PinCode { get; set; }

        [MaxLength(250)]
        [Display(Name = "Agreement Docs : ")]
        public string AgreementDocs { get; set; }

        [Display(Name = "Agreement Docs : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase AgreementDocImage { get; set; }

        [Display(Name = "Empanelment Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EmpanelmentDate { get; set; }

        [Display(Name = "Renewal Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalDate { get; set; }

        [MaxLength(20)]
        [Display(Name = "Audit Status : ")]
        public string AuditStatus { get; set; }

        [Display(Name = "Audit Status Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AuditStatusDate { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "PAN No : ")]
        public string PanNo { get; set; }

        [Display(Name = "PAN No : ")]
        public string PanDoc { get; set; }

        [Display(Name = "PAN No : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase PanDocImage { get; set; }

        [Required]
        [Display(Name = "ID Proof No : ")]
        public string IDProofNo { get; set; }

        [Display(Name = "ID Proof No : ")]
        public string IDProofDoc { get; set; }

        [Display(Name = "ID Proof : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase IDProofDocImage { get; set; }

        [Display(Name = "Service Tax Certificate Docs : ")]
        public string RegistrationCertificateNo { get; set; }

        [Display(Name = "Registration Certificate No : ")]
        public string RegistrationCertificateDoc { get; set; }

        [Display(Name = "Registration Certificate No : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase RegistrationCertificateDocImage { get; set; }

        [Display(Name = "Registration Certificate No : ")]
        public string ServiceTaxCertificateNo { get; set; }

        [Display(Name = "Registration Certificate : ")]
        public string ServiceTaxCertificateDoc { get; set; }

        [Display(Name = "Registration Certificate : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase ServiceTaxCertificateDocImage { get; set; }

        [Display(Name = "Other Document : ")]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase OtherDocImage { get; set; }
    }

    public class VendorExportViewModel
    {

        public short RowID { get; set; }

        public string VendorName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string Location { get; set; }

        public string ModeOfInitiation { get; set; }

        public string VendorContactPerson { get; set; }

        public string VendorEmaiID { get; set; }

        public string VendorMobileNo { get; set; }

        public string VendorContactNo { get; set; }

        public string SPOCToName { get; set; }

        public string SPOCToEmailId { get; set; }

        public string SPOCToContactNo { get; set; }

        public string SPOCToMobileNo { get; set; }

        public string SpecialInstruction { get; set; }

        public string MandatoryDocument { get; set; }

        public string ModeOfPayment { get; set; }

        public string Other1 { get; set; }

        public string Other2 { get; set; }

        public string Other3 { get; set; }

        public string Other4 { get; set; }

        public string Other5 { get; set; }

        //New Fields Add 9 Nov 2016

        public string FavourOf { get; set; }

        public string OtherDocumentDetail { get; set; }

        public string OtherInitiation { get; set; }

        public string AccountNumber { get; set; }

        public string IFSCCode { get; set; }

        public string PayableAT { get; set; }

        public int PinCode { get; set; }

        public string AgreementDocs { get; set; }

        public DateTime? EmpanelmentDate { get; set; }

        public DateTime? RenewalDate { get; set; }

        public string AuditStatus { get; set; }

        public DateTime? AuditStatusDate { get; set; }

        public string PanNo { get; set; }

        public string PanDoc { get; set; }

        public string IDProofNo { get; set; }

        public string IDProofDoc { get; set; }

        public string RegistrationCertificateNo { get; set; }

        public string RegistrationCertificateDoc { get; set; }

        public string ServiceTaxCertificateNo { get; set; }

        public string ServiceTaxCertificateDoc { get; set; }

    }

    public class VendorListPagedModel
    {
        public IEnumerable<VendorViewModel> Vendors { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class VendorDDLViewModel
    {
        [Display(Name = "Vendor Name")]
        public short VendorRowID { get; set; }

        [Display(Name = "Name")]
        public string VendorName { get; set; }
    }
    public class VendorUserDDLViewModel
    {
        [Display(Name = "User Name")]
        public int VendorRowID { get; set; }

        [Display(Name = "Name")]
        public string VendorName { get; set; }
    }


}
