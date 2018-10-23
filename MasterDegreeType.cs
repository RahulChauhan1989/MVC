using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterDegreeType
    {
        public MasterDegreeType()
        {
            DegreeRowID = 0;
            DegreeType = string.Empty;
            Status = 1;
        }
        public short DegreeRowID { get; set; }
        public string DegreeType { get; set; }
        public byte Status { get; set; }
    }
}
