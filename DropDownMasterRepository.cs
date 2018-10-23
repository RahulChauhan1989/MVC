using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.HRViewModels;
using ViewModels.ClientViewModel;
using ViewModels.ProvidedInfoViewModel;

namespace BAL
{
    public class DropDownMasterRepository : IDropDownMasterRepository
    {
        DataContext db;

        public DropDownMasterRepository()
        {
            db = new DataContext();
        }

        public IEnumerable<CountryDDLViewModel> GetCountriesForDDL()
        {
            try
            {
                return db.MasterCountries.Where(c => c.Status == 1).Select(c => new CountryDDLViewModel { CountryRowID = c.CountryRowID, CountryName = c.CountryName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<StateDDLViewModel> GetStatesByCountryIdForDDL(short CountryRowID)
        {
            try
            {
                return db.MasterStates.Where(s => s.CountryRowID == CountryRowID && s.Status == 1).Select(s => new StateDDLViewModel { StateRowID = s.StateRowID, StateName = s.StateName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DistrictDDLViewModel> GetDistrictsByStateIdForDDL(short StateRowID)
        {
            try
            {
                return db.MasterDistricts.Where(d => d.StateRowID == StateRowID && d.Status == 1).Select(d => new DistrictDDLViewModel { DistrictRowID = d.DistrictRowID, DistrictName = d.DistrictName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LocationDDLViewModel> GetLocationsByDistrictIdForDDL(short DistrictRowID)
        {
            try
            {
                return db.MasterLocations.Where(l => l.DistrictRowID == DistrictRowID && l.Status == 1).Select(l => new LocationDDLViewModel { LocationRowID = l.LocationRowID, LocationName = l.LocationName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CheckFamilyDDLViewModel> GetCheckFamilyForDDL()
        {
            try
            {
                return db.MasterCheckFamilies.Where(c => c.Status == 1).Select(c => new CheckFamilyDDLViewModel { CheckFamilyRowID = c.CheckFamilyRowID, CheckFamilyName = c.CheckFamilyName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<UniversityDDLViewModel> GetUniversityForDDL()
        {
            try
            {
                return db.MasterUniversities.Where(c => c.Status == 1).Select(c => new UniversityDDLViewModel { UniversityRowID = c.UniversityRowID, UniversityName = c.UniversityName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CategoryDDLViewModel> GetCategoriesForDDL()
        {
            try
            {
                return db.MasterCategories.Where(c => c.Status == 1).Select(c => new CategoryDDLViewModel { CategoryRowID = c.CategoryRowID, CategoryName = c.CategoryName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<RepoToTeamMemberDDLViewModel> GetRepoToTeamMemberForDDL(short tdid = 0)
        {
            try
            {
                var TeamDepart = db.TeamDepartments.Find(tdid);

                string TMName = db.MasterDesignations.Find(TeamDepart.DesignationRowID).DesignationName;
                if (!string.IsNullOrEmpty(TMName))
                {
                    if (TMName.StartsWith("Manager-PRT"))
                    {
                        return db.TeamDepartments.Where(t => t.MasterDepartment.DepartmentName == "Address" && t.MasterDesignation.DesignationName == "Team Member-Add"
                        ).Select(a => new RepoToTeamMemberDDLViewModel
                        {
                            TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                            TeamDepartmentRowID = a.TeamDepartmentRowID,
                        }
                         ).ToList();
                    }
                    else if (TMName.StartsWith("Manager"))
                    {
                        return db.TeamDepartments.Where(t => t.DepartmentRowID == TeamDepart.DepartmentRowID && t.DesignationRowID != TeamDepart.DesignationRowID
                          && t.MasterDesignation.DesignationName.StartsWith("Head of Operation")).Select(a => new RepoToTeamMemberDDLViewModel
                          {
                              TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                              TeamDepartmentRowID = a.TeamDepartmentRowID,
                          }
                         ).ToList();
                    }
                    else if (TMName.StartsWith("Team Leader"))
                    {
                        return db.TeamDepartments.Where(t => t.DepartmentRowID == TeamDepart.DepartmentRowID && t.DesignationRowID != TeamDepart.DesignationRowID
                          && t.MasterDesignation.DesignationName.StartsWith("Manager")).Select(a => new RepoToTeamMemberDDLViewModel
                          {
                              TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                              TeamDepartmentRowID = a.TeamDepartmentRowID,
                          }
                         ).ToList();
                    }
                    else if (TMName.StartsWith("Team Member"))
                    {
                        return db.TeamDepartments.Where(t => t.DepartmentRowID == TeamDepart.DepartmentRowID && t.DesignationRowID != TeamDepart.DesignationRowID
                        && t.MasterDesignation.DesignationName.StartsWith("Team Leader")).Select(a => new RepoToTeamMemberDDLViewModel
                        {
                            TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                            TeamDepartmentRowID = a.TeamDepartmentRowID,
                        }
                       ).ToList();
                    }

                    else if (TMName.StartsWith("Retention-CS") || TMName.StartsWith("Implant-CS"))
                    {
                        return db.TeamDepartments.Where(t => t.DepartmentRowID == TeamDepart.DepartmentRowID && t.DesignationRowID != TeamDepart.DesignationRowID
                        && (t.MasterDesignation.DesignationName.StartsWith("Team Leader") || t.MasterDesignation.DesignationName.StartsWith("Manager"))).Select(a => new RepoToTeamMemberDDLViewModel
                        {
                            TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                            TeamDepartmentRowID = a.TeamDepartmentRowID,
                        }
                       ).ToList();
                    }
                    else if (TMName.StartsWith("Field Verifier"))
                    {
                        return db.TeamDepartments.Where(t => t.DepartmentRowID == TeamDepart.DepartmentRowID && t.DesignationRowID != TeamDepart.DesignationRowID
                        && (t.MasterDesignation.DesignationName.StartsWith("Team Leader") || t.MasterDesignation.DesignationName.StartsWith("Manager"))).Select(a => new RepoToTeamMemberDDLViewModel
                        {
                            TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                            TeamDepartmentRowID = a.TeamDepartmentRowID,
                        }
                       ).ToList();
                    }
                    else if (TMName.StartsWith("Client Management"))
                    {
                        return db.TeamDepartments.Where(t => t.DepartmentRowID == TeamDepart.DepartmentRowID && t.DesignationRowID != TeamDepart.DesignationRowID
                        && t.MasterDesignation.DesignationName.StartsWith("Head of Operation")).Select(a => new RepoToTeamMemberDDLViewModel
                        {
                            TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                            TeamDepartmentRowID = a.TeamDepartmentRowID,
                        }
                       ).ToList();
                    }
                    else if (TMName.StartsWith("Master Management"))
                    {
                        return db.TeamDepartments.Where(t => t.DepartmentRowID == TeamDepart.DepartmentRowID && t.DesignationRowID != TeamDepart.DesignationRowID
                        && t.MasterDesignation.DesignationName.StartsWith("Head of Operation")).Select(a => new RepoToTeamMemberDDLViewModel
                        {
                            TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                            TeamDepartmentRowID = a.TeamDepartmentRowID,
                        }
                       ).ToList();
                    }
                    else if (TMName.StartsWith("Assistant Manager"))
                    {
                        return db.TeamDepartments.Where(t => t.DepartmentRowID == TeamDepart.DepartmentRowID && t.DesignationRowID != TeamDepart.DesignationRowID
                        && t.MasterDesignation.DesignationName.StartsWith("Head of Operation")).Select(a => new RepoToTeamMemberDDLViewModel
                        {
                            TeamMemberName = a.TeamMember.TMTitle + " " + a.TeamMember.TMFirstName + " " + a.TeamMember.TMLastName + " (" + a.MasterDesignation.DesignationName + ")",
                            TeamDepartmentRowID = a.TeamDepartmentRowID,
                        }
                       ).ToList();
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DepartmentDDLViewModel> GetDepartmentsForDDL()
        {
            try
            {
                return db.MasterDepartments.Where(c => c.Status == 1).Select(c => new DepartmentDDLViewModel { DepartmentRowID = c.DepartmentRowID, DepartmentName = c.DepartmentName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DesignationDDLViewModel> GetDesignationsForDDL()
        {
            try
            {
                return db.MasterDesignations.Where(c => c.Status == 1).Select(c => new DesignationDDLViewModel { DesignationRowID = c.DesignationRowID, DepartmentRowID = c.DepartmentRowID, DesignationName = c.DesignationName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DesignationDDLViewModel> GetDesignationsForDDL(short DepartmentId = 0)
        {
            try
            {
                return db.MasterDesignations.Where(c => c.DepartmentRowID == DepartmentId && c.Status == 1).Select(c => new DesignationDDLViewModel { DesignationRowID = c.DesignationRowID, DesignationName = c.DesignationName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientSubGroupDDLViewModel> GetClientSubGroupDDL()
        {
            try
            {
                return db.MasterClientAbbreviations.Where(c => c.Status == 1).Select(c => new ClientSubGroupDDLViewModel { ClientAbbRowID = c.ClientAbbRowID, ClientName = c.ClientName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientAbbSubGroupDDLViewModel> GetClientAbbSubGroupDDL(short ClientAbbRowID)
        {
            try
            {
                return db.MasterClientSubGroups.Where(c => c.Status == 1 && c.ClientAbbRowID == ClientAbbRowID).Select(c => new ClientAbbSubGroupDDLViewModel { ClientSubGroupID = c.ClientSubGroupID, SubGroupName = c.ClientSubGroupName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TeamMemberDDLViewModel> GetTeamMemberForDDL()
        {
            try
            {
                short[] arrTeamMemberRowIDs = db.WebUsers.Where(w => w.Status == 1 || w.Status == 3).Select(w => w.TeamMemberRoWID).ToArray<short>();

                var TeamMemberListForDDL = (from a in db.TeamMembers.Where(t => t.Status == 1 && !arrTeamMemberRowIDs.Contains(t.TeamMemberRowID))
                                            select new TeamMemberDDLViewModel
                                            {
                                                TeamMemberName = a.TMFirstName + " " + a.TMLastName + " (" + a.EmployeeID + ")",
                                                TeamMemberRowID = a.TeamMemberRowID,
                                            }
                          //orderby a.TMFirstName ascending
                          ).ToList().OrderBy(w => w.TeamMemberName);

                return TeamMemberListForDDL;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SpocForClientChkBLViewModel> GetSpocForClientForChkBoxList()
        {
            try
            {
                var CompanySpoc = db.TeamDepartments.Where(t => t.MasterDepartment.DepartmentName == "Client Servicing").Select(t => new SpocForClientChkBLViewModel
                {
                    SpocEmail = t.TeamMember.EmailID,
                    SpocNameWDesig = (t.TeamMember.TMFirstName + " " + t.TeamMember.TMLastName).Trim() + " (" + t.MasterDesignation.DesignationName + ")"
                }).ToList();

                return CompanySpoc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<BillingCycleDDLViewModel> GetBillingCycleForDDL()
        {

            try
            {
                return db.MasterBillingCycles.Where(d => d.Status == 1).Select(d => new BillingCycleDDLViewModel { BillingRowID = d.BillingRowID, BillingCycle = d.BillingCycle }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<BranchOfficeDDLViewModel> GetBranchOfficeForDDL()
        {

            try
            {
                return db.MasterCompanyBranches.Where(d => d.Status == 1).Select(d => new BranchOfficeDDLViewModel { BORowID = d.BORowID, BOName = d.BOName }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SeverityGridDDLViewModel> GetSeverityGridDDL()
        {

            try
            {
                return db.MasterSeverityGrids.Where(d => d.Status == 1).Select(s => new SeverityGridDDLViewModel { SeverityGridRowId = s.SeverityGridRowId, SeverityGridName = s.SeverityGrid }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SeverityGridDDLViewModel> GetClientSeveritiesGridDDL(short ClientRowID)
        {

            try
            {
                return db.PQClientSeverities.Where(d => d.Status == 1 && d.ClientRowID== ClientRowID).Select(s => new SeverityGridDDLViewModel { SeverityGridRowId = s.SeverityGridRowId, SeverityGridName = s.MasterSeverityGrid.SeverityGrid }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<AntecedentDDLViewModel> GetAntecedentDDL()
        {
            try
            {
                return db.MasterAntecedentTypes.Where(d => d.Status == 1).Select(s => new AntecedentDDLViewModel { AntecedentTypeRowId = s.AntecedentTypeRowId, AntecedentTypeName = s.AntecedentTypeName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientDDLViewModel> GetClientListWithAbbAndLocationForDDL()
        {
            try
            {
                var ClientName = db.PQClientMasters.Select(s => new ClientDDLViewModel
                {
                    ClientRowID = s.ClientRowID,
                    ClientName = s.MasterAbbreviation.ClientName + " (" + s.MasterClientSubGroup.ClientSubGroupName + ")-" + s.MasterLocation.LocationName
                }).ToList();
                return ClientName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientDDLViewModel> GetClientListForDDLByClientSpocEmailID(string SpocEmailID = "")
        {
            try
            {
                var ClientName = db.PQClientMasters.Where(s => s.SpocEmailID.Contains(SpocEmailID)).Select(s => new ClientDDLViewModel
                {
                    ClientRowID = s.ClientRowID,
                    ClientName = s.MasterAbbreviation.ClientName + " (" + s.MasterClientSubGroup.ClientSubGroupName + ")-" + s.MasterLocation.LocationName
                }).ToList();
                return ClientName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientDDLViewModel> GetClientBaseOnloginMemberForDDL(short TeamMemberRowID = 0)
        {
            try
            {
                return db.PQClientTeamMembers.Include("PQClientMaster").Include("TeamMember").Where(ct => ct.TeamDepartment.TeamMemberRowID == TeamMemberRowID)
                     .Select(s => new ClientDDLViewModel
                     {
                         ClientRowID = s.ClientRowID,
                         ClientName = s.PQClientMaster.MasterAbbreviation.ClientName + " (" + s.PQClientMaster.MasterClientSubGroup.ClientSubGroupName + ")-" + s.PQClientMaster.MasterLocation.LocationName
                     }).Distinct().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientDesignationsDDLViewModel> GetClientDesignationsDDL()
        {
            try
            {
                return db.MasterDesignations.Where(c => c.Status == 1).Select(c => new ClientDesignationsDDLViewModel { DesignationRowID = c.DesignationRowID, DesignationName = c.DesignationName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PackagesDDLViewModel> GetPackagesForDDL()
        {
            try
            {
                var data = db.PQClientPackages.Include("MasterCheckFamily").Include("MasterSubCheckFamily")
                    .GroupBy(p => new { p.ClientPackageName }).Select(m => m.FirstOrDefault());

                var bindData = data.Select(a =>
                         new PackagesDDLViewModel
                         {
                             PackageNameTxt = a.ClientPackageName,
                             PackageNameVal = a.ClientPackageName,
                         }
                ).ToList();
                return bindData;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<EmploymentDDLViewModel> GetEmploymentDDL()
        {
            try
            {
                return db.MasterEmployers.Where(c => c.Status == 1).Select(c => new EmploymentDDLViewModel { EmploymentRowID = c.EmployerRowID, EmploymentName = c.CompanyName }).ToList().OrderBy(c => c.EmploymentName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CollegeDDLListViewModel> GetCollegeDDL()
        {
            try
            {
                return db.MasterColleges.Where(c => c.Status == 1).Select(c => new CollegeDDLListViewModel { CollegeRowID = c.CollegeRowID, CollegeName = c.CollegeName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CollegeDDLListViewModel> GetCollegeDDLForVerification(int CollegeID)
        {
            try
            {
                return db.MasterColleges.Where(c => c.Status == 1 && c.CollegeRowID == CollegeID).Select(c => new CollegeDDLListViewModel { CollegeRowID = c.CollegeRowID, CollegeName = c.CollegeName }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DegreeDDLListViewModel> GetDegreeDDL()
        {
            try
            {
                return db.MasterDegreeTypes.Where(c => c.Status == 1).Select(c => new DegreeDDLListViewModel { DegreeRowID = c.DegreeRowID, DegreeName = c.DegreeType }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DegreeDDLListViewModel> GetDegreeDDLForVerifier(int DegreeId)
        {
            try
            {
                return db.MasterDegreeTypes.Where(c => c.Status == 1 && c.DegreeRowID == DegreeId).Select(c => new DegreeDDLListViewModel { DegreeRowID = c.DegreeRowID, DegreeName = c.DegreeType }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SeverityGridDDLViewModel> GetColorDDL()
        {
            try
            {
                return db.MasterSeverityGrids.Where(c => c.Status == 1).Select(c => new SeverityGridDDLViewModel { SeverityGridRowId = c.SeverityGridRowId, SeverityGridName = c.SeverityGrid }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DispositionDDLViewModel> DispositionForDDL(short ChFamilRowId = 0, short ClientRowId = 0)
        {
            try
            {
                return db.PQClientDispositions.Where(c => c.Status == 1 && c.CheckFamilyRowID == ChFamilRowId && c.ClientRowID == ClientRowId).Select(c => new DispositionDDLViewModel { DispositionRowId = c.DispositionRowId, Disposition = c.MasterDisposition.Disposition }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<VendorDDLViewModel> GetVendorForDDL(short StateRowId = 0)
        {
            try
            {
                return db.MasterVendorCoverages.Where(c => c.Status == 1 && c.StateRowID == StateRowId).OrderBy(v => new { v.Level1TAT, v.VendorCost }).Select(c => new VendorDDLViewModel { VendorRowID = c.VendorRowID, VendorName = c.MasterVendor.VendorName + " - TAT: " + c.Level1TAT + " days, Cost (Rs.): " + c.VendorCost }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<StateDDLViewModel> GetStatesByVendorDDL(short VendorId = 0)
        {
            try
            {
                return db.MasterVendorCoverages.Where(c => c.Status == 1 && c.VendorRowID == VendorId).Select(c => new StateDDLViewModel
                { StateRowID = c.StateRowID, StateName = c.MasterState.StateName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<VendorUserDDLViewModel> GetVendorByUserDDL(short VendorId = 0)
        {
            try
            {
                return db.MasterVendorLogins.Where(c => c.Status == 1 && c.VendorRowID == VendorId && c.UserType == 1).Select(c => new VendorUserDDLViewModel
                { VendorRowID = c.VendorLoginRowID, VendorName = c.ContactPerson }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<StateDDLViewModel> GetStatesByCountryIdForDDL(short CountryRowID, short teamMemerRowId)
        {
            try
            {
                var data = db.PQAddressStatus.Include("PQAddress").Where(p => p.TMAllocatedTo == teamMemerRowId && p.PTRMgrAllocatedTo == 0).ToList().Select(a => a.PQAddress.AV_State).Distinct();

                return db.MasterStates.Where(s => s.CountryRowID == CountryRowID && data.Contains(s.StateRowID) && s.Status == 1).ToList().Select(item => new StateDDLViewModel { StateRowID = item.StateRowID, StateName = item.StateName });

                //List<StateDDLViewModel> states = new List<StateDDLViewModel>();
                //StateDDLViewModel model = new StateDDLViewModel();
                //foreach (short item in data)
                //{
                //    var state = db.MasterStates.Where(s => s.CountryRowID == CountryRowID && s.StateRowID == item && s.Status == 1).FirstOrDefault();
                //    if (state != null)
                //    {
                //        model.StateRowID = state.StateRowID;
                //        model.StateName = state.StateName;
                //        states.Add(model);
                //    }
                //}
                //return states;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<StateDDLViewModel> GetStatesByArressStatesIdForDDL()
        {
            try
            {
                var StateIds = db.PQAddresss.Where(s => s.AV_State > 0).Select(a => a.AV_State).Distinct().ToList();

                return db.MasterStates.Where(s => StateIds.Contains(s.StateRowID)).Select(s => new StateDDLViewModel { StateRowID = s.StateRowID, StateName = s.StateName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LocationDDLViewModel> GetCityByArressStatesIdForDDL()
        {
            try
            {
                var CityIds = db.PQAddresss.Where(s => s.AV_City > 0).Select(a => a.AV_City).Distinct().ToList();
                return db.MasterLocations.Where(s => CityIds.Contains(s.LocationRowID)).Select(s => new LocationDDLViewModel { LocationRowID = s.LocationRowID, LocationName = s.LocationName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PartnerDDLViewModel> GetPartnerByArressPartnerIdForDDL()
        {
            try
            {
                var Partnerlds = db.PQAddressStatus.Where(s => s.PTRMgrAllocatedTo > 0).Select(a => a.PTRMgrAllocatedTo).Distinct().ToList();
                return db.MasterVendors.Where(s => Partnerlds.Contains(s.VendorRowID)).Select(s => new PartnerDDLViewModel { PartnerRowId = s.VendorRowID, PartnerName = s.VendorName }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public IEnumerable<PincodeDDLViewModel> GetPincodesByLocationIdForDDL(int LocationRowID)
        //{
        //    try
        //    {
        //        return db.MasterPincodes.Where(p => p.LocationRowID == LocationRowID && p.Status == 1).Select(p => new PincodeDDLViewModel { PincodeRowID = p.PincodeRowID, PinCode = p.PinCode }).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #region Common function 

        public IEnumerable<CheckActionHistoryViewModel> GetCheckActionHistory(int PersonalRowID = 0, short subCheckId = 0)
        {
            try
            {
                return db.CheckActionHistories.Where(c => c.Status == 1 && c.PersonalRowID == PersonalRowID && c.SubCheckRowID == subCheckId).Select(c =>
                new CheckActionHistoryViewModel { CheckStatus = c.CheckStatus, Remarks = c.Remarks, UpdatedDate = c.UpdatedDate, UpdatedByNameDesig = c.UpdatedByNameDesig }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CaseActionHistoryViewModel> GetCaseActionHistories(int PersonalRowID = 0)
        {
            try
            {
                return db.CaseActionHistories.Where(c => c.Status == 1 && c.PersonalRowID == PersonalRowID).Select(c =>
                new CaseActionHistoryViewModel { CaseStatus = c.CaseStatus, Remarks = c.Remarks, UpdatedDate = c.UpdatedDate, UpdatedByNameDesig = c.UpdatedByNameDesig }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PQVerifiedUploadDocViewModel> PQAddressVerGetDocumentList(int PersonalRowID = 0, short subCheckId = 0)
        {
            try
            {
                return db.PQVerifiedUploadDocs.Where(c => c.Status == 1 && c.PersonalRowID == PersonalRowID && c.SubCheckRowID == subCheckId).Select(c =>
                new PQVerifiedUploadDocViewModel { DocumentType = c.DocumentType, FileName = c.FileName, Remarks = c.Remarks, UploadDate = c.UploadDate, DocumentUploadFrom = c.DocumentUploadFrom }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PQAntecedentList> GetAntecedentVerList(short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                var listAddress = db.PQClientFields.Where
                    (
                        a => a.ClientRowID == ClientRowId
                        && a.CheckFamilyRowID == ChFamilRowId
                        && a.SubCheckRowID == subCheckId
                    ).OrderBy(a => a.MasterAntecedent.DisplayOrder).Select(c => new PQAntecedentList
                    {
                        AntecedentName = !string.IsNullOrEmpty(c.CADisplayName) ? c.CADisplayName : c.MasterAntecedent.DisplayName,
                        FieldName = c.MasterAntecedent.FieldName,
                        AntecedentRowId = c.AntecedentRowId,
                        AntecedentTypeRowId = c.MasterAntecedent.AntecedentTypeRowId
                    })
                    .ToList().Where(a => a.AntecedentTypeRowId == 2 || a.AntecedentTypeRowId == 3).DefaultIfEmpty();

                return listAddress.OrderByDescending(a => a.AntecedentTypeRowId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PQAntecedentList> GetAntecedentList(short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                var listAddress = db.PQClientFields.Where
                    (
                        a => a.ClientRowID == ClientRowId
                        && a.CheckFamilyRowID == ChFamilRowId
                        && a.SubCheckRowID == subCheckId
                    ).OrderBy(a => a.MasterAntecedent.DisplayOrder).Select(c => new PQAntecedentList
                    {
                        AntecedentName = !string.IsNullOrEmpty(c.CADisplayName) ? c.CADisplayName : c.MasterAntecedent.DisplayName,
                        FieldName = c.MasterAntecedent.FieldName,
                        AntecedentRowId = c.AntecedentRowId,
                        AntecedentTypeRowId = c.MasterAntecedent.AntecedentTypeRowId
                    })
                    .ToList().Where(a => a.AntecedentTypeRowId == 1 || a.AntecedentTypeRowId == 3 || a.AntecedentTypeRowId == 4).DefaultIfEmpty();

                if (listAddress.First() == null)
                {
                    return null;
                }
                return listAddress;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
