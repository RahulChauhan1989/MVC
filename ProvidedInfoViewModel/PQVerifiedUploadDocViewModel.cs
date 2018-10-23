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
    public class PQVerifiedUploadDocViewModel
    {
        public Int64 VerifiedUploadRowID { get; set; }
        public int PersonalRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }
        public string DocumentUploadFrom { get; set; }   //Provided / Verified
        public string DocumentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Remarks { get; set; }
        public DateTime? UploadDate { get; set; }
        public byte StatusDocxConvert { get; set; }      //Default - 0 otherwise 1
        public byte StatusPDF2DOCXConvert { get; set; }  //Default - 0 otherwise 1
        public string PDF_FileName { get; set; }
        public byte Status { get; set; }
    }

    public class UploadedDocViewModel
    {
        public Int64 VerifiedUploadRowID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Remarks { get; set; }      
    }

    public class PQAddVerifiedUploadDocViewModel
    {
        [Display(Name ="ID")]
        public Int64 VerifiedUploadRowID { get; set; }

        public int PersonalRowID { get; set; }
        public short CheckFamilyRowID { get; set; }

        [Required]
        [Display(Name = "Check Name : ")]
        public short SubCheckRowID { get; set; }
        public short Chec { get; set; }
        [Display(Name = "Document Upload From : ")]
        public string DocumentUploadFrom { get; set; }   //Provided / Verified
         [Display(Name = "Document Type : ")]
        public string DocumentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase UploadDoc { get; set; }
        
        [Display(Name = "Description : ")]
        public string Remarks { get; set; }

        public DateTime? UploadDate { get; set; }
        public byte StatusDocxConvert { get; set; }      //Default - 0 otherwise 1
        public byte StatusPDF2DOCXConvert { get; set; }  //Default - 0 otherwise 1
        public string PDF_FileName { get; set; }

        [Display(Name ="Document not applicable : ")]
        public byte NADoc { get; set; }

        [NotMapped]
        public bool NABool
        {
            get { return NADoc > 0; }
            set { NADoc = value ? (byte)1 : (byte)0; }
        }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        public byte InsuffDoc { get; set; }
    }

    public class PQVerifiedUploadDocListPagedModel
    {
        public IEnumerable<PQVerifiedUploadDocViewModel> UploadedDocInfo { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class UploadedDocForRWQCTMViewModel
    {
        public Int64 VerifiedUploadRowID { get; set; }
        public int PersonalRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }
        public string DocumentUploadFrom { get; set; }   //Provided / Verified
        public string DocumentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Remarks { get; set; }
        public DateTime? UploadDate { get; set; }
        public byte RptArtiFacts { get; set; }
        public byte RptArtiFactOrder { get; set; }
    }

    public class UploadedDocListForRWQCTMPagedModel
    {
        public int PersonalRowID { get; set; }
        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }
        public string AllDocIds { get; set; }
        public IEnumerable<UploadedDocForRWQCTMViewModel> UploadedDocForRQQCTM { get; set; }
    }

    public class UploadedCaseDocForRWQCTMViewModel
    {
        public Int64 CaseDocRowID { get; set; }
        public int PersonalRowID { get; set; }
        public string DocumentUploadFrom { get; set; }   //Provided / Verified
        public string DocumentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Remarks { get; set; }
        public DateTime? UploadDate { get; set; }
        public byte RptArtiFacts { get; set; }
        public byte RptDisplayOrder { get; set; }
    }

    public class UploadedCaseDocListForRWQCTMPagedModel
    {
        public int PersonalRowID { get; set; }
        public string AllDocIds { get; set; }
        public IEnumerable<UploadedCaseDocForRWQCTMViewModel> UploadedCaseDocForRQQCTM { get; set; }
    }

    public class MapUploadedDocRWQCTMModel
    {
        public Int64 VerifiedUploadRowID { get; set; }
        public byte RptArtiFacts { get; set; }
        public byte RptArtiFactOrder { get; set; }
    }

    public class VerifiedUploadDocViewModel
    {
        [ScaffoldColumn(false)]      
        public Int64 VerifiedUploadRowID { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public int PersonalRowID { get; set; }

        [ScaffoldColumn(false)]
        [Required]     
        public short SubCheckRowID { get; set; }

        [ScaffoldColumn(false)]
        public string CheckStatus { get; set; }

        //[ScaffoldColumn(false)]
        //public short ClientRowID { get; set; }

        //[ScaffoldColumn(false)]
        //public int CheckfiledRowID { get; set; }

        //[ScaffoldColumn(false)]
        //public int CheckfiledVerRowID { get; set; }

        //[ScaffoldColumn(false)]
        //public short CheckFamilyRowID { get; set; }

        [ScaffoldColumn(false)]      
        public string DocumentUploadFrom { get; set; }   //Provided / Verified

        [Display(Name = "Document Type :")]
        [Required]
        public string DocumentType { get; set; } // Varification Document

        [ScaffoldColumn(false)]
        public string FileName { get; set; }

        [ScaffoldColumn(false)]
        public string FilePath { get; set; }
        
        [Display(Name ="Select Document :")]     
        [Required]  
        [ValidateLargeFileAttribute]
        public HttpPostedFileBase UploadDoc { get; set; }

        [Display(Name = "Description : ")]
        [Required]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UploadDate { get; set; }

        [ScaffoldColumn(false)]
        public byte StatusDocxConvert { get; set; }      //Default - 0 otherwise 1

        [ScaffoldColumn(false)]
        public byte StatusPDF2DOCXConvert { get; set; }  //Default - 0 otherwise 1

        [ScaffoldColumn(false)]
        public string PDF_FileName { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class VerifiedUploadAddressDocViewModel
    {
        [Required]
        public int PersonalRowID { get; set; }
        
        [Required]
        public short SubCheckRowID { get; set; }
        public string DocumentUploadFrom { get; set; }        
        public string DocumentType { get; set; }
        
        public string FileName { get; set; }
        public string FilePath { get; set; }
        
        [ValidateFileWithNullCheckAttributeInPartner]
        [Display(Name = "Select Document For Signature :")]
        public HttpPostedFileBase UploadSignatureDoc { get; set; }
        
        [ValidateFileWithNullCheckAttributeInPartner]
        [Display(Name = "Select Document For IDProof :")]
        public HttpPostedFileBase UploadIDProofDoc { get; set; }
        
        [ValidateFileWithNullCheckAttributeInPartner]
        [Display(Name = "Select Document For House photo :")]
        public HttpPostedFileBase UploadHousephotoDoc { get; set; }
        
        [ValidateFileWithNullCheckAttributeInPartner]
        [Display(Name = "Select Document For Landmark Photo :")]
        public HttpPostedFileBase UploadLandmarkPhotoDoc { get; set; }

        public string Remarks { get; set; }
        public DateTime? UploadDate { get; set; }
        public string CheckStatus { get; set; }        
        public byte Status { get; set; }
    }

    public class AddTempPQVerifiedUploadDocViewModel
    {
        [Display(Name = "ID")]
        public Int64 VerifiedUploadRowID { get; set; }

        public int PersonalRowID { get; set; }

        [Required]
        [Display(Name = "Select Check : ")]
        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        [Display(Name = "Document Upload From : ")]
        public string DocumentUploadFrom { get; set; }   //Provided / Verified

        [Display(Name = "Document Type : ")]
        public string DocumentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        // [Required]
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase UploadDoc { get; set; }

        //public IEnumerable<HttpPostedFileBase> UploadDoc { get; set; }

        [Display(Name = "Description : ")]
        public string Remarks { get; set; }

        public DateTime? UploadDate { get; set; }
        public byte StatusDocxConvert { get; set; }      //Default - 0 otherwise 1
        public byte StatusPDF2DOCXConvert { get; set; }  //Default - 0 otherwise 1
        public string PDF_FileName { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    
    public class TempPQVerifiedUploadDocListPagedModel
    {
        public IEnumerable<PQVerifiedUploadDocViewModel> TempUploadedDocInfo { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

}
