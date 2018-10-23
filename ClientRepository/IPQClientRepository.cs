using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public interface IPQClientRepository
    {
        bool IsPQClientExist(string PQClientName);
        bool IsPQClientExist(short ClientRowID, string PQClientName);
        void AddPQClient(AddPQClientViewModel model);
        UpdatePQClientViewModel GetPQClientForUpdateById(short ClientRowID=0);
        PQClientForCandiCodeGenViewModel GetPQClientForCadiCodeGenById(short ClientRowID = 0);
        PQClientAntDispositionViewModel GetClientSelectedAntAndDisposition(short ClientRowId = 0);
        void UpdatePQClient(UpdatePQClientViewModel model);
        void DeletePQClient(short CRowID);
        int SaveChanges();
        IEnumerable<PQClientViewModel> GetPQClients();
        PQClientListPagedModel GetPQClient(int pageNo, int pageSize, string sort, string sortDir, string Search = "");
        void AddClientSevirityDetails(string ClientCode = "", short ClientSubgroupID = 0);
        void AddClientDefaultHolidays(string ClientCode = "", short ClientSubgroupID = 0);
        bool IsPQClientData(string ClientCode, short ClientSubgroupID);
        string GetClientAbbName(short ClientAbbRowID);
        void PQClientMailConfig(PQClientMailConfig model);
        PQClientMailConfig GetClientMailById(short ClientRowID);
        PQClientCodeHolidaysViewModel GetPQClientCodeHolidaysById(short ClientRowID = 0);
        IEnumerable<ClientCheckPackageViewModel> GetChecksAndPackageByClientId(short cid = 0, byte PricingType = 0);
        PQClientMailFromViewModel GetPQClientSendMailFromById(short ClientRowID);
        string GetCompanySPOCEmailIdFromPQClientMasterById(short ClientRowID);
        PQClientForExtraExpViewModel GetClientExtraExpensesAllowedByID(short ClientRowID = 0);
        ClientContractConditions GetClientContractConditions(short ClientRowID);
        string GetClientSpecialInstructionByID(short ClientRowID = 0);
        int GetClientPricingTypeById(short ClientRowID = 0);
        string GetSubGroupName(short ClientSubgroupID);
        IEnumerable<ExportClientViewModel> GetClientForExport();
        IEnumerable<ExportClientCheckViewModel> GetClientChecksForExport(short CId = 0);
        IEnumerable<ExportClientPackageViewModel> GetClientPackageForExport(short CId = 0);
        IEnumerable<ExportClientTMemberViewModel> GetClientTeamMemberForExport(short CId = 0);
        IEnumerable<ExportClientLoginViewModel> GetClientLoginForExport();

    }
}
