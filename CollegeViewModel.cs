using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels
{
    public class CollegeViewModel
    {
        [Display(Name = "ID")]
        public int CollegeRowID { get; set; }

        [Display(Name = "Institution/Collage Name")]
        public string CollegeName { get; set; }

        [Display(Name = "University Name")]
        public short UniversityRowID { get; set; }
        public string UniversityName { get; set; }

        [Display(Name = "College Status")]
        public string CollegeStatus { get; set; }

        [Display(Name = "Affiliated From")]
        public string AffliatiatedFrom { get; set; }

        [Display(Name = "Address of the Institution")]
        public string CollegeAddress { get; set; }

        [Display(Name = "Country ")]
        public short CountryRowID { get; set; }
        public string CountryName { get; set; }

        [Display(Name = "State ")]
        public short StateRowID { get; set; }

        public string StateName { get; set; }

        [Display(Name = "District ")]
        public short DistrictRowID { get; set; }
        public string DistrictName { get; set; }

        [Display(Name = "Location ")]
        public int LocationRowID { get; set; }
        public string LocationName { get; set; }

        //[Display(Name = "Pincode")]
        //public int Pincode { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "Mode Of Initiation")]
        public string ModeOfInitiation { get; set; }

        [Display(Name = "Special Instruction")]
        public string SpecialInstruction { get; set; }

        [Display(Name = "Degree Certificate")]
        public byte DegreeCertificate { get; set; }

        [Display(Name = "Location ")]
        public byte ProvisionalCertificate { get; set; }

        [Display(Name = "Final Year MarksSheet")]
        public byte FinalYearMarksSheet { get; set; }

        [Display(Name = "Passing Certificate")]
        public byte PassingCertificate { get; set; }

        [Display(Name = "Others")]
        public byte OtherDocument { get; set; }

              [Display(Name = "Additional Costing")]
        public string AdditionalCosting { get; set; }

        [Display(Name = "Additional Cost")]
        public double AdditionalCost { get; set; }

        public string AdditionalCostYN { get; set; }

        [Display(Name = "Mode Of Payment")]
        public string ModeOfPayment { get; set; }

        [Display(Name = "Concern Person Name")]
        public string ConcernPersonName { get; set; }

        [Display(Name = "Designation")]
        public string DesigConcernPerson { get; set; }

        [Display(Name = "Official Landline No")]
        public string OfficialLandlineNo { get; set; }

        [Display(Name = "Official Email-Id")]
        public string OfficialEmailId { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }

        [Display(Name = "Additional Comments")]
        public string AdditionalComments { get; set; }

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

        [Display(Name = "Snapshot")]
        public string Snapshot { get; set; }

        [Display(Name = "Other Documents")]
        public string OtherDocumentDetail { get; set; }

        [Display(Name = "ResultLink")]
        public string ResultLink { get; set; }

        [Display(Name = "Other Status")]
        public string OtherStatus { get; set; }

        [Display(Name = "Other Affliatiated")]
        public string OtherAffliatiated { get; set; }

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

        [Display(Name = "Payable AT")]
        public string PayableAT { get; set; }

    }
    public class AddCollegeViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int CollegeRowID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Institution/Collage Name : ")]
        public string CollegeName { get; set; }

        [Required]
        [Display(Name = "University Name : ")]
        public short UniversityRowID { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Status : ")]
        public string CollegeStatus { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Affiliated From : ")]
        public string AffliatiatedFrom { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Address of the Institution : ")]
        public string CollegeAddress { get; set; }

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

        [MaxLength(100)]
        [Display(Name = "Website : ")]
        public string Website { get; set; }

        [MaxLength(50)]
        [Display(Name = "Mode Of Initiation : ")]
        public string ModeOfInitiation { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instruction : ")]
        public string SpecialInstruction { get; set; }

        [Display(Name = "Degree")]
        public bool DegreeCertificate { get; set; }

        [Display(Name = "Provisional")]
        public bool ProvisionalCertificate { get; set; }

        [Display(Name = "Final Year MarksSheet")]
        public bool FinalYearMarksSheet { get; set; }

        [Display(Name = "Passing Certificate")]
        public bool PassingCertificate { get; set; }

        [Display(Name = "Other Document")]
        public bool OtherDocument { get; set; }

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
        [Display(Name = "Favour Of")]
        public string FavourOf { get; set; }

        [MaxLength(250)]
        [Display(Name = "Snapshot : ")]
        public string Snapshot { get; set; }

        [Display(Name = "Snapshot : ")]
        [ValidateImageFileWithNullCheckAttribute]
        // public HttpPostedFileBase PostedImage { get; set; }

        public IEnumerable<HttpPostedFileBase> PostedImage { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Document : ")]
        public string OtherDocumentDetail { get; set; }

        [MaxLength(100)]
        [Display(Name = "ResultLink : ")]
        public string ResultLink { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Status : ")]
        public string OtherStatus { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Affliatiated : ")]
        public string OtherAffliatiated { get; set; }

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
    public class UpdateCollegeViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public int CollegeRowID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Institution/Collage Name : ")]
        public string CollegeName { get; set; }

        [Required]
        [Display(Name = "University Name : ")]
        public short UniversityRowID { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "College Status : ")]
        public string CollegeStatus { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Affiliated From : ")]
        public string AffliatiatedFrom { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Address of the Institution : ")]
        public string CollegeAddress { get; set; }

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

        [MaxLength(100)]
        [Display(Name = "Website : ")]
        public string Website { get; set; }

        [MaxLength(50)]
        [Display(Name = "Mode Of Initiation : ")]
        public string ModeOfInitiation { get; set; }

        [MaxLength(500)]
        [Display(Name = "Special Instruction : ")]
        public string SpecialInstruction { get; set; }

        [Display(Name = "Degree")]
        public bool DegreeCertificate { get; set; }

        [Display(Name = "Provisional")]
        public bool ProvisionalCertificate { get; set; }

        [Display(Name = "Final Year MarksSheet")]
        public bool FinalYearMarksSheet { get; set; }

        [Display(Name = "Passing Certificate")]
        public bool PassingCertificate { get; set; }

        [Display(Name = "Other Document")]
        public bool OtherDocument { get; set; }

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
        [Display(Name = "Favour Of")]
        public string FavourOf { get; set; }

        [MaxLength(250)]
        [Display(Name = "Snapshot : ")]
        public string Snapshot { get; set; }

        [Display(Name = "Snapshot : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public IEnumerable<HttpPostedFileBase> PostedImage { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Document : ")]
        public string OtherDocumentDetail { get; set; }

        [MaxLength(100)]
        [Display(Name = "ResultLink : ")]
        public string ResultLink { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Status : ")]
        public string OtherStatus { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Affliatiated : ")]
        public string OtherAffliatiated { get; set; }

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
        [Display(Name = "Payable AT : ")]
        public string PayableAT { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }
    }

    public class CollegeExportViewModel
    {
       public int RowID { get; set; }

       public string College { get; set; }
        
        public string UniversityName { get; set; }
       
        public string Status { get; set; }
        
        public string AffliatiatedFrom { get; set; }
       
        public string Address { get; set; }
       
        public string CountryName { get; set; }

        public string StateName { get; set; }
       
        public string DistrictName { get; set; }

        public string CityName { get; set; }
       
        public string LocationName { get; set; }
        
        public string Website { get; set; }
        
        public string ModeOfInitiation { get; set; }
       
        public string SpecialInstruction { get; set; }
      
        public byte DegreeCertificate { get; set; }
     
        public byte ProvisionalCertificate { get; set; }
       
        public byte FinalYearMarksSheet { get; set; }
       
        public byte PassingCertificate { get; set; }
        
        public byte OtherDocument { get; set; }
      
        public string AdditionalCosting { get; set; }
        
        public double AdditionalCost { get; set; }
      
        public string ModeOfPayment { get; set; }
     
        public string ConcernPersonName { get; set; }

        public string DesigConcernPerson { get; set; }

        public string OfficialLandlineNo { get; set; }
               
        public string OfficialEmailId { get; set; }
        
        public string MobileNo { get; set; }
       
        public string AdditionalComments { get; set; }
        
        public string Other1 { get; set; }
       
        public string Other2 { get; set; }
       
        public string Other3 { get; set; }
       
        public string Other4 { get; set; }
     
        public string Other5 { get; set; }
       
        public string FavourOf { get; set; }
                
        public string Snapshot { get; set; }
        
        public string OtherDocumentDetail { get; set; }
       
        public string ResultLink { get; set; }
       
        public string OtherStatus { get; set; }
        
        public string OtherAffliatiated { get; set; }
   
        public string OtherInitiation { get; set; }
     
        public byte VerificationTATLevel1 { get; set; }
      
        public byte VerificationTATLevel2 { get; set; }

        public string AccountNumber { get; set; }
        
        public string IFSCCode { get; set; }
        
        public string PayableAT { get; set; }

    }

    public class CollegeListViewModel
    {
        [Display(Name = "ID")]
        public int CollegeRowID { get; set; }

        [Display(Name = "Institution/Collage Name")]
        public string CollegeName { get; set; }

        [Display(Name = "University Name")]
        public short UniversityRowID { get; set; }
        public string UniversityName { get; set; }

        [Display(Name = "College Status")]
        public string CollegeStatus { get; set; }

        [Display(Name = "Affiliated From")]
        public string AffliatiatedFrom { get; set; }        

        [Display(Name = "Concern Person Name")]
        public string ConcernPersonName { get; set; }
       
        
        [Display(Name = "Official Email-Id")]
        public string OfficialEmailId { get; set; }
       
        [ScaffoldColumn(false)]
        [Display(Name = "Status")]
        public byte? Status { get; set; }        

    }
    public class CollegeListPagedModel
    {
        public IEnumerable<CollegeListViewModel> Colleges { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    
}
