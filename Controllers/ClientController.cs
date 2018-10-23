using BAL;
using BAL.CandidateRepository;
using BAL.ClientRepository;
using BAL.HRRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ViewModels;
using ViewModels.CandidateViewModel;
using ViewModels.ClientViewModel;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class ClientController : Controller
    {
        #region ********** Repository Object **********

        IAbbreviationRepository repoAbbreviation;
        IClientSubGroupRepository repoCliSubGroup;
        IDropDownMasterRepository repoDDL;
        IPQClientRepository repoPQClient;
        ILocationRepository repoLocation;
        IClientContractUploadRepository repoFileUplod;
        IClientSeverityRepository repoClientSeverity;
        ICheckFamilyRepository repoCheckFamily;
        ISubCheckFamilyRepository repoSubCheckFamily;
        IClientPackageRepository repoClientPackage;
        IClientCheckRepository repoClientCheck;
        IAntecedentRepository repoAntecedent;
        IClientAntecedentFieldRepository repoCAntecedentField;
        IClientLoginRepository repoLogin;
        IBranchOfficeRepository repoBranch;
        IClientDispositionRepository repoClientDisposition;
        IDispositionRepository repoDisposition;
        IPQClientHolidayRepository repoClientHoliday;
        IHolidayRepository repoHoliday;
        IPQClientTMemberRepository repoClientTMember;
        IPQCandidateLoginRepository repoCandidate;
        ITeamMemberRepository repoTeamMember;
        ITeamDepartmentRepository repoTeamDepartment;
        IClientCompletedContractRepository repoCliCompletedContract;

        public ClientController(
            IAbbreviationRepository _repoAbbreviation
            , IClientSubGroupRepository _repoCliSubGroup
            , IDropDownMasterRepository _repoDDL
            , IPQClientRepository _repoPQClient
            , ILocationRepository _repoLocation
            , IClientContractUploadRepository _repoFileUplod
            , IClientSeverityRepository _repoClientSeverity
            , ICheckFamilyRepository _repoCheckFamily
            , ISubCheckFamilyRepository _repoSubCheckFamily
            , IClientPackageRepository _repoClientPackage
            , IClientCheckRepository _repoClientCheck
            , IAntecedentRepository _repoAntecedent
            , IClientAntecedentFieldRepository _repoCAntecedentField
            , IClientLoginRepository _repoLogin
            , IBranchOfficeRepository _repoBranch
            , IClientDispositionRepository _repoClientDisposition
            , IDispositionRepository _repoDisposition
            , IPQClientHolidayRepository _repoClientHoliday
            , IHolidayRepository _repoHoliday
            , IPQClientTMemberRepository _repoClientTMember
            , ITeamMemberRepository _repoTeamMember
            , IPQCandidateLoginRepository _repoCandidate
            , ITeamDepartmentRepository _repoTeamDepartment
            , IClientCompletedContractRepository _repoCliCompletedContract
            )
        {
            repoAbbreviation = _repoAbbreviation;
            repoCliSubGroup = _repoCliSubGroup;
            repoDDL = _repoDDL;
            repoPQClient = _repoPQClient;
            repoLocation = _repoLocation;
            repoFileUplod = _repoFileUplod;
            repoClientSeverity = _repoClientSeverity;
            repoCheckFamily = _repoCheckFamily;
            repoSubCheckFamily = _repoSubCheckFamily;
            repoClientPackage = _repoClientPackage;
            repoClientCheck = _repoClientCheck;
            repoAntecedent = _repoAntecedent;
            repoCAntecedentField = _repoCAntecedentField;
            repoLogin = _repoLogin;
            repoBranch = _repoBranch;
            repoClientDisposition = _repoClientDisposition;
            repoDisposition = _repoDisposition;
            repoClientHoliday = _repoClientHoliday;
            repoHoliday = _repoHoliday;
            repoClientTMember = _repoClientTMember;
            repoCandidate = _repoCandidate;
            repoTeamMember = _repoTeamMember;
            repoTeamDepartment = _repoTeamDepartment;
            repoCliCompletedContract = _repoCliCompletedContract;
        }

        #endregion
        // GET: Client
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            return View();
        }

        #region ****** Abbreviation ******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddAbbreviation()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddAbbreviation(AddAbbreviationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ClientAbbreviation != null && model.ClientName != null && model.ClientAbbreviation.Trim().Length >= 3 && model.ClientName.Trim().Length > 0)
                    {
                        if (!repoAbbreviation.IsAbbreviationExist(model.ClientName.Trim()))
                        {
                            repoAbbreviation.AddAbbreviation(model);
                            int Res = repoAbbreviation.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageAbbreviation");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Client Name could not be blank!");
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
        public ActionResult EditAbbreviation(short id = 0)
        {
            UpdateAbbreviationViewModel model = new UpdateAbbreviationViewModel();
            try
            {
                model = repoAbbreviation.GetAbbreviationForUpdateById(id);
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
        public ActionResult EditAbbreviation(UpdateAbbreviationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ClientAbbreviation != null && model.ClientName != null && model.ClientAbbreviation.Trim().Length >= 3 && model.ClientName.Trim().Length > 0)
                    {
                        if (!repoAbbreviation.IsAbbreviationExist(model.ClientName, model.ClientAbbreviation, model.ClientAbbRowID
                            ))
                        {
                            repoAbbreviation.UpdateAbbreviation(model);
                            int Res = repoAbbreviation.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageAbbreviation");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Client Name could not be blank!");
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
        public JsonResult DeleteAbbreviation(byte id)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoAbbreviation.DeleteAbbreviation(id);
                    int Res = repoAbbreviation.SaveChanges();
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
        public ActionResult ManageAbbreviation(int page = 1, string sort = "ClientName", string sortDir = "asc", string Search = "")
        {
            AbbreviationListPagedModel model = new AbbreviationListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoAbbreviation.GetAbbreviations(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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

        public void ExportAbbreviation()
        {
            try
            {
                var exportData = repoAbbreviation.GetAbbreviationForExports();

                WebGrid grid = new WebGrid(source: exportData, canPage: false, canSort: false);
                string gridData = grid.GetHtml(
                    columns: grid.Columns(
                            grid.Column(header: "No.", format: item => item.WebGrid.Rows.IndexOf(item) + 1 + Math.Round(Convert.ToDouble(grid.TotalRowCount / grid.PageCount) / grid.RowsPerPage) * grid.RowsPerPage * grid.PageIndex),
                            grid.Column(columnName: "ClientName", header: "Client"),
                            grid.Column(columnName: "ClientAbbreviation", header: "Abbreviation")
                            )
                        ).ToString();

                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=Abbreviations" + DateTime.Now.ToString("ddMMyyyy") + ".xls");
                Response.ContentType = "application/excel";
                Response.Write(gridData);
                Response.End();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ****** Client SubGroup ******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddSubGroup()
        {
            try
            {

                BindClient();

            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddSubGroup(AddClientSubGroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.SubGroupName != null && model.SubGroupName.Trim().Length > 0)
                    {
                        if (!repoCliSubGroup.IsClientSubGroupExist(model.SubGroupName.Trim(), model.ClientAbbRowID))
                        {
                            repoCliSubGroup.AddClientSubGroup(model);

                            int Res = repoCliSubGroup.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageSubGroup");
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", " Sub Group could not be blank!");
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
            BindClient();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditSubGroup(short id = 0)
        {
            UpdateClientSubGroupViewModel model = new UpdateClientSubGroupViewModel();
            try
            {
                BindClient();
                model = repoCliSubGroup.GetClientSubGroupForUpdateById(id);

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
        public ActionResult EditSubGroup(UpdateClientSubGroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.SubGroupName != null && model.SubGroupName.Trim().Length > 0 && model.ClientSubGroupID > 0)
                    {
                        if (!repoCliSubGroup.IsClientSubGroupExist(model.SubGroupName.Trim(), model.ClientAbbRowID))
                        {
                            repoCliSubGroup.UpdateClientSubGroup(model);
                            int Res = repoCliSubGroup.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageSubGroup");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sub Group Name could not be blank!");
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
            BindClient();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DeleteSubGroup(short id)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoCliSubGroup.DeleteClientSubGroup(id);
                    int Res = repoCliSubGroup.SaveChanges();
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
        public ActionResult ManageSubGroup(int page = 1, string sort = "SubGroupName", string sortDir = "asc", string Search = "")
        {
            ClientSubGroupListPagedModel model = new ClientSubGroupListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoCliSubGroup.GetClientSubGroups(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public void ExportSubGroup()
        {
            try
            {
                var data = repoCliSubGroup.GetClientSubGroupForExport();
                ExportToExcel(data, "SubGroup");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }
        #endregion

        #region ****** PQClient Details ******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddPQClient()
        {
            BindCountry();
            BindClientAbbList();
            BindClientSpocList();
            BindYesNoList();
            BindReportSentByList();
            BindPricingTypeList();
            BindSeverityTypeList();
            BindBranchOfficeList();
            BindBillingCycleList();
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddPQClient(AddPQClientViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ClientAbbRowID > 0 && model.ClientSubgroupID > 0)
                    {
                        bool SpocEmailID = false;
                        if (!string.IsNullOrEmpty(model.SpocEmailID))
                        {
                            var SpocEmailIds = model.SpocEmailID.Split(',');
                            foreach (string email in SpocEmailIds)
                            {
                                if (!clsValidationMethods.IsValidEmail(email))
                                {
                                    SpocEmailID = true;
                                }
                            }
                        }
                        if (!SpocEmailID)
                        {
                            string strClientAbbName = repoPQClient.GetClientAbbName(model.ClientAbbRowID);
                            string SubGroupName = repoPQClient.GetSubGroupName(model.ClientSubgroupID);
                            string strClientCode = strClientAbbName + "-" + SubGroupName + "-" + model.DistrictRowID.ToString() + "-" + model.LocationRowID.ToString();

                            model.ClientCode = strClientCode;
                            model.ClientCode1 = strClientAbbName;
                            model.Status = 1;
                            model.CreatedDate = DateTime.Now;
                            model.SLAUploaded = 0;
                            model.AgreementType = 1;

                            if (!repoPQClient.IsPQClientData(model.ClientCode, model.ClientSubgroupID))
                            {
                                repoPQClient.AddPQClient(model);
                                int Res = repoPQClient.SaveChanges();
                                if (Res > 0)
                                {
                                    repoPQClient.AddClientSevirityDetails(model.ClientCode, model.ClientSubgroupID);

                                    if (model.MapHolidays == 0)
                                    {
                                        repoPQClient.AddClientDefaultHolidays(model.ClientCode, model.ClientSubgroupID);
                                    }

                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManagePQClient");
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                                }
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Client Already Exists.Choose Another one!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Please enter correct email!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "All * fields are mandatory!");
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
            BindClientAbbList();
            BindClientSpocList();
            BindYesNoList();
            BindReportSentByList();
            BindPricingTypeList();
            BindSeverityTypeList();
            BindBranchOfficeList();
            BindBillingCycleList();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult ManagePQClient(int page = 1, string sort = "CreatedDate", string sortDir = "desc", string Search = "")
        {
            PQClientListPagedModel model = new PQClientListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoPQClient.GetPQClient(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }

                Session["ClientNameForContract"] = null;
                Session["PricingType"] = null;
                Session["MapAntecedent"] = null;
                Session["MapDisposition"] = null;
                Session["MapSeverity"] = null;
                Session["MailSendBy"] = null;
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
        public ActionResult EditPQClient(short id = 0)
        {
            UpdatePQClientViewModel model = new UpdatePQClientViewModel();
            try
            {
                BindCountry();
                BindClientAbbList();
                BindClientSpocList();
                BindYesNoList();
                BindReportSentByList();
                BindPricingTypeList();
                BindSeverityTypeList();
                BindBranchOfficeList();
                BindBillingCycleList();
                model = repoPQClient.GetPQClientForUpdateById(id);
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
        public ActionResult EditPQClient(UpdatePQClientViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ClientRowID > 0)
                    {
                        repoPQClient.UpdatePQClient(model);
                        int Res = repoPQClient.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Edited Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManagePQClient");
                        }
                        else
                        {
                            model = repoPQClient.GetPQClientForUpdateById(model.ClientRowID);
                            ViewBag.ErrorMsg = "There is no change!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Record Already Exist!");
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
            BindClientAbbList();
            BindClientSpocList();
            BindYesNoList();
            BindReportSentByList();
            BindPricingTypeList();
            BindSeverityTypeList();
            BindBranchOfficeList();
            BindBillingCycleList();
            return View(model);
        }

        public ActionResult ClientMail(short CId = 0)
        {
            PQClientMailConfig model = new PQClientMailConfig();
            try
            {
                model = repoPQClient.GetClientMailById(CId);
                if (model != null)
                {
                    model.SMTPPassword = clsCommonMethods.PasswordDecrypt(model.SMTPPassword.Trim());
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult ClientMail(PQClientMailConfig model, short CId = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ClientRowID = CId;
                    if (model.ClientRowID > 0)
                    {
                        model.SMTPPassword = clsCommonMethods.PasswordEncrypt(model.SMTPPassword.Trim());
                        repoPQClient.PQClientMailConfig(model);
                        int Res = repoPQClient.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Edited Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManagePQClient");
                        }
                        else
                        {
                            // model = repoPQClient.GetPQClientForUpdateById(model.ClientRowID);
                            ViewBag.ErrorMsg = "There is no change!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Record Already Exist!");
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
        public void ExportClient()
        {
            try
            {
                var data = repoPQClient.GetClientForExport();
                ExportToExcel(data, "MasterClient");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }
        #endregion

        #region ****** Manage Packege ******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult CreateClientPackage(short CId = 0)
        {
            AddClientPackageViewModel model = new AddClientPackageViewModel();
            try
            {
                model.ClientRowID = CId;
                var clientDetails = repoPQClient.GetClientSelectedAntAndDisposition(CId);
                model.AntecedentSelected = clientDetails.MapAntecedent;
                model.DispositionSelected = clientDetails.MapDisposition;
                BindPackagesList();
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
        public ActionResult CreateClientPackage(FormCollection form, AddClientPackageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(model.ClientPackageName))
                    {
                        short ClAbbRowId = repoPQClient.GetPQClientForUpdateById(model.ClientRowID).ClientAbbRowID;
                        string abbName = repoAbbreviation.GetAbbreviationForUpdateById(ClAbbRowId).ClientAbbreviation;
                        if (!string.IsNullOrEmpty(abbName))
                        {
                            model.ClientPackageName = abbName + "_" + model.ClientPackageName;
                        }
                        byte AntecedentSelected = model.AntecedentSelected;
                        if (!string.IsNullOrEmpty(model.SubCheckID))
                        {
                            if (!repoClientPackage.IsPackageExist(model.ClientPackageName))
                            {
                                int Res = 0;
                                string saveOrNot = "NotSave";
                                string[] SubCheckID = model.SubCheckID.Split(',');
                                //string[] CheckFamilyID = model.CheckFamilyID.Split(',');
                                foreach (var data in SubCheckID)
                                {
                                    string[] arr1 = data.Split('_');
                                    string id2 = "txtClTat_" + data;
                                    string id3 = "txtIntTat_" + data;
                                    string id4 = "txtBprChk_" + data;
                                    string id6 = "ddlSelSeq_" + arr1[0];
                                    string id7 = "txtCprChk_" + data;

                                    model.CheckFamilyRowID = Convert.ToInt16(arr1[0]);
                                    model.SubCheckRowID = Convert.ToInt16(arr1[1]);
                                    if (!string.IsNullOrEmpty(form[id4]))
                                    {
                                        model.TAT = Convert.ToByte(form[id2]);
                                        model.InternalTAT = Convert.ToByte(form[id3]);
                                        model.BillingPerCheck = Convert.ToDouble(form[id4]);
                                        model.ReportSequence = Convert.ToByte(form[id6]);
                                        model.CostPerCheck = Convert.ToDouble(form[id7]);

                                        model.AntecedentSelected = AntecedentSelected == 0 ? Convert.ToByte(1) : Convert.ToByte(0);

                                        repoClientPackage.AddClientPackage(model);
                                        Res = repoClientPackage.SaveChange();

                                        //If set antecedent select Default then save with client checks
                                        if (Res > 0 && AntecedentSelected == 0)
                                        {
                                            AddClientFieldViewModel antModel = new AddClientFieldViewModel();
                                            antModel.ClientRowID = model.ClientRowID;
                                            antModel.CheckFamilyRowID = model.CheckFamilyRowID;
                                            antModel.SubCheckRowID = model.SubCheckRowID;
                                            repoCAntecedentField.AddPQClientAntecedentsDefaultSelected(antModel);
                                        }

                                        if (Res > 0 && model.DispositionSelected == 0)
                                        {
                                            AddClientDispositionViewModel dispModel = new AddClientDispositionViewModel();
                                            dispModel.ClientRowID = model.ClientRowID;
                                            dispModel.CheckFamilyRowID = model.CheckFamilyRowID;
                                            repoClientDisposition.AddClientDispositionDefaultSelected(dispModel);
                                        }

                                        saveOrNot = "Save";
                                    }
                                    else
                                    {
                                        ViewBag.ErrorMsg = "All fields are mandatory.";
                                    }
                                }
                                if (saveOrNot == "Save")
                                {
                                    if (Res > 0)
                                    {
                                        TempData["SuccessMsg"] = "Record Added Successfully!";
                                        ModelState.Clear();
                                        return RedirectToAction("ManagePackages", new { CId = model.ClientRowID });
                                    }
                                    else
                                    {
                                        ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                                    }
                                }
                                else
                                {
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManagePackages", new { CId = model.ClientRowID });
                                }
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Package Name Already Exist!";
                            }
                        }
                        else
                        {
                            TempData["ErrorMsg"] = "There is some problem to save record. Please try again later!";
                            ModelState.Clear();
                            return RedirectToAction("ManagePackages", new { CId = model.ClientRowID });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Package Name could not be blank!");
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
            //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == model.ClientRowID).Select(p => p.ClientName).FirstOrDefault();
            PackageDetails();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult ManagePackages(int page = 1, string sort = "PackageName", string sortDir = "asc", string Search = "", short CId = 0)
        {
            ClientPackageListPagedModel model = new ClientPackageListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                model = repoClientPackage.GetClientPackages(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CId);
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
        public ActionResult RefreshPackageDetails(string PackageName = "")
        {
            try
            {
                PackageDetails(PackageName);
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return PartialView("_PackageCheckSubcheck");
        }

        [SessionExpireFilterAttribute]
        public void PackageDetails(string PackageName = "")
        {
            try
            {
                var chkList = repoCheckFamily.GetCheckFamily();
                var subChklist = repoSubCheckFamily.GetSubCheckFamily();
                var pkgChk = repoClientPackage.GetPackageDetailsByPackageName(PackageName);
                List<PkgCheckFamilyViewModel> pkgChkList = new List<PkgCheckFamilyViewModel>();
                List<pkgSubCheckFamilyViewModel> pkgSubChkList = new List<pkgSubCheckFamilyViewModel>();
                byte count = 1;
                foreach (var item in chkList)
                {
                    PkgCheckFamilyViewModel chk = new PkgCheckFamilyViewModel();
                    chk.CheckFamilyRowID = item.CheckFamilyRowID;
                    chk.CheckFamilyName = item.CheckFamilyName;
                    chk.PkgChkRepoSequence = count++;
                    foreach (var item1 in subChklist.Where(a => a.CheckFamilyRowID == item.CheckFamilyRowID))
                    {
                        if (item.CheckFamilyRowID == item1.CheckFamilyRowID)
                        {
                            pkgSubCheckFamilyViewModel subChk = new pkgSubCheckFamilyViewModel();
                            subChk.SubCheckFamilyRowID = item1.SubCheckFamilyRowID;
                            subChk.SubCheckName = item1.SubCheckName;
                            subChk.CheckFamilyRowID = item1.CheckFamilyRowID;

                            subChk.SubChkPkg = false;
                            subChk.SubCheckName = item1.SubCheckName;
                            subChk.CostParCase = item1.CostParCase;
                            subChk.InternalTAT = item1.InternalTAT;
                            subChk.TAT = item1.TAT;
                            subChk.BillingPerCase = 0;
                            subChk.NoofEntries = 0;
                            if (pkgChk.Count() > 0)
                            {
                                foreach (var item3 in pkgChk.Where(a => a.CheckFamilyRowID == item.CheckFamilyRowID && a.SubCheckRowID == item1.SubCheckFamilyRowID))
                                {
                                    if (item1.SubCheckFamilyRowID == item3.SubCheckRowID)
                                    {
                                        subChk.SubChkPkg = true;
                                        subChk.CostParCase = item3.CostPerCheck;
                                        subChk.InternalTAT = item3.InternalTAT;
                                        subChk.TAT = item3.TAT;
                                        subChk.BillingPerCase = item3.BillingPerCheck;
                                        subChk.ReportSequence = item3.ReportSequence;
                                    }
                                    if (item.CheckFamilyRowID == item3.CheckFamilyRowID)
                                    {
                                        chk.PkgChk = true;
                                        chk.PkgChkRepoSequence = item3.ReportSequence;
                                    }
                                    else
                                    {
                                        chk.PkgChk = false;
                                    }
                                }
                            }
                            pkgSubChkList.Add(subChk);
                        }
                    }
                    pkgChkList.Add(chk);
                }
                ViewBag.CheckFamilyList = pkgChkList;
                ViewBag.SubCheckFamilyList = pkgSubChkList;
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportClientPackage(short CId = 0)
        {
            try
            {
                var data = repoPQClient.GetClientPackageForExport(CId);
                ExportToExcel(data, "MasterClient");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }
        #endregion

        #region ****** Manage Client Checks ******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult CreateClientChecks(short CId = 0)
        {
            AddClientCheckViewModel model = new AddClientCheckViewModel();
            try
            {
                model.ClientRowID = CId;
                var clientDetails = repoPQClient.GetClientSelectedAntAndDisposition(CId);
                model.AntecedentSelected = clientDetails.MapAntecedent;
                model.DispositionSelected = clientDetails.MapDisposition;
                BindCheckFamily();
                BindSubCheckFamily();
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
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
        public ActionResult CreateClientChecks(FormCollection form, AddClientCheckViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int Res = 0;
                    string saveOrNot = "NotSave";
                    byte AntecedentSelected = model.AntecedentSelected;
                    if (!string.IsNullOrEmpty(model.SubCheckID))
                    {
                        string[] SubCheckID = model.SubCheckID.Split(',');
                        //string[] CheckFamilyID = model.CheckFamilyID.Split(',');
                        foreach (var data in SubCheckID)
                        {
                            string[] arr1 = data.Split('_');
                            string id2 = "txtClTat_" + data;
                            string id3 = "txtIntTat_" + data;
                            string id4 = "txtBprChk_" + data;
                            string id6 = "ddlSelSeq_" + arr1[0];
                            string id7 = "txtCprChk_" + data;

                            model.CheckFamilyRowID = Convert.ToInt16(arr1[0]);
                            model.SubCheckRowID = Convert.ToInt16(arr1[1]);
                            if (!repoClientCheck.IsExistSubCheck(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID))
                            {
                                if (!string.IsNullOrEmpty(form[id4]))
                                {
                                    model.TAT = Convert.ToByte(form[id2]);
                                    model.InternalTAT = Convert.ToByte(form[id3]);
                                    model.BillingPerCheck = Convert.ToDouble(form[id4]);
                                    model.ReportSequence = Convert.ToByte(form[id6]);
                                    model.CostPerCheck = Convert.ToDouble(form[id7]);

                                    model.AntecedentSelected = AntecedentSelected == 0 ? Convert.ToByte(1) : Convert.ToByte(0);

                                    repoClientCheck.AddClientCheck(model);
                                    Res = repoClientCheck.SaveChange();

                                    //If set antecedent select Default then save with client checks
                                    if (Res > 0 && AntecedentSelected == 0)
                                    {
                                        AddClientFieldViewModel antModel = new AddClientFieldViewModel();
                                        antModel.ClientRowID = model.ClientRowID;
                                        antModel.CheckFamilyRowID = model.CheckFamilyRowID;
                                        antModel.SubCheckRowID = model.SubCheckRowID;
                                        repoCAntecedentField.AddPQClientAntecedentsDefaultSelected(antModel);
                                    }

                                    if (Res > 0 && model.DispositionSelected == 0)
                                    {
                                        AddClientDispositionViewModel antModel = new AddClientDispositionViewModel();
                                        antModel.ClientRowID = model.ClientRowID;
                                        antModel.CheckFamilyRowID = model.CheckFamilyRowID;
                                        repoClientDisposition.AddClientDispositionDefaultSelected(antModel);
                                    }

                                    saveOrNot = "Save";
                                }
                            }
                        }
                    }
                    if (saveOrNot == "Save")
                    {
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageClientChecks", new { CId = model.ClientRowID });
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                        }
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "There is some problem to save record. Please try again later!";
                        ModelState.Clear();
                        return RedirectToAction("ManageClientChecks", new { CId = model.ClientRowID });
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
            BindCheckFamily();
            BindSubCheckFamily();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult ManageClientChecks(int page = 1, string sort = "CheckFamily", string sortDir = "asc", short CId = 0)
        {
            ClientCheckListPagedModel model = new ClientCheckListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                model = repoClientCheck.GetClientChecks(page, pageSize, sort.ToLower(), sortDir.ToLower(), CId);
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
        public void ExportClientChecks(short CId = 0)
        {
            try
            {
                var data = repoPQClient.GetClientChecksForExport(CId);
                ExportToExcel(data, "MasterClient");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ****** Manage Client Contract Agreement Upload ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageClientContract(int page = 1, string sort = "fileName", string sortDir = "asc", string Search = "", short CId = 0)
        {
            CContractAgreementListPageModel model = new CContractAgreementListPageModel();
            BindComletedContract(CId);
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoFileUplod.GetFileUpload(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CId);
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

            if (Session["ClientNameForContract"] == null || Session["ClientNameForContract"].ToString().Trim().Length == 0)
            {
                var ContractConditions = repoPQClient.GetClientContractConditions(CId);
                Session["ClientNameForContract"] = ContractConditions.ClientName;
                Session["PricingType"] = ContractConditions.PricingType;
                Session["MapAntecedent"] = ContractConditions.MapAntecedent;
                Session["MapDisposition"] = ContractConditions.MapDisposition;
                Session["MapSeverity"] = ContractConditions.MapSeverity;
                Session["MapHoliDays"] = ContractConditions.MapHolidays;
                Session["MailSendBy"] = ContractConditions.MailSendBy;
            }

            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult AddClientContract(short CId = 0)
        {
            if (CId == 0)
            {
                return RedirectToAction("ManagePQClient");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddClientContract(AddCContractAgreementViewModel model, short CId = 0)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (!repoFileUplod.IsFileUploadExist((CId + " " + model.UplodFileName.FileName).Replace(" ", "_").Replace("-", "_").Trim().ToLower(), model.ClientRowID = CId))
                    {
                        #region*************Image Upload************
                        string FldPathDoc = ConfigurationManager.AppSettings["ClientDocs"].ToString();
                        string proImg = string.Empty;
                        if (model.UplodFileName.FileName.ToString() != "")
                        {
                            bool exists = Directory.Exists(Server.MapPath(FldPathDoc));
                            if (!exists)
                                Directory.CreateDirectory(Server.MapPath(FldPathDoc));

                            //string ext = Path.GetExtension(model.UplodFileName.FileName).ToLower();
                            proImg = (CId + " " + model.UplodFileName.FileName).Replace(" ", "_").Replace("-", "_");
                            model.UplodFileName.SaveAs(Server.MapPath(FldPathDoc + proImg));
                            model.FileName = Path.GetFileName(proImg);
                        }
                        #endregion
                        //model.DocumentType = "Verification Contract Agreement";
                        model.Uploaddate = DateTime.Now;
                        model.ClientRowID = CId;
                        model.DocumentUploadFrom = "Contract Agreement";
                        byte SLAUpload = 1;
                        repoFileUplod.AddFileUpload(model);
                        repoFileUplod.UpdateSLAUpload(model.ClientRowID, SLAUpload);
                        int Res = repoFileUplod.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageClientContract", new { CId });
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is no change!";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Record Already Exist!";
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
        public JsonResult ClientContractActive(short id = 0, string checkeds = "")
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
                    repoFileUplod.ActiveContractUpload(id, checkeds);
                    int Res = repoFileUplod.SaveChanges();
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
        public void ExportClientContract(short CId = 0)
        {
            try
            {
                var data = repoFileUplod.GetClientContractForExport(CId);
                ExportToExcel(data, "ClientContract");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ****** Client Severity ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageClientSeverity(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short CId = 0)
        {

            ClientSeverityListPagedModel model = new ClientSeverityListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                model = repoClientSeverity.GetClientSeverities(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CId);

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

        [SessionExpireFilterAttribute]
        public ActionResult EditClientSeverity(short id = 0, short CId = 0)
        {
            UpdateClientSeverityViewModel model = new UpdateClientSeverityViewModel();
            try
            {
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                model = repoClientSeverity.GetClientSeverityForUpdateById(id);
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
        public ActionResult EditClientSeverity(UpdateClientSeverityViewModel model, short CId = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.ClientColorCode.Trim().Length > 0 && model.ClientSeverityRowId > 0)
                    {
                        repoClientSeverity.UpdateClientSeverity(model);
                        int Res = repoClientSeverity.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Edited Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageClientSeverity", new { CId });
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is no change!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Client Severity could not be blank!");
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

        #endregion

        #region ****** Client Antecedent ******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult SetClientAntecedents(int id = 0, short CId = 0, short ChkId = 0, short SChKId = 0, short CPId = 0)
        {
            AddClientFieldViewModel model = new AddClientFieldViewModel();
            try
            {
                model.Id = id;
                model.ClientRowID = CId;
                model.CheckFamilyRowID = ChkId;
                model.SubCheckRowID = SChKId;
                model.PackageRowID = CPId;
                ViewBag.ListOfAntecedent = repoCAntecedentField.GetAntecedents(ChkId);
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                var AntcdntIds = repoCAntecedentField.GetClientAntecedents(CId, ChkId, SChKId);
                if (AntcdntIds != null && AntcdntIds.Count() > 0)
                {
                    foreach (var item in AntcdntIds)
                    {
                        if (item.AntecedentRowId > 0)
                        {
                            model.AntecedentRowIds += Convert.ToString(item.AntecedentRowId) + ",";
                        }
                    }

                    if (model.AntecedentRowIds.Length > 0)
                    {
                        model.AntecedentRowIds = model.AntecedentRowIds.Substring(0, model.AntecedentRowIds.Length - 1);
                    }
                    else
                    {
                        model.AntecedentRowIds = "";
                    }
                }
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
        public ActionResult SetClientAntecedents(FormCollection form, AddClientFieldViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.AntecedentRowIds))
                        model.AntecedentRowIds = null;
                    int Res = 0;
                    string selected = model.AntecedentRowIds;
                    string[] selectedList = selected.Split(',');
                    foreach (var item in selectedList)
                    {
                        model.AntecedentRowId = Int16.Parse(item);
                        string id = "txtAnt_" + item;
                        model.CADisplayName = Convert.ToString(form[id]);
                        if (!repoCAntecedentField.IsPQClientAntecedentsExist(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.AntecedentRowId))
                        {
                            repoCAntecedentField.AddPQClientAntecedentsField(model);
                            Res = repoCAntecedentField.SaveChanges();
                        }
                        else
                        {
                            repoCAntecedentField.UpdatePQClientAntecedentsField(model);
                            Res = repoCAntecedentField.SaveChanges();
                        }
                    }
                    //if (Res > 0)
                    //{
                    if (model.PackageRowID > 0)
                    {
                        repoClientPackage.UpdateAntecedentPackage(model.Id);
                        repoClientPackage.SaveChange();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("ManagePackages", new { CId = model.ClientRowID });
                    }
                    else
                    {
                        repoClientCheck.UpdateAntecedentCheck(model.Id);
                        repoClientCheck.SaveChange();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("ManageClientChecks", new { CId = model.ClientRowID });
                    }
                    //}
                    //else
                    //{
                    //    ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                    //}
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
            BindCheckFamily();
            BindSubCheckFamily();
            return View(model);
        }

        #endregion

        #region ****** Client Disposition *******

        [SessionExpireFilterAttribute]
        public ActionResult ManageClientCheckDispositions(int page = 1, string sort = "Disposition", string sortDir = "asc", string Search = "", short CId = 0)
        {
            ClientCheckFamilyListPagedModel model = new ClientCheckFamilyListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoClientDisposition.GetClientCheckFamily(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CId);
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

        [SessionExpireFilterAttribute]
        public ActionResult ManageClientDispositions(int page = 1, string sort = "Disposition", string sortDir = "asc", string Search = "", short CId = 0, short ChkId = 0)
        {
            ClientDispositionListPagedModel model = new ClientDispositionListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoClientDisposition.GetClientDispositions(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CId, ChkId);
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
        public ActionResult SelectClientDispositions(short CId = 0, short ChkId = 0)
        {
            AddClientDispositionViewModel model = new AddClientDispositionViewModel();
            try
            {
                model.ClientRowID = CId;
                model.CheckFamilyRowID = ChkId;
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                ViewBag.CheckFamilyName = repoCheckFamily.GetCheckFamilyForUpdateById(ChkId).CheckFamilyName;
                ViewBag.DispositionList = repoDisposition.GetDispositionAutoComplete("", ChkId);

                var DispositionIds = repoClientDisposition.GetClientDispositions(CId, ChkId);
                if (DispositionIds != null && DispositionIds.Count() > 0)
                {
                    foreach (var item in DispositionIds)
                    {
                        if (item.DispositionRowId > 0)
                        {
                            model.DispositionIds += Convert.ToString(item.DispositionRowId + "_" + item.SeverityGridRowId) + ",";
                        }
                    }

                    if (model.DispositionIds.Length > 0)
                    {
                        model.DispositionIds = model.DispositionIds.Substring(0, model.DispositionIds.Length - 1);
                    }
                    else
                    {
                        model.DispositionIds = "";
                    }
                }
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
        public ActionResult SelectClientDispositions(AddClientDispositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool saveOrNot = false;
                    if (string.IsNullOrEmpty(model.DispositionIds))
                        model.DispositionIds = null;
                    int Res = 0;
                    string[] selectedList = model.DispositionIds.Split(',');
                    foreach (var item in selectedList)
                    {
                        string[] selectedIds = item.Split('_');

                        model.DispositionRowId = Int16.Parse(selectedIds[0]);
                        model.SeverityGridRowId = Convert.ToByte(selectedIds[1]);
                        if (!repoClientDisposition.IsClientDispositionExist(model.ClientRowID, model.CheckFamilyRowID, model.DispositionRowId))
                        {
                            saveOrNot = true;
                            repoClientDisposition.AddClientDisposition(model);
                            Res = repoClientDisposition.SaveChanges();
                        }
                    }
                    if (saveOrNot)
                    {
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            short CId = model.ClientRowID;
                            short ChkId = model.CheckFamilyRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageClientDispositions", new { CId = CId, ChkId = ChkId });
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                        }
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
            //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == model.ClientRowID).Select(p => p.ClientName).FirstOrDefault();
            ViewBag.CheckFamilyName = repoCheckFamily.GetCheckFamilyForUpdateById(model.CheckFamilyRowID).CheckFamilyName;
            ViewBag.DispositionList = repoDisposition.GetDispositionAutoComplete("", model.CheckFamilyRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageClientDispositionSeverity(int id = 0, short CId = 0, short ChkId = 0)
        {
            UpdateClientDispositionViewModel model = new UpdateClientDispositionViewModel();
            try
            {
                BindCheckFamily();
                BindSeverityGrid();
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                model = repoClientDisposition.GetClientDispoSeverityForUpdateById(id);
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

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult ManageClientDispositionSeverity(UpdateClientDispositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ClientDispositionRowId > 0)
                    {
                        repoClientDisposition.UpdateDispoClientSeverity(model);
                        int Res = repoClientDisposition.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Edited Successfully!";
                            short CId = model.ClientRowID;
                            short ChkId = model.CheckFamilyRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageClientDispositions", new { CId = CId, ChkId = ChkId });
                        }
                        else
                        {
                            model = repoClientDisposition.GetClientDispoSeverityForUpdateById(model.ClientDispositionRowId);
                            ViewBag.ErrorMsg = "There is no change!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Id!");
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
            BindCheckFamily();
            BindSeverityGrid();
            //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == model.ClientRowID).Select(p => p.ClientName).FirstOrDefault();
            model = repoClientDisposition.GetClientDispoSeverityForUpdateById(model.ClientDispositionRowId);
            return View(model);
        }

        #endregion

        #region ****** ClientLogin ******

        [SessionExpireFilterAttribute]
        public ActionResult AddClientLogin()
        {
            try
            {
                BindClientNameSubGrup();
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
        public ActionResult AddClientLogin(AddPQClientLoginViewModel model)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.UserID != null && model.UserID.Trim().Length > 0)
                    {
                        if (!repoLogin.IsClientLoginExist(model.UserID.Trim()))
                        {
                            model.CreatedBy = "Company-Client";
                            model.CreatedTime = DateTime.Now;
                            model.Status = 1;
                            model.UType = 1.ToString();
                            string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(model.UPass.Trim());
                            model.UPass = EncryptedPasswd;
                            model.CreatedUserId = Convert.ToInt16(Session["TeamMemberRowID"]);
                            repoLogin.AddClientLogin(model);
                            int Res = repoLogin.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageClientLogin");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User ID Name could not be blank!");
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
            BindClientNameSubGrup();
            return View();
        }

        [SessionExpireFilterAttribute]
        public ActionResult ManageClientLogin(int page = 1, string sort = "createdtime", string sortDir = "desc", string Search = "")
        {
            PQClientUserListPagedModel model = new PQClientUserListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoLogin.GetClientUsers(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public void ExportClientLogin()
        {
            try
            {
                var data = repoPQClient.GetClientLoginForExport();
                ExportToExcel(data, "MasterClient");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }


        [SessionExpireFilterAttribute]
        public ActionResult EditClientLogin(short id = 0)
        {
            UpdatePQClientLoginViewModel model = new UpdatePQClientLoginViewModel();
            try
            {
                BindClientNameSubGrup();

                model = repoLogin.GetClientLoginForUpdateById(id);
                string EncryptedPasswd = clsCommonMethods.PasswordDecrypt(model.UPass.Trim());
                model.UPass = EncryptedPasswd;
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
        public ActionResult EditClientLogin(UpdatePQClientLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.UserID != null && model.UserID.Trim().Length > 0)
                    {
                        if (!repoLogin.IsClientLoginExist(model.UserID.Trim(), model.ClientUserRowID))
                        {
                            model.ModifiedTime = DateTime.Now;

                            string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(model.UPass.Trim());
                            model.UPass = EncryptedPasswd;
                            model.CreatedUserId = Convert.ToInt16(Session["TeamMemberRowID"]);
                            repoLogin.UpdateClientLogin(model);
                            int Res = repoLogin.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageClientLogin");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User ID Name could not be blank!");
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
            BindClientNameSubGrup();
            return View();
        }

        [SessionExpireFilterAttribute]
        public JsonResult DeleteClientLogin(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoLogin.DeleteClientLoginSubGroups(id);
                    int Res = repoLogin.SaveChanges();
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
        public JsonResult ActiveClientLogin(string checkeds = "", short id = 0)
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
                    repoLogin.ActiveClientLogin(id, checkeds);
                    int Res = repoLogin.SaveChanges();
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
        public JsonResult SendMailToClient(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    SendClientLoginInfoViewModel clientLoginInfo = repoLogin.GetClientLoginInfoforSendMail(id);
                    if (clientLoginInfo != null)
                    {
                        string body = string.Empty;
                        using (StreamReader reader = new StreamReader(Server.MapPath("~/Emailers/Company/LoginDetailsSendToClient.html")))
                        {
                            body = reader.ReadToEnd();
                        }

                        body = body.Replace("{ClientName}", clientLoginInfo.ClientSpocName);
                        body = body.Replace("{UName}", clientLoginInfo.UserID);
                        body = body.Replace("{UPasswd}", clsCommonMethods.PasswordDecrypt(clientLoginInfo.UPass.Trim()));
                        body = body.Replace("{ClientLoginUrl}", ConfigurationManager.AppSettings["ClientLoginUrl"].ToString());

                        clsSendMail mail = new clsSendMail();
                        var signature = mail.GetCompanyMailSignature();

                        string Subject = "BGV User ID And Password";
                        string To = clientLoginInfo.ClientSpocEmail;
                        string Cc = signature.GeneralEmail;
                        string From = signature.GeneralEmail;
                        string DisplayName = signature.CompanyName;
                        string MailSignature = string.Concat("For Securitas India. <br /><br />");

                        if (signature != null)
                        {
                            MailSignature = string.Concat(MailSignature, "<b>", signature.CompanyName, "</b><br /><b>Mobile: ", signature.MobileNo,
                                " | Direct Tel: ", signature.PhoneNo, " | Fax: ", signature.FaxNo, "</b><br /><b>E-mail id </b>: <a style='color:#df012a;' href='mailto:", signature.GeneralEmail, "'>", signature.GeneralEmail, "</a>");
                        }

                        body = body.Replace("{MailSignature}", MailSignature);

                        bool flag = mail.SendMail(DisplayName, From, To, Cc, Subject, body);
                        if (flag)
                        {
                            UpdateClientSendMailStatusViewModel model = new UpdateClientSendMailStatusViewModel();
                            model.ClientUserRowID = id;
                            model.SentMailStatus = 1;
                            model.SentMailDate = DateTime.Now;

                            repoLogin.UpdateClientSendMailStatus(model);
                            int Res = repoLogin.SaveChanges();
                            if (Res > 0)
                            {
                                result = true;
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Mail sending failed!";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Client login details not found!";
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

        #region ****** Candidate Login ******

        [SessionExpireFilterAttribute]
        public ActionResult AddCandidateLogin()
        {
            try
            {
                BindClientNameSubGrup();
                BindYTRApplicableList();
                BindTypeList();
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
        public ActionResult AddCandidateLogin(AddPQCandidateLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.UserID != null && model.UserID.Trim().Length > 0)
                    {
                        if (!repoCandidate.IsCandidateLoginExist(model.UserID.Trim(), model.CandidateEmail.Trim()))
                        {
                            model.CreatedBy = "Company-Candidate";
                            model.CreatedTime = DateTime.Now;
                            model.Status = 1;

                            string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(model.UPass.Trim());
                            model.UPass = EncryptedPasswd;
                            model.CreatedUserId = Convert.ToInt16(Session["TeamMemberRowID"]);

                            repoCandidate.AddCandidateLogin(model);
                            int Res = repoCandidate.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCandidateLogin");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User ID Name could not be blank!");
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
            BindClientNameSubGrup();
            BindYTRApplicableList();
            BindTypeList();
            return View();
        }

        [SessionExpireFilterAttribute]
        public ActionResult ManageCandidateLogin(int page = 1, string sort = "modifiedtime", string sortDir = "desc", string Search = "")
        {
            PQCandidateUserListPagedModel model = new PQCandidateUserListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                BindTypeList();
                model = repoCandidate.GetCandidateUsers(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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

        [SessionExpireFilterAttribute]
        public ActionResult EditCandidateLogin(short id = 0)
        {
            UpdatePQCandidateLoginViewModel model = new UpdatePQCandidateLoginViewModel();
            try
            {
                BindClientNameSubGrup();
                BindTypeList();
                BindYTRApplicableList();
                model = repoCandidate.GetCandidateLoginForPassUpdateById(id);
                string EncryptedPasswd = clsCommonMethods.PasswordDecrypt(model.UPass.Trim());
                model.UPass = EncryptedPasswd;
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
        public ActionResult EditCandidateLogin(UpdatePQCandidateLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.UserID != null && model.UserID.Trim().Length > 0)
                    {
                        if (!repoCandidate.IsCandidateLoginExist(model.UserID.Trim(), model.CandidateUserRowID))
                        {
                            model.ModifiedTime = DateTime.Now;
                            string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(model.UPass.Trim());
                            model.UPass = EncryptedPasswd;
                            model.CreatedUserId = Convert.ToInt16(Session["TeamMemberRowID"]);
                            repoCandidate.UpdateCandidateLogin(model);
                            int Res = repoCandidate.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCandidateLogin");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User ID Name could not be blank!");
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
            BindClientNameSubGrup();
            BindYTRApplicableList();
            BindTypeList();
            return View();
        }

        [SessionExpireFilterAttribute]
        public JsonResult DeleteCandidateLogin(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoLogin.DeleteClientLoginSubGroups(id);
                    int Res = repoLogin.SaveChanges();
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
        public JsonResult ActiveCandidateLogin(string checkeds = "", short id = 0)
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
                    repoCandidate.ActiveCandidateLogin(id, checkeds);
                    int Res = repoCandidate.SaveChanges();
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
        #endregion

        #region ****** Client TeamMembers ******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageClientTeamMembers(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short CId = 0)
        {
            PQClientTMemberListPagedModel model = new PQClientTMemberListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                model = repoClientTMember.GetClientTeamMembers(page, pageSize, sort, sortDir, Search, CId);
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
        public ActionResult AddClientTeamMember(short CId = 0)
        {
            AddPQClientTMemberViewModel model = new AddPQClientTMemberViewModel();
            try
            {
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                BindDepartmentList();
                BindDepartmentTMemberList();
                model.ClientRowID = CId;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddClientTeamMember(AddPQClientTMemberViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(model.TeamMemberRowIds))
                    {
                        int res = 0;
                        bool saveOrNot = false;
                        string[] tmids = model.TeamMemberRowIds.Split(',');
                        foreach (var item in tmids)
                        {
                            string[] ids = item.Split('_');
                            model.TeamDepartmentRowID = Convert.ToInt16(ids[1]);
                            if (!repoClientTMember.IsClientTeamMemberExist(model.TeamDepartmentRowID, model.ClientRowID))
                            {
                                repoClientTMember.AddClientTeamMember(model);
                                res = repoClientTMember.SaveChanges();
                                saveOrNot = true;
                            }
                        }
                        if (saveOrNot)
                        {
                            if (res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageClientTeamMembers", new { CId = model.ClientRowID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                            }
                        }
                        else
                        {
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageClientTeamMembers", new { CId = model.ClientRowID });
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Please select atleast one member!";
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
            //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == model.ClientRowID).Select(p => p.ClientName).FirstOrDefault();
            BindTeamMemberList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DeleteClientTeamMember(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoClientTMember.DeleteClientTeamMember(id);
                    int Res = repoClientTMember.SaveChanges();
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

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportClientTeamMember(short CId = 0)
        {
            try
            {
                var data = repoPQClient.GetClientTeamMemberForExport(CId);
                ExportToExcel(data, "TeamMemberClient");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ************* Upload Document **********
        //[SessionExpireFilterAttribute]
        //public ActionResult ManageUploadDocmentList(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short SubCheckRowID = 0, int pid = 0)
        //{
        //    PQVerifiedUploadDocListPagedModel model = new PQVerifiedUploadDocListPagedModel();
        //    try
        //    {
        //        if (pid == 0)
        //        {
        //            ViewBag.ErrorMsg = "Invalid id!";
        //            return RedirectToAction("AllocatedDEScannerJob", "ProvidedInfo");
        //        }

        //        int pageSize = clsGlobalCommon.PageSize;
        //        GetAllDocUploadedCheckList(pid);
        //        GetAddressProofDocs();
        //        model = repoPQVerifiedUploadDoc.GetCandidateUploadedDocList(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, SubCheckRowID, pid);
        //        var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(pid);
        //        Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
        //        Session["SecuritasRefID"] = CandDetail.CompanyRefNo;

        //    }
        //    catch (Exception Ex)
        //    {
        //        ViewBag.ErrorMsg = Ex.Message;
        //        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
        //    }
        //    return View(model);
        //}

        #endregion

        #region ***************ClientHoliDay***************
        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageClientHoliDay(int page = 1, string sort = "Holiday", string sortDir = "asc", string Search = "", short CId = 0)
        {
            PQClientHolidayListPagedModel model = new PQClientHolidayListPagedModel();
            try
            {
                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                int pageSize = clsGlobalCommon.PageSize;
                model = repoClientHoliday.GetPQClientHoliday(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CId);
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
        public ActionResult AddClientHoliDay(short CId = 0)
        {
            AddPQClientHolidayViewModel model = new AddPQClientHolidayViewModel();

            try
            {

                //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
                var ClientHoliday = repoClientHoliday.GetClientHolidays(CId);
                if (ClientHoliday != null && ClientHoliday.Count() > 0)
                {
                    foreach (var item in ClientHoliday)
                    {
                        if (item.HoliRowID > 0)
                        {
                            model.HoliRowIDs += Convert.ToString(item.HoliRowID) + ",";
                        }
                    }

                    if (model.HoliRowIDs.Length > 0)
                    {
                        model.HoliRowIDs = model.HoliRowIDs.Substring(0, model.HoliRowIDs.Length - 1);
                    }
                    else
                    {
                        model.HoliRowIDs = "";
                    }
                }
                model.ClientRowID = CId;
                BindHoliDay();
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
        public ActionResult AddClientHoliDay(AddPQClientHolidayViewModel model, short CId = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.HoliRowIDs))
                        model.HoliRowIDs = null;
                    int Res = 0;
                    string selected = model.HoliRowIDs;
                    string[] selectedList = selected.Split(',');
                    foreach (var item in selectedList)
                    {
                        model.HoliRowID = Int16.Parse(item);
                        if (!repoClientHoliday.IsClientHolidayExist(model.ClientRowID, model.HoliRowID))
                        {
                            repoClientHoliday.AddIPQClientHoliday(model);
                            Res = repoClientHoliday.SaveChanges();
                        }
                    }
                    if (Res > 0)
                    {
                        if (model.ClientRowID > 0)
                        {
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageClientHoliDay", new { CId = model.ClientRowID });
                        }

                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Record Already Exist!";
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
            //ViewBag.ClientName = repoPQClient.GetPQClients().Where(p => p.ClientRowID == CId).Select(p => p.ClientName).FirstOrDefault();
            BindHoliDay();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DeleteHoliday(short id)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoClientHoliday.DeletePQClientHoliday(id);
                    int Res = repoClientHoliday.SaveChanges();
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
        #endregion

        #region **** DropDownList Bind ****

        [NonAction]
        void BindComletedContract(short ClientRowId = 0)
        {
            try
            {
                ClientCompletedContractViewModel model = new ClientCompletedContractViewModel();
                model = repoCliCompletedContract.ClientComletedContract(ClientRowId);
                Session["ClientContract"] = model.UploadClientContracts;
                Session["ClientCheck"] = model.ClientCheck;
                Session["ClientPackage"] = model.ClientPackage;
                Session["clientDisposition"] = model.clientDisposition;
                Session["ClientSeveritie"] = model.ClientSeveritie;
                Session["ClientHoliday"] = model.ClientHoliday;
                Session["ClientTeamMember"] = model.ClientTeamMember;
                Session["ClientMail"] = model.ClientMail;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindClientDesignation()
        {
            try
            {
                ViewBag.ClientDesignations = repoDDL.GetClientDesignationsDDL();
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }
        [NonAction]
        void BindHoliDay()
        {
            ViewBag.ListHoliDay = repoClientHoliday.GetHolidayList();
        }

        [NonAction]
        void BindCountry()
        {
            try
            {
                ViewBag.Countries = repoDDL.GetCountriesForDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindClientNameSubGrup()
        {
            try
            {
                ViewBag.Client = repoDDL.GetClientListWithAbbAndLocationForDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        public JsonResult BindState(short id = 0)
        {
            var States = new List<StateDDLViewModel>();
            try
            {
                States = repoDDL.GetStatesByCountryIdForDDL(id).ToList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return Json(new SelectList(States.ToArray(), "StateRowID", "StateName"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindDistrict(short id = 0)
        {
            var Districts = new List<DistrictDDLViewModel>();
            try
            {
                Districts = repoDDL.GetDistrictsByStateIdForDDL(id).ToList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return Json(new SelectList(Districts.ToArray(), "DistrictRowID", "DistrictName"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindLocation(short id = 0)
        {
            var Locations = new List<LocationDDLViewModel>();
            try
            {
                Locations = repoDDL.GetLocationsByDistrictIdForDDL(id).ToList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return Json(new SelectList(Locations.ToArray(), "LocationRowID", "LocationName"), JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public void BindClientAbbList()
        {
            try
            {
                ViewBag.ClientAbbList = repoDDL.GetClientSubGroupDDL();
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        public JsonResult ClientAbbSubGroupList(short id = 0)
        {
            var ClientAbbSubGroupList = new List<ClientAbbSubGroupDDLViewModel>();

            try
            {
                ClientAbbSubGroupList = repoDDL.GetClientAbbSubGroupDDL(id).ToList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return Json(new SelectList(ClientAbbSubGroupList.ToArray(), "ClientSubGroupID", "SubGroupName"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPinCodeByLocationId(int id = 0)
        {
            if (id > 0)
            {
                int pinCode = 0;
                try
                {
                    pinCode = repoLocation.GetLocationForUpdateById(id).PinCode;

                }
                catch (Exception Ex)
                {

                    ViewBag.ErrorMsg = Ex.Message;
                    clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                }
                return Json(pinCode, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBranchOfficeNameByid(short id = 0)
        {
            if (id > 0)
            {
                short BORowID = 0;
                try
                {
                    BORowID = repoPQClient.GetPQClientForUpdateById(id).BORowID;
                }
                catch (Exception Ex)
                {

                    ViewBag.ErrorMsg = Ex.Message;
                    clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                }
                return Json(BORowID, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClientAbbreviation(short id = 0)
        {
            if (id > 0)
            {
                string UserID = string.Empty;
                try
                {
                    UserID = repoCandidate.GetClientAbbreviation(id);
                    int NumberOfEntiry = repoCandidate.GetAllCandidateUserByClientId(id);
                    string empty = string.Empty;

                    if (NumberOfEntiry >= 10)
                    {
                        NumberOfEntiry++;
                        empty = Convert.ToString(NumberOfEntiry);
                    }
                    else
                    {
                        NumberOfEntiry++;
                        empty = string.Concat("0", Convert.ToString(NumberOfEntiry));
                    }
                    string[] strArrays = new string[] { UserID, DateTime.Now.ToString("MMyy"), empty };
                    UserID = string.Concat(strArrays);
                }
                catch (Exception Ex)
                {

                    ViewBag.ErrorMsg = Ex.Message;
                    clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                }

                return Json(UserID, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(0, JsonRequestBehavior.AllowGet);
        }

        public void BindPackagesList()
        {
            ViewBag.ClientPackages = repoDDL.GetPackagesForDDL();
        }

        [NonAction]
        void BindClientSpocList()
        {
            try
            {
                //var datalist = repoDDL.GetSpocForClientForChkBoxList();
                ViewBag.ClientSpocList = repoDDL.GetSpocForClientForChkBoxList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindYesNoList()
        {
            try
            {
                IEnumerable<SelectListItem> YesNoList = new List<SelectListItem> {
                new SelectListItem { Text = "Yes", Value = "1" },
                new SelectListItem { Text = "No", Value = "0" },
            };
                ViewBag.YesNoList = YesNoList;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindReportSentByList()
        {
            try
            {
                IEnumerable<SelectListItem> ReportSentBy = new List<SelectListItem> {
                new SelectListItem { Text = "Mail", Value = "1" },
                new SelectListItem { Text = "Physical", Value = "2" },
                new SelectListItem { Text = "Both", Value = "3" },
            };
                ViewBag.ReportSentByList = ReportSentBy;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindPricingTypeList()
        {
            try
            {
                IEnumerable<SelectListItem> PricingType = new List<SelectListItem> {
                new SelectListItem { Text = "Package", Value = "1" },
                new SelectListItem { Text = "Check", Value = "2" },
                new SelectListItem { Text = "Both", Value = "3" },
            };
                ViewBag.PricingTypeList = PricingType;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        void BindSeverityTypeList()
        {
            try
            {
                IEnumerable<SelectListItem> SeverityTypeList = new List<SelectListItem> {
                new SelectListItem { Text = "Default", Value = "0" },
                new SelectListItem { Text = "Client", Value = "1" },
            };
                ViewBag.SeverityTypeList = SeverityTypeList;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
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

        [NonAction]
        void BindBillingCycleList()
        {
            try
            {
                ViewBag.BillingCycleList = repoDDL.GetBillingCycleForDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindCheckFamily()
        {
            try
            {
                ViewBag.CheckFamilyList = repoCheckFamily.GetCheckFamily();
                ViewBag.ChkFmlyCount = repoCheckFamily.GetCheckFamily().Count();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindSubCheckFamily()
        {
            try
            {
                ViewBag.SubCheckFamilyList = repoSubCheckFamily.GetSubCheckFamily();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        void BindSeverityGrid()
        {
            ViewBag.SeverityGrid = repoDDL.GetSeverityGridDDL();
        }

        void BindTeamMemberList()
        {
            var datalist = repoTeamMember.GetTeamMembers();

            ViewBag.TeamMemberList = new MultiSelectList(datalist, "TeamMemberRowID", "TeamMemberName");
        }
        void BindDepartmentList()
        {
            ViewBag.Departments = repoDDL.GetDepartmentsForDDL();
        }

        void BindDepartmentTMemberList()
        {
            var datalist = repoTeamDepartment.GetDepartmentTMembers();

            ViewBag.TeamMemberList = datalist;
        }

        #endregion

        #region ****** NonAction Methods ******

        [NonAction]
        public void BindTypeList()
        {
            try
            {
                IEnumerable<SelectListItem> TypeNameList = new List<SelectListItem>
            {
            new SelectListItem { Text = "Non-Expire ", Value = "1"},
            new SelectListItem { Text = "Expire ", Value = "0"},

            };
                ViewBag.AddTypeList = TypeNameList;
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        public void BindYTRApplicableList()
        {
            try
            {
                IEnumerable<SelectListItem> YTRApplicableList = new List<SelectListItem>
            {
            new SelectListItem { Text = "Not-Applicable ", Value = "0"},
            new SelectListItem { Text = "Applicable ", Value = "1"},

            };
                ViewBag.AddYTRApplicableList = YTRApplicableList;
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }


        [NonAction]
        public void BindPanelNameList()
        {
            try
            {
                IEnumerable<SelectListItem> PanelNameDrugsList = new List<SelectListItem>
            {
            new SelectListItem { Text = "1 Panel ", Value = "1"},
            new SelectListItem { Text = "2 Panel ", Value = "2"},
            new SelectListItem { Text = "3 Panel", Value = "3" },
            new SelectListItem { Text = "4 Panel", Value = "4" },
            new SelectListItem { Text = "5 Panel", Value = "5" },
            new SelectListItem { Text = "6 Panel", Value = "6" },
            new SelectListItem { Text = "7 Panel", Value = "7" },
            new SelectListItem { Text = "8 Panel", Value = "8" },
            new SelectListItem { Text = "9 Panel", Value = "9" },
            new SelectListItem { Text = "10 Panel", Value = "10" },
            new SelectListItem { Text = "11 Panel", Value = "11" },
            new SelectListItem { Text = "12 Panel", Value = "12" },
            new SelectListItem { Text = "13 Panel", Value = "13" },
            new SelectListItem { Text = "14 Panel", Value = "14" },
            };
                ViewBag.AddPanelList = PanelNameDrugsList;
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }
        [NonAction]
        public void BindClient()
        {
            try
            {
                ViewBag.ClientSubGroup = repoDDL.GetClientSubGroupDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ****** Export To Excel ******

        public void ExportToExcel<T>(IEnumerable<T> list, string strFileName)
        {
            try
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
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

    }

}