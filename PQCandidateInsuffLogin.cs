using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQCandidateInsuffLogin
    {
        public PQCandidateInsuffLogin()
        {
            CInsuffUserRowID = 0;
            ClientRowID = 0;
            PersonalRowID = 0;
            CandidateName = string.Empty;
            UserID = string.Empty;
            UPass = string.Empty;
            CreatedBy = string.Empty;
            Status = 1;
        }

        public int CInsuffUserRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public int PersonalRowID { get; set; }
        public virtual PQPersonal PQPersonal { get; set; }
        
        public string CandidateName { get; set; }
        public string UserID { get; set; }
        public string UPass { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte Status { get; set; }
    }
}
