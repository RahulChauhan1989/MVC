using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterHoliday
    {
        public  MasterHoliday()
        {
            HoliRowID=0;
            HoliTitle=string.Empty;
            HoliDate =DateTime.Now;
            HoliDay  =string.Empty;
            HoliMonth=string.Empty;
            HoliYear =string.Empty;
            Remarks  =string.Empty;
            AddInfo  =string.Empty;
            IsDefault=0;
            Status = 1;
        }

        public short  HoliRowID { get; set; }
        public string HoliTitle { get; set; }
        public DateTime HoliDate   { get; set; }
        public string HoliDay   { get; set; }
        public string HoliMonth { get; set; }
        public string HoliYear   { get; set; }
        public string Remarks    { get; set; }
        public string AddInfo    { get; set; }        
        public byte   IsDefault { get; set; }
        public byte   Status    { get; set; }
    }
}
