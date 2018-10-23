using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels.ProvidedInfoViewModel
{
    public class PQPersonalViewModel
    {
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        [Display(Name = "Client Ref ID : ")]
        public string ClientRefID { get; set; }

        [Display(Name = "Location : ")]
        public string Location { get; set; }

        [Display(Name = "Securitas ID : ")]
        public string CompanyRefNo { get; set; }

        [Display(Name = "Candidate Code : ")]
        public string CandidateCode { get; set; }

        [Required]
        [Display(Name = "Title : ")]
        public string CandTitle { get; set; }

        [Required]
        [Display(Name = "Name : ")]
        public string Name { get; set; }

        [Display(Name = "Middle Name : ")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        public string LastName { get; set; }

        [Display(Name = "Title : ")]
        public string FatherTitle { get; set; }

        [Display(Name = "father Name : ")]
        public string FatherName { get; set; }

        [Display(Name = "Middle Name : ")]
        public string FatherMiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        public string FatherLastName { get; set; }

        [Display(Name = "Gender : ")]
        public string Gender { get; set; }

        [Display(Name = "Date Of Birth : ")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Marital Status : ")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }

        [Display(Name = "Email : ")]
        public string EmailID { get; set; }

        [Display(Name = "Pan Card : ")]
        public byte PanCard { get; set; }

        [Display(Name = "Pan Card : ")]
        public string PanCardNo { get; set; }

        [Display(Name = "Passport : ")]
        public byte Passport { get; set; }

        [Display(Name = "Passport : ")]
        public string PassportNo { get; set; }

        [Display(Name = "Aadhaar Card : ")]
        public byte AadhaarCard { get; set; }

        [Display(Name = "Aadhaar Card : ")]
        public string AadhaarCardNo { get; set; }

        [Display(Name = "Driving License : ")]
        public byte DrivingLicense { get; set; }

        [Display(Name = "Driving License : ")]
        public string DrivingLicenseNo { get; set; }

        [Display(Name = "Voter ID Card : ")]
        public byte VoterIDCard { get; set; }

        [Display(Name = "Voter ID Card : ")]
        public string VoterIDCardNo { get; set; }

        [Display(Name = "Create By : ")]
        public short CreatedBy { get; set; }

        [Display(Name = "Create Date : ")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Allocated By : ")]
        public short AllocatedBy { get; set; }

        [Display(Name = "Allocated To DE : ")]
        public short AllocatedToDE { get; set; }

        [Display(Name = "Allocated To DE Date : ")]
        public DateTime? AllocatedToDEDate { get; set; }

        [Display(Name = "Allocated To DEQC : ")]
        public short AllocatedToDEQC { get; set; }

        [Display(Name = "Allocated To DEQC Date : ")]
        public DateTime? AllocatedToDEQCDate { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [Display(Name = "OtherDetails : ")]
        public string OtherDetails { get; set; }

        [Display(Name = "OtherDetails1 : ")]
        public string OtherDetails1 { get; set; }

        [Display(Name = "OtherDetails2 : ")]
        public string OtherDetails2 { get; set; }
    }

    public class AddPQPersonalViewModel
    {
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Required(ErrorMessage = "Select Client")]
        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        [Display(Name = "ID : ")]
        public int ClientUserRowID { get; set; }

        [Display(Name = "Client Ref ID : ")]
        [MaxLength(100)]
        public string ClientRefID { get; set; }

        [Display(Name = "Location : ")]
        public string Location { get; set; }

        [Display(Name = "Securitas ID : ")]
        [MaxLength(100)]
        public string CompanyRefNo { get; set; }

        [Required(ErrorMessage = "Enter candidate code")]
        [Display(Name = "Candidate Code : ")]
        [MaxLength(100)]
        public string CandidateCode { get; set; }

        [Required(ErrorMessage = "Select title")]
        [Display(Name = "Title : ")]
        [MaxLength(15)]
        public string CandTitle { get; set; }

        [Required(ErrorMessage = "Enter Candidate Name")]
        [Display(Name = "Name : ")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Middle Name : ")]
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Title : ")]
        [MaxLength(15)]
        public string FatherTitle { get; set; }

        [Display(Name = "father Name : ")]
        [MaxLength(50)]
        public string FatherName { get; set; }

        [Display(Name = "Middle Name : ")]
        [MaxLength(50)]
        public string FatherMiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        [MaxLength(50)]
        public string FatherLastName { get; set; }

        [Display(Name = "Gender : ")]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Display(Name = "Date Of Birth : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Marital Status : ")]
        [MaxLength(15)]
        public string MaritalStatus { get; set; }

        //[Required(ErrorMessage = "Enter mobile number")]
        [Display(Name = "Mobile No : ")]
        [StringLength(20)]
        [RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNo { get; set; }

        //[Required(ErrorMessage = "Enter Email id")]
        [Display(Name = "Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailID { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Case Type : ")]
        public string CaseType { get; set; }

        [Display(Name = "TAT : ")]
        public byte TAT { get; set; }

        [Display(Name = "Order Date : ")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Delivery Date : ")]
        public DateTime? DeliveryDate { get; set; }

        [Display(Name = "Is Back Date : ")]
        public bool IsBackdate { get; set; }

        [Display(Name = "How Many Back Days : ")]
        public byte HowManyBackDays { get; set; }

        [Display(Name = "Pan Card : ")]
        public byte PanCard { get; set; }

        [Display(Name = "Pan Card : ")]
        [RegularExpression(@"^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$", ErrorMessage = "Please enter valid Pan Card")]
        [MaxLength(10)]
        public string PanCardNo { get; set; }

        [Display(Name = "Passport : ")]
        public byte Passport { get; set; }

        [Display(Name = "Passport : ")]
        [MaxLength(100)]
        public string PassportNo { get; set; }

        [Display(Name = "Aadhaar Card : ")]
        public byte AadhaarCard { get; set; }

        [Display(Name = "Aadhaar Card : ")]
        [RegularExpression(@"^[2-9]{1}[0-9]{11}$", ErrorMessage = "Please enter valid Aadhaar Card")]
        [MaxLength(12)]
        public string AadhaarCardNo { get; set; }

        [Display(Name = "Driving License : ")]
        public byte DrivingLicense { get; set; }

        [Display(Name = "Driving License : ")]
        [MaxLength(100)]
        public string DrivingLicenseNo { get; set; }

        [Display(Name = "Voter ID Card : ")]
        public byte VoterIDCard { get; set; }

        [Display(Name = "Voter ID Card : ")]
        [MaxLength(100)]
        public string VoterIDCardNo { get; set; }

        [Display(Name = "CheckDateTime : ")]
        public DateTime? CheckDateTime { get; set; }

        [MaxLength(100)]
        [Display(Name = "EmployeeID : ")]
        public string EmployeeID { get; set; }

        [MaxLength(20)]
        [Display(Name = "From Type : ")]
        public string FromType { get; set; }

        [MaxLength(100)]
        [Display(Name = "Details Entered By : ")]
        public string DetailsEnteredBy { get; set; }            //Company/Client/Candidate

        [Display(Name = "Create By : ")]
        public short CreatedBy { get; set; }

        [Display(Name = "Create Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Allocated By : ")]
        public short AllocatedBy { get; set; }

        [Display(Name = "Allocated To DE : ")]
        public short AllocatedToDE { get; set; }

        [Display(Name = "Allocated To DE Date : ")]
        public DateTime? AllocatedToDEDate { get; set; }

        [Display(Name = "Allocated To DEQC : ")]
        public short AllocatedToDEQC { get; set; }

        [Display(Name = "Allocated To DEQC Date : ")]
        public DateTime? AllocatedToDEQCDate { get; set; }

        [Display(Name = "Case Status : ")]
        public string CaseStatus { get; set; }

        //[Display(Name = "Final Status : ")]
        //public byte FinalStatus { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase UploadDoc { get; set; }

        [MaxLength(100)]
        [Display(Name = "OtherDetails : ")]
        public string OtherDetails { get; set; }

        public string CandidateCheckOrPackage { get; set; }

        [Display(Name = "Previous Refernce Id : ")]
        public string OtherDetails1 { get; set; }

    }

    public class AddPQPersonalBulkImportViewModel
    {
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Required(ErrorMessage = "Select Client")]
        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        [Display(Name = "ID : ")]
        public int ClientUserRowID { get; set; }

        [Display(Name = "Client Ref ID : ")]
        [MaxLength(100)]
        public string ClientRefID { get; set; }

        [Display(Name = "Location : ")]
        public string Location { get; set; }

        [Display(Name = "Securitas ID : ")]
        [MaxLength(100)]
        public string CompanyRefNo { get; set; }

        [Required(ErrorMessage = "Enter candidate code")]
        [Display(Name = "Candidate Code : ")]
        [MaxLength(100)]
        public string CandidateCode { get; set; }

        [Required(ErrorMessage = "Select title")]
        [Display(Name = "Title : ")]
        [MaxLength(15)]
        public string CandTitle { get; set; }

        [Required(ErrorMessage = "Enter Candidate Name")]
        [Display(Name = "Name : ")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Middle Name : ")]
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Gender : ")]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Display(Name = "Date Of Birth : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Marital Status : ")]
        [MaxLength(15)]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Enter mobile number")]
        [Display(Name = "Mobile No : ")]
        [StringLength(20)]
        [RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Enter Email id")]
        [Display(Name = "Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailID { get; set; }

        public string EmployeeID { get; set; }

        public string CaseType { get; set; }

        [Required]
        public byte TAT { get; set; }

        public DateTime? OrderDate { get; set; }

        [Required]
        public DateTime? DeliveryDate { get; set; }

        [Display(Name = "Pan Card : ")]
        [RegularExpression(@"^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$", ErrorMessage = "Please enter valid Pan Card")]
        [MaxLength(10)]
        public string PanCardNo { get; set; }

        [Display(Name = "Passport : ")]
        [MaxLength(100)]
        public string PassportNo { get; set; }

        [Display(Name = "Aadhaar Card : ")]
        [RegularExpression(@"^[2-9]{1}[0-9]{11}$", ErrorMessage = "Please enter valid Aadhaar Card")]
        [MaxLength(12)]
        public string AadhaarCardNo { get; set; }

        [Display(Name = "Driving License : ")]
        [MaxLength(100)]
        public string DrivingLicenseNo { get; set; }

        [Display(Name = "Voter ID Card : ")]
        [MaxLength(100)]
        public string VoterIDCardNo { get; set; }

        [MaxLength(20)]
        [Display(Name = "From Type : ")]
        public string FromType { get; set; }

        [MaxLength(100)]
        [Display(Name = "Details Entered By : ")]
        public string DetailsEnteredBy { get; set; }            //Company/Client/Candidate

        [Display(Name = "Create By : ")]
        public short CreatedBy { get; set; }

        [Display(Name = "Create Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Case Status : ")]
        public string CaseStatus { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase UploadDoc { get; set; }

        [Display(Name = "Template : ")]
        public string Template { get; set; }

        [MaxLength(100)]
        [Display(Name = "OtherDetails : ")]
        public string OtherDetails { get; set; }

        public string CandidateCheckOrPackage { get; set; }
    }

    public class UpdatePQPersonalViewModel
    {
        [Required]
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        [Display(Name = "ID : ")]
        public int ClientUserRowID { get; set; }

        [Display(Name = "ID : ")]
        public int CandidateUserID { get; set; }

        [Display(Name = "Client Ref ID : ")]
        [MaxLength(100)]
        public string ClientRefID { get; set; }

        [Display(Name = "Location : ")]
        public string Location { get; set; }

        [Display(Name = "Securitas ID : ")]
        [MaxLength(100)]
        public string CompanyRefNo { get; set; }

        [Display(Name = "Candidate Code : ")]
        [MaxLength(100)]
        public string CandidateCode { get; set; }

        [Display(Name = "Title : ")]
        [MaxLength(15)]
        public string CandTitle { get; set; }

        [Required]
        [Display(Name = "Name : ")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Middle Name : ")]
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Title : ")]
        [MaxLength(15)]
        public string FatherTitle { get; set; }

        [Display(Name = "father Name : ")]
        [MaxLength(50)]
        public string FatherName { get; set; }

        [Display(Name = "Middle Name : ")]
        [MaxLength(50)]
        public string FatherMiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        [MaxLength(50)]
        public string FatherLastName { get; set; }

        [Display(Name = "Gender : ")]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Display(Name = "Date Of Birth : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Marital Status : ")]
        [MaxLength(15)]
        public string MaritalStatus { get; set; }
        
        [Display(Name = "Mobile No : ")]
        [StringLength(20)]
        [RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNo { get; set; }

        [Display(Name = "Alternate No : ")]
        public string AlternateNo { get; set; }
        
        [Display(Name = "Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailID { get; set; }

        [MaxLength(100)]
        [Display(Name = "Alternate Email : ")]
        public string AlternateEmailID { get; set; }

        [MaxLength(10)]
        [Display(Name = "STD : ")]
        public string STD { get; set; }

        [MaxLength(20)]
        [Display(Name = "STD Residence Phone No : ")]
        public string ResidencePhoneNo { get; set; }

        [Display(Name = "Pan Card : ")]
        public byte PanCard { get; set; }

        [Display(Name = "Pan Card : ")]
        [MaxLength(100)]
        public string PanCardNo { get; set; }

        [Display(Name = "Passport : ")]
        public byte Passport { get; set; }

        [Display(Name = "Passport : ")]
        [MaxLength(100)]
        public string PassportNo { get; set; }

        [Display(Name = "Aadhaar Card : ")]
        public byte AadhaarCard { get; set; }

        [Display(Name = "Aadhaar Card : ")]
        [MaxLength(100)]
        public string AadhaarCardNo { get; set; }

        [Display(Name = "Driving License : ")]
        public byte DrivingLicense { get; set; }

        [Display(Name = "Driving License : ")]
        [MaxLength(100)]
        public string DrivingLicenseNo { get; set; }

        [Display(Name = "Voter ID Card : ")]
        public byte VoterIDCard { get; set; }

        [Display(Name = "Voter ID Card : ")]
        [MaxLength(100)]
        public string VoterIDCardNo { get; set; }

        [Display(Name = "CheckDateTime : ")]
        public DateTime? CheckDateTime { get; set; }

        [MaxLength(50)]
        [Display(Name = "Candidate Type : ")]
        public string CandidateType { get; set; }

        [MaxLength(50)]
        [Display(Name = "Category : ")]
        public string Catagory { get; set; }

        //[Required]
        [MaxLength(50)]
        [Display(Name = "Case Type : ")]
        public string CaseType { get; set; }

        [Display(Name = "TAT : ")]
        public byte TAT { get; set; }

        [MaxLength(50)]
        [Display(Name = "Nationality : ")]
        public string Nationality { get; set; }

        [MaxLength(100)]
        [Display(Name = "EmployeeID : ")]
        public string EmployeeID { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation : ")]
        public string Designation { get; set; }

        [MaxLength(100)]
        [Display(Name = "Place of Joining : ")]
        public string PlaceofJoining { get; set; }

        [Display(Name = "Date of Joining : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateofJoining { get; set; }

        [MaxLength(100)]
        [Display(Name = "National Skills : ")]
        public string NationalSkills { get; set; }

        [MaxLength(50)]
        [Display(Name = "SSN No : ")]
        public string SSNNo { get; set; }

        [MaxLength(20)]
        [Display(Name = "From Type : ")]
        public string FromType { get; set; }

        [MaxLength(100)]
        [Display(Name = "Details Entered By : ")]
        public string DetailsEnteredBy { get; set; }            //Company/Client/Candidate

        [MaxLength(70)]
        [Display(Name = "Process Name : ")]
        public string ProcessName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Business Name : ")]
        public string BusinessName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Type : ")]
        public string Type { get; set; }

        [MaxLength(50)]
        [Display(Name = "Spouse Name : ")]
        public string SpouseName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Spouse Middle Name : ")]
        public string SpouseMiddleName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Spouse Last Name : ")]
        public string SpouseLastName { get; set; }

        [Display(Name = "Order Date : ")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Delivery Date : ")]
        public DateTime? DeliveryDate { get; set; }

        [Display(Name = "Create By : ")]
        public short CreatedBy { get; set; }

        [Display(Name = "Create Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Allocated By : ")]
        public short AllocatedBy { get; set; }

        [Display(Name = "Allocated To DE : ")]
        public short AllocatedToDE { get; set; }

        [Display(Name = "Allocated To DE Date : ")]
        public DateTime? AllocatedToDEDate { get; set; }

        [Display(Name = "Allocated To DEQC : ")]
        public short AllocatedToDEQC { get; set; }

        [Display(Name = "DEQC Date : ")]
        public DateTime? AllocatedToDEQCDate { get; set; }

        [Display(Name = "DE-Scan : ")]
        public short AllocatedToDEScan { get; set; }

        [Display(Name = "DE-Scan Date : ")]
        public DateTime? AllocatedToDEScanDate { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remark : ")]
        public string Remark { get; set; }

        [MaxLength(50)]
        [Display(Name = "Final Color : ")]
        public string FinalColor { get; set; }

        [Display(Name = "ExitIntrvwApplicable : ")]
        public byte ExitIntrvwApplicable { get; set; }        // yes=1/No=0

        [Display(Name = "Case Status : ")]
        public string CaseStatus { get; set; }

        [Display(Name = "Final Status : ")]
        public string FinalStatus { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [MaxLength(100)]
        [Display(Name = "OtherDetails : ")]
        public string OtherDetails { get; set; }

        [MaxLength(100)]
        [Display(Name = "OtherDetails1 : ")]
        public string OtherDetails1 { get; set; }

        [MaxLength(100)]
        [Display(Name = "OtherDetails2 : ")]
        public string OtherDetails2 { get; set; }
    }

    public class PQPersonalDetailViewModel
    {
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        [Display(Name = "Client Ref ID : ")]
        public string ClientRefID { get; set; }

        [Display(Name = "Securitas ID : ")]
        public string CompanyRefNo { get; set; }

        [Display(Name = "Candidate Code : ")]
        public string CandidateCode { get; set; }

        [Required]
        [Display(Name = "Title : ")]
        public string CandTitle { get; set; }

        [Required]
        [Display(Name = "Name : ")]
        public string Name { get; set; }

        [Display(Name = "Middle Name : ")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        public string LastName { get; set; }

        [Display(Name = "Details Entered By : ")]
        public string DetailsEnteredBy { get; set; }            //Company/Client/Candidate


        [Display(Name = "Create By : ")]
        public short CreatedBy { get; set; }

        [Display(Name = "Create Date : ")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Allocated By : ")]
        public short AllocatedBy { get; set; }

        [Display(Name = "Allocated To DE : ")]
        public short AllocatedToDE { get; set; }
        public string AllocatedToDEName { get; set; }

        [Display(Name = "Allocated To DE Date : ")]
        public DateTime? AllocatedToDEDate { get; set; }

        [Display(Name = "Allocated To DEQC : ")]
        public short AllocatedToDEQC { get; set; }
        public string AllocatedToDEQCName { get; set; }

        [Display(Name = "Allocated To DE-Scan : ")]
        public short AllocatedToDEScan { get; set; }
        public string AllocatedToDEScanName { get; set; }

        [Display(Name = "Allocated Date : ")]
        public DateTime? AllocatedToDEScanDate { get; set; }

        [Display(Name = "Allocated To DEQC Date : ")]
        public DateTime? AllocatedToDEQCDate { get; set; }

        public string CaseStatus { get; set; }

        public string FineStatus { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [Display(Name = "OtherDetails : ")]
        public string OtherDetails { get; set; }

        [Display(Name = "OtherDetails1 : ")]
        public string OtherDetails1 { get; set; }

        [Display(Name = "OtherDetails2 : ")]
        public string OtherDetails2 { get; set; }

        public string DEScanCaseStatus { get; set; }
        public string DECaseStatus { get; set; }
        public string DEQCCaseStatus { get; set; }
    }

    public class PQPersonalInfoListPagedModel
    {
        public IEnumerable<PQPersonalDetailViewModel> PQPersonalInfo { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class PQAllChecksCountViewModel
    {
        public int AddressCount { get; set; }
        public int EmploymentCount { get; set; }
        public int EducationCount { get; set; }
        public int CriminalCount { get; set; }
        public int NatIdentityCount { get; set; }
        public int ReferenceCount { get; set; }
        public int SpecialcheckCount { get; set; }

    }

    public class PQPersonalSessionViewModel
    {
        public int PersonalRowID { get; set; }
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public string ClientRefID { get; set; }
        public string CandidateCode { get; set; }
        public string CompanyRefNo { get; set; }
        public string CandTitle { get; set; }

        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FatherMiddleName { get; set; }
        public string FatherLastName { get; set; }
        public string SpouseName { get; set; }
        public string SpouseMiddleName { get; set; }
        public string SpouseLastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string PanCardNo { get; set; }
        public string PassportNo { get; set; }
        public string AadhaarCardNo { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string VoterIDCardNo { get; set; }
    }

    public class TempPQPersonalSessionViewModel
    {
        public int PersonalRowID { get; set; }
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public string ClientRefID { get; set; }
        public string CandidateCode { get; set; }
        public string CompanyRefNo { get; set; }
        public string CandTitle { get; set; }

        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FatherMiddleName { get; set; }
        public string FatherLastName { get; set; }
        public string SpouseName { get; set; }
        public string SpouseMiddleName { get; set; }
        public string SpouseLastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string PanCardNo { get; set; }
        public string PassportNo { get; set; }
        public string AadhaarCardNo { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string VoterIDCardNo { get; set; }
    }

    public class PQPersonalForSendMailViewModel
    {
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        [Display(Name = "ID : ")]
        public int ClientUserRowID { get; set; }

        [Display(Name = "ID : ")]
        public int CandidateUserID { get; set; }

        [Display(Name = "Client Ref ID : ")]
        public string ClientRefID { get; set; }

        [Display(Name = "Company Ref No : ")]
        public string CompanyRefNo { get; set; }

        [Display(Name = "Candidate Code : ")]
        public string CandidateCode { get; set; }

        [Required]
        [Display(Name = "Title : ")]
        public string CandTitle { get; set; }

        [Required]
        [Display(Name = "Name : ")]
        public string Name { get; set; }

        [Display(Name = "Middle Name : ")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name : ")]
        public string LastName { get; set; }

        [Display(Name = "Gender : ")]
        public string Gender { get; set; }

        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }

        [Display(Name = "Email : ")]
        public string EmailID { get; set; }

        [Display(Name = "OtherDetails1 : ")]
        public string OtherDetails2 { get; set; }
    }

    public class PQPersonalOrCheckForSendMailViewModel
    {
        public int PersonalRowID { get; set; }
        
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }

        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        public DateTime? InternalTAT { get; set; }

        public string ClientRefID { get; set; }        
        public string CompanyRefNo { get; set; }        
        public string CandidateCode { get; set; }  
        public string CandidateName { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }


        public string ClientEmailID { get; set; }
        public string SpocEmailID { get; set; }
        public string Remarks { get; set; }
        public string InsuffRemarks { get; set; }
    }

    public class PQPersonalCheckListForClientViewModel
    {
        public int PersonalRowID { get; set; }

        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }

        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }
               
        public string CompanyRefNo { get; set; }
        public string CandidateCode { get; set; }
        public string CandidateName { get; set; }
    }

    public class ExportPQPersonalDetailViewModel
    {
        public int PersonalRowID { get; set; }        
        public string CandidateName  { get; set; }
        public string CandidateCode { get; set; }
        public string SecuritasID { get; set; }          
        public string DetailsEnteredBy { get; set; }            //Company/Client/Candidate        
        public string CaseStatus { get; set; }
    }

    public class ExportPQPersonalCandidateViewModel
    {
        public int PersonalRowID { get; set; }
        public string ClientName { get; set; }
        public string CandidateName { get; set; }
        public string CandidateCode { get; set; }       
        public string CompanyRefNo { get; set; }           
        public string CaseStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}