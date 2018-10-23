using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;
using ViewModels.PartnerViewModels;

namespace BAL.ClientRepository
{
    public interface IClientLoginRepository
    {
        bool IsClientLoginExist(string UserId);
        bool IsClientLoginExist(string UserId, int ClientUserid);
        void AddClientLogin(AddPQClientLoginViewModel model);
        UpdatePQClientLoginViewModel GetClientLoginForUpdateById(short ClientLoginID);
        void UpdateClientLogin(UpdatePQClientLoginViewModel model);
        void UpdateClientSendMailStatus(UpdateClientSendMailStatusViewModel model);
        SendClientLoginInfoViewModel GetClientLoginInfoforSendMail(int ClientUserRowID);
        void DeleteClientLoginSubGroups(short ClientLoginID);
        void ActiveClientLogin(short id = 0, string checkeds = "");
        int SaveChanges();
        PQClientUserListPagedModel GetClientUsers(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short ClientRowID = 0);                
        int GetAllClientUserByClId(short ClientRowID = 0);
        PQClientUserListPagedModel GetBlockedClientUser(int pageNo, int pageSize, string sort, string sortDir, string ClientName = "", string UserName = "");
        VendorUserLoggedListPagedModel GetBlockeddPartnerUsers(int pageNo, int pageSize, string sort, string sortDir, string ClientName = "", string UserName = "");
        void UnBlockedClientUser(UnBlockedClientUsersViewModel model);
        void UnBlockedPartnerUsers(UnBlockedPartnerUsersViewModel model);
    }
}
