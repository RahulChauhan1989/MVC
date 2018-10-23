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
    public class UplodDocsForDEScanViewModel
    {
        public int PersonalRowID { get; set; }
        public int VerificationRowID { get; set; }
        public short ClientRowID { get; set; }       
        public short ChFamilRowId { get; set; }        
        public short SubCheckRowID { get; set; }
        public string SecuritasID { get; set; }
        public string UniqueComponentId { get; set; }
        public string RedirectPage { get; set; }

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

        [Display(Name = "Document not applicable : ")]
        public byte NADoc { get; set; }

        [NotMapped]
        public bool NABool
        {
            get { return NADoc > 0; }
            set { NADoc = value ? (byte)1 : (byte)0; }
        }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

    }

    public class InsuffCheckClearViewModel
    {
        public int PersonalRowID { get; set; }
        public int CheckRowID { get; set; }
        public short ClientRowID { get; set; }
        public short ChFamilRowId { get; set; }
        public short SubCheckRowID { get; set; }

        [Display(Name = "Check Name : ")]
        public string SubCheckName { get; set; }
        public string SecuritasID { get; set; }
        public string UniqueComponentId { get; set; }

        [Display(Name = "Document Upload From : ")]
        public string DocumentUploadFrom { get; set; }   //Provided / Verified

        [Display(Name = "Document Type : ")]
        public string DocumentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase UploadDoc { get; set; }

        //[Display(Name = "Document not applicable : ")]
        //public byte NADoc { get; set; }
        //[NotMapped]
        //public bool NABool
        //{
        //    get { return NADoc > 0; }
        //    set { NADoc = value ? (byte)1 : (byte)0; }
        //}

        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        public DateTime? UploadDate { get; set; }
        public byte StatusDocxConvert { get; set; }      //Default - 0 otherwise 1
        public byte StatusPDF2DOCXConvert { get; set; }  //Default - 0 otherwise 1

        [Display(Name = "Insuff Reason : ")]
        public string INFReason { get; set; }

    }

}
