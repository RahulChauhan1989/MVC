using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class PQClientTMemberViewModel
    {
        public int ClientTMemberRowID { get; set; }

        public short ClientRowID { get; set; }
       
        public short TeamMemberRowID { get; set; }
      
        public string TeamMemberName { get; set; }
        public string TeamMemberEmail { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public byte Status { get; set; }
    }

    public class AddPQClientTMemberViewModel
    {
        [Display(Name="ID")]
        public int ClientTMemberRowID { get; set; }

        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        [Display(Name = "Team Member : ")]
        public short TeamDepartmentRowID { get; set; }

        [Display(Name = "Team Member : ")]
        public string TeamMemberName { get; set; }

        public string TeamMemberRowIds { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class PQClientTMemberListPagedModel
    {
        public IEnumerable<PQClientTMemberViewModel> ClientTMembers { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class ExportClientTMemberViewModel
    {
        public int ClientTMemberRowID { get; set; }       
        public string TeamMemberName { get; set; }       
        public string Department { get; set; }
        public string Designation { get; set; }
    }
}
