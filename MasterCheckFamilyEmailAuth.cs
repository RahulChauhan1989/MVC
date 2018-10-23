using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterCheckFamilyEmailAuth
    {
        public MasterCheckFamilyEmailAuth()
        {
            CheckFamilyEmailAuthRowID = 0;
            CheckFamilyRowID = 0;
            SMTPServer = string.Empty;
            SMTPPort = 0;
            SMTPUserName = string.Empty;
            SMTPPassword = string.Empty;
            EnableSsl = 0;
            Status = 1;
        }

        public byte CheckFamilyEmailAuthRowID { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public string SMTPServer { get; set; }
        public short SMTPPort { get; set; }
        public string SMTPUserName { get; set; }
        public string SMTPPassword { get; set; }
        public byte EnableSsl { get; set; }
        public byte Status { get; set; }
    }
}
