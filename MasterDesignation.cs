using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterDesignation
    {
        public MasterDesignation()
        {
            DesignationRowID = 0;
            DesignationName = string.Empty;
            DepartmentRowID = 0;
            Status = 1;
        }

        public byte DesignationRowID { get; set; }
        public string DesignationName { get; set; }

        public byte DepartmentRowID { get; set; }
        public virtual MasterDepartment MasterDepartment { get; set; }

        public byte Status { get; set; }
    }
}
