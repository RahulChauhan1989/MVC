using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterCountry
    {
        public MasterCountry()
        {
            CountryRowID = 0;
            CountryName = string.Empty;
            CountryCode = string.Empty;
            Status = 1;
        }

        public short CountryRowID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryCallingCode { get; set; }
        public string InternationalDialingPrefix { get; set; }
        public byte Status { get; set; }
    }
}
