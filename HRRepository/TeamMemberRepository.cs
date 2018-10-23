using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.HRViewModels;

namespace BAL.HRRepository
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        DataContext db;
        public TeamMemberRepository()
        {
            db = new DataContext();
        }

        public void AddTeamMember(AddTeamMemberViewModel model)
        {
            try
            {
                if (model != null)
                {
                    TeamMember entity = new TeamMember();
                    entity.TeamMemberRowID = model.TeamMemberRowID;
                    entity.TMTitle = model.TMTitle;
                    entity.TMFirstName = model.TMFirstName;
                    entity.TMLastName = model.TMLastName;
                    entity.FTitle = model.FTitle;
                    entity.FFirstName = model.FFirstName;
                    entity.FLastName = model.FLastName;
                    entity.SpouseFirstName = model.SpouseFirstName;
                    entity.SpouseLastName = model.SpouseLastName;
                    entity.DOB = model.DOB;
                    entity.DOJ = model.DOJ;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.LocationRowID = model.LocationRowID;
                    entity.PinCode = model.PinCode;
                    entity.EmployeeID = model.EmployeeID;
                    entity.CategoryRowID = model.CategoryRowID;
                    entity.PresentAddress = model.PresentAddress;
                    entity.PermanentAddress = model.PermanentAddress;
                    entity.STD = model.STD;
                    entity.ResidancePhoneNo = model.ResidancePhoneNo;
                    entity.MobileNo = model.MobileNo;
                    entity.EmailID = model.EmailID;
                    entity.DirectTelNo = model.DirectTelNo;
                    entity.ProcessStatus = model.ProcessStatus;
                    entity.UserType = model.UserType;
                    entity.BORowID = model.BORowID;
                    db.TeamMembers.Add(entity);
                }
                else
                {
                    throw new Exception("Team Member could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteTeamMember(short CRowID)
        {
            try
            {
                var entity = db.TeamMembers.Find(CRowID);
                if (entity != null)
                {
                    db.TeamMembers.Remove(entity);
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetTeamMemberNameById(short TeamMemberRowID = 0)
        {
            try
            {
                if (TeamMemberRowID > 0)
                {
                    return db.TeamMembers.Where(b => b.TeamMemberRowID == TeamMemberRowID).Select(b => (b.TMTitle + " " + b.TMFirstName + " " + b.TMLastName)).FirstOrDefault();
                }
                else
                {
                    throw new Exception("Invalid Member Id!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TeamMemberViewModel> GetTeamMembers()
        {
            try
            {

                return db.TeamMembers.Include("MasterDesignation").Select(item => new TeamMemberViewModel
                {
                    TeamMemberRowID = item.TeamMemberRowID,
                    TeamMemberName = item.TMTitle + " " + item.TMFirstName + " " + item.TMLastName,
                    TMTitle = item.TMTitle,
                    TMFirstName = item.TMFirstName,
                    TMLastName = item.TMLastName,
                    FTitle = item.FTitle,
                    FFirstName = item.FFirstName,
                    FLastName = item.FLastName,
                    SpouseFirstName = item.SpouseFirstName,
                    SpouseLastName = item.SpouseLastName,
                    DOB = item.DOB,
                    DOJ = item.DOJ,
                    CountryRowID = item.CountryRowID,
                    StateRowID = item.StateRowID,
                    DistrictRowID = item.DistrictRowID,
                    LocationRowID = item.LocationRowID,
                    PinCode = item.PinCode,
                    EmployeeID = item.EmployeeID,
                    CategoryRowID = item.CategoryRowID,
                    PresentAddress = item.PresentAddress,
                    PermanentAddress = item.PermanentAddress,
                    STD = item.STD,
                    ResidancePhoneNo = item.ResidancePhoneNo,
                    MobileNo = item.MobileNo,
                    EmailID = item.EmailID,
                    DirectTelNo = item.DirectTelNo,
                    ProcessStatus = item.ProcessStatus,
                    UserType = item.UserType,
                    Status = item.Status,
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TeamMemberListPagedModel GetTeamMember(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<TeamMember> data = db.TeamMembers;

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.EmployeeID.ToString().Contains(Search.ToString().Trim()) ||
                    (b.TMTitle + b.TMFirstName + b.TMLastName).ToString().Contains(Search.ToString().Trim()) ||
                    b.MobileNo.ToString().Contains(Search.ToString().Trim()) || b.EmailID.ToString().Contains(Search.ToString().Trim()));
                }
                switch (sort)
                {
                    case "tmfirstname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.TMFirstName) : data.OrderByDescending(d => d.TMFirstName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.EmployeeID) : data.OrderByDescending(d => d.EmployeeID);
                        break;
                }

                TeamMemberListPagedModel model = new TeamMemberListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.TeamMembers = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new TeamMemberViewModel
                {
                    TeamMemberRowID = item.TeamMemberRowID,
                    LocationRowID = item.LocationRowID,
                    CategoryRowID = item.CategoryRowID,
                    TMTitle = item.TMTitle,
                    TMFirstName = item.TMFirstName,
                    TMLastName = item.TMLastName,
                    FTitle = item.FTitle,
                    FFirstName = item.FFirstName,
                    FLastName = item.FLastName,
                    FullName = item.TMTitle + " " + item.FLastName + " " + item.FLastName,
                    FatherFullName = item.FTitle + " " + item.SpouseFirstName + " " + item.FLastName,
                    SpouseName = item.SpouseFirstName,
                    SpouseLastName = item.SpouseFirstName,
                    EmployeeID = item.EmployeeID,
                    DOB = item.DOB,
                    DOJ = item.DOJ,
                    PresentAddress = item.PresentAddress,
                    PermanentAddress = item.PermanentAddress,
                    STD = item.STD,
                    ResidancePhoneNo = item.ResidancePhoneNo,
                    MobileNo = item.MobileNo,
                    EmailID = item.EmailID,
                    DirectTelNo = item.DirectTelNo,
                    ProcessStatus = item.ProcessStatus,
                    UserType = item.UserType,
                    Status = item.Status,
                    BranchName = item.MasterCompanyBranch.BOName
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TeamMemberExportViewModel> GetTeamMembersForExport()
        {
            try
            {
                return db.TeamMembers.Include("MasterDesignation").Select(item => new TeamMemberExportViewModel
                {
                    TeamMemberRowID = item.TeamMemberRowID,
                    TeamMemberName = item.TMTitle + " " + item.TMFirstName + " " + item.TMLastName,
                    SpouseFirstName = item.SpouseFirstName,
                    SpouseLastName = item.SpouseLastName,
                    DOB = item.DOB,
                    DOJ = item.DOJ,
                    CountryName = item.CountryRowID,
                    StateName = item.StateRowID,
                    DistrictName = item.DistrictRowID,
                    LocationName = item.LocationRowID,
                    PinCode = item.PinCode,
                    EmployeeID = item.EmployeeID,
                    BranchName = item.MasterCompanyBranch.BOName,
                    CategoryName = item.CategoryRowID,
                    PresentAddress = item.PresentAddress,
                    PermanentAddress = item.PermanentAddress,
                    STD = item.STD,
                    ResidancePhoneNo = item.ResidancePhoneNo,
                    MobileNo = item.MobileNo,
                    EmailID = item.EmailID,
                    DirectTelNo = item.DirectTelNo,
                    ProcessStatus = item.ProcessStatus,
                    UserType = item.UserType,
                    Status = item.Status,
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateTeamMemberViewModel GetTeamMemberForUpdateById(short TeamMemberRowID)
        {
            try
            {
                UpdateTeamMemberViewModel model = new UpdateTeamMemberViewModel();
                var entity = db.TeamMembers.Find(TeamMemberRowID);

                if (entity != null)
                {
                    model.TeamMemberRowID = entity.TeamMemberRowID;
                    model.TMTitle = entity.TMTitle;
                    model.TMFirstName = entity.TMFirstName;
                    model.TMLastName = entity.TMLastName;
                    model.FTitle = entity.FTitle;
                    model.FFirstName = entity.FFirstName;
                    model.FLastName = entity.FLastName;
                    model.SpouseFirstName = entity.SpouseFirstName;
                    model.SpouseLastName = entity.SpouseLastName;
                    model.DOB = entity.DOB;
                    model.DOJ = entity.DOJ;
                    model.CountryRowID = entity.CountryRowID;
                    model.StateRowID = entity.StateRowID;
                    model.DistrictRowID = entity.DistrictRowID;
                    model.LocationRowID = entity.LocationRowID;
                    model.PinCode = entity.PinCode;
                    model.EmployeeID = entity.EmployeeID;
                    model.CategoryRowID = entity.CategoryRowID;
                    model.PresentAddress = entity.PresentAddress;
                    model.PermanentAddress = entity.PermanentAddress;
                    model.STD = entity.STD;
                    model.ResidancePhoneNo = entity.ResidancePhoneNo;
                    model.MobileNo = entity.MobileNo;
                    model.EmailID = entity.EmailID;
                    model.DirectTelNo = entity.DirectTelNo;
                    model.ProcessStatus = entity.ProcessStatus;
                    model.UserType = entity.UserType;
                    model.Status = entity.Status;
                    model.BORowID = entity.BORowID;
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTeamMemberExist(int TeamMemberRowID, string EmployeeID)
        {
            try
            {
                var TeamMember = db.TeamMembers.Where(c =>c.EmployeeID.Trim().ToLower() == EmployeeID.Trim().ToLower()
                && c.TeamMemberRowID != TeamMemberRowID).FirstOrDefault();

                if (TeamMember != null && TeamMember.EmployeeID.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsTeamMemberExist(string EmployeeID)
        {
            try
            {
                var TeamMember = db.TeamMembers
                    .Where(c => c.EmployeeID.Trim().ToLower() == EmployeeID.Trim().ToLower()).FirstOrDefault();
                if (TeamMember != null && TeamMember.EmployeeID.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public void UpdateTeamMember(UpdateTeamMemberViewModel model)
        {
            try
            {
                if (model != null && model.TeamMemberRowID > 0)
                {
                    TeamMember entity = new TeamMember();
                    entity.TeamMemberRowID = model.TeamMemberRowID;
                    entity.TMTitle = model.TMTitle;
                    entity.TMFirstName = model.TMFirstName;
                    entity.TMLastName = model.TMLastName;
                    entity.FTitle = model.FTitle;
                    entity.FFirstName = model.FFirstName;
                    entity.FLastName = model.FLastName;
                    entity.SpouseFirstName = model.SpouseFirstName;
                    entity.SpouseLastName = model.SpouseLastName;
                    entity.DOB = model.DOB;
                    entity.DOJ = model.DOJ;
                    entity.CountryRowID = model.CountryRowID;
                    entity.StateRowID = model.StateRowID;
                    entity.DistrictRowID = model.DistrictRowID;
                    entity.LocationRowID = model.LocationRowID;
                    entity.PinCode = model.PinCode;
                    entity.EmployeeID = model.EmployeeID;
                    entity.CategoryRowID = model.CategoryRowID;
                    entity.PresentAddress = model.PresentAddress;
                    entity.PermanentAddress = model.PermanentAddress;
                    entity.STD = model.STD;
                    entity.ResidancePhoneNo = model.ResidancePhoneNo;
                    entity.MobileNo = model.MobileNo;
                    entity.EmailID = model.EmailID;
                    entity.DirectTelNo = model.DirectTelNo;
                    entity.ProcessStatus = model.ProcessStatus;
                    entity.UserType = model.UserType;
                    entity.Status = model.Status;
                    entity.BORowID = model.BORowID;
                    db.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("TeamMember could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region Reporting To TeamMember 

        public RepoToTeamMemberListPagedModel GetReportedTeamMembers(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short TeamDepartmentRowID = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                var ReportingTo = db.TeamMemberReportings.Where(r => r.TeamDepartmentRowID == TeamDepartmentRowID).Select(r => r.ReportingTo).ToList();

                RepoToTeamMemberListPagedModel model = new RepoToTeamMemberListPagedModel();
                var data = db.TeamDepartments.Where(t => ReportingTo.Contains(t.TeamDepartmentRowID)).Select(t => new RepoToTeamMemberViewModel
                {
                    TeamMemberName = t.TeamMember.TMTitle + " " + t.TeamMember.TMFirstName + " " + t.TeamMember.TMLastName + " (" + t.MasterDesignation.DesignationName + ")",
                    ReportTeamRowID = db.TeamMemberReportings.Where(r=>r.TeamDepartmentRowID== TeamDepartmentRowID && r.ReportingTo==t.TeamDepartmentRowID).FirstOrDefault().ReportTeamRowID,
                    
                });
               
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.RepoToTeamMembers = data;
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddRepoToTeamMember(AddRepoToTeamMemberViewModel model)
        {
            try
            {
                //int res = 0;
                if (model != null)
                {
                    foreach (var data in model.RepoToIds)
                    {
                        if (!IsRepoToMemberExist(data, model.TeamDepartmentRowID))
                        {
                            TeamMemberReporting entity = new TeamMemberReporting();
                            entity.TeamDepartmentRowID = model.TeamDepartmentRowID;
                            entity.ReportingTo = data;
                            db.TeamMemberReportings.Add(entity);
                        }
                    }
                }
                else
                {
                    throw new Exception("TeamMember could not be blank!");
                }
                //return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsRepoToMemberExist(short ReportingTo, short TeamMemberRowID)
        {
            try
            {
                var TeamMember = db.TeamMemberReportings.Where(c => c.ReportingTo == ReportingTo && c.TeamDepartmentRowID == TeamMemberRowID).FirstOrDefault();
                if (TeamMember != null && TeamMember.ReportingTo > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteReportingTeamMember(short RepoRowID)
        {
            try
            {
                var entity = db.TeamMemberReportings.Find(RepoRowID);
                if (entity != null)
                {
                    db.TeamMemberReportings.Remove(entity);
                }
                else
                {
                    throw new Exception("Invalid Id!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
