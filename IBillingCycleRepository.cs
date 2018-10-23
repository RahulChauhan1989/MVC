    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IBillingCycleRepository
    {
        bool IsBillingCycleExist(string BillingCycleName);

        void AddBillingCycle(AddBillingCycleViewModel model);

        UpdateBillingCycleViewModel GetBillingCycleForUpdateById(byte BCRowID);

        void UpdateBillingCycle(UpdateBillingCycleViewModel model);

        void DeleteBillingCycle(byte BCRowID);

        int SaveChanges();

        void ActiveBillingCycle(short id = 0, string checkeds = "");

        IEnumerable<BillingCycleViewModel> GetBillingCycles();

        IEnumerable<BillingCycleExportViewModel> GetBillingCyclesForExport();

        BillingCycleListPagedModel GetBillingCycles(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
    }
}
