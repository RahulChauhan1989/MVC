using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AbbreviationViewModel
    {
        [Display(Name ="ID")]
        public short ClientAbbRowID { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Display(Name = "Abbreviation")]
        public string ClientAbbreviation { get; set; }
        public byte Status { get; set; }
    }
    public class AddAbbreviationViewModel
    {
        [Display(Name = "ID")]        
        public short ClientAbbRowID { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required]
        [MaxLength(20), MinLength(3)]
        [Display(Name = "Abbreviation")]
        public string ClientAbbreviation { get; set; }
        public byte Status { get; set; }
    }
    public class UpdateAbbreviationViewModel
    {
        [Display(Name = "ID")]
        public short ClientAbbRowID { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required]
        [MaxLength(20), MinLength(3)]
        [Display(Name = "Abbreviation")]
        public string ClientAbbreviation { get; set; }
        public byte Status { get; set; }
    }
    public class AbbreviationListPagedModel
    {
        public IEnumerable<AbbreviationViewModel> ClientAbbreviations { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
  
}
