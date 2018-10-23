using BAL;
using BAL.ClientRepository;
using BAL.PVRepository;
using BAL.VerificationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ViewModels.PVViewModels;
using ViewModels.VerificationViewModel;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class PVerificationController : Controller
    {
        #region ***** Repository Object *****
        IDashboardPVRepository repoDashboardPV;
        IPVInfoRepository repoPVInfo;
        IPQClientTMemberRepository repoPQClientTMember;
        IDropDownMasterRepository repoDDL;
        IPQEmploymentVerRepository repoEmploymentVer;
        IPQEducationVerRepository repoEducationVer;
        IPQCriminalVerRepository repoCriminalVer;
        //IEducationInfoRepository repoEducationInfo;
        //ICriminalInfoRepository repoCriminalInfo;
        public PVerificationController(
            IDashboardPVRepository _repoDashboardPV,
            IPVInfoRepository _repoPVInfo,
            IPQClientTMemberRepository _repoPQClientTMember,
            IDropDownMasterRepository _repoDDL,
            IPQEmploymentVerRepository _repoEmploymentVer
            , IPQEducationVerRepository _repoEducationVer
            , IPQCriminalVerRepository _repoCriminalVer
            //, IEducationInfoRepository _repoEducationInfo
            //, ICriminalInfoRepository _repoCriminalInfo
            )
        {
            repoDashboardPV = _repoDashboardPV;
            repoPVInfo = _repoPVInfo;
            repoPQClientTMember = _repoPQClientTMember;
            repoDDL = _repoDDL;
            repoEmploymentVer = _repoEmploymentVer;
            repoEducationVer = _repoEducationVer;
            repoCriminalVer = _repoCriminalVer;
            //repoEducationInfo = _repoEducationInfo;
            //repoCriminalInfo = _repoCriminalInfo;
        }
        #endregion

        // GET: PVerification
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                //Department Manager
                bool flagMgr = false;
                if (Designation == "Manager-PV")
                {
                    flagMgr = true;
                    ViewBag.DashboardEmp = "Employment Physical Verification Manager Dashboard!";
                    ViewBag.DashboardEdu = "Education Physical Verification Manager Dashboard!";
                    ViewBag.DashboardCri = "Criminal Physical Verification Manager Dashboard!";
                }

                if (flagMgr)
                {
                    DashboardEmpEduCriPVManagerViewModel model = repoDashboardPV.GetPVManagerDashBoardInfo(teamMemerRowId, Designation);
                    ViewBag.ManagerDashboardEmp = model.ManagerDashboardEmp;
                    ViewBag.ManagerDashboardEdu = model.ManagerDashboardEdu;
                    ViewBag.ManagerDashboardCri = model.ManagerDashboardCri;
                }

                //Department TeamLeader
                bool flagTL = false;
                if (Designation == "Team Leader-PV")
                {
                    flagTL = true;
                    ViewBag.DashboardEmp = "Employment Physical Verification TeamLeader Dashboard!";
                    ViewBag.DashboardEdu = "Education Physical Verification TeamLeader Dashboard!";
                    ViewBag.DashboardCri = "Criminal Physical Verification TeamLeader Dashboard!";
                }

                if (flagTL)
                {
                    DashboardEmpEduCriPVTLViewModel model = repoDashboardPV.GetPVTeamLeaderDashBoardInfo(teamMemerRowId, Designation);
                    ViewBag.TeamLeaderDashboardEmp = model.TeamLeaderDashboardEmp;
                    ViewBag.TeamLeaderDashboardEdu = model.TeamLeaderDashboardEdu;
                    ViewBag.TeamLeaderDashboardCri = model.TeamLeaderDashboardCri;
                }

                //Department TeamMember
                bool flagTM = false;
                if (Designation == "Team Member-PV")
                {
                    flagTM = true;
                    ViewBag.DashboardEmp = "Employment Physical Verification TeamMember Dashboard!";
                    ViewBag.DashboardEdu = "Education Physical Verification TeamMember Dashboard!";
                    ViewBag.DashboardCri = "Criminal Physical Verification TeamMember Dashboard!";
                }

                if (flagTM)
                {
                    DashboardEmpEduCriPVTMViewModel model = repoDashboardPV.GetPVTeamMemberDashBoardInfo(teamMemerRowId, Designation);
                    ViewBag.TeamMemberDashboardEmp = model.TeamMemberDashboardEmp;
                    ViewBag.TeamMemberDashboardEdu = model.TeamMemberDashboardEdu;
                    ViewBag.TeamMemberDashboardCri = model.TeamMemberDashboardCri;
                }

                //Department TeamMemberQC
                bool flagTMQC = false;
                if (Designation == "Team Member-PV-QC")
                {
                    flagTMQC = true;
                    ViewBag.DashboardEmp = "Employment Physical Verification TeamMemberQC Dashboard!";
                    ViewBag.DashboardEdu = "Education Physical Verification TeamMemberQC Dashboard!";
                    ViewBag.DashboardCri = "Criminal Physical Verification TeamMemberQC Dashboard!";
                }

                if (flagTMQC)
                {
                    DashboardEmpEduCriPVTMQCViewModel model = repoDashboardPV.GetPVTeamMemberQCDashBoardInfo(teamMemerRowId, Designation);
                    ViewBag.TeamMemberQCDashboardEmp = model.TeamMemberQCDashboardEmp;
                    ViewBag.TeamMemberQCDashboardEdu = model.TeamMemberQCDashboardEdu;
                    ViewBag.TeamMemberQCDashboardCri = model.TeamMemberQCDashboardCri;
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View();
        }

        #region ***** Employment For Manager And TL *****

        [SessionExpireFilterAttribute]
        public ActionResult EmploymentManagerPVAllocated(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, short AllocateTM = 0, short AllocateTMQC = 0, byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "", byte dtm = 0, byte dtmqc = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();

                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                CaseStatusOptionDropDown();
                CheckStatusOptionDropDown();

                if (Designation == "Manager-PV")
                {
                    model = repoPVInfo.GetCandidatePVEmploymentListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Leader-PV")
                {
                    model = repoPVInfo.GetCandidatePVEmploymentListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }

                else if (Designation == "Team Member-PV")
                {
                    model = repoPVInfo.GetCandidatePVEmploymentListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Member-PV-QC")
                {
                    model = repoPVInfo.GetCandidatePVEmploymentListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
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
        public ActionResult EmpPVManagerAllocationToTeamLeader(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocatePVTL = 0, short ClientRowID = 0, string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();
                GetTLMemberForAllocate();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                byte UnAllocatedCount = 0;
                if (Designation == "Manager-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocatePVTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        UpdatePVManagerViewModel empModel = new UpdatePVManagerViewModel();
                        empModel.ModifiedBy = teamMemerRowId;
                        empModel.ModifiedDate = DateTime.Now;
                        empModel.CheckStatus = "Allocated-TL";
                        empModel.PVTLAllocatedTo = AllocatePVTL;
                        empModel.PVTLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            empModel.PVCheckRowID = item;
                            var empDetails = repoPVInfo.GetPVEmploymentDetailsById(item);
                            bool result = repoPVInfo.IsClientDepartPVTeamMembersExist(empDetails.ClientRowID, empModel.PVTLAllocatedTo, "Physical Verification", "Team Leader-PV");
                            if (result)
                            {
                                repoPVInfo.UpdatePVEmploymentInfoByManager(empModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(empDetails.PersonalRowID, "EmpPVManagerAllocationToTeamLeader", empModel.CheckStatus, empDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(empDetails.PersonalRowID, empDetails.SubCheckRowID, empModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoPVInfo.GetCandidateEmploymentListForPVTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays);
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
        public ActionResult EmpPVTeamLeaderAllocationToTeamMember(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocateTM = 0, short AllocateTMQC = 0, short ClientRowID = 0, string OCVerIDs = "", string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                short depTMQCID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depTMQCID > 0)
                {
                    ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-PV");
                    ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-PV-QC");
                }

                byte UnAllocatedCount = 0;

                if (Designation == "Team Leader-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdatePVTeamLeaderViewModel empModel = new PQUpdatePVTeamLeaderViewModel();
                        empModel.ModifiedBy = teamMemerRowId;
                        empModel.ModifiedDate = DateTime.Now;
                        empModel.CheckStatus = "Allocated-TM";
                        empModel.PVTMAllocatedTo = AllocateTM;
                        empModel.PVTMAllocatedDate = DateTime.Now;
                        empModel.PVTMQCAllocatedTo = AllocateTMQC;
                        empModel.PVTMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            empModel.PVCheckRowID = item;
                            var empDetails = repoPVInfo.GetPVEmploymentDetailsById(item);
                            bool result = repoPVInfo.IsClientDepartPVTeamMembersExist(empDetails.ClientRowID, empModel.PVTMAllocatedTo, empModel.PVTMQCAllocatedTo, "Physical Verification", "Team Member-PV", "Team Member-PV-QC");

                            if (result)
                            {
                                repoPVInfo.UpdatePVEmploymentInfoByTeamLeader(empModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(empDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", empModel.CheckStatus, empDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(empDetails.PersonalRowID, empDetails.SubCheckRowID, empModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoPVInfo.GetCandidateEmploymentListForPVTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays);
                }

                if (UnAllocatedCount > 0)
                {
                    ViewBag.ErrorMsg = UnAllocatedCount.ToString() + " Check(s) not allocated because teammember/teammemberQC not mapped with client!";
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
        public ActionResult EmpPTRPVTeamMemberAllocationToPartnerMgr(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocatePTR = 0, short StateRowId = 0, string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;


                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                BindStateVendor(teamMemerRowId);
                GetVendorDDL(StateRowId);
                if (Designation == "Team Member-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocatePTR > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        UpdatePVPartnerTeamMemberViewModel empModel = new UpdatePVPartnerTeamMemberViewModel();
                        empModel.ModifiedBy = teamMemerRowId;
                        empModel.ModifiedDate = DateTime.Now;
                        empModel.CheckStatus = "Allocated-PTR";
                        empModel.PTRMgrAllocatedTo = AllocatePTR;

                        foreach (var item in verIDs)
                        {
                            empModel.PVCheckRowID = item;
                            var addDetails = repoPVInfo.GetPVEmploymentDetailsById(item);

                            repoPVInfo.UpdatePTRPVEmploymentInfoByTeamLeader(empModel);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "AddressTeamMemberAllocationToPartnerMgr", empModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, empModel.CheckStatus, "Team Member Allocated To Partner");
                            #endregion
                        }
                    }
                    model = repoPVInfo.GetCandidatePVEmploymentListForPTRMgrAllocationByTM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, StateRowId, CheckStatus, tatdays);
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

        #region ***** Employment Update by PV Teammember *****

        [SessionExpireFilterAttribute]
        public ActionResult EmploymentPVTMDashboardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, short AllocateTM = 0, short AllocateTMQC = 0, byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "", byte dtm = 0, byte dtmqc = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();

                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                CaseStatusOptionDropDown();
                CheckStatusOptionDropDown();

                if (Designation == "Team Member-PV")
                {
                    model = repoPVInfo.GetCandidatePVEmploymentListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Member-PV-QC")
                {
                    model = repoPVInfo.GetCandidatePVEmploymentListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
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
        public ActionResult UpdateEmploymentInfoByPVTeamMember(int id = 0)
        {
            PQEmploymentVerViewModel model = new PQEmploymentVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoEmploymentVer.GetEmploymentInfoForDataEntry(id);

                    if (model != null)
                    {
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
        public ActionResult UpdateEmploymentInfoByPVTeamMember(PQEmploymentVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        model.Status = 1;
                        if (model.EmploymentVerRowID > 0)
                        {
                            #region Update Employment Information
                            string Designation = Convert.ToString(Session["Designation"]);
                            if (Designation == "Team Member-PV")
                            {
                                model.CheckStatus = "Completed-TM";
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated BY PV-TM");
                            }

                            if (Designation == "Team Member-PV-QC")
                            {
                                if (model.CheckStatus != "Rejected")
                                {
                                    model.CheckStatus = "Completed-QC";
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By PV-TM-QC");
                                }
                                else
                                {
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Rejected By PV-TM-QC");
                                }
                            }

                            repoEmploymentVer.UpdateEmploymentByTeamMember(model);
                            repoEmploymentVer.SaveChanges();

                            repoPVInfo.UpdateEmploymentStatusByPVTM(model.EmploymentRowID, model.CheckStatus, DateTime.Now);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentInfoByPVTeamMember", model.CheckStatus, "Employment Verification", "Update");
                            #endregion                            

                            ModelState.Clear();
                            return RedirectToAction("UpdateEmploymentInfoByPVTeamMember", new { id = model.EmploymentRowID });

                            #endregion
                        }
                        else
                        {
                            #region Update Employment Information

                            repoPVInfo.AddEmploymentByPVTeamMember(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentInfoByPVTeamMember", "WIP-Pending", "Employment Verification", "Insert");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Completed-PV-TM", "Verification Information Submitted");
                            #endregion

                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            return RedirectToAction("UpdateEmploymentInfoByPVTeamMember", new { id = model.EmploymentRowID });

                            #endregion
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invlid Employment id and model!";
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

            BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
            EmployementVerList(model.EmploymentRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoEmploymentVer.GetPersonalDetailsForTM(model.EmploymentRowID);

            RatingNumber();
            BindCountry();
            return View(model);
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

        #endregion

        #region ***** Education For Manager And TL *****

        [SessionExpireFilterAttribute]
        public ActionResult EducationManagerPVAllocated(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte dtm = 0, byte dtmqc = 0, byte AllocatedToTL = 0, short AllocateTM = 0, short AllocateTMQC = 0, byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();

                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                CaseStatusOptionDropDown();
                CheckStatusOptionDropDown();

                if (Designation == "Manager-PV")
                {
                    model = repoPVInfo.GetCandidatePVEducationListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Leader-PV")
                {
                    model = repoPVInfo.GetCandidatePVEducationListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
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

        public ActionResult EduPVManagerAllocationToTeamLeader(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocatePVTL = 0, short ClientRowID = 0, string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();
                GetTLMemberForAllocate();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                byte UnAllocatedCount = 0;
                if (Designation == "Manager-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocatePVTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        UpdatePVManagerViewModel eduModel = new UpdatePVManagerViewModel();
                        eduModel.ModifiedBy = teamMemerRowId;
                        eduModel.ModifiedDate = DateTime.Now;
                        eduModel.CheckStatus = "Allocated-TL";
                        eduModel.PVTLAllocatedTo = AllocatePVTL;
                        eduModel.PVTLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            eduModel.PVCheckRowID = item;
                            var empDetails = repoPVInfo.GetPVEducationDetailsById(item);
                            bool result = repoPVInfo.IsClientDepartPVTeamMembersExist(empDetails.ClientRowID, eduModel.PVTLAllocatedTo, "Physical Verification", "Team Leader-PV");
                            if (result)
                            {
                                repoPVInfo.UpdatePVEducationInfoByManager(eduModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(empDetails.PersonalRowID, "EduPVManagerAllocationToTeamLeader", eduModel.CheckStatus, empDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(empDetails.PersonalRowID, empDetails.SubCheckRowID, eduModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoPVInfo.GetCandidateEducationListForPVTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays);
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
        public ActionResult EduPVTeamLeaderAllocationToTeamMember(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocateTM = 0, short AllocateTMQC = 0, short ClientRowID = 0, string OCVerIDs = "", string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                short depTMQCID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depTMQCID > 0)
                {
                    ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-PV");
                    ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-PV-QC");
                }

                byte UnAllocatedCount = 0;

                if (Designation == "Team Leader-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdatePVTeamLeaderViewModel eduModel = new PQUpdatePVTeamLeaderViewModel();
                        eduModel.ModifiedBy = teamMemerRowId;
                        eduModel.ModifiedDate = DateTime.Now;
                        eduModel.CheckStatus = "Allocated-TM";
                        eduModel.PVTMAllocatedTo = AllocateTM;
                        eduModel.PVTMAllocatedDate = DateTime.Now;
                        eduModel.PVTMQCAllocatedTo = AllocateTMQC;
                        eduModel.PVTMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            eduModel.PVCheckRowID = item;
                            var eduDetails = repoPVInfo.GetPVEducationDetailsById(item);
                            bool result = repoPVInfo.IsClientDepartPVTeamMembersExist(eduDetails.ClientRowID, eduModel.PVTMAllocatedTo, eduModel.PVTMQCAllocatedTo, "Physical Verification", "Team Member-PV", "Team Member-PV-QC");

                            if (result)
                            {
                                repoPVInfo.UpdatePVEducationInfoByTeamLeader(eduModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(eduDetails.PersonalRowID, "EduPVTeamLeaderAllocationToTeamMember", eduModel.CheckStatus, eduDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(eduDetails.PersonalRowID, eduDetails.SubCheckRowID, eduModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoPVInfo.GetCandidateEducationListForPVTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays);
                }

                if (UnAllocatedCount > 0)
                {
                    ViewBag.ErrorMsg = UnAllocatedCount.ToString() + " Check(s) not allocated because teammember/teammemberQC not mapped with client!";
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
        public ActionResult EduPTRPVTeamMemberAllocationToPartnerMgr(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocatePTR = 0, short StateRowId = 0, string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;


                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                BindStateVendor(teamMemerRowId);
                GetVendorDDL(StateRowId);
                if (Designation == "Team Member-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocatePTR > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        UpdatePVPartnerTeamMemberViewModel empModel = new UpdatePVPartnerTeamMemberViewModel();
                        empModel.ModifiedBy = teamMemerRowId;
                        empModel.ModifiedDate = DateTime.Now;
                        empModel.CheckStatus = "Allocated-PTR";
                        empModel.PTRMgrAllocatedTo = AllocatePTR;

                        foreach (var item in verIDs)
                        {
                            empModel.PVCheckRowID = item;
                            var addDetails = repoPVInfo.GetPVEducationDetailsById(item);

                            repoPVInfo.UpdatePTRPVEducationInfoByTeamLeader(empModel);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "AddressTeamMemberAllocationToPartnerMgr", empModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, empModel.CheckStatus, "Team Member Allocated To Partner");
                            #endregion
                        }
                    }
                    model = repoPVInfo.GetCandidatePVEducationListForPTRMgrAllocationByTM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, StateRowId, CheckStatus, tatdays);
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
        #endregion.

        #region ***** Education Update by PV Teammember *****

        [SessionExpireFilterAttribute]
        public ActionResult EducationPVTMDashboardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, short AllocateTM = 0, short AllocateTMQC = 0, byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "", byte dtm = 0, byte dtmqc = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();

                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                CaseStatusOptionDropDown();
                CheckStatusOptionDropDown();

                if (Designation == "Team Member-PV")
                {
                    model = repoPVInfo.GetCandidatePVEducationListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Member-PV-QC")
                {
                    model = repoPVInfo.GetCandidatePVEducationListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
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
        public ActionResult UpdateEducationInfoByPVTeamMember(int id = 0)
        {
            PQEducationVerViewModel model = new PQEducationVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoEducationVer.GetEducationInfoForDataEntry(id);

                    if (model != null)
                    {
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(model.EducationRowID);
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
            BindUniversityStatusList();
            BindAffliatiatedfrom();
            GetDegreeList();
            GetCollegeDDL();
            RatingNumber();
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateEducationInfoByPVTeamMember(PQEducationVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        model.Status = 1;
                        if (model.EducationVerRowID > 0)
                        {
                            #region Update Education Information
                            string Designation = Convert.ToString(Session["Designation"]);
                            if (Designation == "Team Member-PV")
                            {
                                model.CheckStatus = "Completed-TM";
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated BY PV-TM");
                            }

                            if (Designation == "Team Member-PV-QC")
                            {
                                if (model.CheckStatus != "Rejected")
                                {
                                    model.CheckStatus = "Completed-QC";
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By PV-TM-QC");
                                }
                                else
                                {
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Rejected By PV-TM-QC");
                                }
                            }

                            repoEducationVer.UpdateEducationByTeamMember(model);
                            repoEducationVer.SaveChanges();

                            repoPVInfo.UpdateEducationStatusByPVTM(model.EducationRowID, model.CheckStatus, DateTime.Now);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationInfoByPVTeamMember", model.CheckStatus, "Education Verification", "Update");
                            #endregion                            

                            ModelState.Clear();
                            return RedirectToAction("UpdateEducationInfoByPVTeamMember", new { id = model.EducationRowID });

                            #endregion
                        }
                        else
                        {
                            #region Update Education Information

                            repoPVInfo.AddEducationByPVTeamMember(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationInfoByPVTeamMember", "WIP-Pending", "Education Verification", "Insert");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Completed-PV-TM", "Verification Information Submitted");
                            #endregion

                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            return RedirectToAction("UpdateEducationInfoByPVTeamMember", new { id = model.EducationRowID });

                            #endregion
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invlid Education id and model!";
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

            BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
            EmployementVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(model.EducationRowID);

            BindUniversityStatusList();
            BindAffliatiatedfrom();
            GetDegreeList();
            GetCollegeDDL();
            RatingNumber();
            return View(model);
        }

        [NonAction]
        void EducationVerList(int EducationRowId = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                var modelBind = repoEducationVer.GetEducationForTM(EducationRowId);
                ViewBag.modelBind = modelBind;
                ViewBag.ListEducationVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ***** Criminal For Manager And TL *****

        [SessionExpireFilterAttribute]
        public ActionResult CriminalManagerPVAllocated(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte dtm = 0, byte dtmqc = 0, byte AllocatedToTL = 0, short AllocateTM = 0, short AllocateTMQC = 0, byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", short State = 0, short City = 0, short Partner = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();

                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                CaseStatusOptionDropDown();
                CheckStatusOptionDropDown();

                if (Designation == "Manager-PV")
                {
                    model = repoPVInfo.GetCandidatePVCriminalListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, State, City, Partner);
                }
                else if (Designation == "Team Leader-PV")
                {
                    model = repoPVInfo.GetCandidatePVCriminalListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, State, City, Partner);
                }
                else if (Designation == "Team Member-PV")
                {
                    model = repoPVInfo.GetCandidatePVCriminalListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Member-PV-QC")
                {
                    model = repoPVInfo.GetCandidatePVCriminalListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
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

        public ActionResult CriPVManagerAllocationToTeamLeader(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocatePVTL = 0, short ClientRowID = 0, string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();
                GetTLMemberForAllocate();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                byte UnAllocatedCount = 0;
                if (Designation == "Manager-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocatePVTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        UpdatePVManagerViewModel criModel = new UpdatePVManagerViewModel();
                        criModel.ModifiedBy = teamMemerRowId;
                        criModel.ModifiedDate = DateTime.Now;
                        criModel.CheckStatus = "Allocated-TL";
                        criModel.PVTLAllocatedTo = AllocatePVTL;
                        criModel.PVTLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            criModel.PVCheckRowID = item;
                            var empDetails = repoPVInfo.GetPVCriminalDetailsById(item);
                            bool result = repoPVInfo.IsClientDepartPVTeamMembersExist(empDetails.ClientRowID, criModel.PVTLAllocatedTo, "Physical Verification", "Team Leader-PV");
                            if (result)
                            {
                                repoPVInfo.UpdatePVCriminalInfoByManager(criModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(empDetails.PersonalRowID, "CriPVManagerAllocationToTeamLeader", criModel.CheckStatus, empDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(empDetails.PersonalRowID, empDetails.SubCheckRowID, criModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoPVInfo.GetCandidateCriminalListForPVTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays);
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
        public ActionResult CriPVTeamLeaderAllocationToTeamMember(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocateTM = 0, short AllocateTMQC = 0, short ClientRowID = 0, string OCVerIDs = "", string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                short depTMQCID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depTMQCID > 0)
                {
                    ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-PV");
                    ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-PV-QC");
                }

                byte UnAllocatedCount = 0;

                if (Designation == "Team Leader-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdatePVTeamLeaderViewModel criModel = new PQUpdatePVTeamLeaderViewModel();
                        criModel.ModifiedBy = teamMemerRowId;
                        criModel.ModifiedDate = DateTime.Now;
                        criModel.CheckStatus = "Allocated-TM";
                        criModel.PVTMAllocatedTo = AllocateTM;
                        criModel.PVTMAllocatedDate = DateTime.Now;
                        criModel.PVTMQCAllocatedTo = AllocateTMQC;
                        criModel.PVTMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            criModel.PVCheckRowID = item;
                            var criDetails = repoPVInfo.GetPVCriminalDetailsById(item);
                            bool result = repoPVInfo.IsClientDepartPVTeamMembersExist(criDetails.ClientRowID, criModel.PVTMAllocatedTo, criModel.PVTMQCAllocatedTo, "Physical Verification", "Team Member-PV", "Team Member-PV-QC");

                            if (result)
                            {
                                repoPVInfo.UpdatePVCriminalInfoByTeamLeader(criModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(criDetails.PersonalRowID, "CriPVTeamLeaderAllocationToTeamMember", criModel.CheckStatus, criDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(criDetails.PersonalRowID, criDetails.SubCheckRowID, criModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoPVInfo.GetCandidateCriminalListForPVTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays);
                }

                if (UnAllocatedCount > 0)
                {
                    ViewBag.ErrorMsg = UnAllocatedCount.ToString() + " Check(s) not allocated because teammember/teammemberQC not mapped with client!";
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
        public ActionResult CriPTRPVTeamMemberAllocationToPartnerMgr(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocatePTR = 0, short StateRowId = 0, string CheckStatus = "", byte tatdays = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;

                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                BindStateVendor(teamMemerRowId);
                GetVendorDDL(StateRowId);
                if (Designation == "Team Member-PV")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocatePTR > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        UpdatePVPartnerTeamMemberViewModel criModel = new UpdatePVPartnerTeamMemberViewModel();
                        criModel.ModifiedBy = teamMemerRowId;
                        criModel.ModifiedDate = DateTime.Now;
                        criModel.CheckStatus = "Allocated-PTR";
                        criModel.PTRMgrAllocatedTo = AllocatePTR;

                        foreach (var item in verIDs)
                        {
                            criModel.PVCheckRowID = item;
                            var criDetails = repoPVInfo.GetPVCriminalDetailsById(item);

                            repoPVInfo.UpdatePTRPVCriminalInfoByTeamLeader(criModel);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(criDetails.PersonalRowID, "CriPTRPVTeamMemberAllocationToPartnerMgr", criModel.CheckStatus, criDetails.UniqueComponentID, "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(criDetails.PersonalRowID, criDetails.SubCheckRowID, criModel.CheckStatus, "PV Team Member Allocated To Partner");
                            #endregion
                        }
                    }
                    model = repoPVInfo.GetCandidatePVCriminalListForPTRMgrAllocationByTM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, StateRowId, CheckStatus, tatdays);
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

        #region ***** Criminal Update by PV Teammember *****

        [SessionExpireFilterAttribute]
        public ActionResult CriminalPVTMDashboardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, short AllocateTM = 0, short AllocateTMQC = 0, byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "", byte dtm = 0, byte dtmqc = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = 20;
                BindClientList();

                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                CaseStatusOptionDropDown();
                CheckStatusOptionDropDown();

                if (Designation == "Team Member-PV")
                {
                    model = repoPVInfo.GetCandidatePVCriminalListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Member-PV-QC")
                {
                    model = repoPVInfo.GetCandidatePVCriminalListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
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
        public ActionResult UpdateCriminalInfoByPVTeamMember(int id = 0)
        {
            PQCriminalVerViewModel model = new PQCriminalVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoCriminalVer.GetCriminalInfoForDataEntry(id);

                    if (model != null)
                    {
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        CriminalVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoCriminalVer.GetPersonalDetailsForTM(model.CriminalRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Criminal id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            CriminalOptionDropDown();
            RatingNumber();
            BindCountry();
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateCriminalInfoByPVTeamMember(PQCriminalVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        model.Status = 1;
                        if (model.CriminalVerRowId > 0)
                        {
                            #region Update Criminal Information
                            string Designation = Convert.ToString(Session["Designation"]);
                            if (Designation == "Team Member-PV")
                            {
                                model.CheckStatus = "Completed-TM";
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated BY PV-TM");
                            }

                            if (Designation == "Team Member-PV-QC")
                            {
                                if (model.CheckStatus != "Rejected")
                                {
                                    model.CheckStatus = "Completed-QC";
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By PV-TM-QC");
                                }
                                else
                                {
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Rejected By PV-TM-QC");
                                }
                            }

                            repoCriminalVer.UpdateCriminalByTeamMember(model);
                            repoCriminalVer.SaveChanges();

                            repoPVInfo.UpdateCriminalStatusByPVTM(model.CriminalRowID, model.CheckStatus, DateTime.Now);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalInfoByPVTeamMember", model.CheckStatus, "Criminal Verification", "Update");
                            #endregion                            

                            ModelState.Clear();
                            return RedirectToAction("UpdateCriminalInfoByPVTeamMember", new { id = model.CriminalRowID });

                            #endregion
                        }
                        else
                        {
                            #region Update Criminal Information

                            repoPVInfo.AddCriminalByPVTeamMember(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalInfoByPVTeamMember", "WIP-Pending", "Criminal Verification", "Insert");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Completed-PV-TM", "Verification Information Submitted");
                            #endregion

                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            return RedirectToAction("UpdateCriminalInfoByPVTeamMember", new { id = model.CriminalRowID });

                            #endregion
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invlid Criminal id and model!";
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

            BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
            EmployementVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoCriminalVer.GetPersonalDetailsForTM(model.CriminalRowID);

            CriminalOptionDropDown();
            RatingNumber();
            BindCountry();
            return View(model);
        }

        [NonAction]
        void CriminalVerList(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            ViewBag.modelBind = repoCriminalVer.GetCriminalForTM(id);
            ViewBag.ListCriminalVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
        }

        #endregion

        #region ***** NO Action *****

        [SessionExpireFilterAttribute]
        public void GetTLMemberForAllocate()
        {
            try
            {
                short depMgrID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depMgrID > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Manager-PV")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-PV");
                    }
                }
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
                ViewBag.ClientList = repoDDL.GetClientListWithAbbAndLocationForDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void CheckStatusOptionDropDown()
        {
            try
            {
                IEnumerable<SelectListItem> CheckStatusOption = new List<SelectListItem>
            {
                    new SelectListItem { Text = "Allocated-Mgr", Value = "Allocated-Mgr" },
                    new SelectListItem { Text = "Allocated-TL", Value = "Allocated-TL" },
                    new SelectListItem { Text = "Completed-QC", Value = "Completed-QC" },
                    new SelectListItem { Text = "RW-Approval-TL", Value = "RW-Approval-TL" },
                    new SelectListItem { Text = "RW-Approval-Mgr", Value = "RW-Approval-Mgr" },
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
                    new SelectListItem { Text = "Allocated-PTR", Value = "Allocated-PTR" },
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

        void BindStateVendor(short teamMemerRowId)
        {
            short CountryRowID = 106;
            try
            {
                ViewBag.StateList = repoDDL.GetStatesByCountryIdForDDL(CountryRowID, teamMemerRowId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        public void GetVendorDDL(short StateRowId = 0)
        {
            try
            {
                ViewBag.VendorList = repoDDL.GetVendorForDDL(StateRowId);
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
        public void BindAffliatiatedfrom()
        {
            try
            {
                IEnumerable<SelectListItem> AffliatiatedfromList = new List<SelectListItem> {
            new SelectListItem { Text = "UGC", Value = "UGC" },
            new SelectListItem { Text = "AICTE", Value = "AICTE" },
            new SelectListItem { Text = "DEC", Value = "DEC" },
            new SelectListItem { Text = "AIMA", Value = "AIMA" },
            new SelectListItem { Text = "Others", Value = "Others" },
            };
                ViewBag.AffliatiatedfromList = AffliatiatedfromList;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        public void BindUniversityStatusList()
        {
            try
            {

                IEnumerable<SelectListItem> UniverSityStatusList = new List<SelectListItem> {
            new SelectListItem { Text = "Fake", Value = "Fake" },
            new SelectListItem { Text = "Genuine", Value = "Genuine" },
            new SelectListItem { Text = "Shutdown", Value = "Shutdown" },
            new SelectListItem { Text = "Shifted", Value = "Shifted" },
            new SelectListItem { Text = "Operation ceased", Value = "Operation ceased" },
            new SelectListItem { Text = "Small Institute", Value = "Small Institute" },
            //new SelectListItem { Text = "AIMA", Value = "AIMA" },
            new SelectListItem { Text = "Others", Value = "Others" },
            };
                ViewBag.UniverSityStatusList = UniverSityStatusList;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }
        [NonAction]
        public void GetDegreeList()
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

        [NonAction]
        public void GetCollegeDDL()
        {
            try
            {
                ViewBag.CollegeList = repoDDL.GetCollegeDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void CriminalOptionDropDown()
        {
            try
            {
                IEnumerable<SelectListItem> CriminalOption = new List<SelectListItem>
            {
              new SelectListItem { Text = "Match Found", Value = "Match Found" },
              new SelectListItem { Text = "No Match Found ", Value = "No Match Found " },
              new SelectListItem { Text = "Possible  Match found", Value = " Possible  Match found" },
              new SelectListItem { Text = "Record Found", Value = "Record Found" },
              new SelectListItem { Text = "No Record found ", Value = "No Record found" },
              new SelectListItem { Text = "Other", Value = "Other" },
            };
                ViewBag.CriminalOptionList = CriminalOption;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ***** Export Excel *****     
        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportCriminalPV(short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, byte tatdays = 0, string DCheckStatus = "", string CaseStatus = "", string ReAllocation = "")
        {
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            string Designation = Convert.ToString(Session["Designation"]);
            try
            {
                #region Criminal Excel Export

                if (Designation == "Manager-PV")
                {
                    var data = repoPVInfo.GetExportCandidateCriminalListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalMgePV");
                    }
                    else
                    {

                        var data1 = data.PQVerificationInfo.Select(item => new PVExportVerificationMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.OutDate,
                            SPOC = item.SecuritasSPOC,
                            AllocatedTL = item.AllocatedTLName,
                            AllocatedTM = item.AllocatedTMName,
                            AllocatedQC = item.AllocatedQCName,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalMgePV");
                    }
                }
                if (Designation == "Team Leader-PV" || Designation == "Team Member-PV-QC")
                {
                    var data = repoPVInfo.GetExportCandidateCriminalListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus, ReAllocation);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalTLOrQCPV");
                    }
                    else
                    {
                        var data2 = data.PQVerificationInfo.Select(item => new ExportVerificationAddTLViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.OutDate,
                            SPOC = item.SecuritasSPOC,
                            AllocatedTM = item.AllocatedTMName,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data2, "CriminalTLOrQCPV");
                    }
                }
                if (Designation == "Team Member-PV")
                {
                    var data = repoPVInfo.GetExportCandidateCriminalListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalTMPV");
                    }
                    else
                    {
                        var data3 = data.PQVerificationInfo.Select(item => new ExportVerificationAddTMViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.OutDate,
                            SPOC = item.SecuritasSPOC,
                            Partner = item.Partner,
                            Location = item.Location,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data3, "CriminalTMPV");
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

        public void ExportEducationPV(short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, byte tatdays = 0, string DCheckStatus = "", string CaseStatus = "", string ReAllocation = "")
        {
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            string Designation = Convert.ToString(Session["Designation"]);
            try
            {
                #region Education Excel Export

                if (Designation == "Manager-PV")
                {
                    var data = repoPVInfo.GetExportCandidateEducationListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EducationPVMge");
                    }
                    else
                    {

                        var data1 = data.PQVerificationInfo.Select(item => new PVExportVerificationMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.OutDate,
                            SPOC = item.SecuritasSPOC,
                            AllocatedTL = item.AllocatedTLName,
                            AllocatedTM = item.AllocatedTMName,
                            AllocatedQC = item.AllocatedQCName,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EducationPVMge");
                    }
                }
                if (Designation == "Team Leader-PV" || Designation == "Team Member-PV-QC")
                {
                    var data = repoPVInfo.GetExportCandidateEducationListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EducationTLOrQC");
                    }
                    else
                    {
                        var data2 = data.PQVerificationInfo.Select(item => new ExportVerificationEduTLViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.OutDate,
                            SPOC = item.SecuritasSPOC,
                            AllocatedTM = item.AllocatedTMName,
                            AllocatedQC = item.AllocatedQCName,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data2, "EducationTLOrQC");
                    }
                }
                if (Designation == "Team Member-PV")
                {
                    var data = repoPVInfo.GetExportCandidateEducationListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalTMPV");
                    }
                    else
                    {
                        var data3 = data.PQVerificationInfo.Select(item => new ExportVerificationTMMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.OutDate,
                            SPOC = item.SecuritasSPOC,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data3, "CriminalTMPV");
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

        public void ExportEmploymentPV(short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, byte tatdays = 0, string DCheckStatus = "", string CaseStatus = "", string ReAllocation = "")
        {
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            string Designation = Convert.ToString(Session["Designation"]);
            try
            {
                #region Employee Excel Export

                if (Designation == "Manager-PV")
                {
                    var data = repoPVInfo.GetExportCandidateEmployeeListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EmployeePVMge");
                    }
                    else
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportVerificationMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.InternalOutDate,
                            SPOC = item.SecuritasSPOC,
                            AllocatedTL = item.AllocatedTLName,
                            AllocatedTM = item.AllocatedTMName,
                            AllocatedQC = item.AllocatedQCName,
                            CheckStatus = item.CheckStatus
                        }).ToList();

                        ExportToExcel(data1, "EmployeePVMge");
                    }


                }
                if (Designation == "Team Leader-PV" || Designation == "Team Member-PV-QC")
                {
                    var data = repoPVInfo.GetExportCandidateEmployeeListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EducationTLOrQC");
                    }
                    else
                    {
                        var data2 = data.PQVerificationInfo.Select(item => new ExportVerificationEduTLViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.OutDate,
                            SPOC = item.SecuritasSPOC,
                            AllocatedTM = item.AllocatedTMName,
                            AllocatedQC = item.AllocatedQCName,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data2, "EducationTLOrQC");
                    }
                }
                if (Designation == "Team Member-PV")
                {
                    var data = repoPVInfo.GetExportCandidateEmployeeListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationTOPV" || tatdays > 0)
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new PVExportMgrViewModel
                        {

                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            Status = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EducationTLOrQC");
                    }
                    else
                    {
                        var data3 = data.PQVerificationInfo.Select(item => new ExportVerificationTMMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            Ageing = item.InternalOutDate != null ? (item.InternalOutDate - DateTime.Now).Value.Days : 0,
                            TAT = item.OutDate,
                            SPOC = item.SecuritasSPOC,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data3, "EducationTLOrQC");
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

        #region ***** Export To Excel *****

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