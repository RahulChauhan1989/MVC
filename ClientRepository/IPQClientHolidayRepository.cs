using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IPQClientHolidayRepository
    {
         bool IsClientHolidayExist(short ClientRowID, short HoliRowID);

        void AddIPQClientHoliday(AddPQClientHolidayViewModel model);

        UpdatePQClientHolidayViewModel GetPQClientHolidayForUpdateById(short ClientHoliRowID);

        void UpdatePQClientHoliday(UpdatePQClientHolidayViewModel model);

        void DeletePQClientHoliday(short ClientHoliRowID);

        int SaveChanges();

        IEnumerable<PQClientHolidayViewModel> GetClientHolidays(short ClientRowId = 0);

        IEnumerable<HolidayViewModel> GetHolidayList();

        PQClientHolidayListPagedModel GetPQClientHoliday(int pageNo, int pageSize, string sort, string sortDir, string Search = "",short CId=0);
    }
}
