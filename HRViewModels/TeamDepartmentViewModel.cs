using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.HRViewModels
{
    public class TeamDepartmentViewModel
    {
        public short TeamDepartmentRowID { get; set; }
        public short TeamMemberRowID { get; set; }
        public string TeamMemeberName { get; set; }
        public byte DepartmentRowID { get; set; }
        public string DepartmentName { get; set; }

        public byte DesignationRowID { get; set; }
        public string DesignationName { get; set; }

        public byte Status { get; set; }
    }

    public class AddTeamDepartmentViewModel
    {
        public short TeamDepartmentRowID { get; set; }
        public short TeamMemberRowID { get; set; }
        public byte DepartmentRowID { get; set; }
        public string DepartmentRowIds { get; set; }
        public byte DesignationRowID { get; set; }
        public string DesignationRowIds { get; set; }
        public byte Status { get; set; }
    }

    public class TeamDepartmentListPagedModel
    {
        public IEnumerable<TeamDepartmentViewModel> TeamDepartmentList { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
