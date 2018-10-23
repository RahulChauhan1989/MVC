using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.HRViewModels;

namespace BAL.HRRepository
{
    public interface ITeamMemberRepository 
    {
        bool IsTeamMemberExist(string EmployeeId);

        bool IsTeamMemberExist(int TeamMemberRowID, string EmployeeID);

        void AddTeamMember(AddTeamMemberViewModel model);

        string GetTeamMemberNameById(short TeamMemberRowID = 0);

        UpdateTeamMemberViewModel GetTeamMemberForUpdateById(short TeamMemberRowID);

        IEnumerable<TeamMemberExportViewModel> GetTeamMembersForExport();

        void UpdateTeamMember(UpdateTeamMemberViewModel model);

        void DeleteTeamMember(short CRowID);

        int SaveChanges();

        IEnumerable<TeamMemberViewModel> GetTeamMembers();

        TeamMemberListPagedModel GetTeamMember(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        RepoToTeamMemberListPagedModel GetReportedTeamMembers(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short TeamMemberRowID = 0);

        void AddRepoToTeamMember(AddRepoToTeamMemberViewModel model);

        bool IsRepoToMemberExist(short ReportingTo, short TeamMemberRowID);

        void DeleteReportingTeamMember(short RepoRowID);

    }
}
