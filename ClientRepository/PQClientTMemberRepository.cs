using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;

namespace BAL.ClientRepository
{
    public class PQClientTMemberRepository : IPQClientTMemberRepository
    {
        DataContext db;
        public PQClientTMemberRepository()
        {
            db = new DataContext();
        }

        public void AddClientTeamMember(AddPQClientTMemberViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientTeamMember entity = new PQClientTeamMember();
                    entity.ClientRowID = model.ClientRowID;
                    entity.TeamDepartmentRowID = model.TeamDepartmentRowID;

                    db.PQClientTeamMembers.Add(entity);
                }
                else
                {
                    throw new Exception("Repo Client could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PQClientTMemberViewModel> GetDepManagerClientToTeam(short ClientID = 0, string Designation = "")
        {
            try
            {
                return db.PQClientTeamMembers.Include("TeamDepartment").Include("TeamMember").Where(t => t.ClientRowID == ClientID && t.TeamDepartment.MasterDesignation.DesignationName == Designation)
                     .Select(item => new PQClientTMemberViewModel
                     {
                         ClientTMemberRowID = item.ClientTMemberRowID,
                         ClientRowID = item.ClientRowID,
                         TeamMemberRowID = item.TeamDepartment.TeamMember.TeamMemberRowID,
                         TeamMemberName = item.TeamDepartment.TeamMember.TMTitle + " " + item.TeamDepartment.TeamMember.TMFirstName + " " + item.TeamDepartment.TeamMember.TMLastName,
                         TeamMemberEmail = item.TeamDepartment.TeamMember.EmailID,
                         Designation = item.TeamDepartment.MasterDesignation.DesignationName,
                         Status = item.Status,
                     }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PQClientTMemberViewModel> GetRepoClientToTeam(short depMgrID = 0, string Designation = "")
        {
            try
            {
                var ids = db.TeamDepartments.Where(s => s.TeamMemberRowID == depMgrID).Select(s => s.TeamDepartmentRowID);

                return db.TeamMemberReportings.Include("TeamDepartment").Where(t => ids.Contains(t.ReportingTo) && t.TeamDepartment.MasterDesignation.DesignationName == Designation)
                   .Select(item => new PQClientTMemberViewModel
                   {
                       TeamMemberRowID = item.TeamDepartment.TeamMember.TeamMemberRowID,
                       TeamMemberName = item.TeamDepartment.TeamMember.TMTitle + " " + item.TeamDepartment.TeamMember.TMFirstName + " " + item.TeamDepartment.TeamMember.TMLastName,
                       Designation = item.TeamDepartment.MasterDesignation.DesignationName,
                   }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PQClientTMemberViewModel> GetTeamMemberDEByTLDE(short DETLID = 0, string Designation = "")
        {
            try
            {
                var ids = db.TeamDepartments.Where(s => s.TeamMemberRowID == DETLID).Select(s => s.TeamDepartmentRowID);

                return db.TeamMemberReportings.Include("TeamDepartment").Where(t => ids.Contains(t.ReportingTo) && t.TeamDepartment.MasterDesignation.DesignationName == Designation)
                   .Select(item => new PQClientTMemberViewModel
                   {
                       TeamMemberRowID = item.TeamDepartment.TeamMember.TeamMemberRowID,
                       TeamMemberName = item.TeamDepartment.TeamMember.TMTitle + " " + item.TeamDepartment.TeamMember.TMFirstName + " " + item.TeamDepartment.TeamMember.TMLastName,
                       Designation = item.TeamDepartment.MasterDesignation.DesignationName,
                   }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PQClientTMemberListPagedModel GetClientTeamMembers(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short CId = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientTeamMember> data = db.PQClientTeamMembers.Include("TeamDepartment").Where(pt => pt.ClientRowID == CId);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.TeamDepartment.TeamMember.TMFirstName.ToString().Contains(Search)
                    || b.TeamDepartment.TeamMember.TMLastName.ToString().Contains(Search)
                    || b.TeamDepartment.MasterDesignation.DesignationName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    //case "TeamMemberName":
                    //    data = sortDir == "asc" ? data.OrderBy(d => d.TeamMember.TMFirstName) : data.OrderByDescending(d => d.TeamMember.TMFirstName);
                    //    break;
                    //case "Designation":
                    //    data = sortDir == "asc" ? data.OrderBy(d => d.TeamMember.MasterDesignation.DesignationName) : data.OrderByDescending(d => d.TeamMember.MasterDesignation.DesignationName);
                    //    break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.TeamDepartmentRowID) : data.OrderByDescending(d => d.TeamDepartmentRowID);
                        break;
                }

                PQClientTMemberListPagedModel model = new PQClientTMemberListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientTMembers = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new PQClientTMemberViewModel
                {
                    ClientTMemberRowID = item.ClientTMemberRowID,
                    ClientRowID = item.ClientRowID,
                    TeamMemberRowID = item.TeamDepartment.TeamMember.TeamMemberRowID,
                    TeamMemberName = item.TeamDepartment.TeamMember.TMTitle + " " + item.TeamDepartment.TeamMember.TMFirstName + " " + item.TeamDepartment.TeamMember.TMLastName + " (" + item.TeamDepartment.MasterDesignation.DesignationName + ")",
                    Department = item.TeamDepartment.MasterDepartment.DepartmentName,
                    Designation = item.TeamDepartment.MasterDesignation.DesignationName,
                    Status = item.Status,
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsClientTeamMemberExist(short tmdid = 0, short CId = 0)
        {
            try
            {
                var data = db.PQClientTeamMembers.Where(p => p.ClientRowID == CId && p.TeamDepartmentRowID == tmdid).FirstOrDefault();
                if (data != null)
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

        public bool IsClientDETeamMembersExist(short CId = 0, short SCtmid = 0, short DEtmid = 0, short QCtmid = 0)
        {
            try
            {
                var data = db.PQClientTeamMembers.Include("TeamDepartment").Where(p => p.ClientRowID == CId
                && ((p.TeamDepartment.TeamMemberRowID == SCtmid && p.TeamDepartment.MasterDepartment.DepartmentName == "Data Entry" && p.TeamDepartment.MasterDesignation.DesignationName == "Team Member-DE-Scan")
                || (p.TeamDepartment.TeamMemberRowID == DEtmid && p.TeamDepartment.MasterDepartment.DepartmentName == "Data Entry" && p.TeamDepartment.MasterDesignation.DesignationName == "Team Member-DE")
                || (p.TeamDepartment.TeamMemberRowID == QCtmid && p.TeamDepartment.MasterDepartment.DepartmentName == "Data Entry" && p.TeamDepartment.MasterDesignation.DesignationName == "Team Member-DE-QC"))).Select(p => p.TeamDepartment.TeamMemberRowID);

                if (data != null && data.Count() == 3)
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

        public bool IsClientDETeamMembersExistForReAllocation(short CId = 0, short SCtmid = 0, short DEtmid = 0, short QCtmid = 0)
        {
            try
            {
                var data = db.PQClientTeamMembers.Include("TeamDepartment").Where(p => p.ClientRowID == CId
                && ((p.TeamDepartment.TeamMemberRowID == SCtmid && p.TeamDepartment.MasterDepartment.DepartmentName == "Data Entry" && p.TeamDepartment.MasterDesignation.DesignationName == "Team Member-DE-Scan")
                || (p.TeamDepartment.TeamMemberRowID == DEtmid && p.TeamDepartment.MasterDepartment.DepartmentName == "Data Entry" && p.TeamDepartment.MasterDesignation.DesignationName == "Team Member-DE")
                || (p.TeamDepartment.TeamMemberRowID == QCtmid && p.TeamDepartment.MasterDepartment.DepartmentName == "Data Entry" && p.TeamDepartment.MasterDesignation.DesignationName == "Team Member-DE-QC"))).Select(p => p.TeamDepartment.TeamMemberRowID);

                if (data != null && data.Count() > 0)
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

        public bool IsClientDepartTeamMembersExist(short CId = 0, short tmid = 0, string DepartmentName = "", string DesignationName = "")
        {
            try
            {
                var data = db.PQClientTeamMembers.Include("TeamDepartment").Where(p => p.ClientRowID == CId
                && (p.TeamDepartment.TeamMemberRowID == tmid && p.TeamDepartment.MasterDepartment.DepartmentName == DepartmentName
                && p.TeamDepartment.MasterDesignation.DesignationName == DesignationName)).Select(p => p.TeamDepartment.TeamMemberRowID);

                if (data != null && data.Count() > 0)
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

        public short GetClientTeamPVManager(short CId = 0, string DepartmentName = "", string DesignationName = "")
        {
            try
            {
                var data = db.PQClientTeamMembers.Include("TeamDepartment").Where(p => p.ClientRowID == CId
                && p.TeamDepartment.MasterDesignation.DesignationName == DesignationName).FirstOrDefault();

                if (data != null && data.TeamDepartment.TeamMemberRowID > 0)
                {
                    return data.TeamDepartment.TeamMemberRowID;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsClientDepartTeamMembersExistForReAllocation(short CId = 0, short tmid = 0, short tmQCid = 0, string DepartmentName = "", string TMDesiName = "", string QCDesiName = "")
        {
            try
            {
                bool flag = false;
                var data = db.PQClientTeamMembers.Include("TeamDepartment").Where(p => p.ClientRowID == CId && p.TeamDepartment.MasterDepartment.DepartmentName == DepartmentName);

                if (tmid > 0 && tmQCid > 0)
                {
                    data = data.Where(p => p.TeamDepartment.TeamMemberRowID == tmid                    
                    && p.TeamDepartment.MasterDesignation.DesignationName == TMDesiName 
                    ||p.TeamDepartment.TeamMemberRowID == tmQCid 
                    && p.TeamDepartment.MasterDesignation.DesignationName == QCDesiName);

                    if (data != null && data.Distinct().Count() == 2)
                    {
                        flag= true;
                    }
                }
                else if (tmid > 0 && tmQCid == 0)
                {
                    data = data.Where(p => p.TeamDepartment.TeamMemberRowID == tmid
                    && p.TeamDepartment.MasterDesignation.DesignationName == TMDesiName);

                    if (data != null && data.Distinct().Count() >0)
                    {
                        flag = true;
                    }
                }
                else if (tmid == 0 && tmQCid > 0)
                {
                    data = data.Where(p => p.TeamDepartment.TeamMemberRowID == tmQCid
                    && p.TeamDepartment.MasterDesignation.DesignationName == QCDesiName);

                    if (data != null && data.Distinct().Count() >0)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    return flag;
                }
                else
                {
                    return flag;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsClientDepartTeamMembersExist(short CId = 0, short tmid = 0, short tmQCid = 0, string DepartmentName = "", string TMDesiName = "", string QCDesiName = "")
        {
            try
            {
                var data = db.PQClientTeamMembers.Include("TeamDepartment").Where(p => p.ClientRowID == CId
                && (p.TeamDepartment.TeamMemberRowID == tmid && p.TeamDepartment.MasterDepartment.DepartmentName == DepartmentName
                && p.TeamDepartment.MasterDesignation.DesignationName == TMDesiName)
                || (p.TeamDepartment.TeamMemberRowID == tmQCid && p.TeamDepartment.MasterDepartment.DepartmentName == DepartmentName
                && p.TeamDepartment.MasterDesignation.DesignationName == QCDesiName)).Select(p => p.TeamDepartment.TeamMemberRowID);

                if (data != null && data.Distinct().Count() == 2)
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

        public void DeleteClientTeamMember(short id = 0)
        {
            try
            {
                var entity = db.PQClientTeamMembers.Find(id);
                if (entity != null)
                {
                    db.PQClientTeamMembers.Remove(entity);
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
    }
}
