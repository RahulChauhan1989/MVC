using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels
{
    public class CompanyViewModel
    {
        [Display(Name = "ID :")]
        public short CompanyRowID { get; set; }

        [Display(Name = "Name :")]
        public string CompanyName { get; set; }

        [Display(Name = "Address :")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Country :")]
        public short CountryRowID { get; set; }
        public string CountryName { get; set; }

        [Display(Name = "State :")]
        public short StateRowID { get; set; }
        public string StateName { get; set; }

        [Display(Name = "District :")]
        public short DistrictRowID { get; set; }
        public string DistrictName { get; set; }

        [Display(Name = "Location Name : ")]
        public int LocationRowID { get; set; }
        public string LocationName { get; set; }

        [Display(Name = "Email :")]
        public string GeneralEmail { get; set; }

        [Display(Name = "SMTP :")]
        public short SMTP { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password :")]
        public string Password { get; set; }

        [Display(Name = "Is SSL Enable :")]
        public byte EnableSsl { get; set; }

        public string EnableSslYN { get; set; }

        [Display(Name = "Port :")]
        public string SMTPPort { get; set; }

        [Display(Name = "Host :")]
        public string SMTPServer { get; set; }

        [Display(Name = "Mobile No. :")]
        public string MobileNo { get; set; }

        [Display(Name = "Phone No. :")]
        public string PhoneNo { get; set; }

        [Display(Name = "Fax No. :")]
        public string FaxNo { get; set; }

        [Display(Name = "Company Logo :")]
        public string CompanyLogo { get; set; }
       public string CmpLogo { get; set; }

        [Display(Name = "User Name :")]
        public string SMTPUserName { get; set; }

        [Display(Name = "Initiation Display :")]
        public string InitiationDName{ get; set; }

        [Display(Name = "Initiation Email :")]
        public string InitiationEmail { get; set; }

        [Display(Name = "Insuff Display :")]
        public string InsuffDName { get; set; }

        [Display(Name = "Insuff Email :")]
        public string InsuffEmail { get; set; }

        [Display(Name = "Report Display :")]
        public string ReportDName { get; set; }

        [Display(Name = "Report Email :")]
        public string ReportEmail { get; set; }

        [Display(Name = "MIS Display :")]
        public string MISDName { get; set; }

        [Display(Name = "MIS Email :")]
        public string MISEmail { get; set; }

        [Display(Name = "Billing Display :")]
        public string BillingDName { get; set; }

        [Display(Name = "Billing Email :")]
        public string BillingEmail { get; set; }

        [Display(Name = "Other Display :")]
        public string OtherDName { get; set; }

        [Display(Name = "Other Email :")]
        public string OtherEmail { get; set; }        

        [ScaffoldColumn(false)]
        public byte Status { get; set; }    
    }

    public class AddCompanyViewModel
    {
        [Display(Name = "ID : ")]
        public short CompanyRowID { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Name : ")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Address : ")]
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

        [Required]
        [Display(Name = "Mobile No. : ")]
        [MaxLength(20)]
        //[RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Main Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string GeneralEmail { get; set; }

        [Required]
        [Display(Name = "Phone No. : ")]
        [MaxLength(20)]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Fax No. : ")]
        [MaxLength(20)]
        public string FaxNo { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Initiation Display : ")]
        public string InitiationDisplay { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Initiation Email : ")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string InitiationEmail { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Insuff Display : ")]
        public string InsuffDName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Insuff Email : ")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string InsuffEmail { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Report Display : ")]
        public string ReportDName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Report Email : ")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string ReportEmail { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "MIS Display : ")]
        public string MISDName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "MIS Email : ")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string MISEmail { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Billing Display : ")]
        public string BillingDName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Billing Email : ")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string BillingEmail { get; set; }
       
        [MaxLength(100)]
        [Display(Name = "Other Display : ")]
        public string OtherDName { get; set; }
       
        [MaxLength(100)]
        [Display(Name = "Other Email : ")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string OtherEmail { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Host : ")]
        public string SMTPServer { get; set; }

        [Required]
        [MaxLength(4)]
        [Display(Name = "Port : ")]
        public string Port { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "User Name : ")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string SMTPUserName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Password : ")]
        public string SMTPPassword { get; set; }

        [Display(Name = "Is SSL Enable : ")]
        public bool EnableSsl { get; set; }
      
        [Display(Name = "Company Logo : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase CompanyLogo { get; set; }

        public string CmpLogo { get; set; }

        [Required]
        [Display(Name ="Upload Candidate Terms File : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase CandidateTermsFile { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class UpdateCompanyViewModel
    {
        [Required]
        [Display(Name = "ID : ")]
        public short CompanyRowID { get; set; }

        [Required]
        [Display(Name = "Name : ")]
        [MaxLength(150)]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Address : ")]
        [MaxLength(200)]
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

        [Required]
        [Display(Name = "Mobile No : ")]
        [MaxLength(20)]
        //[RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile Number")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Main Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string GeneralEmail { get; set; }

        [Required]
        [Display(Name = "Phone No. : ")]
        [MaxLength(20)]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Fax No. : ")]
        [MaxLength(20)]
        public string FaxNo { get; set; }

        [Required]
        [Display(Name = "Initiation Display : ")]
        [MaxLength(100)]
        public string InitiationDisplay { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        [Display(Name = "Initiation Email : ")]
        [MaxLength(100)]
        public string InitiationEmail { get; set; }

        [Required]
        [Display(Name = "Insuff Display : ")]
        [MaxLength(100)]
        public string InsuffDName { get; set; }

        [Required]
        [Display(Name = "Insuff Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string InsuffEmail { get; set; }

        [Required]
        [Display(Name = "Report Display : ")]
        [MaxLength(100)]
        public string ReportDName { get; set; }

        [Required]
        [Display(Name = "Report Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string ReportEmail { get; set; }

        [Required]
        [Display(Name = "MIS Display : ")]
        [MaxLength(100)]
        public string MISDName { get; set; }

        [Required]
        [Display(Name = "MIS Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string MISEmail { get; set; }

        [Required]
        [Display(Name = "Billing Display : ")]
        [MaxLength(100)]
        public string BillingDName { get; set; }

        [Required]
        [Display(Name = "Billing Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string BillingEmail { get; set; }

        [Display(Name = "Other Display : ")]
        [MaxLength(100)]
        public string OtherDName { get; set; }

        [Display(Name = "Other Email : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string OtherEmail { get; set; }

        [Required]
        [Display(Name = "User Name : ")]
        [MaxLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string SMTPUserName { get; set; }
        
        [Display(Name = "Password : ")]
        [MaxLength(100)]
        public string SMTPPassword { get; set; }

        [Required]
        [MaxLength(4)]
        [Display(Name = "Port : ")]
        public string SMTPPort { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Host : ")]
        public string SMTPServer { get; set; }    
           
        [Display(Name = "Company Logo : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase CompanyLogo { get; set; }
        public string CmpLogo { get; set; }

        [Display(Name = "Upload Candidate Terms File : ")]
        [ValidateImageFileWithNullCheckAttribute]
        public HttpPostedFileBase CandidateTermsFile { get; set; }

        [Display(Name = "Is SSL Enable : ")]
        public bool EnableSsl { get; set; }
    }

    public class CompanyExportViewModel
    {       
        public short CompanyRowID { get; set; }
        public string CompanyName { get; set; }        
        public string CompanyAddress { get; set; }      
        public string CountryName { get; set; }     
        public string StateName { get; set; }       
        public string DistrictName { get; set; }        
        public short LocationRowID { get; set; }
        public string LocationName { get; set; }      
        public string GeneralEmail { get; set; }       
        public short  SMTP { get; set; }
        public string UserName { get; set; }       
        public string Password { get; set; }       
        public byte   EnableSsl { get; set; }        
        public string SMTPPort { get; set; }
        public string SMTPHost { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public string SMTPUserName { get; set; }     
        public string InitiationDName { get; set; }       
        public string InitiationEmail { get; set; }        
        public string InsuffDName { get; set; }     
        public string InsuffEmail { get; set; }     
        public string ReportDName { get; set; }     
        public string ReportEmail { get; set; }       
        public string MISDName { get; set; }    
        public string MISEmail { get; set; }       
        public string BillingDName { get; set; }       
        public string BillingEmail { get; set; }      
        public string OtherDName { get; set; }     
        public string OtherEmail { get; set; }
    }

    public class CompanyListPagedModel
    {
        public IEnumerable<CompanyViewModel> Companies { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class CompanyMailAuthenticationViewModel
    {        
        public short CompanyRowID { get; set; }
        public string SMTPServer { get; set; }
        public string Port { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPPassword { get; set; }
        public bool EnableSsl { get; set; }
    }
    
    public class CompanyMailSignatureViewModel
    {
        public short CompanyRowID { get; set; }
        public string CompanyName { get; set; }
        public string GeneralEmail { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
    }
}