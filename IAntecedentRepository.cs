using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IAntecedentRepository
    {
        UpdateAntecedentViewModel GetAntecedentForUpdateById(short AntecedentRowID);

        void UpdateAntecedent(UpdateAntecedentViewModel model);
      
        int SaveChanges();

        // IEnumerable<AntecedentViewModel> GetAntecedents();

        IEnumerable<AntecedentExportViewModel> GetAntecedentesForExport();
        IEnumerable<AntecedentViewModel> GetAntecedents(short CheckMasterId);

        void ActiveAntecedent(short id = 0, string checkeds = "");

        void SetDefaultAntecedent(short id = 0, string checkeds = "");

        IEnumerable<AntecedentViewModel> GetAntecedentAutoComplete(string Antecedent, short CheckFamilyRowID);

        AntecedentListPageModel GetAntecedents(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CheckFamilyRowID = 0);
    }
}
