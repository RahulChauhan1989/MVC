using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientDashboardRepository
    {
        ClientDashboardViewModel GetClientDashBoardInfo(short ClientRowId, int ClientUserRowID = 0);
        DashboardClientCandidateListViewModel GetClientDashBoardInfo(int pageNo, int pageSize, string sort, string sortDir, string Search = "", string CaseStatus = "",  short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", byte tatHours = 0, int ClientUserRowID = 0);
        DashboardClientCandidateListViewModel GetClientTempDashBoardInfo(int pageNo, int pageSize, string sort, string sortDir, string Search = "", string CaseStatus = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", int ClientUserRowID = 0);
    }
}
