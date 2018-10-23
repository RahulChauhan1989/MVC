using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels.TempViewModel
{
    class ClientUploadDocViewModel
    {
    }

    public class TempPQVerifiedUploadDocsViewModel
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

    public class TempPQVerifiedUploadDocsInfoListPagedModel
    {
        public IEnumerable<TempPQVerifiedUploadDocsViewModel> ClientUploadDocInfo { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    public class AddUploadDocByHRViewModel
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
}
