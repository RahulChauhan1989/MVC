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
    public class WebUserRepository : IWebUserRepository
    {
        DataContext db;
        public WebUserRepository()
        {
            db = new DataContext();
        }

        public bool IsWebUserExist(string CRPUserName)
        {
            try
            {
                var WebUser = db.WebUsers.Where(c => c.CRPUserName.Trim().ToLower() == CRPUserName.Trim().ToLower()).FirstOrDefault();
                if (WebUser != null)
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

        public void AddWebUser(AddWebUserViewModel model)
        {
            try
            {
                if (model != null)
                {
                    WebUser entity = new WebUser();

                    entity.TeamMemberRoWID = model.TeamMemberRoWID;
                    entity.CRPUserName = model.CRPUserName;
                    entity.CRPPassWord = model.CRPPassWord;
                    entity.CreatedDate = model.CreatedDate;
                    entity.IsExportedExcel = model.IsExportedExcel;
                    entity.IsExportedWord = model.IsExportedWord;
                    entity.IsExportedPDF = model.IsExportedPDF;
                    entity.Status = model.Status;

                    db.WebUsers.Add(entity);
                }
                else
                {
                    throw new Exception("All * fields are mandatory!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<WebUserViewModel> GetWebUsers()
        {
            try
            {
                // return new List<WebUserViewModel>();
                return db.WebUsers.Include("UserType").Include("TeamMember").Select(c => new WebUserViewModel
                {
                    WebUserRowID = c.WebUserRowID,
                    CRPUserName = c.CRPUserName,
                    CRPPassWord = c.CRPPassWord,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate,
                    BlockedDate = c.BlockedDate,
                    UnBlockedBy = c.UnBlockedBy,
                    UnBlockedDate = c.UnBlockedDate,
                    TeamMemberRoWID = c.TeamMemberRoWID,
                    Status = c.Status
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public WebUserListPagedModel GetWebUser(int pageNo, int pageSize, string sort, string sortDir, string Search = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<WebUser> data = db.WebUsers.Include("TeamMember").Where(w => w.Status == 1);

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(w => w.CRPUserName.ToString().Contains(Search.ToString().Trim()));
                }

                switch (sort)
                {
                    case "crpusername":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CRPUserName) : data.OrderByDescending(d => d.CRPUserName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.WebUserRowID) : data.OrderByDescending(d => d.WebUserRowID);
                        break;
                }

                WebUserListPagedModel model = new WebUserListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.WebUsers = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new WebUserViewModel
                {
                    WebUserRowID = item.WebUserRowID,
                    CRPUserName = item.CRPUserName,
                    CRPPassWord = item.CRPPassWord,
                    CreatedDate = item.CreatedDate,
                    TeamMemberRoWID = item.TeamMemberRoWID,
                    TeamMemberName = item.TeamMember.TMFirstName + " " + item.TeamMember.TMLastName,
                    IsExportedExcel = item.IsExportedExcel,
                    IsExportedPDF = item.IsExportedPDF,
                    IsExportedWord = item.IsExportedWord,
                    Status = item.Status
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateWebUserViewModel GetWebUserForUpdateById(short WebUserRowID)
        {
            try
            {
                UpdateWebUserViewModel model = new UpdateWebUserViewModel();
                var entity = db.WebUsers.Find(WebUserRowID);

                if (entity != null)
                {
                    model.WebUserRowID = entity.WebUserRowID;
                    model.CRPUserName = entity.CRPUserName;
                    model.CRPPassWord = entity.CRPPassWord;
                    model.IsExportedExcel = entity.IsExportedExcel;
                    model.IsExportedPDF = entity.IsExportedPDF;
                    model.IsExportedWord = entity.IsExportedWord;
                    model.Status = entity.Status;
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

        public bool IsWebUserExist(short WebUserRowID, string CRPUserName)
        {
            try
            {
                var Webuser = db.WebUsers
                    .Where(c => c.CRPUserName.Trim().ToLower() == CRPUserName.Trim().ToLower() && c.WebUserRowID != WebUserRowID)
                    .FirstOrDefault();
                if (Webuser != null)
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

        public void UpdateWebUser(UpdateWebUserViewModel model)
        {
            try
            {
                if (model != null && model.WebUserRowID > 0)
                {
                    db.WebUsers.Single(w => w.WebUserRowID == model.WebUserRowID).CRPPassWord = model.CRPPassWord;
                    db.WebUsers.Single(w => w.WebUserRowID == model.WebUserRowID).IsExportedExcel = model.IsExportedExcel;
                    db.WebUsers.Single(w => w.WebUserRowID == model.WebUserRowID).IsExportedPDF = model.IsExportedPDF;
                    db.WebUsers.Single(w => w.WebUserRowID == model.WebUserRowID).IsExportedWord = model.IsExportedWord;
                    db.WebUsers.Single(w => w.WebUserRowID == model.WebUserRowID).ModifiedDate = model.ModifiedDate;
                }
                else
                {
                    throw new Exception("WebUser could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActiveWebUser(short id = 0, string checkeds = "")
        {
            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.WebUsers.Single(b => b.WebUserRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Web User could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UnBlockedCUListPagedModel GetUnBlockedCompanyUser(int pageNo, int pageSize, string sort, string sortDir,
            string TMName = "", string UserName = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IQueryable<WebUser> data = db.WebUsers.Include("TeamMember").Where(w => w.Status == 3);
                if (!string.IsNullOrEmpty(TMName) || !string.IsNullOrEmpty(UserName))
                {
                    data = data.Where(b => (b.TeamMember.TMFirstName.Contains(TMName)
                    || b.TeamMember.TMLastName.Contains(TMName)
                    || b.CRPUserName.Contains(UserName)));
                }
                switch (sort)
                {
                    case "crpusername":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CRPUserName) : data.OrderByDescending(d => d.CRPUserName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.WebUserRowID) : data.OrderByDescending(d => d.WebUserRowID);
                        break;
                }

                UnBlockedCUListPagedModel model = new UnBlockedCUListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.UnBlockedCUsers = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new UnBlockedCompanyUserModel
                {
                    WebUserRowID = item.WebUserRowID,
                    CRPUserName = item.CRPUserName,
                    TeamMemberRoWID = item.TeamMemberRoWID,
                    TeamMemberName = item.TeamMember.TMFirstName + " " + item.TeamMember.TMLastName,
                    BlockedDate = item.BlockedDate,
                    EmailID = item.TeamMember.EmailID,
                    Status = item.Status
                }).ToList();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UnBlockedUser(UnBlockedUsersViewModel model)
        {
            try
            {
                if (model.WebUserRowID != 0)
                {
                    db.WebUsers.Single(b => b.WebUserRowID == model.WebUserRowID).UnBlockedBy = model.UnBlockedBy;
                    db.WebUsers.Single(b => b.WebUserRowID == model.WebUserRowID).UnBlockedDate = model.UnBlockedDate;
                    db.WebUsers.Single(b => b.WebUserRowID == model.WebUserRowID).Status = model.Status;
                }
                else
                {
                    throw new Exception("Web User could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<WebUserExportViewModel> GetWebUsersForExport()
        {
            try
            {
                return db.WebUsers.Include("UserType").Include("TeamMember").Select(c => new WebUserExportViewModel
                {
                    WebUserRowID = c.WebUserRowID,
                    CRPUserName = c.CRPUserName,
                    CRPPassWord =  c.CRPPassWord,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate,
                    BlockedDate = c.BlockedDate,
                    UnBlockedBy = c.UnBlockedBy,
                    UnBlockedDate = c.UnBlockedDate,
                    IsExportedExcel= c.IsExportedExcel > 0 ? "Yes" : "No",
                    IsExportedPDF = c.IsExportedPDF > 0 ? "Yes" : "No",
                    IsExportedWord = c.IsExportedWord > 0 ? "Yes" : "No",
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
