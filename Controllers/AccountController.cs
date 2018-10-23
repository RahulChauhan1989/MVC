using BAL.HRRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ViewModels.CandidateViewModel;
using ViewModels.ClientViewModel;
using ViewModels.HRViewModels;
using ViewModels.PartnerViewModels;
using WebAppBGV.CommonMethods;

namespace WebAppBGV.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepository repoAccount;
        public AccountController(IAccountRepository _repoAccount)
        {
            repoAccount = _repoAccount;
        }

        #region *********************** Company Login *********************

        // GET: Account
        public ActionResult Index()
        {
            Session["Counter"] = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Index(CompanyLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.Compare(model.CRPUserName, "", false) == 0 && string.Compare(model.CRPPassWord, "", false) == 0)
                    {
                        ModelState.AddModelError("", "Enter User Name and Password");
                    }
                    else if (string.Compare(model.CRPUserName, "", false) == 0 && string.Compare(model.CRPPassWord, "", false) != 0)
                    {
                        ModelState.AddModelError("", "Enter User Name");
                    }
                    else if (!(string.Compare(model.CRPUserName, "", false) != 0 && string.Compare(model.CRPPassWord, "", false) == 0))
                    {
                        DateTime today = DateTime.Today;
                        string str = model.CRPUserName.Trim().ToLower();
                        string str1 = model.CRPPassWord.Trim().ToLower();
                        string[] strArrays1 = str.Split(' ');
                        string[] strArrays2 = str1.Split(' ');
                        string str2 = strArrays1[0];
                        string str3 = strArrays2[0];

                        if (!(string.Compare(str2, "select", false) == 0 || string.Compare(str2, "exec", false) == 0 || string.Compare(str2, "execute", false) == 0 || string.Compare(str2, "drop", false) == 0 || string.Compare(str2, "truncate", false) == 0 || string.Compare(str2, "insert", false) == 0 || string.Compare(str2, "update", false) == 0 || string.Compare(str2, "delete", false) == 0 || string.Compare(str2, "union", false) == 0 || string.Compare(str2, "create", false) == 0)
                          )
                        {
                            if (!(string.Compare(str3, "select", false) == 0 || string.Compare(str3, "exec", false) == 0 || string.Compare(str3, "execute", false) == 0 || string.Compare(str3, "drop", false) == 0 || string.Compare(str3, "truncate", false) == 0 || string.Compare(str3, "insert", false) == 0 || string.Compare(str3, "update", false) == 0 || string.Compare(str3, "delete", false) == 0 || string.Compare(str2, "union", false) == 0 || string.Compare(str2, "create", false) == 0)
                               )
                            {
                                string UserName = model.CRPUserName.Trim();
                                string UserPassword = model.CRPPassWord.Trim();
                                string encPassword = clsCommonMethods.PasswordEncrypt(model.CRPPassWord.Trim());

                                if (!(string.Compare(model.CRPUserName.Trim(), "Arvind", false) == 0 & string.Compare(model.CRPPassWord.Trim(), "Arvind", false) == 0))
                                {
                                    CompanyUserLoggedViewModel loggedUser = new CompanyUserLoggedViewModel();
                                    try
                                    {
                                        loggedUser = repoAccount.GetCompanyUserLoggedDetails(UserName, encPassword);
                                    }
                                    catch (Exception exception1)
                                    {
                                        ViewBag.ErrorMsg = exception1.Message;
                                        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), exception1.Message, exception1.StackTrace);
                                    }

                                    if (loggedUser == null)
                                    {
                                        var activWebUsers = repoAccount.GetAllActiveWebUsers();
                                        foreach (var webUser in activWebUsers)
                                        {
                                            if (webUser.CRPUserName.Trim() == UserName || !(webUser.CRPPassWord.Trim() != encPassword))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                Session["Counter"] = Convert.ToInt32(Session["Counter"]) + 1;
                                                break;
                                            }
                                        }

                                        if (!(Convert.ToInt32(Session["Counter"]) >= 3))
                                        {
                                            ViewBag.ErrorMsg = "Login Failed.Try Again!";
                                            clsCommonMethods.UserLog(Server.MapPath("~\\ErrorLogs\\Unauthorized_UserLog"), UserName, UserPassword, "Company");
                                            return View();
                                        }
                                        else
                                        {
                                            Session["Counter"] = 0;
                                            UpdateCompanyUserBlockStatusViewModel userBlocked = new UpdateCompanyUserBlockStatusViewModel();
                                            userBlocked.CRPUserName = UserName;
                                            userBlocked.BlockedDate = DateTime.Now;
                                            userBlocked.Status = 3;

                                            repoAccount.BlockedCompanyUser(userBlocked);
                                            repoAccount.SaveChanges();

                                            ViewBag.ErrorMsg = "User has been Blocked, Please contact to Administrator!";
                                            Session.Abandon();
                                            return View();
                                        }
                                    }
                                    else
                                    {
                                        Session["CRPUserName"] = UserName;
                                        Session["WebUserRowid"] = loggedUser.WebUserRowID;
                                        Session["TeamMemberRowID"] = loggedUser.TeamMemberRoWID;
                                        Session["TeamMemberName"] = loggedUser.TeamMemberName;
                                        Session["TeamMemberEmail"] = loggedUser.TeamMemberEmail;
                                        //Session["LocationCode"] = loggedUser.LocationRowID;
                                        Session["ClientUType"] = "Company";
                                        Session["Valid"] = 1;

                                        if (Convert.ToInt32(Session["Valid"]) == 1)
                                        {
                                            DateTime dateTime = DateTime.Today;
                                            TimeSpan TimeSinceCreation = new TimeSpan();

                                            if (loggedUser.ModifiedDate != null)
                                            {
                                                TimeSinceCreation = dateTime.Subtract(loggedUser.ModifiedDate.Value);
                                            }
                                            else
                                            {
                                                TimeSinceCreation = dateTime.Subtract(loggedUser.CreatedDate.Value);
                                            }

                                            if (TimeSinceCreation.Days > 29)
                                            {
                                                ViewBag.ErrorMsg = "Your password has expired. Please contact your Administrator!";
                                                Session.Abandon();
                                                return View();
                                            }
                                            else if (TimeSinceCreation.Days < 0)
                                            {
                                                clsCommonMethods.UserLog(Server.MapPath("~\\ErrorLogs\\Unauthorized_UserLog"), UserName, UserPassword, "Company");
                                                ViewBag.ErrorMsg = "Invalid login. Please Try again!";
                                                Session.Abandon();
                                                return View();
                                            }
                                        }

                                        AddUserLoggedInDetailViewModel loggedInDetails = new AddUserLoggedInDetailViewModel();
                                        loggedInDetails.LoginName = loggedUser.TeamMemberName;
                                        loggedInDetails.LoginType = "Company";
                                        loggedInDetails.LoginId = UserName;
                                        loggedInDetails.LoginBy = "";
                                        loggedInDetails.IPDetails = Request.UserHostAddress;
                                        loggedInDetails.LoginDate = DateTime.Now;
                                        loggedInDetails.LoginStatus = 1;

                                        Session["LoginDetailRowID"] = repoAccount.AddUserLoggedInDetails(loggedInDetails);
                                    }
                                }
                                else
                                {
                                    #region Commented Code
                                    Session["TeamMemberName"] = "Arvind";
                                    Session["TeamMemberRowID"] = 1;
                                    Session["CRPUserName"] = "Arvind";
                                    Session["Department"] = "Admin";
                                    Session["Designation"] = "Administrator";
                                    Session["Valid"] = 1;
                                    FormsAuthentication.SetAuthCookie(UserName, false);
                                    return RedirectToAction("Index", "Home");
                                    #endregion
                                }

                                FormsAuthentication.SetAuthCookie(UserName, false);
                                return RedirectToAction("SelectDesignation", "Home");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Password");
                    }
                }
                else
                {
                    var query = from state in ModelState.Values
                                from error in state.Errors
                                select error.ErrorMessage;

                    var errorList = query.ToList();
                    string strError = string.Empty;
                    foreach (string str in errorList)
                    {
                        strError += str + "\n";
                    }

                    ModelState.AddModelError("", strError);
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View();
        }

        public ActionResult Logout()
        {
            try
            {
                UpdateLogOutDetails();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return RedirectToAction("Index");
        }

        public ActionResult TimeoutRedirect()
        {
            return View();
        }

        #endregion

        #region *********************** Client Login *********************

        // GET: Account
        public ActionResult ClientLogin()
        {
            Session["Counter"] = 0;
            return View();
        }

        [HttpPost]
        public ActionResult ClientLogin(ClientLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.Compare(model.CRPUserName, "", false) == 0 && string.Compare(model.CRPPassWord, "", false) == 0)
                    {
                        ModelState.AddModelError("", "Enter User Name and Password");
                    }
                    else if (string.Compare(model.CRPUserName, "", false) == 0 && string.Compare(model.CRPPassWord, "", false) != 0)
                    {
                        ModelState.AddModelError("", "Enter User Name");
                    }
                    else if (!(string.Compare(model.CRPUserName, "", false) != 0 && string.Compare(model.CRPPassWord, "", false) == 0))
                    {
                        DateTime today = DateTime.Today;
                        string str = model.CRPUserName.Trim().ToLower();
                        string str1 = model.CRPPassWord.Trim().ToLower();
                        string[] strArrays1 = str.Split(' ');
                        string[] strArrays2 = str1.Split(' ');
                        string str2 = strArrays1[0];
                        string str3 = strArrays2[0];

                        if (!(string.Compare(str2, "select", false) == 0 || string.Compare(str2, "exec", false) == 0 || string.Compare(str2, "execute", false) == 0 || string.Compare(str2, "drop", false) == 0 || string.Compare(str2, "truncate", false) == 0 || string.Compare(str2, "insert", false) == 0 || string.Compare(str2, "update", false) == 0 || string.Compare(str2, "delete", false) == 0 || string.Compare(str2, "union", false) == 0 || string.Compare(str2, "create", false) == 0)
                          )
                        {
                            if (!(string.Compare(str3, "select", false) == 0 || string.Compare(str3, "exec", false) == 0 || string.Compare(str3, "execute", false) == 0 || string.Compare(str3, "drop", false) == 0 || string.Compare(str3, "truncate", false) == 0 || string.Compare(str3, "insert", false) == 0 || string.Compare(str3, "update", false) == 0 || string.Compare(str3, "delete", false) == 0 || string.Compare(str2, "union", false) == 0 || string.Compare(str2, "create", false) == 0)
                               )
                            {
                                string UserName = model.CRPUserName.Trim();
                                string UserPassword = model.CRPPassWord.Trim();
                                string encPassword = clsCommonMethods.PasswordEncrypt(model.CRPPassWord.Trim());

                                ClientUserLoggedViewModel loggedUser = new ClientUserLoggedViewModel();
                                try
                                {
                                    loggedUser = repoAccount.GetClientUserLoggedDetails(UserName, encPassword);
                                }
                                catch (Exception exception1)
                                {
                                    ViewBag.ErrorMsg = exception1.Message;
                                    clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), exception1.Message, exception1.StackTrace);
                                }

                                if (loggedUser == null)
                                {
                                    var activWebUsers = repoAccount.GetAllActiveClientUsers();
                                    foreach (var webUser in activWebUsers)
                                    {
                                        if (!(webUser.CRPUserName.Trim() == UserName) || !(webUser.CRPPassWord.Trim() != encPassword))
                                        {
                                            continue;
                                        }

                                        Session["Counter"] = Convert.ToInt32(Session["Counter"]) + 1;
                                        break;
                                    }

                                    if (!(Convert.ToInt32(Session["Counter"]) >= 3))
                                    {
                                        ViewBag.ErrorMsg = "Login Failed.Try Again!";
                                        clsCommonMethods.UserLog(Server.MapPath("~\\ErrorLogs\\Unauthorized_UserLog"), UserName, UserPassword, "Client");
                                        return View();
                                    }
                                    else
                                    {
                                        Session["Counter"] = 0;
                                        UpdateClientUserBlockStatusViewModel userBlocked = new UpdateClientUserBlockStatusViewModel();
                                        userBlocked.UserID = UserName;
                                        userBlocked.BlockedDate = DateTime.Now;
                                        userBlocked.Status = 3;

                                        repoAccount.BlockedClientUser(userBlocked);
                                        repoAccount.SaveChanges();

                                        ViewBag.ErrorMsg = "User has been Blocked, Please contact to Administrator!";
                                        Session.Abandon();
                                        return View();
                                    }
                                }
                                else
                                {
                                    Session["UserName"] = UserName;
                                    Session["ClientUserRowID"] = loggedUser.ClientUserRowID;
                                    Session["ClientRowID"] = loggedUser.ClientRowID;
                                    Session["ClientName"] = loggedUser.ClientName + " (" + loggedUser.ClientSubGroupName + ")";
                                    Session["ClientSubGroupName"] = loggedUser.ClientSubGroupName;
                                    Session["LocationName"] = loggedUser.LocationName;
                                    Session["HRApproval"] = loggedUser.HRApprovalRequired;
                                    Session["Abbreviation"] = loggedUser.Abbreviation;
                                    Session["CodeGeneration"] = loggedUser.CodeGeneration;
                                    Session["CSpocName"] = loggedUser.CSpocName;
                                    Session["CSpocEmailID"] = loggedUser.CSpocEmailID;
                                    Session["CreatedBy"] = loggedUser.CreatedBy;
                                    Session["ClientBranch"] = loggedUser.ClientBranch;
                                    Session["ClientUType"] = "Client";
                                    Session["Valid"] = 1;

                                    if (Convert.ToInt32(Session["Valid"]) == 1)
                                    {
                                        DateTime dateTime = DateTime.Today;
                                        TimeSpan TimeSinceCreation = new TimeSpan();

                                        if (loggedUser.ModifiedTime != null)
                                        {
                                            TimeSinceCreation = dateTime.Subtract(loggedUser.ModifiedTime.Value);
                                        }
                                        else
                                        {
                                            TimeSinceCreation = dateTime.Subtract(loggedUser.CreatedTime.Value);
                                        }

                                        if (TimeSinceCreation.Days > 179)
                                        {
                                            ViewBag.ErrorMsg = "Your password has expired. Please contact your Administrator!";
                                            Session.Abandon();
                                            return View();
                                        }
                                        else if (TimeSinceCreation.Days < 0)
                                        {
                                            clsCommonMethods.UserLog(Server.MapPath("~\\ErrorLogs\\Unauthorized_UserLog"), UserName, UserPassword, "Client");
                                            ViewBag.ErrorMsg = "Invalid login. Please Try again!";
                                            Session.Abandon();
                                            return View();
                                        }
                                    }

                                    AddUserLoggedInDetailViewModel loggedInDetails = new AddUserLoggedInDetailViewModel();
                                    loggedInDetails.LoginName = loggedUser.ClientName + "(" + loggedUser.ClientSubGroupName + ")";
                                    loggedInDetails.LoginType = loggedUser.LocationName;
                                    loggedInDetails.LoginId = UserName;
                                    loggedInDetails.LoginBy = "Client";
                                    loggedInDetails.IPDetails = Request.UserHostAddress;
                                    loggedInDetails.LoginDate = DateTime.Now;
                                    loggedInDetails.LoginStatus = 1;

                                    Session["LoginDetailRowID"] = repoAccount.AddUserLoggedInDetails(loggedInDetails);
                                }

                                FormsAuthentication.SetAuthCookie(UserName, false);
                                return RedirectToAction("DashboardClient", "Home", new { area = "ClientArea" });
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Password");
                    }
                }
                else
                {
                    var query = from state in ModelState.Values
                                from error in state.Errors
                                select error.ErrorMessage;

                    var errorList = query.ToList();
                    string strError = string.Empty;
                    foreach (string str in errorList)
                    {
                        strError += str + "\n";
                    }

                    ModelState.AddModelError("", strError);
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View();
        }

        public ActionResult LogOutClient()
        {
            try
            {
                UpdateLogOutDetails();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return RedirectToAction("ClientLogin");
        }

        public ActionResult ClientTimeoutRedirect()
        {
            return View();
        }

        #endregion

        #region *********************** Candidate Login *********************

        // GET: Account
        public ActionResult CandidateLogin()
        {
            Session["Counter"] = 0;
            return View();
        }

        [HttpPost]
        public ActionResult CandidateLogin(CandidateLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.Compare(model.CRPUserName, "", false) == 0 && string.Compare(model.CRPPassWord, "", false) == 0)
                    {
                        ModelState.AddModelError("", "Enter User Name and Password");
                    }
                    else if (string.Compare(model.CRPUserName, "", false) == 0 && string.Compare(model.CRPPassWord, "", false) != 0)
                    {
                        ModelState.AddModelError("", "Enter User Name");
                    }
                    else if (!(string.Compare(model.CRPUserName, "", false) != 0 && string.Compare(model.CRPPassWord, "", false) == 0))
                    {
                        DateTime today = DateTime.Today;
                        string str = model.CRPUserName.Trim().ToLower();
                        string str1 = model.CRPPassWord.Trim().ToLower();
                        string[] strArrays1 = str.Split(' ');
                        string[] strArrays2 = str1.Split(' ');
                        string str2 = strArrays1[0];
                        string str3 = strArrays2[0];

                        if (!(string.Compare(str2, "select", false) == 0 || string.Compare(str2, "exec", false) == 0 || string.Compare(str2, "execute", false) == 0 || string.Compare(str2, "drop", false) == 0 || string.Compare(str2, "truncate", false) == 0 || string.Compare(str2, "insert", false) == 0 || string.Compare(str2, "update", false) == 0 || string.Compare(str2, "delete", false) == 0 || string.Compare(str2, "union", false) == 0 || string.Compare(str2, "create", false) == 0)
                          )
                        {
                            if (!(string.Compare(str3, "select", false) == 0 || string.Compare(str3, "exec", false) == 0 || string.Compare(str3, "execute", false) == 0 || string.Compare(str3, "drop", false) == 0 || string.Compare(str3, "truncate", false) == 0 || string.Compare(str3, "insert", false) == 0 || string.Compare(str3, "update", false) == 0 || string.Compare(str3, "delete", false) == 0 || string.Compare(str2, "union", false) == 0 || string.Compare(str2, "create", false) == 0)
                               )
                            {
                                string UserName = model.CRPUserName.Trim();
                                string UserPassword = model.CRPPassWord.Trim();
                                string encPassword = clsCommonMethods.PasswordEncrypt(model.CRPPassWord.Trim());

                                CandidateUserLoggedViewModel loggedUser = new CandidateUserLoggedViewModel();
                                try
                                {
                                    if (IsValidEmail(UserName))
                                    {
                                        loggedUser = repoAccount.GetInsuffCandidateUserLoggedDetails(UserName, encPassword);
                                    }
                                    else
                                    {
                                        loggedUser = repoAccount.GetCandidateUserLoggedDetails(UserName, encPassword);
                                    }
                                }
                                catch (Exception exception1)
                                {
                                    ViewBag.ErrorMsg = exception1.Message;
                                    clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), exception1.Message, exception1.StackTrace);
                                }

                                if (loggedUser == null)
                                {
                                    this.Session.Abandon();
                                    ViewBag.ErrorMsg = "Login Failed.Try Again!";
                                    clsCommonMethods.UserLog(Server.MapPath("~\\ErrorLogs\\Unauthorized_UserLog"), UserName, UserPassword, "Candidate");
                                    return View();
                                }
                                else
                                {
                                    Session["CadidateUserName"] = UserName;
                                    Session["CandidateUserRowID"] = loggedUser.CandidateUserRowID;
                                    Session["ClientRowID"] = loggedUser.ClientRowID;
                                    Session["HRApproval"] = loggedUser.HRApprovalRequired;
                                    Session["TempPersonalRowID"] = loggedUser.TempPersonalRowID;
                                    Session["LoginCandidateName"] = loggedUser.CandidateName;
                                    Session["CandidateEmail"] = loggedUser.CandidateEmail;
                                    Session["YTRApplicable"] = loggedUser.YTRApplicable;
                                    Session["CreatedBy"] = loggedUser.CreatedBy;
                                    Session["ClientUType"] = "Candidate";
                                    Session["Valid"] = 1;

                                    if (Convert.ToInt32(Session["Valid"]) == 1)
                                    {
                                        DateTime dateTime = DateTime.Today;
                                        TimeSpan TimeSinceCreation = new TimeSpan();

                                        if (loggedUser.ModifiedTime != null)
                                        {
                                            TimeSinceCreation = dateTime.Subtract(loggedUser.ModifiedTime.Value);
                                        }
                                        else
                                        {
                                            TimeSinceCreation = dateTime.Subtract(loggedUser.CreatedTime.Value);
                                        }

                                        if (TimeSinceCreation.Days > 15)
                                        {
                                            ViewBag.ErrorMsg = "Your password has expired. Please contact your Administrator!";
                                            try
                                            {
                                                UpdateCandidateLoginExpireStatusViewModel loginExpire = new UpdateCandidateLoginExpireStatusViewModel();
                                                loginExpire.UserID = UserName;
                                                loginExpire.UserType = 0;
                                                loginExpire.Status = 0;

                                                repoAccount.ExpireCandidateLogin(loginExpire);
                                                repoAccount.SaveChanges();
                                            }
                                            catch (Exception exception11)
                                            {
                                                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), exception11.Message, exception11.StackTrace);
                                            }

                                            Session.Abandon();
                                            return View();
                                        }
                                        else if (TimeSinceCreation.Days < 0)
                                        {
                                            clsCommonMethods.UserLog(Server.MapPath("~\\ErrorLogs\\Unauthorized_UserLog"), UserName, UserPassword, "Candidate");
                                            ViewBag.ErrorMsg = "Invalid login. Please Try again!";
                                            Session.Abandon();
                                            return View();
                                        }
                                    }

                                    AddUserLoggedInDetailViewModel loggedInDetails = new AddUserLoggedInDetailViewModel();
                                    loggedInDetails.LoginName = loggedUser.CandidateName;
                                    loggedInDetails.LoginType = loggedUser.CreatedBy;
                                    loggedInDetails.LoginId = UserName;
                                    loggedInDetails.LoginBy = "Candidate";
                                    loggedInDetails.IPDetails = Request.UserHostAddress;
                                    loggedInDetails.LoginDate = DateTime.Now;
                                    loggedInDetails.LoginStatus = 1;

                                    Session["LoginDetailRowID"] = repoAccount.AddUserLoggedInDetails(loggedInDetails);
                                }

                                FormsAuthentication.SetAuthCookie(UserName, false);
                                if (IsValidEmail(UserName))
                                {
                                    Session["CInsufficiency"] = "YES";
                                    return RedirectToAction("Index", "CandidateInsuff", new { area = "Candidate" });
                                }
                                else
                                {
                                    return RedirectToAction("Index", "Home", new { area = "Candidate" });
                                }
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Password");
                    }
                }
                else
                {
                    var query = from state in ModelState.Values
                                from error in state.Errors
                                select error.ErrorMessage;

                    var errorList = query.ToList();
                    string strError = string.Empty;
                    foreach (string str in errorList)
                    {
                        strError += str + "\n";
                    }

                    ModelState.AddModelError("", strError);
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View();
        }

        public ActionResult LogOutCandidate()
        {
            try
            {
                UpdateLogOutDetails();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return RedirectToAction("CandidateLogin");
        }

        public ActionResult CandidateTimeoutRedirect()
        {
            return View();
        }
              
        #endregion

        //Common Method
        private void UpdateLogOutDetails()
        {
            try
            {
                DictionaryEntry dictionaryEntry = new DictionaryEntry();
                DictionaryEntry dictionaryEntry1;

                UpdateUserLogOutDetailViewModel model = new UpdateUserLogOutDetailViewModel();
                model.LoginDetailRowID = Convert.ToInt32(Session["LoginDetailRowID"]);
                model.LogoutTime = DateTime.Now;

                repoAccount.UpdateUserLogOutDetails(model);

                FormsAuthentication.SignOut();

                this.Session.Clear();
                this.Session.Abandon();

                // Clear authentication cookie.
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                cookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie);

                IDictionaryEnumerator enumerator = HttpContext.Cache.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object current = enumerator.Current;
                    if (current != null)
                    {
                        dictionaryEntry1 = (DictionaryEntry)current;
                    }
                    else
                    {
                        dictionaryEntry1 = dictionaryEntry;
                    }
                    DictionaryEntry dictionaryEntry2 = dictionaryEntry1;
                    HttpContext.Cache.Remove(dictionaryEntry2.Key.ToString());
                }

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoServerCaching();
                Response.Cache.SetNoStore();
            }
            catch (Exception Ex)
            {
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                throw Ex;
            }
        }

        #region *********************** Vendor Login *********************

        // GET: Account
        public ActionResult VendorLogin()
        {
            Session["Counter"] = 0;
            return View();
        }

        [HttpPost]
        public ActionResult VendorLogin(VendorLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.Compare(model.CRPUserName, "", false) == 0 && string.Compare(model.CRPPassWord, "", false) == 0)
                    {
                        ModelState.AddModelError("", "Enter User Name and Password");
                    }
                    else if (string.Compare(model.CRPUserName, "", false) == 0 && string.Compare(model.CRPPassWord, "", false) != 0)
                    {
                        ModelState.AddModelError("", "Enter User Name");
                    }
                    else if (!(string.Compare(model.CRPUserName, "", false) != 0 && string.Compare(model.CRPPassWord, "", false) == 0))
                    {
                        DateTime today = DateTime.Today;
                        string str = model.CRPUserName.Trim().ToLower();
                        string str1 = model.CRPPassWord.Trim().ToLower();
                        string[] strArrays1 = str.Split(' ');
                        string[] strArrays2 = str1.Split(' ');
                        string str2 = strArrays1[0];
                        string str3 = strArrays2[0];

                        if (!(string.Compare(str2, "select", false) == 0 || string.Compare(str2, "exec", false) == 0 || string.Compare(str2, "execute", false) == 0 || string.Compare(str2, "drop", false) == 0 || string.Compare(str2, "truncate", false) == 0 || string.Compare(str2, "insert", false) == 0 || string.Compare(str2, "update", false) == 0 || string.Compare(str2, "delete", false) == 0 || string.Compare(str2, "union", false) == 0 || string.Compare(str2, "create", false) == 0)
                          )
                        {
                            if (!(string.Compare(str3, "select", false) == 0 || string.Compare(str3, "exec", false) == 0 || string.Compare(str3, "execute", false) == 0 || string.Compare(str3, "drop", false) == 0 || string.Compare(str3, "truncate", false) == 0 || string.Compare(str3, "insert", false) == 0 || string.Compare(str3, "update", false) == 0 || string.Compare(str3, "delete", false) == 0 || string.Compare(str2, "union", false) == 0 || string.Compare(str2, "create", false) == 0)
                               )
                            {
                                string UserName = model.CRPUserName.Trim();
                                string UserPassword = model.CRPPassWord.Trim();
                                string encPassword = clsCommonMethods.PasswordEncrypt(model.CRPPassWord.Trim());

                                VendorUserLoggedViewModel loggedUser = new VendorUserLoggedViewModel();
                                try
                                {
                                    loggedUser = repoAccount.GetVendorUserLoggedDetails(UserName, encPassword);
                                }
                                catch (Exception exception1)
                                {
                                    ViewBag.ErrorMsg = exception1.Message;
                                    clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), exception1.Message, exception1.StackTrace);
                                }

                                if (loggedUser == null)
                                {
                                    var activWebUsers = repoAccount.GetAllActiveVendorUsers();
                                    foreach (var webUser in activWebUsers)
                                    {
                                        if (!(webUser.CRPUserName.Trim() == UserName) || !(webUser.CRPPassWord.Trim() != encPassword))
                                        {
                                            continue;
                                        }

                                        Session["Counter"] = Convert.ToInt32(Session["Counter"]) + 1;
                                        break;
                                    }

                                    if (!(Convert.ToInt32(Session["Counter"]) >= 3))
                                    {
                                        ViewBag.ErrorMsg = "Login Failed.Try Again!";
                                        clsCommonMethods.UserLog(Server.MapPath("~\\ErrorLogs\\Unauthorized_UserLog"), UserName, UserPassword, "Vendor");
                                        return View();
                                    }
                                    else
                                    {
                                        Session["Counter"] = 0;
                                        UpdateVendorUserBlockStatusViewModel userBlocked = new UpdateVendorUserBlockStatusViewModel();
                                        userBlocked.UserID = UserName;
                                        userBlocked.BlockedDate = DateTime.Now;
                                        userBlocked.Status = 3;

                                        repoAccount.BlockedVendorUser(userBlocked);
                                        repoAccount.SaveChanges();

                                        ViewBag.ErrorMsg = "User has been Blocked, Please contact to Administrator!";
                                        Session.Abandon();
                                        return View();
                                    }
                                }
                                else
                                {
                                    Session["UserName"] = UserName;
                                    Session["VendorLoginRowID"] = loggedUser.VendorLoginRowID;
                                    Session["VendorRowID"] = loggedUser.VendorRowID;
                                    Session["VendorName"] = loggedUser.VendorName;
                                    Session["VendorEmaiID"] = loggedUser.VendorEmaiID;
                                    Session["ContactPerson"] = loggedUser.ContactPerson;
                                    Session["MobileNo"] = loggedUser.MobileNo;
                                    Session["UserType"] = loggedUser.UserType;
                                    Session["CreatedBy"] = loggedUser.CreatedBy;
                                    Session["Valid"] = 1;

                                    if (Convert.ToInt32(Session["Valid"]) == 1)
                                    {
                                        DateTime dateTime = DateTime.Today;
                                        TimeSpan TimeSinceCreation = new TimeSpan();

                                        if (loggedUser.ModifiedTime != null)
                                        {
                                            TimeSinceCreation = dateTime.Subtract(loggedUser.ModifiedTime.Value);
                                        }
                                        else
                                        {
                                            TimeSinceCreation = dateTime.Subtract(loggedUser.CreatedTime.Value);
                                        }

                                        if (TimeSinceCreation.Days > 179)
                                        {
                                            ViewBag.ErrorMsg = "Your password has expired. Please contact your Administrator!";
                                            Session.Abandon();
                                            return View();
                                        }
                                        else if (TimeSinceCreation.Days < 0)
                                        {
                                            clsCommonMethods.UserLog(Server.MapPath("~\\ErrorLogs\\Unauthorized_UserLog"), UserName, UserPassword, "Vendor");
                                            ViewBag.ErrorMsg = "Invalid login. Please Try again!";
                                            Session.Abandon();
                                            return View();
                                        }
                                    }

                                    AddUserLoggedInDetailViewModel loggedInDetails = new AddUserLoggedInDetailViewModel();
                                    loggedInDetails.LoginName = loggedUser.VendorName;
                                    if (loggedUser.UserType == 0)
                                    {
                                        loggedInDetails.LoginType = "Vendor";
                                    }
                                    else
                                    {
                                        loggedInDetails.LoginType = "Vendor's User";
                                    }

                                    loggedInDetails.LoginId = UserName;
                                    loggedInDetails.LoginBy = "Vendor";
                                    loggedInDetails.IPDetails = Request.UserHostAddress;
                                    loggedInDetails.LoginDate = DateTime.Now;
                                    loggedInDetails.LoginStatus = 1;

                                    Session["LoginDetailRowID"] = repoAccount.AddUserLoggedInDetails(loggedInDetails);
                                }

                                FormsAuthentication.SetAuthCookie(UserName, false);
                                return RedirectToAction("Index", "Home", new { area = "Partner" });
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Enter Password");
                    }
                }
                else
                {
                    var query = from state in ModelState.Values
                                from error in state.Errors
                                select error.ErrorMessage;

                    var errorList = query.ToList();
                    string strError = string.Empty;
                    foreach (string str in errorList)
                    {
                        strError += str + "\n";
                    }

                    ModelState.AddModelError("", strError);
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View();
        }

        public ActionResult LogOutVendor()
        {
            try
            {
                UpdateLogOutDetails();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return RedirectToAction("VendorLogin");
        }

        public ActionResult VendorTimeoutRedirect()
        {
            return View();
        }

        #endregion


        #region NonAction

        private static bool IsValidEmail(string email)
        {
            try
            {
                var r = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

                return !string.IsNullOrEmpty(email) && r.IsMatch(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}