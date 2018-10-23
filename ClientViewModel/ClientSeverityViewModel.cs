using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class ClientSeverityViewModel
    {
        [Display(Name = "ID")]
        public int ClientSeverityRowId { get; set; }

        [Display(Name = "Client Color Name : ")]
        public string ClientColorName { get; set; }

        [Display(Name = "Client Color Code : ")]
        public string ClientColorCode { get; set; }

        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        public string ClientName { get; set; }

        [Display(Name = "Severity : ")]
        public byte SeverityGridRowId { get; set; }

        public string ColorCode { get; set; }

        public string SeverityGrid { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class MasertSeverityViewModel
    {
        [Display(Name = "Status")]
        public byte SeverityGridRowId { get; set; }

        [Display(Name = "Severity")]
        public string SeverityGrid { get; set; }

        [Display(Name = "Color Name")]
        public string ColorName { get; set; }

        [Display(Name = "Color Code")]
        public string ColorCode { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class UpdateClientSeverityViewModel
    {
        [Display(Name ="ID")]
        public int ClientSeverityRowId { get; set; }

        [Display(Name = "Client Color Name : ")]
        public string ClientColorName { get; set; }

        [Display(Name = "Client Color Code : ")]
        public string ClientColorCode { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        [ScaffoldColumn(false)]
        public string ClientName { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Severity : ")]
        public byte SeverityGridRowId { get; set; }

        [Display(Name = "Status")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class ClientSeverityListPagedModel
    {
        public IEnumerable<ClientSeverityViewModel> ClientSeverities { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        public string ClientName { get; set; }
    }
}
