using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModels.ClientViewModel
{
    public class CContractAgreementViewModel
    {
        [Display(Name = "Agreement ID")]
        public int ClientContractRowID { get; set; }

        [Display(Name = "Client ID")]
        public short ClientRowID { get; set; }
              
        [Display(Name = "Document Type")]
        public string DocumentType { get; set; }

        [Display(Name = "File Name")]
        public string FileName { get; set; }

       [Display(Name = "Upload Date")]
        public DateTime? Uploaddate { get; set; }

        [Display(Name = "Document Upload From")]
        public string DocumentUploadFrom { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }
    }
    public class AddCContractAgreementViewModel
    {
        [ScaffoldColumn(false)]
        public int AgreementRowID { get; set; }

        [ScaffoldColumn(false)]
        public short ClientRowID { get; set; }

        [ScaffoldColumn(false)]
        public string DocumentType { get; set; }

        [Display(Name = "Upload File")]
        public string FileName { get; set; }

        [Required]
        [Display(Name = "Upload File")]
        [ValidateLargeFileAttribute]
        public HttpPostedFileBase UplodFileName { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Uploaddate { get; set; }

        [ScaffoldColumn(false)]
        public string DocumentUploadFrom { get; set; }

        [MaxLength(200)]
        public string Remarks { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    public class CContractAgreementListPageModel
    {
        public IEnumerable<CContractAgreementViewModel> CContractAgreements { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class ExportCContractAgreementViewModel
    {
        public int ClientContractRowID { get; set; }       
        public string DocumentType { get; set; }
        public string FileName { get; set; }        
        public DateTime? Uploaddate { get; set; }
        public string DocumentUploadFrom { get; set; }
        public string Remarks { get; set; }
    }
}
