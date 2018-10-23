using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class ClientCompletedContractViewModel
    {        
        public byte UploadClientContracts         { get; set; }
        public byte ClientCheck                   { get; set; }
        public byte ClientPackage                 { get; set; }
        public byte clientDisposition             { get; set; }
        public byte ClientSeveritie               { get; set; }
        public byte ClientHoliday                 { get; set; }
        public byte ClientTeamMember              { get; set; }
        public byte ClientMail                    { get; set; }

    }
}
