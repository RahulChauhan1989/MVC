using BAL;
using BAL.CandidateRepository;
using BAL.ClientRepository;
using BAL.HRRepository;
using BAL.PartnerRepository;
using BAL.ProvidedInfoRepository;
using BAL.VerificationRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ViewModels.CandidateViewModel;
using ViewModels.ProvidedInfoViewModel;
using ViewModels.VerificationViewModel;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class VerificationController : Controller
    {
        #region ******  Repository Objects ******

        IDropDownMasterRepository repoDDL;
        IPQPersonalRepository repoPQPersonal;
        IPQClientRepository repoPQClient;
        IAbbreviationRepository repoAbbreviation;

        IVerificationInfoRepository repoVerificationInfo;

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
        ISubCheckFamilyRepository repoSubCheckFamily;
        IPQVerifiedUploadDocRepository repoPQVerifiedUploadDoc;
        IPQClientCompnayUploadDocRepository repoClientCmpUplod;
        IPQAddressVerRepository repoAddressVer;
        IDashboardVerificationRepository repoDashboard;
        IPQEmploymentVerRepository repoEmploymentVer;
        IPQEducationVerRepository repoEducationVer;
        IPQCriminalVerRepository repoCriminalVer;
        IPQReferenceVerRepository repoReferenceVer;
        IPQNationalIdentityVerRepository repoNationalIdentityVer;
        IEmailVerificationRepository repoEmailVerification;
        ITeamDepartmentRepository repoTeamDepartment;
        IPartnerVerificationRepository repoPartnerVerification;
        IPQCandidateLoginRepository repoPQCandidateLogin;
        ISpecialVerificationRepository repoSplChkVer;

        public VerificationController(
            IDropDownMasterRepository _repoDDL
            , IPQPersonalRepository _repoPQPersonal
            , IPQClientRepository _repoPQClient
            , IAbbreviationRepository _repoAbbreviation
             , IVerificationInfoRepository _repoVerificationInfo
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
            , ISubCheckFamilyRepository _repoSubCheckFamily
            , IPQVerifiedUploadDocRepository _repoPQVerifiedUploadDoc
            , IPQClientCompnayUploadDocRepository _repoClientCmpUplod
            , IPQAddressVerRepository _repoAddressVer
            , IDashboardVerificationRepository _repoDashboard
            , IPQEmploymentVerRepository _repoEmploymentVer
            , IPQEducationVerRepository _repoEducationVer
            , IPQCriminalVerRepository _repoCriminalVer
            , IPQReferenceVerRepository _repoReferenceVer
            , IPQNationalIdentityVerRepository _repoNationalIdentityVer
            , IEmailVerificationRepository _repoEmailVerification
            , ITeamDepartmentRepository _repoTeamDepartment
            , IPartnerVerificationRepository _repoPartnerVerification
            , IPQCandidateLoginRepository _repoPQCandidateLogin
            , ISpecialVerificationRepository _repoSplChkVer
            )
        {
            repoDDL = _repoDDL;
            repoPQPersonal = _repoPQPersonal;
            repoPQClient = _repoPQClient;
            repoAbbreviation = _repoAbbreviation;
            repoVerificationInfo = _repoVerificationInfo;
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
            repoSubCheckFamily = _repoSubCheckFamily;
            repoPQVerifiedUploadDoc = _repoPQVerifiedUploadDoc;
            repoClientCmpUplod = _repoClientCmpUplod;
            repoAddressVer = _repoAddressVer;
            repoDashboard = _repoDashboard;
            repoEmploymentVer = _repoEmploymentVer;
            repoEducationVer = _repoEducationVer;
            repoCriminalVer = _repoCriminalVer;
            repoReferenceVer = _repoReferenceVer;
            repoNationalIdentityVer = _repoNationalIdentityVer;
            repoEmailVerification = _repoEmailVerification;
            repoTeamDepartment = _repoTeamDepartment;
            repoPartnerVerification = _repoPartnerVerification;
            repoPQCandidateLogin = _repoPQCandidateLogin;
            repoSplChkVer = _repoSplChkVer;
        }

        #endregion

        // GET: Verification
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                //Department Manager
                bool flagMgr = false;
                if (Designation == "Manager-Add")
                {
                    flagMgr = true;
                    ViewBag.Dashboard = "Address Verification Manager Dashboard!";
                }
                else if (Designation == "Manager-Emp")
                {
                    flagMgr = true;
                    ViewBag.Dashboard = "Employment Verification Manager Dashboard!";
                }
                else if (Designation == "Manager-Edu")
                {
                    flagMgr = true;
                    ViewBag.Dashboard = "Education Verification Manager Dashboard!";
                }
                else if (Designation == "Manager-Cri")
                {
                    flagMgr = true;
                    ViewBag.Dashboard = "Criminal Verification Manager Dashboard!";
                }
                else if (Designation == "Manager-Ref")
                {
                    flagMgr = true;
                    ViewBag.Dashboard = "Reference Verification Manager Dashboard!";
                }
                else if (Designation == "Manager-Ide")
                {
                    flagMgr = true;
                    ViewBag.Dashboard = "National Identity Verification Manager Dashboard!";
                }
                else if (Designation == "Manager-SPL")
                {
                    flagMgr = true;
                    ViewBag.Dashboard = "Special Check Verification Manager Dashboard!";
                }

                if (flagMgr)
                {
                    ViewBag.ManagerDashboard = repoDashboard.GetManagerDashBoardInfo(teamMemerRowId, Designation);
                }

                //Department TeamLeader
                bool flagTL = false;
                if (Designation == "Team Leader-Add")
                {
                    flagTL = true;
                    ViewBag.Dashboard = "Address Verification TeamLeader Dashboard!";
                }
                else if (Designation == "Team Leader-Emp")
                {
                    flagTL = true;
                    ViewBag.Dashboard = "Employment Verification TeamLeader Dashboard!";
                }
                else if (Designation == "Team Leader-Edu")
                {
                    flagTL = true;
                    ViewBag.Dashboard = "Education Verification TeamLeader Dashboard!";
                }
                else if (Designation == "Team Leader-Cri")
                {
                    flagTL = true;
                    ViewBag.Dashboard = "Criminal Verification TeamLeader Dashboard!";
                }
                else if (Designation == "Team Leader-Ref")
                {
                    flagTL = true;
                    ViewBag.Dashboard = "Reference Verification TeamLeader Dashboard!";
                }
                else if (Designation == "Team Leader-Ide")
                {
                    flagTL = true;
                    ViewBag.Dashboard = "National Identity Verification TeamLeader Dashboard!";
                }
                else if (Designation == "Team Leader-SPL")
                {
                    flagTL = true;
                    ViewBag.Dashboard = "Special Check Verification TeamLeader Dashboard!";
                }

                if (flagTL)
                {
                    ViewBag.TeamLeaderDashboard = repoDashboard.GetTeamLeaderDashBoardInfo(teamMemerRowId, Designation);
                }

                //Department TeamMember
                bool flagTM = false;
                if (Designation == "Team Member-Add")
                {
                    flagTM = true;
                    ViewBag.Dashboard = "Address Verification TeamMember Dashboard!";
                }
                else if (Designation == "Team Member-Emp")
                {
                    flagTM = true;
                    ViewBag.Dashboard = "Employment Verification TeamMember Dashboard!";
                }
                else if (Designation == "Team Member-Edu")
                {
                    flagTM = true;
                    ViewBag.Dashboard = "Education Verification TeamMember Dashboard!";
                }
                else if (Designation == "Team Member-Cri")
                {
                    flagTM = true;
                    ViewBag.Dashboard = "Criminal Verification TeamMember Dashboard!";
                }
                else if (Designation == "Team Member-Ref")
                {
                    flagTM = true;
                    ViewBag.Dashboard = "Reference Verification TeamMember Dashboard!";
                }
                else if (Designation == "Team Member-Ide")
                {
                    flagTM = true;
                    ViewBag.Dashboard = "National Identity Verification TeamMember Dashboard!";
                }
                else if (Designation == "Team Member-SPL")
                {
                    flagTM = true;
                    ViewBag.Dashboard = "Special Check Verification TeamMember Dashboard!";
                }

                if (flagTM)
                {
                    ViewBag.TeamMemberDashboard = repoDashboard.GetTeamMemberDashBoardInfo(teamMemerRowId, Designation);
                }

                //Department TeamMemberQC
                bool flagTMQC = false;
                if (Designation == "Team Member-Add-QC")
                {
                    flagTMQC = true;
                    ViewBag.Dashboard = "Address Verification TeamMemberQC Dashboard!";
                }
                else if (Designation == "Team Member-Emp-QC")
                {
                    flagTMQC = true;
                    ViewBag.Dashboard = "Employment Verification TeamMemberQC Dashboard!";
                }
                else if (Designation == "Team Member-Edu-QC")
                {
                    flagTMQC = true;
                    ViewBag.Dashboard = "Education Verification TeamMemberQC Dashboard!";
                }
                else if (Designation == "Team Member-Cri-QC")
                {
                    flagTMQC = true;
                    ViewBag.Dashboard = "Criminal Verification TeamMemberQC Dashboard!";
                }
                else if (Designation == "Team Member-Ref-QC")
                {
                    flagTMQC = true;
                    ViewBag.Dashboard = "Reference Verification TeamMemberQC Dashboard!";
                }
                else if (Designation == "Team Member-Ide-QC")
                {
                    flagTMQC = true;
                    ViewBag.Dashboard = "National Identity Verification TeamMemberQC Dashboard!";
                }
                else if (Designation == "Team Member-SPL-QC")
                {
                    flagTMQC = true;
                    ViewBag.Dashboard = "Special Check Verification TeamMemberQC Dashboard!";
                }

                if (flagTMQC)
                {
                    ViewBag.TeamMemberQCDashboard = repoDashboard.GetTeamMemberQCDashBoardInfo(teamMemerRowId, Designation);
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return View();
        }

        #region ******** Department Allocation Management ********

        [SessionExpireFilterAttribute]
        public ActionResult DepartmentManagerAllocation(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "", short State = 0, short City = 0, short Partner = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                BindClientListBaseOnLogin(teamMemerRowId);
                CaseStatusOptionDropDown();
                CheckStatusOptionDropDown();
                if (Designation == "Manager-Add")
                {
                    BindCities();
                    BindStates();
                    BindPartneres();
                    model = repoVerificationInfo.GetCandidateAddressListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, State, City, Partner);
                }
                else if (Designation == "Manager-Emp")
                {
                    model = repoVerificationInfo.GetCandidateEmploymentListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Manager-Edu")
                {
                    model = repoVerificationInfo.GetCandidateEducationListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Manager-Cri")
                {
                    model = repoVerificationInfo.GetCandidateCriminalListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, State, City, Partner);
                }
                else if (Designation == "Manager-Ref")
                {
                    model = repoVerificationInfo.GetCandidateReferenceListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Manager-Ide")
                {
                    model = repoVerificationInfo.GetCandidateIdentityListByDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Manager-SPL")
                {
                    model = repoVerificationInfo.GetCandidateSpecialCheckListByManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
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
        public ActionResult ManagerAllocationToTeamLeader(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocateTL = 0, short ClientRowID = 0, string CheckStatus = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                BindClientListBaseOnLogin(teamMemerRowId);
                GetTLMemberForAllocate();

                byte UnAllocatedCount = 0;
                if (Designation == "Manager-Add")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateAddressManagerViewModel addModel = new PQUpdateAddressManagerViewModel();
                        addModel.ModifiedBy = teamMemerRowId;
                        addModel.ModifiedDate = DateTime.Now;
                        addModel.CheckStatus = "Allocated-TL";
                        addModel.TLAllocatedTo = AllocateTL;
                        addModel.TLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            addModel.AddressRowID = item;
                            var addDetails = repoAddressInfo.GetPQAddressDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(addDetails.ClientRowID, addModel.TLAllocatedTo, "Address", "Team Leader-Add");

                            if (result)
                            {
                                repoAddressInfo.UpdateAddressInfoByManager(addModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "ManagerAllocationToTeamLeader", addModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, addModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateAddressListForTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Manager-Emp")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateEmploymentManagerViewModel empModel = new PQUpdateEmploymentManagerViewModel();
                        empModel.ModifiedBy = teamMemerRowId;
                        empModel.ModifiedDate = DateTime.Now;
                        empModel.CheckStatus = "Allocated-TL";
                        empModel.TLAllocatedTo = AllocateTL;
                        empModel.TLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            empModel.EmploymentRowID = item;
                            var empDetails = repoEmploymentInfo.GetPQEmploymentDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(empDetails.ClientRowID, empModel.TLAllocatedTo, "Employment", "Team Leader-Emp");

                            if (result)
                            {
                                repoEmploymentInfo.UpdateEmploymentInfoByManager(empModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(empDetails.PersonalRowID, "ManagerAllocationToTeamLeader", empModel.CheckStatus, empDetails.UniqueComponentID, "Update");
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
                    model = repoVerificationInfo.GetCandidateEmploymentListForTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Manager-Edu")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateEducationManagerViewModel eduModel = new PQUpdateEducationManagerViewModel();
                        eduModel.ModifiedBy = teamMemerRowId;
                        eduModel.ModifiedDate = DateTime.Now;
                        eduModel.CheckStatus = "Allocated-TL";
                        eduModel.TLAllocatedTo = AllocateTL;
                        eduModel.TLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            eduModel.EducationRowID = item;
                            var eduDetails = repoEducationInfo.GetPQEducationDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(eduDetails.ClientRowID, eduModel.TLAllocatedTo, "Education", "Team Leader-Edu");

                            if (result)
                            {
                                repoEducationInfo.UpdateEducationInfoByManager(eduModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(eduDetails.PersonalRowID, "ManagerAllocationToTeamLeader", eduModel.CheckStatus, eduDetails.UniqueComponentID, "Update");
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
                    model = repoVerificationInfo.GetCandidateEducationListForTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Manager-Cri")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateCriminalManagerViewModel criModel = new PQUpdateCriminalManagerViewModel();
                        criModel.ModifiedBy = teamMemerRowId;
                        criModel.ModifiedDate = DateTime.Now;
                        criModel.CheckStatus = "Allocated-TL";
                        criModel.TLAllocatedTo = AllocateTL;
                        criModel.TLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            criModel.CriminalRowID = item;
                            var criDetails = repoCriminalInfo.GetPQCriminalDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(criDetails.ClientRowID, criModel.TLAllocatedTo, "Criminal", "Team Leader-Cri");

                            if (result)
                            {
                                repoCriminalInfo.UpdateCriminalInfoByManager(criModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(criDetails.PersonalRowID, "ManagerAllocationToTeamLeader", criModel.CheckStatus, criDetails.UniqueComponentID, "Update");
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
                    model = repoVerificationInfo.GetCandidateCriminalListForTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Manager-Ref")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateReferenceManagerViewModel refModel = new PQUpdateReferenceManagerViewModel();
                        refModel.ModifiedBy = teamMemerRowId;
                        refModel.ModifiedDate = DateTime.Now;
                        refModel.CheckStatus = "Allocated-TL";
                        refModel.TLAllocatedTo = AllocateTL;
                        refModel.TLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            refModel.ReferenceRowID = item;
                            var refDetails = repoReferenceInfo.GetPQReferenceDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(refDetails.ClientRowID, refModel.TLAllocatedTo, "Reference", "Team Leader-Ref");

                            if (result)
                            {
                                repoReferenceInfo.UpdateReferenceInfoByManager(refModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(refDetails.PersonalRowID, "ManagerAllocationToTeamLeader", refModel.CheckStatus, refDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(refDetails.PersonalRowID, refDetails.SubCheckRowID, refModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateReferenceListForTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Manager-Ide")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateNationalIdentityManagerViewModel ideModel = new PQUpdateNationalIdentityManagerViewModel();
                        ideModel.ModifiedBy = teamMemerRowId;
                        ideModel.ModifiedDate = DateTime.Now;
                        ideModel.CheckStatus = "Allocated-TL";
                        ideModel.TLAllocatedBy = teamMemerRowId;
                        ideModel.TLAllocatedTo = AllocateTL;
                        ideModel.TLAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            ideModel.NationalIdentityRowID = item;
                            var ideDetails = repoNationalIdentInfo.GetPQNationalIdentityDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(ideDetails.ClientRowID, ideModel.TLAllocatedTo, "National Identity", "Team Leader-Ide");

                            if (result)
                            {
                                repoNationalIdentInfo.UpdateNationalIdentityInfoByManager(ideModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(ideDetails.PersonalRowID, "ManagerAllocationToTeamLeader", ideModel.CheckStatus, ideDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(ideDetails.PersonalRowID, ideDetails.SubCheckRowID, ideModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateIdentityListForTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Manager-SPL")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTL > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();

                        ManagerAllocateCheckToTeamLeaderViewModel ideModel = new ManagerAllocateCheckToTeamLeaderViewModel();
                        ideModel.ModifiedBy = teamMemerRowId;
                        ideModel.ModifiedDate = DateTime.Now;
                        ideModel.CheckStatus = "Allocated-TL";
                        ideModel.TLAllocatedBy = teamMemerRowId;
                        ideModel.TLAllocatedTo = AllocateTL;
                        ideModel.TLAllocatedDate = DateTime.Now;

                        foreach (var item in verIDs)
                        {
                            ideModel.SpecialCheckRowId = item;
                            var ideDetails = repoSplChkVer.GetCheckCommonInfoForAllocation(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(ideDetails.ClientRowID, ideModel.TLAllocatedTo, "Special Check", "Team Leader-SPL");

                            if (result)
                            {
                                repoSplChkVer.ManagerAllocateCheckToTeamLeader(ideModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(ideDetails.PersonalRowID, "ManagerAllocationToTeamLeader", ideModel.CheckStatus, ideDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(ideDetails.PersonalRowID, ideDetails.SubCheckRowID, ideModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateSpecialCheckListForTLAllocationByMgr(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }

                if (UnAllocatedCount > 0)
                {
                    ViewBag.ErrorMsg = UnAllocatedCount.ToString() + " Check(s) not allocated because teamleader not mapped with client!";
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
        public ActionResult DepartmentTeamLeaderAllocation(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte dtm = 0, byte dtmqc = 0, short AllocateTM = 0, short AllocateTMQC = 0, byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "", short State = 0, short City = 0, short Partner = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                //BindClientList();

                BindClientListBaseOnLogin(teamMemerRowId);
                CheckStatusOptionDropDown();
                CaseStatusOptionDropDown();

                if (Designation == "Team Leader-Add")
                {
                    BindCities();
                    BindStates();
                    BindPartneres();
                    model = repoVerificationInfo.GetCandidateAddressListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, State, City, Partner);
                }
                else if (Designation == "Team Leader-Emp")
                {
                    model = repoVerificationInfo.GetCandidateEmploymentListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Leader-Edu")
                {
                    model = repoVerificationInfo.GetCandidateEducationListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Leader-Cri")
                {
                    model = repoVerificationInfo.GetCandidateCriminalListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, State, City, Partner);
                }
                else if (Designation == "Team Leader-Ref")
                {
                    model = repoVerificationInfo.GetCandidateReferenceListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Leader-Ide")
                {
                    model = repoVerificationInfo.GetCandidateIdentityListByDepartmentTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Leader-SPL")
                {
                    model = repoVerificationInfo.GetCandidateSpecialCheckListByTeamLeader(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, dtm, dtmqc, AllocateTM, AllocateTMQC, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
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
        public ActionResult TeamLeaderAllocationToTeamMember(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocateTM = 0, short AllocateTMQC = 0, short ClientRowID = 0, string OCVerIDs = "", string CheckStatus = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                BindStates();
                //BindClientList();
                BindClientListBaseOnLogin(teamMemerRowId);
                GetTMMemberForAllocate();
                GetTMQCMemberForAllocate();

                byte UnAllocatedCount = 0;
                if (Designation == "Team Leader-Add")
                {

                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateAddressTeamLeaderViewModel addModel = new PQUpdateAddressTeamLeaderViewModel();
                        addModel.ModifiedBy = teamMemerRowId;
                        addModel.ModifiedDate = DateTime.Now;
                        addModel.CheckStatus = "Allocated-TM";
                        addModel.TMAllocatedTo = AllocateTM;
                        addModel.TMAllocatedDate = DateTime.Now;
                        addModel.TMQCAllocatedTo = AllocateTMQC;
                        addModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            addModel.AddressRowID = item;
                            var addDetails = repoAddressInfo.GetPQAddressDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(addDetails.ClientRowID, addModel.TMAllocatedTo, addModel.TMQCAllocatedTo, "Address", "Team Member-Add", "Team Member-Add-QC");

                            if (result)
                            {
                                repoAddressInfo.UpdateAddressInfoByTeamLeader(addModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", addModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, addModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateAddressListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Team Leader-Emp")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateEmploymentTeamLeaderViewModel empModel = new PQUpdateEmploymentTeamLeaderViewModel();
                        empModel.ModifiedBy = teamMemerRowId;
                        empModel.ModifiedDate = DateTime.Now;
                        empModel.CheckStatus = "Allocated-TM";
                        empModel.TMAllocatedTo = AllocateTM;
                        empModel.TMAllocatedDate = DateTime.Now;
                        empModel.TMQCAllocatedTo = AllocateTMQC;
                        empModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            empModel.EmploymentRowID = item;
                            var addDetails = repoEmploymentInfo.GetPQEmploymentDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(addDetails.ClientRowID, empModel.TMAllocatedTo, empModel.TMQCAllocatedTo, "Employment", "Team Member-Emp", "Team Member-Emp-QC");

                            if (result)
                            {
                                repoEmploymentInfo.UpdateEmploymentInfoByTeamLeader(empModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", empModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, empModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateEmploymentListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Team Leader-Edu")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateEducationTeamLeaderViewModel eduModel = new PQUpdateEducationTeamLeaderViewModel();
                        eduModel.ModifiedBy = teamMemerRowId;
                        eduModel.ModifiedDate = DateTime.Now;
                        eduModel.CheckStatus = "Allocated-TM";
                        eduModel.TMAllocatedTo = AllocateTM;
                        eduModel.TMAllocatedDate = DateTime.Now;
                        eduModel.TMQCAllocatedTo = AllocateTMQC;
                        eduModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            eduModel.EducationRowID = item;
                            var addDetails = repoEducationInfo.GetPQEducationDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(addDetails.ClientRowID, eduModel.TMAllocatedTo, eduModel.TMQCAllocatedTo, "Education", "Team Member-Edu", "Team Member-Edu-QC");

                            if (result)
                            {
                                repoEducationInfo.UpdateEducationInfoByTeamLeader(eduModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", eduModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, eduModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateEducationListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Team Leader-Cri")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateCriminalTeamLeaderViewModel criModel = new PQUpdateCriminalTeamLeaderViewModel();
                        criModel.ModifiedBy = teamMemerRowId;
                        criModel.ModifiedDate = DateTime.Now;
                        criModel.CheckStatus = "Allocated-TM";
                        criModel.TMAllocatedTo = AllocateTM;
                        criModel.TMAllocatedDate = DateTime.Now;
                        criModel.TMQCAllocatedTo = AllocateTMQC;
                        criModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            criModel.CriminalRowID = item;
                            var addDetails = repoCriminalInfo.GetPQCriminalDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(addDetails.ClientRowID, criModel.TMAllocatedTo, criModel.TMQCAllocatedTo, "Criminal", "Team Member-Cri", "Team Member-Cri-QC");

                            if (result)
                            {
                                repoCriminalInfo.UpdateCriminalInfoByTeamLeader(criModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", criModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, criModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateCriminalListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Team Leader-Ref")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateReferenceTeamLeaderViewModel refModel = new PQUpdateReferenceTeamLeaderViewModel();
                        refModel.ModifiedBy = teamMemerRowId;
                        refModel.ModifiedDate = DateTime.Now;
                        refModel.CheckStatus = "Allocated-TM";
                        refModel.TMAllocatedTo = AllocateTM;
                        refModel.TMAllocatedDate = DateTime.Now;
                        refModel.TMQCAllocatedTo = AllocateTMQC;
                        refModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            refModel.ReferenceRowID = item;
                            var addDetails = repoReferenceInfo.GetPQReferenceDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(addDetails.ClientRowID, refModel.TMAllocatedTo, refModel.TMQCAllocatedTo, "Reference", "Team Member-Ref", "Team Member-Ref-QC");

                            if (result)
                            {
                                repoReferenceInfo.UpdateReferenceInfoByTeamLeader(refModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", refModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, refModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateReferenceListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Team Leader-Ide")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateNationalIdentityTeamLeaderViewModel ideModel = new PQUpdateNationalIdentityTeamLeaderViewModel();
                        ideModel.ModifiedBy = teamMemerRowId;
                        ideModel.ModifiedDate = DateTime.Now;
                        ideModel.CheckStatus = "Allocated-TM";
                        ideModel.TMAllocatedTo = AllocateTM;
                        ideModel.TMAllocatedDate = DateTime.Now;
                        ideModel.TMQCAllocatedTo = AllocateTMQC;
                        ideModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            ideModel.NationalIdentityRowID = item;
                            var addDetails = repoNationalIdentInfo.GetPQNationalIdentityDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(addDetails.ClientRowID, ideModel.TMAllocatedTo, ideModel.TMQCAllocatedTo, "National Identity", "Team Member-Ide", "Team Member-Ide-QC");

                            if (result)
                            {
                                repoNationalIdentInfo.UpdateNationalIdentityInfoByTeamLeader(ideModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", ideModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, ideModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateIdentityListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
                }
                else if (Designation == "Team Leader-SPL")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocateTM > 0 && AllocateTMQC > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        TeamLeaderAllocateCheckToTeamMemberViewModel ideModel = new TeamLeaderAllocateCheckToTeamMemberViewModel();
                        ideModel.ModifiedBy = teamMemerRowId;
                        ideModel.ModifiedDate = DateTime.Now;
                        ideModel.CheckStatus = "Allocated-TM";
                        ideModel.TMAllocatedTo = AllocateTM;
                        ideModel.TMAllocatedDate = DateTime.Now;
                        ideModel.TMQCAllocatedTo = AllocateTMQC;
                        ideModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            ideModel.SpecialCheckRowId = item;
                            var addDetails = repoSplChkVer.GetCheckCommonInfoForAllocation(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExist(addDetails.ClientRowID, ideModel.TMAllocatedTo, ideModel.TMQCAllocatedTo, "Special Check", "Team Member-SPL", "Team Member-SPL-QC");

                            if (result)
                            {
                                repoSplChkVer.TeamLeaderAllocateCheckToTeamMember(ideModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", ideModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, ideModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateSpecialCheckListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus);
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
        public ActionResult TeamLeaderReAllocationToTeamMember(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocateTM = 0, short AllocateTMQC = 0, short ClientRowID = 0, string OCVerIDs = "", string CheckStatus = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                BindStates();
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                //BindClientList();
                BindClientListBaseOnLogin(teamMemerRowId);
                GetTMMemberForAllocate();
                GetTMQCMemberForAllocate();
                string ReAllocation = "ReAllocation";
                byte UnAllocatedCount = 0;
                if (Designation == "Team Leader-Add")
                {

                    if (!string.IsNullOrEmpty(VerificationIds) && (AllocateTM > 0 || AllocateTMQC > 0))
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateAddressTeamLeaderViewModel addModel = new PQUpdateAddressTeamLeaderViewModel();
                        addModel.ModifiedBy = teamMemerRowId;
                        addModel.ModifiedDate = DateTime.Now;
                        addModel.CheckStatus = "Allocated-TM";
                        addModel.TMAllocatedTo = AllocateTM;
                        addModel.TMAllocatedDate = DateTime.Now;
                        addModel.TMQCAllocatedTo = AllocateTMQC;
                        addModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            addModel.AddressRowID = item;
                            var addDetails = repoAddressInfo.GetPQAddressDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExistForReAllocation(addDetails.ClientRowID, addModel.TMAllocatedTo, addModel.TMQCAllocatedTo, "Address", "Team Member-Add", "Team Member-Add-QC");

                            if (result)
                            {
                                repoAddressInfo.UpdateAddressInfoByTeamLeaderReAllocated(addModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", addModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, addModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateAddressListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, ReAllocation, AllocateTM, AllocateTMQC);
                }
                else if (Designation == "Team Leader-Emp")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && (AllocateTM > 0 || AllocateTMQC > 0))
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateEmploymentTeamLeaderViewModel empModel = new PQUpdateEmploymentTeamLeaderViewModel();
                        empModel.ModifiedBy = teamMemerRowId;
                        empModel.ModifiedDate = DateTime.Now;
                        empModel.CheckStatus = "Allocated-TM";
                        empModel.TMAllocatedTo = AllocateTM;
                        empModel.TMAllocatedDate = DateTime.Now;
                        empModel.TMQCAllocatedTo = AllocateTMQC;
                        empModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            empModel.EmploymentRowID = item;
                            var addDetails = repoEmploymentInfo.GetPQEmploymentDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExistForReAllocation(addDetails.ClientRowID, empModel.TMAllocatedTo, empModel.TMQCAllocatedTo, "Employment", "Team Member-Emp", "Team Member-Emp-QC");

                            if (result)
                            {
                                repoEmploymentInfo.UpdateEmploymentInfoByTeamLeaderReAllocated(empModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", empModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, empModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateEmploymentListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, ReAllocation, AllocateTM, AllocateTMQC);
                }
                else if (Designation == "Team Leader-Edu")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && (AllocateTM > 0 || AllocateTMQC > 0))
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateEducationTeamLeaderViewModel eduModel = new PQUpdateEducationTeamLeaderViewModel();
                        eduModel.ModifiedBy = teamMemerRowId;
                        eduModel.ModifiedDate = DateTime.Now;
                        eduModel.CheckStatus = "Allocated-TM";
                        eduModel.TMAllocatedTo = AllocateTM;
                        eduModel.TMAllocatedDate = DateTime.Now;
                        eduModel.TMQCAllocatedTo = AllocateTMQC;
                        eduModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            eduModel.EducationRowID = item;
                            var addDetails = repoEducationInfo.GetPQEducationDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExistForReAllocation(addDetails.ClientRowID, eduModel.TMAllocatedTo, eduModel.TMQCAllocatedTo, "Education", "Team Member-Edu", "Team Member-Edu-QC");

                            if (result)
                            {
                                repoEducationInfo.UpdateEducationInfoByTeamLeaderReAllocated(eduModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", eduModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, eduModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateEducationListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, ReAllocation, AllocateTM, AllocateTMQC);
                }
                else if (Designation == "Team Leader-Cri")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && (AllocateTM > 0 || AllocateTMQC > 0))
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateCriminalTeamLeaderViewModel criModel = new PQUpdateCriminalTeamLeaderViewModel();
                        criModel.ModifiedBy = teamMemerRowId;
                        criModel.ModifiedDate = DateTime.Now;
                        criModel.CheckStatus = "Allocated-TM";
                        criModel.TMAllocatedTo = AllocateTM;
                        criModel.TMAllocatedDate = DateTime.Now;
                        criModel.TMQCAllocatedTo = AllocateTMQC;
                        criModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            criModel.CriminalRowID = item;
                            var addDetails = repoCriminalInfo.GetPQCriminalDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExistForReAllocation(addDetails.ClientRowID, criModel.TMAllocatedTo, criModel.TMQCAllocatedTo, "Criminal", "Team Member-Cri", "Team Member-Cri-QC");

                            if (result)
                            {
                                repoCriminalInfo.UpdateCriminalInfoByTeamLeaderReAllocated(criModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", criModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, criModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateCriminalListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, ReAllocation, AllocateTM, AllocateTMQC);
                }
                else if (Designation == "Team Leader-Ref")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && (AllocateTM > 0 || AllocateTMQC > 0))
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateReferenceTeamLeaderViewModel refModel = new PQUpdateReferenceTeamLeaderViewModel();
                        refModel.ModifiedBy = teamMemerRowId;
                        refModel.ModifiedDate = DateTime.Now;
                        refModel.CheckStatus = "Allocated-TM";
                        refModel.TMAllocatedTo = AllocateTM;
                        refModel.TMAllocatedDate = DateTime.Now;
                        refModel.TMQCAllocatedTo = AllocateTMQC;
                        refModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            refModel.ReferenceRowID = item;
                            var addDetails = repoReferenceInfo.GetPQReferenceDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExistForReAllocation(addDetails.ClientRowID, refModel.TMAllocatedTo, refModel.TMQCAllocatedTo, "Reference", "Team Member-Ref", "Team Member-Ref-QC");

                            if (result)
                            {
                                repoReferenceInfo.UpdateReferenceInfoByTeamLeaderReAllocated(refModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", refModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, refModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateReferenceListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, ReAllocation, AllocateTM, AllocateTMQC);
                }
                else if (Designation == "Team Leader-Ide")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && (AllocateTM > 0 || AllocateTMQC > 0))
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateNationalIdentityTeamLeaderViewModel ideModel = new PQUpdateNationalIdentityTeamLeaderViewModel();
                        ideModel.ModifiedBy = teamMemerRowId;
                        ideModel.ModifiedDate = DateTime.Now;
                        ideModel.CheckStatus = "Allocated-TM";
                        ideModel.TMAllocatedTo = AllocateTM;
                        ideModel.TMAllocatedDate = DateTime.Now;
                        ideModel.TMQCAllocatedTo = AllocateTMQC;
                        ideModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            ideModel.NationalIdentityRowID = item;
                            var addDetails = repoNationalIdentInfo.GetPQNationalIdentityDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExistForReAllocation(addDetails.ClientRowID, ideModel.TMAllocatedTo, ideModel.TMQCAllocatedTo, "National Identity", "Team Member-Ide", "Team Member-Ide-QC");

                            if (result)
                            {
                                repoNationalIdentInfo.UpdateNationalIdentityInfoByTeamLeaderReAllocated(ideModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", ideModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, ideModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateIdentityListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, ReAllocation, AllocateTM, AllocateTMQC);
                }
                else if (Designation == "Team Leader-SPL")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && (AllocateTM > 0 || AllocateTMQC > 0))
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateSpecialCheckTeamLeaderViewModel ideModel = new PQUpdateSpecialCheckTeamLeaderViewModel();
                        ideModel.ModifiedBy = teamMemerRowId;
                        ideModel.ModifiedDate = DateTime.Now;
                        ideModel.CheckStatus = "Allocated-TM";
                        ideModel.TMAllocatedTo = AllocateTM;
                        ideModel.TMAllocatedDate = DateTime.Now;
                        ideModel.TMQCAllocatedTo = AllocateTMQC;
                        ideModel.TMQCAllocatedDate = DateTime.Now;
                        foreach (var item in verIDs)
                        {
                            ideModel.SpecialCheckRowID = item;
                            var addDetails = repoSplChkVer.GetPQSpecialCheckDetailsById(item);
                            bool result = repoPQClientTMember.IsClientDepartTeamMembersExistForReAllocation(addDetails.ClientRowID, ideModel.TMAllocatedTo, ideModel.TMQCAllocatedTo, "Special Check", "Team Member-SPL", "Team Member-SPL-QC");

                            if (result)
                            {
                                repoSplChkVer.UpdateSpecialCheckInfoByTeamLeaderReAllocated(ideModel);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "TeamLeaderAllocationToTeamMember", ideModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, ideModel.CheckStatus, "");
                                #endregion
                            }
                            else
                            {
                                UnAllocatedCount++;
                            }
                        }
                    }
                    model = repoVerificationInfo.GetCandidateSpecialCheckListForTMQCAllocationByTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, ReAllocation, AllocateTM, AllocateTMQC);
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
        public ActionResult ManageTeamMemberChecks(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "", short State = 0, short City = 0, short Partner = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                //BindClientList();
                BindClientListBaseOnLogin(teamMemerRowId);
                CheckStatusOptionDropDown();
                CaseStatusOptionDropDown();

                if (Designation == "Team Member-Add")
                {
                    BindCities();
                    BindStates();
                    BindPartneres();
                    model = repoVerificationInfo.GetCandidateAddressListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto, State, City, Partner);
                }
                else if (Designation == "Team Member-Emp")
                {
                    model = repoVerificationInfo.GetCandidateEmploymentListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Member-Edu")
                {
                    model = repoVerificationInfo.GetCandidateEducationListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Member-Cri")
                {
                    model = repoVerificationInfo.GetCandidateCriminalListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Member-Ref")
                {
                    model = repoVerificationInfo.GetCandidateReferenceListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Member-Ide")
                {
                    model = repoVerificationInfo.GetCandidateIdentityListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Member-SPL")
                {
                    model = repoVerificationInfo.GetCandidateSpecialCheckListForTMM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
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
        public ActionResult DepartmentTeamMemberQCChecks(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CheckStatus = "", byte tatdays = 0, string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "", string DCheckStatus = "", string CaseStatus = "", string EmployerName = "", string Allocatedto = "", short State = 0, short City = 0, short Partner = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                //BindClientList();
                BindClientListBaseOnLogin(teamMemerRowId);
                CheckStatusOptionDropDown();
                CaseStatusOptionDropDown();

                if (Designation == "Team Member-Add-QC")
                {
                    BindCities();
                    BindStates();
                    BindPartneres();
                    model = repoVerificationInfo.GetCandidateAddressListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, EmployerName, Allocatedto, CaseStatus, State, City, Partner);
                }
                else if (Designation == "Team Member-Emp-QC")
                {
                    model = repoVerificationInfo.GetCandidateEmploymentListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Member-Edu-QC")
                {
                    model = repoVerificationInfo.GetCandidateEducationListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus, EmployerName, Allocatedto);
                }
                else if (Designation == "Team Member-Cri-QC")
                {
                    model = repoVerificationInfo.GetCandidateCriminalListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Member-Ref-QC")
                {
                    model = repoVerificationInfo.GetCandidateReferenceListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Member-Ide-QC")
                {
                    model = repoVerificationInfo.GetCandidateIdentityListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
                }
                else if (Designation == "Team Member-SPL-QC")
                {
                    model = repoVerificationInfo.GetCandidateSpecialCheckListForTMMQC(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, ClientRowID, CheckStatus, tatdays, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, DCheckStatus, CaseStatus);
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

        #region ******** Manage By Department Team Member ********

        #region ******** Partner Allocation By Address TeamMember ********

        [SessionExpireFilterAttribute]
        public ActionResult AddressTeamMemberAllocationToPartnerMgr(int page = 1, string sort = "", string sortDir = "desc", string Search = "", string VerificationIds = "", short AllocatePTR = 0, short StateRowId = 0, string CheckStatus = "")
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;


                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();

                BindStateVendor(teamMemerRowId);
                GetVendorDDL(StateRowId);
                if (Designation == "Team Member-Add")
                {
                    if (!string.IsNullOrEmpty(VerificationIds) && AllocatePTR > 0)
                    {
                        int[] verIDs = VerificationIds.Split(',').Select(str => int.Parse(str)).ToArray();
                        PQUpdateAddressStatusTeamMemberViewModel addModel = new PQUpdateAddressStatusTeamMemberViewModel();
                        addModel.ModifiedBy = teamMemerRowId;
                        addModel.ModifiedDate = DateTime.Now;
                        addModel.CheckStatus = "Allocated-PTR";
                        addModel.PTRMgrAllocatedTo = AllocatePTR;

                        foreach (var item in verIDs)
                        {
                            addModel.AddressRowID = item;
                            var addDetails = repoAddressInfo.GetPQAddressDetailsById(item);

                            repoAddressInfo.UpdateAddressStatusByTeamMember(addModel);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(addDetails.PersonalRowID, "AddressTeamMemberAllocationToPartnerMgr", addModel.CheckStatus, addDetails.UniqueComponentID, "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(addDetails.PersonalRowID, addDetails.SubCheckRowID, addModel.CheckStatus, "Team Member Allocated To Partner");
                            #endregion
                        }
                    }
                    model = repoVerificationInfo.GetCandidateAddressListForPTRMgrAllocationByTM(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, teamMemerRowId, StateRowId, CheckStatus);
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

        #region ******** Address Verification By Team Member ********

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult AddAddressInfoByTeamMember(int id = 0)
        {
            PQAddressVerViewModel model = new PQAddressVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoAddressVer.GetAddressInfoForDataEntry(id);
                    if (model != null)
                    {
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        //BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        AddressVerList(model.AddressRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoAddressVer.GetPersonalDetailsForTM(model.AddressRowID);

                        ViewBag.VerifiedDetails = repoPartnerVerification.GetAddressVerPartnerForDepartmentTM(model.AddressRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Address id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            TotalNumber();
            BindCountry();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult AddAddressInfoByTeamMember(PQAddressVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Status = 1;
                    if (model != null)
                    {
                        if (model.FatherTitle == "Late" && string.IsNullOrEmpty(model.FatherName) && string.IsNullOrEmpty(model.AV_Resp_Name) && model.FatherName.Trim().ToLower().Replace(" ", "").Contains(model.AV_Resp_Name.Trim().ToLower().Replace(" ", "")))
                        {
                            ViewBag.ErrorMsg = "invalid Respondent Name !";
                        }
                        else
                        {
                            if (model.AddressVerRowID > 0)
                            {
                                #region Update Address Information
                                repoAddressVer.UpdateAddressByTeamMember(model);
                                int Res = repoAddressVer.SaveChanges();
                                if (Res > 0)
                                {
                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressVerificationInfo", model.CheckStatus, "Address Verification", "Update");
                                    #endregion
                                    #region Case/Check Action History Save
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated");
                                    #endregion

                                    ModelState.Clear();
                                    return RedirectToAction("AddAddressInfoByTeamMember", new { id = model.AddressRowID });
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is no Change!";
                                }
                                #endregion
                            }
                            else
                            {
                                #region Add Address Information
                                int Res = repoAddressVer.AddAddressByTeamMember(model);

                                if (Res > 0)
                                {
                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressVerificationInfo", model.CheckStatus, "Address Verification", "Insert");
                                    #endregion
                                    #region Case/Check Action History Save
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification Information Submitted ");
                                    #endregion

                                    ModelState.Clear();
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    return RedirectToAction("AddAddressInfoByTeamMember", new { id = model.AddressRowID });
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is Change!";
                                }
                                #endregion
                            }
                        }
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        // BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        AddressVerList(model.AddressRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoAddressVer.GetPersonalDetailsForTM(model.AddressRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "invlid Address id and model!";
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
            TotalNumber();
            BindCountry();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult VerificationCloserDetails(int id = 0)
        {
            VerificationCloserViewModel model = new VerificationCloserViewModel();

            try
            {
                if (id > 0)
                {
                    model = repoAddressVer.GetVerificationCloserDetails(id);

                    if (model != null)
                    {
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No Detail found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Address id!";
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
        [HttpPost]
        public ActionResult VerificationCloserDetails(VerificationCloserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.AddressVerRowID > 0)
                    {
                        short TeamMemberRowID = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.InfSuffRaiseBy = TeamMemberRowID;
                        model.InfSuffRaisedDate = DateTime.Now;
                        model.StoppedCheckStatus = 1;
                        model.StoppedCheckBy = TeamMemberRowID;
                        model.StoppedCheckDate = DateTime.Now;

                        repoAddressVer.AddVerificationCloserDetails(model);
                        #region Check Action History Save                           
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.ActionHistory);
                        #endregion
                        ModelState.Clear();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        return RedirectToAction("AddAddressInfoByTeamMember", new { id = model.AddressRowID });
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No item found!";
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
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UplodVerificationDocs(short scid = 0, int pe = 0, string cstatus = "")
        {
            VerifiedUploadDocViewModel model = new VerifiedUploadDocViewModel();
            try
            {
                if (scid > 0 && pe > 0)
                {
                    //model.CheckfiledRowID = id;
                    //model.ClientRowID = cid;
                    //model.CheckFamilyRowID = cfid;
                    model.SubCheckRowID = scid;
                    model.PersonalRowID = pe;
                    model.CheckStatus = cstatus;
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Address id!";
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
        [HttpPost]
        public ActionResult UplodVerificationDocs(VerifiedUploadDocViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FldPathDoc = ConfigurationManager.AppSettings["provideddocuments"].ToString();
                    string proImg = string.Empty;
                    if (model.UploadDoc != null && model.UploadDoc.ContentLength > 0)
                    {
                        if (model.DocumentType == null)
                        {
                            model.DocumentType = "Varification Document";
                        }
                        model.DocumentUploadFrom = "Verified";
                        model.StatusDocxConvert = 0;
                        model.StatusPDF2DOCXConvert = 0;
                        model.UploadDate = DateTime.Now;
                        model.Status = 1;
                        string ext = Path.GetExtension(model.UploadDoc.FileName).ToLower();
                        proImg = ("Artifact" + "_" + model.PersonalRowID + "_" + model.SubCheckRowID + "_" + model.UploadDate.Value.ToString("ddMMyyyyHHmmss")).Replace("'", "_").Replace(" ", "_").Replace("-", "_") + ext;
                        model.UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                        model.FileName = proImg;
                        model.FilePath = FldPathDoc;
                        repoPQVerifiedUploadDoc.VerifiedUploadDoc(model);
                        int Res = repoPQVerifiedUploadDoc.SaveChanges();
                        if (Res > 0)
                        {
                            #region Check Action History Save                           
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Upload Doc ");
                            #endregion
                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "please select upload doc!";
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
            return View(model);
        }

        //Get Personal Details and Get Special Instrucation And In Address Verification 
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

        #endregion

        #region ******** Employment Verifiation By TeamMember ********

        [SessionExpireFilterAttribute]
        public ActionResult AddEmploymentInfoByTeamMember(int id = 0)
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
                        //BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
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

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult AddEmploymentInfoByTeamMember(PQEmploymentVerViewModel model)
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

                            repoEmploymentVer.UpdateEmploymentByTeamMember(model);
                            int Res = repoEmploymentVer.SaveChanges();
                            if (Res > 0)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddEmploymentInfoByTeamMember", model.CheckStatus, "Employment Verification", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("AddEmploymentInfoByTeamMember", new { id = model.EmploymentRowID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                            #endregion
                        }
                        else
                        {
                            #region Add Employment Information

                            repoEmploymentVer.AddEmploymentByTeamMember(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddEmploymentInfoByTeamMember", "WIP-Pending", "Employment Verification", "Insert");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "WIP-Pending", "Verification Information Submitted");
                            #endregion

                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            return RedirectToAction("AddEmploymentInfoByTeamMember", new { id = model.EmploymentRowID });

                            #endregion
                        }

                        //BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        EmployementVerList(model.EmploymentRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEmploymentVer.GetPersonalDetailsForTM(model.EmploymentRowID);
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
            RatingNumber();
            BindCountry();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult EmploymentVerCloserDetails(int id = 0)
        {
            EmploymentVerCloserViewModel model = new EmploymentVerCloserViewModel();

            try
            {
                if (id > 0)
                {
                    model = repoEmploymentVer.GetEmploymentVerCloserDetails(id);
                    if (model != null)
                    {
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
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

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult EmploymentVerCloserDetails(EmploymentVerCloserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmploymentVerRowID > 0)
                    {
                        //short TeamMemberRowID = Convert.ToInt16(Session["TeamMemberRowID"]);
                        //model.InfSuffRaiseBy = TeamMemberRowID;
                        //model.InfSuffRaisedDate = DateTime.Now;
                        //model.StoppedCheckStatus = 1;
                        //model.StoppedCheckBy = TeamMemberRowID;
                        //model.StoppedCheckDate = DateTime.Now;

                        repoEmploymentVer.AddEmploymentVerCloserDetails(model);

                        #region Check Action History Save                           
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.ActionHistory);
                        #endregion

                        ModelState.Clear();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        return RedirectToAction("AddEmploymentInfoByTeamMember", new { id = model.EmploymentRowID });
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No item found!";
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
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UplodEmploymentVerDocs(short scid = 0, int pe = 0, string cstatus = "")
        {
            VerifiedUploadDocViewModel model = new VerifiedUploadDocViewModel();
            try
            {
                if (scid > 0 && pe > 0)
                {
                    model.SubCheckRowID = scid;
                    model.PersonalRowID = pe;
                    model.CheckStatus = cstatus;
                }
                else
                {
                    ViewBag.ErrorMsg = "invlid Employment id!";
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
        [HttpPost]
        public ActionResult UplodEmploymentVerDocs(VerifiedUploadDocViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FldPathDoc = ConfigurationManager.AppSettings["provideddocuments"].ToString();
                    string proImg = string.Empty;
                    if (model.UploadDoc != null && model.UploadDoc.ContentLength > 0)
                    {
                        if (model.DocumentType == null)
                        {
                            model.DocumentType = "Varification Document";
                        }
                        model.DocumentUploadFrom = "Verified";
                        model.StatusDocxConvert = 0;
                        model.StatusPDF2DOCXConvert = 0;
                        model.UploadDate = DateTime.Now;
                        model.Status = 1;
                        string ext = Path.GetExtension(model.UploadDoc.FileName).ToLower();
                        proImg = ("Artifact" + "_" + model.PersonalRowID + "_" + model.SubCheckRowID + "_" + model.UploadDate.Value.ToString("ddMMyyyyHHmmss")).Replace("'", "_").Replace(" ", "_").Replace("-", "_") + ext;
                        model.UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                        model.FileName = proImg;
                        repoPQVerifiedUploadDoc.VerifiedUploadDoc(model);
                        int Res = repoPQVerifiedUploadDoc.SaveChanges();
                        if (Res > 0)
                        {
                            #region Check Action History Save                           
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Upload Doc ");
                            #endregion
                            ModelState.Clear();
                            ViewBag.SuccessMsg = "Record Added Successfully!";
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is no Change!";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "please select upload doc!";
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

        #region ******** Education Verifiation By TeamMember ********

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult AddEducationInfoByTeamMember(int id = 0)
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
                        //  BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(id);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No Details found!";
                    }

                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Education Id!";
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

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult AddEducationInfoByTeamMember(PQEducationVerViewModel model)
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
                            #region Update Education                             
                            repoEducationVer.UpdateEducationByTeamMember(model);
                            int Res = repoEducationVer.SaveChanges();
                            if (Res > 0)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentVerificationInfo", model.CheckStatus, "Education Verification", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("AddEducationInfoByTeamMember", new { id = model.EducationRowID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                            #endregion
                        }
                        else
                        {
                            #region Add Education Information
                            repoEducationVer.AddEducationByTeamMember(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "InsertEducationVerificationInfo", model.CheckStatus, "Education Verification", "Insert");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification Information Submitted ");
                            #endregion

                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            return RedirectToAction("AddEducationInfoByTeamMember", new { id = model.EducationRowID });

                            #endregion
                        }
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        //BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(model.EducationRowID);
                        model = repoEducationVer.GetEducationInfoForDataEntry(model.EducationRowID);
                        // return View(model);
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
            BindUniversityStatusList();
            BindAffliatiatedfrom();
            GetDegreeList();
            GetCollegeDDL();
            RatingNumber();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult EducationVerCloserDetails(int id = 0)
        {
            EducationVerCloserViewModel model = new EducationVerCloserViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoEducationVer.GetEducationVerCloserDetails(id);

                    if (model != null)
                    {
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No Details found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Education Id!";
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
        [HttpPost]
        public ActionResult EducationVerCloserDetails(EducationVerCloserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.EducationVerRowID > 0)
                    {
                        short TeamMemberRowID = Convert.ToInt16(Session["TeamMemberRowID"]);

                        repoEducationVer.AddEducationVerCloserDetails(model);

                        #region Check Action History Save                           
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.ActionHistory);
                        #endregion

                        ModelState.Clear();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        return RedirectToAction("AddEducationInfoByTeamMember", new { id = model.EducationRowID, ClientRowId = model.ClientRowID, ChFamilRowId = model.CheckFamilyRowID, subCheckId = model.SubCheckRowID, PersonalRowID = model.PersonalRowID, });
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No item found!";
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
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UplodEducationVerDocs(short scid = 0, int pe = 0, string cstatus = "")
        {
            VerifiedUploadDocViewModel model = new VerifiedUploadDocViewModel();
            try
            {
                if (scid > 0 && pe > 0)
                {
                    model.SubCheckRowID = scid;
                    model.PersonalRowID = pe;
                    model.CheckStatus = cstatus;
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

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UplodEducationVerDocs(VerifiedUploadDocViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FldPathDoc = ConfigurationManager.AppSettings["provideddocuments"].ToString();
                    string proImg = string.Empty;
                    if (model.UploadDoc != null && model.UploadDoc.ContentLength > 0)
                    {
                        if (model.DocumentType == null)
                        {
                            model.DocumentType = "Varification Document";
                        }
                        model.DocumentUploadFrom = "Verified";
                        model.StatusDocxConvert = 0;
                        model.StatusPDF2DOCXConvert = 0;
                        model.UploadDate = DateTime.Now;
                        model.Status = 1;
                        string ext = Path.GetExtension(model.UploadDoc.FileName).ToLower();
                        proImg = ("Artifact" + "_" + model.PersonalRowID + "_" + model.SubCheckRowID + "_" + model.UploadDate.Value.ToString("ddMMyyyyHHmmss")).Replace("'", "_").Replace(" ", "_").Replace("-", "_") + ext;
                        model.UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                        model.FileName = proImg;
                        repoPQVerifiedUploadDoc.VerifiedUploadDoc(model);
                        int Res = repoPQVerifiedUploadDoc.SaveChanges();
                        if (Res > 0)
                        {
                            #region Check Action History Save                           
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Education Verification information Upload Doc ");
                            #endregion
                            ModelState.Clear();
                            ViewBag.SuccessMsg = "Record Added Successfully!";
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "please select upload doc!";
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

        #region ******** Criminal Verifiation By TeamMember ********

        [SessionExpireFilterAttribute]
        public ActionResult AddCriminalInfoByTeamMember(int id = 0)
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
                        //BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        CriminalVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        //Bind Personal Details 
                        ViewBag.PersonalBind = repoCriminalVer.GetPersonalDetailsForTM(id);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No details found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Criminal Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            CriminalOptionDropDown();
            BindCountry();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult AddCriminalInfoByTeamMember(PQCriminalVerViewModel model)
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
                            repoCriminalVer.UpdateCriminalByTeamMember(model);
                            int Res = repoCriminalVer.SaveChanges();
                            if (Res > 0)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalVerificationInfo", model.CheckStatus, "Criminal Verification", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("AddCriminalInfoByTeamMember", new { id = model.CriminalRowID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no Change!";
                            }
                            #endregion
                        }
                        else
                        {
                            #region Add Criminal Information
                            repoCriminalVer.AddCriminalByTeamMember(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalVerificationInfo", model.CheckStatus, "Criminal Verification", "Insert");
                            #endregion
                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification Information Submitted ");
                            #endregion

                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            return RedirectToAction("AddCriminalInfoByTeamMember", new { id = model.CriminalRowID });

                            #endregion
                        }
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        // BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        CriminalVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoCriminalVer.GetPersonalDetailsForTM(model.ClientRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invlid Criminal Id and model!";
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
            TotalNumber();
            BindCountry();
            CriminalOptionDropDown();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult CriminalVerCloserDetails(int id = 0)
        {
            CriminalVerCloserViewModel model = new CriminalVerCloserViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoCriminalVer.GetCriminalVerCloserDetails(id);
                    if (model != null)
                    {
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No details found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Criminal Id!";
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
        [HttpPost]
        public ActionResult CriminalVerCloserDetails(CriminalVerCloserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CriminalVerRowID > 0)
                    {
                        short TeamMemberRowID = Convert.ToInt16(Session["TeamMemberRowID"]);
                        repoCriminalVer.AddCriminalVerCloserDetails(model);

                        #region Check Action History Save                           
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.ActionHistory);
                        #endregion

                        ModelState.Clear();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        return RedirectToAction("AddCriminalInfoByTeamMember", new { id = model.CriminalRowID });
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No item found!";
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
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UplodCriminalVerDocs(short scid = 0, int pe = 0, string cstatus = "")
        {
            VerifiedUploadDocViewModel model = new VerifiedUploadDocViewModel();
            try
            {
                if (scid > 0 && pe > 0)
                {
                    model.SubCheckRowID = scid;
                    model.PersonalRowID = pe;
                    model.CheckStatus = cstatus;
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
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UplodCriminalVerDocs(VerifiedUploadDocViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FldPathDoc = ConfigurationManager.AppSettings["provideddocuments"].ToString();
                    string proImg = string.Empty;
                    if (model.UploadDoc != null && model.UploadDoc.ContentLength > 0)
                    {
                        if (model.DocumentType == null)
                        {
                            model.DocumentType = "Varification Document";
                        }
                        model.DocumentUploadFrom = "Verified";
                        model.StatusDocxConvert = 0;
                        model.StatusPDF2DOCXConvert = 0;
                        model.UploadDate = DateTime.Now;
                        model.Status = 1;
                        string ext = Path.GetExtension(model.UploadDoc.FileName).ToLower();
                        proImg = ("Artifact" + "_" + model.PersonalRowID + "_" + model.SubCheckRowID + "_" + model.UploadDate.Value.ToString("ddMMyyyyHHmmss")).Replace("'", "_").Replace(" ", "_").Replace("-", "_") + ext;
                        model.UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                        model.FileName = proImg;
                        repoPQVerifiedUploadDoc.VerifiedUploadDoc(model);
                        int Res = repoPQVerifiedUploadDoc.SaveChanges();
                        if (Res > 0)
                        {
                            #region Check Action History Save                           
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Crimianl Verification information Upload Doc ");
                            #endregion

                            ModelState.Clear();
                            ViewBag.SuccessMsg = "Record Added Successfully!";
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is No Changes!";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "please select upload doc!";
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
            return View(model);
        }

        [NonAction]
        void CriminalVerList(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            ViewBag.modelBind = repoCriminalVer.GetCriminalForTM(id);
            ViewBag.ListCriminalVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
        }

        #endregion

        #region ******** Reference Verification By Team Member ********

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult AddReferenceInfoByTeamMember(int id = 0)
        {
            PQReferenceVerViewModel model = new PQReferenceVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoReferenceVer.GetReferenceInfoForDataEntry(id);
                    if (model != null)
                    {
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        //BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        ReferenceVerList(model.ReferenceCheckRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoReferenceVer.GetPersonalDetailsForTM(model.ReferenceCheckRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No details found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Reference id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            RatingNumber();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult AddReferenceInfoByTeamMember(PQReferenceVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        model.Status = 1;
                        if (model.ReferenceCheckVerRowID > 0)
                        {
                            #region Update Reference Information
                            repoReferenceVer.UpdateReferenceByTeamMember(model);
                            int Res = repoReferenceVer.SaveChanges();
                            if (Res > 0)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceVerificationInfo", model.CheckStatus, "Reference Verification", "Update");
                                #endregion
                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("AddReferenceInfoByTeamMember", new { id = model.ReferenceCheckRowID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                            #endregion
                        }
                        else
                        {
                            #region Add Reference Information
                            repoReferenceVer.AddReferenceByTeamMember(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "AddReferenceVerificationInfo", model.CheckStatus, "Reference Verification", "Insert");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification Information Submitted ");
                            #endregion

                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            return RedirectToAction("AddReferenceInfoByTeamMember", new { id = model.ReferenceCheckRowID });
                            #endregion
                        }
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        // BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        ReferenceVerList(model.ReferenceCheckRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoReferenceVer.GetPersonalDetailsForTM(model.ReferenceCheckRowID);
                        //return View(model);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "invlid Address id and model!";
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
            RatingNumber();

            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult ReferenceVerCloserDetails(int id = 0)
        {
            ReferenceVerCloserViewModel model = new ReferenceVerCloserViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoReferenceVer.GetReferenceVerCloserDetails(id);
                    if (model != null)
                    {
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Reference Id!";
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
        [HttpPost]
        public ActionResult ReferenceVerCloserDetails(ReferenceVerCloserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ReferenceVerRowID > 0)
                    {
                        short TeamMemberRowID = Convert.ToInt16(Session["TeamMemberRowID"]);

                        repoReferenceVer.AddReferenceVerCloserDetails(model);

                        #region Check Action History Save                           
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.ActionHistory);
                        #endregion
                        ModelState.Clear();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        return RedirectToAction("AddReferenceInfoByTeamMember", new { id = model.ReferenceCheckRowID });
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No item found!";
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
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UplodReferenceVerDocs(short scid = 0, int pe = 0, string cstatus = "")
        {
            VerifiedUploadDocViewModel model = new VerifiedUploadDocViewModel();
            try
            {
                if (scid > 0 && pe > 0)
                {
                    model.SubCheckRowID = scid;
                    model.PersonalRowID = pe;
                    model.CheckStatus = cstatus;
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
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UplodReferenceVerDocs(VerifiedUploadDocViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FldPathDoc = ConfigurationManager.AppSettings["provideddocuments"].ToString();
                    string proImg = string.Empty;
                    if (model.UploadDoc != null && model.UploadDoc.ContentLength > 0)
                    {
                        if (model.DocumentType == null)
                        {
                            model.DocumentType = "Varification Document";
                        }
                        model.DocumentUploadFrom = "Verified";
                        model.StatusDocxConvert = 0;
                        model.StatusPDF2DOCXConvert = 0;
                        model.UploadDate = DateTime.Now;
                        model.Status = 1;
                        string ext = Path.GetExtension(model.UploadDoc.FileName).ToLower();
                        proImg = ("Artifact" + "_" + model.PersonalRowID + "_" + model.SubCheckRowID + "_" + model.UploadDate.Value.ToString("ddMMyyyyHHmmss")).Replace("'", "_").Replace(" ", "_").Replace("-", "_") + ext;
                        model.UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                        model.FileName = proImg;
                        repoPQVerifiedUploadDoc.VerifiedUploadDoc(model);
                        int Res = repoPQVerifiedUploadDoc.SaveChanges();
                        if (Res > 0)
                        {
                            #region Check Action History Save                           
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Reference Verification information Upload Doc ");
                            #endregion
                            ModelState.Clear();
                            ViewBag.SuccessMsg = "Record Added Successfully!";
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                        }
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "please select upload doc!";
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
            return View(model);
        }
        [NonAction]
        void ReferenceVerList(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            //Bind AddressVer Details 
            ViewBag.modelBind = repoReferenceVer.GetReferenceForTM(id);

            ViewBag.ListReferenceVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
        }
        #endregion

        #region ******** NationalIdentity Verifiation By TeamMember ********

        [SessionExpireFilterAttribute]
        public ActionResult AddNationalIdentityInfoByTeamMember(int id = 0)
        {
            PQNationalIdentityVerViewModel model = new PQNationalIdentityVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoNationalIdentityVer.GetNationalIdentityInfoForDataEntry(id);
                    if (model != null)
                    {
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        // BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        NationalIdentityVerList(model.NationalIdentityRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoNationalIdentityVer.GetPersonalDetailsForTM(model.NationalIdentityRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No Detail Found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid NationalIdentity Id!";
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
        [HttpPost]
        public ActionResult AddNationalIdentityInfoByTeamMember(PQNationalIdentityVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        model.Status = 1;
                        if (model.NationalIdentityVerRowID > 0)
                        {
                            #region Update NationalIdentity Information
                            repoNationalIdentityVer.UpdateNationalIdentityByTeamMember(model);
                            int Res = repoNationalIdentityVer.SaveChanges();
                            if (Res > 0)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityVerificationInfo", model.CheckStatus, "NationalIdentity Verification", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("AddNationalIdentityInfoByTeamMember", new { id = model.NationalIdentityRowID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                            #endregion
                        }
                        else
                        {
                            #region Add NationalIdentity Information

                            repoNationalIdentityVer.AddNationalIdentityByTeamMember(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityVerificationInfo", model.CheckStatus, "NationalIdentity Verification", "Insert");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification Information Submitted ");
                            #endregion

                            ModelState.Clear();
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            return RedirectToAction("AddNationalIdentityInfoByTeamMember", new { id = model.NationalIdentityRowID });

                            #endregion
                        }
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        //BindCheckActionHistories(model.PersonalRowID, model.SubCheckRowID);
                        NationalIdentityVerList(model.NationalIdentityRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoNationalIdentityVer.GetPersonalDetailsForTM(model.NationalIdentityRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invlid NationalIdentity Id and model!";
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
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult NationalIdentityVerCloserDetails(int id = 0)
        {
            NationalIdentityVerCloserViewModel model = new NationalIdentityVerCloserViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoNationalIdentityVer.GetNationalIdentityVerCloserDetails(id);
                    if (model != null)
                    {
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No Detail Found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid NationalIdentity Id!";
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
        [HttpPost]
        public ActionResult NationalIdentityVerCloserDetails(NationalIdentityVerCloserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.NationalIdentityVerRowID > 0)
                    {
                        short TeamMemberRowID = Convert.ToInt16(Session["TeamMemberRowID"]);

                        repoNationalIdentityVer.AddNationalIdentityVerCloserDetails(model);

                        #region Check Action History Save                           
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.ActionHistory);
                        #endregion
                        ModelState.Clear();
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        return RedirectToAction("AddNationalIdentityInfoByTeamMember", new { id = model.NationalIdentityRowID });
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No item found!";
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
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UplodNationalIdentityVerDocs(short scid = 0, int pe = 0, string cstatus = "")
        {
            VerifiedUploadDocViewModel model = new VerifiedUploadDocViewModel();
            try
            {
                if (scid > 0 && pe > 0)
                {
                    model.SubCheckRowID = scid;
                    model.PersonalRowID = pe;
                    model.CheckStatus = cstatus;
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid National Identity id!";
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
        [HttpPost]
        public ActionResult UplodNationalIdentityVerDocs(VerifiedUploadDocViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FldPathDoc = ConfigurationManager.AppSettings["provideddocuments"].ToString();
                    string proImg = string.Empty;
                    if (model.UploadDoc != null && model.UploadDoc.ContentLength > 0)
                    {
                        if (model.DocumentType == null)
                        {
                            model.DocumentType = "Varification Document";
                        }
                        model.DocumentUploadFrom = "Verified";
                        model.StatusDocxConvert = 0;
                        model.StatusPDF2DOCXConvert = 0;
                        model.UploadDate = DateTime.Now;
                        model.Status = 1;
                        string ext = Path.GetExtension(model.UploadDoc.FileName).ToLower();
                        proImg = ("Artifact" + "_" + model.PersonalRowID + "_" + model.SubCheckRowID + "_" + model.UploadDate.Value.ToString("ddMMyyyyHHmmss")).Replace("'", "_").Replace(" ", "_").Replace("-", "_") + ext;
                        model.UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                        model.FileName = proImg;
                        repoPQVerifiedUploadDoc.VerifiedUploadDoc(model);
                        int Res = repoPQVerifiedUploadDoc.SaveChanges();
                        if (Res > 0)
                        {
                            #region Check Action History Save                           
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "National Identity Verification information Upload Doc ");
                            #endregion
                            ModelState.Clear();
                            ViewBag.SuccessMsg = "Record Added Successfully!";
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is no change!";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "please select upload doc!";
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
            return View(model);
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

        #endregion

        #region ******** Capture/Show Action History For All Checks ********

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult CheckActionHistory(short scid = 0, int pe = 0)
        {
            try
            {
                ViewBag.CheckActionHistories = repoDDL.GetCheckActionHistory(pe, scid);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return PartialView("_CheckActionHistories");
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult CaptureActionHistoryByVerTM(int id = 0, short cid = 0, short scid = 0, int pe = 0)
        {
            CaptureActionHistoryByVerTM model = new CaptureActionHistoryByVerTM();
            try
            {
                if (id > 0 && cid > 0 && scid > 0 && pe > 0)
                {
                    model.CheckRowID = id;
                    model.ClientRowID = cid;
                    model.SubCheckRowID = scid;
                    model.PersonalRowID = pe;
                }
                else
                {
                    TempData["ErrorMsg"] = "invlid id!";
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
        [HttpPost]
        public ActionResult CaptureActionHistoryByVerTM(CaptureActionHistoryByVerTM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CheckRowID > 0)
                    {
                        short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                        string Designation = Session["Designation"].ToString();

                        if (Designation == "Team Member-Add")
                        {
                            #region Capture Action For Address

                            bool IsSuccess = false;

                            PQUpdateAddressTeamMemberViewModel empModel = new PQUpdateAddressTeamMemberViewModel();
                            empModel.ModifiedBy = teamMemerRowId;
                            empModel.ModifiedDate = DateTime.Now;
                            empModel.CheckStatus = model.CheckStatus;
                            empModel.AddressRowID = model.CheckRowID;
                            empModel.ActionRemark = model.ActionHistory;
                            var addDetails = repoAddressInfo.GetPQAddressDetailsById(model.CheckRowID);

                            if (model.CheckStatus == "Re-Visit")
                            {
                                if (repoAddressInfo.IsAddressCheckAllocatedToPartner(model.CheckRowID))
                                {
                                    repoAddressInfo.UpdateAddressByTeamMember(empModel);
                                    ViewBag.SuccessMsg = "Record update successfully";
                                    IsSuccess = true;
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "Check not allocated to partner yet!";
                                }
                            }
                            else if (model.CheckStatus == "Pre Calling" || model.CheckStatus == "Post Calling")
                            {
                                ViewBag.SuccessMsg = "Record update successfully";
                                IsSuccess = true;
                            }
                            else
                            {
                                repoAddressInfo.UpdateAddressByTeamMember(empModel);
                                ViewBag.SuccessMsg = "Record update successfully";
                                IsSuccess = true;
                            }

                            if (IsSuccess)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "CaptureActionHistoryByVerTM", model.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, empModel.CheckStatus, model.ActionHistory);
                                #endregion  
                            }

                            #endregion
                        }
                        else if (Designation == "Team Member-Emp")
                        {
                            #region Capture Action For Employment

                            bool IsSuccess = false;

                            PQUpdateEmploymentTeamMemberViewModel empModel = new PQUpdateEmploymentTeamMemberViewModel();
                            empModel.ModifiedBy = teamMemerRowId;
                            empModel.ModifiedDate = DateTime.Now;
                            empModel.CheckStatus = model.CheckStatus;
                            empModel.EmploymentRowID = model.CheckRowID;
                            empModel.ActionRemark = model.ActionHistory;
                            var addDetails = repoEmploymentInfo.GetPQEmploymentDetailsById(model.CheckRowID);

                            if (model.CheckStatus == "SendToResearch")
                            {
                                SendAlertMassageToReSearcher(Designation, model.ClientRowID, model.CheckRowID, model.ActionHistory);
                                ViewBag.SuccessMsg = "Notification sent to researcher!";
                                IsSuccess = true;
                            }
                            else if (model.CheckStatus == "PV Raised")
                            {
                                short result = repoPQClientTMember.GetClientTeamPVManager(model.ClientRowID, "Physical Verification", "Manager-PV");
                                if (result > 0)
                                {
                                    empModel.PVMgrAllocatedTo = result;
                                    repoEmploymentInfo.UpdateEmploymentInfoByTeamMember(empModel);
                                    ViewBag.SuccessMsg = "Record update successfully";
                                    IsSuccess = true;
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "Please assign physical manager for this client";
                                }
                            }
                            else
                            {
                                repoEmploymentInfo.UpdateEmploymentInfoByTeamMember(empModel);
                                ViewBag.SuccessMsg = "Record update successfully";
                                IsSuccess = true;
                            }

                            if (IsSuccess)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "CaptureActionHistoryByVerTM", model.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, empModel.CheckStatus, model.ActionHistory);
                                #endregion  
                            }

                            #endregion
                        }
                        else if (Designation == "Team Member-Edu")
                        {
                            #region Capture Action For Education

                            bool IsSuccess = false;

                            PQUpdateEducationTeamMemberViewModel empModel = new PQUpdateEducationTeamMemberViewModel();
                            empModel.ModifiedBy = teamMemerRowId;
                            empModel.ModifiedDate = DateTime.Now;
                            empModel.CheckStatus = model.CheckStatus;
                            empModel.EducationRowID = model.CheckRowID;
                            empModel.ActionRemark = model.ActionHistory;
                            var addDetails = repoEducationInfo.GetPQEducationDetailsById(model.CheckRowID);

                            if (model.CheckStatus == "SendToResearch")
                            {
                                SendAlertMassageToReSearcher(Designation, model.ClientRowID, model.CheckRowID, model.ActionHistory);
                                ViewBag.SuccessMsg = "Notification sent to researcher!";
                                IsSuccess = true;
                            }
                            else if (model.CheckStatus == "PV Raised")
                            {
                                short result = repoPQClientTMember.GetClientTeamPVManager(model.ClientRowID, "Physical Verification", "Manager-PV");
                                if (result > 0)
                                {
                                    empModel.PVMgrAllocatedTo = result;
                                    repoEducationInfo.UpdateEducationInfoByTeamMember(empModel);
                                    ViewBag.SuccessMsg = "Record update successfully";
                                    IsSuccess = true;
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Please assign physical manager for this client";
                                }
                            }
                            else
                            {
                                repoEducationInfo.UpdateEducationInfoByTeamMember(empModel);
                                ViewBag.SuccessMsg = "Record update successfully";
                                IsSuccess = true;
                            }

                            if (IsSuccess)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "CaptureActionHistoryByVerTM", model.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, empModel.CheckStatus, model.ActionHistory);
                                #endregion  
                            }

                            #endregion
                        }
                        else if (Designation == "Team Member-Cri")
                        {
                            #region Capture Action For Criminal

                            bool IsSuccess = false;

                            PQUpdateCriminalTeamMemberViewModel empModel = new PQUpdateCriminalTeamMemberViewModel();
                            empModel.ModifiedBy = teamMemerRowId;
                            empModel.ModifiedDate = DateTime.Now;
                            empModel.CheckStatus = model.CheckStatus;
                            empModel.CriminalRowID = model.CheckRowID;
                            empModel.ActionRemark = model.ActionHistory;
                            var addDetails = repoCriminalInfo.GetPQCriminalDetailsById(model.CheckRowID);

                            if (model.CheckStatus == "PV Raised")
                            {
                                short result = repoPQClientTMember.GetClientTeamPVManager(model.ClientRowID, "Physical Verification", "Manager-PV");
                                if (result > 0)
                                {
                                    empModel.PVMgrAllocatedTo = result;
                                    repoCriminalInfo.UpdateCriminalInfoByTeamMember(empModel);
                                    ViewBag.SuccessMsg = "Record update successfully";
                                    IsSuccess = true;
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Please assign physical manager for this client";
                                }
                            }
                            else
                            {
                                repoCriminalInfo.UpdateCriminalInfoByTeamMember(empModel);
                                ViewBag.SuccessMsg = "Record update successfully";
                                IsSuccess = true;
                            }

                            if (IsSuccess)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "CaptureActionHistoryByVerTM", model.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, empModel.CheckStatus, model.ActionHistory);
                                #endregion  
                            }

                            #endregion
                        }
                        else if (Designation == "Team Member-Ref")
                        {
                            #region Capture Action For Reference

                            bool IsSuccess = false;

                            PQUpdateReferenceTeamMemberViewModel empModel = new PQUpdateReferenceTeamMemberViewModel();
                            empModel.ModifiedBy = teamMemerRowId;
                            empModel.ModifiedDate = DateTime.Now;
                            empModel.CheckStatus = model.CheckStatus;
                            empModel.ReferenceRowID = model.CheckRowID;
                            empModel.ActionRemark = model.ActionHistory;
                            var addDetails = repoReferenceInfo.GetPQReferenceDetailsById(model.CheckRowID);

                            if (model.CheckStatus == "PV Raised")
                            {
                                short result = repoPQClientTMember.GetClientTeamPVManager(model.ClientRowID, "Physical Verification", "Manager-PV");
                                if (result > 0)
                                {
                                    empModel.PVMgrAllocatedTo = result;
                                    repoReferenceInfo.UpdateReferenceInfoByTeamMember(empModel);
                                    ViewBag.SuccessMsg = "Record update successfully";
                                    IsSuccess = true;
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Please assign physical manager for this client";
                                }
                            }
                            else
                            {
                                repoReferenceInfo.UpdateReferenceInfoByTeamMember(empModel);
                                ViewBag.SuccessMsg = "Record update successfully";
                                IsSuccess = true;
                            }

                            if (IsSuccess)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "CaptureActionHistoryByVerTM", model.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, empModel.CheckStatus, model.ActionHistory);
                                #endregion  
                            }

                            #endregion
                        }
                        else if (Designation == "Team Member-Ide")
                        {
                            #region Capture Action For National Identity

                            bool IsSuccess = false;

                            PQUpdateNationalIdentityTeamMemberViewModel empModel = new PQUpdateNationalIdentityTeamMemberViewModel();
                            empModel.ModifiedBy = teamMemerRowId;
                            empModel.ModifiedDate = DateTime.Now;
                            empModel.CheckStatus = model.CheckStatus;
                            empModel.NationalIdentityRowID = model.CheckRowID;
                            empModel.ActionRemark = model.ActionHistory;
                            var addDetails = repoNationalIdentInfo.GetPQNationalIdentityDetailsById(model.CheckRowID);

                            if (model.CheckStatus == "PV Raised")
                            {
                                short result = repoPQClientTMember.GetClientTeamPVManager(model.ClientRowID, "Physical Verification", "Manager-PV");
                                if (result > 0)
                                {
                                    empModel.PVMgrAllocatedTo = result;
                                    repoNationalIdentInfo.UpdateNationalIdentityInfoByTeamMember(empModel);
                                    ViewBag.SuccessMsg = "Record update successfully";
                                    IsSuccess = true;
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Please assign physical manager for this client";
                                }
                            }
                            else
                            {
                                repoNationalIdentInfo.UpdateNationalIdentityInfoByTeamMember(empModel);
                                ViewBag.SuccessMsg = "Record update successfully";
                                IsSuccess = true;
                            }

                            if (IsSuccess)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "CaptureActionHistoryByVerTM", model.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, empModel.CheckStatus, model.ActionHistory);
                                #endregion  
                            }

                            #endregion
                        }
                        else if (Designation == "Team Member-SPL")
                        {
                            #region Capture Action For National Identity

                            bool IsSuccess = false;

                            PQUpdateSpecialCheckTeamMemberViewModel empModel = new PQUpdateSpecialCheckTeamMemberViewModel();
                            empModel.ModifiedBy = teamMemerRowId;
                            empModel.ModifiedDate = DateTime.Now;
                            empModel.CheckStatus = model.CheckStatus;
                            empModel.SpecialCheckRowID = model.CheckRowID;
                            empModel.ActionRemark = model.ActionHistory;
                            var addDetails = repoSplChkVer.GetPQSpecialCheckDetailsById(model.CheckRowID);

                            if (model.CheckStatus == "PV Raised")
                            {
                                short result = repoPQClientTMember.GetClientTeamPVManager(model.ClientRowID, "Physical Verification", "Manager-PV");
                                if (result > 0)
                                {
                                    empModel.PVMgrAllocatedTo = result;
                                    repoSplChkVer.UpdateSpecialCheckInfoByTeamMember(empModel);
                                    ViewBag.SuccessMsg = "Record update successfully";
                                    IsSuccess = true;
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Please assign physical manager for this client";
                                }
                            }
                            else
                            {
                                repoSplChkVer.UpdateSpecialCheckInfoByTeamMember(empModel);
                                ViewBag.SuccessMsg = "Record update successfully";
                                IsSuccess = true;
                            }

                            if (IsSuccess)
                            {
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "CaptureActionHistoryByVerTM", model.CheckStatus, addDetails.UniqueComponentID, "Update");
                                #endregion

                                #region Case/Check Action History Save 
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, empModel.CheckStatus, model.ActionHistory);
                                #endregion  
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
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public JsonResult GetClientExtraExpensesAllowed(short id = 0)
        {
            try
            {
                var data = repoPQClient.GetClientExtraExpensesAllowedByID(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ******** Email Templetes for Verifier ********

        //Send Email to Researcher (Education / Employer)

        private void SendAlertMassageToReSearcher(string Designation, short ClientRowID, int CheckRowID, string Remarks)
        {
            bool flag = false;
            string To = string.Empty;
            string Subject = string.Empty;
            string MailSignature = string.Empty;
            string From = string.Empty;
            string DisplayName = string.Empty;
            bool result = false;

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Emailers/Company/NotifyResearch.html")))
            {
                body = reader.ReadToEnd();
            }

            if (Designation == "Team Member-Emp")
            {
                var ResearchTM = repoPQClientTMember.GetDepManagerClientToTeam(ClientRowID, "Team Member-Emp-Research").FirstOrDefault();
                if (ResearchTM != null && !string.IsNullOrEmpty(ResearchTM.TeamMemberEmail) && ResearchTM.TeamMemberEmail.Trim().Length > 0)
                {
                    To = ResearchTM.TeamMemberEmail.Trim();
                    flag = true;
                }
                else
                {
                    ViewBag.ErrorMsg = "Employment Research Team Member Not Found!";
                }

                Subject = "Update Company Information!";
                body = body.Replace("{EduEmpType}", "Company");
                string CompanyName = repoEmploymentVer.GetCompanyNameForResearch(CheckRowID);
                if (!string.IsNullOrEmpty(CompanyName))
                {
                    body = body.Replace("{EmpOrColgName}", "Company Name : " + CompanyName);
                }
            }

            if (Designation == "Team Member-Edu")
            {
                var ResearchTM = repoPQClientTMember.GetDepManagerClientToTeam(ClientRowID, "Team Member-Edu-Research").FirstOrDefault();
                if (ResearchTM != null && !string.IsNullOrEmpty(ResearchTM.TeamMemberEmail) && ResearchTM.TeamMemberEmail.Trim().Length > 0)
                {
                    To = ResearchTM.TeamMemberEmail.Trim();
                    flag = true;
                }
                else
                {
                    ViewBag.ErrorMsg = "Education Research Team Member Not Found!";
                }

                Subject = "Update College Information!";
                body = body.Replace("{EduEmpType}", "College");
                string CollegeName = repoEducationVer.GetCollegeNameForResearch(CheckRowID);
                if (!string.IsNullOrEmpty(CollegeName))
                {
                    body = body.Replace("{EmpOrColgName}", "College Name : " + CollegeName);
                }
            }

            if (flag)
            {
                clsSendMail mail = new clsSendMail();
                var signature = mail.GetCompanyMailSignature();

                if (signature != null && signature.GeneralEmail != null && signature.GeneralEmail.Trim().Length > 0)
                {
                    From = signature.GeneralEmail;
                    DisplayName = signature.CompanyName.Trim();

                    MailSignature = string.Concat("For Securitas India. <br /><br />");
                    MailSignature = string.Concat(MailSignature, "<b>", signature.CompanyName.Trim(), "</b><br /><b>Mobile: ", signature.MobileNo,
                        " | Direct Tel: ", signature.PhoneNo, " | Fax: ", signature.FaxNo, "</b><br /><b>E-mail id </b>: <a style='color:#df012a;' href='mailto:", signature.GeneralEmail, "'>", signature.GeneralEmail, "</a>");


                    body = body.Replace("{RSearchRemarks}", Remarks);

                    body = body.Replace("{MailSignature}", MailSignature);

                    result = mail.SendMail(DisplayName, From, To, Subject, body);
                    if (result)
                    {
                        ViewBag.SuccessMsg = "Mail Sent Successfully!";
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Mail sending failed!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "From mail id invalid!";
                }
            }
        }

        public ActionResult EmploymentVerEmailDetails(int id = 0)
        {
            EmploymentEmailVerificationViewModel model = new EmploymentEmailVerificationViewModel();
            if (id > 0)
            {
                model = repoEmailVerification.GetEmploymentEmailVerification(id);
            }
            return View(model);
        }

        public ActionResult EducationVerEmailDetails(int id = 0)
        {
            EducationEmailVerificationViewModel model = new EducationEmailVerificationViewModel();
            if (id > 0)
            {
                model = repoEmailVerification.GetEducationEmailVerification(id);
            }
            return View(model);
        }

        public ActionResult ReferenceVerEmailDetails(int id = 0)
        {
            return View();
        }

        #endregion

        #region ******** Spacial Check Verifiation By TeamMember ********
        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult AddSpecialCheckInfoByTeamMember(int id = 0)
        {
            PQSpecialCheckVerViewModel model = new PQSpecialCheckVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoSplChkVer.GetSpecialCheckInfoForDataEntry(id);
                    if (model != null)
                    {
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        SpecialCheckVerList(model.SpecialCheckRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoSplChkVer.GetPersonalDetailsForTM(id);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No Details found!";
                    }

                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Education Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            BindSeverityGrids(model.ClientRowID);
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult AddSpecialCheckInfoByTeamMember(PQSpecialCheckVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null)
                    {
                        model.Status = 1;
                        if (!string.IsNullOrEmpty(model.Severity) && !string.IsNullOrEmpty(model.CheckStatus) && !string.IsNullOrEmpty(model.ColorName))
                        {
                            if ((model.CheckStatus == "Review Requested" && !string.IsNullOrEmpty(model.SC_AnyOtherComments)) || model.CheckStatus == "Completed")
                            {
                                model.Status = 1;
                                if (model.SpecialCheckVerRowID > 0)
                                {
                                    #region Update Education                             
                                    repoSplChkVer.UpdateSpecialCheckInfoByDataEntry(model);

                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateSpecialCheckVerificationInfo", model.CheckStatus, "SpecialCheck Verification", "Update");
                                    #endregion

                                    #region Case/Check Action History Save
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated");
                                    #endregion

                                    ModelState.Clear();
                                    return RedirectToAction("AddSpecialCheckInfoByTeamMember", new { id = model.SpecialCheckRowID });
                                    #endregion
                                }
                                else
                                {
                                    #region Add SpecialCheck Information
                                    repoSplChkVer.AddSpacelCheckInfoByDataEntryn(model);

                                    #region Save LogTransaction Details
                                    clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "InsertSpecialCheckVerificationInfo", model.CheckStatus, "SpecialCheck Verification", "Insert");
                                    #endregion

                                    #region Case/Check Action History Save
                                    clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification Information Submitted ");
                                    #endregion

                                    ModelState.Clear();
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    return RedirectToAction("AddSpecialCheckInfoByTeamMember", new { id = model.SpecialCheckRowID });

                                    #endregion
                                }
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "Remarks is Required!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Severity, CheckStatus & ColorName is Required!";
                        }

                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        SpecialCheckVerList(model.SpecialCheckRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(model.SubCheckRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invalid Special Check id and model!";
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

            BindSeverityGrids(model.ClientRowID);
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UplodSpecialCheckVerDocs(short scid = 0, int pe = 0, string cstatus = "")
        {
            VerifiedUploadDocViewModel model = new VerifiedUploadDocViewModel();
            try
            {
                if (scid > 0 && pe > 0)
                {
                    model.SubCheckRowID = scid;
                    model.PersonalRowID = pe;
                    model.CheckStatus = cstatus;
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

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UplodSpecialCheckVerDocs(VerifiedUploadDocViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FldPathDoc = ConfigurationManager.AppSettings["provideddocuments"].ToString();
                    string proImg = string.Empty;
                    if (model.UploadDoc != null && model.UploadDoc.ContentLength > 0)
                    {
                        if (model.DocumentType == null)
                        {
                            model.DocumentType = "Varification Document";
                        }
                        model.DocumentUploadFrom = "Verified";
                        model.StatusDocxConvert = 0;
                        model.StatusPDF2DOCXConvert = 0;
                        model.UploadDate = DateTime.Now;
                        model.Status = 1;
                        string ext = Path.GetExtension(model.UploadDoc.FileName).ToLower();
                        proImg = ("Artifact" + "_" + model.PersonalRowID + "_" + model.SubCheckRowID + "_" + model.UploadDate.Value.ToString("ddMMyyyyHHmmss")).Replace("'", "_").Replace(" ", "_").Replace("-", "_") + ext;
                        model.UploadDoc.SaveAs(Server.MapPath(FldPathDoc + proImg));
                        model.FileName = proImg;
                        repoPQVerifiedUploadDoc.VerifiedUploadDoc(model);
                        int Res = repoPQVerifiedUploadDoc.SaveChanges();
                        if (Res > 0)
                        {
                            #region Check Action History Save                           
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Special Check Vrification information Upload Doc ");
                            #endregion
                            ModelState.Clear();
                            ViewBag.SuccessMsg = "Record Added Successfully!";
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "please select upload doc!";
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
            return View(model);
        }

        [NonAction]
        void SpecialCheckVerList(int SpecialCheckRowId = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0)
        {
            try
            {
                var modelBind = repoSplChkVer.GetSpecialCheckForTM(SpecialCheckRowId);
                ViewBag.modelBind = modelBind;
                ViewBag.ListSpecialCheckVer = repoDDL.GetAntecedentVerList(ClientRowId, ChFamilRowId, subCheckId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        void BindSeverityGrids(short ClientRowID)
        {
            try
            {
                ViewBag.SeverityGrids = repoDDL.GetClientSeveritiesGridDDL(ClientRowID);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion
        #endregion

        #region ******** Manage By Department Team Leader for Review Requested ********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ViewAddressVerInfo(int id)
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
                    ViewBag.ErrorMsg = "Invlid Address id!";
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
        public ActionResult ViewAddressVerInfo(ViewAddressViewModel model)
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
                            repoAddressInfo.ViewAddressInfoByVrifierTL(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewAddressVerInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageReviewRequestedChecksForDepartmentTL", "Insuff");
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
        public ActionResult ViewEmploymentVerInfo(int id)
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
        public ActionResult ViewEmploymentVerInfo(ViewEmploymentViewModel model)
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
                            repoEmploymentInfo.ViewEmploymentInfoByVrifierTL(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewEmploymentVerInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageReviewRequestedChecksForDepartmentTL", "Insuff");
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
        public ActionResult ViewEducationVerInfo(int id)
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
                        ViewBag.VerifyInfo = verInfo;
                        verInfo.CloserViewModel = repoEducationVer.GetEducationVerCloserDetails(verInfo.EducationVerRowID);
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(model.EducationRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
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
        public ActionResult ViewEducationVerInfo(ViewEducationViewModel model)
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
                            model.CheckStatus = "WIP-Pending";
                            repoEducationInfo.ViewEducationInfoByVrifierTL(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewEducationVerInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageReviewRequestedChecksForDepartmentTL", "Insuff");
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
            EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ViewReferenceVerInfo(int id)
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
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        ReferenceVerList(model.ReferenceRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoReferenceVer.GetPersonalDetailsForTM(model.ReferenceRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Reference id!";
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
        public ActionResult ViewReferenceVerInfo(ViewReferenceViewModel model)
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
                            repoReferenceInfo.ViewReferenceInfoByVrifierTL(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewReferenceVerInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageReviewRequestedChecksForDepartmentTL", "Insuff");
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
        public ActionResult ViewCriminalVerInfo(int id)
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
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
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
        public ActionResult ViewCriminalVerInfo(ViewCriminalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CriminalRowID > 0)
                    {
                        #region Update Employment Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";
                            repoCriminalInfo.ViewCriminalInfoByVrifierTL(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewCriminalVerInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageReviewRequestedChecksForDepartmentTL", "Insuff");
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
        public ActionResult ViewNationalIdentityVerInfo(int id)
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
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        NationalIdentityVerList(model.NationalIdentityRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoNationalIdentityVer.GetPersonalDetailsForTM(model.NationalIdentityRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
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
        public ActionResult ViewNationalIdentityVerInfo(ViewNationalIdentityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.NationalIdentityRowID > 0)
                    {
                        #region Update NationalIdentity Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";
                            repoNationalIdentInfo.ViewNationalIdentityInfoByVrifierTL(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewNationalIdentityVerInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageReviewRequestedChecksForDepartmentTL", "Insuff");
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
                verInfo.CloserViewModel = repoNationalIdentityVer.GetNationalIdentityVerCloserDetails(verInfo.NationalIdentityVerRowID);
            }
            NationalIdentityVerList(model.NationalIdentityRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ViewSpecialCheckVerInfo(int id)
        {
            ViewSpecialCheckViewModel model = new ViewSpecialCheckViewModel();
            try
            {
                if (id > 0)
                {
                    var verInfo = repoSplChkVer.GetSpecialCheckInfoForTMQC(id);

                    if (verInfo != null)
                    {
                        model.SpecialCheckRowId = verInfo.SpecialCheckRowID;
                        model.CheckFamilyRowID = verInfo.CheckFamilyRowID;
                        model.ClientRowID = verInfo.ClientRowID;
                        model.PersonalRowID = verInfo.PersonalRowID;
                        model.SubCheckRowID = verInfo.SubCheckRowID;
                        model.CheckStatus = verInfo.CheckStatus;
                        ViewBag.VerifyInfo = verInfo;

                        // verInfo.CloserViewModel = repoReferenceVer.GetReferenceVerCloserDetails(verInfo.SpecialCheckVerRowID);
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        SpecialCheckVerList(model.SpecialCheckRowId, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoSplChkVer.GetPersonalDetailsForTM(model.SpecialCheckRowId);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No detail found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Reference id!";
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
        public ActionResult ViewSpecialCheckVerInfo(ViewSpecialCheckViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SpecialCheckRowId > 0)
                    {
                        #region Update Reference Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            model.CheckStatus = "WIP-Pending";
                            repoSplChkVer.ViewSpecialCheckInfoByVrifierTL(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "ViewSpecialCheckVerInfo", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 

                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            //int PID = model.PersonalRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageReviewRequestedChecksForDepartmentTL", "Insuff");
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
            var verInfo = repoSplChkVer.GetSpecialCheckInfoForTMQC(model.SpecialCheckRowId);

            if (verInfo != null)
            {
                ViewBag.VerifyInfo = verInfo;
                verInfo.CloserViewModel = null;//repoReferenceVer.GetReferenceVerCloserDetails(verInfo.ReferenceCheckVerRowID);
            }
            SpecialCheckVerList(model.SpecialCheckRowId, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);

            return View(model);
        }
        #endregion

        #region ******** Manage FundPending By Department Team Leader ********

        [SessionExpireFilterAttribute]
        public ActionResult ManageFundPendingChecksForDeprtTL(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
                model = repoPQVerifiedUploadDoc.GetFundPendingCheckListForDepartTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, teamMemberId);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            BindClientList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult FundPendingApproveByDepartmentTL(int PersonalId = 0, int VerId = 0, short chkFmlyId = 0, short SubchkFmlyId = 0)
        {
            FundPendingApprovalViewModel model = new FundPendingApprovalViewModel();
            try
            {
                if (PersonalId > 0 && VerId > 0 && chkFmlyId > 0 && SubchkFmlyId > 0)
                {
                    model.PersonalRowID = PersonalId;
                    model.VerificationRowID = VerId;
                    model.CheckFamilyRowID = chkFmlyId;
                    model.SubCheckRowID = SubchkFmlyId;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult FundPendingApproveByDepartmentTL(FundPendingApprovalViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PersonalRowID > 0 && model.VerificationRowID > 0 && model.CheckFamilyRowID > 0 && model.SubCheckRowID > 0)
                    {
                        model.CheckStatus = "WIP-Pending";
                        model.ModifiedBy = Convert.ToInt16(Session["TeamMemberRowID"]);
                        model.ModifiedDate = DateTime.Now;
                        repoVerificationInfo.FundPendingChecksUpdateByDepartmentTL(model);

                        #region Check Action History Save                           
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                        #endregion

                        ModelState.Clear();
                        ViewBag.SuccessMsg = "Record Updated Successfully!";

                        //TempData["SuccessMsg"] = "Record Updated Successfully!";
                        //RedirectToAction("ManageFundPendingChecksForDeprtTL");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "All fields are mandatory!";
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
            return View(model);
        }

        #endregion

        #region ******** Manage By Department Team Member Quality Check ********

        #region  Update Address Verification By Quality Check

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UpdateAddressInfoByTMQC(int id = 0)
        {
            UpdatePQAddressVerViewModel model = new UpdatePQAddressVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoAddressVer.GetAddressInfoForTMQC(id);
                    if (model != null)
                    {
                        model.CloserViewModel = repoAddressVer.GetVerificationCloserDetails(model.AddressVerRowID);
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
                    ViewBag.ErrorMsg = "Invlid Address id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            TotalNumber();
            BindCountry();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UpdateAddressInfoByTMQC(UpdatePQAddressVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.AddressRowID > 0 && model.ClientRowID > 0 && model.CheckFamilyRowID > 0 && model.SubCheckRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            repoAddressVer.UpdateAddressByTMQC(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressInfoByTMQC", model.CheckStatus, "Address Verification TMQC", "Updated");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.CloserViewModel.ActionHistory);
                            #endregion

                            ModelState.Clear();
                            return RedirectToAction("DepartmentTeamMemberQCChecks");
                        }
                        else
                        {
                            if (model.CheckStatus == "Funds Pending")
                            {
                                SendAlertMassageForFundPending(model.ClientRowID, model.AddressRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                            }

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

                            if (model.AddressVerRowID > 0)
                            {
                                bool flag = false;
                                #region Update Address Information

                                if (model.CloserViewModel.ColorName == "green")
                                {
                                    //short rptQCMgrId = repoTeamDepartment.GetTeamMemberRptWriterManager("Manager-Rpt-QC");
                                    var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                    if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                    {
                                        repoAddressVer.UpdateAddressByTMQC(model, mgrData.TeamMemberRowID);
                                        flag = true;
                                        //Check All Checks are completed then put case status completed
                                        UpdateCaseCompleted(model.PersonalRowID);
                                    }
                                    else
                                    {
                                        TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                        return RedirectToAction("UpdateAddressInfoByTMQC", new { id = model.AddressRowID });
                                    }
                                }
                                else
                                {
                                    repoAddressVer.UpdateAddressByTMQC(model);
                                }

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By Verifier TMQC");
                                if (flag)
                                {
                                    if (model.CheckStatus == "Rejected-RWQC")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-TM", "Allocated to Report QC Team Member");
                                    }
                                    else
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "Allocated to Report QC Manager");
                                    }
                                }
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                            else
                            {
                                #region Add Address Information

                                repoAddressVer.UpdateAddressByTMQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressVerificationInfo", model.CheckStatus, "Address Verification TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated TMQC");
                                #endregion

                                ModelState.Clear();
                                //TempData["SuccessMsg"] = "Record Added Successfully!";
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "invlid Address id and model!";
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

            model.CloserViewModel = repoAddressVer.GetVerificationCloserDetails(model.AddressVerRowID);
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
            AddressVerList(model.AddressRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoAddressVer.GetPersonalDetailsForTM(model.AddressRowID);

            TotalNumber();
            BindCountry();
            return View(model);
        }
        #endregion

        #region  Update Employment Verification By Quality Check

        [SessionExpireFilterAttribute]
        public ActionResult UpdateEmploymentInfoByTMQC(int id = 0)
        {
            UpdatePQEmploymentVerViewModel model = new UpdatePQEmploymentVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoEmploymentVer.GetEmploymentInfoForTMQC(id);
                    if (model != null)
                    {
                        model.CloserViewModel = repoEmploymentVer.GetEmploymentVerCloserDetails(model.EmploymentVerRowID);
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

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UpdateEmploymentInfoByTMQC(UpdatePQEmploymentVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmploymentRowID > 0 && model.ClientRowID > 0 && model.CheckFamilyRowID > 0 && model.SubCheckRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            repoEmploymentVer.UpdateEmploymentByTMQC(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentInfoByTMQC", model.CheckStatus, "Employment Verification TMQC", "Updated");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.CloserViewModel.ActionHistory);
                            #endregion

                            ModelState.Clear();
                            return RedirectToAction("DepartmentTeamMemberQCChecks");
                        }
                        else
                        {
                            if (model.CheckStatus == "Funds Pending")
                            {
                                SendAlertMassageForFundPending(model.ClientRowID, model.EmploymentRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                            }

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

                            if (model.EmploymentVerRowID > 0)
                            {
                                bool flag = false;
                                #region Update Employment Information

                                if (model.CloserViewModel.ColorName.ToLower() == "green")
                                {
                                    //short rptQCMgrId = repoTeamDepartment.GetTeamMemberRptWriterManager("Manager-Rpt-QC");
                                    var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                    if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                    {
                                        repoEmploymentVer.UpdateEmploymentByTMQC(model, mgrData.TeamMemberRowID);
                                        flag = true;
                                        //Check All Checks are completed then put case status completed
                                        UpdateCaseCompleted(model.PersonalRowID);
                                    }
                                    else
                                    {
                                        TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                        return RedirectToAction("UpdateEmploymentInfoByTMQC", new { id = model.EmploymentRowID });
                                    }
                                }
                                else
                                {
                                    repoEmploymentVer.UpdateEmploymentByTMQC(model);
                                }

                                #region Save LogTransaction Details

                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Update");

                                #endregion

                                #region Case/Check Action History Save

                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By Verifier TMQC");
                                if (flag)
                                {
                                    if (model.CheckStatus == "Rejected-RWQC")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-TM", "Allocated to Report QC Team Member");
                                    }
                                    else
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "Allocated to Report QC Manager");
                                    }
                                }

                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");

                                #endregion
                            }
                            else
                            {
                                #region Add Employment Information

                                repoEmploymentVer.UpdateEmploymentByTMQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentInfoByTMQC", model.CheckStatus, "Employment Verification TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated TMQC");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");

                                #endregion
                            }
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

            model.CloserViewModel = repoEmploymentVer.GetEmploymentVerCloserDetails(model.EmploymentVerRowID);
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
            EmployementVerList(model.EmploymentRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoEmploymentVer.GetPersonalDetailsForTM(model.EmploymentRowID);

            RatingNumber();
            BindCountry();
            return View(model);
        }

        #endregion

        #region  Update Education Verification By Quality Check

        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UpdateEducationInfoByTMQC(int id = 0)
        {
            UpdatePQEducationVerViewModel model = new UpdatePQEducationVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoEducationVer.GetEducationInfoForTMQC(id);
                    if (model != null)
                    {
                        model.CloserViewModel = repoEducationVer.GetEducationVerCloserDetails(model.EducationVerRowID);
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
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
                    ViewBag.ErrorMsg = "Invlid Education Id!";
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

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UpdateEducationInfoByTMQC(UpdatePQEducationVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EducationRowID > 0 && model.ClientRowID > 0 && model.CheckFamilyRowID > 0 && model.SubCheckRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            repoEducationVer.UpdateEducationByTMQC(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Updated");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.CloserViewModel.ActionHistory);
                            #endregion

                            ModelState.Clear();
                            return RedirectToAction("DepartmentTeamMemberQCChecks");
                        }
                        else
                        {
                            if (model.CheckStatus == "Funds Pending")
                            {
                                SendAlertMassageForFundPending(model.ClientRowID, model.EducationRowID, model.CheckFamilyRowID, model.SubCheckRowID);

                                #region Send Mail To Candidate

                                //string MailSignature = string.Empty;
                                //string From = string.Empty;
                                //string DisplayName = string.Empty;
                                //string Cc = Session["CSpocEmailID"].ToString();

                                //clsSendMail mail;

                                //var cSmtp = repoPQClient.GetPQClientSendMailFromById(model.ClientRowID);
                                //if (cSmtp != null && cSmtp.MailSendBy > 0)
                                //{
                                //    mail = new clsSendMail(cSmtp.SMTPServer, cSmtp.SMTPPort, cSmtp.SMTPUserName, clsCommonMethods.PasswordDecrypt(cSmtp.SMTPPassword), Convert.ToBoolean(cSmtp.EnableSsl));

                                //    From = cSmtp.SMTPUserName;
                                //    DisplayName = cSmtp.ClientName.Trim();
                                //    Cc = string.Concat(Cc, ",", cSmtp.SpocEmailID);

                                //    MailSignature = string.Concat("<b>", cSmtp.ClientName.Trim(), "</b><br /><b>E-mail id </b>: <a style='color:#df012a;' href='mailto:", cSmtp.SMTPUserName, "'>", cSmtp.SMTPUserName, "</a>");
                                //}
                                //else
                                //{
                                //    mail = new clsSendMail();
                                //    var signature = mail.GetCompanyMailSignature();

                                //    if (signature != null)
                                //    {
                                //        MailSignature = string.Concat("For Securitas India. <br /><br />");
                                //        MailSignature = string.Concat(MailSignature, "<b>", signature.CompanyName.Trim(), "</b><br /><b>Mobile: ", signature.MobileNo,
                                //            " | Direct Tel: ", signature.PhoneNo, " | Fax: ", signature.FaxNo, "</b><br /><b>E-mail id </b>: <a style='color:#df012a;' href='mailto:", signature.GeneralEmail, "'>", signature.GeneralEmail, "</a>");
                                //    }

                                //    string cmpSpocEmails = repoPQClient.GetCompanySPOCEmailIdFromPQClientMasterById(model.ClientRowID);
                                //    Cc = string.Concat(Cc, ",", cmpSpocEmails);

                                //    From = signature.GeneralEmail;
                                //    DisplayName = signature.CompanyName.Trim();
                                //}

                                //if (model.PersonalRowID > 0)
                                //{
                                //    var personalData = repoPQPersonal.GetCheckOrPersonalDetailsForSendMailById(model.CheckFamilyRowID, model.SubCheckRowID, model.EducationRowID);
                                //    //var loginDetail = repoCandidate.GetCandidateLoginDetailsForMailSendById(model.PersonalRowID);
                                //    if (personalData != null)
                                //    {
                                //        string body = string.Empty;
                                //        using (StreamReader reader = new StreamReader(Server.MapPath("~/Emailers/Company/fundpending.html")))
                                //        {
                                //            body = reader.ReadToEnd();
                                //        }
                                //        body = body.Replace("{FCandidateName}", personalData.CandidateName);
                                //        body = body.Replace("{FTAT}", Convert.ToString(personalData.InternalTAT));
                                //        body = body.Replace("{FCheckName}", personalData.SubCheckName);
                                //        body = body.Replace("{FPRemarks}", model.CloserViewModel.Remarks);

                                //        body = body.Replace("{MailSignature}", MailSignature);

                                //        string Subject = personalData.CandidateName + "  " + personalData.SubCheckName;
                                //        string To = personalData.SpocEmailID + "," + personalData.ClientEmailID;

                                //        bool flag = mail.SendMail(DisplayName, From, To, Cc, Subject, body);
                                //        if (flag)
                                //        {
                                //            //result = true;                                               
                                //        }
                                //        else
                                //        {
                                //            TempData["ErrorMsg"] = "Mail sending failed!";
                                //        }
                                //    }
                                //    else
                                //    {
                                //        TempData["ErrorMsg"] = "Candidate login details not found!";
                                //    }
                                //}
                                #endregion
                            }

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

                            if (model.EducationVerRowID > 0)
                            {
                                bool flag = false;
                                #region Update Education Information

                                if (model.CloserViewModel.ColorName.ToLower() == "green")
                                {
                                    //short rptQCMgrId = repoTeamDepartment.GetTeamMemberRptWriterManager("Manager-Rpt-QC");
                                    var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                    if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                    {
                                        repoEducationVer.UpdateEducationByTMQC(model, mgrData.TeamMemberRowID);
                                        flag = true;
                                        //Check All Checks are completed then put case status completed
                                        UpdateCaseCompleted(model.PersonalRowID);
                                    }
                                    else
                                    {
                                        TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                        return RedirectToAction("UpdateEducationInfoByTMQC", new { id = model.EducationRowID });
                                    }
                                }
                                else
                                {
                                    repoEducationVer.UpdateEducationByTMQC(model);
                                }

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By Verifier TMQC");
                                if (flag)
                                {
                                    if (model.CheckStatus == "Rejected-RWQC")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-TM", "Allocated to Report QC Team Member");
                                    }
                                    else
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "Allocated to Report QC Manager");
                                    }
                                }
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                            else
                            {
                                #region Add Education Information

                                repoEducationVer.UpdateEducationByTMQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationVerificationInfo", model.CheckStatus, "Approved By Verifier TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By Verifier TMQC");
                                #endregion

                                ModelState.Clear();
                                //TempData["SuccessMsg"] = "Record Added Successfully!";
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
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

            model.CloserViewModel = repoEducationVer.GetEducationVerCloserDetails(model.EducationVerRowID);
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
            EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(model.EducationRowID);

            BindUniversityStatusList();
            BindAffliatiatedfrom();
            GetDegreeList();
            GetCollegeDDL();
            RatingNumber();
            return View(model);
        }
        #endregion

        #region  Update Criminal Verification By Quality Check

        [SessionExpireFilterAttribute]
        public ActionResult UpdateCriminalInfoByTMQC(int id = 0)
        {
            UpdatePQCriminalVerViewModel model = new UpdatePQCriminalVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoCriminalVer.GetCriminalForTMQC(id);
                    if (model != null)
                    {
                        model.CloserViewModel = repoCriminalVer.GetCriminalVerCloserDetails(model.CriminalVerRowId);
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        CriminalVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoCriminalVer.GetPersonalDetailsForTM(model.CriminalRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No Detail found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Criminal Id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            CriminalOptionDropDown();
            BindCountry();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UpdateCriminalInfoByTMQC(UpdatePQCriminalVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CriminalRowID > 0 && model.ClientRowID > 0 && model.CheckFamilyRowID > 0 && model.SubCheckRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            repoCriminalVer.UpdateCriminalByTMQC(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Updated");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.CloserViewModel.ActionHistory);
                            #endregion

                            ModelState.Clear();
                            return RedirectToAction("DepartmentTeamMemberQCChecks");
                        }
                        else
                        {
                            if (model.CheckStatus == "Funds Pending")
                            {
                                SendAlertMassageForFundPending(model.ClientRowID, model.CriminalRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                            }

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

                            if (model.CriminalVerRowId > 0)
                            {
                                bool flag = false;
                                #region Update Criminal Information

                                if (model.CloserViewModel.ColorName.ToLower() == "green")
                                {
                                    //short rptQCMgrId = repoTeamDepartment.GetTeamMemberRptWriterManager("Manager-Rpt-QC");
                                    var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                    if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                    {
                                        repoCriminalVer.UpdateCriminalByTMQC(model, mgrData.TeamMemberRowID);
                                        flag = true;
                                        //Check All Checks are completed then put case status completed
                                        UpdateCaseCompleted(model.PersonalRowID);
                                    }
                                    else
                                    {
                                        TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                        return RedirectToAction("UpdateCriminalInfoByTMQC", new { id = model.CriminalRowID });
                                    }
                                }
                                else
                                {
                                    repoCriminalVer.UpdateCriminalByTMQC(model);
                                }

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By Verifier TMQC");
                                if (flag)
                                {
                                    if (model.CheckStatus == "Rejected-RWQC")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-TM", "Allocated to Report QC Team Member");
                                    }
                                    else
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "Allocated to Report QC Manager");
                                    }
                                }
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                            else
                            {
                                #region Add Criminal Information

                                repoCriminalVer.UpdateCriminalByTMQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalVerificationInfo", model.CheckStatus, "Criminal Verification TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated TMQC");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invlid Criminal Id and model!";
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

            model.CloserViewModel = repoCriminalVer.GetCriminalVerCloserDetails(model.CriminalRowID);
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
            CriminalVerList(model.CriminalRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoCriminalVer.GetPersonalDetailsForTM(model.CriminalRowID);
            TotalNumber();
            BindCountry();
            CriminalOptionDropDown();
            return View(model);
        }
        #endregion

        #region  Update National Identity Verification By Quality Check
        [SessionExpireFilterAttribute]
        public ActionResult UpdateNationalIdentityInfoByTMQC(int id = 0)
        {
            UpdatePQNationalIdentityVerViewModel model = new UpdatePQNationalIdentityVerViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoNationalIdentityVer.GetNationalIdentityForTMQC(id);
                    if (model != null)
                    {
                        model.CloserViewModel = repoNationalIdentityVer.GetNationalIdentityVerCloserDetails(model.NationalIdentityVerRowID);
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        NationalIdentityVerList(model.NationalIdentityRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoNationalIdentityVer.GetPersonalDetailsForTM(model.NationalIdentityRowID);
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "No details found!";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid NationalIdentity Id!";
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
        [HttpPost]
        public ActionResult UpdateNationalIdentityInfoByTMQC(UpdatePQNationalIdentityVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.NationalIdentityRowID > 0 && model.ClientRowID > 0 && model.CheckFamilyRowID > 0 && model.SubCheckRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            repoNationalIdentityVer.UpdateNationalIdentityByTMQC(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Updated");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.CloserViewModel.ActionHistory);
                            #endregion

                            ModelState.Clear();
                            return RedirectToAction("DepartmentTeamMemberQCChecks");
                        }
                        else
                        {
                            if (model.CheckStatus == "Funds Pending")
                            {
                                SendAlertMassageForFundPending(model.ClientRowID, model.NationalIdentityRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                            }

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

                            if (model.NationalIdentityVerRowID > 0)
                            {
                                bool flag = false;
                                #region Update NationalIdentity Information

                                if (model.CloserViewModel.ColorName.ToLower() == "green")
                                {
                                    //short rptQCMgrId = repoTeamDepartment.GetTeamMemberRptWriterManager("Manager-Rpt-QC");
                                    var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                    if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                    {
                                        repoNationalIdentityVer.UpdateNationalIdentityByTMQC(model, mgrData.TeamMemberRowID);
                                        flag = true;
                                        //Check All Checks are completed then put case status completed
                                        UpdateCaseCompleted(model.PersonalRowID);
                                    }
                                    else
                                    {
                                        TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                        return RedirectToAction("UpdateNationalIdentityInfoByTMQC", new { id = model.NationalIdentityRowID });
                                    }
                                }
                                else
                                {
                                    repoNationalIdentityVer.UpdateNationalIdentityByTMQC(model);
                                }

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated TMQC");
                                if (flag)
                                {
                                    if (model.CheckStatus == "Rejected-RWQC")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-TM", "Allocated to Report QC Team Member");
                                    }
                                    else
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "Allocated to Report QC Manager");
                                    }
                                }
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                            else
                            {
                                #region Add NationalIdentity Information

                                repoNationalIdentityVer.UpdateNationalIdentityByTMQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityVerificationInfo", model.CheckStatus, "Approved By Verifier TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated TMQC");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Invlid NationalIdentity Id and model!";
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
            model.CloserViewModel = repoNationalIdentityVer.GetNationalIdentityVerCloserDetails(model.NationalIdentityVerRowID);
            BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
            BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
            NationalIdentityVerList(model.NationalIdentityRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoNationalIdentityVer.GetPersonalDetailsForTM(model.NationalIdentityRowID);
            BindCountry();
            return View(model);
        }
        #endregion

        #region Update Reference Verification By Quality Check
        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UpdateReferenceInfoByTMQC(int id = 0)
        {
            UpdatePQReferenceVerViewModel model = new UpdatePQReferenceVerViewModel();
            try
            {
                if (id > 0)
                {
                    //Bind Textbox 
                    model = repoReferenceVer.GetReferenceInfoForTMQC(id);
                    if (model != null)
                    {
                        model.CloserViewModel = repoReferenceVer.GetReferenceVerCloserDetails(model.ReferenceCheckVerRowID);
                        BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        ReferenceVerList(model.ReferenceCheckRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoReferenceVer.GetPersonalDetailsForTM(model.ReferenceCheckRowID);
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid Reference id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            RatingNumber();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UpdateReferenceInfoByTMQC(UpdatePQReferenceVerViewModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (model != null && model.ReferenceCheckRowID > 0 && model.ClientRowID > 0 && model.CheckFamilyRowID > 0 && model.SubCheckRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            repoReferenceVer.UpdateReferenceByTMQC(model);

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Updated");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.CloserViewModel.ActionHistory);
                            #endregion

                            ModelState.Clear();
                            return RedirectToAction("DepartmentTeamMemberQCChecks");
                        }
                        else
                        {
                            if (model.CheckStatus == "Funds Pending")
                            {
                                SendAlertMassageForFundPending(model.ClientRowID, model.ReferenceCheckRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                            }

                            #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                            if (model.CheckStatus == "Insufficent")
                            {
                                var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                {
                                    //Insert PQCandidateInsuffLogin Table data for candidate login
                                    SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.ReferenceCheckRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                    SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.ReferenceCheckRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                }
                                else  // send mail Client/Spoc By the Company
                                {
                                    SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.ReferenceCheckRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                }
                            }
                            #endregion

                            if (model.ReferenceCheckVerRowID > 0)
                            {
                                bool flag = false;
                                #region Update Reference Information

                                if (model.CloserViewModel.ColorName.ToLower() == "green")
                                {
                                    //short rptQCMgrId = repoTeamDepartment.GetTeamMemberRptWriterManager("Manager-Rpt-QC");
                                    var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                    if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                    {
                                        repoReferenceVer.UpdateReferenceByTMQC(model, mgrData.TeamMemberRowID);
                                        flag = true;
                                        //Check All Checks are completed then put case status completed
                                        UpdateCaseCompleted(model.PersonalRowID);
                                    }
                                    else
                                    {
                                        TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                        return RedirectToAction("UpdateReferenceInfoByTMQC", new { id = model.ReferenceCheckRowID });
                                    }
                                }
                                else
                                {
                                    repoReferenceVer.UpdateReferenceByTMQC(model);
                                }

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By Verifier TMQC");
                                if (flag)
                                {
                                    if (model.CheckStatus == "Rejected-RWQC")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-TM", "Allocated to Report QC Team Member");
                                    }
                                    else
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "Allocated to Report QC Manager");
                                    }
                                }
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                            else
                            {
                                #region Add Reference Information

                                repoReferenceVer.UpdateReferenceByTMQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceVerificationInfo", model.CheckStatus, "Reference Verification TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated TMQC");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "invlid NationalIdentity id and model!";
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
            RatingNumber();

            return View(model);
        }
        #endregion

        #region Update Special Check Verification By Quality Check
        [SessionExpireFilterAttribute]
        [HttpGet]
        public ActionResult UpdateSpecialCheckInfoByTMQC(int id = 0)
        {
            UpdatePQSpecialCheckVerViewModel model = new UpdatePQSpecialCheckVerViewModel();
            try
            {
                if (id > 0)
                {
                    //Bind Textbox 
                    model = repoSplChkVer.GetSpecialCheckInfoForTMQC(id);
                    if (model != null)
                    {
                        // model.CloserViewModel = repoSplChkVer.GetReferenceVerCloserDetails(model.SpecialCheckRowID);
                        //BindDisposition(model.CheckFamilyRowID, model.ClientRowID);
                        BindDocumentList(model.PersonalRowID, model.SubCheckRowID);
                        SpecialCheckVerList(model.SpecialCheckRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoSplChkVer.GetPersonalDetailsForTM(model.SpecialCheckRowID);
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invlid SpecialCheck id!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            RatingNumber();
            return View(model);
        }

        [SessionExpireFilterAttribute]
        [HttpPost]
        public ActionResult UpdateSpecialCheckInfoByTMQC(UpdatePQSpecialCheckVerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SpecialCheckRowID > 0 && model.ClientRowID > 0 && model.CheckFamilyRowID > 0 && model.SubCheckRowID > 0)
                    {
                        if (model.CheckStatus == "Rejected")
                        {
                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateSpecialCheckInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Updated");
                            #endregion

                            #region Case/Check Action History Save
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.SC_AnyOtherComments);
                            #endregion

                            repoSplChkVer.UpdateSpecialCheckByTMQC(model);

                            ModelState.Clear();
                            return RedirectToAction("DepartmentTeamMemberQCChecks");
                        }
                        else
                        {
                            #region If check Insuff then send alert mail for Client/Spoc/Candidate By the Company
                            if (model.CheckStatus == "Insufficent")
                            {
                                var data = repoPQClient.GetClientContractConditions(model.ClientRowID);
                                var CandidateData = repoPQPersonal.GetPQPersonalInfoForSession(model.PersonalRowID);
                                if (data.CandidateContact == 1 && !string.IsNullOrEmpty(CandidateData.EmailID) && IsValidEmail(CandidateData.EmailID)) // send mail Client/Spoc/Candidate By the Company
                                {
                                    //Insert PQCandidateInsuffLogin Table data for candidate login
                                    SendAlertMassageForInsuffClearationForCandidate(model.ClientRowID, model.SpecialCheckRowID, model.CheckFamilyRowID, model.SubCheckRowID, model.PersonalRowID, CandidateData.EmailID);
                                    SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.SpecialCheckRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                }
                                else  // send mail Client/Spoc By the Company
                                {
                                    SendAlertMassageForInsuffClearationForClientSpoc(model.ClientRowID, model.SpecialCheckRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                                }
                            }
                            #endregion
                            if (model.SpecialCheckVerRowID > 0)
                            {
                                bool flag = false;
                                #region Update Special Check Information

                                //short rptQCMgrId = repoTeamDepartment.GetTeamMemberRptWriterManager("Manager-Rpt-QC");
                                var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                {
                                    repoSplChkVer.UpdateSpecialCheckByTMQC(model, mgrData.TeamMemberRowID);
                                    flag = true;
                                    //Check All Checks are completed then put case status completed
                                    UpdateCaseCompleted(model.PersonalRowID);
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                    return RedirectToAction("UpdateSpecialCheckInfoByTMQC", new { id = model.SpecialCheckRowID });
                                }
                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalInfoByTMQC", model.CheckStatus, "Approved By Verifier TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Approved By Verifier TMQC");
                                if (flag)
                                {
                                    if (model.CheckStatus == "Rejected-RWQC")
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-TM", "Allocated to Report QC Team Member");
                                    }
                                    else
                                    {
                                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Allocated-Mgr", "Allocated to Report QC Manager");
                                    }
                                }
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("DepartmentTeamMemberQCChecks");
                                #endregion
                            }
                            else
                            {
                                #region Add Special Check Information
                                repoSplChkVer.UpdateSpecialCheckByTMQC(model);

                                #region Save LogTransaction Details
                                clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateSpecialCheckVerificationInfo", model.CheckStatus, "SpecialCheck Verification TMQC", "Update");
                                #endregion

                                #region Case/Check Action History Save
                                clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, "Verification information Updated TMQC");
                                #endregion

                                ModelState.Clear();
                                return RedirectToAction("UpdateSpecialCheckInfoByTMQC", new { id = model.SpecialCheckRowID });
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "invlid Special Check id and model!";
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
            SpecialCheckVerList(model.SpecialCheckRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
            ViewBag.PersonalBind = repoSplChkVer.GetPersonalDetailsForTM(model.SpecialCheckRowID);
            return View(model);
        }

        #endregion

        #endregion

        #region ******** Manage RWQC Approval Checks For Department TL ********

        [SessionExpireFilterAttribute]
        public ActionResult ManageRWQCApprovalChecksForDepartmentManager(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
                model = repoVerificationInfo.GetRWApprovalCheckListForDepartmentManager(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, teamMemberId);

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
        public ActionResult ManageRWQCApprovalChecksForDepartmentTL(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();

            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
                model = repoVerificationInfo.GetRWApprovalCheckListForDepartmentTL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, teamMemberId);

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            BindClientList();
            return View(model);

        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateAddressVerInfoByTeamLeader(int id)
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
        public ActionResult UpdateAddressVerInfoByTeamLeader(ViewAddressViewModel model)
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
                            string DesignationName = Convert.ToString(Session["Designation"]);

                            if (model.CheckStatus != "Rejected")
                            {
                                var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                {
                                    repoVerificationInfo.UpdateAddressCheckRejectionByMgrOrTL(model, DesignationName);
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                }
                            }
                            else
                            {
                                repoVerificationInfo.UpdateAddressCheckRejectionByMgrOrTL(model, DesignationName);
                            }

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateAddressVerInfoByTeamLeader", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            if (Session["Designation"] != null && Session["Designation"].ToString() == "Team Leader-Add")
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentTL", "Verification");
                            }
                            else
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentManager", "Verification");
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
        public ActionResult UpdateEmploymentVerInfoByTeamLeader(int id)
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
        public ActionResult UpdateEmploymentVerInfoByTeamLeader(ViewEmploymentViewModel model)
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
                            string DesignationName = Convert.ToString(Session["Designation"]);
                            if (model.CheckStatus != "Rejected")
                            {
                                var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                {
                                    repoVerificationInfo.UpdateEmploymentCheckRejectionByMgrOrTL(model, DesignationName, mgrData.TeamMemberRowID);
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                }
                            }
                            else
                            {
                                repoVerificationInfo.UpdateEmploymentCheckRejectionByMgrOrTL(model, DesignationName);
                            }

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEmploymentVerInfoByTeamLeader", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            if (Session["Designation"] != null && Session["Designation"].ToString() == "Team Leader-Emp")
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentTL", "Verification");
                            }
                            else
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentManager", "Verification");
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

            model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult UpdateEducationVerInfoByTeamLeader(int id)
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
                        ViewBag.VerifyInfo = verInfo;
                        verInfo.CloserViewModel = repoEducationVer.GetEducationVerCloserDetails(verInfo.EducationVerRowID);
                        EducationVerList(model.EducationRowID, model.ClientRowID, model.CheckFamilyRowID, model.SubCheckRowID);
                        model.UploadedDocInfo = repoPQVerifiedUploadDoc.GetCheckUploadDocList(model.PersonalRowID, model.SubCheckRowID);
                        ViewBag.PersonalBind = repoEducationVer.GetPersonalDetailsForTM(model.EducationRowID);
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
        public ActionResult UpdateEducationVerInfoByTeamLeader(ViewEducationViewModel model)
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
                            string DesignationName = Convert.ToString(Session["Designation"]);
                            if (model.CheckStatus != "Rejected")
                            {
                                var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                {
                                    repoVerificationInfo.UpdateEducationCheckRejectionByMgrOrTL(model, DesignationName, mgrData.TeamMemberRowID);
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                }
                            }
                            else
                            {
                                repoVerificationInfo.UpdateEducationCheckRejectionByMgrOrTL(model, DesignationName);
                            }

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateEducationVerInfoByTeamLeader", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            if (Session["Designation"] != null && Session["Designation"].ToString() == "Team Leader-Edu")
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentTL", "Verification");
                            }
                            else
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentManager", "Verification");
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
        public ActionResult UpdateReferenceVerInfoByTeamLeader(int id)
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
        public ActionResult UpdateReferenceVerInfoByTeamLeader(ViewReferenceViewModel model)
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
                            string DesignationName = Convert.ToString(Session["Designation"]);
                            if (model.CheckStatus != "Rejected")
                            {
                                var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                {
                                    repoVerificationInfo.UpdateReferenceCheckRejectionByMgrOrTL(model, DesignationName, mgrData.TeamMemberRowID);
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                }
                            }
                            else
                            {
                                repoVerificationInfo.UpdateReferenceCheckRejectionByMgrOrTL(model, DesignationName);
                            }

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateReferenceVerInfoByTeamLeader", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            if (Session["Designation"] != null && Session["Designation"].ToString() == "Team Leader-Ref")
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentTL", "Verification");
                            }
                            else
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentManager", "Verification");
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
        public ActionResult UpdateCriminalVerInfoByTeamLeader(int id)
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
        public ActionResult UpdateCriminalVerInfoByTeamLeader(ViewCriminalViewModel model)
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
                            string DesignationName = Convert.ToString(Session["Designation"]);
                            if (model.CheckStatus != "Rejected")
                            {
                                var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                {
                                    repoVerificationInfo.UpdateCriminalCheckRejectionByMgrOrTL(model, DesignationName, mgrData.TeamMemberRowID);
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                }
                            }
                            else
                            {
                                repoVerificationInfo.UpdateCriminalCheckRejectionByMgrOrTL(model, DesignationName);
                            }

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateCriminalVerInfoByTeamLeader", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            if (Session["Designation"] != null && Session["Designation"].ToString() == "Team Leader-Cri")
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentTL", "Verification");
                            }
                            else
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentManager", "Verification");
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
        public ActionResult UpdateNationalIdentityVerInfoByTeamLeader(int id)
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
        public ActionResult UpdateNationalIdentityVerInfoByTeamLeader(ViewNationalIdentityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.NationalIdentityRowID > 0)
                    {
                        #region Update NationalIdentity Information
                        if (!string.IsNullOrEmpty(model.Remarks))
                        {
                            string DesignationName = Convert.ToString(Session["Designation"]);
                            if (model.CheckStatus != "Rejected")
                            {
                                var mgrData = repoPQClientTMember.GetDepManagerClientToTeam(model.ClientRowID, "Manager-Rpt-QC").FirstOrDefault();
                                if (mgrData != null && mgrData.TeamMemberRowID > 0)
                                {
                                    repoVerificationInfo.UpdateNationalIdentityCheckRejectionByMgrOrTL(model, DesignationName, mgrData.TeamMemberRowID);
                                }
                                else
                                {
                                    TempData["ErrorMsg"] = "Report QC Manager Not Found!";
                                }
                            }
                            else
                            {
                                repoVerificationInfo.UpdateNationalIdentityCheckRejectionByMgrOrTL(model, DesignationName);
                            }

                            #region Save LogTransaction Details
                            clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "UpdateNationalIdentityVerInfoByTeamLeader", model.CheckStatus, "", "Update");
                            #endregion

                            #region Case/Check Action History Save 
                            clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, model.CheckStatus, model.Remarks);
                            #endregion

                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            if (Session["Designation"] != null && Session["Designation"].ToString() == "Team Leader-Ide")
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentTL", "Verification");
                            }
                            else
                            {
                                return RedirectToAction("ManageRWQCApprovalChecksForDepartmentManager", "Verification");
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

        #endregion

        #region NonAction/Json 

        private void UpdateCaseCompleted(int PersonalId)
        {
            try
            {
                bool res = repoPQPersonal.UpdateCaseCompletedByPersonalId(PersonalId);
                if (res)
                {
                    #region Case/Check Action History Save 
                    clsCommonMethods.AddCaseActionHistory(PersonalId, "Completed", "Case Completed By TeamMember QC");
                    #endregion
                }
            }
            catch (Exception)
            {
                throw;
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

        //Get ActionHistory In Address Verification
        //[NonAction]
        //void BindCheckActionHistories(int PersonalRowID = 0, short subCheckId = 0)
        //{
        //    try
        //    {
        //        ViewBag.CheckActionHistories = repoDDL.GetCheckActionHistory(PersonalRowID, subCheckId);
        //    }
        //    catch (Exception Ex)
        //    {
        //        ViewBag.ErrorMsg = Ex.Message;
        //        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
        //    }
        //}

        //Get DocumentList In Address Verification 
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

        #region Send Mail To Client Or Spoc

        bool SendAlertMassageForFundPending(short ClientRowID, int CheckRowID, short CheckFamilyRowID, short SubCheckRowID)
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
            //string cmpSpocEmails = repoPQClient.GetCompanySPOCEmailIdFromPQClientMasterById(ClientRowID);
            //Cc = cmpSpocEmails;

            From = signature.GeneralEmail;
            DisplayName = signature.CompanyName.Trim();

            var personalData = repoPQPersonal.GetCheckOrPersonalDetailsForSendMailById(CheckFamilyRowID, SubCheckRowID, CheckRowID);
            if (personalData != null)
            {
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(Server.MapPath("~/Emailers/Company/fundpending.html")))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{FCandidateName}", personalData.CandidateName);
                body = body.Replace("{FTAT}", Convert.ToString(personalData.InternalTAT));
                body = body.Replace("{FCheckName}", personalData.SubCheckName);
                body = body.Replace("{FPRemarks}", personalData.Remarks);

                body = body.Replace("{MailSignature}", MailSignature);

                string Subject = "Funds Pending " + personalData.CandidateName + "  " + personalData.SubCheckName;
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
                TempData["ErrorMsg"] = "Candidate Check details not found!";
            }
            return result;
        }
        #endregion

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

        void BindStateList()
        {
            short CountryRowID = 106;
            try
            {
                ViewBag.StateList = repoDDL.GetStatesByCountryIdForDDL(CountryRowID);
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

        public JsonResult GetSeverityColor(short ClientRowId = 0, string Dispositions = "")
        {
            try
            {

                if (ClientRowId > 0 && !String.IsNullOrEmpty(Dispositions))
                {

                    PQAddressVerGetColorNameViewModel model = new PQAddressVerGetColorNameViewModel();
                    try
                    {
                        model = repoAddressVer.PQAddressVerGetColorName(ClientRowId, Dispositions);
                    }
                    catch (Exception Ex)
                    {

                        ViewBag.ErrorMsg = Ex.Message;
                        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                    }
                    return Json(model, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetColorBySeverity(short ClientRowId = 0, byte SeverityRowId = 0)
        {
            try
            {
                if (SeverityRowId > 0)
                {
                    string ColorName = "0";
                    try
                    {
                        ColorName = repoAddressVer.VerGetColorName(ClientRowId, SeverityRowId);
                    }
                    catch (Exception Ex)
                    {
                        ViewBag.ErrorMsg = Ex.Message;
                        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                    }
                    return Json(ColorName, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult GetTLMemberForAllocate(short id = 0)
        {
            try
            {

                if (id > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Manager-Add")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Leader-Add");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Manager-Emp")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Leader-Emp");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Manager-Edu")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Leader-Edu");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Manager-Cri")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Leader-Cri");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Manager-Ref")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Leader-Ref");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Manager-Ide")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Leader-Ide");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }

                    return Json(null, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetTLMemberForAllocate()
        {
            try
            {
                short depMgrID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depMgrID > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Manager-Add")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-Add");
                    }
                    else if (Designation == "Manager-Emp")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-Emp");
                    }
                    else if (Designation == "Manager-Edu")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-Edu");
                    }
                    else if (Designation == "Manager-Cri")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-Cri");
                    }
                    else if (Designation == "Manager-Ref")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-Ref");
                    }
                    else if (Designation == "Manager-Ide")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-Ide");
                    }
                    else if (Designation == "Manager-SPL")
                    {
                        ViewBag.depTeamLeader = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Leader-SPL");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetTMMemberForAllocate(short id = 0)
        {
            try
            {

                if (id > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Team Leader-Add")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Add");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Emp")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Emp");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Edu")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Edu");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Cri")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Cri");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Ref")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Ref");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Ide")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Ide");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }

                    return Json(null, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetTMQCMemberForAllocate(short id = 0)
        {
            try
            {

                if (id > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Administrator")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Add-QC");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Add")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Add-QC");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Emp")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Emp-QC");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Edu")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Edu-QC");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Cri")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Cri-QC");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Ref")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Ref-QC");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }
                    else if (Designation == "Team Leader-Ide")
                    {
                        var DETM = repoPQClientTMember.GetRepoClientToTeam(id, "Team Member-Ide-QC");
                        return Json(new SelectList(DETM.ToArray(), "TeamMemberRowID", "TeamMemberName"), JsonRequestBehavior.AllowGet);
                    }

                    return Json(null, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(0, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetTMMemberForAllocate()
        {
            try
            {
                short depMgrID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depMgrID > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Team Leader-Add")
                    {
                        ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Member-Add");
                    }
                    else if (Designation == "Team Leader-Emp")
                    {
                        ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Member-Emp");
                    }
                    else if (Designation == "Team Leader-Edu")
                    {
                        ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Member-Edu");
                    }
                    else if (Designation == "Team Leader-Cri")
                    {
                        ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Member-Cri");
                    }
                    else if (Designation == "Team Leader-Ref")
                    {
                        ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Member-Ref");
                    }
                    else if (Designation == "Team Leader-Ide")
                    {
                        ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Member-Ide");
                    }
                    else if (Designation == "Team Leader-SPL")
                    {
                        ViewBag.depTM = repoPQClientTMember.GetRepoClientToTeam(depMgrID, "Team Member-SPL");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetTMQCMemberForAllocate()
        {
            try
            {
                short depTMQCID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depTMQCID > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Administrator")
                    {
                        ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-Add-QC");
                    }
                    else if (Designation == "Team Leader-Add")
                    {
                        ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-Add-QC");
                    }
                    else if (Designation == "Team Leader-Emp")
                    {
                        ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-Emp-QC");
                    }
                    else if (Designation == "Team Leader-Edu")
                    {
                        ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-Edu-QC");
                    }
                    else if (Designation == "Team Leader-Cri")
                    {
                        ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-Cri-QC");
                    }
                    else if (Designation == "Team Leader-Ref")
                    {
                        ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-Ref-QC");
                    }
                    else if (Designation == "Team Leader-Ide")
                    {
                        ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-Ide-QC");
                    }
                    else if (Designation == "Team Leader-SPL")
                    {
                        ViewBag.depTMQC = repoPQClientTMember.GetRepoClientToTeam(depTMQCID, "Team Member-SPL-QC");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetPTRMgrForAllocate()
        {
            try
            {
                short depTMID = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (depTMID > 0)
                {
                    string Designation = Session["Designation"].ToString();

                    if (Designation == "Team Member-Add")
                    {
                        ViewBag.PTRManagerList = repoPQClientTMember.GetRepoClientToTeam(depTMID, "Allocate-PTR");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //short GetCheckFamilyIdByDesignationName(string designation ="")
        //{
        //    short id = 0;
        //    if (designation== "Manager-Add")
        //    {
        //        id = 2;
        //    }
        //    if (designation == "Manager-Emp")
        //    {
        //        id = 12;
        //    }
        //    if (designation == "Manager-Edu")
        //    {
        //        id = 11;
        //    }
        //    if (designation == "Manager-Cri")
        //    {
        //        id = 5;
        //    }
        //    if (designation == "Manager-OC")
        //    {
        //        id = 0;
        //    }

        //    return id;
        //}

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
        void BindStates()
        {
            try
            {
                ViewBag.States = repoDDL.GetStatesByArressStatesIdForDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindPartneres()
        {
            try
            {
                ViewBag.Partner = repoDDL.GetPartnerByArressPartnerIdForDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindCities()
        {
            try
            {
                ViewBag.Cities = repoDDL.GetCityByArressStatesIdForDDL();
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
        void BindColorCode()
        {
            try
            {
                ViewBag.ColorCode = repoDDL.GetColorDDL();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void BindRelationship()
        {
            try
            {
                IEnumerable<SelectListItem> RelationshipList = new List<SelectListItem> {
            new SelectListItem { Text = "Parent", Value = "Parent" },
            new SelectListItem { Text = "Father", Value = "Father" },
            new SelectListItem { Text = "Mother ", Value = "Mother" },
            new SelectListItem { Text = "Child", Value = "Child" },
            new SelectListItem { Text = "Spouse", Value = "Spouse" },
            new SelectListItem { Text = "Sibling", Value = "Sibling" },
            new SelectListItem { Text = "Grandparents", Value = "Grandparents" },
            new SelectListItem { Text = "Grandchild", Value = "Grandchild" },
            new SelectListItem { Text = "Parent's Sibling", Value = "Parent's Sibling" },
            };
                ViewBag.RelationshipList = RelationshipList;
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [NonAction]
        void TotalNumber()
        {
            try
            {
                IEnumerable<SelectListItem> Number = new List<SelectListItem>
            {
                new SelectListItem { Text = "1" , Value = "1" },
                new SelectListItem { Text = "2" , Value = "2" },
                new SelectListItem { Text = "3" , Value = "3" },
                new SelectListItem { Text = "4" , Value = "4" },
                new SelectListItem { Text = "5" , Value = "5" },
                new SelectListItem { Text = "6" , Value = "6" },
                new SelectListItem { Text = "7" , Value = "7" },
                new SelectListItem { Text = "8" , Value = "8" },
                new SelectListItem { Text = "9" , Value = "9" },
                new SelectListItem { Text = "10", Value = "10" },
                new SelectListItem { Text = "11", Value = "11" },
                new SelectListItem { Text = "12", Value = "12" },
                new SelectListItem { Text = "13", Value = "13" },
                new SelectListItem { Text = "14", Value = "14" },
                new SelectListItem { Text = "15", Value = "15" },
                new SelectListItem { Text = "16", Value = "16" },
                new SelectListItem { Text = "17", Value = "17" },
                new SelectListItem { Text = "18", Value = "18" },
                new SelectListItem { Text = "19", Value = "19" },
                new SelectListItem { Text = "20", Value = "20" },
            };
                ViewBag.TotalNumberes = Number;
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

        //[NonAction]
        //public void GetDegreeList(int EV_Degree_Name)
        //{
        //    try
        //    {
        //        if (EV_Degree_Name > 0)
        //        {                    
        //            ViewBag.DegreeList = repoDDL.GetDegreeDDLForVerifier(EV_Degree_Name);
        //        }
        //        else
        //        {
        //            ViewBag.DegreeList = repoDDL.GetDegreeDDL();
        //        }

        //    }
        //    catch (Exception Ex)
        //    {
        //        ViewBag.ErrorMsg = Ex.Message;
        //        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
        //    }
        //}

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

        //[NonAction]
        //public void GetCollegeDDL(int CollegeRowID)
        //{
        //    try
        //    {
        //        if (CollegeRowID>0)
        //        {                 
        //            ViewBag.CollegeList = repoDDL.GetCollegeDDLForVerification(CollegeRowID);
        //        }
        //        else
        //        {
        //            ViewBag.CollegeList = repoDDL.GetCollegeDDL();
        //        }

        //    }
        //    catch (Exception Ex)
        //    {
        //        ViewBag.ErrorMsg = Ex.Message;
        //        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
        //    }
        //}

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
        #endregion

        #region ********** Export Excel To Address **********
        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportAddressMge(short ClientRowID = 0, string CheckStatus = "", byte AllocatedToTL = 0, byte tatdays = 0, string DCheckStatus = "", string CaseStatus = "", string ReAllocation = "")
        {
            short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
            string Designation = Convert.ToString(Session["Designation"]);
            try
            {

                #region Address Excel Export
                if (Designation == "Manager-Add")
                {
                    var data = repoVerificationInfo.GetExportCandidateAddressListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);

                    if (CheckStatus == "Allocated-Mgr")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "AddressMge");
                    }
                    else
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new ExportVerificationAddMgrViewModel
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
                            Partner = item.Partner,
                            Location = item.Location,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "AddressMge");
                    }

                }
                if (Designation == "Team Leader-Add" || Designation == "Team Member-Add-QC")
                {
                    var data = repoVerificationInfo.GetExportCandidateAddressListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationToTM" || CheckStatus == "ReAllocation")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "AddressMge");
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
                            Partner = item.Partner,
                            Location = item.Location,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data2, "AddressTLOrQC");
                    }
                }
                if (Designation == "Team Member-Add")
                {
                    var data = repoVerificationInfo.GetExportCandidateAddressListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "NonInitiated")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "AddressTm");
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
                        ExportToExcel(data3, "AddressTM");
                    }
                }
                #endregion

                #region Criminal Excel Export

                if (Designation == "Manager-Cri")
                {
                    var data = repoVerificationInfo.GetExportCandidateCriminalListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "Allocated-Mgr")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalMge");
                    }
                    else
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new ExportVerificationAddMgrViewModel
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
                            Partner = item.Partner,
                            Location = item.Location,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalMge");
                    }
                }
                if (Designation == "Team Leader-Cri" || Designation == "Team Member-Cri-QC")
                {
                    var data = repoVerificationInfo.GetExportCandidateCriminalListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus, ReAllocation);
                    if (CheckStatus == "AllocationToTM" || CheckStatus == "ReAllocation")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalTLOrQC");
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
                            Partner = item.Partner,
                            Location = item.Location,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data2, "CriminalTLOrQC");
                    }
                }
                if (Designation == "Team Member-Cri")
                {
                    var data = repoVerificationInfo.GetExportCandidateCriminalListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
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
                    ExportToExcel(data3, "CriminalTM");
                }
                #endregion

                #region Education Excel Export

                if (Designation == "Manager-Edu")
                {
                    var data = repoVerificationInfo.GetExportCandidateEducationListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "Allocated-Mgr")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EducationMge");
                    }
                    else
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new ExportVerificationEduMgrViewModel
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
                        ExportToExcel(data1, "EducationMge");
                    }
                }
                if (Designation == "Team Leader-Edu" || Designation == "Team Member-Edu-QC")
                {
                    var data = repoVerificationInfo.GetExportCandidateEducationListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationToTM" || CheckStatus == "ReAllocation")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "CriminalTLOrQC");
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
                if (Designation == "Team Member-Edu")
                {
                    var data = repoVerificationInfo.GetExportCandidateEducationListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
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
                    ExportToExcel(data3, "CriminalTM");
                }
                #endregion

                #region Employee Excel Export

                if (Designation == "Manager-Emp")
                {
                    var data = repoVerificationInfo.GetExportCandidateEmployeeListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "Allocated-Mgr")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EmployeeMge");
                    }
                    else
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new ExportVerificationEduMgrViewModel
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
                        ExportToExcel(data1, "EmployeeMge");
                    }
                }
                if (Designation == "Team Leader-Emp" || Designation == "Team Member-Emp-QC")
                {
                    var data = repoVerificationInfo.GetExportCandidateEmployeeListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationToTM" || CheckStatus == "ReAllocation")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "EmployeeMge");
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
                        ExportToExcel(data2, "EmployeeTLOrQC");
                    }
                }
                if (Designation == "Team Member-Emp")
                {
                    var data = repoVerificationInfo.GetExportCandidateEmployeeListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
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
                    ExportToExcel(data3, "EmployeeTM");
                }
                #endregion

                #region Reference Excel Export

                if (Designation == "Manager-Ref")
                {
                    var data = repoVerificationInfo.GetExportCandidateReferenceListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "Allocated-Mgr")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "ReferenceMge");
                    }
                    else
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new ExportVerificationEduMgrViewModel
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
                        ExportToExcel(data1, "ReferenceMge");
                    }
                }
                if (Designation == "Team Leader-Ref" || Designation == "Team Member-Ref-QC")
                {
                    var data = repoVerificationInfo.GetExportCandidateReferenceListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationToTM" || CheckStatus == "ReAllocation")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "ReferenceTLOrQC");
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
                        ExportToExcel(data2, "ReferenceTLOrQC");
                    }
                }
                if (Designation == "Team Member-Ref")
                {
                    var data = repoVerificationInfo.GetExportCandidateReferenceListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
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
                    ExportToExcel(data3, "ReferenceTM");
                }
                #endregion

                #region Reference Excel Export

                if (Designation == "Manager-Ide")
                {
                    var data = repoVerificationInfo.GetExportCandidateNationalIdentitieListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "Allocated-Mgr")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "NationalIdentitieMge");
                    }
                    else
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new ExportVerificationEduMgrViewModel
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
                        ExportToExcel(data1, "NationalIdentitieMge");
                    }
                }
                if (Designation == "Team Leader-Ide" || Designation == "Team Member-Ide-QC")
                {
                    var data = repoVerificationInfo.GetExportCandidateNationalIdentitieListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
                    if (CheckStatus == "AllocationToTM" || CheckStatus == "ReAllocation")
                    {
                        var data1 = data.PQVerificationInfo.Select(item => new AllocationonAddMgrViewModel
                        {
                            VerificationRowID = item.VerificationRowID,
                            ClientName = item.ClientName,
                            SecuritasID = item.CompanyRefNo,
                            CandidateName = item.PersonalName,
                            CheckName = item.SubCheckName,
                            TAT = item.OutDate,
                            InternalTAT = item.InternalOutDate,
                            UniqueComponentId = item.UniqueComponentID,
                            CheckStatus = item.CheckStatus
                        }).ToList();
                        ExportToExcel(data1, "NationalIdentitieTLOrQC");
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
                        ExportToExcel(data2, "NationalIdentitieTLOrQC");
                    }
                }
                if (Designation == "Team Member-Ide")
                {
                    var data = repoVerificationInfo.GetExportCandidateNationalIdentitieListByDepartmentManager(Designation, teamMemerRowId, ClientRowID, CheckStatus, AllocatedToTL, tatdays, DCheckStatus, CaseStatus);
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
                    ExportToExcel(data3, "NationalIdentitieTM");
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

    }
}
