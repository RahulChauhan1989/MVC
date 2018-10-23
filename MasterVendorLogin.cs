using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterVendorLogin
    {
        public MasterVendorLogin()
        {
            VendorLoginRowID = 0;
            VendorRowID = 0;
            ContactPerson = string.Empty;
            MobileNo = string.Empty;
            UserID = string.Empty;
            UPass = string.Empty;
            CreatedBy = string.Empty;
            UnBlockedBy = 0;
            UserType = 0;
            Status = 1;
            SentMailStatus = 0;
            Remarks = string.Empty;
            Other1 = string.Empty;
            Other2 = string.Empty;
            Other3 = string.Empty;
        }

        public int VendorLoginRowID { get; set; }

        public short VendorRowID { get; set; }
        public virtual MasterVendor MasterVendor { get; set; }

        public string ContactPerson { get; set; }
        public string MobileNo { get; set; }
        public string UserID { get; set; }
        public string UPass { get; set; }
        public string CreatedBy { get; set; }       //Company / Vender
        public DateTime? CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public DateTime? BlockedDate { get; set; }
        public short UnBlockedBy { get; set; }
        public DateTime? UnBlockedDate { get; set; }
        public byte UserType { get; set; }          //0-Default(For Vender only) and 1-(Vernder's User)
        public byte Status { get; set; }
        public byte SentMailStatus { get; set; }
        public DateTime? SentMailDate { get; set; }
        public string Remarks { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
    }
}
