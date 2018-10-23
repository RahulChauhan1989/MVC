using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterDisposition
    {
        public MasterDisposition()
        {
            DispositionRowId = 0;
            Disposition = string.Empty;
            CheckFamilyRowID = 0;
            SeverityGridRowId = 0;
            IsSetDefault = 0;
            Status = 1;
        }

        public short DispositionRowId { get; set; }
        public string Disposition { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public byte SeverityGridRowId { get; set; }
        public virtual MasterSeverityGrid MasterSeverityGrid { get; set; }

        public byte IsSetDefault { get; set; }
        public byte Status { get; set; }

    }
}
