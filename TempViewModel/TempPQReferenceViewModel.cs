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
    public class TempPQReferenceViewModel
    {
        public int ReferenceRowID { get; set; }

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

        #endregion

        [MaxLength(100)]
        [Display(Name = "Candidate Name")]
        public string RV_CandidateName { get; set; }      //text field

        [MaxLength(50)]
        [Display(Name = "Securitas Reference ID")]
        public string RV_Sec_Ref_Id { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Name of Organisation")]
        public string RV_OrganisationName { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee Name")]
        public string RV_RefereeName { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee Designation")]
        public string RV_Refere_Desig { get; set; }      //text field

        [MaxLength(200)]
        [Display(Name = "Referee Address")]
        public string RV_Refere_Add { get; set; }      //text field

        [MaxLength(20)]
        [Display(Name = "Referee's mobile number")]
        public string RV_Refre_MobNo { get; set; }      //text field

        [MaxLength(100)]
        [Display(Name = "Referee's Email id")]
        public string RV_Refre_Eid { get; set; }      //text field

        [MaxLength(200)]
        [Display(Name = "How long have you known her/him?")]
        public string RV_Know_Long { get; set; }      // text Area

        [MaxLength(100)]
        [Display(Name = "Tenure of the Employee")]
        public string RV_Tenure_Emp { get; set; }      // to & from calender

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? RV_Tenure_EmpFrom { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? RV_Tenure_EmpTo { get; set; }

        [MaxLength(100)]
        [Display(Name = "Designation")]
        public string RV_Dsg_RC { get; set; }      // text field

        [MaxLength(50)]
        [Display(Name = "Cost to Company")]
        public string RV_CTC { get; set; }      // text field

        [MaxLength(200)]
        [Display(Name = "Reason for leaving")]
        public string RV_Reason_Leav { get; set; }      // text Area

        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase OtherProofDoc { get; set; }

        [MaxLength(200)]
        [Display(Name = "Other Details1")]
        public string RV_OtherDetails { get; set; }     // text

        [MaxLength(200)]
        [Display(Name = "Other Details2")]
        public string RV_OtherDetails2 { get; set; }    //Text

        [MaxLength(200)]
        [Display(Name = "Other Details3")]
        public string RV_OtherDetails3 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details4")]
        public string RV_OtherDetails4 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details5")]
        public string RV_OtherDetails5 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details6")]
        public string RV_OtherDetails6 { get; set; }    // text

        [MaxLength(200)]
        [Display(Name = "Other Details7")]
        public string RV_OtherDetails7 { get; set; }    //Text

        [MaxLength(200)]
        [Display(Name = "Other Details8")]
        public string RV_OtherDetails8 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details9")]
        public string RV_OtherDetails9 { get; set; }    //text

        [MaxLength(200)]
        [Display(Name = "Other Details10")]
        public string RV_OtherDetails10 { get; set; }   //text

        [MaxLength(50)]
        [Display(Name = "CID No")]
        public string ATA_CID_No { get; set; }          //text filed

        [MaxLength(200)]
        [Display(Name = "Company Address")]
        public string ATA_Cmpny_Addr { get; set; }    //text filed

        //following properties not show on page
        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public short ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public short MgrAllocatedBy { get; set; }
        public short MgrAllocatedTo { get; set; }
        public DateTime? MgrAllocatedDate { get; set; }

        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

        
        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        public byte Status { get; set; }
    }

    
    //public class TempPQUpdateReferenceViewModel
    //{
    //    public int ReferenceRowID { get; set; }

    //    #region Common for all Checks 

    //    public short ClientRowID { get; set; }
    //    public int PersonalRowID { get; set; }
    //    public int ClientPackageRowID { get; set; }
    //    public short CheckFamilyRowID { get; set; }
    //    public short SubCheckRowID { get; set; }
    //    public string UniqueComponentID { get; set; }

    //    #endregion
    //    [Display(Name = "Candidate Name")]
    //    public string RV_CandidateName { get; set; }      //text field

    //    [Display(Name = "Securitas Reference ID")]
    //    public string RV_Sec_Ref_Id { get; set; }      //text field

    //    [Display(Name = "Name of Organisation")]
    //    public string RV_OrganisationName { get; set; }      //text field

    //    [Display(Name = "Referee Name")]
    //    public string RV_RefereeName { get; set; }      //text field

    //    [Display(Name = "Referee Designation")]
    //    public string RV_Refere_Desig { get; set; }      //text field

    //    [Display(Name = "Referee Address")]
    //    public string RV_Refere_Add { get; set; }      //text field

    //    [Display(Name = "Referee's mobile number")]
    //    public string RV_Refre_MobNo { get; set; }      //text field

    //    [Display(Name = "Referee's Email id")]
    //    public string RV_Refre_Eid { get; set; }      //text field

    //    [Display(Name = "How long have you known her/him?")]
    //    public string RV_Know_Long { get; set; }      // text Area

    //    [Display(Name = "Tenure of the Employee")]
    //    public string RV_Tenure_Emp { get; set; }      // to & from calender

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? RV_Tenure_EmpFrom { get; set; }

    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime? RV_Tenure_EmpTo { get; set; }

    //    [Display(Name = "Designation")]
    //    public string RV_Dsg_RC { get; set; }      // text field

    //    [Display(Name = "Cost to Company")]
    //    public string RV_CTC { get; set; }      // text field

    //    [Display(Name = "Reason for leaving")]
    //    public string RV_Reason_Leav { get; set; }      // text Area

    //    [Display(Name = "Other Proof :")]
    //    public byte RV_OtherProof { get; set; }                  // CheckBox    Default- 0 otherwise 1

    //    [NotMapped]
    //    public bool RV_OtherProofBool
    //    {
    //        get { return RV_OtherProof > 0; }
    //        set { RV_OtherProof = value ? (byte)1 : (byte)0; }
    //    }

    //    [ValidateLargeFileCandidateUploadDocs]
    //    public HttpPostedFileBase OtherProofDoc { get; set; }

    //    [Display(Name = "Other Details1")]
    //    public string RV_OtherDetails { get; set; }     // text

    //    [Display(Name = "Other Details2")]
    //    public string RV_OtherDetails2 { get; set; }    //Text

    //    [Display(Name = "Other Details3")]
    //    public string RV_OtherDetails3 { get; set; }    //text

    //    [Display(Name = "Other Details4")]
    //    public string RV_OtherDetails4 { get; set; }    //text

    //    [Display(Name = "Other Details5")]
    //    public string RV_OtherDetails5 { get; set; }    //text

    //    [Display(Name = "Other Details6")]
    //    public string RV_OtherDetails6 { get; set; }    // text

    //    [Display(Name = "Other Details7")]
    //    public string RV_OtherDetails7 { get; set; }    //Text

    //    [Display(Name = "Other Details8")]
    //    public string RV_OtherDetails8 { get; set; }    //text

    //    [Display(Name = "Other Details9")]
    //    public string RV_OtherDetails9 { get; set; }    //text

    //    [Display(Name = "Other Details10")]
    //    public string RV_OtherDetails10 { get; set; }   //text

    //    [Display(Name = "CID No")]
    //    public string ATA_CID_No { get; set; }          //text filed

    //    [Display(Name = "Company Address")]
    //    public string ATA_Cmpny_Addr { get; set; }    //text filed

    //    //following properties not show on page
    //    public short CreatedBy { get; set; }
    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? OutDate { get; set; }
    //    public DateTime? InternalOutDate { get; set; }
    //    public short ModifiedBy { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public short MgrAllocatedBy { get; set; }
    //    public short MgrAllocatedTo { get; set; }
    //    public DateTime? MgrAllocatedDate { get; set; }

    //    [Display(Name = "Check Status : ")]
    //    public string CheckStatus { get; set; }

    //    [Display(Name = "Case Status : ")]
    //    public string CaseStatus { get; set; }

    //    [Display(Name = "Remarks : ")]
    //    public string Remarks { get; set; }

    //    public byte Status { get; set; }
    //}

    public class TempUpdateRefrnceRejectionViewModel
    {
        [ScaffoldColumn(false)]
        public int ReferenceRowID { get; set; }

        public short ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Check Status : ")]
        public string CheckStatus { get; set; }

    }

    public class TempPQReferenceList
    {
        //public short PQAddressListRowID { get; set; }


        public short AntecedentRowId { get; set; }

        public string AntecedentName { get; set; }
        public string FieldName { get; set; }
        public byte AntecedentTypeRowId { get; set; }
        //public short ClientRowID { get; set; }      

        //public int PersonalRowID { get; set; }       

        //public int ClientPackageRowID { get; set; }        

        //public short CheckFamilyRowID { get; set; }       

        //public short SubCheckRowID { get; set; }       

        //public string UniqueComponentID { get; set; }
    }
}
