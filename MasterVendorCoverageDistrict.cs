using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class MasterVendorCoverageDistrict
    {
        public MasterVendorCoverageDistrict()
        {
            VCDistrictRowID = 0;
            VendorCoverageRowID = 0;
            DistrictRowID = 0;
            Status = 1;
        }

        public int VCDistrictRowID { get; set; }

        public int VendorCoverageRowID { get; set; }
        public virtual MasterVendorCoverage MasterVendorCoverage { get; set; }
        
        public short DistrictRowID { get; set; }
        public virtual MasterDistrict MasterDistrict { get; set; }
                
        public byte Status { get; set; }
    }
}
