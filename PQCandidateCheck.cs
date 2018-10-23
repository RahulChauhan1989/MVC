using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQCandidateCheck
    {
        public PQCandidateCheck()
        {
            CandCheckRowID = 0;
            ClientRowID = 0;
            PersonalRowID = 0;
            ClientPackageRowID = 0;
            ClientCheckRowID = 0;
            Status = 1;
        }

        public Int64 CandCheckRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public int PersonalRowID { get; set; }
        public virtual PQPersonal PQPersonal { get; set; }

        public int ClientPackageRowID { get; set; }
        public int ClientCheckRowID { get; set; }

        public byte Status { get; set; }
    }
}