using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels.TempViewModel
{
    class TempPQEducationViewModel
    {
    }
     public  class AddTempPQEducationViewModel
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

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? EV_Period_CourseFrom { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? EV_Period_CourseTo { get; set; }

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

        public DateTime? OutDate { get; set; }
        public DateTime? InternalOutDate { get; set; }

        [ScaffoldColumn(false)]
        public short CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        public short ModifiedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }
        
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

        public byte SelectOtherInstitute { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Other Institute Details : ")]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    //public class TempPQUpdateEducationViewModel
    //{
    //    [Display(Name = "ID")]
    //    [ScaffoldColumn(false)]
    //    public int EducationRowID { get; set; }

    //    public short ClientRowID { get; set; }
    //    public int PersonalRowID { get; set; }
    //    public int ClientPackageRowID { get; set; }
    //    public short CheckFamilyRowID { get; set; }
    //    public short SubCheckRowID { get; set; }

    //    public string UniqueComponentID { get; set; }

    //    [Display(Name = "Candidate Name :")]
    //    public string EV_Cand_Name { get; set; }// Text Field

    //    [Display(Name = "Securitas Reference ID :")]
    //    public string EV_Sec_Ref_Id { get; set; }// Text Field

    //    [Display(Name = "Candidate Name (As per education  supporting document) :")]
    //    public string EV_Cand_Name_Supp_Edu_Doc { get; set; }// Text Field

    //    [Display(Name = "College/Institute/School Name :")]
    //    public int EV_Colg_Schl_Inst_Name { get; set; }//  drop down -Auto populated from education master 

    //    [Display(Name = "College/Institute/School Address & contact Details :")]
    //    public string EV_Colg_Schl_Inst_Add_ConDet { get; set; }//  drop down -Auto populated from education master 

    //    [Display(Name = "Affiliated University/ Board Name :")]
    //    public short EV_Affl_University_Name { get; set; }//  drop down -University filter from education master 
    //    public string strEV_Affl_University_Name { get; set; }

    //    [Display(Name = "Degree / Qualification name :")]
    //    public short EV_Degree_Name { get; set; }// Drop down 

    //    [Display(Name = "Mode of Education :")]
    //    public string EV_Mode_Of_Edu { get; set; }// drop down -Full Time / Part Time / Distance

    //    [Display(Name = "Seat No. / Roll No./ Enrollment No./PRN Nos :")]
    //    public string EV_Enroll_RollNo { get; set; }// Text Filed 

    //    [Display(Name = "Registration Number / Registration Code/Roll code/Certificate nos :")]
    //    public string EV_RegNo_RegCode { get; set; }// Text Filed 

    //    [Display(Name = "Duration of course :")]
    //    public string EV_Dur_Course { get; set; }// Text Filed 

    //    [Display(Name = "Course Status :")]
    //    public string EV_Course_Status { get; set; }// Drop down -Completed / Pursuing / Result Awaited / Dropout / Back logs / Others

    //    [Display(Name = "Specialization :")]
    //    public string EV_Specialization { get; set; }// Text Area

    //    [Display(Name = "Period of the course (Date From : To) :")]
    //    public string EV_Period_Course { get; set; }// Date To & From Calender 

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? EV_Period_CourseFrom { get; set; }

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? EV_Period_CourseTo { get; set; }

    //    [Display(Name = "Year of Passing :")]
    //    public string EV_Yr_Passing { get; set; }// Calender

    //    [Display(Name = "Division /CGPA/Percentage :")]
    //    public string EV_Division_CGPA { get; set; }// Text Field

    //    [Display(Name = "CompanyId No :")]
    //    public string ATA_CID_No { get; set; }// Text Field

    //    [Display(Name = "Company Address :")]
    //    public string ATA_Cmpny_Addr { get; set; }// Text Field

    //    [Display(Name = "Degree Certfict :")]
    //    public byte EV_DegreeCertfict { get; set; }   // CheckBox     Default - 0 otherwise 1
    //    [NotMapped]
    //    public bool EV_DegreeCertfictBool
    //    {
    //        get { return EV_DegreeCertfict > 0; }
    //        set { EV_DegreeCertfict = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase DegreeCertfictDoc { get; set; }

    //    [Display(Name = "Provisional Certfict :")]
    //    public byte EV_ProvisionalCertfict { get; set; }   // CheckBox Default - 0 otherwise 1

    //    public bool EV_ProvisionalCertfictBool
    //    {
    //        get { return EV_ProvisionalCertfict > 0; }
    //        set { EV_ProvisionalCertfict = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase ProvisionalCertfictDoc { get; set; }

    //    [Display(Name = "Grade Sheet :")]
    //    public byte EV_GradeSheet { get; set; }   // CheckBox Default - 0 otherwise 1

    //    public bool EV_GradeSheetBool
    //    {
    //        get { return EV_GradeSheet > 0; }
    //        set { EV_GradeSheet = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase GradeSheetDoc { get; set; }

    //    [Display(Name = "AllMarks Cards ")]
    //    public byte EV_AllMarksCards { get; set; }   // CheckBox Default - 0 otherwise 1

    //    public bool EV_AllMarksCardsBool
    //    {
    //        get { return EV_AllMarksCards > 0; }
    //        set { EV_AllMarksCards = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase AllMarksCardsDoc { get; set; }

    //    [Display(Name = "DocStatColgNameNo :")]
    //    public byte EV_DocStatColgNameNo { get; set; }   // CheckBox Default - 0 otherwise 1

    //    public bool EV_DocStatColgNameNoBool
    //    {
    //        get { return EV_DocStatColgNameNo > 0; }
    //        set { EV_DocStatColgNameNo = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase StatColgNameNoDoc { get; set; }

    //    [Display(Name = "Other Proof :")]
    //    public byte EV_OtherProof { get; set; } // CheckBox Default - 0 otherwise 1
    //    public bool EV_OtherProofBool
    //    {
    //        get { return EV_OtherProof > 0; }
    //        set { EV_OtherProof = value ? (byte)1 : (byte)0; }
    //    }
    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase OtherProofDoc { get; set; }

    //    [Display(Name = "Others 1 :")]
    //    public string EV_Others { get; set; }// Text Field

    //    [Display(Name = "Others 2 :")]
    //    public string EV_Others2 { get; set; }// Text Field

    //    [Display(Name = "Others 3 :")]
    //    public string EV_Others3 { get; set; }// Text Field

    //    [Display(Name = "Others 4 :")]
    //    public string EV_Others4 { get; set; }// Text Field

    //    [Display(Name = "Others 5 :")]
    //    public string EV_Others5 { get; set; }// drop down 

    //    [Display(Name = "Others 6 :")]
    //    public string EV_Others6 { get; set; }// Text Field

    //    [Display(Name = "Others 7 :")]
    //    public string EV_Others7 { get; set; }// Text Field

    //    [Display(Name = "Others 8 :")]
    //    public string EV_Others8 { get; set; }// Text Field

    //    [Display(Name = "Others 9 :")]
    //    public string EV_Others9 { get; set; }// Text Field

    //    [Display(Name = "Others 10 :")]
    //    public string EV_Others10 { get; set; }//drop down 

    //    [ScaffoldColumn(false)]
    //    public short ModifiedBy { get; set; }

    //    [ScaffoldColumn(false)]
    //    public DateTime? ModifiedDate { get; set; }

    //    public short MgrAllocatedBy { get; set; }
    //    public short MgrAllocatedTo { get; set; }
    //    public DateTime? MgrAllocatedDate { get; set; }

    //    [ScaffoldColumn(false)]
    //    public string CheckStatus { get; set; }

    //    [ScaffoldColumn(false)]
    //    public string CaseStatus { get; set; }

    //    [ScaffoldColumn(false)]
    //    public string Remarks { get; set; }

    //    [ScaffoldColumn(false)]
    //    public byte Status { get; set; }
    //}

    public class TempUpdateEducationRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int EducationRowID { get; set; }

        public short ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class TempEducationList
    {
        public short AntecedentRowId { get; set; }
        public string AntecedentName { get; set; }
        public string FieldName { get; set; }
        public byte AntecedentTypeRowId { get; set; }
    }
    public class TempCollegeDDLListViewModel
    {
        public int CollegeRowID { get; set; }
        public string CollegeName { get; set; }
    }
    public class tempDegreeDDLListViewModel
    {
        public short DegreeRowID { get; set; }
        public string DegreeName { get; set; }
    }
    public class tempCollegeAddressAndAffiliated
    {   
        public string Address { get; set; }
        public string Affiliated { get; set; }
    }



}
