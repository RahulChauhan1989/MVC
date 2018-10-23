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
    public class PQVerifiedUploadCaseDocViewModel
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
        //public byte StatusDocxConvert { get; set; }      //Default - 0 otherwise 1
        //public byte StatusPDF2DOCXConvert { get; set; }  //Default - 0 otherwise 1
        //public string PDF_FileName { get; set; }
        public byte Status { get; set; }
    }

    public class AddPQVerifiedUploadCaseDocViewModel
    {
        [Display(Name = "ID")]
        public Int64 VerifiedUploadRowID { get; set; }

        public int PersonalRowID { get; set; }

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
        //public byte StatusDocxConvert { get; set; }      //Default - 0 otherwise 1
        //public byte StatusPDF2DOCXConvert { get; set; }  //Default - 0 otherwise 1
        //public string PDF_FileName { get; set; }

        [Display(Name = "Letter Of Authorization :")]
        public byte LOA { get; set; }                  // CheckBox    Default- 0 otherwise 1
        [NotMapped]
        public bool LOABool
        {
            get { return LOA > 0; }
            set { LOA = value ? (byte)1 : (byte)0; }
        }
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase LOADoc { get; set; }

        [Display(Name = "BGV Pages :")]
        public byte BGVPage { get; set; }               // CheckBox    Default- 0 otherwise 1
        [NotMapped]
        public bool BGVPageBool
        {
            get { return BGVPage > 0; }
            set { BGVPage = value ? (byte)1 : (byte)0; }
        }
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase BGVPageDoc { get; set; }

        [Display(Name = "Other :")]
        public byte Other { get; set; }               // CheckBox    Default- 0 otherwise 1
        [NotMapped]
        public bool OtherBool
        {
            get { return Other > 0; }
            set { Other = value ? (byte)1 : (byte)0; }
        }
        [ValidateLargeFileCandidateUploadDocs]
        public HttpPostedFileBase OtherDoc { get; set; }

        [Display(Name = "N/A :")]
        public byte NA { get; set; }                    // CheckBox    Default- 0 otherwise 1s

        [NotMapped]
        public bool NABool
        {
            get { return NA > 0; }
            set { NA = value ? (byte)1 : (byte)0; }
        }
              
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

}
