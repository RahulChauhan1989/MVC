using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientAntecedentFieldRepository
    {
        bool IsPQClientAntecedentsExist(short CId = 0, short ChkId = 0, short SChKId = 0,short AntId = 0);
       
        void AddPQClientAntecedentsField(AddClientFieldViewModel model);

        void AddPQClientAntecedentsDefaultSelected(AddClientFieldViewModel model);

        void UpdatePQClientAntecedentsField(AddClientFieldViewModel model);

        IEnumerable<AntecedentViewModel> GetAntecedents(short CheckMasterId);

        IEnumerable<AntecedentViewModel> GetClientAntecedents(short ClientRowId=0,short CheckFamilyId=0, short SubCheckRowId = 0);

        int SaveChanges();
    }
}
