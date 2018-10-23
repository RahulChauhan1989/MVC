using BAL;
using BAL.ClientRepository;
using BAL.HRRepository;
using BAL.ProvidedInfoRepository;
using BAL.VerificationRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.ProvidedInfoViewModel;
using ViewModels.VerificationViewModel;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class InsuffController : Controller
    {
        #region ******  Repository Objects ******

        IDropDownMasterRepository repoDDL;
        IPQPersonalRepository repoPQPersonal;
        IPQClientRepository repoPQClient;
        IAbbreviationRepository repoAbbreviation;
        ILocationRepository repoLocation;
        IClientPackageRepository repoClientPackage;
        IClientCheckRepository repoClientCheck;
        IAntecedentRepository repoAntecedent;
        IPQLogTrasactionRepository repoPQLogTrasaction;
        IPQCandidateCheckRepository repoPQCandidateCheck;
        ITeamMemberRepository repoTeamMember;
        IPQClientTMemberRepository repoPQClientTMember;
        IAddressInfoRepository repoAddressInfo;
        IEmploymentInfoRepository repoEmploymentInfo;
        IEducationInfoRepository repoEducationInfo;
        ICriminalInfoRepository repoCriminalInfo;
        INationalIdentityInfoRepository repoNationalIdentInfo;
        IReferenceInfoRepository repoReferenceInfo;
        IInsuranceInfoRepository repoInsuranceInfo;
        IHolidayRepository repoHoliday;
        IPQClientHolidayRepository repoPQClientHoliday;
        ISubCheckFamilyRepository repoSubCheckFamily;
        IPQVerifiedUploadDocRepository repoPQVerifiedUploadDoc;
        IPQClientCompnayUploadDocRepository repoClientCmpUplod;
        IEducationResearchRepository repoEducationResearch;
        IEmploymentResearchRepository repoEmploymentResearch;
        ICheckActionHistoryRepository repoCheckActionHistory;
        IVerificationInfoRepository repoVerificationInfo;
        ISpecialCheckInfoRepository repoSplCheckInfo;

        public InsuffController(
            IDropDownMasterRepository _repoDDL
            , IPQPersonalRepository _repoPQPersonal
            , IPQClientRepository _repoPQClient
            , IAbbreviationRepository _repoAbbreviation
            , ILocationRepository _repoLocation
            , IClientPackageRepository _repoClientPackage
            , IClientCheckRepository _repoClientCheck
            , IAntecedentRepository _repoAntecedent
            , IPQLogTrasactionRepository _repoPQLogTrasaction
            , IPQCandidateCheckRepository _repoPQCandidateCheck
            , ITeamMemberRepository _repoTeamMember
            , IPQClientTMemberRepository _repoPQClientTMember
            , IAddressInfoRepository _repoAddressInfo
            , IEmploymentInfoRepository _repoEmploymentInfo
            , IEducationInfoRepository _repoEducationInfo
            , ICriminalInfoRepository _repoCriminalInfo
            , INationalIdentityInfoRepository _repoNationalIdentInfo
            , IReferenceInfoRepository _repoReferenceInfo
            , IInsuranceInfoRepository _repoInsuranceInfo
            , IHolidayRepository _repoHoliday
            , IPQClientHolidayRepository _repoPQClientHoliday
            , ISubCheckFamilyRepository _repoSubCheckFamily
            , IPQVerifiedUploadDocRepository _repoPQVerifiedUploadDoc
            , IPQClientCompnayUploadDocRepository _repoClientCmpUplod
            , IEducationResearchRepository _repoEducationResearch
            , IEmploymentResearchRepository _repoEmploymentResearch
            , ICheckActionHistoryRepository _repoCheckActionHistory
            , IVerificationInfoRepository _repoVerificationInfo
            , ISpecialCheckInfoRepository _repoSplCheckInfo
            )
        {
            repoDDL = _repoDDL;
            repoPQPersonal = _repoPQPersonal;
            repoPQClient = _repoPQClient;
            repoAbbreviation = _repoAbbreviation;
            repoLocation = _repoLocation;
            repoClientPackage = _repoClientPackage;
            repoClientCheck = _repoClientCheck;
            repoAntecedent = _repoAntecedent;
            repoPQLogTrasaction = _repoPQLogTrasaction;
            repoPQCandidateCheck = _repoPQCandidateCheck;
            repoTeamMember = _repoTeamMember;
            repoPQClientTMember = _repoPQClientTMember;
            repoAddressInfo = _repoAddressInfo;
            repoEmploymentInfo = _repoEmploymentInfo;
            repoEducationInfo = _repoEducationInfo;
            repoCriminalInfo = _repoCriminalInfo;
            repoNationalIdentInfo = _repoNationalIdentInfo;
            repoReferenceInfo = _repoReferenceInfo;
            repoInsuranceInfo = _repoInsuranceInfo;
            repoHoliday = _repoHoliday;
            repoPQClientHoliday = _repoPQClientHoliday;
            repoSubCheckFamily = _repoSubCheckFamily;
            repoPQVerifiedUploadDoc = _repoPQVerifiedUploadDoc;
            repoClientCmpUplod = _repoClientCmpUplod;
            repoEducationResearch = _repoEducationResearch;
            repoEmploymentResearch = _repoEmploymentResearch;
            repoCheckActionHistory = _repoCheckActionHistory;
            repoVerificationInfo = _repoVerificationInfo;
            repoSplCheckInfo = _repoSplCheckInfo;
        }

        #endregion

        // GET: Insuff
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            CreateNavigationforInsuffCaseForDETL();
            return View();
        }

        #region ****** Address Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageAddressInsuff(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQAddressInsuffListPagedModel model = new PQAddressInsuffListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);

                model = repoAddressInfo.GetAllAddressInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, "", teamMemerRowId);
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
        public ActionResult AddressInsuffCheckClear(int id = 0)
        {
            UpdatePQAddressInsuffClearViewModel model = new UpdatePQAddressInsuffClearViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoAddressInfo.GetPQAddressDetailsById(id);

                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(model.PersonalRowID);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
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
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddressInsuffCheckClear(UpdatePQAddressInsuffClearViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.AddressRowID > 0)
                    {
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        model.InfSuffClearBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.InfSuffClearDate = DateTime.Now;

                        repoAddressInfo.UpdatePQAddressInsuffClear(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddressInsuffCheckClear", "Insuff Rectified", model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Insuff Rectified", model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
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
            return View(model);
        }
        #endregion

        #region ****** Employment Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageEmploymentInsuff(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQEmploymentInsuffListPagedModel model = new PQEmploymentInsuffListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);

                model = repoEmploymentInfo.GetAllEmploymentInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, "", teamMemerRowId);
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
        public ActionResult EmploymentInsuffCheckClear(int id = 0)
        {
            UpdatePQEmploymentInsuffClearViewModel model = new UpdatePQEmploymentInsuffClearViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoEmploymentInfo.GetPQEmploymentDetailsById(id);

                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(model.PersonalRowID);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
                }
                else
                {
                    throw new Exception("Invalid Id!");
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
        public ActionResult EmploymentInsuffCheckClear(UpdatePQEmploymentInsuffClearViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.EmploymentRowID > 0)
                    {
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        model.InfSuffClearBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.InfSuffClearDate = DateTime.Now;

                        repoEmploymentInfo.UpdatePQEmploymentInsuffClear(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "EmploymentInsuffCheckClear", "Insuff Rectified", model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Insuff Rectified", model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
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
            return View(model);
        }
        #endregion

        #region ****** Education Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageEducationInsuff(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQEducationInsuffListPagedModel model = new PQEducationInsuffListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);

                model = repoEducationInfo.GetAllEducationInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, "", teamMemerRowId);
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
        public ActionResult EducationInsuffCheckClear(int id = 0)
        {
            UpdatePQEducationInsuffClearViewModel model = new UpdatePQEducationInsuffClearViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoEducationInfo.GetPQEducationDetailsById(id);

                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(model.PersonalRowID);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
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
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult EducationInsuffCheckClear(UpdatePQEducationInsuffClearViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.EducationRowID > 0)
                    {
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        model.InfSuffClearBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.InfSuffClearDate = DateTime.Now;

                        repoEducationInfo.UpdatePQEducationInsuffClear(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "EducationInsuffCheckClear", "Insuff Rectified", model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Insuff Rectified", model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
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
            return View(model);
        }
        #endregion

        #region ****** Criminal Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageCriminalInsuff(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQCriminalInsuffListPagedModel model = new PQCriminalInsuffListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);

                model = repoCriminalInfo.GetAllCriminalInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, "", teamMemerRowId);
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
        public ActionResult CriminalInsuffCheckClear(int id = 0)
        {
            UpdatePQCriminalInsuffClearViewModel model = new UpdatePQCriminalInsuffClearViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoCriminalInfo.GetPQCriminalDetailsById(id);

                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(model.PersonalRowID);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
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
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult CriminalInsuffCheckClear(UpdatePQCriminalInsuffClearViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CriminalRowID > 0)
                    {
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        model.InfSuffClearBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.InfSuffClearDate = DateTime.Now;

                        repoCriminalInfo.UpdatePQCriminalInsuffClear(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "CriminalInsuffCheckClear", "Insuff Rectified", model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Insuff Rectified", model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
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
            return View(model);
        }
        #endregion

        #region ****** NationalIdentity Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageNationalIdentityInsuff(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQNationalIdentityInsuffListPagedModel model = new PQNationalIdentityInsuffListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);

                model = repoNationalIdentInfo.GetAllNationalIdentityInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, "", teamMemerRowId);
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
        public ActionResult NationalIdentityInsuffCheckClear(int id = 0)
        {
            UpdatePQNationalIdentityInsuffClearViewModel model = new UpdatePQNationalIdentityInsuffClearViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoNationalIdentInfo.GetPQNationalIdentityDetailsById(id);

                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(model.PersonalRowID);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
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
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult NationalIdentityInsuffCheckClear(UpdatePQNationalIdentityInsuffClearViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.NationalIdentityRowID > 0)
                    {
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        model.InfSuffClearBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.InfSuffClearDate = DateTime.Now;

                        repoNationalIdentInfo.UpdatePQNationalIdentityInsuffClear(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "NationalIdentityInsuffCheckClear", "Insuff Rectified", model.UniqueComponentID, "Insert");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Insuff Rectified", model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
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
            return View(model);
        }
        #endregion

        #region ****** Reference Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageReferenceInsuff(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQReferenceInsuffListPagedModel model = new PQReferenceInsuffListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);

                model = repoReferenceInfo.GetAllReferenceInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, "", teamMemerRowId);
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
        public ActionResult ReferenceInsuffCheckClear(int id = 0)
        {
            UpdatePQReferenceInsuffClearViewModel model = new UpdatePQReferenceInsuffClearViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoReferenceInfo.GetPQReferenceDetailsById(id);

                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(model.PersonalRowID);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
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
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult ReferenceInsuffCheckClear(UpdatePQReferenceInsuffClearViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ReferenceRowID > 0)
                    {
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        model.InfSuffClearBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.InfSuffClearDate = DateTime.Now;

                        repoReferenceInfo.UpdatePQReferenceInsuffClear(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ReferenceInsuffCheckClear", "Insuff Rectified", model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Insuff Rectified", model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
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
            return View(model);
        }

        #endregion

        #region ****** Special Check Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageSpecialCheckInsuff(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQSpecialCheckInsuffListPagedModel model = new PQSpecialCheckInsuffListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);

                model = repoSplCheckInfo.GetAllSpecialCheckInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, "", teamMemerRowId);
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
        public ActionResult SpecialCheckCheckClear(int id = 0)
        {
            UpdatePQSpecialCheckInsuffClearViewModel model = new UpdatePQSpecialCheckInsuffClearViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoSplCheckInfo.GetPQSpecialCheckDetailsById(id);

                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(model.PersonalRowID);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
                }
                else
                {
                    throw new Exception("Invalid Id!");
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
        public ActionResult SpecialCheckCheckClear(UpdatePQSpecialCheckInsuffClearViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.SpecialCheckRowId > 0)
                    {
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        model.InfSuffClearBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.InfSuffClearDate = DateTime.Now;

                        repoSplCheckInfo.UpdatePQSpecialChackInsuffClear(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "SpecialChackInsuffCheckClear", "Insuff Rectified", model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Insuff Rectified", model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
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
            return View(model);
        }

        #endregion

        #region ***** Manage Insuff Checks For Upload Documents - DE-Scan *****

        [SessionExpireFilterAttribute]
        public ActionResult ManageInsuffChecksForUploadDoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string CheckStatus = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            BindClientListBaseOnLogin(teamMemerRowId);

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoPQVerifiedUploadDoc.GetInsuffUploadedDocList(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, CheckStatus, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate);

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            //BindClientList();
            return View(model);

        }

        [SessionExpireFilterAttribute]
        public ActionResult UploadInsuffDocumentForCheck(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0, int PersonalRowID = 0, string CompanyRefNo = "", string rdpage = "")
        {
            UplodDocsForDEScanViewModel model = new UplodDocsForDEScanViewModel();
            if (model != null)
            {
                model.VerificationRowID = id;
                model.ClientRowID = ClientRowId;
                model.ChFamilRowId = ChFamilRowId;
                model.PersonalRowID = PersonalRowID;
                model.SubCheckRowID = subCheckId;
                model.SecuritasID = CompanyRefNo;
                model.RedirectPage = rdpage;

            }
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult UploadInsuffDocumentForCheck(UplodDocsForDEScanViewModel model, string UploadHid, IEnumerable<HttpPostedFileBase> UploadDoc)
        {
            try
            {
                if (model.PersonalRowID > 0 && !string.IsNullOrEmpty(UploadHid) && UploadDoc != null && UploadDoc.FirstOrDefault() != null)
                {
                    int count = 0;
                    string[] DocumentTypes = UploadHid.Split(',');
                    foreach (var item in UploadDoc)
                    {
                        model.FileName = item.FileName.ToString();
                        model.DocumentType = DocumentTypes[count];
                        if (model.DocumentType != null && model.FileName != null && item.ContentLength > 0)
                        {
                            SaveInsuffUploadDoc(model.VerificationRowID, model.PersonalRowID, model.SecuritasID, model.ChFamilRowId, model.SubCheckRowID, "Provided", model.DocumentType, "provideddocuments", item, model.Remarks, model.NADoc);
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "No item found!";
                            break;
                        }
                        count++;
                    }

                    #region Save LogTransaction Details
                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UploadInsuffDocumentForCheck", "Insuff", model.DocumentType, "Uploaded");
                    #endregion

                    #region Case/Check Action History Save 
                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "WIP-Pending", "Insuff/Missing Documents Uploaded");
                    #endregion

                    int PID = model.PersonalRowID;
                    ViewBag.SuccessMsg = "Record Added Successfully!";
                    ModelState.Clear();

                    if (!string.IsNullOrEmpty(model.RedirectPage) && model.RedirectPage.Trim().ToLower() == "rejected")
                    {
                        return RedirectToAction("ManageRejectedChecksForDEScan");
                    }
                    else
                    {
                        return RedirectToAction("ManageInsuffChecksForUploadDoc");
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Please select at least one document!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View(model);
        }

        #endregion

        #region ***** Manage Rejected Checks By Data Entry For DE-Scan *****

        [SessionExpireFilterAttribute]
        public ActionResult ManageRejectedChecksForDEScan(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string CheckStatus = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            BindClientListBaseOnLogin(teamMemerRowId);

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoPQVerifiedUploadDoc.GetRejectedListForDEScan(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, CheckStatus, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate);

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            //BindClientList();
            return View(model);

        }

        #endregion

        #region ***** Manage Review Requested Checks By Data Entry For DE TeamLeader *****

        [SessionExpireFilterAttribute]
        public ActionResult ManageReviewRequestedChecksForDETL(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string CheckStatus = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoPQVerifiedUploadDoc.GetReviewRequestedListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, CheckStatus, teamMemberId);

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            BindClientListBaseOnLogin(teamMemberId);
            return View(model);

        }


        [SessionExpireFilterAttribute]
        public ActionResult ManageReviewRequestedChecksForDepartmentTL(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string CheckStatus = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoPQVerifiedUploadDoc.GetReviewRequestedListForDepartmentTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, CheckStatus, teamMemberId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            BindClientListBaseOnLogin(teamMemberId);
            return View(model);

        }
        #endregion

        [SessionExpireFilterAttribute]
        public ActionResult ManageRejectedChecksByDepTMForDEQC(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string CheckStatus = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            short TeamMemberRowID = Convert.ToInt16(Session["TeamMemberRowID"]);

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoPQVerifiedUploadDoc.GetRejectedChecksByDepTMForDEQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, TeamMemberRowID);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            BindClientListBaseOnLogin(TeamMemberRowID);
            return View(model);

        }


        #region ******* NonAction *******

        [NonAction]
        private void CreateNavigationforInsuffCaseForDETL()
        {
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            var AllChecks = repoPQPersonal.GetAllInsuffChecksCountForDETL(teamMemerRowId);
            string NavTeamMemberDE = string.Empty;
            if (Session["Designation"].ToString() == "Team Leader-DE")
            {
                NavTeamMemberDE += "<li><a href='" + Url.Action("ManageAddressInsuff", "Insuff") + "'> Address (" + AllChecks.AddressCount + ") </a></li>";
                NavTeamMemberDE += "<li><a href='" + Url.Action("ManageEmploymentInsuff", "Insuff") + "'> Employment (" + AllChecks.EmploymentCount + ") </a></li>";
                NavTeamMemberDE += "<li><a href='" + Url.Action("ManageEducationInsuff", "Insuff") + "'> Education (" + AllChecks.EducationCount + ") </a></li>";
                NavTeamMemberDE += "<li><a href='" + Url.Action("ManageCriminalInsuff", "Insuff") + "'> Criminal (" + AllChecks.CriminalCount + ") </a></li>";
                NavTeamMemberDE += "<li><a href='" + Url.Action("ManageNationalIdentityInsuff", "Insuff") + "'> NationalIdentity (" + AllChecks.NatIdentityCount + ") </a></li>";
                NavTeamMemberDE += "<li><a href='" + Url.Action("ManageReferenceInsuff", "Insuff") + "'> Reference (" + AllChecks.ReferenceCount + ") </a></li>";
                NavTeamMemberDE += "<li><a href='" + Url.Action("ManageSpecialcheckInsuff", "Insuff") + "'> Special Chack (" + AllChecks.SpecialcheckCount + ") </a></li>";
            }
            Session["NavLeftInsuffMenuDETL"] = NavTeamMemberDE;
        }

        [NonAction]
        void BindClientList()
        {
            ViewBag.ClientList = repoDDL.GetClientListWithAbbAndLocationForDDL(); ;
        }

        public void SaveInsuffUploadDoc(int VerificationRowID = 0, int PersonalRowID = 0, string secRefId = "", short ChFamilRowId = 0, short SubCheckRowID = 0, string DocumentUploadFrom = "",
            string DocumentType = "", string FolderNameForSave = "", HttpPostedFileBase UploadDoc = null, string remarks = "", byte NADoc = 0)
        {
            try
            {               
                string FileName = (secRefId + "_" + SubCheckRowID.ToString() + " " + DocumentType).Replace(" ", "_").Replace("-", "_");
                PQAddVerifiedUploadDocViewModel DocModel = new PQAddVerifiedUploadDocViewModel();
                DocModel.VerifiedUploadRowID = VerificationRowID;
                DocModel.PersonalRowID = PersonalRowID;
                DocModel.SubCheckRowID = SubCheckRowID;
                DocModel.CheckFamilyRowID = ChFamilRowId;
                DocModel.DocumentUploadFrom = DocumentUploadFrom; //  Provided / Verified
                DocModel.DocumentType = DocumentType; //Name of the selected docs
                if (NADoc == 0)
                {
                    string FldPathDoc = string.Empty;
                    FldPathDoc = ConfigurationManager.AppSettings[FolderNameForSave.Trim().ToLower()].ToString();

                    string existFile = repoPQVerifiedUploadDoc.ExistFileByPersonalIdSubCheckIdDocType(PersonalRowID, SubCheckRowID, DocumentType);
                    if (!string.IsNullOrEmpty(existFile))
                    {
                        string path = Server.MapPath(FldPathDoc + existFile);
                        FileInfo file = new FileInfo(path);
                        if (file.Exists)//check file exsit or not
                        {
                            file.Delete();
                        }
                    }

                    string proImg = string.Empty;
                    string ext = Path.GetExtension(UploadDoc.FileName).ToLower();
                    proImg = FileName + ext;
                    UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                    DocModel.FileName = Path.GetFileName(proImg);
                    DocModel.FilePath = FldPathDoc;

                    //string FldPathDoc = string.Empty;
                    //FldPathDoc = ConfigurationManager.AppSettings[FolderNameForSave.Trim().ToLower()].ToString();
                    //string proImg = string.Empty;
                    //string ext = Path.GetExtension(UploadDoc.FileName).ToLower();
                    //proImg = (secRefId + "_" + SubCheckRowID.ToString() + " " + DocumentType).Replace(" ", "_").Replace("-", "_") + ext;
                    //UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                    //DocModel.FileName = Path.GetFileName(proImg);
                    //DocModel.FilePath = FldPathDoc;
                }
                else
                {
                    DocModel.FileName = "NA";
                    DocModel.FilePath = "NA";
                }
                DocModel.UploadDate = DateTime.Now;
                DocModel.StatusDocxConvert = 0;
                DocModel.StatusPDF2DOCXConvert = 0;
                DocModel.PDF_FileName = "";
                DocModel.Status = 1;
                DocModel.Remarks = remarks;
                repoPQVerifiedUploadDoc.AdInsuffUploadDoc(DocModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        void BindCheckActionHistory(int PersonalRowID = 0, short subCheckId = 0)
        {
            try
            {
                ViewBag.CheckActionHistories = repoDDL.GetCheckActionHistory(PersonalRowID, subCheckId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindClientListBaseOnLogin(short TeamMemberRowId = 0)
        {
            try
            {
                ViewBag.ClientList = repoDDL.GetClientBaseOnloginMemberForDDL(TeamMemberRowId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}