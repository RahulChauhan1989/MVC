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
    class PQEducationViewModel
    {
        public int EducationRowID { get; set; }
        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public short CheckFamilyRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string UniqueComponentID { get; set; }
    }
     public  class AddPQEducationViewModel
    {
        [Display(Name ="ID")]
        [ScaffoldColumn(false)]
        public int EducationRowID { get; set; }

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

        [MaxLength(20)]
        [ScaffoldColumn(false)]
        public string UniqueComponentID { get; set; }

        //public IEnumerable<CheckActionHistoryViewModel> CheckActionHistories { get; set; }
        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Candidate Name :")]
        public string EV_Cand_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID :")]
        public string EV_Sec_Ref_Id { get; set; }// Text Field

        [MaxLength(100)]
        [Display(Name = "Candidate Name (As per education  supporting document) :")]
        public string EV_Cand_Name_Supp_Edu_Doc { get; set; }// Text Field
        
        [Display(Name = "College/Institute/School Name :")]
        public int EV_Colg_Schl_Inst_Name { get; set; }//  drop down -Auto populated from education master 

        [MaxLength(200)]
        [Display(Name = "College/Institute/School Address & contact Details :")]
        public string EV_Colg_Schl_Inst_Add_ConDet { get; set; }//  drop down -Auto populated from education master 

        [Display(Name = "Affiliated University/ Board Name :")]
        public short EV_Affl_University_Name { get; set; }//  drop down -University filter from education master 

        public string  strEV_Affl_University_Name { get; set; }

        [Display(Name = "Degree / Qualification name :")]
        public short EV_Degree_Name { get; set; }// Drop down 

        [MaxLength(50)]
        [Display(Name = "Mode of Education :")]
        public string EV_Mode_Of_Edu { get; set; }// drop down -Full Time / Part Time / Distance

        [MaxLength(50)]
        [Display(Name = "Seat No. / Roll No./ Enrollment No./PRN Nos :")]
        public string EV_Enroll_RollNo { get; set; }// Text Filed 

        [MaxLength(50)]
        [Display(Name = "Registration Number / Registration Code/Roll code/Certificate nos :")]
        public string EV_RegNo_RegCode { get; set; }// Text Filed 

        [MaxLength(50)]
        [Display(Name = "Duration of course :")]
        public string EV_Dur_Course { get; set; }// Text Filed 

        [MaxLength(50)]
        [Display(Name = "Course Status :")]
        public string EV_Course_Status { get; set; }// Drop down -Completed / Pursuing / Result Awaited / Dropout / Back logs / Others

        [MaxLength(100)]
        [Display(Name = "Specialization :")]
        public string EV_Specialization { get; set; }// Text Area

        [MaxLength(100)]
        [Display(Name = "Period of the course (Date From : To) :")]
        public string EV_Period_Course { get; set; }// Date To & From Calender       

        [MaxLength(10)]
        [Display(Name = "Year of Passing :")]
        public string EV_Yr_Passing { get; set; }// Calender

        [MaxLength(50)]
        [Display(Name = "Division /CGPA/Percentage :")]
        public string EV_Division_CGPA { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "CompanyId No :")]
        public string ATA_CID_No { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Company Address :")]
        public string ATA_Cmpny_Addr { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 1 :")]
        public string EV_Others { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 2 :")]
        public string EV_Others2 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 3 :")]
        public string EV_Others3 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 4 :")]
        public string EV_Others4 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 5 :")]
        public string EV_Others5 { get; set; }// drop down 

        [MaxLength(200)]
        [Display(Name = "Others 6 :")]
        public string EV_Others6 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 7 :")]
        public string EV_Others7 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 8 :")]
        public string EV_Others8 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 9 :")]
        public string EV_Others9 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 10 :")]
        public string EV_Others10 { get; set; }//drop down 

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
        [Display(Name = "Check Status : ")]
        public string ReWorkCheckStatus { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }

        [MaxLength(200)]
        [Display(Name = "Reason : ")]
        public string INFRemarks { get; set; }

        [Display(Name = "Other Institute Selected : ")]
        public byte SelectOtherInstitute { get; set; }

        [Display(Name ="Other Institute Details : ")]
        public string OtherInstitute { get; set; }

        [MaxLength(200)]
        [Display(Name = "Check Status : ")]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    public class PQUpdateEducationViewModel
    {
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int EducationRowID { get; set; }

        public short ClientRowID { get; set; }
        public int PersonalRowID { get; set; }
        public int ClientPackageRowID { get; set; }
        public short CheckFamilyRowID { get; set; }
        public short SubCheckRowID { get; set; }

        public string UniqueComponentID { get; set; }

        //public IEnumerable<CheckActionHistoryViewModel> CheckActionHistories { get; set; }
        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Candidate Name :")]
        public string EV_Cand_Name { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID :")]
        public string EV_Sec_Ref_Id { get; set; }// Text Field

        [MaxLength(100)]
        [Display(Name = "Candidate Name (As per education  supporting document) :")]
        public string EV_Cand_Name_Supp_Edu_Doc { get; set; }// Text Field

        [Display(Name = "College/Institute/School Name :")]
        public int EV_Colg_Schl_Inst_Name { get; set; }//  drop down -Auto populated from education master 

        [MaxLength(200)]
        [Display(Name = "College/Institute/School Address & contact Details :")]
        public string EV_Colg_Schl_Inst_Add_ConDet { get; set; }//  drop down -Auto populated from education master 

        [Display(Name = "Affiliated University/ Board Name :")]
        public short EV_Affl_University_Name { get; set; }//  drop down -University filter from education master 
        public string strEV_Affl_University_Name { get; set; }

        [Display(Name = "Degree / Qualification name :")]
        public short EV_Degree_Name { get; set; }// Drop down 

        [MaxLength(50)]
        [Display(Name = "Mode of Education :")]
        public string EV_Mode_Of_Edu { get; set; }// drop down -Full Time / Part Time / Distance

        [MaxLength(50)]
        [Display(Name = "Seat No. / Roll No./ Enrollment No./PRN Nos :")]
        public string EV_Enroll_RollNo { get; set; }// Text Filed 

        [MaxLength(50)]
        [Display(Name = "Registration Number / Registration Code/Roll code/Certificate nos :")]
        public string EV_RegNo_RegCode { get; set; }// Text Filed 

        [MaxLength(50)]
        [Display(Name = "Duration of course :")]
        public string EV_Dur_Course { get; set; }// Text Filed 

        [MaxLength(50)]
        [Display(Name = "Course Status :")]
        public string EV_Course_Status { get; set; }// Drop down -Completed / Pursuing / Result Awaited / Dropout / Back logs / Others

        [MaxLength(100)]
        [Display(Name = "Specialization :")]
        public string EV_Specialization { get; set; }// Text Area

        [MaxLength(100)]
        [Display(Name = "Period of the course (Date From : To) :")]
        public string EV_Period_Course { get; set; }// Date To & From Calender 

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EV_Period_CourseFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EV_Period_CourseTo { get; set; }

        [MaxLength(10)]
        [Display(Name = "Year of Passing :")]
        public string EV_Yr_Passing { get; set; }// Calender

        [MaxLength(50)]
        [Display(Name = "Division /CGPA/Percentage :")]
        public string EV_Division_CGPA { get; set; }// Text Field

        [MaxLength(50)]
        [Display(Name = "CompanyId No :")]
        public string ATA_CID_No { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Company Address :")]
        public string ATA_Cmpny_Addr { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 1 :")]
        public string EV_Others { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 2 :")]
        public string EV_Others2 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 3 :")]
        public string EV_Others3 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 4 :")]
        public string EV_Others4 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 5 :")]
        public string EV_Others5 { get; set; }// drop down 

        [MaxLength(200)]
        [Display(Name = "Others 6 :")]
        public string EV_Others6 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 7 :")]
        public string EV_Others7 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 8 :")]
        public string EV_Others8 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 9 :")]
        public string EV_Others9 { get; set; }// Text Field

        [MaxLength(200)]
        [Display(Name = "Others 10 :")]
        public string EV_Others10 { get; set; }//drop down 
        
        public short ModifiedBy { get; set; }
        
        public DateTime? ModifiedDate { get; set; }

        public short MgrAllocatedBy { get; set; }
        public short MgrAllocatedTo { get; set; }
        public DateTime? MgrAllocatedDate { get; set; }

        public string CheckStatus { get; set; }

        public string ReWorkCheckStatus { get; set; }

        [Display(Name = "Other Institute Selected : ")]
        public byte SelectOtherInstitute { get; set; }

        [Display(Name = "Other Institute Details : ")]
        public string OtherInstitute { get; set; }
 
        [Display(Name = "If Reject : ")]
        public string RejectionReason { get; set; }

        [MaxLength(200)]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
       
    }

    public class PQUpdateEducationManagerViewModel
    {
        [ScaffoldColumn(false)]
        public int EducationRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short TLAllocatedBy { get; set; }
        public short TLAllocatedTo { get; set; }
        public DateTime? TLAllocatedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQUpdateEducationTeamLeaderViewModel
    {
        [ScaffoldColumn(false)]
        public int EducationRowID { get; set; }

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

    public class PQUpdateEducationTeamMemberViewModel
    {
        [ScaffoldColumn(false)]
        public int EducationRowID { get; set; }

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

    public class UpdateEducationRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int EducationRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public short InfSuffRaiseBy { get; set; }
        public DateTime? InfSuffRaisedDate { get; set; }
        public string INFRemarks { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class PQUpdateEducationResearcherViewModel
    {
        [ScaffoldColumn(false)]
        public int EducationRowID { get; set; }

        public string UniqueComponentID { get; set; }
        public int PersonalRowID { get; set; }
        public short SubCheckRowID { get; set; }

        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }
    
    public class CollegeDDLListViewModel
    {
        public int CollegeRowID { get; set; }
        public string CollegeName { get; set; }
    }
    public class DegreeDDLListViewModel
    {
        public short DegreeRowID { get; set; }
        public string DegreeName { get; set; }
    }
    public class CollegeAddressAndAffiliated
    {   
        public string Address { get; set; }
        public string Affiliated { get; set; }
    }

    public class PQEducationInsuffViewModel
    {
        public int EducationRowID { get; set; }

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

    public class UpdatePQEducationInsuffClearViewModel
    {
        public int EducationRowID { get; set; }
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

    public class PQEducationInsuffListPagedModel
    {
        public IEnumerable<PQEducationInsuffViewModel> PQAllInsuffEducations { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class ViewEducationViewModel
    {
        [ScaffoldColumn(false)]
        [Required]
        public int EducationRowID { get; set; }

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
