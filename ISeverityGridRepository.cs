using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ISeverityGridRepository
    {
        bool IsSeverityGridExist(string SeverityGridName);

        bool IsSeverityGridExist(string SeverityGridName, short Id);

        void AddSeverityGrid(AddSeverityGridViewModel model);

        UpdateSeverityGridViewModel GetSeverityGridForUpdateById(short SeverityGridId);

        void UpdateSeverityGrid(UpdateSeverityGridViewModel model);

        void DeleteSeverityGrid(short SeverityGridId);

        int SaveChanges();

        void ActiveSeverity(short id = 0, string checkeds = "");

        IEnumerable<SeverityGridViewModel> GetSeverityGrid();

        IEnumerable<SeverityGridExportViewModel> GetSeverityGridesForExport();

        SeverityGridListPagedModel GetSeverityGrid(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
