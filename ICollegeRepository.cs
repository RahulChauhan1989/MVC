using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface ICollegeRepository
    {
        bool IsCollegeExist(string CollegeName);

        bool IsCollegeExist(int CollegeRowID, string CollegeName);

        void AddCollege(AddCollegeViewModel model);

        UpdateCollegeViewModel GetCollegeForUpdateById(short CollegeRowID);

        CollegeViewModel GetCollegeForDetailsById(short CollegeRowID);

        void UpdateCollege(UpdateCollegeViewModel model);

        void DeleteCollege(short CRowID);

        void ActiveCollege(short id = 0, string checkeds = "");

        int SaveChanges();

        IEnumerable<CollegeViewModel> GetColleges();

        IEnumerable<CollegeExportViewModel> GetCollegesForExport();

        CollegeListPagedModel GetCollege(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
        CollegeListPagedModel GetBeyondCollege(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
