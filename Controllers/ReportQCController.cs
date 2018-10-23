using BAL;
using BAL.ClientRepository;
using BAL.ProvidedInfoRepository;
using BAL.ReportQCRepository;
using BAL.VerificationRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ViewModels;
using ViewModels.ProvidedInfoViewModel;
using ViewModels.ReportQCViewModel;
using ViewModels.VerificationViewModel;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class ReportQCController : Controller
    {

        #region ******  Repository Objects ******
        IReportQCRepository repoReportQC;
        IDropDownMasterRepository repoDDL;
        IPQClientTMemberRepository repoPQClientTMember;
        IPQPersonalRepository repoPQPersonal;
        IPQAddressVerRepository repoAddressVer;
        IPQEmploymentVerRepository repoEmploymentVer;
        IPQEducationVerRepository repoEducationVer;
        IPQCriminalVerRepository repoCriminalVer;
        IPQReferenceVerRepository repoReferenceVer;
        IPQNationalIdentityVerRepository repoNationalIdentityVer;
        IPQVerifiedUploadDocRepository repoPQVerifiedUploadDoc;
        IDashboardRWQCRepository repoDashboardRWQC;
        IPQCandidateCheckRepository repoPQCandidateCheck;
        IClientPackageRepository repoClientPackage;
        IClientCheckRepository repoClientCheck;
        ISpecialCheckInfoRepository repoSplCheckInfo;
        ISpecialVerificationRepository repoSplChkVer;

        public ReportQCController(IReportQCRepository _repoReportQC
            , IDropDownMasterRepository _repoDDL
            , IPQClientTMemberRepository _repoPQClientTMember
            , IPQPersonalRepository _repoPQPersonal
            , IPQAddressVerRepository _repoAddressVer
            , IPQEmploymentVerRepository _repoEmploymentVer
            , IPQEducationVerRepository _repoEducationVer
            , IPQCriminalVerRepository _repoCriminalVer
            , IPQReferenceVerRepository _repoReferenceVer
            , IPQNationalIdentityVerRepository _repoNationalIdentityVer
            , IDashboardRWQCRepository _repoDashboardRWQC
            , IPQVerifiedUploadDocRepository _repoPQVerifiedUploadDoc
            , IPQCandidateCheckRepository _repoPQCandidateCheck
            , IClientPackageRepository _repoClientPackage
            , IClientCheckRepository _repoClientCheck
            , ISpecialCheckInfoRepository _repoSplCheckInfo
            , ISpecialVerificationRepository _repoSplChkVer)
        {
            repoReportQC = _repoReportQC;
            repoDDL = _repoDDL;
            repoPQClientTMember = _repoPQClientTMember;
            repoPQPersonal = _repoPQPersonal;
            repoAddressVer = _repoAddressVer;
            repoEmploymentVer = _repoEmploymentVer;
            repoEducationVer = _repoEducationVer;
            repoCriminalVer = _repoCriminalVer;
            repoReferenceVer = _repoReferenceVer;
            repoNationalIdentityVer = _repoNationalIdentityVer;
            repoPQVerifiedUploadDoc = _repoPQVerifiedUploadDoc;
            repoDashboardRWQC = _repoDashboardRWQC;
            repoPQCandidateCheck = _repoPQCandidateCheck;
            repoClientPackage = _repoClientPackage;
            repoClientCheck = _repoClientCheck;
            repoSplCheckInfo = _repoSplCheckInfo;
            repoSplChkVer = _repoSplChkVer;
        }

        #endregion

        // GET: ReportQC
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                //DataEntry Manager
                if (Designation == "Manager-Rpt-QC")
                {
                    ViewBag.RWQCDashboard = "Report Writer QC Manager Dashboard!";
                    ViewBag.RWQCManagerDashboard = repoDashboardRWQC.GetRWQCManagerDashBoardInfo(teamMemerRowId, Designation);
                }

                //DataEntry TeamLeader               
                if (Designation == "Team Leader-Rpt-QC")
                {
                    ViewBag.RWQCDashboard = "Report Writer QC TeamLeader Dashboard!";
                    ViewBag.RWQCTeamLeaderDashboard = repoDashboardRWQC.GetRWQCTeamLeaderDashBoardInfo(teamMemerRowId, Designation);
                }

                //DataEntry Team Member-DE-Scan               
                if (Designation == "Team Member-Rpt-QC")
                {
                    ViewBag.RWQCDashboard = "Report Writer QC TeamMember Scanner Dashboard!";
                    ViewBag.RWQCTeamMemberDashboard = repoDashboardRWQC.GetRQQCTeamMemberDashBoardInfo(teamMemerRowId, Designation);
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View();
        }

        #region ****** Dashboard ReportQC ******

        [SessionExpireFilterAttribute]
        public ActionResult GetRWQCManagerDashBoardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CaseStatus = "", string RecievingDate = "", string CompletedDate = "", byte tatHours = 0)
        {
            DashboardRWQCListViewModel model = new DashboardRWQCListViewModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoDashboardRWQC.GetCandidateListForReportQCManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CaseStatus, teamMemberId, ClientRowID, RecievingDate, CompletedDate, tatHours);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            //BindClientList();
            BindClientListBaseOnLogin(teamMemberId);
            GetTLMemberForAllocation();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult GetRWQCTeamLeaderDashBoardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CaseStatus = "", string RecievingDate = "", string CompletedDate = "", byte tatHours = 0)
        {
            DashboardRWQCListViewModel model = new DashboardRWQCListViewModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoDashboardRWQC.GetCandidateListForReportQCTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CaseStatus, teamMemberId, ClientRowID, RecievingDate, CompletedDate, tatHours);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            //BindClientList();
            BindClientListBaseOnLogin(teamMemberId);
            GetTLMemberForAllocation();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult GetRWQCTeamMemberDashBoardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CaseStatus = "", string RecievingDate = "", string CompletedDate = "", byte tatHours = 0)
        {
            DashboardRWQCListViewModel model = new DashboardRWQCListViewModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoDashboardRWQC.GetCandidateListForReportQCTeamMember(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CaseStatus, teamMemberId, ClientRowID, RecievingDate, CompletedDate, tatHours);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            //BindClientList();
            BindClientListBaseOnLogin(teamMemberId);
            GetTLMemberForAllocation();
            return View(model);
        }


        #endregion

        #region ****** ReportQC Manager Bucket ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageAllCandidateListForReportQCManager(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, short AllocateTL = 0, string PersonalIds = "", byte tatHours = 0)
        {
            PQPersonalReportQCListPagedModel model = new PQPersonalReportQCListPagedModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
            try
            {
                if (AllocateTL > 0 && !string.IsNullOrEmpty(PersonalIds))
                {
                    byte UnAllocatedCount = 0;
                    int[] PerIDs = PersonalIds.Split(',').Select(str => int.Parse(str)).ToArray();
                    ReportQCAllocationViewModel personalmodel = new ReportQCAllocationViewModel();
                    personalmodel.ModifiedBy = teamMemberId;
                    personalmodel.ModifiedDate = DateTime.Now;
                    personalmodel.CheckStatus = "Allocated-TL";
                    personalmodel.RWQCTeamMemberBy = AllocateTL;
                    personalmodel.RWQCTeamMemberDate = DateTime.Now;
                    foreach (var item in PerIDs)
                    {
                        personalmodel.PersonalRowID = item;
                        short ClientID = repoPQPersonal.GetClientDetailsByPersonalId(item);
                        bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(ClientID, personalmodel.RWQCTeamMemberBy, "Report QC", "Team Leader-Rpt-QC");

                        if (result)
                        {
                            repoReportQC.UpdateAllocationForRWQCTLByRWQCManager(personalmodel);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(personalmodel.PersonalRowID, "ManageAllCandidateListForReportQC", "Allocated-ReportQC-TL", "Allocate TO TL", "Update");
                            #endregion

                            #region Case Action history save
                            clsCommonMethods.AddCaseActionHistory(personalmodel.PersonalRowID, "Allocated-RWQC-TL", "Allocated To RWQCTL");
                            #endregion
                        }
                        else
                        {
                            UnAllocatedCount++;
                        }
                    }
                }

                int pageSize = clsGlobalCommon.PageSize;
                model = repoReportQC.GetCandidateListForReportQCManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemberId, ClientRowID, tatHours);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            //BindClientList();
            BindClientListBaseOnLogin(teamMemberId);
            GetTLMemberForAllocation();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        public ActionResult ManageCandidateChecksForReportQC(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, int PersonalRowID = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoReportQC.GetCandidateCheckListForReportQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, PersonalRowID);

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            //BindClientList();
            BindClientListBaseOnLogin(teamMemberId);
            return View(model);

        }

        #endregion

        #region ****** ReportQC TeamLeader Bucket ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageAllCandidateListForReportQCTL(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, short AllocateTM = 0, string PersonalIds = "", byte tatHours = 0)
        {
            PQPersonalReportQCListPagedModel model = new PQPersonalReportQCListPagedModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);

            try
            {
                if (AllocateTM > 0 && !string.IsNullOrEmpty(PersonalIds))
                {
                    byte UnAllocatedCount = 0;
                    int[] PerIDs = PersonalIds.Split(',').Select(str => int.Parse(str)).ToArray();
                    ReportQCAllocationViewModel personalmodel = new ReportQCAllocationViewModel();
                    personalmodel.ModifiedBy = teamMemberId;
                    personalmodel.ModifiedDate = DateTime.Now;
                    personalmodel.CheckStatus = "Allocated-TM";
                    personalmodel.RWQCTeamMemberBy = AllocateTM;
                    personalmodel.RWQCTeamMemberDate = DateTime.Now;
                    foreach (var item in PerIDs)
                    {
                        personalmodel.PersonalRowID = item;
                        short ClientID = repoPQPersonal.GetClientDetailsByPersonalId(item);
                        bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(ClientID, personalmodel.RWQCTeamMemberBy, "Report QC", "Team Member-Rpt-QC");

                        if (result)
                        {
                            repoReportQC.UpdateAllocationForRWQCTMByRWQCTL(personalmodel);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(personalmodel.PersonalRowID, "ManageAllCandidateListForReportQCTL", "Allocated-ReportQC-TM", "Allocate TO TM", "Update");
                            #endregion

                            #region Case Action history save
                            clsCommonMethods.AddCaseActionHistory(personalmodel.PersonalRowID, "Allocated-RWQC-TM", "Allocated To RWQCTM");
                            #endregion
                        }
                        else
                        {
                            UnAllocatedCount++;
                        }
                    }
                }

                int pageSize = clsGlobalCommon.PageSize;
                model = repoReportQC.GetCandidateListForReportQCTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemberId, ClientRowID, tatHours);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            //BindClientList();
            BindClientListBaseOnLogin(teamMemberId);
            GetTMMemberForAllocation();
            return View(model);
        }

        #endregion

        #region ****** ReportQC TeamMember Bucket ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageAllCandidateListForReportQCTeamMember(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0)
        {
            PQPersonalReportQCListPagedModel model = new PQPersonalReportQCListPagedModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoReportQC.GetCandidateListForReportQCTeamMember(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemberId, ClientRowID);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            //BindClientList();
            BindClientListBaseOnLogin(teamMemberId);
            return View(model);
        }

        #endregion

        #region ******** Manage By ReportQC TeamMember ********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateAddressVerInfoByRWQC(int id)
        {
            ViewAddressViewModel model = new ViewAddressViewModel();
            try
            {
                if (id > 0)
                {
                    var verInfo = repoAddressVer.GetAddressInfoForTMQC(id);
                    if (verInfo != null)
                    {
                        model.AddressRowID = verInfo.AddressRowID;
                        model.CheckFamilyRowID = verInfo.CheckFamilyRowID;
                        model.ClientRowID = verInfo.ClientRowID;
                        model.PersonalRowID = verInfo.PersonalRowID;
                        model.SubCheckRowID = verInfo.SubCheckRowID;
                        model.CheckStatus = verInfo.CheckStatus;
                        ViewBag.VerifyInfo = verInfo;
                        verInfo.CloserViewModel = repoAddressVer.GetVerificationCloserDetails(verInfo.AddressVerRowID);
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        AddressVerList(model.AddressRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoAddressVer.GetPersonalDetailsForTM(model.AddressRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Employment id!";
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
        public ActionResult UpdateAddressVerInfoByRWQC(ViewAddressViewModel model)
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
                            repoReportQC.UpdateAddressCheckRejectionByRWQCTM(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressVerInfoByRWQC", "Rejected-RWQC", "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Rejected-RWQC", model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageCandidateChecksForReportQC", "ReportQC", new { PersonalRowID = model.PersonalRowID, dispFor = "Dashboard" });
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
            var verInfo = repoAddressVer.GetAddressInfoForTMQC(model.AddressRowID);
            if (verInfo != null)
            {
                ViewBag.VerifyInfo = verInfo;
                verInfo.CloserViewModel = repoAddressVer.GetVerificationCloserDetails(verInfo.AddressVerRowID);
            }
            AddressVerList(model.AddressRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID); model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateEmploymentVerInfoByRWQC(int id)
        {
            ViewEmploymentViewModel model = new ViewEmploymentViewModel();
            try
            {
                if (id > 0)
                {
                    var verInfo = repoEmploymentVer.GetEmploymentInfoForTMQC(id);
                    if (verInfo != null)
                    {
                        model.EmploymentRowID = verInfo.EmploymentRowID;
                        model.CheckFamilyRowID = verInfo.CheckFamilyRowID;
                        model.ClientRowID = verInfo.ClientRowID;
                        model.PersonalRowID = verInfo.PersonalRowID;
                        model.SubCheckRowID = verInfo.SubCheckRowID;
                        model.CheckStatus = verInfo.CheckStatus;
                        ViewBag.VerifyInfo = verInfo;
                        verInfo.CloserViewModel = repoEmploymentVer.GetEmploymentVerCloserDetails(verInfo.EmploymentVerRowID);
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        EmployementVerList(model.EmploymentRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEmploymentVer.GetPersonalDetailsForTM(model.EmploymentRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Employment id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            RatingNumber();
            BindCountry();
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateEmploymentVerInfoByRWQC(ViewEmploymentViewModel model)
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
                            repoReportQC.UpdateEmploymentCheckRejectionByRWQCTM(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentVerInfoByRWQC", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageCandidateChecksForReportQC", "ReportQC", new { PersonalRowID = model.PersonalRowID, dispFor = "Dashboard" });
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

            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateEducationVerInfoByRWQC(int id)
        {
            ViewEducationViewModel model = new ViewEducationViewModel();
            try
            {
                if (id > 0)
                {

                    var verInfo = repoEducationVer.GetEducationInfoForTMQC(id);

                    if (verInfo != null)
                    {
                        model.EducationRowID = verInfo.EducationRowID;
                        model.CheckFamilyRowID = verInfo.CheckFamilyRowID;
                        model.ClientRowID = verInfo.ClientRowID;
                        model.PersonalRowID = verInfo.PersonalRowID;
                        model.SubCheckRowID = verInfo.SubCheckRowID;
                        model.CheckStatus = verInfo.CheckStatus;
                        verInfo.CloserViewModel = repoEducationVer.GetEducationVerCloserDetails(verInfo.EducationVerRowID);
                        EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(model.EducationRowID);
                        ViewBag.VerifyInfo = verInfo;
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Education id!";
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
        public ActionResult UpdateEducationVerInfoByRWQC(ViewEducationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EducationRowID > 0)
                    {
                        #region Update Employment Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            repoReportQC.UpdateEducationCheckRejectionByRWQCTM(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationVerInfoByRWQC", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageCandidateChecksForReportQC", "ReportQC", new { PersonalRowID = model.PersonalRowID, dispFor = "Dashboard" });
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
            var verInfo = repoEducationVer.GetEducationInfoForTMQC(model.EducationRowID);
            if (verInfo != null)
            {
                ViewBag.VerifyInfo = verInfo;
                verInfo.CloserViewModel = repoEducationVer.GetEducationVerCloserDetails(verInfo.EducationVerRowID);
            }
            EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID); model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateReferenceVerInfoByRWQC(int id)
        {
            ViewReferenceViewModel model = new ViewReferenceViewModel();
            try
            {
                if (id > 0)
                {

                    var verInfo = repoReferenceVer.GetReferenceInfoForTMQC(id);

                    if (verInfo != null)
                    {
                        model.ReferenceRowID = verInfo.ReferenceCheckRowID;
                        model.CheckFamilyRowID = verInfo.CheckFamilyRowID;
                        model.ClientRowID = verInfo.ClientRowID;
                        model.PersonalRowID = verInfo.PersonalRowID;
                        model.SubCheckRowID = verInfo.SubCheckRowID;
                        model.CheckStatus = verInfo.CheckStatus;
                        ViewBag.VerifyInfo = verInfo;
                        verInfo.CloserViewModel = repoReferenceVer.GetReferenceVerCloserDetails(verInfo.ReferenceCheckVerRowID);
                        ReferenceVerList(model.ReferenceRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoReferenceVer.GetPersonalDetailsForTM(model.ReferenceRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Education id!";
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
        public ActionResult UpdateReferenceVerInfoByRWQC(ViewReferenceViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.ReferenceRowID > 0)
                    {
                        #region Update Employment Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            repoReportQC.UpdateReferenceCheckRejectionByRWQCTM(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceVerInfoByRWQC", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageCandidateChecksForReportQC", "ReportQC", new { PersonalRowID = model.PersonalRowID, dispFor = "Dashboard" });
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
            var verInfo = repoReferenceVer.GetReferenceInfoForTMQC(model.ReferenceRowID);
            if (verInfo != null)
            {
                ViewBag.VerifyInfo = verInfo;
                verInfo.CloserViewModel = repoReferenceVer.GetReferenceVerCloserDetails(verInfo.ReferenceCheckVerRowID);
            }
            ReferenceVerList(model.ReferenceRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateCriminalVerInfoByRWQC(int id)
        {

            ViewCriminalViewModel model = new ViewCriminalViewModel();
            try
            {
                if (id > 0)
                {

                    var verInfo = repoCriminalVer.GetCriminalForTMQC(id);

                    if (verInfo != null)
                    {
                        model.CriminalRowID = verInfo.CriminalRowID;
                        model.CheckFamilyRowID = verInfo.CheckFamilyRowID;
                        model.ClientRowID = verInfo.ClientRowID;
                        model.PersonalRowID = verInfo.PersonalRowID;
                        model.SubCheckRowID = verInfo.SubCheckRowID;
                        model.CheckStatus = verInfo.CheckStatus;
                        ViewBag.VerifyInfo = verInfo;
                        verInfo.CloserViewModel = repoCriminalVer.GetCriminalVerCloserDetails(verInfo.CriminalVerRowId);
                        CriminalVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoCriminalVer.GetPersonalDetailsForTM(model.CriminalRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Education id!";
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
        public ActionResult UpdateCriminalVerInfoByRWQC(ViewCriminalViewModel model)
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
                            repoReportQC.UpdateCriminalCheckRejectionByRWQCTM(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalVerInfoByRWQC", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion


                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageCandidateChecksForReportQC", "ReportQC", new { PersonalRowID = model.PersonalRowID, dispFor = "Dashboard" });
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
            var verInfo = repoCriminalVer.GetCriminalForTMQC(model.CriminalRowID);
            if (verInfo != null)
            {
                ViewBag.VerifyInfo = verInfo;
                verInfo.CloserViewModel = repoCriminalVer.GetCriminalVerCloserDetails(verInfo.CriminalVerRowId);
            }
            CriminalVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateNationalIdentityVerInfoByRWQC(int id)
        {

            ViewNationalIdentityViewModel model = new ViewNationalIdentityViewModel();
            try
            {
                if (id > 0)
                {

                    var verInfo = repoNationalIdentityVer.GetNationalIdentityForTMQC(id);

                    if (verInfo != null)
                    {
                        model.NationalIdentityRowID = verInfo.NationalIdentityRowID;
                        model.CheckFamilyRowID = verInfo.CheckFamilyRowID;
                        model.ClientRowID = verInfo.ClientRowID;
                        model.PersonalRowID = verInfo.PersonalRowID;
                        model.SubCheckRowID = verInfo.SubCheckRowID;
                        model.CheckStatus = verInfo.CheckStatus;
                        ViewBag.VerifyInfo = verInfo;
                        verInfo.CloserViewModel = repoNationalIdentityVer.GetNationalIdentityVerCloserDetails(verInfo.NationalIdentityVerRowID);
                        NationalIdentityVerList(model.NationalIdentityRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoNationalIdentityVer.GetPersonalDetailsForTM(model.NationalIdentityRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Education id!";
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
        public ActionResult UpdateNationalIdentityVerInfoByRWQC(ViewNationalIdentityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.NationalIdentityRowID > 0)
                    {
                        #region Update Criminal Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            repoReportQC.UpdateNationalIdentityCheckRejectionByRWQCTM(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityVerInfoByRWQC", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion


                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageCandidateChecksForReportQC", "ReportQC", new { PersonalRowID = model.PersonalRowID, dispFor = "Dashboard" });
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
            var verInfo = repoNationalIdentityVer.GetNationalIdentityForTMQC(model.NationalIdentityRowID);
            if (verInfo != null)
            {
                ViewBag.VerifyInfo = verInfo;
                verInfo.CloserViewModel = repoNationalIdentityVer.GetNationalIdentityVerCloserDetails(verInfo.NationalIdentityRowID);
            }
            NationalIdentityVerList(model.NationalIdentityRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateSpecialCheckVerInfoByRWQC(int id)
        {
            ViewSpecialCheckViewModel model = new ViewSpecialCheckViewModel();
            try
            {
                if (id > 0)
                {
                    var SpecialCheckdetail = repoSplChkVer.GetSpecialCheckInfoForTMQC(id);
                    if (SpecialCheckdetail == null)
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                        return View(model);
                    }
                    model.SpecialCheckRowId = SpecialCheckdetail.SpecialCheckRowID;
                    model.ClientRowID = SpecialCheckdetail.ClientRowID;
                    model.CheckFamilyRowID = SpecialCheckdetail.CheckFamilyRowID;
                    model.SubCheckRowID = SpecialCheckdetail.SubCheckRowID;
                    model.PersonalRowID = SpecialCheckdetail.PersonalRowID;
                    model.CheckStatus = SpecialCheckdetail.CheckStatus;
                    ViewBag.SpecialCheckdetails = SpecialCheckdetail;
                    SpecialCheckVerList(model.SpecialCheckRowId, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                    ViewBag.ListSpecialCheck = repoDDL.GetAntecedentList(model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                    model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
                    ViewBag.PersonalBind = repoSplChkVer.GetPersonalDetailsForTM(model.SpecialCheckRowId);
                }
                else
                {
                    ViewBag.ErrorMsg = "No detail found!";
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
        public ActionResult UpdateSpecialCheckVerInfoByRWQC(ViewSpecialCheckViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SpecialCheckRowId > 0)
                    {
                        #region Update SpecialCheck Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            repoReportQC.UpdateSpecialCheckRejectionByRWQCTM(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateSpecialCheckVerInfoByRWQC", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageCandidateChecksForReportQC", "ReportQC", new { PersonalRowID = model.PersonalRowID, dispFor = "Dashboard" });
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
            //var verInfo = repoCriminalVer.GetCriminalForTMQC(model.CriminalRowID);
            //if (verInfo != null)
            //{
            //    ViewBag.VerifyInfo = verInfo;
            //    verInfo.CloserViewModel = repoCriminalVer.GetCriminalVerCloserDetails(verInfo.CriminalVerRowId);
            //}
            //SpecialCheckVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }

        #endregion

        #region ******** ReportQC TM Map Artifacts ********

        [SessionExpireFilterAttribute]
        public ActionResult ManageCandidateChecksForReportQCTM(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0, int PersonalRowID = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoReportQC.GetCandidateCheckListForReportQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, PersonalRowID);

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            //BindClientList();
            BindClientListBaseOnLogin(teamMemberId);

            return View(model);

        }

        [SessionExpireFilterAttribute]
        public ActionResult UpdateRptArtifactsDocByRWQCTM(int page = 1, string sort = "", string sortDir = "asc", string Search = "", int Pid = 0, short SubCheckId = 0)
        {
            UploadedDocListForRWQCTMPagedModel model = new UploadedDocListForRWQCTMPagedModel();
            try
            {
                if (Pid > 0 && SubCheckId > 0)
                {
                    model.PersonalRowID = Pid;
                    model.SubCheckRowID = SubCheckId;
                    int pageSize = clsGlobalCommon.PageSize;

                    //model = repoPQVerifiedUploadDoc.GetCandidateUploadedDocListForRWQCTM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, Pid, SubCheckId);
                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(Pid);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
                    if (model == null)
                    {
                        ViewBag.ErrorMsg = "No Document Found!";
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateReportArtifactsDocByRWQCTM(int Pid = 0, short SubCheckId = 0)
        {
            UploadedDocListForRWQCTMPagedModel model = new UploadedDocListForRWQCTMPagedModel();
            try
            {
                if (Pid > 0 && SubCheckId > 0)
                {
                    int pageSize = clsGlobalCommon.PageSize;

                    model = repoPQVerifiedUploadDoc.GetCandidateUploadedDocListForRWQCTM(Pid, SubCheckId);
                    model.PersonalRowID = Pid;
                    model.SubCheckRowID = SubCheckId;
                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(Pid);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
                    if (model == null)
                    {
                        ViewBag.ErrorMsg = "No Document Found!";
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
        public ActionResult UpdateReportArtifactsDocByRWQCTM(FormCollection form, UploadedDocListForRWQCTMPagedModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<MapUploadedDocRWQCTMModel> dMapObj = new List<MapUploadedDocRWQCTMModel>();
                    MapUploadedDocRWQCTMModel MapObj;
                    if (model.AllDocIds != null)
                    {
                        long[] ids = model.AllDocIds.Split(',').Select(str => Int64.Parse(str)).ToArray();
                        foreach (var item in ids)
                        {
                            MapObj = new MapUploadedDocRWQCTMModel();
                            string txtRSeq = "txtRkSeq_" + item;
                            byte RSeq = Convert.ToByte(form[txtRSeq]);

                            MapObj.VerifiedUploadRowID = item;
                            MapObj.RptArtiFactOrder = Convert.ToByte(form[txtRSeq]);
                            dMapObj.Add(MapObj);
                        }
                    }
                    repoPQVerifiedUploadDoc.UpdateArtifactDocumentByRWQCTM(dMapObj, model.PersonalRowID, model.SubCheckRowID);

                    ViewBag.SuccessMsg = "Artifacts Mapped Successfully";
                    //return RedirectToAction("ManageCandidateChecksForReportQCTM", new { PersonalRowID = model.PersonalRowID, dispFor = "TeamMember" });
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
            model = repoPQVerifiedUploadDoc.GetCandidateUploadedDocListForRWQCTM(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateReportArtifactsCaseDocByRWQCTM(int Pid = 0)
        {
            UploadedCaseDocListForRWQCTMPagedModel model = new UploadedCaseDocListForRWQCTMPagedModel();
            try
            {
                if (Pid > 0)
                {
                    int pageSize = clsGlobalCommon.PageSize;

                    model = repoPQVerifiedUploadDoc.GetCandidateUploadedCaseDocListForRWQCTM(Pid);
                    model.PersonalRowID = Pid;
                    var CandDetail = repoPQPersonal.GetCandidateNameOrCmpIDById(Pid);
                    Session["CandidateName"] = CandDetail.CandTitle + " " + CandDetail.Name + " " + CandDetail.MiddleName + " " + CandDetail.LastName;
                    if (model == null)
                    {
                        ViewBag.ErrorMsg = "No Document Found!";
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
        public ActionResult UpdateReportArtifactsCaseDocByRWQCTM(FormCollection form, UploadedCaseDocListForRWQCTMPagedModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<MapUploadedDocRWQCTMModel> dMapObj = new List<MapUploadedDocRWQCTMModel>();
                    MapUploadedDocRWQCTMModel MapObj;
                    if (model.AllDocIds != null)
                    {
                        long[] ids = model.AllDocIds.Split(',').Select(str => Int64.Parse(str)).ToArray();
                        foreach (var item in ids)
                        {
                            MapObj = new MapUploadedDocRWQCTMModel();
                            string txtRSeq = "txtRkSeq_" + item;
                            byte RSeq = Convert.ToByte(form[txtRSeq]);

                            MapObj.VerifiedUploadRowID = item;
                            MapObj.RptArtiFactOrder = Convert.ToByte(form[txtRSeq]);
                            dMapObj.Add(MapObj);
                        }
                    }
                    repoPQVerifiedUploadDoc.UpdateArtifactCaseDocumentByRWQCTM(dMapObj, model.PersonalRowID);

                    ViewBag.SuccessMsg = "Artifacts Mapped Successfully";
                    //return RedirectToAction("ManageCandidateChecksForReportQCTM", new { PersonalRowID = model.PersonalRowID, dispFor = "TeamMember" });
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
            model = repoPQVerifiedUploadDoc.GetCandidateUploadedCaseDocListForRWQCTM(model.PersonalRowID);
            return View(model);
        }


        public JsonResult UpdateArtifactsById(long id = 0, bool checkeds = false)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    byte RptArtiFacts = checkeds == true ? Convert.ToByte(1) : Convert.ToByte(0);
                    //repoPQVerifiedUploadDoc.UpdateArtifactDocumentByRWQCTM(id, RptArtiFacts);
                }
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ******** Interim Report Writring ********

        [SessionExpireFilterAttribute]
        public ActionResult ReportInterim(int id = 0)
        {
            InterimReportGenerateViewModel model = new InterimReportGenerateViewModel();
            try
            {
                CandidatePdfLists(id);
                CandidateCasePdfLists(id);
                model = repoReportQC.GenerateCandidateInterimReportByReportQCTM(id);
                Session["SecritadRefId"] = model.CompanyRefNo;
                model.CandidateCaseDocList = repoReportQC.GetCandidateCaseDocListForReport(id);
                model.ReportDate = DateTime.Now;
                model.DocPath = ConfigurationManager.AppSettings["provideddocuments"].ToString();
                model.PersonalChecksBriefDetails = repoReportQC.GetCandidateChecksBriefDetailsByPersonalId(id);
                model.CandidateDocList = repoReportQC.GetCandidateDocListForReport(id);
                model.DocPath = ConfigurationManager.AppSettings["provideddocuments"].ToString();

                //model.AddressCheckList = repoAddressVer.GetAddressInfoForTMQC(id);

                #region ***** All Checks *****

                model.AddressProvidedList = repoReportQC.GetProvidedAddressForReportQC(id);
                model.AddressVerifiedList = repoReportQC.GetVerifiedAddressForReportQC(id);
                model.AntecedentList = repoReportQC.GetAntecedentVerList(model.ClientRowID);

                model.EmploymentProvidedList = repoReportQC.GetProvidedEmploymentForReportQC(id);
                model.EmploymentVerifiedList = repoReportQC.GetVerifiedEmploymentForReportQC(id);

                model.EducationProvidedList = repoReportQC.GetProvidedEducationForReportQC(id);
                model.EducationVerifiedList = repoReportQC.GetVerifiedEducationForReportQC(id);

                model.CriminalProvidedList = repoReportQC.GetProvidedCriminalForReportQC(id);
                model.CriminalVerifiedList = repoReportQC.GetVerifiedCriminalForReportQC(id);

                model.ReferenceProvidedList = repoReportQC.GetProvidedReferenceForReportQC(id);
                model.ReferenceVerifiedList = repoReportQC.GetVerifiedReferenceForReportQC(id);

                model.NationalIdentityProvidedList = repoReportQC.GetProvidedNationalIdentityForReportQC(id);
                model.NationalIdentityVerifiedList = repoReportQC.GetVerifiedNationalIdentityForReportQC(id);

                model.SpecialCheckProvidedList = repoReportQC.GetProvidedSpecialCheckForReportQC(id);
                model.SpecialCheckVerifiedList = repoReportQC.GetVerifiedSpecialCheckForReportQC(id);

                #endregion
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View(model);
        }

        public void CandidatePdfLists(int id)
        {
            string DocPath = ConfigurationManager.AppSettings["provideddocuments"].ToString();
            var CandidatePdfList = repoReportQC.GetCandidatePdfListForConversion(id);
            foreach (var item in CandidatePdfList)
            {
                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(Server.MapPath(DocPath + item.DocFile));
               
                if (f.PageCount > 0)
                {
                    string jpgFileName = item.DocFile.Replace(".pdf", "");
                    string ImageName = string.Empty;
                    for (int i = 1; i <= f.PageCount; i++)
                    {
                        ImageName += jpgFileName + i + ".jpg,";
                    }
                    if (!string.IsNullOrEmpty(ImageName) && ImageName.Length > 0)
                    {
                        ImageName = ImageName.Substring(0, ImageName.Length - 1);
                        bool res = repoReportQC.UpdateImageName(item.VerifiedUploadRowID, ImageName);
                        if (res)
                        {
                            int width = 644; // Width in Px
                            int height = 911; // Height in Px
                            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                            f.ImageOptions.Resize(new System.Drawing.Size { Width = width, Height = height }, false);
                            f.ImageOptions.Dpi = 200;
                            f.ToImage(Server.MapPath(DocPath), jpgFileName);
                        }
                    }
                }
            }
        }

        public void CandidateCasePdfLists(int id)
        {

            string DocPath = ConfigurationManager.AppSettings["provideddocuments"].ToString();
            var CandidatePdfList = repoReportQC.GetCandidateCasePdfListForReport(id);
            foreach (var item in CandidatePdfList)
            {
                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(Server.MapPath(DocPath + item.DocFile));
                if (f.PageCount > 0)
                {
                    string jpgFileName = item.DocFile.Replace(".pdf", "");
                    string ImageName = string.Empty;
                    for (int i = 1; i <= f.PageCount; i++)
                    {
                        ImageName += jpgFileName + i + ".jpg,";
                    }
                    if (!string.IsNullOrEmpty(ImageName) && ImageName.Length > 0)
                    {
                        ImageName = ImageName.Substring(0, ImageName.Length - 1);
                        bool res = repoReportQC.UpdateCaseImageName(item.CaseDocRowID, ImageName);
                        if (res)
                        {
                            int width = 644; // Width in Px
                            int height = 800; // Height in Px
                            f.ImageOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                            f.ImageOptions.Resize(new System.Drawing.Size { Width = width, Height = height }, false);
                            f.ImageOptions.Dpi = 200;
                            f.ToImage(Server.MapPath(DocPath), jpgFileName);
                        }
                    }
                }
            }
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult UploadReportPDFFileBYRWTM(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0 && Path.GetExtension(file.FileName).ToLower() == ".pdf")
                {
                    string FldPathDoc = string.Empty;
                    FldPathDoc = ConfigurationManager.AppSettings["CandidateReportdoc".Trim().ToLower()].ToString();

                    string SecuId =Convert.ToString(Session["SecritadRefId"]);
                    string ImgName = string.Empty;
                    string ext = System.IO.Path.GetExtension(file.FileName).ToLower();
                    ImgName = SecuId + ext;
                    file.SaveAs(Server.MapPath(FldPathDoc + ImgName));
                    repoReportQC.UpdatePQPersonalUploadReportDoc(SecuId, ImgName);
                    TempData["SuccessMsg"] = "Record Update Successfully!";
                }
                else
                {
                    TempData["ErrorMsg"] = "Please upload file having extension .pdf only.!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return RedirectToAction("ManageAllCandidateListForReportQCTeamMember");
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult ConverdReportPDFFileToWord(HttpPostedFileBase file)
        {
            try
            {
                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(file.InputStream);
                byte[] rtf = null;

                if (f.PageCount > 0)
                {
                    f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf;
                    //Let's whole PDF document to Word (RTF)
                    rtf = f.ToWord();
                }

                //show Word/rtf
                if (rtf != null)
                {
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = "application/msword";
                    Response.AddHeader("Content-Disposition:", "attachment; filename=ReportInWordFormet.doc");
                    Response.BinaryWrite(rtf);
                    Response.Flush();
                    Response.End();
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

        #region ***** Case Action Histories *****
        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult CaseActionHistories(int pid = 0)
        {
            try
            {
                ViewBag.CaseActionHistories = repoDDL.GetCaseActionHistories(pid);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return PartialView("_CaseActionHistories");
        }

        #endregion

        #region ****** NonAction ****** 

        [NonAction]
        void BindClientList()
        {
            try
            {
                ViewBag.ClientList = repoDDL.GetClientListWithAbbAndLocationForDDL();
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

        public void GetTLMemberForAllocation()
        {
            try
            {
                short depMgrID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depMgrID > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Manager-Rpt-QC")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-Rpt-QC");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetTMMemberForAllocation()
        {
            try
            {
                short depMgrID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depMgrID > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Team Leader-Rpt-QC")
                    {
                        ViewBag.depTeamMember = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Member-Rpt-QC");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
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
        void RatingNumber()
        {
            try
            {
                IEnumerable<SelectListItem> Numbers = new List<SelectListItem>
            {
              new SelectListItem { Text = "1", Value = "1" },
              new SelectListItem { Text = "2", Value = "2" },
              new SelectListItem { Text = "3", Value = "3" },
              new SelectListItem { Text = "4", Value = "4" },
              new SelectListItem { Text = "5", Value = "5" },
              new SelectListItem { Text = "6", Value = "6" },
              new SelectListItem { Text = "7", Value = "7" },
              new SelectListItem { Text = "8", Value = "8" },
              new SelectListItem { Text = "9", Value = "9" },
              new SelectListItem { Text = "10", Value = "10" },
            };
                ViewBag.RatingNumbers = Numbers;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindDisposition(short ChFamilRowId = 0, short ClientRowId = 0)
        {
            try
            {

                var DispositionList = repoDDL.DispositionForDDL(ChFamilRowId, ClientRowId);
                ViewBag.Disposition = new MultiSelectList(DispositionList, "DispositionRowId", "Disposition");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindDocumentList(int PersonalRowID = 0, short subCheckId = 0)
        {
            try
            {
                ViewBag.GetDocumentList = repoDDL.PQAddressVerGetDocumentList(PersonalRowID, subCheckId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void AddressVerList(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                //Bind AddressVer Details 
                ViewBag.modelBind = repoAddressVer.GetAddressForTM(id);

                ViewBag.ListAddressVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void EmployementVerList(int EmploymentRowID = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {

                //Bind EmployementVer Details 
                var modelBind = repoEmploymentVer.GetEmploymentForTM(EmploymentRowID);

                ViewBag.modelBind = modelBind;
                ViewBag.ListEmploymentVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }
        [NonAction]
        void EducationVerList(int EducationRowId = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                //Bind AddressVer Details 
                var modelBind = repoEducationVer.GetEducationForTM(EducationRowId);
                ViewBag.modelBind = modelBind;
                ViewBag.ListEducationVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        void CriminalVerList(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            ViewBag.modelBind = repoCriminalVer.GetCriminalForTM(id);
            ViewBag.ListCriminalVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
        }

        [NonAction]
        void ReferenceVerList(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            //Bind AddressVer Details 
            ViewBag.modelBind = repoReferenceVer.GetReferenceForTM(id);

            ViewBag.ListReferenceVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
        }

        [NonAction]
        void NationalIdentityVerList(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                ViewBag.modelBind = repoNationalIdentityVer.GetNationalIdentityForTM(id);
                ViewBag.ListNationalIdentityVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        void SpecialCheckVerList(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            ViewBag.modelBind = repoSplChkVer.GetSpecialCheckForTM(id);
            ViewBag.ListSplCheckVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
        }

        #endregion

        #region Export Excel 
        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportAddressMge(short ClientRowID = 0, byte AllocatedToTL = 0, byte tatHours = 0, string CaseStatus = "", string ReAllocation = "")
        {
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            string Designation = Convert.ToString(Session["Designation"]);
            try
            {
                #region Education Excel Export

                if (Designation == "Manager-Rpt-QC")
                {
                    var data = repoDashboardRWQC.GetExportRWQCListByMgr(Designation, teamMemerRowId, tatHours, CaseStatus);
                    if (CaseStatus == "CaseStatus1Time" && tatHours > 0)
                    {
                        var data1 = data.DashboardDetailsRWQC.Select(item => new RWExportViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CandidateCode,
                            CandidateName = item.CandidateName,
                            ClientRefID = item.CompanyRefNo,
                            Status = item.CaseStatus
                        }).ToList();
                        ExportToExcel(data1, "ManagerRptQC");
                    }
                    else
                    {

                        var data1 = data.DashboardDetailsRWQC.Select(item => new RWExportMgrViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.CandidateName,
                            CreatedDate = item.CreatedDate,
                            Final = item.FinalStatus,
                            Status = item.CaseStatus
                        }).ToList();
                        ExportToExcel(data1, "ManagerRptQC");
                    }
                }

                if (Designation == "Team Leader-Rpt-QC")
                {
                    var data = repoDashboardRWQC.GetExportRWQCListByTl(Designation, teamMemerRowId, tatHours, CaseStatus);
                    if (CaseStatus == "CaseStatus1Time" && tatHours > 0)
                    {
                        var data1 = data.DashboardDetailsRWQC.Select(item => new RWExportViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CandidateCode,
                            CandidateName = item.CandidateName,
                            ClientRefID = item.CompanyRefNo,
                            Status = item.CaseStatus
                        }).ToList();
                        ExportToExcel(data1, "TeamLeaderRptQC");
                    }
                    else
                    {
                        var data1 = data.DashboardDetailsRWQC.Select(item => new RWExportMgrViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.CandidateName,
                            CreatedDate = item.CreatedDate,
                            Final = item.FinalStatus,
                            Status = item.CaseStatus
                        }).ToList();
                        ExportToExcel(data1, "TeamLeadertQC");
                    }
                }
                if (Designation == "Team Member-Rpt-QC")
                {
                    var data = repoDashboardRWQC.GetExportRWQCListByTM(Designation, teamMemerRowId, tatHours, CaseStatus);
                    if (tatHours > 0)
                    {
                        var data1 = data.DashboardDetailsRWQC.Select(item => new TMExportMgrViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.CandidateName,
                            CreatedDate = item.CreatedDate,
                            Status = item.CaseStatus

                        }).ToList();
                        ExportToExcel(data1, "TeamMemberRptQC");
                    }
                    else if (CaseStatus == "CaseForReportQc")
                    {
                        var data1 = data.DashboardDetailsRWQC.Select(item => new TMCaseExportMgrViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.CandidateName,
                            ClientRefID = item.CandidateCode,
                            Final = item.FinalStatus,
                            Status = item.CaseStatus
                        }).ToList();
                        ExportToExcel(data1, "TeamMemberRptQC");
                    }
                    else
                    {

                        var data1 = data.DashboardDetailsRWQC.Select(item => new TMExportViewModel
                        {
                            PersonalRowID = item.PersonalRowID,
                            ClientName = item.ClientName,
                            CandidateName = item.CandidateName,
                            SecuritasID = item.CompanyRefNo,
                            CreatedDate = item.CreatedDate,
                            Status = item.CaseStatus
                        }).ToList();
                        ExportToExcel(data1, "TeamMemberRptQC");
                    }
                }


                #endregion
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

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

        #region ***** Non-Action Methods for Report Generation *****
        [NonAction]
        private string ReportHeader()
        {
            StringBuilder sbHeader = new StringBuilder("<tr style='line-height:0px;'>");
            sbHeader.AppendLine("<td width='2%' align='left' valign='top'><img src='@Url.Content('~/Images/top-left.jpg')' width='45' height='49' hspace='0' vspace='0'></td>");
            sbHeader.AppendLine("<td width='96%' valign='top' class='border-top'>&nbsp;</td>");
            sbHeader.AppendLine("<td align='right' valign='top'><img src='@Url.Content('~/Images/top-right.jpg')' width='45' height='49' hspace='0' vspace='0'></td>");
            sbHeader.AppendLine("</tr>");
            return sbHeader.ToString();
        }

        [NonAction]
        private string ReportFooter()
        {
            StringBuilder sbHeader = new StringBuilder("<tr>");
            sbHeader.AppendLine("<td align='left' valign='top'><img src='@Url.Content('~/Images/bottom-left.jpg')' width='45' height='45'></td>");
            sbHeader.AppendLine("<td valign='bottom' class='border-bottom'><img src='@Url.Content('~/Images/footer.jpg')' width='740' height='12'></td>");
            sbHeader.AppendLine("<td align='right' valign='top'><img src='@Url.Content('~/Images/bottom-right.jpg')' width='45' height='45'></td>");
            sbHeader.AppendLine("</tr>");
            return sbHeader.ToString();
        }
        
        #endregion
    }
}