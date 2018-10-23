using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterDistrict
    {
        public MasterDistrict()
        {
            DistrictRowID = 0;
            DistrictName = string.Empty;
            StateRowID = 0;
            CountryRowID = 0;
            Status = 1;
        }

        public short DistrictRowID { get; set; }
        public string DistrictName { get; set; }

        public short StateRowID { get; set; }
        public virtual MasterState MasterState { get; set; }

        public short CountryRowID { get; set; }
        public virtual MasterCountry MasterCountry { get; set; }

        public byte Status { get; set; }
    }
}
