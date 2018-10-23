using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterSeverityGrid
    {
        public MasterSeverityGrid()
        {
            SeverityGridRowId = 0;
            SeverityGrid = string.Empty;
            ColorName = string.Empty;
            ColorCode = string.Empty;
            Status = 1;
        }

        public byte SeverityGridRowId { get; set; }
        public string SeverityGrid { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public byte Status { get; set; }
    }
}
