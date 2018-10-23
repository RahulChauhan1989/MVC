using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels.TempViewModel
{
    public class TempPQPersonalViewModel
    {
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }

        //[Display(Name = "ID : ")]
        //public int ClientUserRowID { get; set; }

        //[Display(Name = "ID : ")]
        //public int CandidateUserID { get; set; }

        [Display(Name = "Client Ref ID : ")]
        public string ClientRefID { get; set; }

        [Display(Name = "Location : ")]
        public string Location { get; set; }

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

        //[Display(Name = "Alternate No : ")]
        //public string AlternateNo { get; set; }

        [Display(Name = "Email : ")]
        public string EmailID { get; set; }

        //[Display(Name = "Alternate Email : ")]
        //public string AlternateEmailID { get; set; }

        //[Display(Name = "STD : ")]
        //public string STD { get; set; }

        //[Display(Name = "Residence Phone No : ")]
        //public string ResidencePhoneNo { get; set; }

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

        //[Display(Name = "CheckDateTime : ")]
        //public DateTime? CheckDateTime { get; set; }

        //[Display(Name = "Candidate Type : ")]
        //public string CandidateType { get; set; }

        //[Display(Name = "Catagory : ")]
        //public string Catagory { get; set; }

        //[Display(Name = "CaseType : ")]
        //public string CaseType { get; set; }

        //[Display(Name = "TAT : ")]
        //public byte TAT { get; set; }

        //[Display(Name = "Nationality : ")]
        //public string Nationality { get; set; }

        //[Display(Name = "EmployeeID : ")]
        //public string EmployeeID { get; set; }

        //[Display(Name = "Designation : ")]
        //public string Designation { get; set; }

        //[Display(Name = "Place of Joining : ")]
        //public string PlaceofJoining { get; set; }

        //[Display(Name = "DateofJoining : ")]
        //public DateTime? DateofJoining { get; set; }

        //[Display(Name = "Details Entered By : ")]
        //public string DetailsEnteredBy { get; set; }            //Company/Client/Candidate

        //[Display(Name = "ProcessName : ")]
        //public string ProcessName { get; set; }

        //[Display(Name = "BusinessName : ")]
        //public string BusinessName { get; set; }

        //[Display(Name = "Type : ")]
        //public string Type { get; set; }

        //[Display(Name = "SpouseName : ")]
        //public string SpouseName { get; set; }

        //[Display(Name = "Spouse Middle Name : ")]
        //public string SpouseMiddleName { get; set; }

        //[Display(Name = "Spouse Last Name : ")]
        //public string SpouseLastName { get; set; }

        [Display(Name = "Create By : ")]
        public string CreatedBy { get; set; }

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

    public class AddTempPQPersonalViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Required(ErrorMessage = "Select Client")]
        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        public int ClientUserRowID { get; set; }

        public int CandidateUserID { get; set; }

        [Display(Name = "Client Ref ID : ")]
        [MaxLength(100)]
        public string ClientRefID { get; set; }

        [Display(Name = "Company Ref No : ")]
        [MaxLength(100)]
        public string CompanyRefNo { get; set; }


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

        [MaxLength(50)]
        [Display(Name = "CaseType : ")]
        public string CaseType { get; set; }

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

        public string CandidateCheckOrPackage { get; set; }


        public string OtherDetails { get; set; }
        public string OtherDetails1 { get; set; }

        public short TAT { get; set; }

        public byte CaseStatus { get; set; }
        public byte Status { get; set; }
    }

    public class AddTempPQPersonalForBulkUpViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID : ")]
        public int PersonalRowID { get; set; }

        [Required(ErrorMessage = "Select Client")]
        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        public int ClientUserRowID { get; set; }

        public int CandidateUserID { get; set; }

        [Display(Name = "Client Ref ID : ")]
        [MaxLength(100)]
        public string ClientRefID { get; set; }

        [Display(Name = "EmployeID : ")]
        [MaxLength(100)]
        public string EmployeID { get; set; }

        //[Display(Name = "Company Ref No : ")]
        //[MaxLength(100)]
        //public string CompanyRefNo { get; set; }

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

        [MaxLength(50)]
        [Display(Name = "CaseType : ")]
        public string CaseType { get; set; }

        [MaxLength(20)]
        [Display(Name = "From Type : ")]
        public string FromType { get; set; }

        [MaxLength(100)]
        [Display(Name = "Details Entered By : ")]
        public string DetailsEnteredBy { get; set; }            //Company/Client/Candidate

        [Display(Name = "Created By : ")]
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

        public string CandidateCheckOrPackage { get; set; }

        [Display(Name = "Upload Docs : ")]
        [ValidateLargeFileClientCandidateUploadExcelDocs]
        public HttpPostedFileBase UploadDoc { get; set; }

        [Display(Name = "Template : ")]
        public string Template { get; set; }

        public string OtherDetails { get; set; }
        public string OtherDetails1 { get; set; }

        public short TAT { get; set; }

        public byte CaseStatus { get; set; }
        public byte Status { get; set; }
    }

    public class UpdateTempPQPersonalViewModel
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

        [Display(Name = "Company Ref No : ")]
        [MaxLength(100)]
        public string CompanyRefNo { get; set; }

        [Display(Name = "Candidate Code : ")]
        [MaxLength(100)]
        public string CandidateCode { get; set; }

        [Display(Name = "Title : ")]
        [MaxLength(15)]
        public string CandTitle { get; set; }

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
        [Display(Name = "Catagory : ")]
        public string Catagory { get; set; }

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

        [Display(Name = "Allocated To DEQC Date : ")]
        public DateTime? AllocatedToDEQCDate { get; set; }

        [MaxLength(200)]
        [Display(Name = "Remark : ")]
        public string Remark { get; set; }

        [MaxLength(50)]
        [Display(Name = "Final Color : ")]
        public string FinalColor { get; set; }

        [Display(Name = "ExitIntrvwApplicable : ")]
        public byte ExitIntrvwApplicable { get; set; }        // yes=1/No=0

        [Display(Name = "Case Status : ")]
        public byte CaseStatus { get; set; }

        [Display(Name = "Final Status : ")]
        public byte FinalStatus { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [Required]
        [Display(Name = "Upload Candidate Signed Terms File : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase CandidateTermsFile { get; set; }

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

    public class TempPQPersonalDetailViewModel
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

        //[Display(Name = "Location : ")]
        //public string Location { get; set; }

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

        //[Display(Name = "Title : ")]
        //public string FatherTitle { get; set; }

        //[Display(Name = "father Name : ")]
        //public string FatherName { get; set; }

        //[Display(Name = "Middle Name : ")]
        //public string FatherMiddleName { get; set; }

        //[Display(Name = "Last Name : ")]
        //public string FatherLastName { get; set; }

        [Display(Name = "Gender : ")]
        public string Gender { get; set; }

        //[Display(Name = "Date Of Birth : ")]
        //public DateTime? DOB { get; set; }

        //[Display(Name = "Marital Status : ")]
        //public string MaritalStatus { get; set; }

        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }

        //[Display(Name = "Alternate No : ")]
        //public string AlternateNo { get; set; }

        [Display(Name = "Email : ")]
        public string EmailID { get; set; }

        public string SendMailStatus { get; set; }

        //[Display(Name = "Alternate Email : ")]
        //public string AlternateEmailID { get; set; }

        //[Display(Name = "STD : ")]
        //public string STD { get; set; }

        //[Display(Name = "Residence Phone No : ")]
        //public string ResidencePhoneNo { get; set; }

        //[Display(Name = "Pan Card : ")]
        //public byte PanCard { get; set; }

        //[Display(Name = "Pan Card : ")]
        //public string PanCardNo { get; set; }

        //[Display(Name = "Passport : ")]
        //public byte Passport { get; set; }

        //[Display(Name = "Passport : ")]
        //public string PassportNo { get; set; }

        //[Display(Name = "Aadhaar Card : ")]
        //public byte AadhaarCard { get; set; }

        //[Display(Name = "Aadhaar Card : ")]
        //public string AadhaarCardNo { get; set; }

        //[Display(Name = "Driving License : ")]
        //public byte DrivingLicense { get; set; }

        //[Display(Name = "Driving License : ")]
        //public string DrivingLicenseNo { get; set; }

        //[Display(Name = "Voter ID Card : ")]
        //public byte VoterIDCard { get; set; }

        //[Display(Name = "Voter ID Card : ")]
        //public string VoterIDCardNo { get; set; }

        //[Display(Name = "CheckDateTime : ")]
        //public DateTime? CheckDateTime { get; set; }

        //[Display(Name = "Candidate Type : ")]
        //public string CandidateType { get; set; }

        //[Display(Name = "Catagory : ")]
        //public string Catagory { get; set; }

        //[Display(Name = "CaseType : ")]
        //public string CaseType { get; set; }

        //[Display(Name = "TAT : ")]
        //public byte TAT { get; set; }

        //[Display(Name = "Nationality : ")]
        //public string Nationality { get; set; }

        //[Display(Name = "EmployeeID : ")]
        //public string EmployeeID { get; set; }

        //[Display(Name = "Designation : ")]
        //public string Designation { get; set; }

        //[Display(Name = "Place of Joining : ")]
        //public string PlaceofJoining { get; set; }

        //[Display(Name = "DateofJoining : ")]
        //public DateTime? DateofJoining { get; set; }

        //[Display(Name = "Details Entered By : ")]
        //public string DetailsEnteredBy { get; set; }            //Company/Client/Candidate

        //[Display(Name = "ProcessName : ")]
        //public string ProcessName { get; set; }

        //[Display(Name = "BusinessName : ")]
        //public string BusinessName { get; set; }

        //[Display(Name = "Type : ")]
        //public string Type { get; set; }

        //[Display(Name = "SpouseName : ")]
        //public string SpouseName { get; set; }

        //[Display(Name = "Spouse Middle Name : ")]
        //public string SpouseMiddleName { get; set; }

        //[Display(Name = "Spouse Last Name : ")]
        //public string SpouseLastName { get; set; }

        [Display(Name = "Create By : ")]
        public short CreatedBy { get; set; }

        [Display(Name = "Create Date : ")]
        public DateTime? CreatedDate { get; set; }

        //[Display(Name = "Allocated By : ")]
        //public short AllocatedBy { get; set; }

        //[Display(Name = "Allocated To DE : ")]
        //public short AllocatedToDE { get; set; }
        //public string AllocatedToDEName { get; set; }

        //[Display(Name = "Allocated To DE Date : ")]
        //public DateTime? AllocatedToDEDate { get; set; }

        //[Display(Name = "Allocated To DEQC : ")]
        //public short AllocatedToDEQC { get; set; }
        //public string AllocatedToDEQCName { get; set; }

        //[Display(Name = "Allocated To DEQC Date : ")]
        //public DateTime? AllocatedToDEQCDate { get; set; }

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

    public class TempPQPersonalForSendMailViewModel
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

        //[Display(Name = "Status : ")]
        //[ScaffoldColumn(false)]
        //public byte Status { get; set; }

        //[Display(Name = "OtherDetails : ")]
        //public string OtherDetails { get; set; }

        [Display(Name = "OtherDetails1 : ")]
        public string OtherDetails2 { get; set; }
    }

    public class TempPQPersonalInfoListPagedModel
    {
        public IEnumerable<TempPQPersonalDetailViewModel> TempPQPersonalInfo { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class TempClientHrApprovalCasesViewModel
    {
        public int PersonalRowID { get; set; }
        public string CandidateName { get; set; }
        public short ClientRowID { get; set; }
        public string ClientName { get; set; }
        public string ClientRefID { get; set; }
        public string CompanyRefNo { get; set; }
        public string CandidateCode { get; set; }
        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DetailsEnterdBy { get; set; }
        public string FromType { get; set; }
        public string OtherDetails { get; set; }
        public string OtherDetails1 { get; set; }
        public string OtherDetails2 { get; set; }
    }

    public class TempClientHrApprovalCasesListPagedModel
    {
        public IEnumerable<TempClientHrApprovalCasesViewModel> TempHrAprvlCases { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

}