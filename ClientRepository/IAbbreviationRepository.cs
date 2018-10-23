using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
    public interface IAbbreviationRepository
    {
        bool IsAbbreviationExist(string ClientName);

        bool IsAbbreviationExist(string ClientName, string CAbbreviation, short ClientAbbRowID);

        void AddAbbreviation(AddAbbreviationViewModel model);

        UpdateAbbreviationViewModel GetAbbreviationForUpdateById(short BCRowID);

        void UpdateAbbreviation(UpdateAbbreviationViewModel model);

        void DeleteAbbreviation(byte AbbreID);

        int SaveChanges();

        IEnumerable<AbbreviationViewModel> GetAbbreviationCycles();

        AbbreviationListPagedModel GetAbbreviations(int pageNo, int pageSize, string sort, string sortDir, string Search = "");

        IEnumerable<AbbreviationViewModel> GetAbbreviationForExports();
    }
}
