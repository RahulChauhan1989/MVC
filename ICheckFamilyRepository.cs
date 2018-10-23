using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ICheckFamilyRepository
    {
        bool IsCheckFamilyExist(string CheckFamilyName);

        void AddCheckFamily(AddCheckFamilyViewModel model);

        UpdateCheckFamilyViewModel GetCheckFamilyForUpdateById(short CFRowID);

        void UpdateCheckFamily(UpdateCheckFamilyViewModel model);

        void DeleteCheckFamily(short CFRowID);

        int SaveChanges();

        void ActiveCheckFamily(short id = 0, string checkeds = "");

        IEnumerable<CheckFamilyViewModel> GetCheckFamily();

        IEnumerable<CheckFamilyExportViewModel> GetCheckFamiliesForExport();

        CheckFamilyListPagedModel GetCheckFamily(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
