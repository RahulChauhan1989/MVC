using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.HRViewModels
{
    public class TeamMemberViewModel
    {       
        [Display(Name = "ID")]
        public short TeamMemberRowID { get; set; }

        public string TeamMemberName { get; set; }

        [Display(Name = "Title : ")]
        public string TMTitle { get; set; }
       
        [Display(Name = "First Name : ")]
        public string TMFirstName { get; set; }
        
        [Display(Name = "Last Name : ")]
        public string TMLastName { get; set; }
   
        [Display(Name = "Title : ")]
        public string FTitle { get; set; }
       
        [Display(Name = "First Name : ")]
        public string FFirstName { get; set; }
       
        [Display(Name = "Last Name : ")]
        public string FLastName { get; set; }

        public string FullName { get; set; }

        public string FatherFullName { get; set; }

        public string SpouseName { get; set; }

        [Display(Name = "Spouse First Name : ")]
        public string SpouseFirstName { get; set; }

        [Display(Name = "Spouse Last Name : ")]
        public string SpouseLastName { get; set; }
        
        [Display(Name = "Date of Birth : ")]       
        public DateTime? DOB { get; set; }       
       
        [Display(Name = "Date of Join : ")]
        public DateTime? DOJ { get; set; }
       
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }
       
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select District!")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }
               
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }
       
        [Display(Name = "Pin Code :")]
        public int PinCode { get; set; }
      
        [Display(Name = "Employee : ")]
        public string EmployeeID { get; set; } 
        
        [Display(Name = "Select Category : ")]
        public byte CategoryRowID { get; set; }

        [Display(Name = "Present Address : ")]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanent Address : ")]
        public string PermanentAddress { get; set; }

        [Display(Name = "STD : ")]
        public string STD { get; set; }

        [Display(Name = "Residance Phone No : ")]
        public string ResidancePhoneNo { get; set; }

        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }
        
        [Display(Name = "EmailID : ")]
        public string EmailID { get; set; }

        [Display(Name = "Direct Tel No : ")]
        public string DirectTelNo { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Process Status : ")]
        public string ProcessStatus { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "User Type : ")]
        public string UserType { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status : ")]
        public byte Status { get; set; }

        public string BranchName { get; set; }
    }

    public class TeamMemberExportViewModel
    {
        [Display(Name = "ID")]
        public short TeamMemberRowID { get; set; }

        public string TeamMemberName { get; set; }
        
        public string FatherFullName { get; set; }

        public string SpouseName { get; set; }

        [Display(Name = "Spouse First Name : ")]
        public string SpouseFirstName { get; set; }
        
        public string SpouseLastName { get; set; }
        
        public DateTime? DOB { get; set; }
        
        public DateTime? DOJ { get; set; }
        
        public short CountryName { get; set; }
        
        public short StateName { get; set; }
        
        public short DistrictName { get; set; }
        
        public int LocationName { get; set; }
        
        public int PinCode { get; set; }

        [Display(Name = "Employee : ")]
        public string EmployeeID { get; set; }

        public string BranchName { get; set; }

        public byte CategoryName { get; set; }

        [Display(Name = "Present Address : ")]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanent Address : ")]
        public string PermanentAddress { get; set; }

        [Display(Name = "STD : ")]
        public string STD { get; set; }

        [Display(Name = "Residance Phone No : ")]
        public string ResidancePhoneNo { get; set; }

        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }
        
        public string EmailID { get; set; }
        
        public string DirectTelNo { get; set; }

        [ScaffoldColumn(false)]
        public string ProcessStatus { get; set; }

        [ScaffoldColumn(false)]
        public string UserType { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class AddTeamMemberViewModel
    {
        [ScaffoldColumn(false)]
        [Display(Name = "ID")]
        public short TeamMemberRowID { get; set; }

        [Required]
        [Display(Name = "Title : ")]
        public string TMTitle { get; set; }

        [Required]
        [Display(Name = "First Name : ")]
        public string TMFirstName { get; set; }

      
        [Display(Name = "Last Name : ")]
        public string TMLastName { get; set; }

      
        [Display(Name = "Title : ")]
        public string FTitle { get; set; }

     
        [Display(Name = "First Name : ")]
        public string FFirstName { get; set; }

       
        [Display(Name = "Last Name : ")]
        public string FLastName { get; set; }

        [Display(Name = "Spouse First Name : ")]
        public string SpouseFirstName { get; set; }

        [Display(Name = "Spouse Last Name : ")]
        public string SpouseLastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Join : ")]
        public DateTime? DOJ { get; set; }

        [Required(ErrorMessage = "Please Select Country!")]
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Please Select State!")]
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select District!")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Please Select Location!")]
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }

        [RegularExpression(@"^([1-9])([0-9]){5}$", ErrorMessage = "Please Enter Valid Pincode!")]
        [Range(110001, 860000)]
        [Display(Name = "Pin Code :")]
        public int PinCode { get; set; }

        [Required]
        [Display(Name = "Employee Code: ")]
        public string EmployeeID { get; set; }      

        [Required(ErrorMessage = "Please Select Category!")]
        [Display(Name = "Select Category : ")]
        public byte CategoryRowID { get; set; }

        [Display(Name = "Present Address : ")]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanent Address : ")]
        public string PermanentAddress { get; set; }

        [MaxLength(4)]
        [MinLength(2)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid STD ")]
        [Display(Name = "STD : ")]
        public string STD { get; set; }
        
        [MaxLength(8)]
        [MinLength(6)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid Phone No ")]
        [Display(Name = "Residance Phone No : ")]
        public string ResidancePhoneNo { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid Mobile No")]
        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }

        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        [Display(Name = "Email Id : ")]
        public string EmailID { get; set; }

        
        [Display(Name = "Direct Tel No : ")]
        public string DirectTelNo { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Process Status : ")]
        public string ProcessStatus { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "User Type : ")]
        public string UserType { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status : ")]
        public byte Status { get; set; }

        [Required(ErrorMessage = "Select Branch Office!")]
        [Display(Name = "Branch Office :")]
        public short BORowID { get; set; }
    }

    public class UpdateTeamMemberViewModel
    {
      
        [Display(Name = "ID")]
        public short TeamMemberRowID { get; set; }

        [Required]
        [Display(Name = "Title : ")]
        public string TMTitle { get; set; }

        [Required]
        [Display(Name = "First Name : ")]
        public string TMFirstName { get; set; }

       
        [Display(Name = "Last Name : ")]
        public string TMLastName { get; set; }

        
        [Display(Name = "Title : ")]
        public string FTitle { get; set; }

       
        [Display(Name = "First Name : ")]
        public string FFirstName { get; set; }

        
        [Display(Name = "Last Name : ")]
        public string FLastName { get; set; }

        [Display(Name = "Spouse First Name : ")]
        public string SpouseFirstName { get; set; }

        [Display(Name = "Spouse Last Name : ")]
        public string SpouseLastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Join : ")]
        public DateTime? DOJ { get; set; }

        [Required(ErrorMessage = "Please Select Country!")]
        [Display(Name = "Select Country : ")]
        public short CountryRowID { get; set; }

        [Required(ErrorMessage = "Please Select State!")]
        [Display(Name = "Select State : ")]
        public short StateRowID { get; set; }

        [Required(ErrorMessage = "Please Select District!")]
        [Display(Name = "Select District : ")]
        public short DistrictRowID { get; set; }

        [Required(ErrorMessage = "Please Select Location!")]
        [Display(Name = "Select Location : ")]
        public int LocationRowID { get; set; }

        [RegularExpression(@"^([1-9])([0-9]){5}$", ErrorMessage = "Please Enter Valid Pincode!")]
        [Range(110001, 860000)]
        [Display(Name = "Pin Code :")]
        public int PinCode { get; set; }
        
        [Required]
        [Display(Name = "Employee Code: ")]
        public string EmployeeID { get; set; }

       
        [Required(ErrorMessage = "Please Select Category!")]
        [Display(Name = "Select Category : ")]
        public byte CategoryRowID { get; set; }

        [Display(Name = "Present Address : ")]
        public string PresentAddress { get; set; }

        [Display(Name = "Permanent Address : ")]
        public string PermanentAddress { get; set; }

        [MaxLength(4)]
        [MinLength(2)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid STD ")]
        [Display(Name = "STD : ")]
        public string STD { get; set; }


        [MaxLength(8)]
        [MinLength(6)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid Phone No ")]
        [Display(Name = "Residance Phone No : ")]
        public string ResidancePhoneNo { get; set; }

        [MaxLength(11)]
        [RegularExpression(@"^[7-9]{1}.*[0-9]{9}$", ErrorMessage = "Please enter valid Mobile No")]
        [Display(Name = "Mobile No : ")]
        public string MobileNo { get; set; }

        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Please enter correct email")]
        [Display(Name = "EmailID : ")]
        public string EmailID { get; set; }
       
        [Display(Name = "Direct Tel No : ")]
        public string DirectTelNo { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Process Status : ")]
        public string ProcessStatus { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "UserType : ")]
        public string UserType { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status : ")]
        public byte Status { get; set; }

        [Required(ErrorMessage = "Select Branch Office!")]
        [Display(Name = "Branch Office :")]
        public short BORowID { get; set; }
    }

    public class TeamMemberListPagedModel
    {
        public IEnumerable<TeamMemberViewModel> TeamMembers { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    
    public class TeamMemberDDLViewModel
    {
        public short TeamMemberRowID { get; set; }

        [Display(Name = "TeamMember Name")]
        public string TeamMemberName { get; set; }
    }

    public class SpocForClientChkBLViewModel
    {
        [Display(Name = "Spoc Name")]
        public string SpocNameWDesig { get; set; }

        [Display(Name = "Spoc Email")]
        public string SpocEmail { get; set; }
    }

    #region View Model for TeamMember Reporting

    public class RepoToTeamMemberDDLViewModel
    {
        public short TeamDepartmentRowID { get; set; }

        [Display(Name = "TeamMember Name")]
        public string TeamMemberName { get; set; }
    }
    public class RepoToTeamMemberViewModel
    {
        public int ReportTeamRowID { get; set; }

        [Display(Name = "TeamMember Name")]
        public string TeamMemberName { get; set; }

    }

    public class AddRepoToTeamMemberViewModel
    {
        public short TeamDepartmentRowID { get; set; }

        [Display(Name = "Reporting To")]
        public string TeamMemberName { get; set; }
        public IEnumerable<short> RepoToIds { get; set; }
    }

    public class RepoToTeamMemberListPagedModel
    {
        public IEnumerable<RepoToTeamMemberViewModel> RepoToTeamMembers { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    #endregion

    #region View Model for Client Reporting

    public class RepoToClientDDLViewModel
    {
        public short ClientRowID { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

    }

    public class AddRepoToClientViewModel
    {
        public short ClientRowID { get; set; }

        [Display(Name = "Reporting To")]
        public string ClientName { get; set; }
        public IEnumerable<short> RepoToIds { get; set; }
    }

    public class RepoToClientListPagedModel
    {
        public short ClientRowID { get; set; }

        [Display(Name = "Reporting To")]
        public string ClientName { get; set; }
        public IEnumerable<RepoToClientDDLViewModel> RepoToClients { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    #endregion
}


