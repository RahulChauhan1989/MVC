using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.HRViewModels;

namespace BAL.HRRepository
{
    public interface IWebUserRepository
    {
        bool IsWebUserExist(string WebUserName);

        bool IsWebUserExist(short WebUserRowID, string CRPUserName);

        void AddWebUser(AddWebUserViewModel model);

        UpdateWebUserViewModel GetWebUserForUpdateById(short WebUserRowID);

        void UpdateWebUser(UpdateWebUserViewModel model);
       
        int SaveChanges();

        void ActiveWebUser(short id = 0, string checkeds = "");

        IEnumerable<WebUserViewModel> GetWebUsers();

        WebUserListPagedModel GetWebUser(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        UnBlockedCUListPagedModel GetUnBlockedCompanyUser(int pageNo, int pageSize, 
            string sort, string sortDir, string TeamMemberName = "", string UserName = "");

        void UnBlockedUser(UnBlockedUsersViewModel model);

        IEnumerable<WebUserExportViewModel> GetWebUsersForExport();
    }
}
