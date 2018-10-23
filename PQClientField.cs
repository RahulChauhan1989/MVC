using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQClientField
    {
        public PQClientField()
        {
            ClientFieldRowID = 0;
            ClientRowID = 0;
            CheckFamilyRowID = 0;
            SubCheckRowID = 0;
            AntecedentRowId = 0;
            CADisplayName = string.Empty;
            Status = 1;
        }

        public int ClientFieldRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public short SubCheckRowID { get; set; }
        public virtual MasterSubCheckFamily MasterSubCheckFamily { get; set; }

        public short AntecedentRowId { get; set; }
        public virtual MasterAntecedent MasterAntecedent { get; set; }

        public string CADisplayName { get; set; }

        public byte Status { get; set; }
    }
}
