using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
   public class ClientFieldViewModel
    {
        public int ClientFieldRowID { get; set; }

        public short ClientRowID { get; set; }
       
        public short CheckFamilyRowID { get; set; }
        
        public short SubCheckRowID { get; set; }
       
        public short AntecedentRowId { get; set; }
        public string CADisplayName { get; set; }

        public byte Status { get; set; }
    }

    public class AddClientFieldViewModel
    {
        public int Id { get; set; }

        public int ClientFieldRowID { get; set; }

        public short ClientRowID { get; set; }

        public short CheckFamilyRowID { get; set; }
        
        public short SubCheckRowID { get; set; }

        public short PackageRowID { get; set; }

        public short AntecedentRowId { get; set; }

        public string AntecedentRowIds { get; set; }

        public string CADisplayName { get; set; }

        public byte Status { get; set; }
    }
}
