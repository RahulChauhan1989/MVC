using BAL;
using BAL.CandidateRepository;
using BAL.ClientRepository;
using BAL.HRRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ViewModels.ClientViewModel;
using ViewModels.HRViewModels;
using ViewModels.PartnerViewModels;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class HRMgmtController : Controller
    {
        #region ********** Repository Object **********

        IDropDownMasterRepository repoDDL;
        ITeamMemberRepository repoTeamMember;
        IWebUserRepository repoWebUser;
        ILocationRepository repoLocation;
        IClientLoginRepository repoLogin;
        ITeamDepartmentRepository repoTeamDepartment;

        public HRMgmtController(
             IDropDownMasterRepository _repoDDL
            , ITeamMemberRepository _repoTeamMember
            , IWebUserRepository _repoWebUser
            , ILocationRepository _repoLocation
            , IClientLoginRepository _repoLogin
            , ITeamDepartmentRepository _repoTeamDepartment
        )
        {
            repoDDL = _repoDDL;
            repoTeamMember = _repoTeamMember;
            repoWebUser = _repoWebUser;
            repoLocation = _repoLocation;
            repoLogin = _repoLogin;
            repoTeamDepartment = _repoTeamDepartment;
        }

        #endregion

        // GET: HRMgmt
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            return View();
        }

        #region ********** TeamMember HRMgmt **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddTeamMember()
        {
            try
            {
                //BindState();
                BindCountry();
                BindTitleList();
                BindTitleFatherList();
                BindCategoryList();
                BindDepartmentList();
                BindBranchOfficeList();
                //BindDesignationList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddTeamMember(AddTeamMemberViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool flag = false;
                    if (model.EmployeeID != null && model.EmployeeID.Trim().Length > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(model.MobileNo))
                        {
                            if (model.MobileNo.Length < 10 || model.MobileNo.Length > 11)
                            {
                                flag = true;
                                ViewBag.ErrorMsg = "Enter Valid Mobile No";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(model.STD) && !string.IsNullOrWhiteSpace(model.ResidancePhoneNo))
                        {
                            if (model.STD.Length < 3)
                            {
                                flag = true;
                                ViewBag.ErrorMsg = "Enter valid STD Code";
                            }
                            else if (model.ResidancePhoneNo.Length < 6)
                            {
                                flag = true;
                                ViewBag.ErrorMsg = "Enter Valid Telephone No";
                            }
                        }
                        if (!flag)
                        {
                            if (!repoTeamMember.IsTeamMemberExist(model.EmployeeID.Trim()))
                            {
                                DateTime DateOfBirth = DateTime.Parse(model.DOB.ToString());
                                DateTime DateOfJoin = DateTime.Parse(model.DOJ.ToString());
                                var age = DateOfJoin.Year - DateOfBirth.Year;
                                if (age >= 18)
                                {
                                    repoTeamMember.AddTeamMember(model);
                                    int Res = repoTeamMember.SaveChanges();
                                    if (Res > 0)
                                    {
                                        TempData["SuccessMsg"] = "Record Added Successfully!";
                                        ModelState.Clear();
                                        return RedirectToAction("ManageTeamMembers");
                                    }
                                    else
                                    {
                                        ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                                    }
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "Date Of Birth should be less than 18 years From join Date";
                                }
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Record Already Exist!";
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "TeamMember Name could not be blank!");
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
            //BindState();
            BindCountry();
            BindTitleList();
            BindTitleFatherList();
            BindCategoryList();
            BindDepartmentList();
            BindBranchOfficeList();
            //BindDesignationList();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageTeamMembers(int page = 1, string sort = "TMFirstName", string sortDir = "asc", string Search = "")
        {
            TeamMemberListPagedModel model = new TeamMemberListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoTeamMember.GetTeamMember(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditTeamMember(short id = 0)
        {
            UpdateTeamMemberViewModel model = new UpdateTeamMemberViewModel();
            try
            {
                BindCountry();
                BindTitleList();
                BindTitleFatherList();
                BindCategoryList();
                BindDepartmentList();
                BindBranchOfficeList();
                //BindDesignationList();
                model = repoTeamMember.GetTeamMemberForUpdateById(id);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult EditTeamMember(UpdateTeamMemberViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool flag = false;
                    if (model.EmployeeID != null && model.EmployeeID.Trim().Length > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(model.MobileNo))
                        {
                            if (model.MobileNo.Length < 10 || model.MobileNo.Length > 11)
                            {
                                flag = true;
                                ModelState.AddModelError("", "Enter Valid Mobile No");
                                //ViewBag.ErrorMsg = "Enter Valid Mobile No";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(model.STD) && !string.IsNullOrWhiteSpace(model.ResidancePhoneNo))
                        {
                            if (model.STD.Length < 3)
                            {

                                flag = true;
                                ModelState.AddModelError("", "Enter valid STD Code");

                            }
                            else if (model.ResidancePhoneNo.Length < 6)
                            {
                                flag = true;
                                ModelState.AddModelError("", "Enter Valid Telephone No");
                            }
                        }
                        if (!flag)
                        {
                            if (!repoTeamMember.IsTeamMemberExist(model.TeamMemberRowID, model.EmployeeID.Trim()))
                            {
                                DateTime DateOfBirth = DateTime.Parse(model.DOB.ToString());
                                DateTime DateOfJoin = DateTime.Parse(model.DOJ.ToString());
                                var age = DateOfJoin.Year - DateOfBirth.Year;
                                if (age >= 18)
                                {
                                    repoTeamMember.UpdateTeamMember(model);
                                    int Res = repoTeamMember.SaveChanges();
                                    if (Res > 0)
                                    {
                                        TempData["SuccessMsg"] = "Record Added Successfully!";
                                        ModelState.Clear();
                                        return RedirectToAction("ManageTeamMembers");
                                    }
                                    else
                                    {
                                        ViewBag.ErrorMsg = "There is no change!";
                                    }
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "Date Of Birth should be less than 18 years From join Date!";
                                }
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Record Already Exist!";
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "TeamMember Name could not be blank!");
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
            BindCountry();
            BindTitleList();
            BindTitleFatherList();
            BindCategoryList();
            BindDepartmentList();
            BindBranchOfficeList();
            //BindDesignationList();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DeleteTeamMember(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoTeamMember.DeleteTeamMember(id);
                    int Res = repoTeamMember.SaveChanges();
                    if (Res > 0)
                    {
                        result = true;
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportTeamMembers()
        {
            // Step 1 - get the data from database
            var data = repoTeamMember.GetTeamMembersForExport();
            ExportToExcel(data, "TeamMembers");
        }

        #endregion

        #region ********** Manage Team Member Department And Designation **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageDepartDesignation(int page = 1, string sort = "EmployeeID", string sortDir = "asc", string Search = "", short tmid = 0)
        {
            TeamDepartmentListPagedModel model = new TeamDepartmentListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                Session["TMName"] = repoTeamMember.GetTeamMemberNameById(tmid);
                Session["tmid"] = tmid;
                model = repoTeamDepartment.GetTeamDepartmentAndDesignation(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, tmid);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddTeamDepartDesignation(short id = 0)
        {
            AddTeamDepartmentViewModel model = new AddTeamDepartmentViewModel();
            try
            {
                model.TeamMemberRowID = id;
                BindDepartmentList();
                BindDesignationList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddTeamDepartDesignation(AddTeamDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.TeamMemberRowID > 0)
                    {
                        int res = 0;
                        if (!string.IsNullOrEmpty(model.DesignationRowIds))
                        {
                            string[] ids = model.DesignationRowIds.Split(',');
                            foreach (var item in ids)
                            {
                                string[] Did = item.Split('_');
                                model.DepartmentRowID = Convert.ToByte(Did[0]);
                                model.DesignationRowID = Convert.ToByte(Did[1]);
                                model.Status = 1;
                                if (!repoTeamDepartment.IsDepartDesignationExist(model.DepartmentRowID, model.TeamMemberRowID))
                                {
                                    repoTeamDepartment.AddTeamDepartment(model);
                                    res = repoTeamDepartment.SaveChanges();
                                }
                            }
                        }
                        ModelState.Clear();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        return RedirectToAction("ManageDepartDesignation", new { tmid = model.TeamMemberRowID });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid TeamMemeber ID!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult MapTeamDepartmentWithAllClients(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    result = repoTeamDepartment.MapTeamDepartmentWithAllClients(id);
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DeleteTeamDepartAndDesignationById(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoTeamDepartment.DeleteTeamDepartAndDesignationById(id);
                    int Res = repoTeamDepartment.SaveChanges();
                    if (Res > 0)
                    {
                        result = true;
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ********** Reporting To TeamMember ********** 

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageReportedTeamMembers(short tdid = 0)
        {
            RepoToTeamMemberListPagedModel model = new RepoToTeamMemberListPagedModel();
            try
            {
                int page = 1; string sort = "EmployeeID"; string sortDir = "asc"; string Search = "";
                int pageSize = clsGlobalCommon.PageSize;
                model = repoTeamMember.GetReportedTeamMembers(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, tdid);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddReportingTeamMember(short tdid = 0)
        {
            AddRepoToTeamMemberViewModel model = new AddRepoToTeamMemberViewModel();
            try
            {
                model.TeamDepartmentRowID = tdid;
                BindRepoToTeamMemberList(tdid);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddReportingTeamMember(AddRepoToTeamMemberViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.RepoToIds != null && model.RepoToIds.Count() > 0)
                    {
                        repoTeamMember.AddRepoToTeamMember(model);
                        int Res = repoTeamMember.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageReportedTeamMembers", new { tdid = model.TeamDepartmentRowID });
                        }
                        else
                        {
                            TempData["ErrorMsg"] = "There is no change!";
                            return RedirectToAction("ManageReportedTeamMembers", new { tdid = model.TeamDepartmentRowID });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "TeamMember Name could not be blank!");
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
            }
            BindRepoToTeamMemberList(model.TeamDepartmentRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DeleteReportingTeamMember(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoTeamMember.DeleteReportingTeamMember(id);
                    int Res = repoTeamMember.SaveChanges();
                    if (Res > 0)
                    {
                        result = true;
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ********** WebUser HRMgmt **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddWebUser()
        {
            try
            {
                BindTeamMemberList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddWebUser(AddWebUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.TeamMemberRoWID == 0)
                    {
                        ModelState.AddModelError("", "Please Select Team Member!");
                    }
                    if (string.IsNullOrWhiteSpace(model.CRPUserName))
                    {
                        ModelState.AddModelError("", "User Name could not be blank!");
                    }
                    else if (!string.IsNullOrWhiteSpace(model.CRPPassWord))
                    {
                        if (!repoWebUser.IsWebUserExist(model.CRPUserName.Trim()))
                        {
                            string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(model.CRPPassWord.Trim());
                            model.CRPPassWord = EncryptedPasswd;
                            model.CreatedDate = DateTime.Now;
                            model.Status = 1;

                            repoWebUser.AddWebUser(model);
                            int Res = repoWebUser.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageWebUsers");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Record not save. Please try again later!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "User Name Already Exist. Choose Another One!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password could not be blank!");
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

            BindTeamMemberList();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageWebUsers(int page = 1, string sort = "CRPUserName", string sortDir = "asc", string Search = "")
        {
            WebUserListPagedModel model = new WebUserListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoWebUser.GetWebUser(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditWebUser(short id = 0)
        {
            UpdateWebUserViewModel model = new UpdateWebUserViewModel();
            try
            {
                BindTeamMemberList();
                model = repoWebUser.GetWebUserForUpdateById(id);
                model.CRPPassWord = clsCommonMethods.PasswordDecrypt(model.CRPPassWord.Trim());
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult EditWebUser(UpdateWebUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CRPPassWord != null && model.CRPPassWord.Trim().Length > 0 && model.WebUserRowID > 0)
                    {
                        string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(model.CRPPassWord.Trim());
                        model.CRPPassWord = EncryptedPasswd;
                        model.ModifiedDate = DateTime.Now;
                        repoWebUser.UpdateWebUser(model);
                        int Res = repoWebUser.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Edited Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageWebUsers");
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is no change!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "WebUser name could not be blank!");
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
            BindTeamMemberList();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult WebUserActive(string checkeds = "", short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    if (checkeds.Trim().ToLower() == "true")
                    {
                        checkeds = "1";
                    }
                    if (checkeds.Trim().ToLower() == "false")
                    {
                        checkeds = "0";
                    }
                    repoWebUser.ActiveWebUser(id, checkeds);
                    int Res = repoWebUser.SaveChanges();
                    if (Res > 0)
                    {
                        result = true;
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportWebUsers()
        {
            // Step 1 - get the data from database
            var data = repoWebUser.GetWebUsersForExport();
            foreach (var item in data)
            {
                item.CRPPassWord = clsCommonMethods.PasswordDecrypt(item.CRPPassWord.Trim());
            }
            ExportToExcel(data, "Webusers");
        }

        #endregion

        #region ********** UnBlockedUserCompany HRMgmt **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UnBlockedUserCompany(int page = 1, string sort = "CRPUserName", string sortDir = "asc",
            string TeamMemberName = "", string UserName = "")
        {
            UnBlockedCUListPagedModel model = new UnBlockedCUListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoWebUser.GetUnBlockedCompanyUser(page, pageSize, sort.ToLower(), sortDir.ToLower(), TeamMemberName, UserName);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return View(model);
        }

        //[HttpPost]
        //[SessionExpireFilterAttribute]
        //public ActionResult UnBlockedUsers(FormCollection form)
        //{
        //    //get collection of selected ids
        //    var chckedValues = form.GetValues("assignChkBx");

        //    //You can use each object if u wish from id
        //    foreach (var id in chckedValues)
        //    {
        //        //get object example..  Customer Customer = Customers.find(id);
        //        //Your Method here like send an item to customer
        //    }
        //    return RedirectToAction("UnBlockedUserCompany");
        //}

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult UnBlockedUsers(string checkeds = "", short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    if (checkeds.Trim().ToLower() == "true")
                    {
                        checkeds = "1";
                    }
                    if (checkeds.Trim().ToLower() == "false")
                    {
                        checkeds = "0";
                    }
                    UnBlockedUsersViewModel model = new UnBlockedUsersViewModel();
                    model.UnBlockedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    model.UnBlockedDate = DateTime.Now;
                    model.WebUserRowID = id;
                    model.Status = Convert.ToByte(checkeds);
                    if (model.UnBlockedBy > 0)
                    {
                        repoWebUser.UnBlockedUser(model);
                        int Res = repoWebUser.SaveChanges();
                        if (Res > 0)
                        {
                            result = true;
                            // Send_Mail_UnblockedPassword_Client
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invalid Id!";
                    }

                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ********** UnBlockUserClient HRMgmt **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UnBlockedUserClient(int page = 1, string sort = "CRPUserName", string sortDir = "asc",
            string ClientName = "", string UserName = "")
        {
            PQClientUserListPagedModel model = new PQClientUserListPagedModel();
            try
            {
                BindClientList();
                int pageSize = clsGlobalCommon.PageSize;
                model = repoLogin.GetBlockedClientUser(page, pageSize, sort.ToLower(), sortDir.ToLower(), ClientName, UserName);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult UnBlockedClientUsers(short id = 0, string checkeds = "")
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    if (checkeds.Trim().ToLower() == "true")
                    {
                        checkeds = "1";
                    }
                    if (checkeds.Trim().ToLower() == "false")
                    {
                        checkeds = "0";
                    }
                    UnBlockedClientUsersViewModel model = new UnBlockedClientUsersViewModel();
                    model.UnBlockedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    model.UnBlockedDate = DateTime.Now;
                    model.ClientUserRowID = id;
                    model.Status = Convert.ToByte(checkeds);
                    if (model.UnBlockedBy > 0)
                    {
                        repoLogin.UnBlockedClientUser(model);
                        int Res = repoLogin.SaveChanges();
                        if (Res > 0)
                        {
                            result = true;
                            // Send_Mail_UnblockedPassword_Client
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invalid Id!";
                    }

                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ********** UnBlockedPartnerUsers HRMgmt **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UnBlockedPartnerUsers(int page = 1, string sort = "CRPUserName", string sortDir = "asc",
            string PartnerName = "", string UserName = "")
        {
            VendorUserLoggedListPagedModel model = new VendorUserLoggedListPagedModel();
            try
            {
                BindClientList();
                int pageSize = clsGlobalCommon.PageSize;
                model = repoLogin.GetBlockeddPartnerUsers(page, pageSize, sort.ToLower(), sortDir.ToLower(), PartnerName, UserName);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult UpdateUnBlockedPartnerUsers(short id = 0, string checkeds = "")
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    if (checkeds.Trim().ToLower() == "true")
                    {
                        checkeds = "1";
                    }
                    if (checkeds.Trim().ToLower() == "false")
                    {
                        checkeds = "0";
                    }
                    UnBlockedPartnerUsersViewModel model = new UnBlockedPartnerUsersViewModel();
                    model.UnBlockedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    model.UnBlockedDate = DateTime.Now;
                    model.PartnerUsersRowID = id;
                    model.Status = Convert.ToByte(checkeds);
                    if (model.UnBlockedBy > 0)
                    {
                        repoLogin.UnBlockedPartnerUsers(model);
                        int Res = repoLogin.SaveChanges();
                        if (Res > 0)
                        {
                            result = true;
                            // Send_Mail_UnblockedPassword_Client
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invalid Id!";
                    }

                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ********** Dropdown HRMgmts **********

        public void BindTeamMemberList()
        {
            try
            {
                ViewBag.TeamMembers = repoDDL.GetTeamMemberForDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        void BindTitleList()
        {
            try
            {
                IEnumerable<SelectListItem> TitleList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Mr.", Value = "Mr.", Selected=false },
                    new SelectListItem { Text = "Ms.", Value = "Ms.", Selected=false },
                    new SelectListItem { Text = "Mrs.", Value = "Mrs.", Selected=false },
                    new SelectListItem { Text = "Mohd.", Value = "Mohd.", Selected=false },
                    new SelectListItem { Text = "Kahtun.", Value = "Kahtun.", Selected=false },
                };
                ViewBag.TitleList = TitleList;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        void BindTitleFatherList()
        {
            try
            {
                IEnumerable<SelectListItem> TitleList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Mr.", Value = "Mr.", Selected=false },
                    new SelectListItem { Text = "Mohd.", Value = "Mohd.", Selected=false },
                     new SelectListItem { Text = "Late.", Value = "Late.", Selected=false },
                };
                ViewBag.TitleFatherList = TitleList;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        void BindRepoToTeamMemberList(short tdid = 0)
        {
            var datalist = repoDDL.GetRepoToTeamMemberForDDL(tdid);

            ViewBag.RepoToTeamMember = new MultiSelectList(datalist, "TeamDepartmentRowID", "TeamMemberName");
        }

        void BindRepoToClientList()
        {
            ViewBag.RepoToClient = repoDDL.GetCategoriesForDDL();
        }

        void BindCategoryList()
        {
            ViewBag.Categories = repoDDL.GetCategoriesForDDL();
        }

        void BindDepartmentList()
        {
            ViewBag.Departments = repoDDL.GetDepartmentsForDDL();
        }

        void BindDesignationList()
        {
            ViewBag.Designations = repoDDL.GetDesignationsForDDL();
        }

        [NonAction]
        void BindClientList()
        {
            ViewBag.ClientList = repoDDL.GetClientListWithAbbAndLocationForDDL(); ;
        }

        void BindCountry()
        {
            ViewBag.Countries = repoDDL.GetCountriesForDDL();
        }

        [NonAction]
        void BindBranchOfficeList()
        {
            try
            {
                ViewBag.BranchOfficeList = repoDDL.GetBranchOfficeForDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        public JsonResult BindState(short id = 0)
        {
            var States = repoDDL.GetStatesByCountryIdForDDL(id);

            return Json(new SelectList(States.ToArray(), "StateRowID", "StateName"), JsonRequestBehavior.AllowGet);
        }

        //public void BindState(short id = 4)
        //{
        //    ViewBag.States = repoDDL.GetStatesByCountryIdForDDL(id);

        //    //return Json(new SelectList(States.ToArray(), "StateRowID", "StateName"), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult BindDistrict(short id = 0)
        {
            var Districts = repoDDL.GetDistrictsByStateIdForDDL(id);

            return Json(new SelectList(Districts.ToArray(), "DistrictRowID", "DistrictName"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindLocation(short id = 0)
        {
            var Locations = repoDDL.GetLocationsByDistrictIdForDDL(id);

            return Json(new SelectList(Locations.ToArray(), "LocationRowID", "LocationName"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPinCodeByLocationId(int id = 0)
        {
            if (id > 0)
            {
                int pinCode = repoLocation.GetLocationForUpdateById(id).PinCode;
                return Json(pinCode, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindDesignation(short id = 0)
        {
            var Designations = repoDDL.GetDesignationsForDDL(id);

            return Json(new SelectList(Designations.ToArray(), "DesignationRowID", "DesignationName"), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ********** Export To Excel **********

        public void ExportToExcel<T>(IEnumerable<T> list, string strFileName)
        {
            // Step 1 - get the data from database
            var data = list.ToList();

            // instantiate the GridView control from System.Web.UI.WebControls namespace
            // set the data source
            GridView gridview = new GridView();
            gridview.DataSource = data;
            gridview.DataBind();

            // Clear all the content from the current response
            Response.ClearContent();
            Response.Buffer = true;

            // set the header
            Response.AddHeader("content-disposition", "attachment;filename=" + strFileName + ".xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            clsExportDataToExcel.WriteHtmlTable(data, Response.Output);

            Response.Flush();
            Response.End();
        }

        #endregion
    }
}