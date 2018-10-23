using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class ClientCheckViewModel
    {
        [Display(Name = "ID")]
        public int ClientCheckRowID { get; set; }

        [Display(Name = "Client Name")]
        public short ClientRowID { get; set; }

        [Display(Name = "Check Family")]
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }

        [Display(Name = "Sub Check")]
        public short SubCheckRowID { get; set; }
        public string SubCheckFamillyName { get; set; }

        [Display(Name = "TAT")]
        public byte TAT { get; set; }

        [Display(Name = "Internal TAT")]
        public byte InternalTAT { get; set; }

        [Display(Name = "Billing Per Check")]
        public double BillingPerCheck { get; set; }

        [Display(Name = "Cost Per Check")]
        public double CostPerCheck { get; set; }

        [Display(Name = "Report Sequence")]
        public byte ReportSequence { get; set; }

        [Display(Name = "Antecedent Selected")]
        public byte AntecedentSelected { get; set; }

        [Display(Name = "Selected Template")]
        public byte SelectedTemplate { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? AddedDate { get; set; }
    }

    public class AddClientCheckViewModel
    {
        [Display(Name = "ID : ")]
        public int ClientCheckRowID { get; set; }

        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        [Display(Name = "Check Family : ")]
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyID { get; set; }

        [Display(Name = "Sub Check : ")]
        public short SubCheckRowID { get; set; }
        public string SubCheckID { get; set; }

        [Display(Name = "TAT : ")]
        public byte TAT { get; set; }

        [Display(Name = "Internal TAT : ")]
        public byte InternalTAT { get; set; }

        [Display(Name = "Billing Per Check : ")]
        public double BillingPerCheck { get; set; }

        [Display(Name = "Cost Per Check : ")]
        public double CostPerCheck { get; set; }

        [Display(Name = "Report Sequence : ")]
        public byte ReportSequence { get; set; }

        [Display(Name = "Antecedent Selected : ")]
        public byte AntecedentSelected { get; set; }

        public byte DispositionSelected { get; set; }

        [Display(Name = "Selected Template : ")]
        public byte SelectedTemplate { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }

        [Display(Name = "Created Date : ")]
        public DateTime? AddedDate { get; set; }        
    }

    public class ClientCheckListPagedModel
    {
        public IEnumerable<ClientCheckViewModel> ClientChecks { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class ExportClientCheckViewModel
    {
        public int ClientCheckRowID { get; set; }
        public string CheckFamilyName { get; set; }        
        public string SubCheckFamillyName { get; set; }
        public byte ReportSequence { get; set; }
        public byte AntecedentSelected { get; set; }
    }
}
