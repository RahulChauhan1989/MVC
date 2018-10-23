using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQClientDisposition
    {
        public PQClientDisposition()
        {
            ClientDispositionRowId = 0;
            ClientRowID = 0;
            CheckFamilyRowID = 0;
            DispositionRowId = 0;
            SeverityGridRowId = 0;
            Status = 1;
        }

        public int ClientDispositionRowId { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public short DispositionRowId { get; set; }
        public virtual MasterDisposition MasterDisposition { get; set; }

        public byte SeverityGridRowId { get; set; }
        public virtual MasterSeverityGrid MasterSeverityGrid { get; set; }
        
        public byte Status { get; set; }
    }
}
