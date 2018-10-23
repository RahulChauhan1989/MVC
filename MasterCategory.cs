using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterCategory
    {
        public MasterCategory()
        {
            CategoryRowID = 0;
            CategoryName = string.Empty;
            Status = 1;
        }
        
        public byte CategoryRowID { get; set; }
        public string CategoryName { get; set; }
        public byte Status { get; set; }
    }
}
