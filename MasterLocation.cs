using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class MasterLocation
    {
        public MasterLocation()
        {
            LocationRowID = 0;
            LocationName = string.Empty;
            PinCode = 0;
            DistrictRowID = 0;
            StateRowID = 0;
            CountryRowID = 0;
            Status = 1;
        }

        public int LocationRowID { get; set; }
        public string LocationName { get; set; }
        public int PinCode { get; set; }

        public short DistrictRowID { get; set; }
        public virtual MasterDistrict MasterDistrict { get; set; }

        public short StateRowID { get; set; }
        public virtual MasterState MasterState { get; set; }

        public short CountryRowID { get; set; }
        public virtual MasterCountry MasterCountry { get; set; }

        public byte Status { get; set; }
    }
}
