using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ClientViewModel;
using ViewModels.HRViewModels;
using ViewModels.PartnerViewModels;

namespace BAL.ClientRepository
{
    public class ClientLoginRepository : IClientLoginRepository
    {
        DataContext db;

        public ClientLoginRepository()
        {
            db = new DataContext();
        }

        public void AddClientLogin(AddPQClientLoginViewModel model)
        {
            try
            {
                if (model != null)
                {
                    PQClientLogin entity = new PQClientLogin();
                    entity.ClientRowID = model.ClientRowID;
                    entity.ClientBranch = model.ClientBranch;
                    entity.UserID = model.UserID;
                    entity.UPass = model.UPass;
                    entity.CreatedBy = model.CreatedBy;
                    entity.CreatedTime = model.CreatedTime;
                    entity.UType = model.UType;
                    entity.CreatedUserId = model.CreatedUserId;
                    entity.Status = model.Status;
                    db.PQClientLogins.Add(entity);
                }
                else
                {
                    throw new Exception("Client Login could not be blank!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteClientLoginSubGroups(short ClientLoginID)
        {
            try
            {
                var entity = db.PQClientLogins.Find(ClientLoginID);
                if (entity != null)
                {
                    db.PQClientLogins.Remove(entity);
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

        public UpdatePQClientLoginViewModel GetClientLoginForUpdateById(short ClientLoginID)
        {
            try
            {
                UpdatePQClientLoginViewModel model = new UpdatePQClientLoginViewModel();
                var entity = db.PQClientLogins.Find(ClientLoginID);
                if (entity != null)
                {
                    model.ClientUserRowID = entity.ClientUserRowID;
                    model.ClientRowID = entity.ClientRowID;
                    model.UserID = entity.UserID;
                    model.UPass = entity.UPass;
                    model.CreatedBy = entity.CreatedBy;
                    model.ModifiedTime = entity.ModifiedTime;
                    model.CreatedUserId = entity.CreatedUserId;
                    model.Remarks = entity.Remarks;
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

        public PQClientUserListPagedModel GetClientUsers(int pageNo, int pageSize, string sort, string sortDir, string Search = "",short ClientRowID=0)
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }

                IQueryable<PQClientLogin> data = db.PQClientLogins;
                if (ClientRowID>0)
                {
                    data = data.Where(c => c.ClientRowID == ClientRowID);
                }

                if (!string.IsNullOrEmpty(Search))
                {
                    data = data.Where(b => b.PQClientMaster.MasterAbbreviation.ClientName.ToString().Contains(Search));
                }

                switch (sort)
                {
                    case "clientname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.PQClientMaster.MasterAbbreviation.ClientName) : data.OrderByDescending(d => d.PQClientMaster.MasterAbbreviation.ClientName);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.ModifiedTime) : data.OrderByDescending(d => d.ModifiedTime);
                        break;
                }

                PQClientUserListPagedModel model = new PQClientUserListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientUsers = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new PQClientLoginViewModel
                {
                    ClientUserRowID = item.ClientUserRowID,
                    ClientRowID = item.ClientRowID,
                    ClientName = item.PQClientMaster.MasterAbbreviation.ClientName,
                    ClientBranch = item.ClientBranch,
                    CreatedTime = item.CreatedTime,
                    ModifiedTime = item.ModifiedTime,
                    UserID = item.UserID,
                    CreatedBy = item.CreatedBy,
                    SentMailStatus = item.SentMailStatus,
                    SentMailDate = item.SentMailDate,
                    Status = item.Status,

                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
  
        public bool IsClientLoginExist(string UserId)
        {
            try
            {
                var ClientUserID = db.PQClientLogins.Where(c => c.UserID.Trim().ToLower() == UserId.Trim().ToLower()).FirstOrDefault();
                if (ClientUserID != null && ClientUserID.UserID.Length > 0)
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

        public bool IsClientLoginExist(string UserId, int ClientUserid)
        {
            var ClientUserID = db.PQClientLogins.Where(c => c.UserID.Trim().ToLower() == UserId.Trim().ToLower()
            && c.ClientUserRowID != ClientUserid).FirstOrDefault();
            if (ClientUserID != null && ClientUserID.UserID.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
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

        public void UpdateClientLogin(UpdatePQClientLoginViewModel model)
        {
            try
            {
                if (model != null && model.ClientUserRowID > 0)
                {
                    db.PQClientLogins.Single(c => c.ClientUserRowID == model.ClientUserRowID).ClientUserRowID = model.ClientUserRowID;
                    db.PQClientLogins.Single(c => c.ClientUserRowID == model.ClientUserRowID).ClientRowID = model.ClientRowID;
                    db.PQClientLogins.Single(c => c.ClientUserRowID == model.ClientUserRowID).UserID = model.UserID;
                    db.PQClientLogins.Single(c => c.ClientUserRowID == model.ClientUserRowID).UPass = model.UPass;
                    db.PQClientLogins.Single(c => c.ClientUserRowID == model.ClientUserRowID).ModifiedTime = model.ModifiedTime;
                    db.PQClientLogins.Single(c => c.ClientUserRowID == model.ClientUserRowID).CreatedUserId = model.CreatedUserId;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateClientSendMailStatus(UpdateClientSendMailStatusViewModel model)
        {
            try
            {
                if (model != null)
                {
                    db.PQClientLogins.Single(c => c.ClientUserRowID == model.ClientUserRowID).SentMailStatus = model.SentMailStatus;
                    db.PQClientLogins.Single(c => c.ClientUserRowID == model.ClientUserRowID).SentMailDate = model.SentMailDate;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SendClientLoginInfoViewModel GetClientLoginInfoforSendMail(int ClientUserRowID)
        {
            try
            {
                return db.PQClientLogins.Where(c => c.ClientUserRowID == ClientUserRowID && c.Status == 1).Select(client => new SendClientLoginInfoViewModel
                {
                    ClientSpocName = client.PQClientMaster.CSpocName,
                    ClientSpocEmail = client.PQClientMaster.CSpocEmailID,
                    UserID = client.UserID,
                    UPass = client.UPass
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetAllClientUserByClId(short ClientRowID = 0)
        {
            try
            {
                var data = (from p in db.PQClientLogins
                            where p.ClientRowID == ClientRowID
                            select p
                            ).ToList();
                return data.Count();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActiveClientLogin(short id = 0, string checkeds = "")
        {

            try
            {
                if (id != 0 && checkeds != null)
                {
                    db.PQClientLogins.Single(b => b.ClientUserRowID == id).Status = Convert.ToByte(checkeds);
                }
                else
                {
                    throw new Exception("Client User could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public PQClientUserListPagedModel GetBlockedClientUser(int pageNo, int pageSize, string sort, string sortDir, string ClientName = "", string UserName = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IQueryable<PQClientLogin> data = db.PQClientLogins.Where(w => w.Status == 3);
                if (!string.IsNullOrEmpty(ClientName) || !string.IsNullOrEmpty(UserName))
                {
                    data = data.Where(b => (b.UserID.Contains(UserName)
                    //|| b.PQClientMaster.MasterAbbreviation.ClientName.Contains(UserName)
                    ));
                }                
                switch (sort)
                {
                    case "clientname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.PQClientMaster.MasterAbbreviation.ClientName) : data.OrderByDescending(d => d.PQClientMaster.MasterAbbreviation.ClientName);
                        break;
                    case "createdtime":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CreatedTime) : data.OrderByDescending(d => d.CreatedTime);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.ModifiedTime) : data.OrderByDescending(d => d.ModifiedTime);
                        break;
                }
                PQClientUserListPagedModel model = new PQClientUserListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.ClientUsers = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new PQClientLoginViewModel
                {
                    ClientUserRowID = item.ClientUserRowID,
                    ClientRowID = item.ClientRowID,
                    ClientName = item.PQClientMaster.MasterAbbreviation.ClientName,
                    CreatedTime = item.CreatedTime,
                    ModifiedTime = item.ModifiedTime,
                    UserID = item.UserID,
                    CreatedBy = item.CreatedBy,
                    SentMailStatus = item.SentMailStatus,
                    SentMailDate = item.SentMailDate,
                    Status = item.Status,

                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VendorUserLoggedListPagedModel GetBlockeddPartnerUsers(int pageNo, int pageSize, string sort, string sortDir, string PartnerName = "", string UserName = "")
        {
            try
            {
                if (pageNo < 0)
                {
                    pageNo = 1;
                }
                IQueryable<MasterVendorLogin> data = db.MasterVendorLogins.Where(w => w.Status == 3);
                if (!string.IsNullOrEmpty(PartnerName) || !string.IsNullOrEmpty(UserName))
                {
                    data = data.Where(b => (b.UserID.Contains(UserName)
                    //|| b.PQClientMaster.MasterAbbreviation.ClientName.Contains(UserName)
                    ));
                }
                switch (sort)
                {
                    case "clientname":
                        data = sortDir == "asc" ? data.OrderBy(d => d.MasterVendor.VendorName) : data.OrderByDescending(d => d.MasterVendor.VendorName);
                        break;
                    case "createdtime":
                        data = sortDir == "asc" ? data.OrderBy(d => d.CreatedTime) : data.OrderByDescending(d => d.CreatedTime);
                        break;
                    default:
                        data = sortDir == "asc" ? data.OrderBy(d => d.ModifiedTime) : data.OrderByDescending(d => d.ModifiedTime);
                        break;
                }
                VendorUserLoggedListPagedModel model = new VendorUserLoggedListPagedModel();
                model.PageSize = pageSize;
                model.TotalRecords = data.Count();
                model.VendorUser = data.Skip((pageNo - 1) * pageSize).Take(pageSize).Select(item => new VendorUserLoggedViewModel
                {
                    VendorLoginRowID = item.VendorLoginRowID,
                    VendorRowID = item.VendorRowID,
                    VendorName = item.MasterVendor.VendorName,
                    CreatedTime = item.CreatedTime,
                    ModifiedTime = item.ModifiedTime,
                    UserID = item.UserID,
                    CreatedBy = item.CreatedBy,
                    Status = item.Status,

                }).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void UnBlockedClientUser(UnBlockedClientUsersViewModel model)
        {
            try
            {
                if (model.ClientUserRowID != 0)
                {
                    db.PQClientLogins.Single(b => b.ClientUserRowID == model.ClientUserRowID).UnBlockedBy = model.UnBlockedBy;
                    db.PQClientLogins.Single(b => b.ClientUserRowID == model.ClientUserRowID).UnBlockedDate = model.UnBlockedDate;
                    db.PQClientLogins.Single(b => b.ClientUserRowID == model.ClientUserRowID).Status = model.Status;
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

        public void UnBlockedPartnerUsers(UnBlockedPartnerUsersViewModel model)
        {
            try
            {
                if (model.PartnerUsersRowID != 0)
                {
                    db.MasterVendorLogins.Single(b => b.VendorLoginRowID == model.PartnerUsersRowID).UnBlockedBy = model.UnBlockedBy;
                    db.MasterVendorLogins.Single(b => b.VendorLoginRowID == model.PartnerUsersRowID).UnBlockedDate = model.UnBlockedDate;
                    db.MasterVendorLogins.Single(b => b.VendorLoginRowID == model.PartnerUsersRowID).ModifiedTime = model.UnBlockedDate;
                    db.MasterVendorLogins.Single(b => b.VendorLoginRowID == model.PartnerUsersRowID).Status = model.Status;
                }
                else
                {
                    throw new Exception("Partner User could not be blank!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
