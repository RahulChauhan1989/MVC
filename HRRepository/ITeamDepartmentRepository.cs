using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.HRViewModels;

namespace BAL.HRRepository
{
    public interface ITeamDepartmentRepository
    {
        void AddTeamDepartment(AddTeamDepartmentViewModel model);
        IEnumerable<TeamDepartmentViewModel> GetDepartmentTMembers();
        TeamDepartmentListPagedModel GetTeamDepartmentAndDesignation(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short teammemberId = 0);
        int SaveChanges();

        IEnumerable<TeamDepartmentViewModel> GetTeamDepartmentsWithDesignationsById(short TeamMemberRowID);
        TeamDepartmentViewModel GetDepartmentWithDesignationById(short TeamDepartmentRowID);
        void DeleteTeamDepartAndDesignationById(short tdid = 0);
        short GetTeamMemberRptWriterManager(string DesignationName = "");
        bool IsDepartDesignationExist(byte DepartmentRowID = 0, short TeamMemberRowID = 0);
        bool MapTeamDepartmentWithAllClients(short tdid = 0);
    }
}
