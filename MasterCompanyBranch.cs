using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterCompanyBranch
    {
        public MasterCompanyBranch()
        {
            BORowID = 0;
            CompanyRowID = 0;
            BOName = string.Empty;
            BOAddress = string.Empty;
            BOConcernPersonName = string.Empty;
            BOContactNumber = string.Empty;
            BOEmailId = string.Empty;
            Status = 1;
        }
        public short BORowID { get; set; }
        public string BOName { get; set; }

        public short CompanyRowID { get; set; }
        public virtual MasterCompany MasterCompany { get; set; }

        public string BOAddress { get; set; }
        public string BOConcernPersonName { get; set; }
        public string BOContactNumber { get; set; }
        public string BOEmailId { get; set; }
        public byte Status { get; set; }
    }
}
