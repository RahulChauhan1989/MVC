using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQClientCandidateBulkUpload
    {
        public PQClientCandidateBulkUpload()
        {
            CBulkUploadRowID = 0;
            ClientRowID = 0;
            ClientPackageRowID = 0;
            ClientCheckRowID = 0;
            ExcelFileName = string.Empty;
            ImportBy = string.Empty;
            Remarks = string.Empty;
            Status = 1;
        }

        public int CBulkUploadRowID { get; set; }

        public short ClientRowID { get; set; }
        public virtual PQClientMaster PQClientMaster { get; set; }

        public int ClientPackageRowID { get; set; }
        public int ClientCheckRowID { get; set; }
        public string ExcelFileName { get; set; }
        public string ImportBy { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }
    }
}
