using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ClientViewModel
{
    public class ClientSubGroupViewModel
    {
        [Display(Name ="ID")]
        public short ClientSubGroupID { get; set; }

        [Display(Name = "Client Sub-Group ")]
        public string SubGroupName { get; set; }

        public short ClientAbbRowID { get; set; }

        [Display(Name = "Client Name")]
        public string  ClientName { get; set; }
        
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    public class AddClientSubGroupViewModel
    {
        [ScaffoldColumn(false)]
        public short ClientSubGroupID { get; set; }
        [Required(ErrorMessage = "Please select Clien  is required")]
        public short ClientAbbRowID { get; set; }
        
        [MaxLength(100)]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required]
        [Display(Name = "Client Sub-Group ")]
        public string SubGroupName { get; set; }
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    public class UpdateClientSubGroupViewModel
    {

        [Display(Name = "ID")]
        public short ClientSubGroupID { get; set; }
        [Required(ErrorMessage = "please select Clien  is required")]
        public short ClientAbbRowID { get; set; }
        
        [MaxLength(100)]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required]
        [Display(Name = "Client Sub-Group ")]
        public string SubGroupName { get; set; }
        [ScaffoldColumn(false)]
        public byte Status { get; set; }
    }
    
    public class ClientSubGroupListPagedModel
    {
        public IEnumerable<ClientSubGroupViewModel> ClientSubGroups { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
    public class ClientSubGroupDDLViewModel
    {
        public int ClientAbbRowID { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
    }

    public class ClientAbbSubGroupDDLViewModel
    {
        public short ClientSubGroupID { get; set; }

        public string SubGroupName { get; set; }
    }

    public class ExportClientSubGroupViewModel
    {
        public short ClientSubGroupID { get; set; }      
        public string ClientName { get; set; }
        public string SubGroupName { get; set; }
    }

}
