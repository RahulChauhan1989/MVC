using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ILocationRepository
    {
        bool IsLocationExist(string LocationName);

        void AddLocation(AddLocationViewModel model);

        UpdateLocationViewModel GetLocationForUpdateById(int LocationRowID);

        void UpdateLocation(UpdateLocationViewModel model);

        void DeleteLocation(short CRowID);

        int SaveChanges();

        void ActiveLocation(short id = 0, string checkeds = "");

        IEnumerable<LocationViewModel> GetLocations();

        IEnumerable<LocationExportViewModel> GetLocationesForExport();

        LocationListPagedModel GetLocation(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
