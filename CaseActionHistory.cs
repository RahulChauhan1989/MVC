using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CaseActionHistory
    {
        public CaseActionHistory()
        {
            CaseAHRowID = 0;
            UpdatedBy = 0;
            PersonalRowID = 0;
            Remarks = string.Empty;
            CaseStatus = string.Empty;
            Status = 1;
        }

        public int CaseAHRowID { get; set; }

        public int PersonalRowID { get; set; }
        public virtual PQPersonal PQPersonal { get; set; }

        public string Remarks { get; set; }
        public string CaseStatus { get; set; }
        public short UpdatedBy { get; set; }
        public string UpdatedByNameDesig { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte Status { get; set; }
    }
}
