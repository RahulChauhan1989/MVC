using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IUniversityRepository
    {
        bool IsUniversityExist(string UniversityName);

        bool IsUniversityExist(short UniversityRowID, string UniversityName);

        void AddUniversity(AddUniversityViewModel model);

        UpdateUniversityViewModel GetUniversityForUpdateById(short UniversityRowID);

        UniversityViewModel GetUniversityForDetailsById(short UniversityRowID);

        void UpdateUniversity(UpdateUniversityViewModel model);

        void DeleteUniversity(short CRowID);

        int SaveChanges();

        void ActiveUniversity(short id = 0, string checkeds = "");

        IEnumerable<UniversityViewModel> GetUniversities();

        IEnumerable<UniversityExportViewModel> GetUniversitiesForExport();

        UniversityListPagedModel GetUniversity(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
