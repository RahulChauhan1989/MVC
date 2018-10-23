using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CheckActionHistory
    {
        public CheckActionHistory()
        {
            CheckAHRowID = 0;
            SubCheckRowID = 0;
            UpdatedBy = 0;
            CheckStatus = string.Empty;
            Remarks = string.Empty;
            Status = 1;
        }

        public int CheckAHRowID { get; set; }

        public int PersonalRowID { get; set; }
        public virtual PQPersonal PQPersonal { get; set; }

        public short SubCheckRowID { get; set; }
        public virtual MasterSubCheckFamily MasterSubCheckFamily { get; set; }

        public string CheckStatus { get; set; }
        public string Remarks { get; set; }
        public short UpdatedBy { get; set; }
        public string UpdatedByNameDesig { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public byte Status { get; set; }
    }
}
