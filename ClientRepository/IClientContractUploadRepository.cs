using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IClientContractUploadRepository
    {
        bool IsFileUploadExist(string FileUploadName,short ClientRowId);

        void AddFileUpload(AddCContractAgreementViewModel model);

        AddCContractAgreementViewModel GetCContractAgreementFileNameById(short CCARowID);

        //void UpdateBillingCycle(UpdateBillingCycleViewModel model);

        void DeleteFileUpload(short AgreementId);

        int SaveChanges();

        IEnumerable<CContractAgreementViewModel> GetFileUploads();

        void UpdateSLAUpload(short ClientRowID = 0, byte SLAUpload = 0);

        void ActiveContractUpload(short id = 0, string checkeds = "");

        CContractAgreementListPageModel GetFileUpload(int pageNo, int pageSize, string sort, string sortDir, string Search = "",short CId=0);
        IEnumerable<ExportCContractAgreementViewModel> GetClientContractForExport(short CId = 0);
    }
}
