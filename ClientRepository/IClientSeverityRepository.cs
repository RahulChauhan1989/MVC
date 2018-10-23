using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientSeverityRepository
    {
        //bool IsClientSeverityExist(string ClientColorCode);

       UpdateClientSeverityViewModel GetClientSeverityForUpdateById(int ClientSeverityRowID);
     
        void UpdateClientSeverity(UpdateClientSeverityViewModel model);

        IEnumerable<MasertSeverityViewModel> GetMasterSeveritys();       

        int SaveChanges();

        ClientSeverityListPagedModel GetClientSeverities(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short ClientRowID=0);
    }
}
