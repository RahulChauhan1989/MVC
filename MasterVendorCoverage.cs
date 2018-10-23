using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterVendorCoverage
    {
        public MasterVendorCoverage()
        {
            VendorCoverageRowID = 0;
            VendorRowID = 0;
            CheckFamilyRowID = 0;
            CountryRowID = 0;
            StateRowID = 0;
            VendorCost = 0;
            AdditionalCosting = 0;
            AdditionalCost = 0;
            Level1TAT = 0;
            Level2TAT = 0;
            Remarks = string.Empty;
            Status = 1;
        }

        public int VendorCoverageRowID { get; set; }

        public short VendorRowID { get; set; }
        public virtual MasterVendor MasterVendor { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public short CountryRowID { get; set; }
        public virtual MasterCountry MasterCountry { get; set; }

        public short StateRowID { get; set; }
        public virtual MasterState MasterState { get; set; }

        public double VendorCost { get; set; }
        public byte AdditionalCosting { get; set; }
        public double AdditionalCost { get; set; }
        public byte Level1TAT { get; set; }
        public byte Level2TAT { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }
    }
}
