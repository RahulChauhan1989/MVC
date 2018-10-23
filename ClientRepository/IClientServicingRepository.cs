using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientServicingRepository
    {
        DashboardManagerClientServicingViewModel GetManagerClientServicingDashBoardInfo(short TeamMemberRowId, short ClientRowID, string SpocEmailID);

        DashboardClientCandidateListViewModel GetClientServicingDashBoardInfo(int pageNo, int pageSize, string sort, string sortDir, string Search = "", string CaseStatus = "", short ClientRowID = 0, string RecievingDate = "", string CompletedDate = "", byte tatdays = 0, string SpocEmailID = "");

        DashboardClientCandidateListViewModel GetClientServicingDashBoardTempPQPersonalInfo(int pageNo, int pageSize, string sort, string sortDir, string Search = "", string CaseStatus = "", short ClientRowID = 0, string RecievingDate = "", string SpocEmailID = "");
    }
}
