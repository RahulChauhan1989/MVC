using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IDegreeTypeRepository
    {
        bool IsDegreeTypeExist(string DegreeTypeName);

        void AddDegreeType(AddDegreeTypeViewModel model);

        UpdateDegreeTypeViewModel GetDegreeTypeForUpdateById(short DegreeTypeRowID);

        void UpdateDegreeType(UpdateDegreeTypeViewModel model);

        void DeleteDegreeType(short CRowID);

        int SaveChanges();

        void ActiveDegree(short id = 0, string checkeds = "");

        IEnumerable<DegreeTypeViewModel> GetDegreeTypes();

        IEnumerable<DegreeViewModel> GetDegreeForExport();

        DegreeTypeListPagedModel GetDegreeType(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
