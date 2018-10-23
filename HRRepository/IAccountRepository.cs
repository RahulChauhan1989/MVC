using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.CandidateViewModel;
using ViewModels.ClientViewModel;
using ViewModels.HRViewModels;
using ViewModels.PartnerViewModels;

namespace BAL.HRRepository
{
    public interface IAccountRepository
    {   
        //For Company User Login     
        CompanyUserLoggedViewModel GetCompanyUserLoggedDetails(string UserName, string EcryptedPassword);
        IEnumerable<CompanyLoginViewModel> GetAllActiveWebUsers();
        void BlockedCompanyUser(UpdateCompanyUserBlockStatusViewModel model);

        int SaveChanges();

        int AddUserLoggedInDetails(AddUserLoggedInDetailViewModel model);
        void UpdateUserLogOutDetails(UpdateUserLogOutDetailViewModel model);

        //For Client User Login     
        ClientUserLoggedViewModel GetClientUserLoggedDetails(string UserName, string EcryptedPassword);
        IEnumerable<ClientLoginViewModel> GetAllActiveClientUsers();
        void BlockedClientUser(UpdateClientUserBlockStatusViewModel model);

        //For Candidate User Login     
        CandidateUserLoggedViewModel GetCandidateUserLoggedDetails(string UserName, string EcryptedPassword);
        CandidateUserLoggedViewModel GetInsuffCandidateUserLoggedDetails(string UserName, string EcryptedPassword);
        IEnumerable<CandidateLoginViewModel> GetAllActiveCandidateUsers();
        void ExpireCandidateLogin(UpdateCandidateLoginExpireStatusViewModel model);

        //For Vender User Login     
        VendorUserLoggedViewModel GetVendorUserLoggedDetails(string UserName, string EcryptedPassword);
        IEnumerable<VendorLoginViewModel> GetAllActiveVendorUsers();
        void BlockedVendorUser(UpdateVendorUserBlockStatusViewModel model);

    }
}
