using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class ClientDispositionViewModel
    {
        [Display(Name = "ID")]
        public int ClientDispositionRowId { get; set; }

        [Display(Name = "Client Name")]
        public short ClientRowID { get; set; }

        [Display(Name = "Check Family")]
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }

        [Display(Name = "Disposition")]
        public short DispositionRowId { get; set; }
        public string Disposition { get; set; }

        [Display(Name = "Severity Grid")]
        public byte SeverityGridRowId { get; set; }
        public string SeverityGrid { get; set; }

        [Display(Name = "Status")]
        public byte Status { get; set; }
    }

    public class ClientCheckFamilyViewModel
    {
        public short ClientRowID { get; set; }
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyName { get; set; }
        public int DispositionMap { get; set; }
    }

    public class AddClientDispositionViewModel
    {
        [Display(Name = "ID : ")]
        public int ClientDispositionRowId { get; set; }

        [Required]
        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        [Required]
        [Display(Name = "Check Family : ")]
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyID { get; set; }

        [Required]
        [Display(Name = "Disposition : ")]
        public short DispositionRowId { get; set; }
        public string DispositionIds { get; set; }

        [Display(Name = "Severity Grid : ")]
        public byte SeverityGridRowId { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class UpdateClientDispositionViewModel
    {
        [Required]
        [Display(Name = "ID : ")]
        public int ClientDispositionRowId { get; set; }

        [Required]
        [Display(Name = "Client Name : ")]
        public short ClientRowID { get; set; }

        [Required]
        [Display(Name = "Check Family : ")]
        public short CheckFamilyRowID { get; set; }
        public string CheckFamilyID { get; set; }

        [Required]
        [Display(Name = "Disposition : ")]
        public short DispositionRowId { get; set; }
        public string Disposition { get; set; }

        [Display(Name = "Severity Grid : ")]
        public byte SeverityGridRowId { get; set; }

        [Display(Name = "Status : ")]
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }

    public class ClientDispositionListPagedModel
    {
        public IEnumerable<ClientDispositionViewModel> ClientDispositions { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }

    public class ClientCheckFamilyListPagedModel
    {
        public IEnumerable<ClientCheckFamilyViewModel> ClientChekFamilies { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
