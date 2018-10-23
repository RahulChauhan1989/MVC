using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BillingCycleViewModel
    {
        [Display(Name = "ID")]
        public byte BillingRowID { get; set; }

        [Display(Name = "Billing Cycle")]
        public string BillingCycle { get; set; }  

        public byte? Status { get; set; }
    }

    public class BillingCycleExportViewModel
    {
        public byte BillingRowID { get; set; }

        public string BillingCycle { get; set; }
    }

    public class AddBillingCycleViewModel
    {
        [ScaffoldColumn(false)]
        public byte BillingRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Billing Cycle")]
        public string BillingCycle { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }

    public class UpdateBillingCycleViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public byte BillingRowID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Billing Cycle")]
        public string BillingCycle { get; set; }

        [ScaffoldColumn(false)]
        public byte? Status { get; set; }
    }    

    public class BillingCycleListPagedModel
    {
        public IEnumerable<BillingCycleViewModel> BillingCycles { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class BillingCycleDDLViewModel
    {
        public byte BillingRowID { get; set; }
        public string BillingCycle { get; set; }
    }
}
