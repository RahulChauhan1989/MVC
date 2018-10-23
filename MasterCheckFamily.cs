using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterCheckFamily
    {
        public MasterCheckFamily()
        {
            CheckFamilyRowID = 0;
            CheckFamilyName = string.Empty;
            Status = 1;
        }
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName  { get; set; }
        public byte Status { get; set; }
    }
}
