using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientDispositionRepository
    {
        bool IsClientDispositionExist(short ClientRowID = 0, short CheckFamilyRowID = 0, short DispositionRowId = 0);

        void AddClientDisposition(AddClientDispositionViewModel model);

        void AddClientDispositionDefaultSelected(AddClientDispositionViewModel model);

        int SaveChanges();

        IEnumerable<ClientDispositionViewModel> GetClientDispositionCycles();

        ClientDispositionListPagedModel GetClientDispositions(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0, short ChkId = 0);

        IEnumerable<ClientDispositionViewModel> GetClientDispositions(short CId = 0, short ChkId = 0);

        ClientCheckFamilyListPagedModel GetClientCheckFamily(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0);

        UpdateClientDispositionViewModel GetClientDispoSeverityForUpdateById(int ClientDispositionRowId);

        void UpdateDispoClientSeverity(UpdateClientDispositionViewModel model);

    }
}
