using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.TempViewModel
{
   public class PQClientCandiBulkUploadViewModel
    {
        public int CBulkUploadRowID { get; set; }
        public short ClientRowID { get; set; }      
        public int ClientPackageRowID { get; set; }
        public int ClientCheckRowID { get; set; }
        public string ExcelFileName { get; set; }
        public string  ImportBy { get; set; }
        public string Remarks { get; set; }
        public byte Status { get; set; }
    }

    public class AddPQClientCandiBulkUploadViewModel
    {
        [Display(Name = "ID")]
        public int CBulkUploadRowID { get; set; }

        [Display(Name = "Client")]
        public short ClientRowID { get; set; }

        [Display(Name = "Package")]
        public int ClientPackageRowID { get; set; }

        [Display(Name = "Check")]
        public int ClientCheckRowID { get; set; }

        public string ExcelFileName { get; set; }        
        public string ImportBy { get; set; }
        public string Remarks { get; set; }
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
}
