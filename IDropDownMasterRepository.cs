using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.ClientViewModel;
using ViewModels.HRViewModels;
using ViewModels.ProvidedInfoViewModel;
using ViewModels.VerificationViewModel;

namespace BAL
{
    public interface IDropDownMasterRepository
    {
        IEnumerable<CountryDDLViewModel> GetCountriesForDDL();
        IEnumerable<StateDDLViewModel> GetStatesByCountryIdForDDL(short CountryRowID);
        IEnumerable<DistrictDDLViewModel> GetDistrictsByStateIdForDDL(short StateRowID);
        IEnumerable<LocationDDLViewModel> GetLocationsByDistrictIdForDDL(short DistrictRowID);
       IEnumerable<CheckFamilyDDLViewModel> GetCheckFamilyForDDL();
        IEnumerable<UniversityDDLViewModel> GetUniversityForDDL();
        IEnumerable<ClientSubGroupDDLViewModel> GetClientSubGroupDDL();
        IEnumerable<CategoryDDLViewModel> GetCategoriesForDDL();
        IEnumerable<DepartmentDDLViewModel> GetDepartmentsForDDL();

        IEnumerable<DesignationDDLViewModel> GetDesignationsForDDL();
        IEnumerable<DesignationDDLViewModel> GetDesignationsForDDL(short id);

        IEnumerable<RepoToTeamMemberDDLViewModel> GetRepoToTeamMemberForDDL(short tdid = 0);
        IEnumerable<TeamMemberDDLViewModel> GetTeamMemberForDDL();
        IEnumerable<SpocForClientChkBLViewModel> GetSpocForClientForChkBoxList();
        IEnumerable<ClientDDLViewModel> GetClientListForDDLByClientSpocEmailID(string SpocEmailID = "");
        IEnumerable<SeverityGridDDLViewModel> GetClientSeveritiesGridDDL(short ClientRowID);

        IEnumerable<BillingCycleDDLViewModel> GetBillingCycleForDDL();
        IEnumerable<BranchOfficeDDLViewModel> GetBranchOfficeForDDL();
        IEnumerable<ClientAbbSubGroupDDLViewModel> GetClientAbbSubGroupDDL(short ClientAbbRowId);
        IEnumerable<SeverityGridDDLViewModel> GetSeverityGridDDL();
        IEnumerable<AntecedentDDLViewModel> GetAntecedentDDL();
        IEnumerable<ClientDDLViewModel> GetClientListWithAbbAndLocationForDDL();
        IEnumerable<ClientDesignationsDDLViewModel> GetClientDesignationsDDL();
        IEnumerable<PackagesDDLViewModel> GetPackagesForDDL();
        IEnumerable<ClientDDLViewModel> GetClientBaseOnloginMemberForDDL(short TeamMemberRowID = 0);

        IEnumerable<EmploymentDDLViewModel> GetEmploymentDDL();
        IEnumerable<CollegeDDLListViewModel> GetCollegeDDL();
        IEnumerable<DegreeDDLListViewModel> GetDegreeDDL();
        IEnumerable<SeverityGridDDLViewModel> GetColorDDL();
        IEnumerable<DispositionDDLViewModel> DispositionForDDL(short ChFamilRowId=0, short ClientRowId=0);
        IEnumerable<VendorDDLViewModel> GetVendorForDDL(short StateRowId = 0);
        IEnumerable<StateDDLViewModel> GetStatesByVendorDDL(short VendorId = 0);
        IEnumerable<VendorUserDDLViewModel> GetVendorByUserDDL(short VendorId = 0);

        IEnumerable<StateDDLViewModel> GetStatesByCountryIdForDDL(short CountryRowID, short teamMemerRowId);
        IEnumerable<StateDDLViewModel> GetStatesByArressStatesIdForDDL();
        IEnumerable<LocationDDLViewModel> GetCityByArressStatesIdForDDL();
        IEnumerable<PartnerDDLViewModel> GetPartnerByArressPartnerIdForDDL();
        IEnumerable<CollegeDDLListViewModel> GetCollegeDDLForVerification(int CollegeID);
        IEnumerable<DegreeDDLListViewModel> GetDegreeDDLForVerifier(int DegreeId);

        #region Comman Funtion
        IEnumerable<CheckActionHistoryViewModel> GetCheckActionHistory(int PersonalRowID = 0, short subCheckId = 0);
        IEnumerable<CaseActionHistoryViewModel> GetCaseActionHistories(int PersonalRowID = 0);
        IEnumerable<PQVerifiedUploadDocViewModel> PQAddressVerGetDocumentList(int PersonalRowID = 0, short subCheckId = 0);
        IEnumerable<PQAntecedentList> GetAntecedentVerList(short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0);
        IEnumerable<PQAntecedentList> GetAntecedentList(short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0);
        #endregion

    }
}
