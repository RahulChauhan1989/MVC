using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQClientLogin
    {
        public PQClientLogin()
        {
            ClientUserRowID = 0;
            ClientRowID = 0;
            ClientBranch = string.Empty;
            UserID = string.Empty;
            UPass = string.Empty;
            CreatedBy = string.Empty;
            UnBlockedBy = 0;
            UType = string.Empty;
            SentMailStatus = 0;
            Remarks = string.Empty;
            Status = 1;
        }

        public int ClientUserRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }
        
        public string ClientBranch { get; set; }
        public string UserID { get; set; }
        public string UPass { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? BlockedDate { get; set; }
        public short UnBlockedBy { get; set; }
        public DateTime? UnBlockedDate { get; set; }
        public string UType { get; set; }
        public byte Status { get; set; }
        public byte SentMailStatus { get; set; }
        public DateTime? SentMailDate { get; set; }
        public string Remarks { get; set; }
        public short CreatedUserId { get; set; }
    }
}
