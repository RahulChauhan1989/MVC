using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class ClientPackageViewModel
    {
        [Display(Name = "ID")]
        public int ClientPackageRowID { get; set; }

        [Display(Name = "Package Name")]
        public string ClientPackageName { get; set; }

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

        [Display(Name = "Antecedents")]
        public byte AntecedentSelected { get; set; }

        [Display(Name = "Template")]
        public byte SelectedTemplate { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? AddedDate { get; set; }
    }

    public class AddClientPackageViewModel
    {
        [Display(Name = "ID : ")]
        public int ClientPackageRowID { get; set; }

        [Required(ErrorMessage ="Enter Package Name")]
        [Display(Name = "Package Name : ")]
        public string ClientPackageName { get; set; }

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

        [Display(Name = "Antecedents : ")]
        public byte AntecedentSelected { get; set; }

        public byte DispositionSelected { get; set; }

        [Display(Name = "Template : ")]
        public byte SelectedTemplate { get; set; }

        [Display(Name = "Status : ")]
        public byte Status { get; set; }

        [Display(Name = "Created Date : ")]
        public DateTime? AddedDate { get; set; }
    }

    public class ClientPackageListPagedModel
    {
        public IEnumerable<ClientPackageViewModel> ClientPackages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class PackageListPagedModel
    {
        public IEnumerable<ClientPackageViewModel> Packages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class PackagesDDLViewModel
    {
        [Display(Name = "Package Name")]
        public string PackageNameTxt { get; set; }

        public string PackageNameVal { get; set; }
    }

    public class ExportClientPackageViewModel
    {
        public int ClientPackageRowID { get; set; }
        public string ClientPackageName { get; set; }
        public string CheckFamilyName { get; set; }
        public string SubCheckFamillyName { get; set; }
        public byte ReportSequence { get; set; }
        public byte AntecedentSelected { get; set; }
    }
}
