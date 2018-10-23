using DAL.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("BGVSqlConn")
        {

        }

        #region **** Master Tables ****

        public DbSet<MasterCountry> MasterCountries { get; set; }
        public DbSet<MasterState> MasterStates { get; set; }
        public DbSet<MasterDistrict> MasterDistricts { get; set; }
        public DbSet<MasterLocation> MasterLocations { get; set; }
        public DbSet<MasterDepartment> MasterDepartments { get; set; }
        public DbSet<MasterDesignation> MasterDesignations { get; set; }
        public DbSet<MasterCategory> MasterCategories { get; set; }
        public DbSet<MasterBillingCycle> MasterBillingCycles { get; set; }
        public DbSet<MasterDegreeType> MasterDegreeTypes { get; set; }
        public DbSet<MasterUniversity> MasterUniversities { get; set; }
        public DbSet<MasterCollege> MasterColleges { get; set; }
        public DbSet<MasterEmployer> MasterEmployers { get; set; }
        public DbSet<MasterPoliceStation> MasterPoliceStations { get; set; }
        public DbSet<MasterCheckFamily> MasterCheckFamilies { get; set; }
        public DbSet<MasterSubCheckFamily> MasterSubCheckFamilies { get; set; }
        public DbSet<MasterAntecedentType> MasterAntecedentTypes { get; set; }
        public DbSet<MasterAntecedent> MasterAntecedents { get; set; }
        public DbSet<MasterSeverityGrid> MasterSeverityGrids { get; set; }
        public DbSet<MasterDisposition> MasterDispositions { get; set; }
        public DbSet<MasterCompany> MasterCompanies { get; set; }
        public DbSet<MasterCompanyBranch> MasterCompanyBranches { get; set; }
        public DbSet<MasterHoliday> MasterHolidays { get; set; }
        public DbSet<MasterVendor> MasterVendors { get; set; }
        public DbSet<MasterVendorCoverage> MasterVendorCoverages { get; set; }
        public DbSet<MasterVendorCoverageDistrict> MasterVendorCoverageDistricts { get; set; }
        public DbSet<MasterVendorLogin> MasterVendorLogins { get; set; }

        #endregion

        #region **** Client Tables ****

        public DbSet<MasterClientAbbreviation> MasterClientAbbreviations { get; set; }
        public DbSet<MasterClientSubGroup> MasterClientSubGroups { get; set; }
        public DbSet<PQClientMaster> PQClientMasters { get; set; }
        public DbSet<PQClientSeverity> PQClientSeverities { get; set; }
        public DbSet<PQClientContract> PQClientContracts { get; set; }
        public DbSet<PQClientCheck> PQClientChecks { get; set; }
        public DbSet<PQClientField> PQClientFields { get; set; }
        public DbSet<PQClientPackage> PQClientPackages { get; set; }
        public DbSet<PQClientDisposition> PQClientDispositions { get; set; }
        public DbSet<PQClientHoliday> PQClientHolidays { get; set; }
        public DbSet<PQClientLogin> PQClientLogins { get; set; }
        public DbSet<PQClientTeamMember> PQClientTeamMembers { get; set; }
        public DbSet<PQClientBulkUpload> PQClientBulkUploads { get; set; }
        public DbSet<PQClientCandidateBulkUpload> PQClientCandidateBulkUploads { get; set; }

        #endregion

        #region **** HR Management Tables ****

        public DbSet<TeamMember>TeamMembers { get; set; }
        public DbSet<TeamDepartment> TeamDepartments { get; set; }
        public DbSet<TeamMemberReporting> TeamMemberReportings { get; set; }
        //public DbSet<UserType> UserTypes { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
        //public DbSet<UserRightModule> UserRightModules { get; set; }
        //public DbSet<UserRight> UserRights { get; set; }
        public DbSet<UserLoginLogOutDetail> UserLoginLogOutDetails { get; set; }

        #endregion

        #region ******* Operation Module *******

        public DbSet<PQPersonal> PQPersonals { get; set; }
        public DbSet<PQCandidateCheck> PQCandidateChecks { get; set; }
        public DbSet<PQLogTrasaction> PQLogTrasactions { get; set; }
        public DbSet<PQVerifiedUploadDoc> PQVerifiedUploadDocs { get; set; }
        public DbSet<PQAddress> PQAddresss { get; set; }
        public DbSet<PQEmployment> PQEmployments { get; set; }
        public DbSet<PQEducation> PQEducations { get; set; }
        public DbSet<PQCriminal> PQCriminals { get; set; }
        public DbSet<PQReference> PQReferences { get; set; }
        public DbSet<PQNationalIdentity> PQNationalIdentities { get; set; }
        public DbSet<CaseActionHistory> CaseActionHistories { get; set; }
        public DbSet<CheckActionHistory> CheckActionHistories { get; set; }
        public DbSet<PQCandidateLogin> PQCandidateLogins { get; set; }
        public DbSet<PQEducationResearch> PQEducationResearchs { get; set; }
        public DbSet<PQEmploymentResearch> PQEmploymentResearchs { get; set; }
        public DbSet<PQVerifiedUploadCaseDoc> PQVerifiedUploadCaseDocs { get; set; }

        public DbSet<PQSpecialCheck> PQSpecialChecks { get; set; }

        ////public DbSet<PQDrugTest> PQDrugTests { get; set; }

        #endregion

        #region ***** Temp Operation Module *******

        public DbSet<TempPQPersonal> TempPQPersonals { get; set; }
        public DbSet<TempPQCandidateCheck> TempPQCandidateChecks { get; set; }
        public DbSet<TempPQAddress> TempPQAddresss { get; set; }
        public DbSet<TempPQEmployment> TempPQEmployments { get; set; }
        public DbSet<TempPQEducation> TempPQEducations { get; set; }
        public DbSet<TempPQReference> TempPQReferences { get; set; }
        public DbSet<TempPQCriminal> TempPQCriminals { get; set; }
        public DbSet<TempPQNationalIdentity> TempPQNationalIdentities { get; set; }
        public DbSet<TempPQVerifiedUploadDoc> TempPQVerifiedUploadDocs { get; set; }
        public DbSet<TempPQSpecialCheck> TempPQSpecialChecks { get; set; }

        #endregion

        #region ********** Verification Tables **********

        public DbSet<PQAddressVer> PQAddressVers { get; set; }
        public DbSet<PQAddressVerDisposition> PQAddressVerDispositions { get; set; }
        public DbSet<PQAddressStatus> PQAddressStatus { get; set; }

        public DbSet<PQEmploymentVer> PQEmploymentVers { get; set; }
        public DbSet<PQEmploymentVerDisposition> PQEmploymentVerDispositions { get; set; }
        public DbSet<PQEmploymentStatus> PQEmploymentStatus { get; set; }

        public DbSet<PQEducationVer> PQEducationVers { get; set; }
        public DbSet<PQEducationVerDisposition> PQEducationVerDispositions { get; set; }
        public DbSet<PQEducationStatus> PQEducationStatus { get; set; }

        public DbSet<PQCriminalVer> PQCriminalVers { get; set; }
        public DbSet<PQCriminalVerDisposition> PQCriminalVerDispositions { get; set; }
        public DbSet<PQCriminalStatus> PQCriminalStatus { get; set; }

        public DbSet<PQReferenceVer> PQReferenceVers { get; set; }
        public DbSet<PQReferenceVerDisposition> PQReferenceVerDispositions { get; set; }
        public DbSet<PQReferenceStatus> PQReferenceStatus { get; set; }

        public DbSet<PQNationalIdentityVer> PQNationalIdentityVers { get; set; }
        public DbSet<PQNationalIdentityVerDisposition> PQNationalIdentityVerDispositions { get; set; }
        public DbSet<PQNationalIdentityStatus> PQNationalIdentityStatus { get; set; }

        public DbSet<PQCandidateInsuffLogin> PQCandidateInsuffLogins { get; set; }

        public DbSet<PQSpecialCheckVer> PQSpecialCheckVers { get; set; }
        public DbSet<PQSpecialCheckStatus> PQSpecialCheckStatus { get; set; }

        #endregion

        #region ********** Mobile App Tables **********

        public DbSet<PQAddressVarPartener> PQAddressVarParteners { get; set; }
        public DbSet<PQAddressPartenerUploadDocs> PQAddressPartenerUploadDocs { get; set; }

        #endregion

        ////public DbSet<ServerDetail> ServerDetails { get; set; }
        ////public DbSet<LoginLogOutDetail> LoginLogOutDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region **** Master Mapping Configuration ****

            modelBuilder.Configurations.Add<MasterCountry>(new MasterCountryMap());
            modelBuilder.Configurations.Add<MasterState>(new MasterStateMap());
            modelBuilder.Configurations.Add<MasterDistrict>(new MasterDistrictMap());
            modelBuilder.Configurations.Add<MasterLocation>(new MasterLocationMap());
            modelBuilder.Configurations.Add<MasterDepartment>(new MasterDepartmentMap());
            modelBuilder.Configurations.Add<MasterDesignation>(new MasterDesignationMap());
            modelBuilder.Configurations.Add<MasterCategory>(new MasterCategoryMap());
            modelBuilder.Configurations.Add<MasterBillingCycle>(new MasterBillingCycleMap());
            modelBuilder.Configurations.Add<MasterDegreeType>(new MasterDegreeTypeMap());
            modelBuilder.Configurations.Add<MasterUniversity>(new MasterUniversityMap());
            modelBuilder.Configurations.Add<MasterCollege>(new MasterCollegeMap());
            modelBuilder.Configurations.Add<MasterEmployer>(new MasterEmployerMap());
            modelBuilder.Configurations.Add<MasterPoliceStation>(new MasterPoliceStationMap());
            modelBuilder.Configurations.Add<MasterCheckFamily>(new MasterCheckFamilyMap());
            modelBuilder.Configurations.Add<MasterSubCheckFamily>(new MasterSubCheckFamilyMap());
            modelBuilder.Configurations.Add<MasterAntecedentType>(new MasterAntecedentTypeMap());
            modelBuilder.Configurations.Add<MasterAntecedent>(new MasterAntecedentMap());
            modelBuilder.Configurations.Add<MasterSeverityGrid>(new MasterSeverityGridMap());
            modelBuilder.Configurations.Add<MasterDisposition>(new MasterDispositionMap());
            modelBuilder.Configurations.Add<MasterCompany>(new MasterCompanyMap());
            modelBuilder.Configurations.Add<MasterCompanyBranch>(new MasterCompanyBranchMap());
            modelBuilder.Configurations.Add<MasterHoliday>(new MasterHolidayMap());
            modelBuilder.Configurations.Add<MasterVendor>(new MasterVendorMap());
            modelBuilder.Configurations.Add<MasterVendorCoverage>(new MasterVendorCoverageMap());
            modelBuilder.Configurations.Add<MasterVendorCoverageDistrict>(new MasterVendorCoverageDistrictMap());
            modelBuilder.Configurations.Add<MasterVendorLogin>(new MasterVendorLoginMap());

            #endregion

            #region **** Client-Details Mapping Configuration ****

            modelBuilder.Configurations.Add<MasterClientAbbreviation>(new MasterClientAbbreviationMap());
            modelBuilder.Configurations.Add<MasterClientSubGroup>(new MasterClientSubGroupMap());
            modelBuilder.Configurations.Add<PQClientMaster>(new PQClientMasterMap());
            modelBuilder.Configurations.Add<PQClientSeverity>(new PQClientSeverityMap());
            modelBuilder.Configurations.Add<PQClientContract>(new PQClientContractMap());
            modelBuilder.Configurations.Add<PQClientCheck>(new PQClientCheckMap());
            modelBuilder.Configurations.Add<PQClientField>(new PQClientFieldMap());
            modelBuilder.Configurations.Add<PQClientPackage>(new PQClientPackageMap());
            modelBuilder.Configurations.Add<PQClientDisposition>(new PQClientDispositionMap());
            modelBuilder.Configurations.Add<PQClientHoliday>(new PQClientHolidayMap());
            modelBuilder.Configurations.Add<PQClientLogin>(new PQClientLoginMap());
            modelBuilder.Configurations.Add<PQClientTeamMember>(new PQClientTeamMemberMap());
            modelBuilder.Configurations.Add<PQClientBulkUpload>(new PQClientBulkUploadMap());
            modelBuilder.Configurations.Add<PQClientCandidateBulkUpload>(new PQClientCandidateBulkUploadMap());

            #endregion

            #region **** HRMgmt Mapping Configuration ****

            modelBuilder.Configurations.Add<TeamMember>(new TeamMemberMap());
            modelBuilder.Configurations.Add<TeamDepartment>(new TeamDepartmentMap());
            modelBuilder.Configurations.Add<TeamMemberReporting>(new TeamMemberReportingMap());
            modelBuilder.Configurations.Add<WebUser>(new WebUserMap());
            modelBuilder.Configurations.Add<UserLoginLogOutDetail>(new UserLoginLogOutDetailMap());

            //modelBuilder.Configurations.Add<UserRight>(new UserRightMap());
            //modelBuilder.Configurations.Add<UserRightModule>(new UserRightModuleMap());
            //modelBuilder.Configurations.Add<UserType>(new UserTypeMap());

            #endregion

            #region ******* Operation Module *******

            modelBuilder.Configurations.Add<PQPersonal>(new PQPersonalMap());
            modelBuilder.Configurations.Add<PQCandidateCheck>(new PQCandidateCheckMap());
            modelBuilder.Configurations.Add<PQLogTrasaction>(new PQLogTrasactionMap());
            modelBuilder.Configurations.Add<PQVerifiedUploadDoc>(new PQVerifiedUploadDocMap());
            modelBuilder.Configurations.Add<PQAddress>(new PQAddressMap());
            modelBuilder.Configurations.Add<PQEmployment>(new PQEmploymentMap());
            modelBuilder.Configurations.Add<PQEducation>(new PQEducationMap());
            modelBuilder.Configurations.Add<PQCriminal>(new PQCriminalMap());
            modelBuilder.Configurations.Add<PQReference>(new PQReferenceMap());
            modelBuilder.Configurations.Add<PQNationalIdentity>(new PQNationalIdentityMap());
            modelBuilder.Configurations.Add<CaseActionHistory>(new CaseActionHistoryMap());
            modelBuilder.Configurations.Add<CheckActionHistory>(new CheckActionHistoryMap());
            modelBuilder.Configurations.Add<PQCandidateLogin>(new PQCandidateLoginMap());
            modelBuilder.Configurations.Add<PQEducationResearch>(new PQEducationResearchMap());
            modelBuilder.Configurations.Add<PQEmploymentResearch>(new PQEmploymentResearchMap());
            modelBuilder.Configurations.Add<PQVerifiedUploadCaseDoc>(new PQVerifiedUploadCaseDocMap());

            modelBuilder.Configurations.Add<PQSpecialCheck>(new PQSpecialCheckMap());


            ////modelBuilder.Configurations.Add<PQDrugTest>(new PQDrugTestMap());

            #endregion

            #region ********* Temp Operation Module **********

            modelBuilder.Configurations.Add<TempPQPersonal>(new TempPQPersonalMap());
            modelBuilder.Configurations.Add<TempPQCandidateCheck>(new TempPQCandidateCheckMap());
            modelBuilder.Configurations.Add<TempPQAddress>(new TempPQAddressMap());
            modelBuilder.Configurations.Add<TempPQEmployment>(new TempPQEmploymentMap());
            modelBuilder.Configurations.Add<TempPQEducation>(new TempPQEducationMap());
            modelBuilder.Configurations.Add<TempPQReference>(new TempPQReferenceMap());
            modelBuilder.Configurations.Add<TempPQCriminal>(new TempPQCriminalMap());
            modelBuilder.Configurations.Add<TempPQNationalIdentity>(new TempPQNationalIdentityMap());
            modelBuilder.Configurations.Add<TempPQVerifiedUploadDoc>(new TempPQVerifiedUploadDocMap());
            modelBuilder.Configurations.Add<TempPQSpecialCheck>(new TempPQSpecialCheckMap());

            #endregion

            #region ********** Verification Mapping Cofiguration **********

            modelBuilder.Configurations.Add<PQAddressVer>(new PQAddressVerMap());
            modelBuilder.Configurations.Add<PQAddressVerDisposition>(new PQAddressVerDispositionMap());
            modelBuilder.Configurations.Add<PQAddressStatus>(new PQAddressStatusMap());

            modelBuilder.Configurations.Add<PQEmploymentVer>(new PQEmploymentVerMap());
            modelBuilder.Configurations.Add<PQEmploymentVerDisposition>(new PQEmploymentVerDispositionMap());
            modelBuilder.Configurations.Add<PQEmploymentStatus>(new PQEmploymentStatusMap());

            modelBuilder.Configurations.Add<PQEducationVer>(new PQEducationVerMap());
            modelBuilder.Configurations.Add<PQEducationVerDisposition>(new PQEducationVerDispositionMap());
            modelBuilder.Configurations.Add<PQEducationStatus>(new PQEducationStatusMap());

            modelBuilder.Configurations.Add<PQCriminalVer>(new PQCriminalVerMap());
            modelBuilder.Configurations.Add<PQCriminalVerDisposition>(new PQCriminalVerDispositionMap());
            modelBuilder.Configurations.Add<PQCriminalStatus>(new PQCriminalStatusMap());

            modelBuilder.Configurations.Add<PQReferenceVer>(new PQReferenceVerMap());
            modelBuilder.Configurations.Add<PQReferenceVerDisposition>(new PQReferenceVerDispositionMap());
            modelBuilder.Configurations.Add<PQReferenceStatus>(new PQReferenceStatusMap());

            modelBuilder.Configurations.Add<PQNationalIdentityVer>(new PQNationalIdentityVerMap());
            modelBuilder.Configurations.Add<PQNationalIdentityVerDisposition>(new PQNationalIdentityVerDispositionMap());
            modelBuilder.Configurations.Add<PQNationalIdentityStatus>(new PQNationalIdentityStatusMap());

            modelBuilder.Configurations.Add<PQCandidateInsuffLogin>(new PQCandidateInsuffLoginMap());

            modelBuilder.Configurations.Add<PQSpecialCheckVer>(new PQSpecialCheckVerMap());
            modelBuilder.Configurations.Add<PQSpecialCheckStatus>(new PQSpecialCheckStatusMap());

            #endregion

            #region ********** Mobile App Tables **********

            modelBuilder.Configurations.Add<PQAddressVarPartener>(new PQAddressVarPartenerMap());
            modelBuilder.Configurations.Add<PQAddressPartenerUploadDocs>(new PQAddressPartenerUploadDocsMap());

            #endregion

            ////modelBuilder.Configurations.Add<ServerDetail>(new ServerDetailMap());
            ////modelBuilder.Configurations.Add<LoginLogOutDetail>(new LoginLogOutDetailMap());
        }
}
}
