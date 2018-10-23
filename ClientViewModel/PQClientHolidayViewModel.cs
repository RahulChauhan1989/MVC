using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class PQClientHolidayViewModel
    {
        [Display(Name ="ID :")]
        [ScaffoldColumn(false)]
        public short ClientHoliRowID { get; set; }

        [Display(Name = "Holi Name :")]
        public short HoliRowID { get; set; }

        [Display(Name = "Holi Name :")]
        public string HoliName { get; set; }

        [Display(Name = "Client Name :")]
        public short ClientRowID { get; set; }

        public string HoliRowIDs { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Client Name :")]
        public string ClientName { get; set; }

        public DateTime? HolidayDate { get; set; }

        [Display(Name ="Status :")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    public class AddPQClientHolidayViewModel
    {
        [Display(Name = "ID :")]
        [ScaffoldColumn(false)]
        public short ClientHoliRowID { get; set; }

        [Display(Name = "Holi Name :")]
        public short HoliRowID { get; set; }

        public string HoliRowIDs { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Client Name :")]
        public short ClientRowID { get; set; }
       
        [Display(Name = "Status :")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    public class UpdatePQClientHolidayViewModel
    {
        [Display(Name = "ID :")]
        [ScaffoldColumn(false)]
        public short ClientHoliRowID { get; set; }

        [Display(Name = "Holi Name :")]
        public short HoliRowID { get; set; }

        [Display(Name = "Holi Name :")]
        public string HoliName { get; set; }

        [Display(Name = "Client Name :")]
        public short ClientRowID { get; set; }

        [Display(Name = "Client Name :")]
        public string ClientName { get; set; }

        [Display(Name = "Status :")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class PQClientHolidayListPagedModel
    {
        public IEnumerable<PQClientHolidayViewModel> PQClientHolidays { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

}
