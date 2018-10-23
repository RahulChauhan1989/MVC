using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.TempViewModel;

namespace BAL.ClientRepository
{
    public interface IUploadDocClientRepository
    {
        TempPQVerifiedUploadDocsInfoListPagedModel GetCandidateUploadedDocList(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short SubCheckRowID = 0, int PersonalRowID = 0, int ClientUserRowID = 0);
    }
}
