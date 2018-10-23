using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IDispositionRepository
    {
        bool IsDispositionExist(string DispositionName);

        void AddDisposition(AddDispositionViewModel model);

        UpdateDispositionViewModel GetDispositionForUpdateById(short DispositionID);

        void UpdateDisposition(UpdateDispositionViewModel model);

        void ActiveDisposition(short id = 0, string checkeds = "");

        void SetDefaultDisposition(short id = 0, string checkeds = "");

        void DeleteDisposition(short DispositionID);

        int SaveChanges();

        IEnumerable<DispositionExportViewModel> GetDispositionsForExport();

        IEnumerable<DispositionViewModel> GetDisposition();

        IEnumerable<DispositionViewModel> GetDispositionAutoComplete(string Disposition, short CheckFamilyRowID );

        DispositionListPagedModel GetDisposition(int pageNo, int pageSize, string sort, string sortDir, short CheckFamilyRowID, string Search = "");
    }
}
