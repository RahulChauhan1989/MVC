using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientCompletedContractRepository
    {
        ClientCompletedContractViewModel ClientComletedContract(short ClientRowId = 0);

        //byte ClientComletedContract(short ClientRowId = 0);
    }
}
