using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class PQClientHoliday
    {
        public PQClientHoliday()
        {
            ClientHoliRowID = 0;
            HoliRowID = 0;
            ClientRowID = 0;
            Status = 1;
        }
        public short ClientHoliRowID { get; set; }

        public short HoliRowID { get; set; } 
        public virtual MasterHoliday MasterHoliday { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public byte Status { get; set; }

    }
}
