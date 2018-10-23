using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQClientBulkUpload
    {
        public PQClientBulkUpload()
        {
            ClientBulkUploadRowID = 0;
            ClientRowID = 0;
            ExcelFileName = string.Empty;
            AttachDocName = string.Empty;
            Status = 0;
            UploadedBy = string.Empty;
        }

        public int ClientBulkUploadRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public string ExcelFileName { get; set; }
        public string AttachDocName { get; set; }
        
        public byte Status { get; set; }

        public string UploadedBy { get; set; }
        public DateTime? UploadedDate { get; set; }
    }
}
