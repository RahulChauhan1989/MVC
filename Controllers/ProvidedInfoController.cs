using BAL;
using BAL.ClientRepository;
using BAL.HRRepository;
using BAL.ProvidedInfoRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;
using ViewModels.ClientViewModel;
using ViewModels.TempViewModel;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;
using System.Data.SqlTypes;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;
using ViewModels.ProvidedInfoViewModel;
using BAL.CandidateRepository;
using ViewModels.CandidateViewModel;
using System.Web.UI.WebControls;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class ProvidedInfoController : Controller
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
        IPQClientCandiBulkUploadRepository repoPQClientCandiBulkUpload;
        ICaseActionHistoryRepository repoCaseActionHistory;
        IPQVerifiedUploadCaseDocRepository repoPQVerifiedUploadCaseDoc;
        IDashboardDataEntryRepository repoIDashboardDataEntry;
        IPQCandidateLoginRepository repoPQCandidateLogin;
        ISpecialCheckInfoRepository repoSplCheckInfo;

        public ProvidedInfoController(
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
            , IPQClientCandiBulkUploadRepository _repoPQClientCandiBulkUpload
            , ICaseActionHistoryRepository _repoCaseActionHistory
            , IPQVerifiedUploadCaseDocRepository _repoPQVerifiedUploadCaseDoc
            , IDashboardDataEntryRepository _repoIDashboardDataEntry
            , IPQCandidateLoginRepository _repoPQCandidateLogin
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
            repoPQClientCandiBulkUpload = _repoPQClientCandiBulkUpload;
            repoCaseActionHistory = _repoCaseActionHistory;
            repoPQVerifiedUploadCaseDoc = _repoPQVerifiedUploadCaseDoc;
            repoIDashboardDataEntry = _repoIDashboardDataEntry;
            repoPQCandidateLogin = _repoPQCandidateLogin;
            repoSplCheckInfo = _repoSplCheckInfo;
        }

        #endregion

        // GET: ProvidedInfo
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            try
            {
                CreateNavigationforTeamMemberDE();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                //DataEntry Manager
                if (Designation == "Manager-DE")
                {
                    ViewBag.DEDashboard = "DataEntry Manager Dashboard!";
                    ViewBag.DEManagerDashboard = repoIDashboardDataEntry.GetDEManagerDashBoardInfo(teamMemerRowId);
                }

                //DataEntry TeamLeader               
                if (Designation == "Team Leader-DE")
                {
                    ViewBag.DEDashboard = "DataEntry TeamLeader Dashboard!";
                    ViewBag.DETeamLeaderDashboard = repoIDashboardDataEntry.GetDETeamLeaderDashBoardInfo(teamMemerRowId);
                }

                //DataEntry Team Member-DE-Scan               
                if (Designation == "Team Member-DE-Scan")
                {
                    ViewBag.DEDashboard = "DataEntry TeamMember Scanner Dashboard!";
                    ViewBag.DEScanTeamMemberDashboard = repoIDashboardDataEntry.GetDETeamMemberDEScanDashBoardInfo(teamMemerRowId);
                }

                //DataEntry Team Member-DE               
                if (Designation == "Team Member-DE")
                {
                    ViewBag.DEDashboard = "DataEntry TeamMember Dashboard!";
                    ViewBag.DETeamMemberDashboard = repoIDashboardDataEntry.GetDETeamMemberDEDashBoardInfo(teamMemerRowId);
                }

                //DataEntry Team Member-DE-QC               
                if (Designation == "Team Member-DE-QC")
                {
                    ViewBag.DEDashboard = "DataEntry TeamMember QC Dashboard!";
                    ViewBag.DETeamMemberQCDashboard = repoIDashboardDataEntry.GetDETeamMemberDEQCDashBoardInfo(teamMemerRowId);
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View();
        }

        #region ******* Manage Candidate *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddCandidate()
        {
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            BindClientListBaseOnLogin(teamMemerRowId);

            BindCaseTypeList();
            BindTitleList();
            BindTitleFatherList();
            BindMaritalStatusList();
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddCandidate(AddPQPersonalViewModel model)
        {
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ClientRowID > 0 && model.Name.Trim().Length > 0)
                    {
                        if (!repoPQPersonal.IsCandidateExist(model.ClientRowID, model.VoterIDCardNo, model.DrivingLicenseNo, model.AadhaarCardNo, model.PassportNo, model.PanCardNo))
                        {
                            model.CreatedBy = teamMemerRowId;
                            model.CreatedDate = DateTime.Now;
                            model.FromType = "Company Cases";
                            model.DetailsEnteredBy = "Company";
                            model.CaseStatus = "Allocated";
                            model.Status = 1;

                            PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);

                            #region OrderDate And DeliveryDate

                            if (model.IsBackdate && model.HowManyBackDays > 0)
                            {
                                model.CompanyRefNo = GetCompanyRefNo(model.ClientRowID, model.HowManyBackDays);
                                DateTime oDate = DateTime.Now.AddDays(-model.HowManyBackDays);
                                model.OrderDate = oDate;
                                model.DeliveryDate = GetDeliveryDate(oDate, model.TAT, client);
                            }
                            else
                            {
                                model.CompanyRefNo = GetCompanyRefNo(model.ClientRowID, 0);
                                DateTime oDate = DateTime.Now;
                                model.OrderDate = oDate;
                                model.DeliveryDate = GetDeliveryDate(oDate, model.TAT, client);
                            }
                            #endregion

                            int count = 0;
                            if (!string.IsNullOrEmpty(model.AadhaarCardNo))
                            {
                                count += 1;
                                model.AadhaarCard = 1;
                            }
                            if (!string.IsNullOrEmpty(model.PassportNo))
                            {
                                count += 1;
                                model.Passport = 1;
                            }
                            if (!string.IsNullOrEmpty(model.PanCardNo))
                            {
                                count += 1;
                                model.PanCard = 1;
                            }
                            if (!string.IsNullOrEmpty(model.DrivingLicenseNo))
                            {
                                count += 1;
                                model.DrivingLicense = 1;
                            }
                            if (!string.IsNullOrEmpty(model.VoterIDCardNo))
                            {
                                count += 1;
                                model.VoterIDCard = 1;
                            }
                            if (count > 0 && !string.IsNullOrEmpty(model.CandidateCheckOrPackage))
                            {
                                repoPQPersonal.AddCandidate(model);
                                int Res = repoPQPersonal.SaveChanges();
                                if (Res > 0)
                                {
                                    model.PersonalRowID = repoPQPersonal.GetPQPersonalByCandidateCode(model.CompanyRefNo).PersonalRowID;
                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "Add Candidate", "Candidate Reference Generated", "Input", "Insert");
                                    #endregion

                                    #region Case/Check Action History Save 
                                    clsCommonMethods.AddCaseActionHistory(model.PersonalRowID, "Allocated-TL", "Securitas Id Generated: " + model.CompanyRefNo);
                                    #endregion

                                    #region Save Package Or Check for Candidate

                                    SavePackageOrCheckWithCandidate(model);

                                    #endregion

                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("DataEntryAllocation");
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("", "Enter atleast one document details!");
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Candidate could not be blank!");
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

            BindClientListBaseOnLogin(teamMemerRowId);
            BindCaseTypeList();
            BindTitleList();
            BindTitleFatherList();
            BindMaritalStatusList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateCandidateDetails(int id = 0)
        {
            UpdatePQPersonalViewModel model = new UpdatePQPersonalViewModel();
            try
            {
                BindClientList();
                BindCaseTypeList();
                BindTitleList();
                BindTitleFatherList();
                BindMaritalStatusList();
                BindCatagoryList();
                BindCandidateTypeList();
                model = repoPQPersonal.GetPQPersonalForUpdateById(id);
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
        public ActionResult UpdateCandidateDetails(UpdatePQPersonalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PersonalRowID > 0 && model.Name.Trim().Length > 0)
                    {
                        #region Docs Details
                        int count = 0;
                        if (!string.IsNullOrEmpty(model.AadhaarCardNo))
                        {
                            count += 1;
                            model.AadhaarCard = 1;
                        }
                        if (!string.IsNullOrEmpty(model.PassportNo))
                        {
                            count += 1;
                            model.Passport = 1;
                        }
                        if (!string.IsNullOrEmpty(model.PanCardNo))
                        {
                            count += 1;
                            model.PanCard = 1;
                        }
                        if (!string.IsNullOrEmpty(model.DrivingLicenseNo))
                        {
                            count += 1;
                            model.DrivingLicense = 1;
                        }
                        if (!string.IsNullOrEmpty(model.VoterIDCardNo))
                        {
                            count += 1;
                            model.VoterIDCard = 1;
                        }
                        #endregion

                        PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);

                        #region OrderDate And DeliveryDate

                        DateTime oDate = DateTime.Now;
                        //model.OrderDate = oDate;
                        //model.DeliveryDate = GetDeliveryDate(oDate, model.TAT, client);
                        #endregion
                        if (count > 0)
                        {
                            repoPQPersonal.UpdateCandidate(model);
                            int Res = repoPQPersonal.SaveChanges();
                            if (Res > 0)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "Update Candidate", "Candidate Information Update", "Input", "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCaseActionHistory(model.PersonalRowID, model.CaseStatus, "Update Candidate Information");
                                #endregion
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                int PID = model.PersonalRowID;
                                ModelState.Clear();
                                if (Session["Designation"].ToString() == "Team Member-DE-QC")
                                {
                                    return RedirectToAction("ManageQualityCheckJob", new { id = PID });
                                }
                                else
                                {
                                    return RedirectToAction("ManageDataEntryJob", new { id = PID });
                                }

                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change";
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Enter atleast one document details!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Candidate could not be blank!");
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
            BindClientList();
            BindCaseTypeList();
            BindTitleList();
            BindTitleFatherList();
            BindMaritalStatusList();
            BindCatagoryList();
            BindCandidateTypeList();
            return View(model);
        }

        #endregion

        #region ******* Manage Bulk Candidate Import *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddBulkCandidateImport()
        {
            AddPQPersonalBulkImportViewModel model = new AddPQPersonalBulkImportViewModel();
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);

                string FileName = "CandidateUploadTemplate.xlsx";
                string FldPathDoc = System.Configuration.ConfigurationManager.AppSettings["clientCanidatetemplate"].ToString();
                model.Template = Url.Content(FldPathDoc + FileName);
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
        public ActionResult AddBulkCandidateImport(AddPQPersonalBulkImportViewModel model)
        {
            try
            {
                if (model.ClientRowID > 0 && !string.IsNullOrEmpty(model.CandidateCheckOrPackage))
                {
                    int fileNo = repoPQClientCandiBulkUpload.GetNoOfExcelFileByClientID(model.ClientRowID);
                    var ClientDetails = repoPQClient.GetPQClientForCadiCodeGenById(model.ClientRowID);
                    if (model.UploadDoc != null && model.UploadDoc.ContentLength > 0)
                    {
                        fileNo++;
                        string Extension = Path.GetExtension(model.UploadDoc.FileName).ToLower();
                        string FileName = (ClientDetails.ClientName + "_" + fileNo.ToString()).Replace(" ", "_").Replace("-", "_") + Extension;
                        string FolderPath = ConfigurationManager.AppSettings["clientCanidatetemplate"];
                        // HttpPostedFileBase
                        string FilePath = Server.MapPath(FolderPath + FileName);
                        model.UploadDoc.SaveAs(Server.MapPath(FolderPath + FileName));

                        int res = SaveClientCandidateUploadFileWithChecks(model.ClientRowID, FileName, model.CandidateCheckOrPackage);
                        if (res > 0)
                        {
                            ImportExcelAndSaveCandidateByBulkUpload(FilePath, Extension, "Yes", model);
                            ModelState.Clear();
                            return RedirectToAction("DataEntryAllocation");
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Please Select Excel Document!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid ClientID!";
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

        #region ******* DataEntry Scanner Job *******

        [SessionExpireFilterAttribute]
        public ActionResult AllocatedDEScannerJob(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string CaseStatus = "", byte tatHours = 0)
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = 0;
                if (Session["Designation"].ToString() == "Team Member-DE-Scan")
                {
                    teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                    BindClientListBaseOnLogin(teamMemerRowId);
                    model = repoPQPersonal.GetAllocatedCandidateListForDEScan(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, CaseStatus, tatHours);
                }
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
        public JsonResult CompletedDEScannerJobs(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoPQPersonal.UpdatePQPersonalForQC(id, "WIP");
                    int Res = repoPQPersonal.SaveChanges();

                    if (Res > 0)
                    {
                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(id, "CompletedDEScannerJobs", "WIP", "Upload docs", "Upload document complete");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCaseActionHistory(id, "WIP", "Scanner job completed");
                        #endregion
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

        [SessionExpireFilterAttribute]
        public ActionResult ManageUploadDocmentList(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short SubCheckRowID = 0, int pid = 0)
        {
            PQVerifiedUploadDocListPagedModel model = new PQVerifiedUploadDocListPagedModel();
            try
            {
                if (pid == 0)
                {
                    ViewBag.ErrorMsg = "Invalid id!";
                    return RedirectToAction("AllocatedDEScannerJob", "ProvidedInfo");
                }

                int pageSize = clsGlobalCommon.PageSize;
                GetAllCheckListforDocUpload(pid);
                GetAddressProofDocs();
                model = repoPQVerifiedUploadDoc.GetCandidateUploadedDocList(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, SubCheckRowID, pid);
                var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(pid);
                Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
                Session["SecuritasRefID"] = CandDetail.CompanyRefNo;

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
        public JsonResult DeleteCandidateUploadedDocs(short id = 0, short SubCheckRowID = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    string FileName = repoPQVerifiedUploadDoc.DeleteUploadedDocsByID(id, SubCheckRowID);

                    string FldPathDoc = System.Configuration.ConfigurationManager.AppSettings["provideddocuments"].ToString();
                    string path = Server.MapPath(FldPathDoc + FileName);
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)//check file exsit or not
                    {
                        file.Delete();
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

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UploadCandidateDocument(int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            PQAddVerifiedUploadDocViewModel model = new PQAddVerifiedUploadDocViewModel();
            try
            {
                CreateMenuitemforDEScanner(PersonalRowID);
                model.PersonalRowID = PersonalRowID;
                model.SubCheckRowID = subCheckId;
                model.CheckFamilyRowID = ChFamilRowId;
                GetAllCheckListforDocUpload(PersonalRowID);
                ViewBag.GetDocumentList = repoDDL.PQAddressVerGetDocumentList(PersonalRowID, subCheckId);
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
        public ActionResult UploadCandidateDocument(PQAddVerifiedUploadDocViewModel model, string UploadHid, IEnumerable<HttpPostedFileBase> UploadDoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.NADoc == 1)
                    {
                        SavePQVerifiedUploadDoc(model.PersonalRowID, model.SubCheckRowID, "Provided", "NA", "provideddocuments", null, model.Remarks, model.NADoc);
                    }
                    else
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
                                    SavePQVerifiedUploadDoc(model.PersonalRowID, model.SubCheckRowID, "Provided", model.DocumentType, "provideddocuments", item, model.Remarks, model.NADoc);
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "No item found!";
                                    break;
                                }
                                count++;
                            }

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UploadCandidateDocument", "Provided", model.DocumentType, "Insert");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Document Uploaded", "Document uploaded");
                            #endregion

                            int PID = model.PersonalRowID;
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("UploadCandidateDocument", new { PersonalRowID = PID });
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Please select at least one document!";
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
            GetAllCheckListforDocUpload(model.PersonalRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UploadCandidateCaseDocument(int pid = 0)
        {
            AddPQVerifiedUploadCaseDocViewModel model = new AddPQVerifiedUploadCaseDocViewModel();
            try
            {
                model.PersonalRowID = pid;
                GetCaseDocumentList(pid);
                //GetAllCheckListforDocUpload(pid);
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
        public ActionResult UploadCandidateCaseDocument(AddPQVerifiedUploadCaseDocViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PersonalRowID > 0)
                    {
                        if (model.LOABool && model.LOADoc != null && model.LOADoc.ContentLength > 0)
                        {
                            SavePQVerifiedUploadCaseDoc(model.PersonalRowID, "Provided", "Letter Of Authorization", "provideddocuments", model.LOADoc, model.Remarks);
                        }
                        if (model.BGVPageBool && model.BGVPageDoc != null && model.BGVPageDoc.ContentLength > 0)
                        {
                            SavePQVerifiedUploadCaseDoc(model.PersonalRowID, "Provided", "BGV Page", "provideddocuments", model.BGVPageDoc, model.Remarks);
                        }
                        if (model.OtherBool && model.OtherDoc != null && model.OtherDoc.ContentLength > 0)
                        {
                            SavePQVerifiedUploadCaseDoc(model.PersonalRowID, "Provided", "Other Doc For Case", "provideddocuments", model.OtherDoc, model.Remarks);
                        }
                        if (model.NABool)
                        {
                            SavePQVerifiedUploadCaseDoc(model.PersonalRowID, "Provided", "NA", "provideddocuments", null, model.Remarks, model.NABool);
                        }

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UploadCandidateDocument", "Provided", model.DocumentType, "Insert");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCaseActionHistory(model.PersonalRowID, "BGV form or LOA document uploaded", "Case Document uploaded");
                        #endregion

                        int PID = model.PersonalRowID;
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("ManageUploadDocmentList", new { pid = PID });
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Please select at least one document!";
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
            //GetAllCheckListforDocUpload(model.PersonalRowID);
            return View(model);
        }

        #endregion

        #region ******* DE Allocation/Allocated  *******

        [SessionExpireFilterAttribute]
        public ActionResult DataEntryAllocation(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, short AllocateDEID = 0, short AllocateQCID = 0, short AllocateDEScan = 0, string PersonalIds = "", string RecievingfromDate = "", string RecievingToDate = "")
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                if (AllocateDEID > 0 && AllocateQCID > 0 && AllocateDEScan > 0 && !string.IsNullOrEmpty(PersonalIds))
                {
                    #region Update Personal Allocation Data Entry And Quailty Check

                    UpdatePQPersonalViewModel personalmodel = new UpdatePQPersonalViewModel();
                    DateTime currDateTime = DateTime.Now;
                    personalmodel.AllocatedToDE = AllocateDEID;
                    personalmodel.AllocatedToDEDate = currDateTime;
                    personalmodel.AllocatedToDEQC = AllocateQCID;
                    personalmodel.AllocatedToDEQCDate = currDateTime;
                    personalmodel.AllocatedToDEScan = AllocateDEScan;
                    personalmodel.AllocatedToDEScanDate = currDateTime;
                    personalmodel.AllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    int[] personalId = PersonalIds.Split(',').Select(str => int.Parse(str)).ToArray();
                    string DEScaName = repoTeamMember.GetTeamMemberNameById(AllocateDEScan);
                    string DEMemmber = repoTeamMember.GetTeamMemberNameById(AllocateDEID);
                    string DEQC = repoTeamMember.GetTeamMemberNameById(AllocateQCID);
                    int count = 0;
                    foreach (var item in personalId)
                    {
                        personalmodel.PersonalRowID = item;
                        #region Check TeamMembers Map with Client
                        personalmodel.ClientRowID = repoPQPersonal.GetClientDetailsByPersonalId(item);
                        bool result = repoPQClientTMember.IsClientDETeamMembersExist(personalmodel.ClientRowID, personalmodel.AllocatedToDEScan, personalmodel.AllocatedToDE, personalmodel.AllocatedToDEQC);

                        if (result)
                        {
                            repoPQPersonal.UpdatePQPersonalAllocateDEOrQCByID(personalmodel);
                            repoPQPersonal.SaveChanges();
                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(personalmodel.PersonalRowID, "DataEntryAllocation", "Allocated-DE-TM", "Allocate", "Update");
                            #endregion

                            #region Case Action history save
                            clsCommonMethods.AddCaseActionHistory(personalmodel.PersonalRowID, "Allocated-DE-TM", "Allocated To  DE-Scan (" + DEScaName + "), DE-TM (" + DEMemmber + "),  DE-QC (" + DEQC + ")");
                            #endregion
                        }
                        else
                        {
                            count++;
                        }
                        #endregion
                    }
                    if (count > 0)
                    {
                        ViewBag.ErrorMsg = count + " Candidate's not allocated!";
                    }

                    #endregion
                }
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (Session["Designation"].ToString() == "Team Leader-DE")
                {
                    BindClientListBaseOnLogin(teamMemerRowId);
                    model = repoPQPersonal.GetCandidateListForAllocation(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, RecievingfromDate, RecievingToDate);
                }

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
            GetDEMemberForAllocate();
            GetQCMemberForAllocate();
            GetDEScanMemberForAllocate();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult DataEntryREAllocationByDETL(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, short AllocateDEID = 0, short AllocateQCID = 0, short AllocateDEScan = 0, string PersonalIds = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string SearchType = "", string CaseStatus = "")
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                if ((AllocateDEID > 0 || AllocateQCID > 0 || AllocateDEScan > 0) && !string.IsNullOrEmpty(PersonalIds))
                {
                    string DEScaName = string.Empty;
                    string DEMemmber = string.Empty;
                    string DEQC = string.Empty;
                    #region Update Personal Allocation Data Entry And Quailty Check
                    if (AllocateDEScan > 0)
                    {
                        DEScaName = repoTeamMember.GetTeamMemberNameById(AllocateDEScan);
                    }
                    if (AllocateDEID > 0)
                    {
                        DEMemmber = repoTeamMember.GetTeamMemberNameById(AllocateDEID);
                    }
                    if (AllocateQCID > 0)
                    {
                        DEQC = repoTeamMember.GetTeamMemberNameById(AllocateQCID);
                    }
                    UpdatePQPersonalViewModel personalmodel = new UpdatePQPersonalViewModel();
                    DateTime currDateTime = DateTime.Now;
                    personalmodel.AllocatedToDE = AllocateDEID;
                    personalmodel.AllocatedToDEDate = currDateTime;
                    personalmodel.AllocatedToDEQC = AllocateQCID;
                    personalmodel.AllocatedToDEQCDate = currDateTime;
                    personalmodel.AllocatedToDEScan = AllocateDEScan;
                    personalmodel.AllocatedToDEScanDate = currDateTime;
                    personalmodel.AllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    int[] personalId = PersonalIds.Split(',').Select(str => int.Parse(str)).ToArray();
                    int count = 0;
                    foreach (var item in personalId)
                    {
                        personalmodel.PersonalRowID = item;
                        #region Check TeamMembers Map with Client
                        personalmodel.ClientRowID = repoPQPersonal.GetClientDetailsByPersonalId(item);
                        bool result = repoPQClientTMember.IsClientDETeamMembersExistForReAllocation(personalmodel.ClientRowID, personalmodel.AllocatedToDEScan, personalmodel.AllocatedToDE, personalmodel.AllocatedToDEQC);

                        if (result)
                        {
                            repoPQPersonal.UpdatePQPersonalReAllocateDEOrQCByID(personalmodel);
                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(personalmodel.PersonalRowID, "DataEntryREAllocation", "Allocated-DE-TM", "Allocate", "Update");
                            #endregion

                            #region Case Action history save
                            if (!string.IsNullOrEmpty(DEScaName))
                            {
                                clsCommonMethods.AddCaseActionHistory(personalmodel.PersonalRowID, "ReAllocated-DE-Scan", "ReAllocated To DE-Scan (" + DEScaName + ")");
                            }
                            if (!string.IsNullOrEmpty(DEMemmber))
                            {
                                clsCommonMethods.AddCaseActionHistory(personalmodel.PersonalRowID, "ReAllocated-DE-TM", "ReAllocated To DE-TM (" + DEMemmber + ")");
                            }
                            if (!string.IsNullOrEmpty(DEQC))
                            {
                                clsCommonMethods.AddCaseActionHistory(personalmodel.PersonalRowID, "ReAllocated-DE-TM-QC", "ReAllocated To DE-QC (" + DEQC + ")");
                            }
                            #endregion
                        }
                        else
                        {
                            count++;
                        }
                        #endregion
                    }
                    if (count > 0)
                    {
                        ViewBag.ErrorMsg = count + " Candidate's not reallocated!";
                    }

                    #endregion
                }
                int pageSize = clsGlobalCommon.PageSize;
                model = repoPQPersonal.GetAllocatedCandidateListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, AllocateDEID, AllocateQCID, AllocateDEScan, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, SearchType, CaseStatus);

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
            if (Session["Designation"].ToString() == "Team Leader-DE")
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);
            }
            else
            {
                BindClientList();
            }
            GetDEMemberForAllocate();
            GetQCMemberForAllocate();
            GetDEScanMemberForAllocate();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult DataEntryAllocated(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, short AllocateDEID = 0, short AllocateQCID = 0, short AllocateDEScan = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string SearchType = "", string CaseStatus = "")
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                CaseStatusOptionDropDown();
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = 0;
                if (Session["Designation"].ToString() == "Team Leader-DE")
                {
                    teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                    BindClientListBaseOnLogin(teamMemerRowId);
                    model = repoPQPersonal.GetAllocatedCandidateListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, AllocateDEID, AllocateQCID, AllocateDEScan, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, SearchType, CaseStatus);
                }
                if (Session["Designation"].ToString() == "Manager-DE")
                {
                    BindClientList();
                    model = repoPQPersonal.GetAllocatedCandidateListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, AllocateDEID, AllocateQCID, AllocateDEScan, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, SearchType);
                }
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

        #endregion

        #region******* Manage DataEntry/QuailityCheck Job *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ReAllocationDEQC(int id = 0, short ClientRowID = 0)
        {
            try
            {
                int res = 0;
                if (id > 0)
                {
                    repoPQPersonal.UpdateCadidateAllocationByID(id);
                    res = repoPQPersonal.SaveChanges();
                    if (res > 0)
                    {
                        return RedirectToAction("DataEntryAllocation", new { ClientRowID = ClientRowID });
                    }
                    else
                    {
                        return RedirectToAction("DataEntryAllocated", new { ClientRowID = ClientRowID });
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View("DataEntryAllocated");
        }

        [SessionExpireFilterAttribute]
        public ActionResult AllocatedDataEntryJob(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string CaseStatus = "", byte tatHours = 0)
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = 0;
                if (Session["Designation"].ToString() == "Team Member-DE")
                {
                    teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                    BindClientListBaseOnLogin(teamMemerRowId);
                    model = repoPQPersonal.GetAllocatedCandidateListForDataEntry(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, CaseStatus, tatHours);
                }
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
        public JsonResult CompletedDataEntryJobs(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoPQPersonal.UpdatePQPersonalForDE(id, "Completed-DE");
                    int Res = repoPQPersonal.SaveChanges();

                    if (Res > 0)
                    {
                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(id, "CompletedDataEntryJobs", "WIP", "Data Entry", "Data Entry complete");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCaseActionHistory(id, "WIP", "Data Entry job completed");
                        #endregion
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


        [SessionExpireFilterAttribute]
        public ActionResult ManageDataEntryJob(int id = 0)
        {
            CaseActionHistoryListPagedModel model = new CaseActionHistoryListPagedModel();
            try
            {
                if (id == 0)
                {
                    TempData["ErrorMsg"] = "Invalid id!";
                    RedirectToAction("AllocatedDataEntryJob", "ProvidedInfo");

                }

                #region ******* Create Left Menu Item (Checks) *******

                CreateMenuitemforDataEntryOperator(id);

                #endregion

                GetCaseDocumentList(id);
                model = repoCaseActionHistory.GetCaseActionHistories(id);

                var CandDetail = repoPQPersonal.GetPQPersonalInfoForSession(id);
                string ssnCandidateName = CandDetail.Name.Trim();
                if (!string.IsNullOrEmpty(CandDetail.MiddleName))
                {
                    ssnCandidateName += " " + CandDetail.MiddleName.Trim();
                }
                if (!string.IsNullOrEmpty(CandDetail.LastName))
                {
                    ssnCandidateName += " " + CandDetail.LastName.Trim();
                }

                Session["CandidateName"] = ssnCandidateName;
                Session["SecuritasRefID"] = CandDetail.CompanyRefNo;
                Session["ClientSplInst"] = repoPQClient.GetClientSpecialInstructionByID(CandDetail.ClientRowID);

                Session["scnCompanyRefNo"] = CandDetail.CompanyRefNo;
                Session["scnCandidateCode"] = CandDetail.CandidateCode;
                Session["scnCandTitle"] = CandDetail.CandTitle;
                Session["scnName"] = CandDetail.Name;
                Session["scnMiddleName"] = CandDetail.MiddleName;
                Session["scnLastName"] = CandDetail.LastName;
                Session["scnFatherName"] = CandDetail.FatherName;
                Session["scnFatherMiddleName"] = CandDetail.FatherMiddleName;
                Session["scnFatherLastName"] = CandDetail.FatherLastName;
                Session["scnSpouseName"] = CandDetail.SpouseName;
                Session["scnSpouseMiddleName"] = CandDetail.SpouseMiddleName;
                Session["scnSpouseLastName"] = CandDetail.SpouseLastName;
                Session["scnDOB"] = CandDetail.DOB;
                Session["scnGender"] = CandDetail.Gender;
                Session["scnMobileNo"] = CandDetail.MobileNo;
                Session["scnEmailID"] = CandDetail.EmailID;
                Session["scnPanCardNo"] = CandDetail.PanCardNo;
                Session["scnPassportNo"] = CandDetail.PassportNo;
                Session["scnAadhaarCardNo"] = CandDetail.AadhaarCardNo;
                Session["scnDrivingLicenseNo"] = CandDetail.DrivingLicenseNo;
                Session["scnVoterIDCardNo"] = CandDetail.VoterIDCardNo;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            BindClientList();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult AllocatedQualityCheckJob(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string SearchType = "", string CaseStatus = "", byte tatHours = 0)
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = 0;
                if (Session["Designation"].ToString() == "Team Member-DE-QC")
                {
                    teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                    BindClientListBaseOnLogin(teamMemerRowId);
                    model = repoPQPersonal.GetAllocatedCandidateListForQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, SearchType, CaseStatus, tatHours);
                }
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
        public JsonResult CompletedDEQualityCheckJobs(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoPQPersonal.UpdatePQPersonalForDEQualityCheck(id, "Completed-QC");
                    int Res = repoPQPersonal.SaveChanges();

                    if (Res > 0)
                    {
                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(id, "CompletedDEQualityCheckJobs", "WIP", "Quality Check", "Quality Check complete");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCaseActionHistory(id, "WIP", "Quality Check job completed");
                        #endregion
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


        [SessionExpireFilterAttribute]
        public ActionResult ManageQualityCheckJob(int id = 0)
        {
            CaseActionHistoryListPagedModel model = new CaseActionHistoryListPagedModel();
            try
            {
                if (id == 0)
                {
                    RedirectToAction("AllocatedQualityCheckJob", "ProvidedInfo");
                    ViewBag.ErrorMsg = "Invalid id!";
                }

                #region Create Left Menu Item (Checks)

                CreateMenuitemforQualityCheck(id);

                #endregion

                model = repoCaseActionHistory.GetCaseActionHistories(id);

                var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(id);
                Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
                Session["ClientSplInst"] = repoPQClient.GetClientSpecialInstructionByID(CandDetail.ClientRowID);

                BindClientList();
                GetCaseDocumentList(id);
                if (model == null)
                {
                    RedirectToAction("AllocatedQualityCheckJob", "ProvidedInfo");
                    ViewBag.ErrorMsg = "Invalid id!";
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

        #region ******* Employment/Education Checks Researcher Jobs ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageResearchEducationChecks(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingDate = "", string CompletedDate = "", string DCheckStatus = "", string CaseStatus = "")
        {
            PQEducationResearchListPagedModel model = new PQEducationResearchListPagedModel();
            try
            {
                CheckStatusOptionDropDown();
                CaseStatusOptionDropDown();
                int pageSize = clsGlobalCommon.PageSize;
                if (Session["Designation"].ToString() == "Team Member-Edu-Research")
                {
                    BindClientList();
                    model = repoEducationResearch.GetEducationCheckListForResearch(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingDate, CompletedDate, DCheckStatus, CaseStatus);
                }
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
        public JsonResult CompleteEducationResearchJobs(string id = "")
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    int[] ids = id.Split('_').Select(str => int.Parse(str)).ToArray();
                    UpdatePQEducationResearchViewModel reModel = new UpdatePQEducationResearchViewModel();
                    reModel.EduResearchRowID = ids[0];
                    reModel.UpdatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    reModel.UpdatedNameDesig = Session["TeamMemberName"].ToString() + " (" + Session["Designation"].ToString() + ")";
                    reModel.UpdatedOn = DateTime.Now;

                    //update Employment research table and Get More ids for check status and action history ang log save 
                    PQUpdateEducationResearcherViewModel eModel = new PQUpdateEducationResearcherViewModel();
                    eModel = repoEducationResearch.UpdateEducationResearchInfo(reModel, ids[1]);

                    #region Save LogTransaction Details
                    clsCommonMethods.AddPQLogTrasaction(eModel.PersonalRowID, "CompleteEducationResearchJobs", "WIP-Pending", eModel.UniqueComponentID, "Update");
                    #endregion

                    //Check Action History Save 
                    clsCommonMethods.AddCheckActionHistory(eModel.PersonalRowID, eModel.SubCheckRowID, "Edu-Research Job Complete", "Other Institute Details Uploded");

                    result = true;
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

        [SessionExpireFilterAttribute]
        public ActionResult ManageResearchEmploymentChecks(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingDate = "", string CompletedDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "")
        {
            PQEmploymentResearchListPagedModel model = new PQEmploymentResearchListPagedModel();
            try
            {
                CaseStatusOptionDropDown();
                CheckStatusOptionDropDown();
                int pageSize = clsGlobalCommon.PageSize;
                if (Session["Designation"].ToString() == "Team Member-Emp-Research")
                {
                    BindClientList();
                    model = repoEmploymentResearch.GetEmploymentCheckListForResearch(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingDate, CompletedDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
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
        public JsonResult CompleteEmploymentResearchJobs(string id = "")
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    int[] ids = id.Split('_').Select(str => int.Parse(str)).ToArray();
                    UpdatePQEmploymentResearchViewModel reModel = new UpdatePQEmploymentResearchViewModel();
                    reModel.EmpResearchRowID = ids[0];
                    reModel.UpdatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    reModel.UpdatedNameDesig = Session["TeamMemberName"].ToString() + " (" + Session["Designation"].ToString() + ")";
                    reModel.UpdatedOn = DateTime.Now;

                    //update Employment research table and Get More ids for check status and action history ang log save 
                    PQUpdateEmploymentResearcherViewModel eModel = new PQUpdateEmploymentResearcherViewModel();
                    eModel = repoEmploymentResearch.UpdateEmploymentResearchInfo(reModel, ids[1]);

                    #region Save LogTransaction Details
                    clsCommonMethods.AddPQLogTrasaction(eModel.PersonalRowID, "CompleteEmploymentResearchJobs", "WIP-Pending", eModel.UniqueComponentID, "Insert");
                    #endregion

                    //Check Action History Save 
                    clsCommonMethods.AddCheckActionHistory(eModel.PersonalRowID, eModel.SubCheckRowID, "WIP-Pending", "Emp-Research Job Complete, Other Employer Details Uploded");

                    result = true;
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

        #region ******* Manage Employment YTR Checks *******

        [SessionExpireFilterAttribute]
        public ActionResult ManageEmploymentYTRChecks(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string YTRDate = "")
        {
            PQEmploymentListPagedModel model = new PQEmploymentListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                if (Session["Designation"].ToString() == "Team Leader-DE")
                {
                    short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                    BindClientListBaseOnLogin(teamMemerRowId);

                    model = repoEmploymentInfo.GetAllYTRChecksListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, YTRDate);
                }
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
        public JsonResult EmploymentYTRCheckClear(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    PQUpdateEmploymentResearcherViewModel eModel = new PQUpdateEmploymentResearcherViewModel();
                    eModel.EmploymentRowID = id;
                    eModel.CheckStatus = "WIP-Pending";
                    eModel.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    eModel.ModifiedDate = DateTime.Now;
                    eModel = repoEmploymentInfo.UpdateEmploymentInfoByResearcher(eModel);

                    #region Save LogTransaction Details
                    clsCommonMethods.AddPQLogTrasaction(eModel.PersonalRowID, "EmploymentYTRCheckClear", eModel.CheckStatus, eModel.UniqueComponentID, "Clear YTR By DETL");
                    #endregion

                    //Check Action History Save 
                    clsCommonMethods.AddCheckActionHistory(eModel.PersonalRowID, eModel.SubCheckRowID, eModel.CheckStatus, "YTR Clear By DETL");

                    result = true;
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

        #region ******* Case Document List *******

        public void GetCaseDocumentList(int personalRowID = 0)
        {
            try
            {
                ViewBag.CaseDocList = repoPQVerifiedUploadCaseDoc.GetCaseDocumentListByPersonalId(personalRowID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetCheckActionHistories(int PersonalRowID = 0, short subCheckId = 0)
        {
            try
            {
                ViewBag.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult GetCheckActionHistories(short subCheckId = 0, int Pid = 0)
        {
            try
            {
                ViewBag.CheckActionHistories = repoDDL.GetCheckActionHistory(Pid, subCheckId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return PartialView("_CheckActionHistories");
        }

        #endregion

        #region ******* Uploaded Docs Display With Checks For Cadidate ******
        [SessionExpireFilterAttribute]
        public ActionResult UploadedCandidateDocs(int page = 1, string sort = "", string sortDir = "asc", string Search = "", int id = 0)
        {
            PQVerifiedUploadDocListPagedModel model = new PQVerifiedUploadDocListPagedModel();
            try
            {
                if (id == 0)
                {
                    ViewBag.ErrorMsg = "Invalid id!";
                    return RedirectToAction("AllocatedDEScannerJob", "ProvidedInfo");
                }

                int pageSize = clsGlobalCommon.PageSize;
                GetAddressProofDocs();
                model = repoPQVerifiedUploadDoc.GetCandidateUploadedDocList(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, 0, id);
                //var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(id);
                //Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
                //Session["SecuritasRefID"] = CandDetail.CompanyRefNo;

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View(model);
        }

        #endregion

        #region ******* Data Entry Team Member *******

        #region******* Update Address Information By DataEntry *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult AddAddressInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            PQAddressViewModel model = new PQAddressViewModel();
            try
            {
                BindCountry();
                GetAddressProofDocs();
                model = repoAddressInfo.GetAddressInfoForDataEntry(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    model = new PQAddressViewModel();
                    ////model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                    model.ClientRowID = ClientRowId;
                    model.CheckFamilyRowID = ChFamilRowId;
                    model.SubCheckRowID = subCheckId;
                    model.PersonalRowID = PersonalRowID;

                    model.AV_Cand_Name = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                }
                else
                {
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                }
                ViewBag.ListAddress = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);
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
        public ActionResult AddAddressInfo(PQAddressViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    DateTime oDate = DateTime.Now;
                    model.CreatedDate = oDate;
                    if (model.AddressRowID > 0)
                    {
                        #region Update Address Information

                        repoAddressInfo.UpdateAddressInformation(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddAddressInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        int PID = model.PersonalRowID;
                        ModelState.Clear();
                        return RedirectToAction("ManageDataEntryJob", new { id = PID });

                        #endregion
                    }
                    else
                    {
                        #region Add Address Information

                        if (model.ClientRowID > 0 && model.PersonalRowID > 0)
                        {
                            var subCheck = repoPQCandidateCheck.GetTATForOutDateById(model.ClientRowID, model.PersonalRowID, model.SubCheckRowID);
                            PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);

                            #region OrderDate And DeliveryDate

                            model.OutDate = GetDeliveryDate(oDate, subCheck.TAT, client);
                            model.InternalOutDate = GetDeliveryDate(oDate, subCheck.InternalTAT, client);
                            #endregion

                            #region Generate UniqueComponentId

                            int TotalRecord = repoAddressInfo.GetAllAddressByClientId(model.ClientRowID);
                            string clCode = client.ClientCode1.Substring(0, 3).ToUpper();
                            TotalRecord++;
                            model.UniqueComponentID = string.Concat(clCode, "-ADD-", DateTime.Now.ToString("yyyyMMdd"), "-", Convert.ToString(TotalRecord));

                            #endregion

                            model.AV_Sec_Ref_No = Session["SecuritasRefID"].ToString();
                            model.Status = 1;
                            if (string.IsNullOrEmpty( model.AV_Cand_Name))
                            {
                                model.AV_Cand_Name = Convert.ToString(Session["CandidateName"]);
                            }
                            repoAddressInfo.AddAddressInformation(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddAddressInfo", model.CheckStatus, model.UniqueComponentID, "Insert");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageDataEntryJob", new { id = PID });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Address info could not be blank!");
                        }

                        #endregion
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
            GetAddressProofDocs();
            ViewBag.ListAddress = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ViewAddressInfo(int id)
        {
            ViewAddressViewModel model = new ViewAddressViewModel();
            try
            {
                var Addressdetailes = repoAddressInfo.GetAddressInfoForQualityCheck(id);

                if (Addressdetailes == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                model.ClientRowID = Addressdetailes.ClientRowID;
                model.CheckFamilyRowID = Addressdetailes.CheckFamilyRowID;
                model.SubCheckRowID = Addressdetailes.SubCheckRowID;
                model.PersonalRowID = Addressdetailes.PersonalRowID;
                model.AddressRowID = Addressdetailes.AddressRowID;

                ViewBag.AddressDetails = Addressdetailes;

                ViewBag.ListAddress = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
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
        public ActionResult ViewAddressInfo(string Approved, string Rejected, ViewAddressViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AddressRowID > 0)
                    {
                        #region Update Address Information

                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewAddressInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            if (Session["Designation"].ToString() == "Team Leader-DE")
                            {
                                repoAddressInfo.ViewAddressInfoDETL(model);
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageReviewRequestedChecksForDETL", "Insuff");
                            }
                            if (Session["Designation"].ToString() == "Team Member-DE-QC")
                            {
                                if (Approved == "true")
                                {
                                    repoAddressInfo.UpdateAddressInfoRejectionByDEQC(model, true);
                                }
                                else
                                {
                                    repoAddressInfo.UpdateAddressInfoRejectionByDEQC(model);
                                }
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageRejectedChecksByDepTMForDEQC", "Insuff");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Remark could not be blank!");
                        }
                        #endregion
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid model!");
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
            ViewBag.ListAddress = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update Employment Information By DataEntry *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult AddEmploymentInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            AddEmploymentViewModel model = new AddEmploymentViewModel();
            try
            {
                model = repoEmploymentInfo.GetEmploymentInfoForDataEntry(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    model = new AddEmploymentViewModel();
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                    model.ClientRowID = ClientRowId;
                    model.CheckFamilyRowID = ChFamilRowId;
                    model.SubCheckRowID = subCheckId;
                    model.PersonalRowID = PersonalRowID;
                    model.EV_CandidateName = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                    model.EV_EmployeeName = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                }
                else
                {
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                }
                GetEmploymentList();
                ViewBag.ListEmployment = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);
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
        public ActionResult AddEmploymentInfo(AddEmploymentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    DateTime oDate = DateTime.Now;
                    model.CreatedDate = DateTime.Now;
                    if (string.IsNullOrEmpty(model.EV_CandidateName))
                    {
                        model.EV_CandidateName = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                    }
                    if (model.EmploymentRowID > 0)
                    {
                        #region Update Employment Information
                        if (!string.IsNullOrEmpty(model.EV_OrganisationName))
                        {
                            repoEmploymentInfo.UpdateEmploymentInfoByDataEntry(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddEmploymentInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                            #endregion

                            #region Save EmploymentResearchDetails
                            if (model.CheckStatus == "Research")
                            {
                                int employmentRowId = repoEmploymentInfo.GetEmploymentIDByUniqueComponentID(model.PersonalRowID, model.UniqueComponentID);
                                SaveEmploymentResearchDetails(employmentRowId, model.OtherEmployer);
                            }
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageDataEntryJob", new { id = PID });
                        }
                        #endregion
                    }
                    else
                    {
                        #region Add Employment Information
                        if (model.ClientRowID > 0 && model.PersonalRowID > 0)
                        {
                            if (!string.IsNullOrEmpty(model.EV_OrganisationName))
                            {
                                if (string.IsNullOrEmpty(model.EV_CandidateName))
                                {
                                    model.EV_CandidateName = Convert.ToString(Session["CandidateName"]);
                                }
                                model.EV_SecuritasReferenceID = Session["SecuritasRefID"].ToString();
                                var subCheck = repoPQCandidateCheck.GetTATForOutDateById(model.ClientRowID, model.PersonalRowID, model.SubCheckRowID);
                                PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);

                                #region OrderDate And DeliveryDate                                    
                                model.OutDate = GetDeliveryDate(oDate, subCheck.TAT, client);
                                model.InternalOutDate = GetDeliveryDate(oDate, subCheck.InternalTAT, client);
                                #endregion

                                #region Generate UniqueComponentId

                                int TotalRecord = repoEmploymentInfo.GetAllEmploymentByClientId(model.ClientRowID);
                                string clCode = client.ClientCode1.Substring(0, 3).ToUpper();
                                TotalRecord++;
                                model.UniqueComponentID = string.Concat(clCode, "-EMP-", DateTime.Now.ToString("yyyyMMdd"), "-", Convert.ToString(TotalRecord));
                                #endregion

                                model.Status = 1;
                                repoEmploymentInfo.AddEmploymentInformation(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddEmploymentInfo", model.CheckStatus, model.UniqueComponentID, "Insert");
                                #endregion

                                #region Case/Check Action History Save

                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);

                                #endregion

                                #region Save Employment ResearchDetails
                                if (model.CheckStatus == "Research")
                                {
                                    int employmentRowId = repoEmploymentInfo.GetEmploymentIDByUniqueComponentID(model.PersonalRowID, model.UniqueComponentID);
                                    SaveEmploymentResearchDetails(employmentRowId, model.OtherEmployer);
                                }
                                #endregion

                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                int PID = model.PersonalRowID;
                                ModelState.Clear();
                                return RedirectToAction("ManageDataEntryJob", new { id = PID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Name of organisation antecedent not mapped and it is mandatory!";
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Employment info could not be blank!");
                        }
                        #endregion
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
            GetEmploymentList();
            ViewBag.ListEmployment = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult ViewEmploymentInfo(int id)
        {
            ViewEmploymentViewModel model = new ViewEmploymentViewModel();
            try
            {
                var EmployeeDetails = repoEmploymentInfo.GetEmploymentInfoForQC(id);
                if (EmployeeDetails == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                model.ClientRowID = EmployeeDetails.ClientRowID;
                model.CheckFamilyRowID = EmployeeDetails.CheckFamilyRowID;
                model.SubCheckRowID = EmployeeDetails.SubCheckRowID;
                model.PersonalRowID = EmployeeDetails.PersonalRowID;
                model.EmploymentRowID = EmployeeDetails.EmploymentRowID;

                ViewBag.EmployeeDetails = EmployeeDetails;

                ViewBag.ListEmployment = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
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
        public ActionResult ViewEmploymentInfo(string Approved, string Rejected, ViewEmploymentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmploymentRowID > 0)
                    {
                        #region Update Employment Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewEmploymentInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            if (Session["Designation"].ToString() == "Team Leader-DE")
                            {
                                repoEmploymentInfo.ViewEmploymentInfoDETL(model);
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageReviewRequestedChecksForDETL", "Insuff");
                            }
                            if (Session["Designation"].ToString() == "Team Member-DE-QC")
                            {
                                if (Approved == "true")
                                {
                                    repoEmploymentInfo.ViewEmploymentInfoByDataEntry(model, true);
                                }
                                else
                                {
                                    repoEmploymentInfo.ViewEmploymentInfoByDataEntry(model);
                                }                               
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageRejectedChecksByDepTMForDEQC", "Insuff");
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid model!");
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
            ViewBag.ListEmployment = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update Education Information By DataEntry *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult AddEducationInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            AddPQEducationViewModel model = new AddPQEducationViewModel();
            try
            {
                model = repoEducationInfo.GetEducationInfoForDataEntry(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    model = new AddPQEducationViewModel();
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                    model.ClientRowID = ClientRowId;
                    model.CheckFamilyRowID = ChFamilRowId;
                    model.SubCheckRowID = subCheckId;
                    model.PersonalRowID = PersonalRowID;
                    model.EV_Cand_Name = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                    model.EV_Cand_Name_Supp_Edu_Doc = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                }
                else
                {

                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                }
                ViewBag.ListEducation = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            GetDegreeList();
            GetCollegeList();
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddEducationInfo(AddPQEducationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    DateTime oDate = DateTime.Now;
                    model.CreatedDate = oDate;
                    if (model.EducationRowID > 0)
                    {
                        #region Update Education Information

                        if (model.EV_Colg_Schl_Inst_Name > 0)
                        {
                            repoEducationInfo.UpdateEducationInfoByDataEntry(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddEducationInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                            #endregion

                            #region Save EducationResearchDetails
                            if (model.CheckStatus == "Research")
                            {
                                int educationRowId = repoEducationInfo.GetEducationIDByUniqueComponentID(model.PersonalRowID, model.UniqueComponentID);
                                SaveEducationResearchDetails(educationRowId, model.OtherInstitute);
                            }
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageDataEntryJob", new { id = PID });
                        }

                        #endregion
                    }
                    else
                    {
                        #region Add Education Information
                        if (model.ClientRowID > 0 && model.PersonalRowID > 0)
                        {
                            if (model.EV_Colg_Schl_Inst_Name > 0)
                            {
                                var subCheck = repoPQCandidateCheck.GetTATForOutDateById(model.ClientRowID, model.PersonalRowID, model.SubCheckRowID);
                                PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);

                                #region OrderDate And DeliveryDate
                                model.OutDate = GetDeliveryDate(oDate, subCheck.TAT, client);
                                model.InternalOutDate = GetDeliveryDate(oDate, subCheck.InternalTAT, client);
                                #endregion

                                #region Generate UniqueComponentId

                                int TotalRecord = repoEducationInfo.GetAllEducationsByClientId(model.ClientRowID);
                                string clCode = client.ClientCode1.Substring(0, 3).ToUpper();
                                TotalRecord++;
                                model.UniqueComponentID = string.Concat(clCode, "-EDU-", DateTime.Now.ToString("yyyyMMdd"), "-", Convert.ToString(TotalRecord));
                                #endregion

                                #region Affliatiated from List

                                IEnumerable<SelectListItem> AffliatiatedfromList = new List<SelectListItem> {
                                    new SelectListItem { Text = "UGC", Value = "1" },
                                    new SelectListItem { Text = "AICTE", Value = "2" },
                                    new SelectListItem { Text = "DEC", Value = "3" },
                                    new SelectListItem { Text = "AIMA", Value = "4" },
                                    new SelectListItem { Text = "Others", Value = "0" },
                                    };
                                string affValue = AffliatiatedfromList.Where(a => a.Text == model.strEV_Affl_University_Name).FirstOrDefault().Value;
                                model.EV_Affl_University_Name = Convert.ToInt16(affValue);

                                #endregion

                                if (string.IsNullOrEmpty(model.EV_Cand_Name))
                                {
                                    model.EV_Cand_Name = Convert.ToString(Session["CandidateName"]);
                                }
                                model.EV_Sec_Ref_Id = Convert.ToString(Session["SecuritasRefID"]);
                                model.Status = 1;
                                repoEducationInfo.AddEducationInformation(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddEducationInfo", model.CheckStatus, model.UniqueComponentID, "Insert");
                                #endregion

                                #region Save EducationResearchDetails
                                if (model.CheckStatus == "Research")
                                {
                                    int educationRowId = repoEducationInfo.GetEducationIDByUniqueComponentID(model.PersonalRowID, model.UniqueComponentID);
                                    SaveEducationResearchDetails(educationRowId, model.OtherInstitute);
                                }
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                                #endregion

                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                int PID = model.PersonalRowID;
                                ModelState.Clear();
                                return RedirectToAction("ManageDataEntryJob", new { id = PID });
                            }

                        }
                        else
                        {
                            ModelState.AddModelError("", "Education info could not be blank!");
                        }
                        #endregion
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
            GetDegreeList();
            GetCollegeList();
            ViewBag.ListEducation = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult ViewEducationInfo(int id)
        {
            ViewEducationViewModel model = new ViewEducationViewModel();
            try
            {
                var EducationDetails = repoEducationInfo.GetEducationInfoForQualityCheck(id);

                if (EducationDetails == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                model.ClientRowID = EducationDetails.ClientRowID;
                model.CheckFamilyRowID = EducationDetails.CheckFamilyRowID;
                model.SubCheckRowID = EducationDetails.SubCheckRowID;
                model.PersonalRowID = EducationDetails.PersonalRowID;
                model.EducationRowID = EducationDetails.EducationRowID;

                ViewBag.EducationDetails = EducationDetails;

                ViewBag.ListEducation = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
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
        public ActionResult ViewEducationInfo(string Approved, string Rejected, PQUpdateEducationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EducationRowID > 0)
                    {
                        #region Update Education Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewEducationInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            if (Session["Designation"].ToString() == "Team Leader-DE")
                            {
                                repoEducationInfo.ViewEducationInfoDETL(model);
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageReviewRequestedChecksForDETL", "Insuff");
                            }
                            if (Session["Designation"].ToString() == "Team Member-DE-QC")
                            {
                                if (Approved == "true")
                                {
                                    repoEducationInfo.UpdateEducationRejectionByDEQC(model, true);
                                }
                                else
                                {
                                    repoEducationInfo.UpdateEducationRejectionByDEQC(model);
                                }
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageRejectedChecksByDepTMForDEQC", "Insuff");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Remark could not be blank!");
                        }
                        #endregion
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid model!");
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

            ViewBag.ListEducation = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update Criminal Information By DataEntry *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult AddCriminalInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            AddPQCriminalViewModel model = new AddPQCriminalViewModel();
            try
            {
                model = repoCriminalInfo.GetCriminalInfoForDataEntry(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    model = new AddPQCriminalViewModel();
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                    model.ClientRowID = ClientRowId;
                    model.CheckFamilyRowID = ChFamilRowId;
                    model.SubCheckRowID = subCheckId;
                    model.PersonalRowID = PersonalRowID;
                    model.CRV_Cand_Name = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                    model.CRV_First_Name = Session["scnName"] != null ? Session["scnName"].ToString() : "";
                    model.CRV_Last_Name = Session["scnLastName"] != null ? Session["scnLastName"].ToString() : "";
                    model.CRV_Father_Name = Session["scnFatherName"] != null ? Session["scnFatherName"].ToString() : "";
                    if (Session["scnDOB"] != null)
                    {
                        model.CRV_DOB = Convert.ToDateTime(Session["scnDOB"]);
                    }

                    model.CRV_Gender = Session["scnGender"] != null ? Session["scnGender"].ToString() : "";
                }
                else
                {
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                }
                ViewBag.ListCriminal = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);
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
        public ActionResult AddCriminalInfo(AddPQCriminalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    DateTime oDate = DateTime.Now;
                    model.CreatedDate = oDate;

                    if (model.CriminalRowID > 0)
                    {
                        #region Update Criminal Information 

                        repoCriminalInfo.UpdateCriminalInforByDataEntry(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddCriminalInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        int PID = model.PersonalRowID;
                        ModelState.Clear();
                        return RedirectToAction("ManageDataEntryJob", new { id = PID });

                        #endregion
                    }
                    else
                    {
                        #region Add Criminal Information
                        if (model.ClientRowID > 0 && model.PersonalRowID > 0)
                        {
                            model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                            var subCheck = repoPQCandidateCheck.GetTATForOutDateById(model.ClientRowID, model.PersonalRowID, model.SubCheckRowID);
                            PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);

                            #region OrderDate And DeliveryDate

                            model.OutDate = GetDeliveryDate(oDate, subCheck.TAT, client);
                            model.InternalOutDate = GetDeliveryDate(oDate, subCheck.InternalTAT, client);
                            #endregion

                            #region Generate UniqueComponentId

                            int TotalRecord = repoCriminalInfo.GetAllCriminalByClientId(model.ClientRowID);
                            string clCode = client.ClientCode1.Substring(0, 3).ToUpper();
                            TotalRecord++;
                            model.UniqueComponentID = string.Concat(clCode, "-CRI-", DateTime.Now.ToString("yyyyMMdd"), "-", Convert.ToString(TotalRecord));

                            #endregion

                            if (string.IsNullOrEmpty(model.CRV_Cand_Name))
                            {
                                model.CRV_Cand_Name = Convert.ToString(Session["CandidateName"]);
                            }
                            model.CRV_Sec_Ref_No = Convert.ToString(Session["SecuritasRefID"]);
                            model.Status = 1;
                            repoCriminalInfo.AddCriminalInformation(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddCriminalInfo", model.CheckStatus, model.UniqueComponentID, "Insert");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageDataEntryJob", new { id = PID });
                        }
                        else
                        {
                            ModelState.AddModelError("", "Criminal info could not be blank!");
                        }
                        #endregion
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
            ViewBag.ListCriminal = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult ViewCriminalInfo(int id)
        {
            ViewCriminalViewModel model = new ViewCriminalViewModel();
            try
            {
                var Criminaldetails = repoCriminalInfo.GetCriminalInfoForQualityCheck(id);
                if (Criminaldetails == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                model.ClientRowID = Criminaldetails.ClientRowID;
                model.CheckFamilyRowID = Criminaldetails.CheckFamilyRowID;
                model.SubCheckRowID = Criminaldetails.SubCheckRowID;
                model.PersonalRowID = Criminaldetails.PersonalRowID;
                model.CriminalRowID = Criminaldetails.CriminalRowID;

                ViewBag.CriminalDetails = Criminaldetails;

                ViewBag.ListCriminal = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
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
        public ActionResult ViewCriminalInfo(string Approved, string Rejected, ViewCriminalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CriminalRowID > 0)
                    {
                        #region Update Criminal Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewCriminalInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            if (Session["Designation"].ToString() == "Team Leader-DE")
                            {
                                repoCriminalInfo.ViewCriminaInfoDETL(model);
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageReviewRequestedChecksForDETL", "Insuff");
                            }
                            if (Session["Designation"].ToString() == "Team Member-DE-QC")
                            {
                                if (Approved == "true")
                                {
                                    repoCriminalInfo.UpdateCriminalRejectionByDEQC(model, true);
                                }
                                else
                                {
                                    repoCriminalInfo.UpdateCriminalRejectionByDEQC(model);
                                }
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageRejectedChecksByDepTMForDEQC", "Insuff");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Remark could not be blank!");
                        }
                        #endregion
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid model!");
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
            ViewBag.ListCriminal = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update National Identity Information By DataEntry *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult AddNationalIdentityInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            AddPQNationalIdentityViewModel model = new AddPQNationalIdentityViewModel();
            try
            {
                model = repoNationalIdentInfo.GetNationalIdentityInfoForDataEntry(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    model = new AddPQNationalIdentityViewModel();
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                    model.ClientRowID = ClientRowId;
                    model.CheckFamilyRowID = ChFamilRowId;
                    model.SubCheckRowID = subCheckId;
                    model.PersonalRowID = PersonalRowID;

                    model.NIC_Cand_Name = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                    if (Session["scnDOB"] != null)
                    {
                        model.NIC_DOB = Convert.ToDateTime(Session["scnDOB"]);

                        model.NIC_DOB1 = Convert.ToDateTime(Session["scnDOB"]);
                    }
                    model.NIC_Gender = Session["scnGender"] != null ? Session["scnGender"].ToString() : "";
                    model.NIC_Aadhar_Card_No = Session["scnAadhaarCardNo"] != null ? Session["scnAadhaarCardNo"].ToString() : "";
                    model.NIC_Dvng_Liscense_No = Session["scnDrivingLicenseNo"] != null ? Session["scnDrivingLicenseNo"].ToString() : "";
                    model.NIC_Voter_Id_No = Session["scnVoterIDCardNo"] != null ? Session["scnVoterIDCardNo"].ToString() : "";
                    model.NIC_Pan_No = Session["scnPanCardNo"] != null ? Session["scnPanCardNo"].ToString() : "";
                    model.NIC_Passport_No = Session["scnPassportNo"] != null ? Session["scnPassportNo"].ToString() : "";
                }
                else
                {
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                }
                ViewBag.ListNationalIdentity = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);
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
        public ActionResult AddNationalIdentityInfo(AddPQNationalIdentityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    DateTime oDate = DateTime.Now;
                    model.CreatedDate = oDate;

                    if (model.NationalIdentityRowID > 0)
                    {
                        #region Update NationalIdentity Information

                        repoNationalIdentInfo.UpdateNationalIdentityInfoByDataEntry(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Update Successfully!";
                        int PID = model.PersonalRowID;
                        ModelState.Clear();
                        return RedirectToAction("ManageDataEntryJob", new { id = PID });

                        #endregion
                    }
                    else
                    {
                        #region Add National Identity Information
                        if (model.ClientRowID > 0 && model.PersonalRowID > 0)
                        {
                            var subCheck = repoPQCandidateCheck.GetTATForOutDateById(model.ClientRowID, model.PersonalRowID, model.SubCheckRowID);
                            PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);
                            #region OrderDate And DeliveryDate

                            model.OutDate = GetDeliveryDate(oDate, subCheck.TAT, client);
                            model.InternalOutDate = GetDeliveryDate(oDate, subCheck.InternalTAT, client);
                            #endregion

                            #region Generate UniqueComponentId

                            int TotalRecord = repoNationalIdentInfo.GetAllNationalIdentityByClientId(model.ClientRowID);
                            string clCode = client.ClientCode1.Substring(0, 3).ToUpper();
                            TotalRecord++;
                            model.UniqueComponentID = string.Concat(clCode, "-NIC-", DateTime.Now.ToString("yyyyMMdd"), "-", Convert.ToString(TotalRecord));

                            #endregion

                            if (string.IsNullOrEmpty(model.NIC_Cand_Name))
                            {
                                model.NIC_Cand_Name = Convert.ToString(Session["CandidateName"]);
                            }
                            model.NIC_Sec_Ref_Id = Convert.ToString(Session["SecuritasRefID"]);
                            model.Status = 1;
                            repoNationalIdentInfo.AddNationalIdentityInformation(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddNationalIdentityInfo", model.CheckStatus, model.UniqueComponentID, "Insert");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageDataEntryJob", new { id = PID });

                        }
                        else
                        {
                            ModelState.AddModelError("", "National Identity info could not be blank!");
                        }
                        #endregion
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
            ViewBag.ListNationalIdentity = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult ViewNationalIdentityInfo(int id)
        {
            ViewNationalIdentityViewModel model = new ViewNationalIdentityViewModel();

            try
            {
                var NicDetails = repoNationalIdentInfo.GetNationalIdentityInfoForQC(id);
                if (NicDetails == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                model.ClientRowID = NicDetails.ClientRowID;
                model.CheckFamilyRowID = NicDetails.CheckFamilyRowID;
                model.SubCheckRowID = NicDetails.SubCheckRowID;
                model.PersonalRowID = NicDetails.PersonalRowID;
                model.NationalIdentityRowID = NicDetails.NationalIdentityRowID;

                ViewBag.NIdentityDetails = NicDetails;

                ViewBag.ListNationalIdentity = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
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
        public ActionResult ViewNationalIdentityInfo(string Approved, string Rejected, ViewNationalIdentityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.NationalIdentityRowID > 0)
                    {
                        #region Update National Identity Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewNationalIdentInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            if (Session["Designation"].ToString() == "Team Leader-DE")
                            {
                                repoNationalIdentInfo.ViewNationalIdentityInfoDETL(model);
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageReviewRequestedChecksForDETL", "Insuff");
                            }

                            if (Session["Designation"].ToString() == "Team Member-DE-QC")
                            {
                                if (Approved == "True")
                                {
                                    repoNationalIdentInfo.UpdateNationalIdentityRejectionByDEQC(model, true);
                                }
                                else
                                {
                                    repoNationalIdentInfo.UpdateNationalIdentityRejectionByDEQC(model);
                                }
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageRejectedChecksByDepTMForDEQC", "Insuff");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Remark could not be blank!");
                        }
                        #endregion
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid model!");
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
            ViewBag.ListNationalIdentity = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update Reference Information By DataEntry *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult AddReferenceInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            PQReferenceViewModel model = new PQReferenceViewModel();
            try
            {
                model = repoReferenceInfo.GetReferenceInfoForDataEntry(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    model = new PQReferenceViewModel();
                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                    model.ClientRowID = ClientRowId;
                    model.CheckFamilyRowID = ChFamilRowId;
                    model.SubCheckRowID = subCheckId;
                    model.PersonalRowID = PersonalRowID;
                    model.RV_CandidateName = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                    //model.RV_Refre_MobNo = Session["scnMobileNo"] != null ? Session["scnMobileNo"].ToString() : "";
                    //model.RV_Refre_Eid = Session["scnEmailID"] != null ? Session["scnEmailID"].ToString() : "";

                }
                else
                {

                    //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                }
                ViewBag.ListReference = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);
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
        public ActionResult AddReferenceInfo(PQReferenceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    DateTime oDate = DateTime.Now;
                    model.CreatedDate = oDate;
                    if (model.ReferenceRowID > 0)
                    {
                        #region Update Reference Information

                        repoReferenceInfo.UpdateReferenceInfoByDataEntry(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                        #endregion

                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        int PID = model.PersonalRowID;
                        ModelState.Clear();
                        return RedirectToAction("ManageDataEntryJob", new { id = PID });

                        #endregion
                    }
                    else
                    {
                        #region Add Reference Information 
                        if (model.ClientRowID > 0 && model.PersonalRowID > 0)
                        {
                            var subCheck = repoPQCandidateCheck.GetTATForOutDateById(model.ClientRowID, model.PersonalRowID, model.SubCheckRowID);
                            PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);

                            #region OrderDate And DeliveryDate

                            model.OutDate = GetDeliveryDate(oDate, subCheck.TAT, client);
                            model.InternalOutDate = GetDeliveryDate(oDate, subCheck.InternalTAT, client);
                            #endregion

                            #region Generate UniqueComponentId

                            int TotalRecord = repoReferenceInfo.GetAllReferenceByClientId(model.ClientRowID);
                            string clCode = client.ClientCode1.Substring(0, 3).ToUpper();
                            TotalRecord++;
                            model.UniqueComponentID = string.Concat(clCode, "-REF-", DateTime.Now.ToString("yyyyMMdd"), "-", Convert.ToString(TotalRecord));

                            #endregion

                            if (string.IsNullOrEmpty(model.RV_CandidateName))
                            {
                                model.RV_CandidateName = Convert.ToString(Session["CandidateName"]);
                            }
                            model.RV_Sec_Ref_Id = Convert.ToString(Session["SecuritasRefID"]);
                            model.Status = 1;
                            repoReferenceInfo.AddReferenceInformation(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddReferenceInfo", model.CheckStatus, model.UniqueComponentID, "Insert");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.INFRemarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageDataEntryJob", new { id = PID });

                        }
                        else
                        {
                            ModelState.AddModelError("", "Reference info could not be blank!");
                        }
                        #endregion
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
            ViewBag.ListReference = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult ViewReferenceInfo(int id)
        {
            ViewReferenceViewModel model = new ViewReferenceViewModel();
            try
            {
                var Referencedetail = repoReferenceInfo.GetReferenceInfoForQualityCheck(id);
                if (Referencedetail == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                model.ClientRowID = Referencedetail.ClientRowID;
                model.CheckFamilyRowID = Referencedetail.CheckFamilyRowID;
                model.SubCheckRowID = Referencedetail.SubCheckRowID;
                model.PersonalRowID = Referencedetail.PersonalRowID;
                model.ReferenceRowID = Referencedetail.ReferenceRowID;

                ViewBag.Referencedetails = Referencedetail;

                ViewBag.ListReference = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
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
        public ActionResult ViewReferenceInfo(string Approved, string Rejected, PQUpdateReferenceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.ReferenceRowID > 0)
                    {
                        #region Update Reference Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewReferenceInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            if (Session["Designation"].ToString() == "Team Leader-DE")
                            {
                                repoReferenceInfo.ViewReferenceInfoDETL(model);
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageReviewRequestedChecksForDETL", "Insuff");
                            }
                            if (Session["Designation"].ToString() == "Team Member-DE-QC")
                            {
                                if (Approved == "true")
                                {
                                    repoReferenceInfo.UpdateReferenceRejectionByDEQC(model, true);
                                }
                                else
                                {
                                    repoReferenceInfo.UpdateReferenceRejectionByDEQC(model);
                                }
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageRejectedChecksByDepTMForDEQC", "Insuff");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Remark could not be blank!");
                        }
                        #endregion
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid model!");
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
            GetEmploymentList();
            ViewBag.ListReference = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region ******* Update Special Check Information By DataEntry *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult AddSpecialCheckInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            AddSpecialCheckViewModel model = new AddSpecialCheckViewModel();
            try
            {
                model = repoSplCheckInfo.GetSpecialCheckInfoForDataEntry(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    model = new AddSpecialCheckViewModel();
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                    model.ClientRowID = ClientRowId;
                    model.CheckFamilyRowID = ChFamilRowId;
                    model.SubCheckRowID = subCheckId;
                    model.PersonalRowID = PersonalRowID;
                    model.SC_Cand_Name = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                    model.SC_Father_Name = Session["scnFatherName"] != null ? Session["scnFatherName"].ToString() : "";
                    if (Session["scnDOB"] != null)
                    {
                        model.SC_DOB = Convert.ToDateTime(Session["scnDOB"]);
                    }

                }
                else
                {
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
                }
                ViewBag.ListSpecialCheck = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);
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
        public ActionResult AddSpecialCheckInfo(AddSpecialCheckViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                    DateTime oDate = DateTime.Now;
                    model.CreatedDate = oDate;
                    if (model.SpecialCheckRowId > 0)
                    {
                        #region Update SpecialCheck Information

                        repoSplCheckInfo.UpdateSpecialCheckInfoByDataEntry(model);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddSpecialCheckInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                        #endregion

                        #endregion
                        TempData["SuccessMsg"] = "Record Update Successfully!";
                        int PID = model.PersonalRowID;
                        ModelState.Clear();
                        return RedirectToAction("ManageDataEntryJob", new { id = PID });
                    }
                    else
                    {
                        #region Add SpecialCheck Information
                        if (model.ClientRowID > 0 && model.PersonalRowID > 0)
                        {
                            var subCheck = repoPQCandidateCheck.GetTATForOutDateById(model.ClientRowID, model.PersonalRowID, model.SubCheckRowID);
                            PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);

                            #region OrderDate And DeliveryDate
                            model.OutDate = GetDeliveryDate(oDate, subCheck.TAT, client);
                            model.InternalOutDate = GetDeliveryDate(oDate, subCheck.InternalTAT, client);
                            #endregion

                            #region Generate UniqueComponentId

                            int TotalRecord = repoSplCheckInfo.GetAllSpacialByClientId(model.ClientRowID);
                            string clCode = client.ClientCode1.Substring(0, 3).ToUpper();
                            TotalRecord++;
                            model.UniqueComponentID = string.Concat(clCode, "-SC-", DateTime.Now.ToString("yyyyMMdd"), "-", Convert.ToString(TotalRecord));
                            #endregion


                            model.SC_SecuritasID = Session["SecuritasRefID"].ToString();
                            model.Status = 1;
                            repoSplCheckInfo.AddSpacelCheckInformation(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddSpecialCheckInfo", model.CheckStatus, model.UniqueComponentID, "Insert");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageDataEntryJob", new { id = PID });
                        }

                        else
                        {
                            ModelState.AddModelError("", "SpecialCheck info could not be blank!");
                        }
                        #endregion
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
            ViewBag.ListSpecialCheck = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult ViewSpecialCheckInfo(int id)
        {
            ViewSpecialCheckViewModel model = new ViewSpecialCheckViewModel();
            try
            {
                var SpecialCheckdetail = repoSplCheckInfo.GetSpecialCheckInfoForQualityCheck(id);
                if (SpecialCheckdetail == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                model.ClientRowID = SpecialCheckdetail.ClientRowID;
                model.CheckFamilyRowID = SpecialCheckdetail.CheckFamilyRowID;
                model.SubCheckRowID = SpecialCheckdetail.SubCheckRowID;
                model.PersonalRowID = SpecialCheckdetail.PersonalRowID;
                model.SpecialCheckRowId = SpecialCheckdetail.SpecialCheckRowId;

                ViewBag.SpecialCheckdetails = SpecialCheckdetail;

                ViewBag.ListSpecialCheck = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
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
        public ActionResult ViewSpecialCheckInfo(string Approved, string Rejected, UpdateSpecialCheckViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SpecialCheckRowId > 0)
                    {
                        #region Update Special Check Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewSpecialCheckInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            if (Session["Designation"].ToString() == "Team Leader-DE")
                            {
                                repoSplCheckInfo.ViewSpecialCheckInfoDETL(model);
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageReviewRequestedChecksForDETL", "Insuff");
                            }
                            if (Session["Designation"].ToString() == "Team Member-DE-QC")
                            {
                                if (Approved == "true")
                                {
                                    repoSplCheckInfo.UpdateSpecialCheckRejectionByDEQC(model, true);
                                }
                                else
                                {
                                    repoSplCheckInfo.UpdateSpecialCheckRejectionByDEQC(model);
                                }
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageRejectedChecksByDepTMForDEQC", "Insuff");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Remark could not be blank!");
                        }
                        #endregion
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid model!");
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

            ViewBag.ListSpecialCheck = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }
        #endregion

        #region******* Update Insurance Information By DataEntry *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult AddInsuranceInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            PQInsuranceViewModel model = new PQInsuranceViewModel();
            try
            {
                model.ClientRowID = ClientRowId;
                model.CheckFamilyRowID = ChFamilRowId;
                model.SubCheckRowID = subCheckId;
                model.PersonalRowID = PersonalRowID;
                //BindCountry();
                ViewBag.ListReference = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);
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
        public ActionResult AddInsuranceInfo(PQInsuranceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ClientRowID > 0 && model.PersonalRowID > 0)
                    {
                        model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        var subCheck = repoPQCandidateCheck.GetTATForOutDateById(model.ClientRowID, model.PersonalRowID, model.SubCheckRowID);
                        PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);
                        #region OrderDate And DeliveryDate

                        DateTime oDate = DateTime.Now;
                        model.CreatedDate = oDate;
                        model.OutDate = GetDeliveryDate(oDate, subCheck.TAT, client);
                        model.InternalOutDate = GetDeliveryDate(oDate, subCheck.InternalTAT, client);
                        #endregion

                        #region Generate UniqueComponentId

                        int TotalRecord = repoInsuranceInfo.GetAllInsuranceByClientId(model.ClientRowID);
                        string clCode = client.ClientCode1.Substring(0, 3).ToUpper();
                        TotalRecord++;
                        model.UniqueComponentID = string.Concat(clCode, DateTime.Now.ToString("yyyyMMdd"), "-", Convert.ToString(TotalRecord));

                        #endregion

                        //model.CaseStatus = "Pending";
                        model.CheckStatus = model.CheckStatus;
                        model.Status = 1;
                        repoInsuranceInfo.AddInsuranceInformation(model);
                        int Res = repoInsuranceInfo.SaveChanges();
                        if (Res > 0)
                        {
                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddInsuranceInfo", "Pending", model.UniqueComponentID, "Insert");
                            #endregion

                            #region Uploaded Documents Save 
                            //if (model.IV_OtherProof == 1 && model.OtherProofDoc != null && model.OtherProofDoc.ContentLength > 0)
                            //{
                            //    SavePQVerifiedUploadDoc(model.PersonalRowID, model.SubCheckRowID, "Provided", "OtherProof", "reference", model.OtherProofDoc);
                            //}
                            #endregion

                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageDataEntryJob", new { id = PID });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Insurance info could not be blank!");
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
            ViewBag.ListReference = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region ******* DataEntryBulkUpload  ******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult DataEntryBulkUpload(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0,string UploadfromDate = "" ,string UploadToDate = "")
        {
            ClientByBulkUploadListPagedModel model = new ClientByBulkUploadListPagedModel();
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                BindClientListBaseOnLogin(teamMemerRowId);
                int pageSize = 40;
                model = repoClientCmpUplod.GetCompanyListForUpload(page, pageSize, sort, sortDir, Search, ClientRowID,UploadfromDate,UploadToDate);
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

        #endregion

        #endregion

        #region ******* Quality Check Team Member  *******

        #region******* Update Address Information By QualityCheck *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateAddressInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            PQUpdateAddressViewModel model = new PQUpdateAddressViewModel();
            try
            {
                BindCountry();
                GetAddressProofDocs();
                ViewBag.ListAddress = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);

                model = repoAddressInfo.GetAddressInfoForQualityCheck(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
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
        public ActionResult UpdateAddressInfo(PQUpdateAddressViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.AddressRowID > 0)
                    {
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        if (model.CheckStatus == "Rejected")
                        {
                            UpdateAddressRejectionViewModel rejmodel = new UpdateAddressRejectionViewModel();
                            rejmodel.AddressRowID = model.AddressRowID;
                            rejmodel.CheckStatus = "Rejected";
                            rejmodel.INFRemarks = model.RejectionReason;
                            repoAddressInfo.RejectionUpdateAddressInfoByQC(rejmodel);

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.RejectionReason);
                            #endregion

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageQualityCheckJob", new { id = model.PersonalRowID });
                        }
                        else
                        {
                            #region Update Address Information

                            var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Add").FirstOrDefault();
                            if (mgrData != null && mgrData.TeamMemberRowID > 0)
                            {
                                #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                                if (model.CheckStatus == "Insufficent")
                                {
                                    var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                    var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                    if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                    {
                                        //Insert PQCandidateInsuffLogin Table data for candidate login
                                        SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.AddressRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.AddressRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                    else  // send mail Client/Spoc By the Company
                                    {
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.AddressRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                }
                                #endregion

                                model.MgrAllocatedTo = mgrData.TeamMemberRowID;
                                model.MgrAllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                model.MgrAllocatedDate = DateTime.Now;
                                repoAddressInfo.UpdateAddressInfoByQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved");
                                if (model.CheckStatus == "Completed")
                                {
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "");
                                }
                                #endregion

                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                int PID = model.PersonalRowID;
                                ModelState.Clear();
                                return RedirectToAction("ManageQualityCheckJob", new { id = PID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Please assign address manager for this client";
                            }
                            #endregion
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
            BindCountry();
            GetAddressProofDocs();
            ViewBag.ListAddress = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update Employment Information By QualityCheck *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult UpdateEmploymentInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            UpdateEmploymentViewModel model = new UpdateEmploymentViewModel();
            try
            {
                GetEmploymentList();
                ViewBag.ListEmployment = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);

                model = repoEmploymentInfo.GetEmploymentInfoForQC(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
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
        public ActionResult UpdateEmploymentInfo(UpdateEmploymentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.EmploymentRowID > 0)
                    {
                        if (string.IsNullOrEmpty(model.EV_CandidateName))
                        {
                            model.EV_CandidateName = Session["CandidateName"] != null ? Session["CandidateName"].ToString() : "";
                        }
                        if (model.CheckStatus == "Rejected")
                        {
                            UpdateEmploymentRejectionViewModel rejModel = new UpdateEmploymentRejectionViewModel();
                            rejModel.EmploymentRowID = model.EmploymentRowID;
                            rejModel.CheckStatus = "Rejected";
                            rejModel.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                            rejModel.ModifiedDate = DateTime.Now;
                            rejModel.INFRemarks = model.RejectionReason;
                            repoEmploymentInfo.RejectionUpdateEmploymentInfoByQC(rejModel);

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.RejectionReason);
                            #endregion

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentInfo", "Pending", model.UniqueComponentID, "Update");
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageQualityCheckJob", new { id = model.PersonalRowID });
                        }
                        else
                        {
                            #region Update Employment Information
                            if (!string.IsNullOrEmpty(model.EV_OrganisationName))
                            {
                                var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Emp").FirstOrDefault();
                                if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                {
                                    #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                                    if (model.CheckStatus == "Insufficent")
                                    {
                                        var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                        var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                        if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                        {
                                            //Insert PQCandidateInsuffLogin Table data for candidate login
                                            SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.EmploymentRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                            SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.EmploymentRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                        }
                                        else  // send mail Client/Spoc By the Company
                                        {
                                            SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.EmploymentRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                        }
                                    }
                                    #endregion

                                    model.MgrAllocatedTo = mgrData.TeamMemberRowID;
                                    model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                    model.ModifiedDate = DateTime.Now;
                                    model.MgrAllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                    model.MgrAllocatedDate = DateTime.Now;
                                    repoEmploymentInfo.UpdateEmploymentInfoByQC(model);

                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentInfo", "Pending", model.UniqueComponentID, "Update");
                                    #endregion

                                    #region Case/Check Action History Save 
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved");
                                    if (model.CheckStatus == "Completed")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "");
                                    }
                                    #endregion                                  

                                    TempData["SuccessMsg"] = "Record Update Successfully!";
                                    int PID = model.PersonalRowID;
                                    ModelState.Clear();
                                    return RedirectToAction("ManageQualityCheckJob", new { id = PID });
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "Please assign employment manager for this client";
                                }
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Name of organisation antecedent not mapped and it is mandatory!";
                            }
                            #endregion
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
            GetEmploymentList();
            ViewBag.ListEmployment = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update Education Information By QualityCheck *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult UpdateEducationInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            PQUpdateEducationViewModel model = new PQUpdateEducationViewModel();
            try
            {
                GetDegreeList();
                GetCollegeList();
                ViewBag.ListEducation = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);

                model = repoEducationInfo.GetEducationInfoForQualityCheck(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
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
        public ActionResult UpdateEducationInfo(PQUpdateEducationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.EducationRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            UpdateEducationRejectionViewModel rejModel = new UpdateEducationRejectionViewModel();
                            rejModel.EducationRowID = model.EducationRowID;
                            rejModel.CheckStatus = "Rejected";
                            rejModel.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                            rejModel.ModifiedDate = DateTime.Now;
                            rejModel.INFRemarks = model.RejectionReason;
                            repoEducationInfo.RejectionUpdateEducationInfoByQC(rejModel);

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.RejectionReason);
                            #endregion

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageQualityCheckJob", new { id = model.PersonalRowID });
                        }
                        else
                        {
                            #region Update Education Information
                            var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Edu").FirstOrDefault();
                            if (mgrData != null && mgrData.TeamMemberRowID > 0)
                            {
                                if (model.EV_Colg_Schl_Inst_Name > 0)
                                {
                                    #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                                    if (model.CheckStatus == "Insufficent")
                                    {
                                        var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                        var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                        if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                        {
                                            //Insert PQCandidateInsuffLogin Table data for candidate login
                                            SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.EducationRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                            SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.EducationRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                        }
                                        else  // send mail Client/Spoc By the Company
                                        {
                                            SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.EducationRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                        }
                                    }
                                    #endregion

                                    model.MgrAllocatedTo = mgrData.TeamMemberRowID;
                                    model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                    model.ModifiedDate = DateTime.Now;
                                    model.MgrAllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                    model.MgrAllocatedDate = DateTime.Now;
                                    repoEducationInfo.UpdateEducationInfoByQualityCheck(model);

                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                                    #endregion

                                    #region Case/Check Action History Save 
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved");
                                    if (model.CheckStatus == "Completed")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "");
                                    }
                                    #endregion                                    

                                    TempData["SuccessMsg"] = "Record Update Successfully!";
                                    int PID = model.PersonalRowID;
                                    ModelState.Clear();
                                    return RedirectToAction("ManageQualityCheckJob", new { id = PID });
                                }
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Please assign education manager for this client";
                            }
                            #endregion
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
            GetDegreeList();
            GetCollegeList();
            ViewBag.ListEducation = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update Criminal Information By QualityCheck *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult UpdateCriminalInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            PQUpdateCriminalViewModel model = new PQUpdateCriminalViewModel();
            try
            {
                ViewBag.ListCriminal = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);

                model = repoCriminalInfo.GetCriminalInfoForQualityCheck(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
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
        public ActionResult UpdateCriminalInfo(PQUpdateCriminalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CriminalRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            UpdateCriminalRejectionViewModel rejmodel = new UpdateCriminalRejectionViewModel();
                            rejmodel.CriminalRowID = model.CriminalRowID;
                            rejmodel.CheckStatus = "Rejected";
                            rejmodel.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                            rejmodel.ModifiedDate = DateTime.Now;
                            repoCriminalInfo.RejectionUpdateCriminalInfoByQC(rejmodel);

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.RejectionReason);
                            #endregion

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageQualityCheckJob", new { id = model.PersonalRowID });
                        }
                        else
                        {
                            #region Update Criminal Information 
                            var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Cri").FirstOrDefault();
                            if (mgrData != null && mgrData.TeamMemberRowID > 0)
                            {
                                #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                                if (model.CheckStatus == "Insufficent")
                                {
                                    var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                    var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                    if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                    {
                                        //Insert PQCandidateInsuffLogin Table data for candidate login
                                        SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.CriminalRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.CriminalRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                    else  // send mail Client/Spoc By the Company
                                    {
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.CriminalRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                }
                                #endregion

                                model.MgrAllocatedTo = mgrData.TeamMemberRowID;
                                model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                model.ModifiedDate = DateTime.Now;
                                model.MgrAllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                model.MgrAllocatedDate = DateTime.Now;
                                repoCriminalInfo.UpdateCriminalInfoByQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved");
                                if (model.CheckStatus == "Completed")
                                {
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "");
                                }
                                #endregion

                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                int PID = model.PersonalRowID;
                                ModelState.Clear();
                                return RedirectToAction("ManageQualityCheckJob", new { id = PID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Please assign criminal manager for this client";
                            }
                            #endregion
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
            ViewBag.ListCriminal = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update National Identity Information By QualityCheck *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult UpdateNationalIdentityInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            UpdatePQNationalIdentityViewModel model = new UpdatePQNationalIdentityViewModel();
            try
            {
                ViewBag.ListNationalIdentity = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);

                model = repoNationalIdentInfo.GetNationalIdentityInfoForQC(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
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
        public ActionResult UpdateNationalIdentityInfo(UpdatePQNationalIdentityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.NationalIdentityRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            UpdateNationalIRejectionViewModel rejmodel = new UpdateNationalIRejectionViewModel();
                            rejmodel.NationalIdentityRowID = model.NationalIdentityRowID;
                            rejmodel.CheckStatus = "Rejected";
                            rejmodel.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                            rejmodel.ModifiedDate = DateTime.Now;
                            repoNationalIdentInfo.RejectionUpdateNationalIInfoByQC(rejmodel);

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.RejectionReason);
                            #endregion

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityInfo", "Pending", model.UniqueComponentID, "Update");
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageQualityCheckJob", new { id = model.PersonalRowID });
                        }
                        else
                        {
                            #region Update NationalIdentity Information
                            var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Ide").FirstOrDefault();
                            if (mgrData != null && mgrData.TeamMemberRowID > 0)
                            {
                                #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                                if (model.CheckStatus == "Insufficent")
                                {
                                    var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                    var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                    if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                    {
                                        //Insert PQCandidateInsuffLogin Table data for candidate login
                                        SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.NationalIdentityRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.NationalIdentityRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                    else  // send mail Client/Spoc By the Company
                                    {
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.NationalIdentityRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                }
                                #endregion

                                model.MgrAllocatedTo = mgrData.TeamMemberRowID;
                                model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                model.ModifiedDate = DateTime.Now;
                                model.MgrAllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                model.MgrAllocatedDate = DateTime.Now;
                                repoNationalIdentInfo.UpdateNationalIdentityInfoByQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved");
                                if (model.CheckStatus == "Completed")
                                {
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "");
                                }
                                #endregion

                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                int PID = model.PersonalRowID;
                                ModelState.Clear();
                                return RedirectToAction("ManageQualityCheckJob", new { id = PID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Please assign national identity manager for this client";
                            }
                            #endregion
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
            ViewBag.ListNationalIdentity = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region******* Update Reference Information By QualityCheck *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult UpdateReferenceInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            PQUpdateReferenceViewModel model = new PQUpdateReferenceViewModel();
            try
            {
                ViewBag.ListReference = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);

                model = repoReferenceInfo.GetReferenceInfoForQualityCheck(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }

                //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(PersonalRowID, subCheckId);
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
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
        public ActionResult UpdateReferenceInfo(PQUpdateReferenceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ReferenceRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            UpdateRefrnceRejectionViewModel rejmodel = new UpdateRefrnceRejectionViewModel();
                            rejmodel.ReferenceRowID = model.ReferenceRowID;
                            rejmodel.CheckStatus = "Rejected";
                            rejmodel.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                            rejmodel.ModifiedDate = DateTime.Now;
                            repoReferenceInfo.RejectionUpdateRefrenceInfoByQC(rejmodel);

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.RejectionReason);
                            #endregion

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceInfo", "Pending", model.UniqueComponentID, "Update");
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageQualityCheckJob", new { id = model.PersonalRowID });
                        }
                        else
                        {
                            #region Update Reference Information
                            var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Ref").FirstOrDefault();
                            if (mgrData != null && mgrData.TeamMemberRowID > 0)
                            {
                                #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                                if (model.CheckStatus == "Insufficent")
                                {
                                    var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                    var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                    if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                    {
                                        //Insert PQCandidateInsuffLogin Table data for candidate login
                                        SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.ReferenceRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.ReferenceRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                    else  // send mail Client/Spoc By the Company
                                    {
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.ReferenceRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                }
                                #endregion

                                model.MgrAllocatedTo = mgrData.TeamMemberRowID;
                                model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                model.ModifiedDate = DateTime.Now;
                                model.MgrAllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                model.MgrAllocatedDate = DateTime.Now;
                                repoReferenceInfo.UpdateReferenceInfoByQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved");
                                if (model.CheckStatus == "Completed")
                                {
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "");
                                }
                                #endregion

                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                int PID = model.PersonalRowID;
                                ModelState.Clear();
                                return RedirectToAction("ManageQualityCheckJob", new { id = PID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Please assign reference manager for this client";
                            }
                            #endregion
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
            ViewBag.ListReference = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            //model.CheckActionHistories = repoCheckActionHistory.GetCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        #endregion

        #region ******* Update Special Check Information By QualityCheck *******

        [HttpGet]
        [SessionExpireFilterAttribute]
        [Route(Name = "DataEntry")]
        public ActionResult UpdateSpecialCheckInfo(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            UpdateSpecialCheckViewModel model = new UpdateSpecialCheckViewModel();
            try
            {             
                ViewBag.ListSpecialCheck = repoDDL.GetAntecedentList(ClientRowId, ChFamilRowId, subCheckId);               
                model = repoSplCheckInfo.GetSpecialCheckInfoForDEQC(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId);              
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No detail found!";
                    return View(model);
                }
                model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(PersonalRowID, subCheckId);
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
        public ActionResult UpdateSpecialCheckInfo(UpdateSpecialCheckViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.SpecialCheckRowId > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            UpdateSpecialCheckRejectionViewModel rejModel = new UpdateSpecialCheckRejectionViewModel();
                            rejModel.SpecialCheckRowId = model.SpecialCheckRowId;
                            rejModel.CheckStatus = "Rejected";
                            rejModel.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                            rejModel.ModifiedDate = DateTime.Now;
                            rejModel.Remarks = model.Remarks;
                            repoSplCheckInfo.RejectionUpdateSpecialCheckInfoByQC(rejModel);

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateSpecialCheckInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageQualityCheckJob", new { id = model.PersonalRowID });
                        }
                        else
                        {
                            #region ****** Update Special Check Information ******

                            var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-SPL").FirstOrDefault();
                            if (mgrData != null && mgrData.TeamMemberRowID > 0)
                            {

                                #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                                if (model.CheckStatus == "Insufficent")
                                {
                                    var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                    var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                    if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                    {
                                        SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.SpecialCheckRowId, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.SpecialCheckRowId, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                    else  // send mail Client/Spoc By the Company
                                    {
                                        SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.SpecialCheckRowId, model.CheckFamilyRowID, model.SubCheckRowID);
                                    }
                                }
                                    #endregion

                                    model.MgrAllocatedTo = mgrData.TeamMemberRowID;
                                    model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                    model.ModifiedDate = DateTime.Now;
                                    model.MgrAllocatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                    model.MgrAllocatedDate = DateTime.Now;
                                    repoSplCheckInfo.UpdateSpecialCheckInfoByQualityCheck(model);

                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateSpecialCheckInfo", model.CheckStatus, model.UniqueComponentID, "Update");
                                    #endregion

                                    #region Case/Check Action History Save 
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved");
                                    if (model.CheckStatus == "Completed")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "");
                                    }
                                    #endregion                                    

                                    TempData["SuccessMsg"] = "Record Update Successfully!";
                                    int PID = model.PersonalRowID;
                                    ModelState.Clear();
                                    return RedirectToAction("ManageQualityCheckJob", new { id = PID });
                               
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Please assign SpecialCheck manager for this client";
                            }
                            #endregion
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
           
            ViewBag.ListSpecialCheck = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }
        #endregion

        #endregion

        #region ******* Manage Dashboard *******

        [SessionExpireFilterAttribute]
        public ActionResult GetDEManagerDashBoardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CaseStatus = "", string RecievingToDate = "", string RecievingFromDate = "", byte tatHours = 0)
        {
            DashboardDEListViewModel model = new DashboardDEListViewModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                BindClientList();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                if (Designation == "Manager-DE")
                {
                    model = repoIDashboardDataEntry.GetDEManagerDashBoardInfo(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CaseStatus, ClientRowID, RecievingToDate, RecievingFromDate, tatHours);
                }

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
        public ActionResult GetDETeamLeaderDashBoardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CaseStatus = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = ""
                , byte tatHours = 0)
        {
            DashboardDEListViewModel model = new DashboardDEListViewModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                BindClientList();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                if (Designation == "Team Leader-DE")
                {
                    model = repoIDashboardDataEntry.GetDETeamLeaderDashBoardInfo(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CaseStatus, teamMemerRowId, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, tatHours);
                }

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

        #endregion

        #region NonAction/DropDownList  

        [NonAction]
        private void CreateNavigationforTeamMemberDE()
        {
            try
            {
                string NavTeamMemberDE = string.Empty;
                if (Session["Designation"].ToString() == "Team Leader-DE")
                {
                    NavTeamMemberDE += "<li><a href='" + Url.Action("AddCandidate", "ProvidedInfo") + "'> Add Candidate </a></li>";
                    NavTeamMemberDE += "<li><a href='" + Url.Action("AddBulkCandidateImport", "ProvidedInfo") + "'> Bulk Candidate Import </a></li>";
                    //NavTeamMemberDE += "<li><a href='" + Url.Action("DataEntryAllocation", "ProvidedInfo") + "'> Allocation </a></li>";
                    //NavTeamMemberDE += "<li><a href='" + Url.Action("DataEntryAllocated", "ProvidedInfo") + "'> Allocated </a></li>";
                    NavTeamMemberDE += "<li><a href='" + Url.Action("DataEntryBulkUpload", "ProvidedInfo") + "'> Data Entry Bulk Upload </a></li>";
                }
                if (Session["Designation"].ToString() == "Team Member-DE-Scan")
                {
                    //NavTeamMemberDE += "<li><a href='" + Url.Action("AllocatedDEScannerJob", "ProvidedInfo") + "'> Allocated DE Scanner Jobs </a></li>";
                }
                if (Session["Designation"].ToString() == "Team Member-DE")
                {
                    //NavTeamMemberDE += "<li><a href='" + Url.Action("AllocatedDataEntryJob", "ProvidedInfo") + "'> Allocated DE Jobs </a></li>";
                }
                if (Session["Designation"].ToString() == "Team Member-DE-QC")
                {
                    //NavTeamMemberDE += "<li><a href='" + Url.Action("AllocatedQualityCheckJob", "ProvidedInfo") + "'> Allocated QC Jobs </a></li>";
                }
                if (Session["Designation"].ToString() == "Team Member-Edu-Research")
                {
                    NavTeamMemberDE += "<li><a href='" + Url.Action("ManageResearchEducationChecks", "ProvidedInfo") + "'> Education Research </a></li>";
                }
                if (Session["Designation"].ToString() == "Team Member-Emp-Research")
                {
                    NavTeamMemberDE += "<li><a href='" + Url.Action("ManageResearchEmploymentChecks", "ProvidedInfo") + "'> Employment Research </a></li>";
                }
                if (Session["Designation"].ToString() == "Team Leader-DE")
                {
                    NavTeamMemberDE += "<li><a href='" + Url.Action("ManageEmploymentYTRChecks", "ProvidedInfo") + "'> Employment YTR List </a></li>";
                }

                Session["NavTeamMemberDE"] = NavTeamMemberDE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        private void CreateMenuitemforDEScanner(int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    var CandidateChecks = repoPQCandidateCheck.GetCandidateChecks(id);
                    string NavInputDataMenuList = "<li><a href='" + Url.Action("UploadCandidateCaseDocument", "ProvidedInfo", new { pid = id }) + "' > Case Document </a></li>";
                    if (CandidateChecks != null && CandidateChecks.Count() > 0)
                    {
                        foreach (var item in CandidateChecks)
                        {
                            if (item.ClientPackageRowID > 0)
                            {
                                var chkData = repoClientPackage.GetPackageDetailsById(item.ClientPackageRowID);
                                //if (!repoPQVerifiedUploadDoc.IsExistsChecksInUploadDocList(item.PersonalRowID, chkData.SubCheckRowID))
                                //{
                                string urlValue = Url.Content(string.Format("~/ProvidedInfo/UploadCandidateDocument/?PersonalRowID={0}&ChFamilRowId={1}&subCheckId={2}", item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID));
                                NavInputDataMenuList += "<li><a href='" + urlValue + "'> " + chkData.SubCheckFamillyName + " </a></li>";
                                //}
                            }
                            else if (item.ClientCheckRowID > 0)
                            {
                                var chkData = repoClientCheck.GetChecksDetailsById(item.ClientCheckRowID);
                                //if (!repoPQVerifiedUploadDoc.IsExistsChecksInUploadDocList(item.PersonalRowID, chkData.SubCheckRowID))
                                //{
                                string urlValue = Url.Content(string.Format("~/ProvidedInfo/UploadCandidateDocument/?PersonalRowID={0}&ChFamilRowId={1}&subCheckId={2}", item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID));
                                NavInputDataMenuList += "<li><a href='" + urlValue + "'> " + chkData.SubCheckFamillyName + " </a></li>";
                                //}
                            }
                        }
                    }
                    Session["NavInputDataMenuList"] = NavInputDataMenuList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        private void CreateMenuitemforDataEntryOperator(int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    var CandidateChecks = repoPQCandidateCheck.GetCandidateChecks(id);
                    string NavInputDataMenuList = "<li><a href='" + Url.Action("UpdateCandidateDetails", "ProvidedInfo", new { id = id }) + "' > Personal Info </a></li>";
                    if (CandidateChecks != null && CandidateChecks.Count() > 0)
                    {
                        foreach (var item in CandidateChecks)
                        {
                            if (item.ClientPackageRowID > 0)
                            {
                                var chkData = repoClientPackage.GetPackageDetailsById(item.ClientPackageRowID);
                                string pageName = GetPageNameByCheckId(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID);
                                if (!string.IsNullOrEmpty(pageName))
                                {
                                    string urlValue = Url.Content(string.Format("~/ProvidedInfo/" + pageName + "/client/{0}/candidate/{1}/check/{2}/{3}", item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID));
                                    NavInputDataMenuList += "<li><a href='" + urlValue + "'> " + chkData.SubCheckFamillyName + " </a></li>";
                                }
                            }
                            else if (item.ClientCheckRowID > 0)
                            {
                                var chkData = repoClientCheck.GetChecksDetailsById(item.ClientCheckRowID);
                                string pageName = GetPageNameByCheckId(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID);
                                if (!string.IsNullOrEmpty(pageName))
                                {
                                    string urlValue = Url.Content(string.Format("~/ProvidedInfo/" + pageName + "/client/{0}/candidate/{1}/check/{2}/{3}", item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID));
                                    NavInputDataMenuList += "<li><a href='" + urlValue + "'> " + chkData.SubCheckFamillyName + " </a></li>";
                                }
                            }
                        }
                    }
                    Session["NavInputDataMenuList"] = NavInputDataMenuList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        private string GetPageNameByCheckId(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                string pageName = string.Empty;
                if (ChFamilRowId == 2 && repoAddressInfo.IfExistAddressForDELeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "AddAddressInfo";
                }
                if (ChFamilRowId == 12 && repoEmploymentInfo.IfExistEmploymentForDELeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "AddEmploymentInfo";
                }
                if (ChFamilRowId == 11 && repoEducationInfo.IfExistEducationForDELeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "AddEducationInfo";
                }
                if (ChFamilRowId == 26 && repoNationalIdentInfo.IfExistNationalIdentityForDELeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "AddNationalIdentityInfo";
                }
                if (ChFamilRowId == 30 && repoReferenceInfo.IfExistReferenceForDELeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "AddReferenceInfo";
                }
                if (ChFamilRowId == 5 && repoCriminalInfo.IfExistCriminalForDELeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "AddCriminalInfo";
                }
                if (ChFamilRowId == 40 && repoSplCheckInfo.IfExistSpecialCheckForDELeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "AddSpecialCheckInfo";
                }
                return pageName;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        private void CreateMenuitemforQualityCheck(int id = 0)
        {
            try
            {

                if (id > 0)
                {
                    var CandidateChecks = repoPQCandidateCheck.GetCandidateChecks(id);
                    string NavInputDataMenuList = "<li><a href='" + Url.Action("UpdateCandidateDetails", "ProvidedInfo", new { id = id }) + "'> Personal Info </a></li>";

                    if (CandidateChecks != null && CandidateChecks.Count() > 0)
                    {
                        foreach (var item in CandidateChecks)
                        {
                            if (item.ClientPackageRowID > 0)
                            {
                                var chkData = repoClientPackage.GetPackageDetailsById(item.ClientPackageRowID);
                                string pageName = GetQCPageNameByCheckId(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID);
                                if (!string.IsNullOrEmpty(pageName))
                                {
                                    string urlValue = Url.Content(string.Format("~/ProvidedInfo/" + pageName + "/client/{0}/candidate/{1}/check/{2}/{3}", item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID));
                                    NavInputDataMenuList += "<li><a href='" + urlValue + "'> " + chkData.SubCheckFamillyName + " </a></li>";
                                }
                            }
                            else if (item.ClientCheckRowID > 0)
                            {
                                var chkData = repoClientCheck.GetChecksDetailsById(item.ClientCheckRowID);
                                string pageName = GetQCPageNameByCheckId(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID);
                                if (!string.IsNullOrEmpty(pageName))
                                {
                                    string urlValue = Url.Content(string.Format("~/ProvidedInfo/" + pageName + "/client/{0}/candidate/{1}/check/{2}/{3}", item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID));
                                    NavInputDataMenuList += "<li><a href='" + urlValue + "'> " + chkData.SubCheckFamillyName + " </a></li>";
                                }
                            }
                        }
                    }
                    Session["NavInputDataMenuList"] = NavInputDataMenuList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        private string GetQCPageNameByCheckId(short ClientRowId = 0, int PersonalRowID = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                string pageName = string.Empty;
                if (ChFamilRowId == 2 && repoAddressInfo.IfExistAddressForQCLeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "UpdateAddressInfo";
                }
                if (ChFamilRowId == 12 && repoEmploymentInfo.IfExistEmploymentForQCLeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "UpdateEmploymentInfo";
                }
                if (ChFamilRowId == 11 && repoEducationInfo.IfExistEducationForQCLeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "UpdateEducationInfo";
                }
                if (ChFamilRowId == 26 && repoNationalIdentInfo.IfExistNationalIdentityForQCLeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "UpdateNationalIdentityInfo";
                }
                if (ChFamilRowId == 30 && repoReferenceInfo.IfExistReferenceForQCLeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "UpdateReferenceInfo";
                }
                if (ChFamilRowId == 5 && repoCriminalInfo.IfExistCriminalForQCLeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "UpdateCriminalInfo";
                }
                if (ChFamilRowId == 40 && repoSplCheckInfo.IfExistSpecialCheckForDEQCLeftMenu(ClientRowId, PersonalRowID, ChFamilRowId, subCheckId))
                {
                    pageName = "UpdateSpecialCheckInfo";
                }
                return pageName;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[NonAction] //Following Commented Code not in use. May be deleted in near future
        //private int IfCaseUploadCompleteByDataEntry(int PersonalRowID = 0)
        //{
        //    try
        //    {

        //        int res = 0;
        //        if (PersonalRowID > 0)
        //        {
        //            var CandidateChecks = repoPQCandidateCheck.GetCandidateChecks(PersonalRowID);
        //            if (CandidateChecks != null && CandidateChecks.Count() > 0)
        //            {
        //                bool Result = true;
        //                foreach (var item in CandidateChecks)
        //                {
        //                    if (item.ClientPackageRowID > 0)
        //                    {
        //                        var chkData = repoClientPackage.GetPackageDetailsById(item.ClientPackageRowID);
        //                        if (chkData.CheckFamilyRowID == 2)
        //                        {
        //                            // pageName = "AddAddressInfo";
        //                            Result = repoAddressInfo.IfExistAddress(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 5)
        //                        {
        //                            // pageName = "AddCriminalInfo";
        //                            Result = repoCriminalInfo.IfExistCriminal(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 11)
        //                        {
        //                            // pageName = "AddEducationInfo";
        //                            Result = repoEducationInfo.IfExistEducation(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 12)
        //                        {
        //                            //pageName = "AddEmploymentInfo";
        //                            Result = repoEmploymentInfo.IfExistEmployment(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 26)
        //                        {
        //                            //pageName = "AddNationalIdentityInfo";
        //                            Result = repoNationalIdentInfo.IfExistNationalIdentityInfo(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 30)
        //                        {
        //                            //pageName = "AddReferenceInfo";
        //                            Result = repoReferenceInfo.IfExistReference(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                    }
        //                    else if (item.ClientCheckRowID > 0)
        //                    {
        //                        var chkData = repoClientCheck.GetChecksDetailsById(item.ClientCheckRowID);
        //                        if (chkData.CheckFamilyRowID == 2)
        //                        {
        //                            // pageName = "AddAddressInfo";
        //                            Result = repoAddressInfo.IfExistAddress(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 5)
        //                        {
        //                            // pageName = "AddCriminalInfo";
        //                            Result = repoCriminalInfo.IfExistCriminal(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 11)
        //                        {
        //                            // pageName = "AddEducationInfo";
        //                            Result = repoEducationInfo.IfExistEducation(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 12)
        //                        {
        //                            //pageName = "AddEmploymentInfo";
        //                            Result = repoEmploymentInfo.IfExistEmployment(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 26)
        //                        {
        //                            //pageName = "AddNationalIdentityInfo";
        //                            Result = repoNationalIdentInfo.IfExistNationalIdentityInfo(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 30)
        //                        {
        //                            //pageName = "AddReferenceInfo";
        //                            Result = repoReferenceInfo.IfExistReference(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DEC");
        //                        }
        //                    }
        //                    if (Result)
        //                    {
        //                        break;
        //                    }
        //                }
        //                if (Result == false)
        //                {
        //                    repoPQPersonal.UpdatePQPersonalForQC(PersonalRowID, "DEC");
        //                    res = repoPQPersonal.SaveChanges();
        //                    if (res > 0)
        //                    {
        //                        #region Case/Check Action History Save 
        //                        clsCommonMethods.AddCaseActionHistory(PersonalRowID, "DEC", "Data Entry Completed");
        //                        #endregion
        //                    }
        //                }
        //            }
        //        }
        //        return res;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[NonAction]
        //private int IfApproveCaseQualityCheckJob(int PersonalRowID = 0)
        //{
        //    try
        //    {
        //        int res = 0;
        //        if (PersonalRowID > 0)
        //        {
        //            var CandidateChecks = repoPQCandidateCheck.GetCandidateChecks(PersonalRowID);
        //            if (CandidateChecks != null && CandidateChecks.Count() > 0)
        //            {
        //                bool Result = true;
        //                foreach (var item in CandidateChecks)
        //                {
        //                    if (item.ClientPackageRowID > 0)
        //                    {
        //                        var chkData = repoClientPackage.GetPackageDetailsById(item.ClientPackageRowID);
        //                        if (chkData.CheckFamilyRowID == 2)
        //                        {
        //                            // pageName = "AddAddressInfo";
        //                            Result = repoAddressInfo.IfExistAddress(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 5)
        //                        {
        //                            // pageName = "AddCriminalInfo";
        //                            Result = repoCriminalInfo.IfExistCriminal(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 11)
        //                        {
        //                            // pageName = "AddEducationInfo";
        //                            Result = repoEducationInfo.IfExistEducation(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 12)
        //                        {
        //                            //pageName = "AddEmploymentInfo";
        //                            Result = repoEmploymentInfo.IfExistEmployment(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 26)
        //                        {
        //                            //pageName = "AddNationalIdentityInfo";
        //                            Result = repoNationalIdentInfo.IfExistNationalIdentityInfo(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 30)
        //                        {
        //                            //pageName = "AddReferenceInfo";
        //                            Result = repoReferenceInfo.IfExistReference(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                    }
        //                    else if (item.ClientCheckRowID > 0)
        //                    {
        //                        var chkData = repoClientCheck.GetChecksDetailsById(item.ClientCheckRowID);
        //                        if (chkData.CheckFamilyRowID == 2)
        //                        {
        //                            // pageName = "AddAddressInfo";
        //                            Result = repoAddressInfo.IfExistAddress(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 5)
        //                        {
        //                            // pageName = "AddCriminalInfo";
        //                            Result = repoCriminalInfo.IfExistCriminal(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 11)
        //                        {
        //                            // pageName = "AddEducationInfo";
        //                            Result = repoEducationInfo.IfExistEducation(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 12)
        //                        {
        //                            //pageName = "AddEmploymentInfo";
        //                            Result = repoEmploymentInfo.IfExistEmployment(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 26)
        //                        {
        //                            //pageName = "AddNationalIdentityInfo";
        //                            Result = repoNationalIdentInfo.IfExistNationalIdentityInfo(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                        if (chkData.CheckFamilyRowID == 30)
        //                        {
        //                            //pageName = "AddReferenceInfo";
        //                            Result = repoReferenceInfo.IfExistReference(item.ClientRowID, item.PersonalRowID, chkData.CheckFamilyRowID, chkData.SubCheckRowID, "DE-QC-C");
        //                        }
        //                    }
        //                    if (Result)
        //                    {
        //                        break;
        //                    }
        //                }
        //                if (Result == false)
        //                {
        //                    repoPQPersonal.UpdatePQPersonalForQC(PersonalRowID, "DE-QC-C");
        //                    res = repoPQPersonal.SaveChanges();
        //                    if (res > 0)
        //                    {
        //                        #region Case/Check Action History Save 
        //                        clsCommonMethods.AddCaseActionHistory(PersonalRowID, "DE-QC-C", "Data Entry Quality Check Completed");
        //                        #endregion
        //                    }
        //                }
        //            }
        //        }
        //        return res;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public string GetCompanyRefNo(short id = 0, byte bckDays = 0)
        {
            try
            {
                string CRefNo = string.Empty;
                short ClientAbbRowID = repoPQClient.GetPQClientForUpdateById(id).ClientAbbRowID;
                string str1 = repoAbbreviation.GetAbbreviationForUpdateById(ClientAbbRowID).ClientAbbreviation;
                int noOfEntr = repoPQPersonal.GetAllCandidatesById(id);
                string empty = string.Empty;
                if (noOfEntr >= 10)
                {
                    noOfEntr++;
                    empty = Convert.ToString(noOfEntr);
                }
                else
                {
                    noOfEntr++;
                    empty = string.Concat("0", Convert.ToString(noOfEntr));
                }

                string[] strArrays = new string[] { str1, "-", DateTime.Now.AddDays(-bckDays).ToString("dd-MM-yyyy"), "-", empty };
                CRefNo = string.Concat(strArrays);
                return CRefNo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Send Mail To Client/Spoc/Candidate For Insuff Case

        bool SendAlertMassageForInsuffClearationForClientSpoc(short ClientRowID, int CheckRowID, short CheckFamilyRowID, short SubCheckRowID)
        {
            bool result = false;
            string MailSignature = string.Empty;
            string From = string.Empty;
            string DisplayName = string.Empty;
            string Cc = string.Empty; //Session["CSpocEmailID"].ToString();
            clsSendMail mail;
            mail = new clsSendMail();
            var signature = mail.GetCompanyMailSignature();
            if (signature != null)
            {
                MailSignature = string.Concat("For Securitas India. <br /><br />");
                MailSignature = string.Concat(MailSignature, "<b>", signature.CompanyName.Trim(), "</b><br /><b>Mobile: ", signature.MobileNo,
                    " | Direct Tel: ", signature.PhoneNo, " | Fax: ", signature.FaxNo, "</b><br /><b>E-mail id </b>: <a style='color:#df012a;' href='mailto:", signature.GeneralEmail, "'>", signature.GeneralEmail, "</a>");
            }
            From = signature.GeneralEmail;
            DisplayName = signature.CompanyName.Trim();
            var personalData = repoPQPersonal.GetCheckOrPersonalDetailsForSendMailById(CheckFamilyRowID, SubCheckRowID, CheckRowID);
            if (personalData != null)
            {
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/Emailers/Company/Insufficiency.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{FCandidateName}", personalData.CandidateName);
                body = body.Replace("{FCheckName}", personalData.SubCheckName);
                body = body.Replace("{FClientRefId}", personalData.ClientRefID);
                body = body.Replace("{FReferenceID}", personalData.CompanyRefNo);
                body = body.Replace("{FInsuffRemarks}", personalData.InsuffRemarks);

                body = body.Replace("{MailSignature}", MailSignature);
                string Subject = "Insufficiency " + personalData.CandidateName + "  " + personalData.SubCheckName;
                string To = personalData.SpocEmailID + "," + personalData.ClientEmailID;
                bool flag = mail.SendMail(DisplayName, From, To, Subject, body);
                if (flag)
                {
                    result = true;
                }
                else
                {
                    TempData["ErrorMsg"] = "Mail sending failed!";
                }
            }
            else
            {
                TempData["ErrorMsg"] = "Candidate login details not found!";
            }
            return result;
        }

        bool SendAlertMassageForInsuffClearationForCandidate(short ClientRowID, int CheckRowID, short CheckFamilyRowID, short SubCheckRowID, int PersonalRowID, string CandidateEmail)
        {
            bool result = false;
            string MailSignature = string.Empty;
            string From = string.Empty;
            string DisplayName = string.Empty;

            #region Save CandidateLogin Details
            AddPQCandidateLoginViewModel cModel = new AddPQCandidateLoginViewModel();
            string passwrd = clsCryptoRandomNumber.GetRandomAlphaNumeric();
            string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(passwrd);
            cModel.ClientRowID = ClientRowID;
            cModel.PersonalRowID = PersonalRowID;
            cModel.UserID = CandidateEmail;
            cModel.UPass = EncryptedPasswd;
            cModel.CreatedBy = "Company";
            cModel.CreatedTime = DateTime.Now;
            cModel.Status = 1;
            cModel = repoPQCandidateLogin.AddInsuffCandidateLogin(cModel);
            #endregion

            clsSendMail mail;
            var cSmtp = repoPQClient.GetPQClientSendMailFromById(ClientRowID);
            if (cSmtp != null && cSmtp.MailSendBy > 0 && !string.IsNullOrEmpty(cSmtp.SMTPServer) && !string.IsNullOrEmpty(cSmtp.SMTPPort) && !string.IsNullOrEmpty(cSmtp.SMTPUserName) && !string.IsNullOrEmpty(cSmtp.SMTPPassword))
            {
                mail = new clsSendMail(cSmtp.SMTPServer, cSmtp.SMTPPort, cSmtp.SMTPUserName, clsCommonMethods.PasswordDecrypt(cSmtp.SMTPPassword), Convert.ToBoolean(cSmtp.EnableSsl));
                From = cSmtp.CSendInsuffEmail != null ? cSmtp.CSendInsuffEmail : cSmtp.SMTPUserName;
                DisplayName = cSmtp.CSendInsuffDisplay != null ? cSmtp.CSendInsuffDisplay : cSmtp.ClientName.Trim();
                MailSignature = string.Concat("<b>", cSmtp.ClientName.Trim(), "</b><br /><b>E-mail id </b>: <a style='color:#df012a;' href='mailto:", cSmtp.SMTPUserName, "'>", cSmtp.SMTPUserName, "</a>");
            }
            else
            {
                mail = new clsSendMail();
                var signature = mail.GetCompanyMailSignature();
                if (signature != null)
                {
                    MailSignature = string.Concat("For Securitas India. <br /><br />");
                    MailSignature = string.Concat(MailSignature, "<b>", signature.CompanyName.Trim(), "</b><br /><b>Mobile: ", signature.MobileNo,
                        " | Direct Tel: ", signature.PhoneNo, " | Fax: ", signature.FaxNo, "</b><br /><b>E-mail id </b>: <a style='color:#df012a;' href='mailto:", signature.GeneralEmail, "'>", signature.GeneralEmail, "</a>");
                }
                From = signature.GeneralEmail;
                DisplayName = signature.CompanyName.Trim();
            }

            var personalData = repoPQPersonal.GetCheckOrPersonalDetailsForSendMailById(CheckFamilyRowID, SubCheckRowID, CheckRowID);
            if (personalData != null)
            {
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/Emailers/Company/insuffCandidate.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{CandidateName}", personalData.CandidateName);
                body = body.Replace("{ClientRefId}", personalData.ClientRefID);
                body = body.Replace("{ExpireDate}", DateTime.Now.AddDays(5).ToString());
                body = body.Replace("{UName}", cModel.UserID);
                body = body.Replace("{UPasswd}", clsCommonMethods.PasswordDecrypt(cModel.UPass.Trim()));
                body = body.Replace("{CandidateLoginUrl}", ConfigurationManager.AppSettings["CandidateLoginUrl"].ToString());
                body = body.Replace("{CheckName}", personalData.SubCheckName);
                body = body.Replace("{Remarks}", personalData.InsuffRemarks);

                body = body.Replace("{MailSignature}", MailSignature);
                string Subject = "Insufficiency";
                string To = cModel.UserID; // personalData.SpocEmailID + "," + personalData.ClientEmailID; 
                bool flag = mail.SendMail(DisplayName, From, To, Subject, body);
                if (flag)
                {
                    result = true;
                }
                else
                {
                    TempData["ErrorMsg"] = "Mail sending failed!";
                }
            }
            else
            {
                TempData["ErrorMsg"] = "Candidate login details not found!";
            }
            return result;
        }
        #endregion

        public JsonResult GetCandidateCode(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    string CandidateCode = string.Empty;
                    CandidateCode = GenrateCandidateCode(id);
                    return Json(CandidateCode, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GenrateCandidateCode(short id = 0)
        {
            try
            {
                var ClientDetails = repoPQClient.GetPQClientForCadiCodeGenById(id);
                int CodeGeneration = ClientDetails.CodeGeneration;
                string CandidateCode = string.Empty;
                if (CodeGeneration > 0)
                {
                    string str1 = ClientDetails.ClientAbbName;
                    int noOfEntr = repoPQPersonal.GetAllCandidateCodeGenerationById(id);
                    string empty = string.Empty;
                    if (noOfEntr >= 10)
                    {
                        noOfEntr++;
                        empty = Convert.ToString(noOfEntr);
                    }
                    else
                    {
                        noOfEntr++;
                        empty = string.Concat("0", Convert.ToString(noOfEntr));
                    }

                    string str2 = DateTime.Now.Year.ToString();
                    string str3 = DateTime.Now.Month.ToString();
                    string str4 = str2 + str3 + DateTime.Now.Day.ToString();
                    string str5 = DateTime.Now.Hour.ToString();
                    string str6 = DateTime.Now.Minute.ToString();
                    string str7 = DateTime.Now.Second.ToString();
                    string str8 = str5 + str6 + str7 + DateTime.Now.Millisecond.ToString();
                    string[] strArrays = new string[] { str1, "-", str4, "-", empty, "-", str8 };
                    CandidateCode = string.Concat(strArrays);

                }
                else
                {
                    CandidateCode = "";
                }
                return CandidateCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetPricingTypeByID(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    int pricingType = repoPQClient.GetClientPricingTypeById(id);
                    return Json(pricingType, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetBORowIdByClientId(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    short BORowID = repoPQClient.GetPQClientForUpdateById(id).BORowID;
                    return Json(BORowID, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        private void GetAllCheckListforDocUpload(int id = 0)
        {
            try
            {

                if (id > 0)
                {
                    var CandidateChecks = repoPQCandidateCheck.GetCandidateChecks(id);
                    List<SubCheckFamilyForDDLViewModel> objData = new List<SubCheckFamilyForDDLViewModel>();
                    if (CandidateChecks != null && CandidateChecks.Count() > 0)
                    {
                        foreach (var item in CandidateChecks)
                        {
                            SubCheckFamilyForDDLViewModel data = new SubCheckFamilyForDDLViewModel();
                            if (item.ClientPackageRowID > 0)
                            {
                                var chkData = repoClientPackage.GetPackageDetailsById(item.ClientPackageRowID);
                                //if (!repoPQVerifiedUploadDoc.IsExistsChecksInUploadDocList(item.PersonalRowID, chkData.SubCheckRowID))
                                //{
                                data.SubCheckName = chkData.SubCheckFamillyName;
                                data.SubCheckRowID = chkData.SubCheckRowID;
                                objData.Add(data);
                                //}
                            }
                            else if (item.ClientCheckRowID > 0)
                            {
                                var chkData = repoClientCheck.GetChecksDetailsById(item.ClientCheckRowID);
                                //if (!repoPQVerifiedUploadDoc.IsExistsChecksInUploadDocList(item.PersonalRowID, chkData.SubCheckRowID))
                                //{
                                data.SubCheckName = chkData.SubCheckFamillyName;
                                data.SubCheckRowID = chkData.SubCheckRowID;
                                objData.Add(data);
                                //}
                            }
                        }
                    }
                    ViewBag.CheckList = objData.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        private void GetAllDocUploadedCheckList(int id = 0)
        {
            try
            {

                if (id > 0)
                {
                    var CandidateChecks = repoPQCandidateCheck.GetCandidateChecks(id);
                    List<SubCheckFamilyForDDLViewModel> objData = new List<SubCheckFamilyForDDLViewModel>();
                    if (CandidateChecks != null && CandidateChecks.Count() > 0)
                    {
                        foreach (var item in CandidateChecks)
                        {
                            SubCheckFamilyForDDLViewModel data = new SubCheckFamilyForDDLViewModel();
                            if (item.ClientPackageRowID > 0)
                            {
                                var chkData = repoClientPackage.GetPackageDetailsById(item.ClientPackageRowID);
                                if (repoPQVerifiedUploadDoc.IsExistsChecksInUploadDocList(item.PersonalRowID, chkData.SubCheckRowID))
                                {
                                    data.SubCheckName = chkData.SubCheckFamillyName;
                                    data.SubCheckRowID = chkData.SubCheckRowID;
                                    objData.Add(data);
                                }
                            }
                            else if (item.ClientCheckRowID > 0)
                            {
                                var chkData = repoClientCheck.GetChecksDetailsById(item.ClientCheckRowID);
                                if (repoPQVerifiedUploadDoc.IsExistsChecksInUploadDocList(item.PersonalRowID, chkData.SubCheckRowID))
                                {
                                    data.SubCheckName = chkData.SubCheckFamillyName;
                                    data.SubCheckRowID = chkData.SubCheckRowID;
                                    objData.Add(data);
                                }
                            }
                        }
                    }
                    ViewBag.CheckList = objData.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetDocumentTypeListBySubCheckID(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    short chkId = repoSubCheckFamily.GetSubCheckFamilyForUpdateById(id).CheckFamilyRowID;
                    string pageName = string.Empty;
                    if (chkId == 2)
                    {
                        //pageName = "AddAddressInfo";
                        List<SelectListItem> objData = new List<SelectListItem>
                        {
                            new SelectListItem{Text="Ration Card", Value="Ration_Card"},
                            new SelectListItem{Text="Telephone Bill", Value="Telephone_Bill"},
                            new SelectListItem{Text="Rent Agreement", Value="Rent_Agreement"},
                            new SelectListItem{Text="Passport", Value="Passport"},
                            new SelectListItem{Text="Electricity Bill", Value="Electricity_Bill"},
                            new SelectListItem{Text="Gas Supply Bill", Value="Gas_Supply_Bill"},
                            new SelectListItem{Text="Water Bill", Value="Water_Bill"},
                           new SelectListItem{Text="Others", Value="Others"}
                        };
                        return Json(objData, JsonRequestBehavior.AllowGet);

                    }
                    if (chkId == 5)
                    {
                        //pageName = "AddCriminalInfo";
                        List<SelectListItem> objData = new List<SelectListItem>
                        {
                            new SelectListItem{Text="Identity Proof", Value="Identity_Proof"},
                            new SelectListItem{Text="Address Proof", Value="Address_Proof"},
                            new SelectListItem{Text="Authorized Letter", Value="Authorized_Letter"},
                            new SelectListItem{Text="Other Proof", Value="Other_Proof"}
                        };
                        return Json(objData, JsonRequestBehavior.AllowGet);
                    }
                    if (chkId == 11)
                    {
                        //pageName = "AddEducationInfo";
                        List<SelectListItem> objData = new List<SelectListItem>
                        {
                            new SelectListItem{Text="Degree Certificate", Value="Degree_Certificate"},
                            new SelectListItem{Text="Provisional Certificate", Value="Provisional_Certificate"},
                            new SelectListItem{Text="Grade Sheet", Value="Grade_Sheet"},
                            new SelectListItem{Text="LOA", Value="LOA"},
                            new SelectListItem{Text="Other Proof", Value="Other_Proof"},
                        };
                        return Json(objData, JsonRequestBehavior.AllowGet);
                    }
                    if (chkId == 12)
                    {
                        //pageName = "AddEmploymentInfo";
                        List<SelectListItem> objData = new List<SelectListItem>
                        {
                            new SelectListItem{Text="Experience Letter", Value="Experience_Letter"},
                            new SelectListItem{Text="Relieving Letter", Value="Relieving_Letter"},
                            new SelectListItem{Text="LOA", Value="LOA"},
                            new SelectListItem{Text="Appointment Letter", Value="Appointment_Letter"},
                            new SelectListItem{Text="Others", Value="Others"},
                        };
                        return Json(objData, JsonRequestBehavior.AllowGet);
                    }
                    if (chkId == 26)
                    {
                        //pageName = "AddNationalIdentityInfo";
                        List<SelectListItem> objData = new List<SelectListItem>
                        {
                            new SelectListItem{Text="Aadhaar Card", Value="AadhaarCard"},
                            new SelectListItem{Text="Driving License", Value="DrivingLicense"},
                            new SelectListItem{Text="PAN Card", Value="PANCard"},
                            new SelectListItem{Text="Passport", Value="Passport"},
                            new SelectListItem{Text="VoterID", Value="VoterID"},
                            new SelectListItem{Text="OtherProof", Value="OtherProof"}
                        };
                        return Json(objData, JsonRequestBehavior.AllowGet);
                    }
                    if (chkId == 30)
                    {
                        //pageName = "AddReferenceInfo";
                        List<SelectListItem> objData = new List<SelectListItem>
                        {
                            new SelectListItem{Text="Others", Value="Others"}
                        };
                        return Json(objData, JsonRequestBehavior.AllowGet);
                    }
                    if (chkId == 40)
                    {
                        //pageName = "AddSpecialCheckInfo";
                        List<SelectListItem> objData = new List<SelectListItem>
                        {
                            new SelectListItem{Text="Special Document", Value="SpecialDoc"},
                            new SelectListItem{Text="Others", Value="Others"}
                        };
                        return Json(objData, JsonRequestBehavior.AllowGet);
                    }
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception Ex)
            {
                //ViewBag.ErrorMsg = Ex.Message;
                //clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace)
                throw Ex;
            }
        }

        public void GetAddressProofDocs()
        {
            try
            {
                List<SelectListItem> objData = new List<SelectListItem>
                { new SelectListItem{Text="Ration Card", Value="Ration Card"},
                    new SelectListItem{Text="Telephone Bill", Value="Telephone Bill"},
                    new SelectListItem{Text="Rent Agreement", Value="Rent Agreement"},
                    new SelectListItem{Text="Passport", Value="Passport"},
                    new SelectListItem{Text="Electricity Bill", Value="Electricity Bill"},
                    new SelectListItem{Text="Gas Supply Bill", Value="Gas Supply Bill"},
                    new SelectListItem{Text="Water Bill", Value="Water Bill"},
                    new SelectListItem{Text="Others", Value="Others"}};
                ViewBag.AddressProofDocs = objData;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        private int SaveClientCandidateUploadFileWithChecks(short ClientRowID = 0, string FileName = "", string CandidateCheckOrPackage = "")
        {
            try
            {
                int res = 0;
                AddPQClientCandiBulkUploadViewModel objModel = new AddPQClientCandiBulkUploadViewModel();
                objModel.ClientRowID = ClientRowID;
                objModel.ExcelFileName = FileName;
                objModel.ImportBy = "Company";
                objModel.Status = 1;
                string[] strChkPkg = CandidateCheckOrPackage.Split(',');
                foreach (var ChkPkg in strChkPkg)
                {
                    string[] strIds = ChkPkg.Split('-');
                    if (!string.IsNullOrEmpty(strIds[0]))
                    {
                        if (strIds[0] == "Check")
                        {
                            int ClientCheckRowID = Convert.ToInt32(strIds[1]);
                            var ChekData = repoClientCheck.GetChecksByClientId(ClientRowID).Where(p => p.ClientCheckRowID == ClientCheckRowID && p.AntecedentSelected == 1);
                            objModel.ClientPackageRowID = 0;
                            foreach (var item in ChekData)
                            {
                                objModel.ClientCheckRowID = item.ClientCheckRowID;
                                repoPQClientCandiBulkUpload.AddPQClientCandiBulkUpload(objModel);
                                res += repoPQClientCandiBulkUpload.SaveChanges();
                            }
                        }
                        if (strIds[0] == "Package")
                        {
                            var pkgDetails = repoClientPackage.GetPackageDetailsByPackageName(strIds[1]).Where(p => p.AntecedentSelected == 1);
                            objModel.ClientCheckRowID = 0;
                            foreach (var item in pkgDetails)
                            {
                                objModel.ClientPackageRowID = item.ClientPackageRowID;
                                repoPQClientCandiBulkUpload.AddPQClientCandiBulkUpload(objModel);
                                res += repoPQClientCandiBulkUpload.SaveChanges();
                            }
                        }
                    }
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ImportExcelAndSaveCandidateByBulkUpload(string FilePath, string Extension, string isHDR, AddPQPersonalBulkImportViewModel model) //isHDR - means Include header Yes or No
        {
            try
            {
                string conStr = "";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();

                //Insert into database CandidatesBulkImport table
                if (dt.Rows.Count > 0)
                {
                    //string lblMsg = clsCommanMethod.MsgBox("Total Candidates : " + dt.Rows.Count.ToString());
                    int countSuccess = 0;
                    int countDuplicate = 0;
                    string Email = string.Empty;
                    string MobileNo = string.Empty;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Email = Convert.ToString(dt.Rows[i]["Email"]);

                        model.EmailID = Email;
                        MobileNo = Convert.ToString(dt.Rows[i]["Mobile"]);
                        if (MobileNo.Length > 10)
                        {
                            if (MobileNo.Length == 12)
                            {
                                model.MobileNo = MobileNo.Remove(0, 2);
                            }
                            else if (MobileNo.Length == 11)
                            {
                                model.MobileNo = MobileNo.Remove(0, 1);
                            }
                        }
                        model.MobileNo = MobileNo;
                        model.Name = dt.Rows[i]["Name"].ToString();
                        model.VoterIDCardNo = dt.Rows[i]["VoterIDCardNo"].ToString();
                        model.DrivingLicenseNo = dt.Rows[i]["DrivingLicenseNo"].ToString();
                        model.AadhaarCardNo = dt.Rows[i]["AadhaarCardNo"].ToString();
                        model.PassportNo = dt.Rows[i]["PassportNo"].ToString();
                        model.PanCardNo = dt.Rows[i]["PanCardNo"].ToString();

                        if (!string.IsNullOrEmpty(model.Name))
                        {
                            if (!repoPQPersonal.IsCandidateExist(model.ClientRowID, model.VoterIDCardNo, model.DrivingLicenseNo, model.AadhaarCardNo, model.PassportNo, model.PanCardNo))
                            {
                                model.MiddleName = dt.Rows[i]["MiddleName"].ToString();
                                model.LastName = dt.Rows[i]["LastName"].ToString();
                                model.Gender = dt.Rows[i]["Gender"].ToString();
                                if (string.IsNullOrEmpty(model.Gender) || model.Gender.ToLower() == "male")
                                {
                                    model.Gender = "male";
                                    model.CandTitle = "Mr.";
                                }
                                else
                                {
                                    model.CandTitle = "Ms.";
                                }
                                model.EmployeeID = dt.Rows[i]["EmployeID"].ToString();
                                model.ClientRefID = dt.Rows[i]["ClientRefID"].ToString();
                                model.CandidateCode = GenrateCandidateCode(model.ClientRowID);
                                model.CompanyRefNo = GetCompanyRefNo(model.ClientRowID);
                                model.CreatedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                                model.CreatedDate = DateTime.Now;
                                model.FromType = "Company Cases";
                                model.DetailsEnteredBy = "Company";
                                model.CaseStatus = "Allocated";
                                model.Status = 1;

                                PQClientCodeHolidaysViewModel client = repoPQClient.GetPQClientCodeHolidaysById(model.ClientRowID);
                                model.TAT = repoPQPersonal.GetClientTATByCandidateId(model.ClientRowID);
                                model.CaseType = "Normal";

                                // OrderDate And DeliveryDate
                                DateTime oDate = DateTime.Now;
                                model.OrderDate = oDate;
                                model.DeliveryDate = GetDeliveryDate(oDate, model.TAT, client);

                                repoPQPersonal.AddCandidateAsBulkImport(model);
                                int Res = repoPQPersonal.SaveChanges();
                                if (Res > 0)
                                {
                                    model.PersonalRowID = repoPQPersonal.GetPQPersonalByCandidateCode(model.CompanyRefNo).PersonalRowID;

                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "Add Candidate", "Candidate Reference Generated", "Input", "Insert");
                                    #endregion

                                    #region Case/Check Action History Save 
                                    clsCommonMethods.AddCaseActionHistory(model.PersonalRowID, "Allocated-TL", "Securitas Id Generated by Import: " + model.CompanyRefNo);
                                    #endregion

                                    SavePackageOrCheckWithCandidateAsBulkImport(model);

                                    countSuccess++;
                                }
                            }
                            else
                            {
                                countDuplicate++;
                            }
                        }
                    }
                    TempData["SuccessMsg"] = countSuccess.ToString() + " Candidate(s) added successfully!";
                    if (countDuplicate > 0)
                    {
                        TempData["ErrorMsg"] = countDuplicate.ToString() + " Candidate(s) already exist!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "No candidate found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

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

        public JsonResult GetChecksAndPackageByClientId(short cid = 0, byte pt = 0)
        {
            try
            {
                //Package" = "1"    Check"   = "2"   Both"    = "3"  
                if (cid > 0)
                {
                    var data = repoPQClient.GetChecksAndPackageByClientId(cid, pt);
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Save Package Or Check for Candidate
        void SavePackageOrCheckWithCandidate(AddPQPersonalViewModel model)
        {
            try
            {
                AddPQCandidateCheckViewModel chekModel = new AddPQCandidateCheckViewModel();
                chekModel.ClientRowID = model.ClientRowID;
                chekModel.PersonalRowID = model.PersonalRowID;
                string[] strChkPkg = model.CandidateCheckOrPackage.Split(',');
                foreach (var ChkPkg in strChkPkg)
                {
                    string[] strIds = ChkPkg.Split('-');
                    if (!string.IsNullOrEmpty(strIds[0]))
                    {
                        if (strIds[0] == "Check")
                        {
                            int ClientCheckRowID = Convert.ToInt32(strIds[1]);
                            var ChekData = repoClientCheck.GetChecksByClientId(model.ClientRowID).Where(p => p.ClientCheckRowID == ClientCheckRowID && p.AntecedentSelected == 1);
                            chekModel.ClientPackageRowID = 0;
                            foreach (var item in ChekData)
                            {
                                chekModel.ClientCheckRowID = item.ClientCheckRowID;
                                repoPQCandidateCheck.AddCandidateCheck(chekModel);
                                repoPQCandidateCheck.SaveChanges();
                            }
                        }
                        if (strIds[0] == "Package")
                        {
                            var pkgDetails = repoClientPackage.GetPackageDetailsByPackageName(strIds[1]).Where(p => p.AntecedentSelected == 1);
                            chekModel.ClientCheckRowID = 0;
                            foreach (var item in pkgDetails)
                            {
                                chekModel.ClientPackageRowID = item.ClientPackageRowID;
                                repoPQCandidateCheck.AddCandidateCheck(chekModel);
                                repoPQCandidateCheck.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        //Save Package Or Check for Candidate case of bulk import
        void SavePackageOrCheckWithCandidateAsBulkImport(AddPQPersonalBulkImportViewModel model)
        {
            try
            {
                AddPQCandidateCheckViewModel chekModel = new AddPQCandidateCheckViewModel();
                chekModel.ClientRowID = model.ClientRowID;
                chekModel.PersonalRowID = model.PersonalRowID;
                string[] strChkPkg = model.CandidateCheckOrPackage.Split(',');
                foreach (var ChkPkg in strChkPkg)
                {
                    string[] strIds = ChkPkg.Split('-');
                    if (!string.IsNullOrEmpty(strIds[0]))
                    {
                        if (strIds[0] == "Check")
                        {
                            int ClientCheckRowID = Convert.ToInt32(strIds[1]);
                            var ChekData = repoClientCheck.GetChecksByClientId(model.ClientRowID).Where(p => p.ClientCheckRowID == ClientCheckRowID && p.AntecedentSelected == 1);
                            chekModel.ClientPackageRowID = 0;
                            foreach (var item in ChekData)
                            {
                                chekModel.ClientCheckRowID = item.ClientCheckRowID;
                                repoPQCandidateCheck.AddCandidateCheck(chekModel);
                                repoPQCandidateCheck.SaveChanges();
                            }
                        }
                        if (strIds[0] == "Package")
                        {
                            var pkgDetails = repoClientPackage.GetPackageDetailsByPackageName(strIds[1]).Where(p => p.AntecedentSelected == 1);
                            chekModel.ClientCheckRowID = 0;
                            foreach (var item in pkgDetails)
                            {
                                chekModel.ClientPackageRowID = item.ClientPackageRowID;
                                repoPQCandidateCheck.AddCandidateCheck(chekModel);
                                repoPQCandidateCheck.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveEducationResearchDetails(int educationRowId = 0, string OtherInstitute = "")
        {
            try
            {
                AddPQEducationResearchViewModel reModel = new AddPQEducationResearchViewModel();
                reModel.EducationRowId = educationRowId;
                reModel.OtherInstitute = OtherInstitute;
                reModel.AddedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                reModel.AddedNameDesig = Session["TeamMemberName"].ToString() + " (" + Session["Designation"].ToString() + ")";
                reModel.AddedOn = DateTime.Now;
                reModel.Status = 1;
                repoEducationResearch.AddEducationResearchInfo(reModel);
                repoEducationResearch.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveEmploymentResearchDetails(int EmploymentRowId = 0, string OtherEmployer = "")
        {
            try
            {
                AddPQEmploymentResearchViewModel reModel = new AddPQEmploymentResearchViewModel();
                reModel.EmploymentRowId = EmploymentRowId;
                reModel.OtherEmployer = OtherEmployer;
                reModel.AddedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                reModel.AddedNameDesig = Session["TeamMemberName"].ToString() + " (" + Session["Designation"].ToString() + ")";
                reModel.AddedOn = DateTime.Now;
                reModel.Status = 1;
                repoEmploymentResearch.AddEmploymentResearchInfo(reModel);
                repoEmploymentResearch.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetDEMemberForAllocate(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-DE");
                    return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetQCMemberForAllocate(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    var QCTM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-DE-QC");
                    return Json(new SelectList(QCTM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetDEScanMemberForAllocate(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    var ScanTM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-DE-Scan");
                    return Json(new SelectList(ScanTM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetDEMemberForAllocate()
        {
            try
            {
                short DETLID = Convert.ToInt16(Session["TeamMemberRowID"]);
                ViewBag.DETeamMembers = repoPQClientTMember.GetTeamMemberDEByTLDE(DETLID, "Team Member-DE");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetQCMemberForAllocate()
        {
            try
            {
                short DETLID = Convert.ToInt16(Session["TeamMemberRowID"]);
                ViewBag.DEQCTeamMembers = repoPQClientTMember.GetTeamMemberDEByTLDE(DETLID, "Team Member-DE-QC");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetDEScanMemberForAllocate()
        {
            try
            {
                short DETLID = Convert.ToInt16(Session["TeamMemberRowID"]);
                ViewBag.DEScanTeamMembers = repoPQClientTMember.GetTeamMemberDEByTLDE(DETLID, "Team Member-DE-Scan");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetClientTATByCandidateId(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    byte tat = repoPQPersonal.GetClientTATByCandidateId(id);
                    return Json(tat, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

        void GetEmploymentList()
        {
            try
            {
                ViewBag.EmploymentList = repoDDL.GetEmploymentDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        public JsonResult EmploymentAddress(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    string Address = string.Empty;
                    string Location = string.Empty;
                    try
                    {
                        Address = repoEmploymentInfo.GetAddressAndLocation(id).Address;


                    }
                    catch (Exception Ex)
                    {
                        ViewBag.ErrorMsg = Ex.Message;
                        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                    }
                    return Json(Address, Location, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult EmploymentLocation(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    string Location = string.Empty;
                    try
                    {
                        Location = repoEmploymentInfo.GetAddressAndLocation(id).Location;

                    }
                    catch (Exception Ex)
                    {
                        ViewBag.ErrorMsg = Ex.Message;
                        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                    }
                    return Json(Location, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        void GetCollegeList()
        {
            try
            {
                //List<CollegeDDLListViewModel> obj = new List<CollegeDDLListViewModel>();
                var obj = repoDDL.GetCollegeDDL().ToList();
                //obj.Add(new CollegeDDLListViewModel { CollegeRowID = 0, CollegeName = "Others" });
                ViewBag.CollegeList = obj;// repoDDL.GetCollegeDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        void GetDegreeList()
        {
            try
            {
                ViewBag.DegreeList = repoDDL.GetDegreeDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        public JsonResult CollegeAddress(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    string Address = string.Empty;

                    try
                    {
                        Address = repoEducationInfo.GetAddressAndAffiliated(id).Address;
                    }
                    catch (Exception Ex)
                    {
                        ViewBag.ErrorMsg = Ex.Message;
                        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                    }
                    return Json(Address, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult AffiliatedCollege(short id = 0)
        {
            try
            {
                if (id > 0)
                {
                    string AfflCollage = string.Empty;

                    try
                    {
                        AfflCollage = repoEducationInfo.GetAddressAndAffiliated(id).Affiliated;
                    }
                    catch (Exception Ex)
                    {
                        ViewBag.ErrorMsg = Ex.Message;
                        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                    }
                    return Json(AfflCollage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        private DateTime GetDeliveryDate(DateTime oDate, byte TAT, PQClientCodeHolidaysViewModel client)
        {
            try
            {
                DateTime ddate = oDate;
                DateTime fdlDate = oDate;
                ddate = ddate.AddDays(TAT);
                int intDate = 0;
                do
                {
                    intDate = getWeekendAndHoliDays(fdlDate, ddate, client);
                    fdlDate = ddate;
                    ddate = ddate.AddDays(intDate);
                }
                while (intDate != 0);
                return ddate;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        private int getWeekendAndHoliDays(DateTime oDate, DateTime dDate, PQClientCodeHolidaysViewModel clientModel)
        {
            try
            {
                int intDate = 0;
                //1-Client or 0-Default
                if (clientModel.MapHolidays == 1)
                {
                    var clientHoli = repoPQClientHoliday.GetClientHolidays(clientModel.ClientRowID).Where(ch => ch.HolidayDate.Value.Date >= oDate && ch.HolidayDate.Value <= dDate);
                    //int offDayCount = 0;
                    //TimeSpan diff = dDate - oDate;
                    //int days = diff.Days;
                    //for (var i = 1; i <= days; i++)
                    //{
                    //    var testDate = oDate.AddDays(i);
                    //    var currDate = clientHoli.Where(cd => cd.HolidayDate.Value.Date == testDate.Date).Select(c => c.HolidayDate).ToList();
                    //    if (currDate.Count() != 0)
                    //    {
                    //        offDayCount += 1;
                    //    }
                    //}

                    intDate = clientHoli.Count();
                    dDate = dDate.AddDays(intDate);

                }
                //DaysCalculation ==1-Working Days or 0-Calendar Days
                if (clientModel.DaysCalculation == 1)
                {
                    // Weekend Days count
                    int weekEndCount = 0;
                    TimeSpan diff = dDate - oDate;
                    int days = diff.Days;
                    for (var i = 1; i <= days; i++)
                    {
                        var testDate = oDate.AddDays(i);
                        if (testDate.DayOfWeek == DayOfWeek.Saturday || testDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            weekEndCount += 1;
                        }
                    }
                    dDate = dDate.AddDays(weekEndCount);
                    intDate += weekEndCount;
                }
                return intDate;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SavePQVerifiedUploadDoc(int PersonalRowID = 0, short SubCheckRowID = 0, string DocumentUploadFrom = "", string DocumentType = "", string FolderNameForSave = "", HttpPostedFileBase UploadDoc = null, string remarks = "", byte NADoc = 0)
        {
            try
            {
                string secRefId = Session["SecuritasRefID"].ToString();
                string FileName = (secRefId + "_" + SubCheckRowID.ToString() + " " + DocumentType).Replace(" ", "_").Replace("-", "_");
                PQAddVerifiedUploadDocViewModel DocModel = new PQAddVerifiedUploadDocViewModel();
                DocModel.PersonalRowID = PersonalRowID;
                DocModel.SubCheckRowID = SubCheckRowID;
                DocModel.DocumentUploadFrom = DocumentUploadFrom; //  Provided / Verified
                DocModel.DocumentType = DocumentType;            //Name of the selected docs
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
                repoPQVerifiedUploadDoc.AddPQVerifiedUploadDoc(DocModel);
                repoPQVerifiedUploadDoc.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SavePQVerifiedUploadCaseDoc(int PersonalRowID = 0, string DocumentUploadFrom = "", string DocumentType = "", string FolderNameForSave = "", HttpPostedFileBase UploadDoc = null, string remarks = "", bool NADoc = false)
        {
            try
            {
                string secRefId = Session["SecuritasRefID"].ToString();
                AddPQVerifiedUploadCaseDocViewModel DocModel = new AddPQVerifiedUploadCaseDocViewModel();
                DocModel.PersonalRowID = PersonalRowID;
                DocModel.DocumentUploadFrom = DocumentUploadFrom; //  Provided / Verified
                DocModel.DocumentType = DocumentType; //Name of the selected docs
                if (!NADoc)
                {
                    string FileName = (secRefId + " " + DocumentType).Replace(" ", "_").Replace("-", "_");
                    string FldPathDoc = string.Empty;
                    FldPathDoc = ConfigurationManager.AppSettings[FolderNameForSave.Trim().ToLower()].ToString();

                    string existFile = repoPQVerifiedUploadCaseDoc.ExistFileByPersonalIdAndDocType(PersonalRowID, DocumentType);
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
                }
                else
                {
                    DocModel.FileName = "NA";
                    DocModel.FilePath = "NA";
                }
                DocModel.UploadDate = DateTime.Now;
                DocModel.Status = 1;
                DocModel.Remarks = remarks;
                repoPQVerifiedUploadCaseDoc.AddPQVerifiedUploadCaseDoc(DocModel);
                repoPQVerifiedUploadCaseDoc.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        private int IfAllCheckDocUploadedByDEScanCaseMove(int PersonalRowID = 0)
        {
            try
            {

                int res = 0;
                if (PersonalRowID > 0)
                {
                    var CandidateChecks = repoPQCandidateCheck.GetCandidateChecks(PersonalRowID);
                    if (CandidateChecks != null && CandidateChecks.Count() > 0)
                    {
                        bool Result = true;
                        foreach (var item in CandidateChecks)
                        {
                            if (item.ClientPackageRowID > 0)
                            {
                                var chkData = repoClientPackage.GetPackageDetailsById(item.ClientPackageRowID);
                                Result = repoPQVerifiedUploadDoc.IsExistsTempChecksInUploadDocList(item.PersonalRowID, chkData.SubCheckRowID);
                            }
                            else
                            {
                                var chkData = repoClientPackage.GetPackageDetailsById(item.ClientCheckRowID);
                                Result = repoPQVerifiedUploadDoc.IsExistsTempChecksInUploadDocList(item.PersonalRowID, chkData.SubCheckRowID);
                            }
                            if (Result)
                            {
                                break;
                            }
                        }
                        if (Result == false)
                        {
                            repoPQPersonal.UpdatePQPersonalForQC(PersonalRowID, "DEO");
                            res = repoPQPersonal.SaveChanges();
                            if (res > 0)
                            {
                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCaseActionHistory(PersonalRowID, "DEC", "Data Entry Completed");
                                #endregion
                            }
                        }
                    }
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        void BindCountry()
        {
            try
            {
                ViewBag.Countries = repoDDL.GetCountriesForDDL();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        void BindClientList()
        {
            try
            {
                ViewBag.ClientList = repoDDL.GetClientListWithAbbAndLocationForDDL(); ;
            }
            catch (Exception)
            {

                throw;
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

        [NonAction]
        void BindBranchOfficeList()
        {
            try
            {
                ViewBag.BranchOfficeList = repoDDL.GetBranchOfficeForDDL();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        void BindCaseTypeList()
        {
            try
            {
                IEnumerable<SelectListItem> CaseTypeList = new List<SelectListItem> {
                    new SelectListItem { Text = "Normal", Value = "Normal" },
                    new SelectListItem { Text = "Priority", Value = "Priority" },
                };
                ViewBag.CaseTypeList = CaseTypeList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
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
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
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
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        void BindMaritalStatusList()
        {
            try
            {
                IEnumerable<SelectListItem> MaritalStatusList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "N/A", Value = "N/A", Selected=false },
                    new SelectListItem { Text = "Married", Value = "Married", Selected=false },
                    new SelectListItem { Text = "Unmarried", Value = "Unmarried", Selected=false },
                };
                ViewBag.MaritalStatusList = MaritalStatusList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        void BindCandidateTypeList()
        {
            try
            {
                IEnumerable<SelectListItem> CandidateTypeList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Fresher", Value = "Fresher", Selected=false },
                    new SelectListItem { Text = "Experienced", Value = "Experienced", Selected=false },
                };
                ViewBag.CandidateTypeList = CandidateTypeList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        void BindCatagoryList()
        {
            try
            {
                IEnumerable<SelectListItem> CatagoryList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Pre Joining", Value = "Pre Joining", Selected=false },
                    new SelectListItem { Text = "Post Joining", Value = "Post Joining", Selected=false },
                };
                ViewBag.CatagoryList = CatagoryList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        void CheckStatusOptionDropDown()
        {
            try
            {
                IEnumerable<SelectListItem> CheckStatusOption = new List<SelectListItem>
            {
              new SelectListItem { Text = "WIP-Pending", Value = "WIP-Pending" },
              new SelectListItem { Text = "Completed", Value = "Completed" },
              new SelectListItem { Text = "Stop", Value = "Stop" },
              new SelectListItem { Text = "Insufficent", Value = "Insufficent" },
              new SelectListItem { Text = "Review request", Value = "Review request" },
              new SelectListItem { Text = "YTR - Hold", Value = "YTR - Hold" },
              new SelectListItem { Text = "Rejected", Value = "Rejected" },
              new SelectListItem { Text = "PV Raised", Value = "PV Raised" },
              new SelectListItem { Text = "PV Rejected", Value = "PV Rejected" },
              new SelectListItem { Text = "Funds Pending", Value = "Funds Pending" },
              new SelectListItem { Text = "Verified - Clarification", Value = "Verified - Clarification" },
              new SelectListItem { Text = "Insuff Rectified", Value = "Insuff Rectified" },
              new SelectListItem { Text = "Research", Value = "Research" },
            };
                ViewBag.CheckStatusOptionList = CheckStatusOption;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void CaseStatusOptionDropDown()
        {
            try
            {
                IEnumerable<SelectListItem> CaseStatusOption = new List<SelectListItem>
            {
              new SelectListItem { Text = "Allocated", Value = "Allocated" },
              new SelectListItem { Text = "WIP", Value = "WIP" },
              new SelectListItem { Text = "Funds Pending", Value = "Funds Pending" },
              new SelectListItem { Text = "Insufficent", Value = "Insufficent" },
              new SelectListItem { Text = "Review Pending", Value = "Review Pending" },
              new SelectListItem { Text = "YTR Hold", Value = "YTR Hold" },
              new SelectListItem { Text = "Completed", Value = "Completed" },
              new SelectListItem { Text = "Re-open-WIP", Value = "Re-open-WIP" },
              new SelectListItem { Text = "Re-open- Insuff", Value = "Re-open- Insuff" },
              new SelectListItem { Text = "Re-open Completed", Value = "Re-open Completed" },
              new SelectListItem { Text = "QC Pending", Value = "QC Pending" },
              new SelectListItem { Text = "QC Rejected", Value = "QC Rejected" },
              new SelectListItem { Text = "Stopped", Value = "Stopped" },
            };
                ViewBag.CaseStatusOptionList = CaseStatusOption;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ******** ExportExcel DE *******
        [SessionExpireFilterAttribute]
        public ActionResult ExcelExportDE(short ClientRowID = 0, string CaseStatus = "", byte tatHours = 0)
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {               
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                if (Designation == "Manager-DE")
                {                   
                    var data = repoIDashboardDataEntry.GetDEEmportExcel(teamMemerRowId,Designation, CaseStatus, ClientRowID, tatHours);
                    if (CaseStatus== "DEntryAllocated")
                    {
                        if (CaseStatus== "CaseStatus1")
                        {
                            var data1 = data.PQPersonalInfo.Select(item => new ExportExcelAlocationDEViewModel
                            {
                                PersonalRowID = item.PersonalRowID,
                                ClientName = item.ClientName,
                                SecuritasID = item.CompanyRefNo,
                                CandidateName = item.Name,
                                AllocatedScanner = item.AllocatedToDEScanName,
                                AllocatedDE = item.AllocatedToDEName,
                                AllocatedQC = item.AllocatedToDEQCName,
                                Status = item.CaseStatus,
                            }).ToList();
                            ExportToExcel(data1, "DataEntryMge");
                        }
                        else
                        {
                            var data1 = data.PQPersonalInfo.Select(item => new ExportExcelAlocationDEViewModel
                            {
                                PersonalRowID = item.PersonalRowID,
                                ClientName = item.ClientName,
                                SecuritasID = item.CompanyRefNo,
                                CandidateName = item.Name,
                                AllocatedScanner = item.AllocatedToDEScanName,
                                AllocatedDE = item.AllocatedToDEName,
                                AllocatedQC = item.AllocatedToDEQCName,
                                Status = item.CaseStatus,
                            }).ToList();
                            ExportToExcel(data1, "DataEntryMge");
                        }                        
                    }
                    else
                    {
                        var data1 = data.PQPersonalInfo.Select(item => new ExportExcelDEViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.Name,
                            CreatedDate = item.CreatedDate,
                            Status = item.CaseStatus,
                        }).ToList();
                        ExportToExcel(data1, "DataEntryMge");
                    }
                   
                }
                if (Designation == "Team Leader-DE")
                {
                    var data = repoIDashboardDataEntry.GetDEEmportExcel(teamMemerRowId,Designation, CaseStatus, ClientRowID, tatHours);
                    if (CaseStatus == "DEntryAllocated")
                    {
                        var data1 = data.PQPersonalInfo.Select(item => new ExportExcelAlocationDEViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.Name,
                            AllocatedScanner = item.AllocatedToDEScanName,
                            AllocatedDE = item.AllocatedToDEName,
                            AllocatedQC = item.AllocatedToDEQCName,
                            Status = item.CaseStatus,
                        }).ToList();
                        ExportToExcel(data1, "DataEntryTL");
                    }
                    else
                    {
                        var data1 = data.PQPersonalInfo.Select(item => new ExportExcelDEViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.Name,
                            CreatedDate = item.CreatedDate,
                            Status = item.CaseStatus,
                        }).ToList();
                        ExportToExcel(data1, "DataEntryTL");
                    }
                }
                if (Designation == "Team Member-DE-Scan")
                {
                    var data = repoIDashboardDataEntry.GetDEEmportExcel(teamMemerRowId,Designation, CaseStatus, ClientRowID, tatHours);
                    var data1 = data.PQPersonalInfo.Select(item => new ExportExcelDEViewModel
                    {
                        PersonalRowID = item.PersonalRowID,
                        ClientName = item.ClientName,
                        SecuritasID = item.CompanyRefNo,
                        CandidateName = item.Name,
                        CreatedDate = item.CreatedDate,
                        Status = item.CaseStatus,
                    }).ToList();
                    ExportToExcel(data1, "DataEntryScan");
                }
                if (Designation == "Team Member-DE")
                {
                    var data = repoIDashboardDataEntry.GetDEEmportExcel(teamMemerRowId, Designation, CaseStatus, ClientRowID, tatHours);
                    var data1 = data.PQPersonalInfo.Select(item => new ExportExcelDEViewModel
                    {
                        PersonalRowID = item.PersonalRowID,
                        ClientName = item.ClientName,
                        SecuritasID = item.CompanyRefNo,
                        CandidateName = item.Name,
                        CreatedDate = item.CreatedDate,
                        Status = item.CaseStatus,
                    }).ToList();
                    ExportToExcel(data1, "DataEntry");
                }
                
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View(model);
        }
        public ActionResult ExcelExportYTRDE(short ClientRowID = 0, string CaseStatus = "", byte tatHours = 0)
        {
            DashboardExportDEListViewModel model = new DashboardExportDEListViewModel();
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                if (Session["Designation"].ToString() == "Team Leader-DE")
                {
                    var data = repoIDashboardDataEntry.GetDEYTREmportExcel(teamMemerRowId, Designation, CaseStatus, ClientRowID, tatHours);
                    var data1 = data.ExportExDetailsDE.Select(item => new ExportExcelDEYTRViewModel
                    {
                        PersonalRowID = item.PersonalRowID,
                        ClientName = item.ClientName,
                        SecuritasID = item.CompanyRefNo,
                        CandidateName = item.CandidateName,
                        CreatedDate = item.CreatedDate,
                        CheckName=item.SubCheckName,
                        Status = item.CaseStatus,
                    }).ToList();
                    ExportToExcel(data1, "DataEntryMge");
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View(model);
        }

        public ActionResult ExcelExportREAllocationByDETL(short ClientRowID = 0, string CaseStatus = "", byte tatHours = 0)
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                    var data = repoIDashboardDataEntry.GetREAllocationByDETLmportExcel(teamMemerRowId, Designation, CaseStatus, ClientRowID, tatHours);

                if (Session["Designation"].ToString() == "Team Leader-DE")
                {
                    var data1 = data.PQPersonalInfo.Select(item => new ExportExcelREAllocationByDEViewModel
                    {
                        PersonalRowID = item.PersonalRowID,
                        ClientName = item.ClientName,
                        SecuritasID = item.CompanyRefNo,
                        CandidateName = item.Name,
                        CreatedDate = item.CreatedDate,
                        AllocatedDE = item.AllocatedToDEName,
                        AllocatedScanner = item.AllocatedToDEScanName,
                        AllocatedDEQC = item.AllocatedToDEQCName,                        
                    }).ToList();
                    ExportToExcel(data1, "DataEntryMge");
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View(model);
        }

        public ActionResult ExcelExportDEScanner(short ClientRowID = 0, string CaseStatus = "", byte tatHours = 0)
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                if (Designation == "Team Member-DE-Scan")
                {
                    var data = repoIDashboardDataEntry.GetDEScannermportExcel(teamMemerRowId, Designation, CaseStatus, ClientRowID, tatHours);
                    var data1 = data.PQPersonalInfo.Select(item => new ExportExcelDEScannerViewModel
                    {
                        PersonalRowID = item.PersonalRowID,
                        ClientName = item.ClientName,
                        SecuritasID = item.CompanyRefNo,
                        CandidateName = item.Name,
                        AllocatedOn=item.AllocatedToDEScanDate,
                        UploadedByClient=item.OtherDetails,
                    }).ToList();
                    ExportToExcel(data1, "DEScanner");
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View(model);
        }

        public ActionResult ExcelExportDEQC(short ClientRowID = 0, string CaseStatus = "", byte tatHours = 0)
        {
            PQPersonalInfoListPagedModel model = new PQPersonalInfoListPagedModel();
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                if (Designation == "Team Member-DE-QC")
                {
                    var data = repoIDashboardDataEntry.GetDEQCEmportExcel(teamMemerRowId, Designation, CaseStatus, ClientRowID, tatHours);
                    var data1 = data.PQPersonalInfo.Select(item => new ExportExcelDEQCViewModel
                    {
                        PersonalRowID = item.PersonalRowID,
                        ClientName = item.ClientName,
                        SecuritasID = item.CompanyRefNo,
                        CandidateName = item.Name,
                        AllocatedScanner=item.AllocatedToDEScanName,
                        AllocatedDE = item.AllocatedToDEName,
                        Status = item.CaseStatus,
                       
                    }).ToList();
                    ExportToExcel(data1, "DEScanner");
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
