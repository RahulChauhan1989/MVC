using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using BAL;
using BAL.ClientRepository;
using BAL.HRRepository;
using BAL.ProvidedInfoRepository;
using BAL.CandidateRepository;
using BAL.VerificationRepository;
using BAL.PartnerRepository;
using BAL.ReportQCRepository;
using BAL.PVRepository;

namespace WebAppBGV
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDropDownMasterRepository, DropDownMasterRepository>();
            container.RegisterType<IBranchOfficeRepository, BranchOfficeRepository>();
            container.RegisterType<ICountryRepository, CountryRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IBillingCycleRepository, BillingCycleRepository>();
            container.RegisterType<IStateRepository, StateRepository>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<IDistrictRepository, DistrictRepository>();
            container.RegisterType<IDepartmentsRepository, DepartmentRepository>();
            container.RegisterType<IDesignationRepository, DesignationRepository>();
            container.RegisterType<IDegreeTypeRepository, DegreeTypeRepository>();
            container.RegisterType<ICheckFamilyRepository, CheckFamilyRepository>();
            container.RegisterType<ISubCheckFamilyRepository, SubCheckFamilyRepository>();
            container.RegisterType<IUniversityRepository, UniversityRepository>();
            container.RegisterType<ICollegeRepository, CollegeRepository>();
            container.RegisterType<IEmployerRepository, EmployerRepository>();
            container.RegisterType<IVendorRepository, VendorRepository>();
            container.RegisterType<IAbbreviationRepository, AbbreviationRepository>();
            container.RegisterType<IClientSubGroupRepository, ClientSubGroupRepository>();
            container.RegisterType<IPoliceStationRepository, PoliceStationRepository>();
            container.RegisterType<ITeamMemberRepository, TeamMemberRepository>();
            container.RegisterType<IWebUserRepository, WebUserRepository>();
            container.RegisterType<IPoliceStationRepository, PoliceStationRepository>();
            container.RegisterType<IPQClientRepository, PQClientRepository>();
            container.RegisterType<IDispositionRepository, DispositionRepository>();
            container.RegisterType<ISeverityGridRepository, SeverityGridRepository>();
            container.RegisterType<IClientContractUploadRepository, ClientContractUploadRepository>();
            container.RegisterType<IClientSeverityRepository, ClientSeverityRepository>();
            container.RegisterType<IClientPackageRepository, ClientPackageRepository>();
            container.RegisterType<IClientCheckRepository, ClientCheckRepository>();
            container.RegisterType<IAntecedentRepository, AntecedentRepository>();
            container.RegisterType<IClientAntecedentFieldRepository, ClientAntecedentsFieldRepository>();
            container.RegisterType<IClientLoginRepository, ClientLoginRepository>();
            container.RegisterType<IPQPersonalRepository, PQPersonalRepository>();           
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<IVendorCoverageRepository, VendorCoverageRepository>();
            container.RegisterType<IHolidayRepository, HolidayRepository>();
            container.RegisterType<IVCoverageDistrictRepository, VCoverageDistrictRepository>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IClientDispositionRepository, ClientDispositionRepository>();
            container.RegisterType<IPQClientHolidayRepository, PQClientHolidayRepository>();
            container.RegisterType<IPQClientTMemberRepository, PQClientTMemberRepository>();
            container.RegisterType<IPQCandidateCheckRepository, PQCandidateCheckRepository>();
            container.RegisterType<IPQLogTrasactionRepository, PQLogTrasactionRepository>();
            container.RegisterType<IPQCandidateLoginRepository, PQCandidateLoginRepository>();
            container.RegisterType<IAddressInfoRepository, AddressInfoRepository>();
            container.RegisterType<IEmploymentInfoRepository, EmploymentInfoRepository>();
            container.RegisterType<IEducationInfoRepository, EducationInfoRepository>();
            container.RegisterType<ICriminalInfoRepository, CriminalInfoRepository>();
            container.RegisterType<INationalIdentityInfoRepository, NationalIdentityInfoRepository>();
            container.RegisterType<IReferenceInfoRepository, ReferenceInfoRepository>();
            container.RegisterType<IInsuranceInfoRepository, InsuranceInfoRepository>();
            container.RegisterType<IPQVerifiedUploadDocRepository, PQVerifiedUploadDocRepository>();
            container.RegisterType<IPQClientCompnayUploadDocRepository, PQClientCompnayUploadDocRepository>();
            container.RegisterType<IPQClientCandiBulkUploadRepository, PQClientCandiBulkUploadRepository>();
            container.RegisterType<ICheckTempCandidateCaseStatusRepository, CheckTempCandidateCaseStatusRepository>();
            container.RegisterType<IVerificationInfoRepository, VerificationInfoRepository>();
            container.RegisterType<IPQAddressVerRepository, PQAddressVerRepository>();
            container.RegisterType<ITeamDepartmentRepository, TeamDepartmentRepository>();
            container.RegisterType<IClientCompletedContractRepository, ClientCompletedContractRepository>();
            container.RegisterType<IEducationResearchRepository, EducationResearchRepository>();
            container.RegisterType<IEmploymentResearchRepository, EmploymentResearchRepository>();
            container.RegisterType<IDashboardVerificationRepository, DashboardVerificationRepository>();
            container.RegisterType<IPQEmploymentVerRepository, PQEmploymentVerRepository>();
            container.RegisterType<ICheckActionHistoryRepository, CheckActionHistoryRepository>();
            container.RegisterType<IPQEducationVerRepository, PQEducationVerRepository>();
            container.RegisterType<IPQCriminalVerRepository, PQCriminalVerRepository>();
            container.RegisterType<IPQReferenceVerRepository, PQReferenceVerRepository>();
            container.RegisterType<IPQNationalIdentityVerRepository, PQNationalIdentityVerRepository>();
            container.RegisterType<ICaseActionHistoryRepository, CaseActionHistoryRepository>();
            container.RegisterType<IPQVerifiedUploadCaseDocRepository, PQVerifiedUploadCaseDocRepository>();
            container.RegisterType<IEmailVerificationRepository, EmailVerificationRepository>();
            container.RegisterType<IMasterVendorLoginRepository, MasterVendorLoginRepository>();
            container.RegisterType<IPartnerVerificationRepository, PartnerVerificationRepository>();
            container.RegisterType<IPartnerAddressVerRepository, PartnerAddressVerRepository>();
            container.RegisterType<IDashboardPVRepository, DashboardPVRepository>();
            container.RegisterType<IReportQCRepository, ReportQCRepository>();
            container.RegisterType<IDashboardDataEntryRepository, DashboardDataEntryRepository>();
            container.RegisterType<IDashboardRWQCRepository, DashboardRWQCRepository>();
            container.RegisterType<IClientDashboardRepository, ClientDashboardRepository>();
            container.RegisterType<IPartnerDashboardRepository, PartnerDashboardRepository>();
            container.RegisterType<IClientServicingRepository, ClientServicingRepository>();
            container.RegisterType<IPVInfoRepository, PVInfoRepository>();
            container.RegisterType<IUploadDocClientRepository, UploadDocClientRepository>();
            container.RegisterType<ISpecialCheckInfoRepository, SpecialCheckInfoRepository>();
            container.RegisterType<ISpecialVerificationRepository, SpecialVerificationRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}