using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MasterAntecedent
    {
        public MasterAntecedent()
        {
            AntecedentRowId = 0;
            FieldName = string.Empty;
            DisplayName = string.Empty;
            AntecedentTypeRowId = 0;
            CheckFamilyRowID = 0;
            IsSetDefault = 0;
            DisplayOrder = 0;
            BGVPublished = 0;
            ReportPublished = 0;
            EmailAdded = 0;
            Status = 1;
        }

        public short AntecedentRowId { get; set; }
        public string FieldName { get; set; }
        public string DisplayName { get; set; }

        public byte AntecedentTypeRowId { get; set; }
        public virtual MasterAntecedentType MasterAntecedentType { get; set; }

        public short CheckFamilyRowID { get; set; }
        public virtual MasterCheckFamily MasterCheckFamily { get; set; }

        public byte IsSetDefault { get; set; }
        public byte DisplayOrder { get; set; }
        public byte BGVPublished { get; set; }
        public byte ReportPublished { get; set; }
        public byte EmailAdded { get; set; }
        public byte Status { get; set; }

    }
}
