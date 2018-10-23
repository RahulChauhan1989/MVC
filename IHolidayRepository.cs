using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IHolidayRepository
    {
        bool IsHolidayExist(string HolidayTitle,DateTime HoliDate);

        bool IsHolidayExist(string HolidayTitle, DateTime HoliDate,short HoliRowID);

        void AddHoliday(AddHolidayViewModel model);

        UpdateHolidayViewModel GetHolidayForUpdateById(short HolidayRowID);

      
        void UpdateHoliday(UpdateHolidayViewModel model);

        int SaveChanges();

        IEnumerable<HolidayViewModel> GetHolidays(DateTime currDate, DateTime dDate);

        HolidayListPagedModel GetHolidays(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        IEnumerable<HolidayExportViewModel> GetHolidayesForExport();

        void HolidayIsDefault(short Id = 0, string IsDefault = "");

        void HolidayActiveInActive(short Id = 0, string Status = "");

    }
}
