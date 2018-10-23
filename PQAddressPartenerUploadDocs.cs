using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PQAddressPartenerUploadDocs
    {
        public Int64 PartenerUploadRowID { get; set; }

        public int PQAddressVarPtrRowId { get; set; }
        public PQAddressVarPartener PQAddressVarPartener { get; set; }

        public int PersonalRowID { get; set; }
        public short SubCheckRowID { get; set; }

        public string DocumentUploadFrom { get; set; }      //  Provided / Verified
        public string DocumentType { get; set; }
        public string FileName { get; set; }        
        public string FilePath { get; set; }
        public byte Status { get; set; }                //Default - 1
    }
}
