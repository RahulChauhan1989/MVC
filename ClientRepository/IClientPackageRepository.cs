using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientPackageRepository
    {
        bool IsPackageExist(string PackageName);

        void AddClientPackage(AddClientPackageViewModel model);
        
        int SaveChange();

        IEnumerable<ClientPackageViewModel> GetPackagesByClientId(short CId = 0);

        ClientPackageListPagedModel GetClientPackages(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0);

        PackageListPagedModel GetPackages(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        IEnumerable<ClientPackageViewModel> GetPackageDetailsByPackageName(string PackageName = "");

        ClientPackageViewModel GetPackageDetailsById(int CPId = 0);

        void UpdateAntecedentPackage(int id = 0);
    }
}
