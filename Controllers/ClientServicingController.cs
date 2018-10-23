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
using ViewModels.ClientViewModel;
using ViewModels.ProvidedInfoViewModel;
using ViewModels.VerificationViewModel;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    public class ClientServicingController : Controller
    {
        #region ******  Repository Objects ******

        IClientServicingRepository repoDashboard;
        IDropDownMasterRepository repoDDL;
        IPQVerifiedUploadDocRepository repoPQVerifiedUploadDoc;
        IVerificationInfoRepository repoVerificationInfo;
        IPQPersonalRepository repoPQPersonal;
        IAddressInfoRepository repoAddressInfo;
        IEmploymentInfoRepository repoEmploymentInfo;
        IEducationInfoRepository repoEducationInfo;
        ICriminalInfoRepository repoCriminalInfo;
        INationalIdentityInfoRepository repoNationalIdentInfo;
        IReferenceInfoRepository repoReferenceInfo;
        ISubCheckFamilyRepository repoSubCheck;
        ISpecialCheckInfoRepository repoSplCheckInfo;

        public ClientServicingController(
           IClientServicingRepository _repoDashboard
            , IDropDownMasterRepository _repoDDL
            , IPQVerifiedUploadDocRepository _repoPQVerifiedUploadDoc
            , IVerificationInfoRepository _repoVerificationInfo
            , IPQPersonalRepository _repoPQPersonal
            , IAddressInfoRepository _repoAddressInfo
            , IEmploymentInfoRepository _repoEmploymentInfo
            , IEducationInfoRepository _repoEducationInfo
            , ICriminalInfoRepository _repoCriminalInfo
            , INationalIdentityInfoRepository _repoNationalIdentInfo
            , IReferenceInfoRepository _repoReferenceInfo
            , ISubCheckFamilyRepository _repoSubCheck
            , ISpecialCheckInfoRepository _repoSplCheckInfo
            )
        {
            repoDashboard = _repoDashboard;
            repoDDL = _repoDDL;
            repoPQVerifiedUploadDoc = _repoPQVerifiedUploadDoc;
            repoVerificationInfo = _repoVerificationInfo;
            repoPQPersonal = _repoPQPersonal;
            repoAddressInfo = _repoAddressInfo;
            repoEmploymentInfo = _repoEmploymentInfo;
            repoEducationInfo = _repoEducationInfo;
            repoCriminalInfo = _repoCriminalInfo;
            repoNationalIdentInfo = _repoNationalIdentInfo;
            repoReferenceInfo = _repoReferenceInfo;
            repoSubCheck = _repoSubCheck;
            repoSplCheckInfo = _repoSplCheckInfo;
        }

        #endregion

        // GET: ClientServicing
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Designation = Session["Designation"].ToString();
                string SpocEmail = Session["TeamMemberEmail"].ToString();
                BindClientListByLogInName(SpocEmail);
                //Department Manager
                //bool flagMgr = false;
                if (Designation == "Manager-CS")
                {
                    //flagMgr = true;
                    ViewBag.Dashboard = "Client Servicing Manager Dashboard!";
                }

                //if (flagMgr)
                //{
                //    ViewBag.ManagerDashboard = repoDashboard.GetManagerClientServicingDashBoardInfo(teamMemerRowId, "Manager-Add");
                //}
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
        public ActionResult RefreshDashboardDetails(short ClientRowID = 0)
        {
            try
            {
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                string Department = Session["Department"].ToString();
                string SpocEmail = Session["TeamMemberEmail"].ToString();
                //BindClientListByLogInName(SpocEmail);
                //Department Manager
                bool flagMgr = false;
                if (Department == "Client Servicing")
                {
                    flagMgr = true;
                    ViewBag.Dashboard = "Client Servicing Dashboard!";
                }

                if (flagMgr)
                {
                    ViewBag.ClientID = ClientRowID;
                    ViewBag.ManagerDashboard = repoDashboard.GetManagerClientServicingDashBoardInfo(teamMemerRowId, ClientRowID, SpocEmail);
                }
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return PartialView("_ClientServicingDashboard");
        }

        [SessionExpireFilterAttribute]
        public ActionResult ClientServicingDashboardInfo(int page = 1, string sort = "", string sortDir = "desc", string Search = "", short ClientRowID = 0, string CaseStatus = "", string RecievingDate = "", string CompletedDate = "", byte tatdays = 0)
        {
            DashboardClientCandidateListViewModel model = new DashboardClientCandidateListViewModel();
            try
            {
                int pageSize = 20;
                string SpocEmail = Session["TeamMemberEmail"].ToString();
                short teamMemerRowId = Convert.ToInt16(Session["TeamMemberRowID"]);
                if (!string.IsNullOrEmpty(CaseStatus) && (CaseStatus == "Pendingwithcandidate" || CaseStatus == "PendingwithHR"))
                {
                    model = repoDashboard.GetClientServicingDashBoardTempPQPersonalInfo(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CaseStatus, ClientRowID, RecievingDate, SpocEmail);
                }
                else
                {
                    model = repoDashboard.GetClientServicingDashBoardInfo(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CaseStatus, ClientRowID, RecievingDate, CompletedDate, tatdays, SpocEmail);
                }

                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
                BindClientListByLogInName(SpocEmail);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View(model);
        }

        #region ******** Manage FundPending By Spoc ********

        [SessionExpireFilterAttribute]
        public ActionResult ManageFundPendingChecksForSpoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", short ClientRowID = 0)
        {
            VerificationInfoListPagedModel model = new VerificationInfoListPagedModel();
            string SpocEmail = Session["TeamMemberEmail"].ToString();
            try
            {
                int pageSize = 20;
                short teamMemberId = Convert.ToInt16(Session["TeamMemberRowID"]);
                model = repoPQVerifiedUploadDoc.GetFundPendingCheckListForSpoc(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, SpocEmail, ClientRowID);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            BindClientListByLogInName(SpocEmail);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult FundPendingApproveBySpoc(int PersonalId = 0, int VerId = 0, short chkFmlyId = 0, short SubchkFmlyId = 0)
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
        public ActionResult FundPendingApproveBySpoc(FundPendingApprovalViewModel model)
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

        #region ****** Insufficiency Management By Client Servicing (Spoc) ******

        [SessionExpireFilterAttribute]
        public ActionResult InsuffMgmtForClientServicing()
        {
            CreateNavigationforInsuffCaseForClientServicing();
            return View();
        }

        [SessionExpireFilterAttribute]
        public ActionResult InsufficiencyCheckClearByCSSpoc(int id = 0, short ClientRowId = 0, short ChFamilRowId = 0, short subCheckId = 0, int PersonalRowID = 0, string CompanyRefNo = "",string InfRemarks = "")
        {
            InsuffCheckClearViewModel model = new InsuffCheckClearViewModel();
            if (model != null)
            {
                model.CheckRowID = id;
                model.ClientRowID = ClientRowId;
                model.ChFamilRowId = ChFamilRowId;
                model.PersonalRowID = PersonalRowID;
                model.SubCheckRowID = subCheckId;
                model.SecuritasID = CompanyRefNo;
                model.INFReason = InfRemarks;
                model.SubCheckName = repoSubCheck.GetSubCheckFamilyForUpdateById(subCheckId).SubCheckName;
            }
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult InsufficiencyCheckClearByCSSpoc(InsuffCheckClearViewModel model, string UploadHid, IEnumerable<HttpPostedFileBase> UploadDoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PersonalRowID > 0 && ((!string.IsNullOrEmpty(UploadHid) && UploadDoc != null && UploadDoc.FirstOrDefault() != null) || (!string.IsNullOrEmpty(model.Remarks))))
                    {
                        if (!string.IsNullOrEmpty(UploadHid) && UploadDoc != null && UploadDoc.FirstOrDefault() != null)
                        {
                            int count = 0;
                            string[] DocumentTypes = UploadHid.Split(',');
                            foreach (var item in UploadDoc)
                            {
                                model.FileName = item.FileName.ToString();
                                model.DocumentType = DocumentTypes[count];
                                if (model.DocumentType != null && model.FileName != null && item.ContentLength > 0)
                                {
                                    SavePQVerifiedUploadDoc(model.PersonalRowID, model.SubCheckRowID, "Provided", model.DocumentType, "provideddocuments", item, model.Remarks, 0, model.SecuritasID);
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "Invalid Document!";
                                    break;
                                }
                                count++;
                            }

                            if (string.IsNullOrEmpty(model.Remarks))
                            {
                                model.Remarks = "Insuff Document Uploaded By Spoc";
                            } 
                        }
                        repoPQPersonal.UpdateInsuffCheckByPeraonalIdAndSubCheckID(model.ChFamilRowId, model.CheckRowID, model.Remarks);

                        #region Save LogTransaction Details
                        clsCommonMethods.AddPQLogTrasaction(model.PersonalRowID, "InsufficiencyCheckClearByClient", "Insuff Clear By Client Spoc", model.DocumentType, "Insert");
                        #endregion

                        #region Case/Check Action History Save 
                        clsCommonMethods.AddCheckActionHistory(model.PersonalRowID, model.SubCheckRowID, "Insuff Clear By Client Spoc", model.Remarks);
                        #endregion

                        int PID = model.PersonalRowID;
                        TempData["SuccessMsg"] = "Record Added Successfully!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Please select at least one document or mention remarks!";
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

        #region ****** Address Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageAddressInsuffForCSSpoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQAddressInsuffListPagedModel model = new PQAddressInsuffListPagedModel();
            try
            {
                int pageSize = 20;
                short ClientRowID = Convert.ToInt16(Session["ClientRowID"]);
                string spocEmail = Session["TeamMemberEmail"].ToString();
                model = repoAddressInfo.GetAllAddressInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, spocEmail);
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

        #endregion

        #region ****** Employment Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageEmploymentInsuffForCSSpoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQEmploymentInsuffListPagedModel model = new PQEmploymentInsuffListPagedModel();
            try
            {
                int pageSize = 20;
                short ClientRowID = Convert.ToInt16(Session["ClientRowID"]);
                string spocEmail = Session["TeamMemberEmail"].ToString();
                model = repoEmploymentInfo.GetAllEmploymentInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, spocEmail);
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

        #endregion

        #region ****** Education Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageEducationInsuffForCSSpoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQEducationInsuffListPagedModel model = new PQEducationInsuffListPagedModel();
            try
            {
                int pageSize = 20;
                short ClientRowID = Convert.ToInt16(Session["ClientRowID"]);
                string spocEmail = Session["TeamMemberEmail"].ToString();
                model = repoEducationInfo.GetAllEducationInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, spocEmail);
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

        #endregion

        #region ****** Criminal Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageCriminalInsuffForCSSpoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQCriminalInsuffListPagedModel model = new PQCriminalInsuffListPagedModel();
            try
            {
                int pageSize = 20;
                short ClientRowID = Convert.ToInt16(Session["ClientRowID"]);
                string spocEmail = Session["TeamMemberEmail"].ToString();
                model = repoCriminalInfo.GetAllCriminalInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, spocEmail);
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

        #endregion

        #region ****** NationalIdentity Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageNationalIdentityInsuffForCSSpoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQNationalIdentityInsuffListPagedModel model = new PQNationalIdentityInsuffListPagedModel();
            try
            {
                int pageSize = 20;
                short ClientRowID = Convert.ToInt16(Session["ClientRowID"]);
                string spocEmail = Session["TeamMemberEmail"].ToString();
                model = repoNationalIdentInfo.GetAllNationalIdentityInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, spocEmail);
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

        #endregion

        #region ****** Reference Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageReferenceInsuffForCSSpoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", string RecievingDate = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQReferenceInsuffListPagedModel model = new PQReferenceInsuffListPagedModel();
            try
            {
                int pageSize = 20;
                short ClientRowID = Convert.ToInt16(Session["ClientRowID"]);
                string spocEmail = Session["TeamMemberEmail"].ToString();
                model = repoReferenceInfo.GetAllReferenceInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, spocEmail);
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

        #endregion
        #region ****** SpecialCheck Insuff Cases ******

        [SessionExpireFilterAttribute]
        public ActionResult ManageSpecialCheckInsuffForCSSpoc(int page = 1, string sort = "", string sortDir = "asc", string Search = "", string RecievingDate = "", string RecievingToDate = "", string RecievingFromDate = "", string CompletedToDate = "", string CompletedFromDate = "")
        {
            PQSpecialCheckInsuffListPagedModel model = new PQSpecialCheckInsuffListPagedModel();
            try
            {
                int pageSize = 20;
                short ClientRowID = Convert.ToInt16(Session["ClientRowID"]);
                string spocEmail = Session["TeamMemberEmail"].ToString();
                model = repoSplCheckInfo.GetAllSpecialCheckInsuffListForDETL(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, ClientRowID, RecievingToDate, RecievingFromDate, CompletedToDate, CompletedFromDate, 0, spocEmail);
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

        #endregion
        #endregion


        #region ***** NonAction *****

        [NonAction]
        void BindClientListByLogInName(string SpocEmail = "")
        {
            try
            {
                ViewBag.ClientList = repoDDL.GetClientListForDDLByClientSpocEmailID(SpocEmail); ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        private void CreateNavigationforInsuffCaseForClientServicing()
        {
            string spocEmail = Session["TeamMemberEmail"].ToString();
            var AllChecks = repoPQPersonal.GetAllInsuffChecksCountForCSSpoc(spocEmail);
            string NavTeamMemberDE = string.Empty;
            NavTeamMemberDE += "<li><a href='" + Url.Action("ManageAddressInsuffForCSSpoc", "ClientServicing") + "'> Address (" + AllChecks.AddressCount + ") </a></li>";
            NavTeamMemberDE += "<li><a href='" + Url.Action("ManageEmploymentInsuffForCSSpoc", "ClientServicing") + "'> Employment (" + AllChecks.EmploymentCount + ") </a></li>";
            NavTeamMemberDE += "<li><a href='" + Url.Action("ManageEducationInsuffForCSSpoc", "ClientServicing") + "'> Education (" + AllChecks.EducationCount + ") </a></li>";
            NavTeamMemberDE += "<li><a href='" + Url.Action("ManageCriminalInsuffForCSSpoc", "ClientServicing") + "'> Criminal (" + AllChecks.CriminalCount + ") </a></li>";
            NavTeamMemberDE += "<li><a href='" + Url.Action("ManageNationalIdentityInsuffForCSSpoc", "ClientServicing") + "'> NationalIdentity (" + AllChecks.NatIdentityCount + ") </a></li>";
            NavTeamMemberDE += "<li><a href='" + Url.Action("ManageReferenceInsuffForCSSpoc", "ClientServicing") + "'> Reference (" + AllChecks.ReferenceCount + ") </a></li>";
            NavTeamMemberDE += "<li><a href='" + Url.Action("ManageSpecialCheckInsuffForCSSpoc", "ClientServicing") + "'> Special Check (" + AllChecks.SpecialcheckCount + ") </a></li>";

            Session["NavLeftInsuffMenuForCS"] = NavTeamMemberDE;
        }

        private void SavePQVerifiedUploadDoc(int PersonalRowID = 0, short SubCheckRowID = 0, string DocumentUploadFrom = "", string DocumentType = "", string FolderNameForSave = "", HttpPostedFileBase UploadDoc = null, string remarks = "", byte NADoc = 0, string secRefId = "")
        {
            try
            {
                //string secRefId = Session["SecuritasRefID"].ToString();
                PQAddVerifiedUploadDocViewModel DocModel = new PQAddVerifiedUploadDocViewModel();
                DocModel.PersonalRowID = PersonalRowID;
                DocModel.SubCheckRowID = SubCheckRowID;
                DocModel.DocumentUploadFrom = DocumentUploadFrom; //  Provided / Verified
                DocModel.DocumentType = DocumentType;            //Name of the selected docs
                if (NADoc == 0)
                {
                    string FldPathDoc = string.Empty;
                    FldPathDoc = ConfigurationManager.AppSettings[FolderNameForSave.Trim().ToLower()].ToString();
                    string proImg = string.Empty;
                    string ext = Path.GetExtension(UploadDoc.FileName).ToLower();
                    proImg = (secRefId + "_" + SubCheckRowID.ToString() + " " + DocumentType).Replace(" ", "_").Replace("-", "_") + ext;
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
                DocModel.InsuffDoc = 1;
                repoPQVerifiedUploadDoc.AddPQVerifiedUploadDoc(DocModel);
                repoPQVerifiedUploadDoc.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }


}