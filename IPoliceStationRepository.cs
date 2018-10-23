using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IPoliceStationRepository
    {
        bool IsPoliceStationExist(string PoliceStationName);

        void ActivePoliceStation(short id = 0, string checkeds = "");

        void AddStationRepository(AddPoliceStationViewModel model);

        UpdatePoliceStationViewModel GetPoliceStationrForUpdateById(short PoliceStationRowID);

        PoliceStationViewModel GetPoliceStationForDetailsById(short PoliceStationRowID);

        void UpdatePoliceStation(UpdatePoliceStationViewModel model);

        bool IsPoliceStationExist(short PoliceStationRowID, string PoliceStationName);

        void DeletePoliceStation(short CRowID);

        int SaveChanges();

        IEnumerable<PoliceStationViewModel> GetPoliceStations();

        IEnumerable<PoliceStationExportViewModel> GetPoliceStationsForExport();

        PoliceStationListPagedModel GetPoliceStation(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
