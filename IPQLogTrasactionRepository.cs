using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IPQLogTrasactionRepository
    {
        void AddPQLogTrasaction(AddPQLogTrasactionViewModel model);

        int SaveChanges();
    }
}
