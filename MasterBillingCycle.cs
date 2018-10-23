using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterBillingCycle
    {
        public MasterBillingCycle()
        {
            BillingRowID = 0;
            BillingCycle = string.Empty;
            Status = 1;
        }

        public byte BillingRowID { get; set; }
        public string BillingCycle { get; set; }
        public byte Status { get; set; }
    }
}
