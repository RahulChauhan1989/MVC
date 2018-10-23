using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AntecedentViewModel
    {
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public short AntecedentRowId { get; set; }

        [Display(Name = "Field Name")]
        public string FieldName { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Display(Name = "Antecedent Type")]
        public byte AntecedentTypeRowId { get; set; }
       
        public string AntecedentTypeName { get; set; }

        [Display(Name = "Check Family")]
        public short CheckFamilyRowID { get; set; }
       
        public string CheckFamilyName { get; set; }

        [Display(Name = "BGV Published")]
        public byte BGVPublished { get; set; }
        public string BGVPublish { get; set; }

        [Display(Name = "Report Published")]
        public byte ReportPublished { get; set; }
        public string ReportPublish { get; set; }

        [Display(Name = "Email Added")]
        public byte EmailAdded { get; set; }
        public string EmailAdd { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        public byte IsSetDefault { get; set; }

        [Display(Name = "Is Active")]
        public byte DisplayOrder { get; set; }
    }
    public class UpdateAntecedentViewModel
    {
        [Display(Name = "ID")]
        
        public short AntecedentRowId { get; set; }

        [Display(Name = "Field Name")]
        public string FieldName { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        public byte AntecedentTypeRowId { get; set; }
        [Display(Name = "Antecedent Type")]
        public string AntecedentTypeName { get; set; }

        public short CheckFamilyRowID { get; set; }
        [Display(Name = "CheckFamily")]
        public string CheckFamilyName { get; set; }

        [Display(Name = "BGV Published")]
        public byte BGVPublished { get; set; }
       

        [Display(Name = "Report Published")]
        public byte ReportPublished { get; set; }

        [Display(Name = "Email Added")]
        public byte EmailAdded { get; set; }

        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [Display(Name = "Display Order")]
        public byte DisplayOrder { get; set; }
    }

    public class AntecedentDDLViewModel
    {
        [Display(Name = "Antecedents Type :")]
        public short AntecedentTypeRowId { get; set; }

        public string AntecedentTypeName { get; set; }
    }

    public class AntecedentExportViewModel
    {      
        public short AntecedentRowId { get; set; }
      
        public string FieldName { get; set; }
      
        public string DisplayName { get; set; }
       
        public string AntecedentTypeName { get; set; }
        
        public string CheckFamilyName { get; set; }

        public byte BGVPublished { get; set; }

        public string BGVPublish { get; set; }
       
        public byte ReportPublished { get; set; }

        public string ReportPublish { get; set; }    

        public byte EmailAdded { get; set; }

        public string EmailAdd { get; set; }       

    }

    public class AntecedentListPageModel
    {
        public IEnumerable<AntecedentViewModel> Antecedents { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
