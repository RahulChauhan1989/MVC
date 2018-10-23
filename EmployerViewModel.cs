using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels
{
    public class EmployerViewModel
    {
        [Display(Name = "ID")]
        public int EmployerRowID { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Legal Status")]
        public string CompanyLegalStatus { get; set; }

        [Display(Name = "Company Status")]
        public string CompanyStatus { get; set; }

        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }

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

        //[Display(Name = "Pincode")]
        //public int Pincode { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "CIN Number")]
        public string CINNumber { get; set; }

        [Display(Name = "Registered On MCA")]
        public string RegisteredOnMCA { get; set; }

        [Display(Name = "Paid Up Capital")]
        public double PaidUpCapital { get; set; }

        [Display(Name = "Mode Of Initiation")]
        public string ModeOfInitiation { get; set; }

        [Display(Name = "Special Instruction")]
        public string SpecialInstruction { get; set; }

        [Display(Name ="MandatoryDocument")]
        public string MandatoryDocument { get; set; }

        [Display(Name = "Additional Costing")]
        public string AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost")]
        public double AdditionalCost { get; set; }

        public string AdditionalCostYN { get; set; }

        [Display(Name = "Mode Of Payment")]
        public string ModeOfPayment { get; set; }

        [Display(Name = "Concern Person Name")]
        public string ConcernPersonName { get; set; }

        [Display(Name = "Designation of Concern Person")]
        public string DesigConcernPerson { get; set; }

        [Display(Name = "Official Landline No")]
        public string OfficialLandlineNo { get; set; }

        [Display(Name = "Official Email-Id")]
        public string OfficialEmailId { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }

        [Display(Name = "Additional Comments")]
        public string AdditionalComments { get; set; }

        [Display(Name = "PV Initiated")]
        public string PVInitiated { get; set; }

        [Display(Name = "PV Init At Address")]
        public string PVInitAtAddress { get; set; }

        [Display(Name = "Other DocumentNo")]
        public string OtherDocumentNo { get; set; }

        [Display(Name = "Other1")]
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

        //New Fields Add 8 Nov 2016
        [Display(Name = "Favour Of")]
        public string FavourOf { get; set; }

        [Display(Name = "Company Snapshot")]
        public string Snapshot { get; set; }

        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [Display(Name = "MCA RegProof")]
        public string MCARegProof { get; set; }

        [Display(Name = "PV Init Address Proof")]
        public string PVInitAtAddressProof { get; set; }

        [Display(Name = "Other Document Add")]
        public string OtherDocumentAdded { get; set; }

        [Display(Name = "Other Doc Proof")]
        public string OtherDocProof { get; set; }

        [Display(Name = "Other Status")]
        public string COtherStatus { get; set; }

        [Display(Name = "Other Legal Status")]
        public string COtherLegalStatus { get; set; }

        [Display(Name = "Other Initiation")]
        public string OtherInitiation { get; set; }

        [Display(Name = "Level-1 TAT")]
        public byte VerificationTATLevel1 { get; set; }

        [Display(Name = "Level-2 TAT")]
        public byte VerificationTATLevel2 { get; set; }

        [Display(Name = "AccountNumber")]
        public string AccountNumber { get; set; }

        [Display(Name = "IFSCCode")]
        public string IFSCCode { get; set; }

        [Display(Name = "Payable At")]
        public string PayableAT { get; set; }
    }

    public class AddEmployerViewModel
    {
        [Display(Name = "ID")]
        public int EmployerRowID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Company Name : ")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Company Legal Status : ")]
        public string CompanyLegalStatus { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Company Status : ")]
        public string CompanyStatus { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Company Address : ")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select District")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Please Select Location")]
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }

        [Display(Name = "Pin Code : ")]
        public int PinCode { get; set; }

        [Display(Name = "Website : ")]
        [MaxLength(100)]
        public string Website { get; set; }

        [Display(Name = "CIN Number : ")]
        [MaxLength(30)]
        public string CINNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "Registered On MCA : ")]
        public string RegisteredOnMCA { get; set; }

        [Display(Name = "Paid Up Capital : ")]
        public double PaidUpCapital { get; set; }

        [MaxLength(50)]
        [Display(Name = "Mode Of Initiation : ")]
        public string ModeOfInitiation { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instruction : ")]
        public string SpecialInstruction { get; set; }

        [MaxLength(500)]
        [Display(Name = "MandatoryDocument : ")]
        public string MandatoryDocument { get; set; }

        [MaxLength(3)]
        [Display(Name = "Additional Costing : ")]
        public string AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost : ")]
        public double AdditionalCost { get; set; }

        [MaxLength(20)]
        [Display(Name = "Mode Of Payment : ")]
        public string ModeOfPayment { get; set; }

        [MaxLength(100)]
        [Display(Name = "Concern Person Name : ")]
        public string ConcernPersonName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation : ")]
        public string DesigConcernPerson { get; set; }

        [Display(Name = "Official Landline No : ")]
        [MaxLength(100)]
        public string OfficialLandlineNo { get; set; }

        [Display(Name = "Official Email-Id : ")]
        [MaxLength(250)]
        public string OfficialEmailId { get; set; }

        [Display(Name = "Mobile Number : ")]
        [MaxLength(100)]
        public string MobileNo { get; set; }

        [MaxLength(500)]
        [Display(Name = "Additional Comments : ")]
        public string AdditionalComments { get; set; }

        [MaxLength(3)]
        [Display(Name = "PV Initiated : ")]
        public string PVInitiated { get; set; }

        [MaxLength(200)]
        [Display(Name = "PV Initiated At Address : ")]
        public string PVInitAtAddress { get; set; }

        [MaxLength(100)]
        [Display(Name = "Other DocumentNo : ")]
        public string OtherDocumentNo { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other1 : ")]
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

        [MaxLength(250)]
        [Display(Name = "Company Snapshot : ")]
        public string Snapshot { get; set; }

        [Display(Name = "Company Snapshot : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public IEnumerable<HttpPostedFileBase> PostedImage { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [MaxLength(250)]
        [Display(Name = "MCA Reg Snapshot : ")]
        public string MCARegProof { get; set; }

        [Display(Name = "MCA Reg Snapshot : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase MCARegProofImage { get; set; }

        [MaxLength(250)]
        [Display(Name = "Address Snapshot : ")]
        public string PVInitAtAddressProof { get; set; }

        [Display(Name = "Address Snapshot : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase InitAddProofImage { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Document Add : ")]
        public string OtherDocumentAdded { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Doc Snapshot : ")]
        public string OtherDocProof { get; set; }

        [Display(Name = "Other Doc Snapshot : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase OtherDocProofImage { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Status : ")]
        public string COtherStatus { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Legal Status : ")]
        public string COtherLegalStatus { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Initiation : ")]
        public string OtherInitiation { get; set; }

        [Display(Name = "Level-1 TAT : ")]
        public byte VerificationTATLevel1 { get; set; }

        [Display(Name = "Level-2 TAT : ")]
        public byte VerificationTATLevel2 { get; set; }

        [MaxLength(20)]
        [Display(Name = "Account Number : ")]
        public string AccountNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "IFSC Code : ")]
        public string IFSCCode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Payable At : ")]
        public string PayableAT { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }
    }

    public class UpdateEmployerViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int EmployerRowID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Company Name : ")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Company Legal Status : ")]
        public string CompanyLegalStatus { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Company Status : ")]
        public string CompanyStatus { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Company Address : ")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select District")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Please Select Location")]
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }

        [Display(Name = "Pin Code : ")]
        public int PinCode { get; set; }

        [Display(Name = "Website : ")]
        [MaxLength(100)]
        public string Website { get; set; }

        [Display(Name = "CIN Number : ")]
        [MaxLength(30)]
        public string CINNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "Registered On MCA : ")]
        public string RegisteredOnMCA { get; set; }

        [Display(Name = "Paid Up Capital : ")]
        public double PaidUpCapital { get; set; }

        [MaxLength(50)]
        [Display(Name = "Mode Of Initiation : ")]
        public string ModeOfInitiation { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instruction : ")]
        public string SpecialInstruction { get; set; }

        [MaxLength(500)]
        [Display(Name = "MandatoryDocument : ")]
        public string MandatoryDocument { get; set; }

        [MaxLength(3)]
        [Display(Name = "Additional Costing : ")]
        public string AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost : ")]
        public double AdditionalCost { get; set; }

        [MaxLength(20)]
        [Display(Name = "Mode Of Payment : ")]
        public string ModeOfPayment { get; set; }

        [MaxLength(100)]
        [Display(Name = "Concern Person Name : ")]
        public string ConcernPersonName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation of Concern Person : ")]
        public string DesigConcernPerson { get; set; }

        [Display(Name = "Official Landline No : ")]
        [MaxLength(100)]
        public string OfficialLandlineNo { get; set; }

        [Display(Name = "Official Email-Id : ")]
        [MaxLength(250)]
        public string OfficialEmailId { get; set; }

        [Display(Name = "Mobile Number : ")]
        [MaxLength(100)]
        [RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNo { get; set; }

        [MaxLength(500)]
        [Display(Name = "Additional Comments : ")]
        public string AdditionalComments { get; set; }

        [MaxLength(3)]
        [Display(Name = "PV Initiated : ")]
        public string PVInitiated { get; set; }

        [MaxLength(200)]
        [Display(Name = "PV Initiated At Address : ")]
        public string PVInitAtAddress { get; set; }

        [MaxLength(100)]
        [Display(Name = "Other DocumentNo : ")]
        public string OtherDocumentNo { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other1 : ")]
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

        [MaxLength(250)]
        [Display(Name = "Company Snapshot : ")]
        public string Snapshot { get; set; }

        [Display(Name = "Company Snapshot : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public IEnumerable<HttpPostedFileBase> PostedImage { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [MaxLength(250)]
        [Display(Name = "MCA RegProof : ")]
        public string MCARegProof { get; set; }

        [Display(Name = "MCA RegProof : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase MCARegProofImage { get; set; }

        [MaxLength(250)]
        [Display(Name = "PV Init Address Proof : ")]
        public string PVInitAtAddressProof { get; set; }

        [Display(Name = "PV Init Address Proof : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase InitAddProofImage { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Document Add : ")]
        public string OtherDocumentAdded { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Doc Proof : ")]
        public string OtherDocProof { get; set; }

        [Display(Name = "Other Doc Proof : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase OtherDocProofImage { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Status : ")]
        public string COtherStatus { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Legal Status : ")]
        public string COtherLegalStatus { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Initiation : ")]
        public string OtherInitiation { get; set; }

        [Display(Name = "Level-1 TAT : ")]
        public byte VerificationTATLevel1 { get; set; }

        [Display(Name = "Level-2 TAT : ")]
        public byte VerificationTATLevel2 { get; set; }

        [MaxLength(20)]
        [Display(Name = "Account Number : ")]
        public string AccountNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "IFSC Code : ")]
        public string IFSCCode { get; set; }

        [MaxLength(50)]
        [Display(Name = "Payable At : ")]
        public string PayableAT { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }
    }

    public class EmployerExportViewModel
    {        
        public int RowID { get; set; }
        
        public string Name { get; set; }
       
        public string LegalStatus { get; set; }
       
        public string Status { get; set; }
     
        public string Address { get; set; }
       
        public string Country { get; set; }
       
        public string State { get; set; }
        
        public string District { get; set; }
      
        public string Location { get; set; }
       
        public string Website { get; set; }
      
        public string CINNumber { get; set; }
       
        public string RegisteredOnMCA { get; set; }
      
        public double PaidUpCapital { get; set; }

        public string ModeOfInitiation { get; set; }
        
        public string SpecialInstruction { get; set; }
      
        public string MandatoryDocument { get; set; }
        
        public string AdditionalCosting { get; set; }
       
        public double AdditionalCost { get; set; }
        
        public string ModeOfPayment { get; set; }
        
        public string ConcernPersonName { get; set; }
       
        public string DesigConcernPerson { get; set; }
        
        public string OfficialLandlineNo { get; set; }
       
        public string OfficialEmailId { get; set; }
        
        public string MobileNo { get; set; }
       
        public string AdditionalComments { get; set; }
        
        public string PVInitiated { get; set; }
       
        public string PVInitAtAddress { get; set; }
    
        public string OtherDocumentNo { get; set; }
     
        public string Other1 { get; set; }
       
        public string Other2 { get; set; }
       
        public string Other3 { get; set; }
     
        public string Other4 { get; set; }
     
        public string Other5 { get; set; }       
       
        public string FavourOf { get; set; }
        
        public string Snapshot { get; set; }
      
        public string OtherDocumentDetail { get; set; }
       
        public string MCARegProof { get; set; }
      
        public string PVInitAtAddressProof { get; set; }
       
        public string OtherDocumentAdded { get; set; }
       
        public string OtherDocProof { get; set; }
       
        public string COtherStatus { get; set; }
       
        public string COtherLegalStatus { get; set; }
      
        public string OtherInitiation { get; set; }
     
        public byte VerificationTATLevel1 { get; set; }
       
        public byte VerificationTATLevel2 { get; set; }
       
        public string AccountNumber { get; set; }
      
        public string IFSCCode { get; set; }
       
        public string PayableAT { get; set; }
    }

    public class AddEmployerListViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int EmployerRowID { get; set; }
        
        public string CompanyName { get; set; }        
      
        public string CompanyStatus { get; set; }
     
        public string ConcernPersonName { get; set; }
        
        public string OfficialEmailId { get; set; }

        public string OfficialLandlineNo { get; set; }

        public string MobileNo { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status : ")]
        public byte? Status { get; set; }        
    }

    public class EmployerListPagedModel
    {
        public IEnumerable<AddEmployerListViewModel> Employers { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
