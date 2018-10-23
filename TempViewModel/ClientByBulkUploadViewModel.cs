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
    public class ClientByBulkUploadViewModel
    {
        [ScaffoldColumn(false)]
        public int ClientBulkUploadRowID { get; set; }
        [ScaffoldColumn(false)]
        public short ClientRowID { get; set; }

        [ScaffoldColumn(false)]
        public string ExcelFileName { get; set; }
        [Required]
        [Display(Name = "Excel Upload")]
        [ValidateLargeFileClientCandidateUploadExcelDocs]
        public HttpPostedFileBase IdentityExcel { get; set; }

        [ScaffoldColumn(false)]
        public string AttachDocName { get; set; }
        [Required]
        [ValidateLargeFileCandidateUploadExcelDocs]
        [Display(Name = "Attach Upload")]
        public HttpPostedFileBase IdentityDoc { get; set; }
        public string CandidateCheckOrPackage { get; set; }
        public byte Status { get; set; }

        public string UploadedBy { get; set; }
        public DateTime? UploadedDate { get; set; }
    }
   public class ClientByBulkUploadListPagedModel
    {
        public IEnumerable<ClientByBulkUploadListViewModel> PQClientCompany { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class ClientByBulkUploadListViewModel
    {
        public short ClientRowId { get; set; }
        public string ClientName { get; set; }

        [Display(Name = "Excel File")]
        public string ExcelFileName { get; set; }

        [Display(Name = "Attachment File")]
        public string AttachDocName { get; set; }

        public string UploadedBy { get; set; }
        public DateTime? UploadedDate { get; set; }
    }
}
