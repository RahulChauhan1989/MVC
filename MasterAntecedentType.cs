using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterAntecedentType
    {
        public MasterAntecedentType()
        {
            AntecedentTypeRowId = 0;
            AntecedentTypeName = string.Empty;
            Status = 1;
        }

        public byte AntecedentTypeRowId { get; set; }
        public string AntecedentTypeName { get; set; }
        public byte Status { get; set; }
    }
}
