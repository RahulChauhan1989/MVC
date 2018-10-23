using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class HolidayViewModel
    {
        [Display(Name = "ID")]
        public short HoliRowID { get; set; }

        [Display(Name = "Title")]
        public string HoliTitle { get; set; }

        [Display(Name = "Date")]
        public DateTime HoliDate { get; set; }

        [Display(Name = "Day")]
        public string HoliDay { get; set; }

        [Display(Name = "Month")]
        public string HoliMonth { get; set; }

        [Display(Name = "Year")]
        public string HoliYear { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Additional Comment")]
        public string AddInfo { get; set; }

        [Display(Name = "IsDefault")]
        public byte IsDefault { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class AddHolidayViewModel
    {
        [Display(Name = "ID : ")]
        public short HoliRowID { get; set; }

        [Required]
        [Display(Name = "Title : ")]
        public string HoliTitle { get; set; }

        [Required]
        [Display(Name = "Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HoliDate { get; set; }

        [Display(Name = "Day : ")]
        public string HoliDay { get; set; }

        [Display(Name = "Month : ")]
        public string HoliMonth { get; set; }

        [Display(Name = "Year : ")]
        public string HoliYear { get; set; }

        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        [Display(Name = "Additional Comment : ")]
        public string AddInfo { get; set; }

        [Display(Name = "IsDefault : ")]
        public bool IsDefault { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status : ")]
        public byte Status { get; set; }
    }

    public class UpdateHolidayViewModel
    {
        [Required]
        [Display(Name = "ID : ")]
        public short HoliRowID { get; set; }

        [Required]
        [Display(Name = "Title : ")]
        public string HoliTitle { get; set; }

        [Required]
        [Display(Name = "Date : ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HoliDate { get; set; }

        [Display(Name = "Day : ")]
        public string HoliDay { get; set; }

        [Display(Name = "Month : ")]
        public string HoliMonth { get; set; }

        [Display(Name = "Year : ")]
        public string HoliYear { get; set; }

        [Display(Name = "Remarks : ")]
        public string Remarks { get; set; }

        [Display(Name = "Additional Comment : ")]
        public string AddInfo { get; set; }

        [Display(Name = "IsDefault : ")]
        public bool IsDefault { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Status : ")]
        public byte Status { get; set; }
    }

    public class HolidayListPagedModel
    {
        public IEnumerable<HolidayViewModel> Holidays { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public  class HolidayExportViewModel
    {
        public short RowID { get; set; }
        public string HolidayTitle { get; set; }
        public DateTime HoliDate { get; set; }
        public string HoliDay { get; set; }
        //public string HoliMonth { get; set; }
        //public string HoliYear { get; set; }
        public string Remarks { get; set; }
        //public string AddInfo { get; set; }
        //public byte IsDefault { get; set; }
        //public byte Status { get; set; }
    }
}
