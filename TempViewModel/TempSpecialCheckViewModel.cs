using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.TempViewModel
{
    public class TempSpecialCheckViewModel
    {
        public int SpecialCheckRowId { get; set; }

        public string SC_Cand_Name { get; set; }   
        public string SC_Father_Name { get; set; }  
        public string SC_SecuritasID { get; set; } 
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SC_DOB { get; set; }

        //Following not show on page. It is for future use only
        public string SC_Others1 { get; set; }
        public string SC_Others2 { get; set; }
        public string SC_Others3 { get; set; }
        public string SC_Others4 { get; set; }
        public string SC_Others5 { get; set; }

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class AddTempSpecialCheckViewModel
    {
        [ScaffoldColumn(false)]
        public int SpecialCheckRowId { get; set; }

        [ScaffoldColumn(false)]
        public short ClientRowID { get; set; }

        [ScaffoldColumn(false)]
        public int PersonalRowID { get; set; }

        [ScaffoldColumn(false)]
        public int ClientPackageRowID { get; set; }

        [ScaffoldColumn(false)]
        public short CheckFamilyRowID { get; set; }

        [ScaffoldColumn(false)]
        public short SubCheckRowID { get; set; }

        [MaxLength(20)]
        [ScaffoldColumn(false)]
        public string UniqueComponentID { get; set; }

        [MaxLength(100)]
        public string SC_Cand_Name { get; set; }        // Text Field - Auto Capture

        [MaxLength(100)]
        public string SC_Father_Name { get; set; }      // Text Field - Auto Capture

        [MaxLength(100)]
        public string SC_SecuritasID { get; set; }      // Text Field - Auto Capture

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SC_DOB { get; set; }           // date  Text Field - Auto Capture
        
        //Following not show on page. It is for future use only
        [MaxLength(200)]
        public string SC_Others1 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others2 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others3 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others4 { get; set; }       // Text Field
        [MaxLength(200)]
        public string SC_Others5 { get; set; }       // Text Field 

        public short CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public short ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }

        [MaxLength(20)]
        public string CheckStatus { get; set; }

        [MaxLength(20)]
        public string ReWorkCheckStatus { get; set; }

        [MaxLength(200)]
        public string Remarks { get; set; }
        public byte Status { get; set; }
    }
}
