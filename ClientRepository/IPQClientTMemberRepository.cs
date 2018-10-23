using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IPQClientTMemberRepository
    {
        bool IsClientTeamMemberExist(short tmid = 0, short CId = 0);
        bool IsClientDETeamMembersExist(short CId = 0, short SCtmid = 0, short DEtmid = 0, short QCtmid = 0);
        bool IsClientDETeamMembersExistForReAllocation(short CId = 0, short SCtmid = 0, short DEtmid = 0, short QCtmid = 0);
        bool IsClientDepartTeamMembersExist(short CId = 0, short tmid = 0, string DepartmentName = "", string DesignationName = "");
        bool IsClientDepartTeamMembersExistForReAllocation(short CId = 0, short tmid = 0, short tmQCid = 0, string DepartmentName = "", string TMDesiName = "", string QCDesiName = "");
        bool IsClientDepartTeamMembersExist(short CId = 0, short tmid = 0, short tmQCid = 0, string DepartmentName = "", string TMDesiName = "", string QCDesiName = "");
        short GetClientTeamPVManager(short CId = 0, string DepartmentName = "", string DesignationName = "");
        void AddClientTeamMember(AddPQClientTMemberViewModel model);
        IEnumerable<PQClientTMemberViewModel> GetDepManagerClientToTeam(short depMgrID = 0, string Designation = "");
        int SaveChanges();
        IEnumerable<PQClientTMemberViewModel> GetRepoClientToTeam(short ClientRowID = 0, string Designation = "");
        PQClientTMemberListPagedModel GetClientTeamMembers(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0);
        IEnumerable<PQClientTMemberViewModel> GetTeamMemberDEByTLDE(short DETLID = 0, string Designation = "");
        void DeleteClientTeamMember(short id = 0);
    }
}
