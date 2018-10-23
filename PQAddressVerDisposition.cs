using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQAddressVerDisposition
    {
        public Int64 AddressVerDispositionRowID { get; set; }

        public int AddressVerRowID { get; set; }
        public virtual PQAddressVer PQAddressVer { get; set; }

        public int ClientDispositionRowId { get; set; }
        public virtual PQClientDisposition PQClientDisposition { get; set; }
    }
}
