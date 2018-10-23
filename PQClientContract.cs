using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQClientContract
    {
        public PQClientContract()
        {
            ClientContractRowID = 0;
            ClientRowID = 0;
            DocumentType = string.Empty;
            FileName = string.Empty;
            FilePath = string.Empty;
            DocumentUploadFrom = string.Empty;
            Remarks = string.Empty;
            UploadDate = DateTime.Now;
            Status = 1;
        }

        public int ClientContractRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public string DocumentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string DocumentUploadFrom { get; set; }
        public string Remarks { get; set; }
        public DateTime? UploadDate { get; set; }
        public byte Status { get; set; }
    }
}
