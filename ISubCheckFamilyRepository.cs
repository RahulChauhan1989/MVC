using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ISubCheckFamilyRepository
    {
        bool IsSubCheckFamilyExist(string SubCheckName, short id);
        bool IsSubCheckFamilyExist(string SubCheckName, short CheckFamilyId, short SubCheckId);

        void AddSubCheckFamily(AddSubCheckFamilyViewModel model);

        UpdateSubCheckFamilyViewModel GetSubCheckFamilyForUpdateById(short CFRowID);

        void UpdateSubCheckFamily(UpdateSubCheckFamilyViewModel model);

        void DeleteSubCheckFamily(short CFRowID);

        int SaveChanges();

        IEnumerable<SubCheckFamilyViewModel> GetSubCheckFamily();

        IEnumerable<SubCheckFamilyExportViewModel> GetSubCheckFamiliesForExport();

        SubCheckFamilyListPagedModel GetSubCheckFamily(int pageNo, int pageSize, string sort, string sortDir, short CheckFamilyRowID = 0, string Search = "");

        void ActiveSubCheckFamily(short id = 0, string checkeds = "");
    }
}
