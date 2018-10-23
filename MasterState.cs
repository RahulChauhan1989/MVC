using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterState
    {
        public MasterState()
        {
            StateRowID = 0;
            StateName = string.Empty;
            CountryRowID = 0;
            Status = 1;
        }

        public short StateRowID { get; set; }
        public string StateName { get; set; }

        public short CountryRowID { get; set; }
        public virtual MasterCountry MasterCountry { get; set; }

        public byte Status { get; set; }
    }
}
