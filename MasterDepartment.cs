using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterDepartment
    {
        public MasterDepartment()
        {
            DepartmentRowID = 0;
            DepartmentName = string.Empty;
            Status = 1;
        }

        public byte DepartmentRowID { get; set; }
        public string DepartmentName { get; set; }
        public byte Status { get; set; }
    }
}
