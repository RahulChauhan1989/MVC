using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IStateRepository
    {
        bool IsStateExist(string StateName);

        void AddState(AddStateViewModel model);

        IEnumerable<StateExportViewModel> GetStatesForExport();

        UpdateStateViewModel GetStateForUpdateById(short StateID);

        void UpdateState(UpdateStateViewModel model);
        
        void DeleteState(short StateRowID);

        int SaveChanges();
        
        StateListPagedModel GetStates(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        IEnumerable<StateViewModel> GetStates();

        StateCheckBoxList GetStatesForCheckbox(short countryRowID);

        void ActiveStates(short id = 0, string checkeds = "");
    }
}
