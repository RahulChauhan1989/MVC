using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProvidedInfoViewModel
{
    public class CheckActionHistoryViewModel
    {
        public int CheckAHRowID { get; set; }

        public int PersonalRowID { get; set; }

        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        public string CheckStatus { get; set; }
        public string Remarks { get; set; }
        public short UpdatedBy { get; set; }
        public string UpdatedByNameDesig { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte Status { get; set; }
    }

    public class AddCheckActionHistoryViewModel
    {
        public int CheckAHRowID { get; set; }

        [Required]
        public int PersonalRowID { get; set; }

        [Required]
        public short SubCheckRowID { get; set; }

        [MaxLength(50)]
        public string CheckStatus { get; set; }

        [MaxLength(5000)]
        public string Remarks { get; set; }
        public short UpdatedBy { get; set; }
        public string UpdatedByNameDesig { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte Status { get; set; }
    }
}
