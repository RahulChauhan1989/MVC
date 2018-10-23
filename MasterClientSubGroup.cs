using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterClientSubGroup
    {
        public MasterClientSubGroup()
        {
            ClientSubGroupID = 0;
            ClientAbbRowID = 0;
            ClientSubGroupName = string.Empty;
            Status = 1;
        }

        public short ClientSubGroupID { get; set; }
        public string ClientSubGroupName { get; set; }

        public short ClientAbbRowID { get; set; }
        public virtual MasterClientAbbreviation MasterClientAbbreviation { get; set; }

        public byte Status { get; set; }
    }
}
