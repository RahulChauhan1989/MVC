using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientCheckRepository
    {
        void AddClientCheck(AddClientCheckViewModel model);

        int SaveChange();

        IEnumerable<ClientCheckViewModel> GetChecksByClientId(short CId = 0);

        ClientCheckListPagedModel GetClientChecks(int pageNo, int pageSize, string sort, string sortDir, short CId = 0);

        ClientCheckViewModel GetChecksDetailsById(int ChkId = 0);

        void UpdateAntecedentCheck(int id = 0);

        bool IsExistSubCheck(short ClientRowId = 0, short CheckFamilyId = 0, short SubCheckRowId = 0);

        #region *****Temp Check ******
        bool IsExistTempSubCheck(short ClientRowId = 0, short CheckFamilyId = 0, short SubCheckRowId = 0);

        #endregion
    }
}
