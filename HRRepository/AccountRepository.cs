using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.HRViewModels;
using ViewModels.ClientViewModel;
using ViewModels.CandidateViewModel;
using ViewModels.PartnerViewModels;

namespace BAL.HRRepository
{
    public class AccountRepository : IAccountRepository
    {
        DataContext db;
        public AccountRepository()
        {
            db = new DataContext();
        }

        public CompanyUserLoggedViewModel GetCompanyUserLoggedDetails(string UserName, string EcryptedPassword)
        {
            try
            {
                CompanyUserLoggedViewModel LoggedUser = new CompanyUserLoggedViewModel();

                LoggedUser = db.WebUsers.Where(w => w.CRPUserName.Trim() == UserName && w.CRPPassWord.Trim() == EcryptedPassword && w.Status == 1).Select(user => new CompanyUserLoggedViewModel
                {
                    WebUserRowID = user.WebUserRowID,
                    TeamMemberRoWID = user.TeamMemberRoWID,
                    TeamMemberName = (user.TeamMember.TMFirstName + " " + user.TeamMember.TMLastName).Trim(),
                    TeamMemberEmail = user.TeamMember.EmailID,
                    CRPUserName = user.CRPUserName.Trim(),
                    CRPPassWord = user.CRPPassWord.Trim(),
                    IsExportedExcel = user.IsExportedExcel,
                    IsExportedWord = user.IsExportedWord,
                    IsExportedPDF = user.IsExportedPDF,
                    CreatedDate = user.CreatedDate,
                    ModifiedDate = user.ModifiedDate,
                    Status = user.Status
                }).FirstOrDefault();

                return LoggedUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CompanyLoginViewModel> GetAllActiveWebUsers()
        {
            try
            {
                return db.WebUsers.Where(w => w.Status == 1).Select(w => new CompanyLoginViewModel
                {
                    CRPUserName = w.CRPUserName.Trim(),
                    CRPPassWord = w.CRPPassWord.Trim()
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BlockedCompanyUser(UpdateCompanyUserBlockStatusViewModel model)
        {
            try
            {
                if (model != null)
                {
                    short WebUserRowID = db.WebUsers.Where(w => w.CRPUserName.Trim() == model.CRPUserName).FirstOrDefault().WebUserRowID;
                    if(WebUserRowID > 0)
                    {
                        db.WebUsers.Single(w => w.WebUserRowID == WebUserRowID).BlockedDate = model.BlockedDate;
                        db.WebUsers.Single(w => w.WebUserRowID == WebUserRowID).Status = model.Status;
                    }
                }
                else
                {
                    throw new Exception("Invalid block user details!");
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

        public int AddUserLoggedInDetails(AddUserLoggedInDetailViewModel model)
        {
            try
            {
                UserLoginLogOutDetail entity = new UserLoginLogOutDetail();
                entity.LoginName = model.LoginName;
                entity.LoginType = model.LoginType;
                entity.LoginId = model.LoginId;
                entity.LoginBy = model.LoginBy;
                entity.IPDetails = model.IPDetails;
                entity.LoginDate = model.LoginDate;
                entity.LoginTime = DateTime.Now;
                entity.LogoutTime = model.LogoutTime;
                entity.LoginStatus = model.LoginStatus;
                db.UserLoginLogOutDetails.Add(entity);
                db.SaveChanges();

                return entity.LoginDetailRowID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUserLogOutDetails(UpdateUserLogOutDetailViewModel model)
        {
            try
            {
                db.UserLoginLogOutDetails.Single(l => l.LoginDetailRowID == model.LoginDetailRowID && l.LoginStatus == 1).LogoutTime = model.LogoutTime;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //For Client User Login 

        public ClientUserLoggedViewModel GetClientUserLoggedDetails(string UserName, string EcryptedPassword)
        {
            try
            {
                return db.PQClientLogins.Where(w => w.UserID.Trim() == UserName && w.UPass.Trim() == EcryptedPassword && w.Status == 1).Select(user => new ClientUserLoggedViewModel
                {
                    ClientUserRowID = user.ClientUserRowID,
                    ClientRowID = user.ClientRowID,
                    ClientName = user.PQClientMaster.MasterAbbreviation.ClientName.Trim(),
                    ClientBranch = user.ClientBranch,
                    ClientSubGroupName = user.PQClientMaster.MasterClientSubGroup.ClientSubGroupName.Trim(),
                    LocationName = user.PQClientMaster.MasterLocation.LocationName,
                    HRApprovalRequired = user.PQClientMaster.HRApprovalRequired,
                    Abbreviation = user.PQClientMaster.MasterAbbreviation.ClientAbbreviation,
                    CodeGeneration = user.PQClientMaster.CodeGeneration,
                    UserID = user.UserID.Trim(),
                    UPass = user.UPass.Trim(),
                    CSpocName=user.PQClientMaster.CSpocName,
                    CSpocEmailID=user.PQClientMaster.CSpocEmailID,
                    CreatedBy = user.CreatedBy.Trim(),
                    CreatedTime = user.CreatedTime,
                    ModifiedTime = user.ModifiedTime,
                    Status = user.Status
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientLoginViewModel> GetAllActiveClientUsers()
        {
            try
            {
                return db.PQClientLogins.Where(w => w.Status == 1).Select(w => new ClientLoginViewModel
                {
                    CRPUserName = w.UserID.Trim(),
                    CRPPassWord = w.UPass.Trim()
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BlockedClientUser(UpdateClientUserBlockStatusViewModel model)
        {
            try
            {
                if (model != null)
                {
                    int ClientUserRowID = db.PQClientLogins.Where(w => w.UserID.Trim() == model.UserID).FirstOrDefault().ClientUserRowID;
                    if (ClientUserRowID > 0)
                    {
                        db.PQClientLogins.Single(w => w.ClientUserRowID == ClientUserRowID).BlockedDate = model.BlockedDate;
                        db.PQClientLogins.Single(w => w.ClientUserRowID == ClientUserRowID).Status = model.Status;
                    }
                }
                else
                {
                    throw new Exception("Invalid block user details!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //For Candidate User Login

        public CandidateUserLoggedViewModel GetCandidateUserLoggedDetails(string UserName, string EcryptedPassword)
        {
            try
            {
                return db.PQCandidateLogins.Where(w => w.UserID.Trim() == UserName && w.UPass.Trim() == EcryptedPassword && w.Status == 1 && w.UserType==1).Select(user => new CandidateUserLoggedViewModel
                {
                    CandidateUserRowID = user.CandidateUserRowID,
                    ClientRowID = user.ClientRowID,
                    HRApprovalRequired=user.PQClientMaster.HRApprovalRequired,
                    CandidateName = user.CandidateName,
                    CandidateEmail = user.CandidateEmail,
                    UserID = user.UserID.Trim(),
                    UPass = user.UPass.Trim(),
                    CreatedBy = user.CreatedBy.Trim(),
                    CreatedTime = user.CreatedTime,
                    ModifiedTime = user.ModifiedTime,
                    YTRApplicable = user.YTRApplicable,
                    TempPersonalRowID=user.TempPersonalRowID                    
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CandidateUserLoggedViewModel GetInsuffCandidateUserLoggedDetails(string UserName, string EcryptedPassword)
        {
            try
            {
                return db.PQCandidateInsuffLogins.Where(w => w.UserID.Trim() == UserName && w.UPass.Trim() == EcryptedPassword && w.Status == 1).Select(user => new CandidateUserLoggedViewModel
                {
                    CandidateUserRowID = user.CInsuffUserRowID,
                    ClientRowID = user.ClientRowID,
                    HRApprovalRequired = user.PQClientMaster.HRApprovalRequired,
                    CandidateName = user.CandidateName,
                    CandidateEmail = user.UserID,
                    UserID = user.UserID.Trim(),
                    UPass = user.UPass.Trim(),
                    CreatedBy = user.CreatedBy.Trim(),
                    CreatedTime = user.CreatedTime,
                    ModifiedTime = user.ModifiedTime,
                    YTRApplicable = user.PQClientMaster.YTRStatus,
                    TempPersonalRowID = user.PersonalRowID
                }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CandidateLoginViewModel> GetAllActiveCandidateUsers()
        {
            try
            {
                return db.PQCandidateLogins.Where(w => w.Status == 1).Select(w => new CandidateLoginViewModel
                {
                    CRPUserName = w.UserID.Trim(),
                    CRPPassWord = w.UPass.Trim()
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExpireCandidateLogin(UpdateCandidateLoginExpireStatusViewModel model)
        {
            try
            {
                if (model != null)
                {
                    int CandidateUserRowID = db.PQCandidateLogins.Where(w => w.UserID.Trim() == model.UserID).FirstOrDefault().CandidateUserRowID;
                    if (CandidateUserRowID > 0)
                    {
                        db.PQCandidateLogins.Single(w => w.CandidateUserRowID == CandidateUserRowID).UserType = model.UserType;
                        db.PQCandidateLogins.Single(w => w.CandidateUserRowID == CandidateUserRowID).Status = model.Status;
                    }
                }
                else
                {
                    throw new Exception("Invalid block user details!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region ***** For Vendor User Login *****
        
        public VendorUserLoggedViewModel GetVendorUserLoggedDetails(string UserName, string EcryptedPassword)
        {
            try
            {
                var listUser =db.MasterVendorLogins.Where(w => w.UserID.Trim() == UserName && w.UPass.Trim() == EcryptedPassword && w.Status == 1).Select(user => new VendorUserLoggedViewModel
                {
                    VendorLoginRowID = user.VendorLoginRowID,
                    VendorRowID = user.VendorRowID,
                    VendorName = user.MasterVendor.VendorName.Trim(),
                    VendorEmaiID = user.MasterVendor.VendorEmaiID.Trim(),
                    ContactPerson = user.ContactPerson,
                    MobileNo = user.MobileNo,
                    UserID = user.UserID.Trim(),
                    UPass = user.UPass.Trim(),
                    UserType = user.UserType,
                    CreatedBy = user.CreatedBy.Trim(),
                    CreatedTime = user.CreatedTime,
                    ModifiedTime = user.ModifiedTime,
                    Status = user.Status
                }).FirstOrDefault();
                return listUser;
            }
            
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<VendorLoginViewModel> GetAllActiveVendorUsers()
        {
            try
            {
                return db.MasterVendorLogins.Where(w => w.Status == 1).Select(w => new VendorLoginViewModel
                {
                    CRPUserName = w.UserID.Trim(),
                    CRPPassWord = w.UPass.Trim()
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BlockedVendorUser(UpdateVendorUserBlockStatusViewModel model)
        {
            try
            {
                if (model != null)
                {
                    int VendorLoginRowID = db.MasterVendorLogins.Where(w => w.UserID.Trim() == model.UserID).FirstOrDefault().VendorLoginRowID;
                    if (VendorLoginRowID > 0)
                    {
                        db.MasterVendorLogins.Single(w => w.VendorLoginRowID == VendorLoginRowID).BlockedDate = model.BlockedDate;
                        db.MasterVendorLogins.Single(w => w.VendorLoginRowID == VendorLoginRowID).Status = model.Status;
                    }
                }
                else
                {
                    throw new Exception("Invalid block user details!");
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
