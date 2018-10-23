using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.HRViewModels;

namespace BAL.HRRepository
{
    public class TeamDepartmentRepository : ITeamDepartmentRepository
    {
        DataContext db;
        public TeamDepartmentRepository()
        {
            db = new DataContext();
        }
        public void AddTeamDepartment(AddTeamDepartmentViewModel model)
        {
            try
            {
                if (model != null)
                {
                    TeamDepartment entity = new TeamDepartment();
                    entity.DepartmentRowID = model.DepartmentRowID;
                    entity.DesignationRowID = model.DesignationRowID;
                    entity.TeamMemberRowID = model.TeamMemberRowID;
                    entity.Status = model.Status;
                    db.TeamDepartments.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsDepartDesignationExist(byte DepartmentRowID=0, short TeamMemberRowID=0)
        {
            try
            {
                var TeamMember = db.TeamDepartments.Where(c => c.DepartmentRowID == DepartmentRowID && c.TeamMemberRowID==TeamMemberRowID).FirstOrDefault();
                if (TeamMember != null && TeamMember.TeamMemberRowID > 0)
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

        public  IEnumerable<TeamDepartmentViewModel>  GetDepartmentTMembers()
        {
            try
            {
                return db.TeamDepartments.Include("TeamMember").Include("MasterDepartment").Include("MasterDesignation").
                    Select(item => new TeamDepartmentViewModel
                    {
                        TeamDepartmentRowID = item.TeamDepartmentRowID,
                        DepartmentRowID = item.DepartmentRowID,
                        DepartmentName = item.MasterDepartment.DepartmentName,
                        DesignationRowID = item.DesignationRowID,
                        DesignationName = item.MasterDesignation.DesignationName,
                        TeamMemberRowID = item.TeamMemberRowID,
                        TeamMemeberName=item.TeamMember.TMTitle + " " + item.TeamMember.TMFirstName + " " + item.TeamMember.TMLastName+" (" + item.MasterDesignation.DesignationName+")",
                        Status = item.Status,
                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TeamDepartmentListPagedModel GetTeamDepartmentAndDesignation(int pageNo, int pageSize, string sort, string sortDir, string Search = "", short teammemberId = 0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IQueryable<TeamDepartment> data = db.TeamDepartments.Include("TeamMember").Include("MasterDepartment").Include("MasterDesignation").Where(r => r.TeamMemberRowID == teammemberId);

                switch (sort)
                {
                     default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.TeamDepartmentRowID) : data.OrderByDescending(d => d.TeamDepartmentRowID);
                        break;
                }
                TeamDepartmentListPagedModel model = new TeamDepartmentListPagedModel();

                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.TeamDepartmentList = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new TeamDepartmentViewModel
                {
                    TeamDepartmentRowID = item.TeamDepartmentRowID,
                    DepartmentRowID = item.DepartmentRowID,
                    DepartmentName=item.MasterDepartment.DepartmentName,
                    DesignationRowID = item.DesignationRowID,
                    DesignationName=item.MasterDesignation.DesignationName,
                    TeamMemberRowID = item.TeamMemberRowID,
                    Status = item.Status,
                }).ToList();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TeamDepartmentViewModel> GetTeamDepartmentsWithDesignationsById(short TeamMemberRowID)
        {
            try
            {
                return db.TeamDepartments.Where(d => d.TeamMemberRowID == TeamMemberRowID).Select(team => new TeamDepartmentViewModel
                {
                    TeamDepartmentRowID = team.TeamDepartmentRowID,
                    TeamMemberRowID = team.TeamMemberRowID,
                    DepartmentRowID = team.DepartmentRowID,
                    DepartmentName = team.MasterDepartment.DepartmentName,
                    DesignationRowID = team.DesignationRowID,
                    DesignationName = team.MasterDesignation.DesignationName,
                    Status = team.Status
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TeamDepartmentViewModel GetDepartmentWithDesignationById(short TeamDepartmentRowID)
        {
            try
            {
                return db.TeamDepartments.Where(d => d.TeamDepartmentRowID == TeamDepartmentRowID).Select(team => new TeamDepartmentViewModel
                {
                    TeamDepartmentRowID = team.TeamDepartmentRowID,
                    TeamMemberRowID = team.TeamMemberRowID,
                    DepartmentRowID = team.DepartmentRowID,
                    DepartmentName = team.MasterDepartment.DepartmentName,
                    DesignationRowID = team.DesignationRowID,
                    DesignationName = team.MasterDesignation.DesignationName,
                    Status = team.Status
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public short GetTeamMemberRptWriterManager(string DesignationName = "")
        {
            try
            {
                return db.TeamDepartments.Where(a => a.MasterDepartment.DepartmentName == "Report QC" && a.MasterDesignation.DesignationName == DesignationName ).FirstOrDefault().TeamMemberRowID;               
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

        public void DeleteTeamDepartAndDesignationById(short tdid=0)
        {
            try
            {
                var entity = db.TeamDepartments.Find(tdid);
                if (entity != null)
                {
                    db.TeamDepartments.Remove(entity);
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

        public bool MapTeamDepartmentWithAllClients(short tdid = 0)
        {
            try
            {              
                var clientTemDepartment = db.PQClientTeamMembers.Where(t => t.TeamDepartmentRowID == tdid).Select(t => t.ClientRowID).ToList();
                var data = db.PQClientMasters.Select(c => c.ClientRowID).ToList();
                var clientRowIds = data.Except(clientTemDepartment).ToList();

                List<PQClientTeamMember> entities = new List<PQClientTeamMember>();
                foreach (var item in clientRowIds)
                {
                    PQClientTeamMember entity = new PQClientTeamMember();
                    entity.ClientRowID = item;
                    entity.TeamDepartmentRowID =tdid;

                    entities.Add(entity);
                }
                db.PQClientTeamMembers.AddRange(entities);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }        
    }
}
