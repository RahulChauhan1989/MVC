using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProvidedInfoViewModel
{
    public class CaseActionHistoryViewModel
    {
        public int CaseAHRowID { get; set; }
        public int PersonalRowID { get; set; }
        public string UpdatedByNameDesig { get; set; }
        public string Remarks { get; set; }
        public string CaseStatus { get; set; }
        public short UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte Status { get; set; }
    }

    public class AddCaseActionHistoryViewModel
    {
        public int CaseAHRowID { get; set; }

        [Required]
        public int PersonalRowID { get; set; }

        [MaxLength(5000)]
        public string Remarks { get; set; }

        [MaxLength(50)]
        public string CaseStatus { get; set; }
        public short UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedByNameDesig { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class CaseActionHistoryListPagedModel
    {
        public IEnumerable<CaseActionHistoryViewModel> CaseActionHistories { get; set; }
        //public int PageSize { get; set; }
        //public int TotalRecords { get; set; }
    }
}
