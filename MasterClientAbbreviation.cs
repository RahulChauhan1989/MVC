using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterClientAbbreviation
    {
        public MasterClientAbbreviation()
        {
            ClientAbbRowID = 0;
            ClientName = string.Empty;
            ClientAbbreviation = string.Empty;
            Status = 1;
        }

        public short ClientAbbRowID { get; set; }
        public string ClientName { get; set; }
        public string ClientAbbreviation { get; set; }
        public byte Status { get; set; }
    }
}
