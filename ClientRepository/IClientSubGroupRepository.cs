using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.ClientViewModel;

namespace BAL
{
    public interface IClientSubGroupRepository
    {
        bool IsClientSubGroupExist(string SubGroupName,short id);

       

        void AddClientSubGroup(AddClientSubGroupViewModel model);

        UpdateClientSubGroupViewModel GetClientSubGroupForUpdateById(short ClientSubGroupID);

        void UpdateClientSubGroup(UpdateClientSubGroupViewModel model);

        void DeleteClientSubGroup(short ClientSubGroupID);

        int SaveChanges();

        ClientSubGroupListPagedModel GetClientSubGroups(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        IEnumerable<ExportClientSubGroupViewModel> GetClientSubGroupForExport();
    }
}
