using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterSubCheckFamily
    {
        public MasterSubCheckFamily()
        {
            SubCheckRowID = 0;
            SubCheckName = string.Empty;
            CheckFamilyRowID = 0;
            Status = 1;
        }
        public short SubCheckRowID { get; set; }
        public string SubCheckName { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public byte InternalTAT { get; set; }
        public byte TAT { get; set; }
        public double CostPerCase { get; set; }
        public byte Status { get; set; }

    }
}
