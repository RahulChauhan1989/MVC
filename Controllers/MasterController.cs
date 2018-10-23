using BAL;
using BAL.PartnerRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ViewModels;
using ViewModels.PartnerViewModels;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class MasterController : Controller
    {
        #region ********** Repository Object **********

        IBranchOfficeRepository repoBranch;
        ICountryRepository repoCountry;
        IDropDownMasterRepository repoDDL;
        IStateRepository repoState;
        ICategoryRepository repoCategory;
        IBillingCycleRepository repoBillingCycle;
        ILocationRepository repoLocation;
        IDistrictRepository repoDistrict;
        IDepartmentsRepository repoDepartment;
        IDesignationRepository repoDesignation;
        IDegreeTypeRepository repoDegreeType;
        ICheckFamilyRepository repoCheckFamily;
        ISubCheckFamilyRepository repoSubCheckFamily;
        IUniversityRepository repoUniversity;
        ICollegeRepository repoCollege;
        IEmployerRepository repoEmployer;
        IVendorRepository repoVendor;
        IPoliceStationRepository repoPoliceStation;
        IDispositionRepository repoDisposition;
        ISeverityGridRepository repoSeverityGrid;
        IAntecedentRepository repoAntecedent;
        ICompanyRepository repoCompany;
        IVendorCoverageRepository repoVendorCoverage;
        IHolidayRepository repoHoliday;
        IVCoverageDistrictRepository repoVCoverageDistrict;
        IMasterVendorLoginRepository repoVendorLogin;

        public MasterController(
            IBranchOfficeRepository _repoBranch
            , ICountryRepository _repoCountry
            , IDropDownMasterRepository _repoDDL
            , IStateRepository _repoState
            , ICategoryRepository _repoCategory
            , IBillingCycleRepository _repoBillingCycle
            , IDistrictRepository _repoDistrict
            , ILocationRepository _repoLocation
            , IDepartmentsRepository _repoDepartment
            , IDesignationRepository _repoDesignation
            , IDegreeTypeRepository _repoDegreeType
            , ICheckFamilyRepository _repoCheckFamily
            , ISubCheckFamilyRepository _repoSubCheckFamily
            , IUniversityRepository _repoUniversity
            , ICollegeRepository _repoCollege
            , IEmployerRepository _repoEmployer
            , IPoliceStationRepository _repoPoliceStation
            , IVendorRepository _repoVendor
            , IDispositionRepository _repoDisposition
            , ISeverityGridRepository _repoSeverityGrid
            , IAntecedentRepository _repoAntecedent
            , ICompanyRepository _repoCompany
            , IVendorCoverageRepository _repoVendorCoverage
            , IHolidayRepository _repoHoliday
            , IVCoverageDistrictRepository _repoVCoverageDistrict
            , IMasterVendorLoginRepository _repoVendorLogin
        )
        {
            repoBranch = _repoBranch;
            repoCountry = _repoCountry;
            repoDDL = _repoDDL;
            repoState = _repoState;
            repoCategory = _repoCategory;
            repoBillingCycle = _repoBillingCycle;
            repoDistrict = _repoDistrict;
            repoLocation = _repoLocation;
            repoDepartment = _repoDepartment;
            repoDesignation = _repoDesignation;
            repoDegreeType = _repoDegreeType;
            repoCheckFamily = _repoCheckFamily;
            repoSubCheckFamily = _repoSubCheckFamily;
            repoUniversity = _repoUniversity;
            repoCollege = _repoCollege;
            repoEmployer = _repoEmployer;
            repoPoliceStation = _repoPoliceStation;
            repoVendor = _repoVendor;
            repoDisposition = _repoDisposition;
            repoSeverityGrid = _repoSeverityGrid;
            repoAntecedent = _repoAntecedent;
            repoCompany = _repoCompany;
            repoVendorCoverage = _repoVendorCoverage;
            repoHoliday = _repoHoliday;
            repoVCoverageDistrict = _repoVCoverageDistrict;
            repoVendorLogin = _repoVendorLogin;
        }

        #endregion

        // GET: Master
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {
            return View();
        }

        #region ********* Master Company ****************

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageCompany(int page = 1, string sort = "CompanyName", string sortDir = "asc", string Search = "")
        {
            try
            {
                CompanyListPagedModel model = new CompanyListPagedModel();
                try
                {
                    int pageSize = clsGlobalCommon.PageSize;
                    model = repoCompany.GetCompanies(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddCompany()
        {
            BindCountry();
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddCompany(AddCompanyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CompanyName != null && model.CompanyName.Trim().Length > 0)
                    {
                        if (!repoCompany.IsCompanyExist(model.CompanyName.Trim()))
                        {
                            #region Candidate Terms File Save
                            string TrmFldPathDoc = ConfigurationManager.AppSettings["CandidateAgreeDoc"].ToString();
                            string trmImg = string.Empty;
                            if (model.CandidateTermsFile != null && model.CandidateTermsFile.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.CandidateTermsFile.FileName).ToLower();
                                trmImg = "CandidateAgreement" + ext;
                                model.CandidateTermsFile.SaveAs(Server.MapPath(TrmFldPathDoc + trmImg));
                            }
                            #endregion

                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["CompanyDoc"].ToString();
                            string proImg = string.Empty;
                            if (model.CompanyLogo != null && model.CompanyLogo.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.CompanyLogo.FileName).ToLower();
                                proImg = (model.CompanyName + " ").Replace(" ", "_").Replace("-", "_") + ext;
                                model.CompanyLogo.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.CmpLogo = Path.GetFileName(proImg);
                            }
                            #endregion

                            string PwdEncrypt = clsCommonMethods.PasswordEncrypt(model.SMTPPassword.Trim());
                            model.SMTPPassword = PwdEncrypt;
                            model.Status = 1;

                            repoCompany.AddCompany(model);
                            int Res = repoCompany.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCompany");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Company Name could not be blank!");
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
            catch (Exception)
            {

                throw;
            }
            BindCountry();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditCompany(short id = 0)
        {
            UpdateCompanyViewModel model = new UpdateCompanyViewModel();
            try
            {
                BindCountry();
                model = repoCompany.GetCompanyForUpdateById(id);

            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult EditCompany(UpdateCompanyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CompanyName != null && model.CompanyName.Trim().Length > 0)
                    {
                        if (!repoCompany.IsCompanyExist(model.CompanyName, model.CompanyRowID))
                        {
                            #region Candidate Terms File Save
                            string TrmFldPathDoc = ConfigurationManager.AppSettings["CandidateAgreeDoc"].ToString();
                            string trmImg = string.Empty;
                            if (model.CandidateTermsFile != null && model.CandidateTermsFile.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.CandidateTermsFile.FileName).ToLower();
                                trmImg = "CandidateAgreement" + ext;
                                model.CandidateTermsFile.SaveAs(Server.MapPath(TrmFldPathDoc + trmImg));
                            }
                            #endregion

                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["CompanyDoc"].ToString();
                            string proImg = string.Empty;
                            if (model.CompanyLogo != null && model.CompanyLogo.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.CompanyLogo.FileName).ToLower();
                                proImg = (model.CompanyName + " ").Replace(" ", "_").Replace("-", "_") + ext;
                                model.CompanyLogo.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.CmpLogo = Path.GetFileName(proImg);
                            }
                            #endregion

                            if (!string.IsNullOrEmpty(model.SMTPPassword))
                            {
                                string PwdEncrypt = clsCommonMethods.PasswordEncrypt(model.SMTPPassword.Trim());
                                model.SMTPPassword = PwdEncrypt;
                            }

                            repoCompany.UpdateCompany(model);
                            int Res = repoCompany.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCompany");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no change!";
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Company Name could not be blank!");
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
            catch (Exception)
            {

                throw;
            }
            BindCountry();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult CompanyActive(string checkeds = "", short id = 0)
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
                    repoCompany.ActiveCompany(id, checkeds);
                    int Res = repoCompany.SaveChanges();
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
        public void ExportCompany()
        {
            // Step 1 - get the data from database
            var data = repoCompany.GetCompaniesForExport();
            ExportToExcel(data, "Companies");
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult CompanyDetails(short id = 0)
        {
            CompanyViewModel model = new CompanyViewModel();
            try
            {
                BindCountry();
                model = repoCompany.GetCompanyForDetailsById(id);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }
            return View(model);
        }

        #endregion

        #region ********** Branch Office Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult BranchOffice(short CId = 0)
        {
            if (CId == 0)
            {
                return RedirectToAction("ManageCompany");
            }
            else
            {
                ViewBag.CompanyName = repoCompany.GetCompany().Where(p => p.CompanyRowID == CId).Select(p => p.CompanyName).FirstOrDefault();
                return View();
            }
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult BranchOffice(AddBranchOfficeViewModel model, short CId = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.BOName != null && model.BOName.Trim().Length > 0)
                    {
                        if (!repoBranch.IsBranchOfficeExist(model.BOName.Trim()))
                        {
                            model.CompanyRowID = CId;
                            repoBranch.AddBranchOffice(model);
                            int Res = repoBranch.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageBranchOffice", new { CId });
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
                        ModelState.AddModelError("", "Branch Name could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageBranchOffice(int page = 1, string sort = "BOName", string sortDir = "asc", string Search = "", short CId = 0)
        {
            BranchOfficeListPagedModel model = new BranchOfficeListPagedModel();
            try
            {
                int pageSize = 20;
                model = repoBranch.GetBranchOffices(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CId);
                ViewBag.ClientName = repoCompany.GetCompany().Where(p => p.CompanyRowID == CId).Select(p => p.CompanyName).FirstOrDefault();
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
        public ActionResult EditBranchOffice(short CId = 0, short id = 0)
        {
            UpdateBranchOfficeViewModel model = new UpdateBranchOfficeViewModel();
            try
            {
                model = repoBranch.GetBranchOfficeForUpdateById(id);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            ViewBag.CompanyName = repoCompany.GetCompany().Where(p => p.CompanyRowID == CId).Select(p => p.CompanyName).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult EditBranchOffice(UpdateBranchOfficeViewModel model, short CId = 0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.BOName != null && model.BOName.Trim().Length > 0 && model.BORowID > 0)
                    {
                        if (!repoBranch.IsBranchOfficeExist(model.BOName, model.BORowID))
                        {
                            repoBranch.UpdateBranchOffice(model);
                            int Res = repoBranch.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageBranchOffice", new { CId });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no changes!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Branch Name could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult BranchOfficeActive(string checkeds = "", short id = 0)
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
                    repoBranch.ActiveBranchOffice(id, checkeds);
                    int Res = repoBranch.SaveChanges();
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
        public void ExportBranchOffice()
        {
            try
            {
                var data = repoBranch.GetBranchOfficesForExport();
                ExportToExcel(data, "BranchOffice");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** Country Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageCountry(int page = 1, string sort = "CountryName", string sortDir = "asc", string Search = "")
        {
            CountryListPagedModel model = new CountryListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoCountry.GetCountries(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult Country()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult Country(AddCountryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CountryCode != null && model.CountryName != null && model.CountryCode.Trim().Length > 0 && model.CountryName.Trim().Length > 0)
                    {
                        if (!repoCountry.IsCountryExist(model.CountryCode, model.CountryName))
                        {
                            model.Status = 1;
                            repoCountry.AddCountry(model);
                            int Res = repoCountry.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCountry");
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
                        ModelState.AddModelError("", "Country Name could not be blank!");
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
        public ActionResult EditCountry(short id = 0)
        {
            UpdateCountryViewModel model = new UpdateCountryViewModel();
            try
            {
                model = repoCountry.GetCountryForUpdateById(id);
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
        public ActionResult EditCountry(UpdateCountryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CountryCode != null && model.CountryName != null && model.CountryCode.Trim().Length > 0 && model.CountryName.Trim().Length > 0 && model.CountryRowID > 0)
                    {
                        if (!repoCountry.IsCountryExist(model.CountryCode, model.CountryName, model.CountryRowID))
                        {
                            repoCountry.UpdateCountry(model);
                            int Res = repoCountry.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCountry");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no changes!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Country Name could not be blank!");
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
        public JsonResult CountryActive(string checkeds = "", short id = 0)
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
                    repoCountry.ActiveCountry(id, checkeds);
                    int Res = repoCountry.SaveChanges();
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
        public void ExportCountry()
        {
            try
            {
                // Step 1 - get the data from database
                var data = repoCountry.GetCountriesForExport();
                ExportToExcel(data, "Countries");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** Category Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult Category()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult Category(AddCategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CategoryName != null && model.CategoryName.Trim().Length > 0)
                    {
                        if (!repoCategory.IsCategoryExist(model.CategoryName.Trim()))
                        {
                            repoCategory.AddCategory(model);
                            int Res = repoCategory.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCategory");
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
                        ModelState.AddModelError("", "Category Name could not be blank!");
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
        public ActionResult ManageCategory(int page = 1, string sort = "CategoryName", string sortDir = "asc", string Search = "")
        {
            CategoryListPagedModel model = new CategoryListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoCategory.GetCategory(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditCategory(short id = 0)
        {
            UpdateCategoryViewModel model = new UpdateCategoryViewModel();
            try
            {
                model = repoCategory.GetCategoryForUpdateById(id);
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
        public ActionResult EditCategory(UpdateCategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CategoryName != null && model.CategoryName.Trim().Length > 0 && model.CategoryRowID > 0)
                    {
                        if (!repoCategory.IsCategoryExist(model.CategoryName.Trim()))
                        {
                            repoCategory.UpdateCategory(model);
                            int Res = repoCategory.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCategory");
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
                        ModelState.AddModelError("", "Category name could not be blank!");
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
        public JsonResult CategoryActive(string checkeds = "", short id = 0)
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
                    repoCategory.ActiveCategory(id, checkeds);
                    int Res = repoCategory.SaveChanges();
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
        public void ExportCategory()
        {
            try
            {
                // Step 1 - get the data from database
                var data = repoCategory.GetCategoriesForExport();
                ExportToExcel(data, "Categories");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** Department Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddDepartment(AddDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.DepartmentName != null && model.DepartmentName.Trim().Length > 0)
                    {
                        if (!repoDepartment.IsDepartmentExist(model.DepartmentName.Trim()))
                        {
                            repoDepartment.AddDepartment(model);
                            int Res = repoDepartment.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageDepartments");
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
                        ModelState.AddModelError("", "Department Name could not be blank!");
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
        public ActionResult ManageDepartments(int page = 1, string sort = "DepartmentName", string sortDir = "asc", string Search = "")
        {
            DepartmentListPagedModel model = new DepartmentListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoDepartment.GetDepartment(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditDepartment(short id = 0)
        {
            UpdateDepartmentViewModel model = new UpdateDepartmentViewModel();
            try
            {
                model = repoDepartment.GetDepartmentForUpdateById(id);
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
        public ActionResult EditDepartment(UpdateDepartmentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.DepartmentName != null && model.DepartmentName.Trim().Length > 0 && model.DepartmentRowID > 0)
                    {
                        if (!repoDepartment.IsDepartmentExist(model.DepartmentName.Trim()))
                        {
                            repoDepartment.UpdateDepartment(model);
                            int Res = repoDepartment.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageDepartments");
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
                        ModelState.AddModelError("", "Department name could not be blank!");
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
        public JsonResult DepartmentActive(string checkeds = "", short id = 0)
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
                    repoDepartment.ActiveDepartment(id, checkeds);
                    int Res = repoDepartment.SaveChanges();
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
        public void ExportDepartment()
        {

            try
            {
                var data = repoDepartment.GetDepartmentesForExport();
                ExportToExcel(data, "Departmentes");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** Designation Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddDesignation()
        {
            try
            {
                BindDepartmentList();
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
        public ActionResult AddDesignation(AddDesignationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.DesignationName != null && model.DesignationName.Trim().Length > 0)
                    {
                        if (!repoDesignation.IsDesignationExist(model.DesignationName.Trim(), model.DepartmentRowID))
                        {
                            repoDesignation.AddDesignation(model);
                            int Res = repoDesignation.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageDesignations");
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
                        ModelState.AddModelError("", "Designation Name could not be blank!");
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
            BindDepartmentList();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageDesignations(int page = 1, string sort = "DepartmentName", string sortDir = "asc", string Search = "")
        {
            DesignationListPagedModel model = new DesignationListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoDesignation.GetDesignation(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditDesignation(short id = 0)
        {
            UpdateDesignationViewModel model = new UpdateDesignationViewModel();
            try
            {
                BindDepartmentList();
                model = repoDesignation.GetDesignationForUpdateById(id);
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
        public ActionResult EditDesignation(UpdateDesignationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.DesignationName != null && model.DesignationName.Trim().Length > 0 && model.DesignationRowID > 0)
                    {
                        if (!repoDesignation.IsDesignationExist(model.DesignationName.Trim(), model.DepartmentRowID))
                        {
                            repoDesignation.UpdateDesignation(model);
                            int Res = repoDesignation.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageDesignations");
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
                        ModelState.AddModelError("", "Designation name could not be blank!");
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
            BindDepartmentList();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DesignationActive(string checkeds = "", short id = 0)
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
                    repoDesignation.ActiveDesignation(id, checkeds);
                    int Res = repoDesignation.SaveChanges();
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
        public void ExportDesignation()
        {
            try
            {

                var data = repoDesignation.GetDesignationsForExport();
                ExportToExcel(data, "Designations");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** State Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageStates(int page = 1, string sort = "StateName", string sortDir = "asc", string Search = "")
        {
            StateListPagedModel model = new StateListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoState.GetStates(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No record found!";
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
        public ActionResult AddState()
        {
            try
            {
                BindCountry();
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
        public ActionResult AddState(AddStateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.StateName != null && model.StateName.Trim().Length > 0)
                    {
                        if (!repoState.IsStateExist(model.StateName.Trim()))
                        {
                            repoState.AddState(model);
                            int Res = repoState.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageStates");
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
                        ModelState.AddModelError("", "State Name could not be blank!");
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
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditState(short id = 0)
        {
            UpdateStateViewModel model = new UpdateStateViewModel();
            try
            {
                BindCountry();
                model = repoState.GetStateForUpdateById(id);
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
        public ActionResult EditState(UpdateStateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.StateName != null && model.StateName.Trim().Length > 0 && model.StateRowID > 0)
                    {
                        if (!repoState.IsStateExist(model.StateName.Trim()))
                        {
                            repoState.UpdateState(model);
                            int Res = repoState.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageStates");
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
                        ModelState.AddModelError("", "State Name could not be blank!");
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
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult StateActive(string checkeds = "", short id = 0)
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
                    repoState.ActiveStates(id, checkeds);
                    int Res = repoState.SaveChanges();
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
        public void ExportStates()
        {
            try
            {
                var data = repoState.GetStatesForExport();
                ExportToExcel(data, "States");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** District Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageDistricts(int page = 1, string sort = "DistrictName", string sortDir = "asc", string Search = "")
        {
            DistrictListPagedModel model = new DistrictListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoDistrict.GetDistricts(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No record found!";
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
        public ActionResult AddDistrict()
        {
            try
            {
                BindCountry();
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
        public ActionResult AddDistrict(AddDistrictViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.DistrictName != null && model.DistrictName.Trim().Length > 0)
                    {
                        if (!repoDistrict.IsDistrictExist(model.DistrictName.Trim()))
                        {
                            repoDistrict.AddDistrict(model);
                            int Res = repoDistrict.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageDistricts");
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
                        ModelState.AddModelError("", "District Name could not be blank!");
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
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditDistrict(short id = 0)
        {
            UpdateDistrictViewModel model = new UpdateDistrictViewModel();
            try
            {
                BindCountry();
                model = repoDistrict.GetDistrictForUpdateById(id);
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
        public ActionResult EditDistrict(UpdateDistrictViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.DistrictName != null && model.DistrictName.Trim().Length > 0 && model.DistrictRowID > 0)
                    {
                        if (!repoDistrict.IsDistrictExist(model.DistrictName.Trim()))
                        {
                            repoDistrict.UpdateDistrict(model);
                            int Res = repoDistrict.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageDistricts");
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
                        ModelState.AddModelError("", "District name could not be blank!");
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
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DistrictActive(string checkeds = "", short id = 0)
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
                    repoDistrict.ActiveDistrict(id, checkeds);
                    int Res = repoDistrict.SaveChanges();
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
        public void ExportDistrict()
        {
            try
            {
                var data = repoDistrict.GetDistrictesForExport();
                ExportToExcel(data, "Districts");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** Location Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddLocation()
        {
            try
            {
                BindCountry();
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
        public ActionResult AddLocation(AddLocationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.LocationName != null && model.LocationName.Trim().Length > 0)
                    {
                        if (!repoLocation.IsLocationExist(model.LocationName.Trim()))
                        {
                            repoLocation.AddLocation(model);
                            int Res = repoLocation.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageLocations");
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
                        ModelState.AddModelError("", "Location Name could not be blank!");
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
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageLocations(int page = 1, string sort = "locationrowid", string sortDir = "asc", string Search = "")
        {
            LocationListPagedModel model = new LocationListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoLocation.GetLocation(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditLocation(int id = 0)
        {
            UpdateLocationViewModel model = new UpdateLocationViewModel();
            try
            {
                BindCountry();
                model = repoLocation.GetLocationForUpdateById(id);
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
        public ActionResult EditLocation(UpdateLocationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.LocationName != null && model.LocationName.Trim().Length > 0 && model.LocationRowID > 0)
                    {
                        if (!repoLocation.IsLocationExist(model.LocationName.Trim()))
                        {
                            repoLocation.UpdateLocation(model);
                            int Res = repoLocation.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageLocations");
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
                        ModelState.AddModelError("", "Location name could not be blank!");
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
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult CountryLocation(string checkeds = "", short id = 0)
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
                    repoLocation.ActiveLocation(id, checkeds);
                    int Res = repoLocation
                        .SaveChanges();
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
        public JsonResult LocationActive(string checkeds = "", short id = 0)
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
                    repoLocation.ActiveLocation(id, checkeds);
                    int Res = repoLocation.SaveChanges();
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
        public void ExportLocation()
        {
            try
            {
                var data = repoLocation.GetLocationesForExport();
                ExportToExcel(data, "Location");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** DegreeType Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddDegreeType()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddDegreeType(AddDegreeTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.DegreeType != null && model.DegreeType.Trim().Length > 0)
                    {
                        if (!repoDegreeType.IsDegreeTypeExist(model.DegreeType.Trim()))
                        {
                            repoDegreeType.AddDegreeType(model);
                            int Res = repoDegreeType.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageDegreeTypes");
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
                        ModelState.AddModelError("", "DegreeType Name could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageDegreeTypes(int page = 1, string sort = "DegreeTypeName", string sortDir = "asc", string Search = "")
        {
            DegreeTypeListPagedModel model = new DegreeTypeListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoDegreeType.GetDegreeType(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditDegreeType(short id = 0)
        {
            UpdateDegreeTypeViewModel model = new UpdateDegreeTypeViewModel();
            try
            {
                model = repoDegreeType.GetDegreeTypeForUpdateById(id);
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
        public ActionResult EditDegreeType(UpdateDegreeTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.DegreeType != null && model.DegreeType.Trim().Length > 0 && model.DegreeRowID > 0)
                    {
                        if (!repoDegreeType.IsDegreeTypeExist(model.DegreeType.Trim()))
                        {
                            repoDegreeType.UpdateDegreeType(model);
                            int Res = repoDegreeType.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageDegreeTypes");
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
                        ModelState.AddModelError("", "DegreeType name could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DegreeTypesActive(string checkeds = "", short id = 0)
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
                    repoDegreeType.ActiveDegree(id, checkeds);
                    int Res = repoDegreeType.SaveChanges();
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
        public void ExportDegree()
        {
            try
            {
                var data = repoDegreeType.GetDegreeForExport();
                ExportToExcel(data, "Degrees");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** SubCheckFamily Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddSubCheckFamily()
        {
            try
            {
                BindCheckFamilyList();
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
        public ActionResult AddSubCheckFamily(AddSubCheckFamilyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.SubCheckName != null && model.SubCheckName.Trim().Length > 0)
                    {
                        if (!repoSubCheckFamily.IsSubCheckFamilyExist(model.SubCheckName.Trim(), model.CheckFamilyRowID))
                        {
                            repoSubCheckFamily.AddSubCheckFamily(model);
                            int Res = repoSubCheckFamily.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageSubCheckFamily");
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
                        ModelState.AddModelError("", "Sub Check Family Name could not be blank!");
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

            BindCheckFamilyList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageSubCheckFamily(int page = 1, string sort = "CheckFamilyName", string sortDir = "asc", short CheckFamilyRowID = 0, string Search = "")
        {
            SubCheckFamilyListPagedModel model = new SubCheckFamilyListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoSubCheckFamily.GetSubCheckFamily(page, pageSize, sort.ToLower(), sortDir.ToLower(), CheckFamilyRowID, Search);
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
            BindCheckFamilyList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditSubCheckFamily(short id = 0)
        {
            UpdateSubCheckFamilyViewModel model = new UpdateSubCheckFamilyViewModel();
            try
            {
                BindCheckFamilyList();
                model = repoSubCheckFamily.GetSubCheckFamilyForUpdateById(id);
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
        public ActionResult EditSubCheckFamily(UpdateSubCheckFamilyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.SubCheckName != null && model.SubCheckName.Trim().Length > 0 && model.SubCheckFamilyRowID > 0)
                    {
                        if (!repoSubCheckFamily.IsSubCheckFamilyExist(model.SubCheckName, model.CheckFamilyRowID, model.SubCheckFamilyRowID))
                        {
                            repoSubCheckFamily.UpdateSubCheckFamily(model);
                            int Res = repoSubCheckFamily.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageSubCheckFamily");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no changes!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sub Check Family name could not be blank!");
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

            BindCheckFamilyList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult SubCheckFamilyActive(string checkeds = "", short id = 0)
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
                    repoSubCheckFamily.ActiveSubCheckFamily(id, checkeds);
                    int Res = repoSubCheckFamily.SaveChanges();
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
        public void ExportSubCheckFamily()
        {
            try
            {
                var data = repoSubCheckFamily.GetSubCheckFamiliesForExport();
                ExportToExcel(data, "SubCheckFamilies");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** CheckFamily Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddCheckFamily()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddCheckFamily(AddCheckFamilyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CheckFamilyName != null && model.CheckFamilyName.Trim().Length > 0)
                    {
                        if (!repoCheckFamily.IsCheckFamilyExist(model.CheckFamilyName.Trim()))
                        {
                            repoCheckFamily.AddCheckFamily(model);
                            int Res = repoCheckFamily.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCheckFamily");
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
                        ModelState.AddModelError("", "CheckFamily Name could not be blank!");
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
        public ActionResult ManageCheckFamily(int page = 1, string sort = "CheckFamilyName", string sortDir = "asc", string Search = "")
        {
            CheckFamilyListPagedModel model = new CheckFamilyListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoCheckFamily.GetCheckFamily(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditCheckFamily(short id = 0)
        {
            UpdateCheckFamilyViewModel model = new UpdateCheckFamilyViewModel();
            try
            {
                model = repoCheckFamily.GetCheckFamilyForUpdateById(id);
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
        public ActionResult EditCheckFamily(UpdateCheckFamilyViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CheckFamilyName != null && model.CheckFamilyName.Trim().Length > 0 && model.CheckFamilyRowID > 0)
                    {
                        if (!repoCheckFamily.IsCheckFamilyExist(model.CheckFamilyName.Trim()))
                        {
                            repoCheckFamily.UpdateCheckFamily(model);
                            int Res = repoCheckFamily.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageCheckFamily");
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no changes!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "CheckFamily name could not be blank!");
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
        public JsonResult CheckFamilyActive(string checkeds = "", short id = 0)
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
                    repoCheckFamily.ActiveCheckFamily(id, checkeds);
                    int Res = repoCheckFamily.SaveChanges();
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
        public void ExportCheckFamily()
        {
            try
            {
                var data = repoCheckFamily.GetCheckFamiliesForExport();
                ExportToExcel(data, "CheckFamilies");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** Billing Cycle **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult BillingCycle()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult BillingCycle(AddBillingCycleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.BillingCycle != null && model.BillingCycle.Trim().Length > 0)
                    {
                        if (!repoBillingCycle.IsBillingCycleExist(model.BillingCycle.Trim()))
                        {
                            repoBillingCycle.AddBillingCycle(model);
                            var Res = repoBillingCycle.SaveChanges();

                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageBillingCycle");
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
                        ModelState.AddModelError("", "Billing Cycle Name could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageBillingCycle(int page = 1, string sort = "BillingCycle", string sortDir = "asc", string Search = "")
        {
            BillingCycleListPagedModel model = new BillingCycleListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoBillingCycle.GetBillingCycles(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditBillingCycle(byte id = 0)
        {
            UpdateBillingCycleViewModel model = new UpdateBillingCycleViewModel();
            try
            {
                model = repoBillingCycle.GetBillingCycleForUpdateById(id);
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
        public ActionResult EditBillingCycle(UpdateBillingCycleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.BillingCycle != null && model.BillingCycle.Trim().Length > 0)
                    {
                        if (!repoBillingCycle.IsBillingCycleExist(model.BillingCycle.Trim()))
                        {
                            repoBillingCycle.UpdateBillingCycle(model);
                            var Res = repoBillingCycle.SaveChanges();

                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageBillingCycle");
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
                        ModelState.AddModelError("", "Billing Cycle Name could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult BillingCycleActive(string checkeds = "", short id = 0)
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
                    repoBillingCycle.ActiveBillingCycle(id, checkeds);
                    int Res = repoBillingCycle.SaveChanges();
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
        public void ExportBillingCycle()
        {
            try
            {
                var data = repoBillingCycle.GetBillingCyclesForExport();
                ExportToExcel(data, "BillingCycles");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** University Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddUniversity()
        {
            try
            {
                BindCountry();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindAffliatiatedfrom();
                BindUniversityStatusList();
                BindModeOfInitiationList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();

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
        public ActionResult AddUniversity(AddUniversityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.UniversityName != null && model.UniversityName.Trim().Length > 0)
                    {
                        if (!repoUniversity.IsUniversityExist(model.UniversityName.Trim()))
                        {
                            #region ***** Image Upload *****

                            string FldPathDoc = ConfigurationManager.AppSettings["MasterUniversityDocs"].ToString();

                            string fileNames = string.Empty;
                            string proImg = string.Empty;
                            if (model.PostedImage.FirstOrDefault() != null)
                            {
                                foreach (var file in model.PostedImage)
                                {
                                    string ext = Path.GetFileName(file.FileName).ToLower();
                                    proImg = (model.UniversityName + " " + model.UniversityStatus).Replace(" ", "_").Replace("-", "_") + ext;
                                    file.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                    fileNames += proImg + ",";
                                }
                                model.Snapshot = Path.GetFileName(fileNames);
                            }

                            #endregion

                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.OfficialEmailId != null && model.OfficialEmailId.Length > 0)
                            {
                                string[] arrEmails = model.OfficialEmailId.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.OfficialEmailId = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion

                            if (flag)
                            {
                                model.ModifiedDate = DateTime.Now;
                                repoUniversity.AddUniversity(model);
                                int Res = repoUniversity.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManageUniversities");
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "University Name could not be blank!");
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
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindAffliatiatedfrom();
            BindUniversityStatusList();
            BindModeOfInitiationList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageUniversities(int page = 1, string sort = "", string sortDir = "desc", string Search = "")
        {
            UniversityListPagedModel model = new UniversityListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoUniversity.GetUniversity(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditUniversity(short id = 0)
        {
            UpdateUniversityViewModel model = new UpdateUniversityViewModel();
            try
            {
                BindCountry();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindAffliatiatedfrom();
                BindUniversityStatusList();
                BindModeOfInitiationList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
                model = repoUniversity.GetUniversityForUpdateById(id);
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
        public ActionResult EditUniversity(UpdateUniversityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.UniversityName != null && model.UniversityName.Trim().Length > 0 && model.UniversityRowID > 0)
                    {
                        if (!repoUniversity.IsUniversityExist(model.UniversityRowID, model.UniversityName.Trim()))
                        {

                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["MasterUniversityDocs"].ToString();

                            string fileNames = string.Empty;
                            string proImg = string.Empty;
                            if (model.PostedImage.FirstOrDefault() != null)
                            {
                                foreach (var file in model.PostedImage)
                                {
                                    string ext = Path.GetFileName(file.FileName).ToLower();
                                    proImg = (model.UniversityName + " " + model.UniversityStatus).Replace(" ", "_").Replace("-", "_") + ext;
                                    file.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                    fileNames += proImg + ",";
                                }
                                model.Snapshot = Path.GetFileName(fileNames);
                            }

                            #endregion

                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.OfficialEmailId != null && model.OfficialEmailId.Length > 0)
                            {
                                string[] arrEmails = model.OfficialEmailId.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.OfficialEmailId = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion

                            if (flag)
                            {
                                model.ModifiedDate = DateTime.Now;
                                repoUniversity.UpdateUniversity(model);
                                int Res = repoUniversity.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Edited Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManageUniversities");
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is no change!";
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "University name could not be blank!");
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
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindAffliatiatedfrom();
            BindUniversityStatusList();
            BindModeOfInitiationList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult UniversityActive(string checkeds = "", short id = 0)
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
                    repoUniversity.ActiveUniversity(id, checkeds);
                    int Res = repoUniversity.SaveChanges();
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
        public ActionResult UniversityDetails(short id = 0)
        {
            UniversityViewModel model = new UniversityViewModel();
            try
            {
                model = repoUniversity.GetUniversityForDetailsById(id);

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
        public void ExportUniversities()
        {
            try
            {

                var data = repoUniversity.GetUniversitiesForExport();
                ExportToExcel(data, "Universities");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** College Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddCollege()
        {
            try
            {
                BindCountry();
                BindUniversityList();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindAffliatiatedfrom();
                BindUniversityStatusList();
                BindModeOfInitiationList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
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
        public ActionResult AddCollege(AddCollegeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CollegeName != null && model.CollegeName.Trim().Length > 0)
                    {
                        if (!repoCollege.IsCollegeExist(model.CollegeName.Trim()))
                        {
                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["MasterCollegeDocs"].ToString();

                            string fileNames = string.Empty;
                            string proImg = string.Empty;
                            if (model.PostedImage.FirstOrDefault() != null)
                            {
                                foreach (var file in model.PostedImage)
                                {
                                    string ext = Path.GetFileName(file.FileName).ToLower();
                                    proImg = (model.CollegeName + " " + model.CollegeStatus).Replace(" ", "_").Replace("-", "_") + ext;
                                    file.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                    fileNames += proImg + ",";
                                }
                                model.Snapshot = Path.GetFileName(fileNames);
                            }

                            #endregion

                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.OfficialEmailId != null && model.OfficialEmailId.Length > 0)
                            {
                                string[] arrEmails = model.OfficialEmailId.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.OfficialEmailId = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion
                            if (flag)
                            {
                                model.ModifiedDate = DateTime.Now;
                                repoCollege.AddCollege(model);
                                int Res = repoCollege.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManageColleges");
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
                    }
                    else
                    {
                        ModelState.AddModelError("", "College Name could not be blank!");
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
            BindUniversityList();
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindAffliatiatedfrom();
            BindUniversityStatusList();
            BindModeOfInitiationList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageColleges(int page = 1, string sort = "", string sortDir = "desc", string Search = "")
        {
            CollegeListPagedModel model = new CollegeListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoCollege.GetCollege(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult ManageBeyondColleges(int page = 1, string sort = "", string sortDir = "desc", string Search = "")
        {
            CollegeListPagedModel model = new CollegeListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoCollege.GetBeyondCollege(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditCollege(short id = 0, bool bynd = false)
        {
            UpdateCollegeViewModel model = new UpdateCollegeViewModel();
            try
            {
                BindCountry();
                BindUniversityList();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindAffliatiatedfrom();
                BindUniversityStatusList();
                BindModeOfInitiationList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
                model = repoCollege.GetCollegeForUpdateById(id);
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
        public ActionResult EditCollege(UpdateCollegeViewModel model, bool bynd = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CollegeName != null && model.CollegeName.Trim().Length > 0 && model.CollegeRowID > 0)
                    {
                        if (!repoCollege.IsCollegeExist(model.CollegeRowID, model.CollegeName.Trim()))
                        {
                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["MasterCollegeDocs"].ToString();

                            string fileNames = string.Empty;
                            string proImg = string.Empty;
                            if (model.PostedImage.FirstOrDefault() != null)
                            {
                                foreach (var file in model.PostedImage)
                                {
                                    string ext = Path.GetFileName(file.FileName).ToLower();
                                    proImg = (model.CollegeName + " " + model.CollegeStatus).Replace(" ", "_").Replace("-", "_") + ext;
                                    file.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                    fileNames += proImg + ",";
                                }
                                model.Snapshot = Path.GetFileName(fileNames);
                            }

                            #endregion

                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.OfficialEmailId != null && model.OfficialEmailId.Length > 0)
                            {
                                string[] arrEmails = model.OfficialEmailId.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.OfficialEmailId = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion

                            if (flag)
                            {
                                model.ModifiedDate = DateTime.Now;
                                repoCollege.UpdateCollege(model);
                                int Res = repoCollege.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Edited Successfully!";
                                    ModelState.Clear();

                                    if (bynd)
                                    {
                                        return RedirectToAction("ManageBeyondColleges");
                                    }
                                    else
                                    {
                                        return RedirectToAction("ManageColleges");
                                    }
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
                    }
                    else
                    {
                        ModelState.AddModelError("", "College name could not be blank!");
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
            BindUniversityList();
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindAffliatiatedfrom();
            BindUniversityStatusList();
            BindModeOfInitiationList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult CollegeActive(string checkeds = "", short id = 0)
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
                    repoCollege.ActiveCollege(id, checkeds);
                    int Res = repoCollege.SaveChanges();
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
        public ActionResult CollegeDetails(short id = 0)
        {
            CollegeViewModel model = new CollegeViewModel();
            try
            {
                model = repoCollege.GetCollegeForDetailsById(id);

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
        public void ExportColleges()
        {
            try
            {

                var data = repoCollege.GetCollegesForExport();
                ExportToExcel(data, "Universities");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** Employer Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddEmployer()
        {
            try
            {
                BindCountry();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindMandatoryDocumentList();
                BindCompanyStatusList();
                BindCompanyLegalStatusList();
                BindModeOfInitiationList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
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
        public ActionResult AddEmployer(AddEmployerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CompanyName != null && model.CompanyName.Trim().Length > 0)
                    {
                        if (!repoEmployer.IsEmployerExist(model.CompanyName.Trim()))
                        {
                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["MasterEmployerDocs"].ToString();
                            string fileNames = string.Empty;

                            if (model.PostedImage.FirstOrDefault() != null)
                            {
                                string proImg = string.Empty;
                                foreach (var file in model.PostedImage)
                                {
                                    string ext = Path.GetFileName(file.FileName).ToLower();
                                    proImg = (model.CompanyName + " " + model.CompanyLegalStatus).Replace(" ", "_").Replace("-", "_") + ext;
                                    file.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                    fileNames += proImg + ",";
                                }
                                model.Snapshot = Path.GetFileName(fileNames);
                            }

                            if (model.MCARegProofImage != null && model.MCARegProofImage.FileName.ToString() != "")
                            {
                                string proImg = string.Empty;
                                string ext = Path.GetExtension(model.MCARegProofImage.FileName).ToLower();
                                proImg = (model.CompanyName + " " + "MCARegProof").Replace(" ", "_").Replace("-", "_") + ext;
                                model.MCARegProofImage.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.MCARegProof = Path.GetFileName(proImg);
                            }
                            if (model.InitAddProofImage != null && model.InitAddProofImage.FileName.ToString() != "")
                            {
                                string proImg = string.Empty;
                                string ext = Path.GetExtension(model.InitAddProofImage.FileName).ToLower();
                                proImg = (model.CompanyName + " " + "PVInitAtAddress").Replace(" ", "_").Replace("-", "_") + ext;
                                model.InitAddProofImage.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.PVInitAtAddressProof = Path.GetFileName(proImg);
                            }
                            if (model.OtherDocProofImage != null && model.OtherDocProofImage.FileName.ToString() != "")
                            {
                                string proImg = string.Empty;
                                string ext = Path.GetExtension(model.OtherDocProofImage.FileName).ToLower();
                                proImg = (model.CompanyName + " " + "OtherDocumentNo").Replace(" ", "_").Replace("-", "_") + ext;
                                model.OtherDocProofImage.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.OtherDocProof = Path.GetFileName(proImg);
                            }
                            #endregion
                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.OfficialEmailId != null && model.OfficialEmailId.Length > 0)
                            {
                                string[] arrEmails = model.OfficialEmailId.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.OfficialEmailId = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion

                            if (flag)
                            {
                                model.ModifiedDate = DateTime.Now;
                                repoEmployer.AddEmployer(model);
                                int Res = repoEmployer.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManageEmployers");
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Company Name could not be blank!");
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
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindMandatoryDocumentList();
            BindCompanyStatusList();
            BindCompanyLegalStatusList();
            BindModeOfInitiationList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageEmployers(int page = 1, string sort = "", string sortDir = "desc", string Search = "")
        {
            EmployerListPagedModel model = new EmployerListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoEmployer.GetEmployer(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult ManageBeyondEmployers(int page = 1, string sort = "", string sortDir = "desc", string Search = "")
        {
            EmployerListPagedModel model = new EmployerListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoEmployer.GetBeyondEmployer(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditEmployer(short id = 0, bool bynd = false)
        {
            UpdateEmployerViewModel model = new UpdateEmployerViewModel();
            try
            {
                BindCountry();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindMandatoryDocumentList();
                BindCompanyStatusList();
                BindCompanyLegalStatusList();
                BindModeOfInitiationList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
                model = repoEmployer.GetEmployerForUpdateById(id);
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
        public ActionResult EditEmployer(UpdateEmployerViewModel model, bool bynd = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CompanyName != null && model.CompanyName.Trim().Length > 0 && model.EmployerRowID > 0)
                    {
                        if (!repoEmployer.IsEmployerExist(model.EmployerRowID, model.CompanyName.Trim()))
                        {
                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["MasterEmployerDocs"].ToString();
                            string fileNames = string.Empty;

                            if (model.PostedImage.FirstOrDefault() != null)
                            {
                                string proImg = string.Empty;
                                foreach (var file in model.PostedImage)
                                {
                                    string ext = Path.GetFileName(file.FileName).ToLower();
                                    proImg = (model.CompanyName + " " + model.CompanyLegalStatus).Replace(" ", "_").Replace("-", "_") + ext;
                                    file.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                    fileNames += proImg + ",";
                                }
                                model.Snapshot = Path.GetFileName(fileNames);
                            }

                            if (model.MCARegProofImage != null && model.MCARegProofImage.FileName.ToString() != "")
                            {
                                string proImg = string.Empty;
                                string ext = Path.GetExtension(model.MCARegProofImage.FileName).ToLower();
                                proImg = (model.CompanyName + " " + "MCARegProof").Replace(" ", "_").Replace("-", "_") + ext;
                                model.MCARegProofImage.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.MCARegProof = Path.GetFileName(proImg);
                            }
                            if (model.InitAddProofImage != null && model.InitAddProofImage.FileName.ToString() != "")
                            {
                                string proImg = string.Empty;
                                string ext = Path.GetExtension(model.InitAddProofImage.FileName).ToLower();
                                proImg = (model.CompanyName + " " + "PVInitAtAddress").Replace(" ", "_").Replace("-", "_") + ext;
                                model.InitAddProofImage.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.PVInitAtAddressProof = Path.GetFileName(proImg);
                            }
                            if (model.OtherDocProofImage != null && model.OtherDocProofImage.FileName.ToString() != "")
                            {
                                string proImg = string.Empty;
                                string ext = Path.GetExtension(model.OtherDocProofImage.FileName).ToLower();
                                proImg = (model.CompanyName + " " + "OtherDocumentNo").Replace(" ", "_").Replace("-", "_") + ext;
                                model.OtherDocProofImage.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.OtherDocProof = Path.GetFileName(proImg);
                            }
                            #endregion

                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.OfficialEmailId != null && model.OfficialEmailId.Length > 0)
                            {
                                string[] arrEmails = model.OfficialEmailId.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.OfficialEmailId = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion

                            if (flag)
                            {
                                model.ModifiedDate = DateTime.Now;
                                repoEmployer.UpdateEmployer(model);
                                int Res = repoEmployer.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Edited Successfully!";
                                    ModelState.Clear();

                                    if (bynd)
                                    {
                                        return RedirectToAction("ManageBeyondEmployers"); 
                                    }
                                    else
                                    {
                                        return RedirectToAction("ManageEmployers");
                                    }
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is no change!";
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Employer name could not be blank!");
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
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindMandatoryDocumentList();
            BindCompanyStatusList();
            BindCompanyLegalStatusList();
            BindModeOfInitiationList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult EmployerActive(string checkeds = "", short id = 0)
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
                    repoEmployer.ActiveEmployer(id, checkeds);
                    int Res = repoEmployer.SaveChanges();
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
        public ActionResult EmployerDetails(short id = 0)
        {
            EmployerViewModel model = new EmployerViewModel();
            try
            {
                model = repoEmployer.GetEmployerForDetailsById(id);

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
        public void ExportEmployer()
        {
            try
            {
                var data = repoEmployer.GetEmployeresForExport();
                ExportToExcel(data, "Employeres");
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ******** Police station ********************

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddPoliceStation()
        {
            try
            {
                BindCountry();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindModeOfInitiationList();
                BindPoliceMandatoryList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
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
        public ActionResult AddPoliceStation(AddPoliceStationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PoliceStationName != null && model.PoliceStationName.Trim().Length > 0)
                    {
                        if (!repoPoliceStation.IsPoliceStationExist(model.PoliceStationName.Trim()))
                        {
                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.OfficialEmailId != null && model.OfficialEmailId.Length > 0)
                            {
                                string[] arrEmails = model.OfficialEmailId.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.OfficialEmailId = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion
                            if (flag)
                            {
                                repoPoliceStation.AddStationRepository(model);
                                int Res = repoPoliceStation.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManagePoliceStation");
                                }
                                {
                                    ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Police Station Name could not be blank!");
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
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindModeOfInitiationList();
            BindPoliceMandatoryList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManagePoliceStation(int page = 1, string sort = "", string sortDir = "desc", string Search = "")
        {
            PoliceStationListPagedModel model = new PoliceStationListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoPoliceStation.GetPoliceStation(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditPoliceStation(short id = 0)
        {
            UpdatePoliceStationViewModel model = new UpdatePoliceStationViewModel();
            try
            {

                BindCountry();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindModeOfInitiationList();
                BindPoliceMandatoryList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();

                model = repoPoliceStation.GetPoliceStationrForUpdateById(id);


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
        public ActionResult EditPoliceStation(UpdatePoliceStationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.PoliceStationName != null && model.PoliceStationName.Trim().Length > 0 && model.PoliceStationRowID > 0)
                    {
                        if (!repoPoliceStation.IsPoliceStationExist(model.PoliceStationRowID, model.PoliceStationName.Trim()))
                        {
                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.OfficialEmailId != null && model.OfficialEmailId.Length > 0)
                            {
                                string[] arrEmails = model.OfficialEmailId.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.OfficialEmailId = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion

                            if (flag)
                            {
                                repoPoliceStation.UpdatePoliceStation(model);
                                int Res = repoPoliceStation.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Edited Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManagePoliceStation");
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is no change!";
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Police Station name could not be blank!");
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
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindModeOfInitiationList();
            BindPoliceMandatoryList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult PoliceStationActive(string checkeds = "", short id = 0)
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
                    repoPoliceStation.ActivePoliceStation(id, checkeds);
                    int Res = repoPoliceStation.SaveChanges();
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

       

        public void ExportPoliceStation()
        {
            try
            {

                var data = repoPoliceStation.GetPoliceStationsForExport();
                ExportToExcel(data, "PoliceStations");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult PoliceStationDetails(short id = 0)
        {
            PoliceStationViewModel model = new PoliceStationViewModel();
            try
            {
                model = repoPoliceStation.GetPoliceStationForDetailsById(id);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return View(model);
        }

        #endregion

        #region ********** Vendor Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddVendor()
        {
            try
            {
                BindCountry();
                BindPincodeList();
                BindModeOfPaymentList();
                //BindAdditionalCostingList();
                BindMandatoryDocumentList();
                BindModeOfInitiationList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
                BindCoverageCheckList();
                BindAuditStatusList();
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
        public ActionResult AddVendor(AddVendorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.VendorName != null && model.VendorName.Trim().Length > 0)
                    {
                        if (!repoVendor.IsVendorExist(model.VendorName.Trim()))
                        {
                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["MasterVendorDocs"].ToString();
                            string proImg = string.Empty;
                            if (model.AgreementDocImage != null && model.AgreementDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.AgreementDocImage.FileName).ToLower();
                                proImg = (model.VendorName + " " + model.PanNo).Replace(" ", "_").Replace("-", "_") + ext;
                                model.AgreementDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.AgreementDocs = Path.GetFileName(proImg);
                            }

                            string proImg1 = string.Empty;
                            if (model.ServiceTaxCertificateDocImage != null && model.ServiceTaxCertificateDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.ServiceTaxCertificateDocImage.FileName).ToLower();
                                proImg1 = (model.VendorName + " " + "ServiceTaxcertificate").Replace(" ", "_").Replace("-", "_") + ext;
                                model.ServiceTaxCertificateDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg1));
                                model.ServiceTaxCertificateDoc = Path.GetFileName(proImg1);
                            }

                            string proImg2 = string.Empty;
                            if (model.RegistrationCertificateDocImage != null && model.RegistrationCertificateDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.RegistrationCertificateDocImage.FileName).ToLower();
                                proImg2 = (model.VendorName + " " + "RegistrationCertificate").Replace(" ", "_").Replace("-", "_") + ext;
                                model.RegistrationCertificateDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg2));
                                model.RegistrationCertificateDoc = Path.GetFileName(proImg2);
                            }

                            string proImg3 = string.Empty;
                            if (model.IDProofDocImage != null && model.IDProofDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.IDProofDocImage.FileName).ToLower();
                                proImg3 = (model.VendorName + " " + "IDProof").Replace(" ", "_").Replace("-", "_") + ext;
                                model.IDProofDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg3));
                                model.IDProofDoc = Path.GetFileName(proImg3);
                            }

                            string proImg4 = string.Empty;
                            if (model.PanDocImage != null && model.PanDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.PanDocImage.FileName).ToLower();
                                proImg4 = (model.VendorName + " " + "PanDoc").Replace(" ", "_").Replace("-", "_") + ext;
                                model.PanDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg4));
                                model.PanDoc = Path.GetFileName(proImg4);
                            }

                            string proImg5 = string.Empty;
                            if (model.PanDocImage != null && model.PanDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.PanDocImage.FileName).ToLower();
                                proImg5 = (model.VendorName + " " + "OtherDoc").Replace(" ", "_").Replace("-", "_") + ext;
                                model.PanDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg5));
                                model.OtherDocumentDetail = Path.GetFileName(proImg5);
                            }
                            #endregion

                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.VendorEmaiID != null && model.VendorEmaiID.Length > 0)
                            {
                                string[] arrEmails = model.VendorEmaiID.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.VendorEmaiID = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion
                            if (flag)
                            {
                                repoVendor.AddVendor(model);
                                int Res = repoVendor.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    short vid = repoVendor.GetLastVendorIdByName(model.VendorName);
                                    ModelState.Clear();
                                    return RedirectToAction("AddVendorCoverage", new { vid = vid });
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Vendor Name could not be blank!");
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
            BindPincodeList();
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindMandatoryDocumentList();
            BindModeOfInitiationList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            BindCoverageCheckList();
            BindAuditStatusList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageVendors(int page = 1, string sort = "VendorName", string sortDir = "asc", string Search = "")
        {
            VendorListPagedModel model = new VendorListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoVendor.GetVendor(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult EditVendor(short id = 0)
        {
            UpdateVendorViewModel model = new UpdateVendorViewModel();
            try
            {
                BindCountry();
                BindPincodeList();
                BindModeOfPaymentList();
                BindAdditionalCostingList();
                BindMandatoryDocumentList();
                BindModeOfInitiationList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
                BindCoverageCheckList();
                BindAuditStatusList();
                model = repoVendor.GetVendorForUpdateById(id);
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
        public ActionResult EditVendor(UpdateVendorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.VendorName != null && model.VendorName.Trim().Length > 0 && model.VendorRowID > 0)
                    {
                        if (!repoVendor.IsVendorExist(model.VendorRowID, model.VendorName.Trim()))
                        {
                            #region Image Upload
                            string FldPathDoc = ConfigurationManager.AppSettings["MasterVendorDocs"].ToString();
                            string proImg = string.Empty;
                            if (model.AgreementDocImage != null && model.AgreementDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.AgreementDocImage.FileName).ToLower();
                                proImg = (model.VendorName + " " + model.PanNo).Replace(" ", "_").Replace("-", "_") + ext;
                                model.AgreementDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg));
                                model.AgreementDocs = Path.GetFileName(proImg);
                            }

                            string proImg1 = string.Empty;
                            if (model.ServiceTaxCertificateDocImage != null && model.ServiceTaxCertificateDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.ServiceTaxCertificateDocImage.FileName).ToLower();
                                proImg1 = (model.VendorName + " " + "ServiceTaxcertificate").Replace(" ", "_").Replace("-", "_") + ext;
                                model.ServiceTaxCertificateDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg1));
                                model.ServiceTaxCertificateDoc = Path.GetFileName(proImg1);
                            }

                            string proImg2 = string.Empty;
                            if (model.RegistrationCertificateDocImage != null && model.RegistrationCertificateDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.RegistrationCertificateDocImage.FileName).ToLower();
                                proImg2 = (model.VendorName + " " + "RegistrationCertificate").Replace(" ", "_").Replace("-", "_") + ext;
                                model.RegistrationCertificateDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg2));
                                model.RegistrationCertificateDoc = Path.GetFileName(proImg2);
                            }

                            string proImg3 = string.Empty;
                            if (model.IDProofDocImage != null && model.IDProofDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.IDProofDocImage.FileName).ToLower();
                                proImg3 = (model.VendorName + " " + "IDProof").Replace(" ", "_").Replace("-", "_") + ext;
                                model.IDProofDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg3));
                                model.IDProofDoc = Path.GetFileName(proImg3);
                            }

                            string proImg4 = string.Empty;
                            if (model.PanDocImage != null && model.PanDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.PanDocImage.FileName).ToLower();
                                proImg4 = (model.VendorName + " " + "PanDoc").Replace(" ", "_").Replace("-", "_") + ext;
                                model.PanDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg4));
                                model.PanDoc = Path.GetFileName(proImg4);
                            }

                            string proImg5 = string.Empty;
                            if (model.PanDocImage != null && model.PanDocImage.FileName.ToString() != "")
                            {
                                string ext = Path.GetExtension(model.PanDocImage.FileName).ToLower();
                                proImg5 = (model.VendorName + " " + "OtherDoc").Replace(" ", "_").Replace("-", "_") + ext;
                                model.PanDocImage.SaveAs(Server.MapPath(FldPathDoc + proImg5));
                                model.OtherDocumentDetail = Path.GetFileName(proImg5);
                            }
                            #endregion
                            #region ***** Email Validation Code *****

                            string CorrectEmails = string.Empty;
                            string InvalidCorrectEmails = string.Empty;
                            bool flag = true;

                            if (model.VendorEmaiID != null && model.VendorEmaiID.Length > 0)
                            {
                                string[] arrEmails = model.VendorEmaiID.Split(',');
                                if (arrEmails.Length > 0)
                                {
                                    foreach (string item in arrEmails)
                                    {
                                        if (clsValidationMethods.IsValidEmail(item))
                                        {
                                            CorrectEmails += item + ",";
                                        }
                                        else
                                        {
                                            InvalidCorrectEmails += item + ",";
                                            flag = false;
                                        }
                                    }

                                    if (flag)
                                    {
                                        model.VendorEmaiID = CorrectEmails.Remove(CorrectEmails.Length - 1, 1);
                                    }
                                    else
                                    {
                                        InvalidCorrectEmails = InvalidCorrectEmails.Remove(InvalidCorrectEmails.Length - 1, 1);
                                        ViewBag.ErrorMsg = "Invalid email id's : " + InvalidCorrectEmails;
                                    }
                                }
                            }

                            #endregion

                            if (flag)
                            {
                                repoVendor.UpdateVendor(model);
                                int Res = repoVendor.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Edited Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManageVendors");
                                }
                                else
                                {
                                    ViewBag.ErrorMsg = "There is no change!";
                                }
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Vendor name could not be blank!");
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
            BindPincodeList();
            BindModeOfPaymentList();
            BindAdditionalCostingList();
            BindMandatoryDocumentList();
            BindModeOfInitiationList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            BindCoverageCheckList();
            BindAuditStatusList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult VendorDetails(short id = 0)
        {
            VendorViewModel model = new VendorViewModel();
            try
            {
                model = repoVendor.GetVendorForDetailsById(id);

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
        public JsonResult VendorActive(string checkeds = "", short id = 0)
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
                    repoVendor.ActiveVendor(id, checkeds);
                    int Res = repoVendor.SaveChanges();
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
        public ActionResult GetStateCheckBoxList(short id = 0)
        {
            StateCheckBoxList CheckItem = new StateCheckBoxList();
            try
            {
                CheckItem = repoState.GetStatesForCheckbox(id);
            }
            catch (Exception Ex)
            {

                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return PartialView("_CoverageStates", CheckItem);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportVendor()
        {
            try
            {
                var data = repoVendor.GetVendoresForExport();
                ExportToExcel(data, "Vendores");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult GetDistrictForCheckbox(short countryRowID = 0, string CoverageStateIds = "", string CoverageDistrictIds = "")
        {
            DistrictCheckBoxList CheckItem = new DistrictCheckBoxList();
            try
            {
                if (!string.IsNullOrEmpty(CoverageStateIds))
                {
                    short[] StateIds = CoverageStateIds.Split(',').Select(str => short.Parse(str)).ToArray();

                    CheckItem.checkBoxList = repoDistrict.GetDistrictForCheckbox(countryRowID, StateIds);
                    if (!string.IsNullOrEmpty(CoverageDistrictIds))
                    {
                        string[] DistrictIds = CoverageDistrictIds.Split(',');
                        foreach (var data in CheckItem.checkBoxList)
                        {
                            foreach (var ab in DistrictIds)
                            {
                                //string[] DistrictId = ab.Split('_');
                                if (data.DistrictRowID == short.Parse(ab)) { data.DistrictIsChecked = true; }
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
            return PartialView("_CoverageDistricts", CheckItem);
        }
        #endregion

        #region ************** Vender login *************
        [SessionExpireFilterAttribute]
        public ActionResult ManageVenderLogin(int vid = 0, int page = 1, string sort = "userid", string sortDir = "asc", string Search = "")
        {
            MasterVendorLoginListPage model = new MasterVendorLoginListPage();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoVendorLogin.GetMasterVendorLogin(vid, page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult AddVenderLogin(short vid = 0)
        {
            AddMasterVendorLoginViewModel model = new AddMasterVendorLoginViewModel();
            try
            {
                if (vid > 0)
                {
                    var vendor = repoVendorLogin.GetMasterVendorNameMobile(vid);
                    model.VendorRowID = vid;
                    model.ContactPerson = vendor.ContactPerson;
                    model.MobileNo = vendor.MobileNo;
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid id's";
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
        public ActionResult AddVenderLogin(AddMasterVendorLoginViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.UserID != null && model.UPass.Trim().Length > 0)
                    {
                        if (!repoVendorLogin.IsMasterVendorLoginExist(model.UserID.Trim()))
                        {
                            string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(model.UPass.Trim());
                            model.UPass = EncryptedPasswd;
                            model.Status = 1;
                            model.ModifiedTime = DateTime.Now;
                            model.CreatedTime = DateTime.Now;
                            model.CreatedBy = "Company";
                            repoVendorLogin.AddVendorLogin(model);
                            int Res = repoVendorLogin.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();

                                return RedirectToAction("ManageVenderLogin", new { vid = model.VendorRowID });
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
                        ModelState.AddModelError("", "Vendor Login could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditVenderLogin(int id = 0)
        {
            UpdateMasterVendorLoginViewModel model = new UpdateMasterVendorLoginViewModel();
            try
            {
                if (id > 0)
                {
                    model = repoVendorLogin.GetMasterVendorLoginrForUpdateById(id);
                    string DcryptedPasswd = clsCommonMethods.PasswordDecrypt(model.UPass.Trim());
                    model.UPass = DcryptedPasswd;
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid id's";
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
        public ActionResult EditVenderLogin(UpdateMasterVendorLoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.UserID != null && model.VendorRowID > 0)
                    {
                        if (!repoVendorLogin.IsMasterVendorLoginExist(model.VendorLoginRowID, model.UserID))
                        {
                            string EncryptedPasswd = clsCommonMethods.PasswordEncrypt(model.UPass.Trim());
                            model.UPass = EncryptedPasswd;
                            model.ModifiedTime = DateTime.Now;
                            model.CreatedBy = "Company";
                            repoVendorLogin.UpdateMasterVendorLogin(model);
                            int Res = repoVendorLogin.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();

                                return RedirectToAction("ManageVenderLogin", new { vid = model.VendorRowID });
                            }
                            else
                            {
                                ViewBag.ErrorMsg = "There is no changes!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Record Already Exist!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Vender Login could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult VenderLoginActive(string checkeds = "", short id = 0)
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
                    repoVendorLogin.ActiveMasterVendorLogin(id, checkeds);
                    int Res = repoVendorLogin.SaveChanges();
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

        #region ********** Vendor Coverage Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddVendorCoverage(short vid = 0)
        {
            AddVendorCoverageViewModel model = new AddVendorCoverageViewModel();
            try
            {
                BindCountry();
                BindAddCostingList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
                BindCoverageCheckList();
                ViewBag.VendorName = repoVendor.GetVendorForUpdateById(vid).VendorName;
                model.VendorRowID = vid;
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
        public ActionResult AddVendorCoverage(FormCollection form, AddVendorCoverageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.VendorRowID > 0)
                    {
                        if (!string.IsNullOrEmpty(model.CoverageStateIds))
                        {
                            string[] CoverageData = model.CoverageStateIds.Split(',');
                            int Res = 0;
                            foreach (var item in CoverageData)
                            {
                                Res = 0;
                                string[] data = item.Split('_');
                                string VCost = "VCost_" + item;
                                model.StateRowID = short.Parse(item);
                                if (!repoVendorCoverage.IsCoverageChecksExist(model.VendorRowID, model.CheckFamilyRowID, model.StateRowID))
                                {
                                    if (!string.IsNullOrEmpty(form[VCost]))
                                    {
                                        model.VendorCost = Convert.ToDouble(form[VCost]);

                                        repoVendorCoverage.AddVendorCoverage(model);
                                        Res = repoVendorCoverage.SaveChanges();
                                    }
                                    else
                                    {
                                        ViewBag.ErrorMsg = "Vendor cost could not be blank for state: " + repoState.GetStateForUpdateById(model.StateRowID).StateName + "! <br />";
                                        break;
                                    }
                                }
                            }
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                short vid = model.VendorRowID;
                                ModelState.Clear();
                                return RedirectToAction("ManageVendorCoverages", new { vid = vid });
                            }
                            else
                            {
                                ViewBag.ErrorMsg += "Record not save. Please try again later!";
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Please select atleast one District for each selected State!";
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Vendor does not exist!");
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
            BindAddCostingList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            BindCoverageCheckList();
            ViewBag.VendorName = repoVendor.GetVendorForUpdateById(model.VendorRowID).VendorName;
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageVendorCoverages(int page = 1, string sort = "CheckFamily", string sortDir = "", string Search = "", short vid = 0)
        {
            VendorCoverageListPagedModel model = new VendorCoverageListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                ViewBag.VendorName = repoVendor.GetVendorForUpdateById(vid).VendorName;
                model = repoVendorCoverage.GetVendorCoverages(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, vid);
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
        public ActionResult EditVendorCoverage(int id = 0)
        {
            UpdateVendorCoverageViewModel model = new UpdateVendorCoverageViewModel();
            try
            {
                BindCountry();
                BindAddCostingList();
                BindVarificationTATLevel1();
                BindVarificationTATLevel2();
                BindCoverageCheckList();
                model = repoVendorCoverage.GetVendorCoverageForUpdateById(id);
                var data = repoVendorCoverage.GetVendorCoverageForUpdateById(id);
                if (model != null)
                {
                    ViewBag.VendorName = repoVendor.GetVendorForUpdateById(model.VendorRowID).VendorName;
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
        public ActionResult EditVendorCoverage(UpdateVendorCoverageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CheckFamilyRowID > 0 && model.VendorRowID > 0)
                    {
                        repoVendorCoverage.UpdateVendorCoverage(model);
                        int Res = repoVendorCoverage.SaveChanges();

                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Edited Successfully!";
                            short vid = model.VendorRowID;
                            ModelState.Clear();
                            return RedirectToAction("ManageVendorCoverages", new { vid = vid });
                        }
                        else
                        {
                            ViewBag.ErrorMsg += "Record not save. Please try again later!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ivalid Vendor Coverage Id!");
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
            BindAddCostingList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            BindCoverageCheckList();
            model = repoVendorCoverage.GetVendorCoverageForUpdateById(model.VendorCoverageRowID);
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult VendorCoverageActive(string checkeds = "", short id = 0)
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
                    repoVendorCoverage.ActiveVendorCoverage(id, checkeds);
                    int Res = repoVendorCoverage.SaveChanges();
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
        public void ExportVendorCoverage()
        {
            try
            {

                var data = repoVendor.GetVendoresForExport();
                ExportToExcel(data, "Vendores");
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
        }

        #endregion

        #region ********** Vendor Coverage District Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddVendorCoverageDistrict(short vid = 0, int vcoverageid = 0)
        {
            AddVCDistrictViewModel model = new AddVCDistrictViewModel();
            try
            {
                ViewBag.VendorName = repoVendor.GetVendorForUpdateById(vid).VendorName;
                var VCoverageData = repoVendorCoverage.GetVendorCoverageForUpdateById(vcoverageid);
                var VCDistrict = repoVCoverageDistrict.GetVendorCoverageDistricts();
                foreach (var item in VCDistrict)
                {
                    if (item.VendorCoverageRowID == vcoverageid)
                    {
                        model.CoverageDistrictIds += Convert.ToString(item.DistrictRowID) + ",";
                    }
                }
                if (model.CoverageDistrictIds != null)
                {
                    model.CoverageDistrictIds = model.CoverageDistrictIds.Substring(0, model.CoverageDistrictIds.Length - 1);
                }
                else
                {
                    model.CoverageDistrictIds = "";
                }

                model.CountryRowID = VCoverageData.CountryRowID;
                model.CountryName = repoCountry.GetCountryForUpdateById(VCoverageData.CountryRowID).CountryName;
                model.StateRowID = VCoverageData.StateRowID;
                model.StateName = repoState.GetStateForUpdateById(VCoverageData.StateRowID).StateName;
                model.VendorRowID = vid;
                model.VendorCoverageRowID = vcoverageid;
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
        public ActionResult AddVendorCoverageDistrict(AddVCDistrictViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.VendorRowID > 0)
                    {
                        if (!string.IsNullOrEmpty(model.CoverageDistrictIds))
                        {
                            string[] CoverageData = model.CoverageDistrictIds.Split(',');
                            int Res = 0;
                            bool alReadySave = false;
                            foreach (var item in CoverageData)
                            {
                                model.DistrictRowID = Convert.ToInt16(item);
                                alReadySave = true;
                                if (!repoVCoverageDistrict.IsVCCoverageChecksExist(model.VendorCoverageRowID, model.DistrictRowID))
                                {
                                    repoVCoverageDistrict.AddVendorCoverageDistrict(model);
                                    Res = repoVCoverageDistrict.SaveChanges();
                                    if (Res == 0)
                                    {
                                        alReadySave = false;
                                        ViewBag.ErrorMsg += "Record not save. Please try again later!";
                                    }
                                }
                            }
                            if (alReadySave == true)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                short vid = model.VendorRowID;
                                int vcoverageid = model.VendorCoverageRowID;
                                ModelState.Clear();
                                return RedirectToAction("ManageVendorCoverageDistricts", new { vid = vid, vcoverageid = vcoverageid });
                            }
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "Please select atleast one District for each selected State!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Vendor does not exist!");
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
            BindAddCostingList();
            BindVarificationTATLevel1();
            BindVarificationTATLevel2();
            BindCoverageCheckList();
            model.CoverageDistrictIds = "";
            ViewBag.VendorName = repoVendor.GetVendorForUpdateById(model.VendorRowID).VendorName;
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageVendorCoverageDistricts(int page = 1, string sort = "VendorName", string sortDir = "asc", string Search = "", short vid = 0, int vcoverageid = 0)
        {
            VCDistrictListPagedModel model = new VCDistrictListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                ViewBag.VendorName = repoVendor.GetVendorForUpdateById(vid).VendorName;

                model = repoVCoverageDistrict.GetVendorCoverageDistricts(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, vcoverageid);
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
        public JsonResult VendorCoverageDistrictActive(string checkeds = "", short id = 0)
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
                    repoVCoverageDistrict.ActiveVendorCoverageDistrict(id, checkeds);
                    int Res = repoVCoverageDistrict.SaveChanges();
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

        //[HttpGet]
        //[SessionExpireFilterAttribute]
        //public void ExportVendorCoverageDistrict()
        //{
        //    // Step 1 - get the data from database
        //    var data = repoVendor.GetVendoresForExport();
        //    ExportToExcel(data, "Vendores");
        //}

        //[HttpGet]
        //[SessionExpireFilterAttribute]
        //public ActionResult EditVendorCoverageDistrict(int id = 0, short vid = 0, int vcoverageid = 0)
        //{
        //    UpdateVCDistrictViewModel model = new UpdateVCDistrictViewModel();
        //    try
        //    {
        //        BindCountry();
        //        BindAddCostingList();
        //        BindVarificationTATLevel1();
        //        BindVarificationTATLevel2();
        //        BindCoverageCheckList();
        //        model = repoVCoverageDistrict.GetVendorCoverageDistrictForUpdateById(id);
        //        model.VendorRowID = vid;
        //        model.VendorCoverageRowID = vcoverageid;
        //        if (model != null)
        //        {
        //            ViewBag.VendorName = repoVendor.GetVendorForUpdateById(model.VendorRowID).VendorName;
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        ViewBag.ErrorMsg = Ex.Message;
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //[SessionExpireFilterAttribute]
        //public ActionResult EditVendorCoverageDistrict(UpdateVCDistrictViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (!string.IsNullOrEmpty(model.CoverageDistrictIds))
        //            {
        //                string[] CoverageData = model.CoverageDistrictIds.Split(',');
        //                int Res = 0;
        //                foreach (var item in CoverageData)
        //                {
        //                    Res = 0;
        //                    model.DistrictRowID = Convert.ToInt16(item);
        //                    if (!repoVCoverageDistrict.IsVCCoverageChecksExist(model.VendorCoverageRowID, model.DistrictRowID))
        //                    {
        //                        repoVCoverageDistrict.UpdateVendorCoverageDistrict(model);
        //                        Res = repoVCoverageDistrict.SaveChanges();
        //                    }
        //                }
        //                if (Res > 0)
        //                {
        //                    TempData["SuccessMsg"] = "Record Edit Successfully!";
        //                    short vid = model.VendorRowID;
        //                    int vcoverageid = model.VendorCoverageRowID;
        //                    ModelState.Clear();
        //                    return RedirectToAction("ManageVendorCoverageDistricts", new { vid = vid, vcoverageid = vcoverageid });
        //                }
        //                else
        //                {
        //                    ViewBag.ErrorMsg += "Record not save. Please try again later!";
        //                }
        //            }
        //            else
        //            {
        //                ViewBag.ErrorMsg = "Please select atleast one District for each selected State!";
        //            }
        //        }
        //        else
        //        {
        //            var query = from state in ModelState.Values
        //                        from error in state.Errors
        //                        select error.ErrorMessage;

        //            var errorList = query.ToList();
        //            string strError = string.Empty;
        //            foreach (string str in errorList)
        //            {
        //                strError += str + "\n";
        //            }
        //            ModelState.AddModelError("", strError);
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        ViewBag.ErrorMsg = Ex.Message;
        //    }
        //    BindCountry();
        //    BindAddCostingList();
        //    BindVarificationTATLevel1();
        //    BindVarificationTATLevel2();
        //    BindCoverageCheckList();
        //    model = repoVCoverageDistrict.GetVendorCoverageDistrictForUpdateById(model.VendorCoverageRowID);
        //    return View(model);
        //}       

        #endregion

        #region************Disposition*********************

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageDisposition(int page = 1, string sort = "Disposition", string sortDir = "asc", short CheckFamilyRowID = 0, string Search = "")
        {
            DispositionListPagedModel model = new DispositionListPagedModel();
            try
            {

                int pageSize = clsGlobalCommon.PageSize;
                model = repoDisposition.GetDisposition(page, pageSize, sort.ToLower(), sortDir.ToLower(), CheckFamilyRowID, Search);
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
            BindCheckFamilyList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddDisposition()
        {
            BindCheckFamilyList();
            BindSeverityGrid();
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddDisposition(AddDispositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Disposition != null && model.Disposition.Trim().Length > 0)
                    {
                        repoDisposition.AddDisposition(model);
                        int Res = repoDisposition.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Added Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageDisposition");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Disposition could not be blank!");
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
            BindCheckFamilyList();
            BindSeverityGrid();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditDisposition(short id = 0)
        {
            UpdateDispositionViewModel model = new UpdateDispositionViewModel();
            try
            {
                BindCheckFamilyList();
                BindSeverityGrid();
                model = repoDisposition.GetDispositionForUpdateById(id);
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
        public ActionResult EditDisposition(UpdateDispositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Disposition != null && model.Disposition.Trim().Length > 0 && model.DispositionRowId > 0)
                    {
                        repoDisposition.UpdateDisposition(model);
                        int Res = repoDisposition.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Update Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageDisposition");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Disposition could not be blank!");
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
            BindCheckFamilyList();
            BindSeverityGrid();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DispositionActive(string checkeds = "", short id = 0)
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
                    repoDisposition.ActiveDisposition(id, checkeds);
                    int Res = repoDisposition.SaveChanges();
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
        public JsonResult DispositionSetDefault(string checkeds = "", short id = 0)
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
                    repoDisposition.SetDefaultDisposition(id, checkeds);
                    int Res = repoDisposition.SaveChanges();
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

        [HttpPost]
        [SessionExpireFilterAttribute]
        public JsonResult GetDispositionTestAutoComplete(string Disposition, short hdnChkId)
        {
            var DispositonAutoComplete = new List<DispositionViewModel>();
            try
            {
                DispositonAutoComplete = repoDisposition.GetDispositionAutoComplete(Disposition, hdnChkId).ToList();
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }

            return Json(DispositonAutoComplete, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportDisposition()
        {
            // Step 1 - get the data from database
            var data = repoDisposition.GetDispositionsForExport();
            ExportToExcel(data, "Dispositions");
        }

        #endregion

        #region ************Severity Grid**********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageSeverityGrid(int page = 1, string sort = "", string sortDir = "asc", string Search = "")
        {
            SeverityGridListPagedModel model = new SeverityGridListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoSeverityGrid.GetSeverityGrid(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
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
        public ActionResult AddSeverityGrid()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddSeverityGrid(AddSeverityGridViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.SeverityGrid != null && model.ColorCode != null && model.SeverityGrid.Trim().Length > 0 && model.ColorCode.Trim().Length > 0)
                    {
                        if (!repoSeverityGrid.IsSeverityGridExist(model.SeverityGrid.Trim()))
                        {
                            repoSeverityGrid.AddSeverityGrid(model);
                            int Res = repoSeverityGrid.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Added Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageSeverityGrid");
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
                        ModelState.AddModelError("", "Branch Name could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditSeverityGrid(short id = 0)
        {
            UpdateSeverityGridViewModel model = new UpdateSeverityGridViewModel();
            try
            {
                model = repoSeverityGrid.GetSeverityGridForUpdateById(id);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }
            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult EditSeverityGrid(UpdateSeverityGridViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.SeverityGrid != null && model.ColorCode != null && model.SeverityGrid.Trim().Length > 0 && model.ColorCode.Trim().Length > 0 && model.SeverityGridRowId > 0)
                    {
                        if (!repoSeverityGrid.IsSeverityGridExist(model.SeverityGrid.Trim(), model.SeverityGridRowId))
                        {
                            repoSeverityGrid.UpdateSeverityGrid(model);
                            int Res = repoSeverityGrid.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Update Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageSeverityGrid");
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
                        ModelState.AddModelError("", "Branch Name could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult DeleteSeverityGrid(short id = 0)
        {
            bool result = false;
            try
            {
                if (id > 0)
                {
                    repoSeverityGrid.DeleteSeverityGrid(id);
                    int Res = repoSeverityGrid.SaveChanges();
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
        public JsonResult SeverityGridActive(string checkeds = "", short id = 0)
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
                    repoSeverityGrid.ActiveSeverity(id, checkeds);
                    int Res = repoSeverityGrid.SaveChanges();
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
        public void ExportdSeverityGrid()
        {
            // Step 1 - get the data from database
            var data = repoSeverityGrid.GetSeverityGridesForExport();
            ExportToExcel(data, "SeverityGrides");
        }

        #endregion

        #region **************Antecedent**************

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditAntecedent(short id = 0)
        {
            UpdateAntecedentViewModel model = new UpdateAntecedentViewModel();
            try
            {
                AntecedentTypeList();
                BindCheckFamilyList();
                model = repoAntecedent.GetAntecedentForUpdateById(id);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult EditAntecedent(UpdateAntecedentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.FieldName != null && model.FieldName.Trim().Length > 0 && model.AntecedentRowId > 0)
                    {

                        repoAntecedent.UpdateAntecedent(model);
                        int Res = repoAntecedent.SaveChanges();
                        if (Res > 0)
                        {
                            TempData["SuccessMsg"] = "Record Edited Successfully!";
                            ModelState.Clear();
                            return RedirectToAction("ManageAntecedent");
                        }
                        else
                        {
                            ViewBag.ErrorMsg = "There is some problem to save record. Please try again later!";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Antecedent Name could not be blank!");
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
            AntecedentTypeList();
            BindCheckFamilyList();
            return View();
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageAntecedent(int page = 1, string sort = "CheckFamilyName", string sortDir = "asc", string Search = "", short CheckFamilyRowID = 0)
        {
            AntecedentListPageModel model = new AntecedentListPageModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoAntecedent.GetAntecedents(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search, CheckFamilyRowID);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No item found!";
                }
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }
            BindCheckFamilyList();
            return View(model);
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult AntecedentActive(string checkeds = "", short id = 0)
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
                    repoAntecedent.ActiveAntecedent(id, checkeds);
                    int Res = repoAntecedent.SaveChanges();
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
        public JsonResult AntecedentSetDefault(string checkeds = "", short id = 0)
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
                    repoAntecedent.SetDefaultAntecedent(id, checkeds);
                    int Res = repoAntecedent.SaveChanges();
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

        [HttpPost]
        [SessionExpireFilterAttribute]
        public JsonResult GetAntecedentTestAutoComplete(string Antecedent, short hdnChkId)
        {
            try
            {
                var AntecedentTestAutoComplete = repoAntecedent.GetAntecedentAutoComplete(Antecedent, hdnChkId);
                return Json(AntecedentTestAutoComplete, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public void ExportAntecedent()
        {
            // Step 1 - get the data from database
            var data = repoAntecedent.GetAntecedentesForExport();
            ExportToExcel(data, "Antecedentes");
        }

        #endregion

        #region ********** Holiday Master **********

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult ManageHolidays(int page = 1, string sort = "HoliDate", string sortDir = "asc", string Search = "")
        {
            HolidayListPagedModel model = new HolidayListPagedModel();
            try
            {
                int pageSize = clsGlobalCommon.PageSize;
                model = repoHoliday.GetHolidays(page, pageSize, sort.ToLower(), sortDir.ToLower(), Search);
                if (model == null)
                {
                    ViewBag.ErrorMsg = "No record found!";
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
        public void ExportHoliday()
        {
            // Step 1 - get the data from database
            var data = repoHoliday.GetHolidayesForExport();
            ExportToExcel(data, "Holidays");
        }

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult AddHoliday()
        {
            return View();
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult AddHoliday(AddHolidayViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.HoliTitle != null && model.HoliTitle.Trim().Length > 0)
                    {
                        if (model.HoliDate != null)
                        {
                            if (!repoHoliday.IsHolidayExist(model.HoliTitle.Trim(), model.HoliDate))
                            {
                                model.HoliDay = model.HoliDate.DayOfWeek.ToString();
                                model.HoliMonth = model.HoliDate.ToString("MMMM");
                                model.HoliYear = model.HoliDate.Year.ToString();

                                repoHoliday.AddHoliday(model);
                                int Res = repoHoliday.SaveChanges();
                                if (Res > 0)
                                {
                                    TempData["SuccessMsg"] = "Record Added Successfully!";
                                    ModelState.Clear();
                                    return RedirectToAction("ManageHolidays");
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
                            ModelState.AddModelError("", "Holiday Date could not be blank!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Holiday Title could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public ActionResult EditHoliday(short id = 0)
        {
            UpdateHolidayViewModel model = new UpdateHolidayViewModel();
            try
            {
                model = repoHoliday.GetHolidayForUpdateById(id);
            }
            catch (Exception Ex)
            {
                ViewBag.ErrorMsg = Ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        [SessionExpireFilterAttribute]
        public ActionResult EditHoliday(UpdateHolidayViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.HoliTitle != null && model.HoliTitle.Trim().Length > 0)
                    {
                        if (!repoHoliday.IsHolidayExist(model.HoliTitle.Trim(), model.HoliDate, model.HoliRowID))
                        {
                            model.HoliDay = model.HoliDate.DayOfWeek.ToString();
                            model.HoliMonth = model.HoliDate.ToString("MMMM");
                            model.HoliYear = model.HoliDate.Year.ToString();
                            repoHoliday.UpdateHoliday(model);
                            int Res = repoHoliday.SaveChanges();
                            if (Res > 0)
                            {
                                TempData["SuccessMsg"] = "Record Edited Successfully!";
                                ModelState.Clear();
                                return RedirectToAction("ManageHolidays");
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
                        ModelState.AddModelError("", "Holiday Title could not be blank!");
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

        [HttpGet]
        [SessionExpireFilterAttribute]
        public JsonResult HolidayActiveInActive(string checkeds = "", short id = 0)
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
                    repoHoliday.HolidayActiveInActive(id, checkeds);
                    int Res = repoHoliday.SaveChanges();
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
        public JsonResult HolidayIsDefault(string checkeds = "", short id = 0)
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
                    repoHoliday.HolidayIsDefault(id, checkeds);
                    int Res = repoHoliday.SaveChanges();
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

        #region ********** Dropdown Masters **********

        void AntecedentTypeList()
        {
            ViewBag.AntecedentTypeList = repoDDL.GetAntecedentDDL();
        }

        void BindCheckFamilyList()
        {
            var lsitTest = repoDDL.GetCheckFamilyForDDL();
            ViewBag.CheckFamilyList = lsitTest;
        }

        void BindSeverityGrid()
        {
            ViewBag.SeverityGrid = repoDDL.GetSeverityGridDDL();
        }

        void BindCountry()
        {
            ViewBag.Countries = repoDDL.GetCountriesForDDL();
        }

        public JsonResult BindState(short id = 0)
        {
            var States = repoDDL.GetStatesByCountryIdForDDL(id);

            return Json(new SelectList(States.ToArray(), "StateRowID", "StateName"), JsonRequestBehavior.AllowGet);
        }

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

        public void BindVarificationTATLevel1()
        {
            List<SelectListItem> VarificationTAT = new List<SelectListItem>();
            for (int i = 1; i <= 90; i++)
            {
                SelectListItem abc = new SelectListItem();
                abc.Text = i.ToString();
                abc.Value = i.ToString();
                VarificationTAT.Add(abc);
            }
            ViewBag.VarificationTATLevel1 = VarificationTAT;
            //return Json(new SelectList(VarificationTAT, "VerificationTATLevel1", "VerificationTATLevel1"), JsonRequestBehavior.AllowGet);
        }

        public void BindVarificationTATLevel2()
        {
            List<SelectListItem> VarificationTAT = new List<SelectListItem>();
            for (int i = 1; i <= 90; i++)
            {
                SelectListItem abc = new SelectListItem();
                abc.Text = i.ToString();
                abc.Value = i.ToString();
                VarificationTAT.Add(abc);
            }
            ViewBag.VarificationTATLevel2 = VarificationTAT;
            // return Json(new SelectList(VarificationTAT, "VerificationTATLevel2", "VerificationTATLevel2"), JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public void BindCoverageCheckList()
        {
            ViewBag.CoverageCheckList = repoDDL.GetCheckFamilyForDDL();
        }

        [NonAction]
        public void BindAuditStatusList()
        {
            //Prepaid/Online/Cheque/DD/Others
            IEnumerable<SelectListItem> AuditStatusList = new List<SelectListItem> {
            new SelectListItem { Text = "Done", Value = "Done" },
            new SelectListItem { Text = "Pending", Value = "Pending" },
            };
            ViewBag.AuditStatusList = AuditStatusList;
        }

        //public JsonResult BindDesignation(byte id = 0)
        //{
        //    var Designation = repoDDL.GetDesignationsByDepartmentsForDDL(id);

        //    return Json(new SelectList(Designation.ToArray(), "DesignationRowID", "DesignationName"), JsonRequestBehavior.AllowGet);
        //}

        void BindPincodeList()
        {
            //ViewBag.PincodeList = repoDDL.GetPincodesForDDL();
        }

        [NonAction]
        public void BindModeOfPaymentList()
        {
            //Prepaid/Online/Cheque/DD/Others
            IEnumerable<SelectListItem> ModeOfPaymentList = new List<SelectListItem> {
            new SelectListItem { Text = "Prepaid", Value = "Prepaid" },
            new SelectListItem { Text = "Online", Value = "Online" },
            new SelectListItem { Text = "Cheque", Value = "Cheque" },
            new SelectListItem { Text = "DD", Value = "DD" },
            new SelectListItem { Text = "Others", Value = "Others" },
            };
            ViewBag.ModeOfPaymentList = ModeOfPaymentList;
        }

        [NonAction]
        public void BindAdditionalCostingList()
        {
            //Yes/No(If yes, then text box)s
            IEnumerable<SelectListItem> AdditionalCostingList = new List<SelectListItem> {
            new SelectListItem { Text = "Yes", Value = "Yes" },
            new SelectListItem { Text = "No", Value = "No" },
            };
            ViewBag.AdditionalCostingList = AdditionalCostingList;
        }

        [NonAction]
        public void BindAddCostingList()
        {
            //Yes/No(If yes, then text box)s
            IEnumerable<SelectListItem> AdditionalCostingList = new List<SelectListItem> {
            new SelectListItem { Text = "Yes", Value = "1" },
            new SelectListItem { Text = "No", Value = "0" },
            };
            ViewBag.AdditionalCostingList = AdditionalCostingList;
        }

        [NonAction]
        public void BindAffliatiatedfrom()
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

        [NonAction]
        public void BindUniversityStatusList()
        {
            //Fake / Genuine / Shutdown / Shifted / Operation ceased / Small Institute / Others

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

        [NonAction]
        public void BindCompanyStatusList()
        {
            //Genuine / Fake / Watchlisted / Shutdown / Shifted / Others
            IEnumerable<SelectListItem> CompanyStatusList = new List<SelectListItem> {

            new SelectListItem { Text = "Genuine", Value = "Genuine" },
            new SelectListItem { Text = "Fake", Value = "Fake" },
            new SelectListItem { Text = "Watchlisted", Value = "Watchlisted" },
            new SelectListItem { Text = "Shutdown", Value = "Shutdown" },
            new SelectListItem { Text = "Shifted", Value = "Shifted" },
            new SelectListItem { Text = "Others", Value = "Others" },
            };
            ViewBag.CompanyStatusList = CompanyStatusList;
        }

        [NonAction]
        public void BindCompanyLegalStatusList()
        {
            //Shutdown/Shifted/Operation ceased/Not registered/Shop/Propreitorship/Others
            IEnumerable<SelectListItem> CompanyLegalStatusList = new List<SelectListItem> {
             new SelectListItem { Text = "Shutdown", Value = "Shutdown" },
             new SelectListItem { Text = "Shifted", Value = "Shifted" },
             new SelectListItem { Text = "Operation ceased", Value = "Operation ceased" },
             new SelectListItem { Text = "Not registered", Value = "Not registered" },
             new SelectListItem { Text = "Shop", Value = "Shop" },
             new SelectListItem { Text = "Propreitorship", Value = "Propreitorship" },
             new SelectListItem { Text = "Others", Value = "Others" },
            };
            ViewBag.CompanyLegalStatusList = CompanyLegalStatusList;
        }

        [NonAction]
        public void BindModeOfInitiationList()
        {
            //Verbal / Written / ThirdParty / Vendor / Online / Others
            IEnumerable<SelectListItem> InitiationList = new List<SelectListItem> {
            new SelectListItem { Text = "Online", Value = "Online" },
            new SelectListItem { Text = "Offline", Value = "Offline" },
            new SelectListItem { Text = "Verbal", Value = "Verbal" },
            new SelectListItem { Text = "Written", Value = "Written" },
            new SelectListItem { Text = "ThirdParty", Value = "ThirdParty" },
            new SelectListItem { Text = "Vendor", Value = "Vendor" },
            new SelectListItem { Text = "Fax-Letter", Value = "Fax-Letter" },
            new SelectListItem { Text = "Others", Value = "Others" },
            };
            ViewBag.InitiationList = InitiationList;
        }

        [NonAction]
        public void BindMandatoryDocumentList()
        {
            //Reliving letter/Experience Letter/Offer Letter/Salary-slip/Appointment Letter/Confirmation Letter/Service Certificate/Others
            IEnumerable<SelectListItem> MandatoryDocumentList = new List<SelectListItem> {
            new SelectListItem { Text = "Reliving letter", Value = "Reliving letter" },
            new SelectListItem { Text = "Experience Letter", Value = "Experience Letter" },
            new SelectListItem { Text = "Offer Letter", Value = "Offer Letter" },
            new SelectListItem { Text = "Salary-slip", Value = "Salary-slip" },
            new SelectListItem { Text = "Appointment Letter", Value = "Appointment Letter" },
            new SelectListItem { Text = "Confirmation Letter", Value = "Confirmation Letter" },
            new SelectListItem { Text = "Service Certificate", Value = "Service Certificate" },
            new SelectListItem { Text = "Others", Value = "Others" },
            };
            ViewBag.MandatoryDocumentList = MandatoryDocumentList;

        }

        [NonAction]
        public void BindPoliceMandatoryList()
        {
            IEnumerable<SelectListItem> PoliceMandatoryList = new List<SelectListItem>
            {
            new SelectListItem { Text = "PAN Card", Value = "PAN Card", Selected=false },
            new SelectListItem { Text = "Driving Liscense ", Value = "Driving Liscense", Selected=false },
            new SelectListItem { Text = "Passport", Value = "Passport", Selected=false },
            new SelectListItem { Text = "Voter ID", Value = "Voter ID", Selected=false },
            new SelectListItem { Text = "Photo", Value = "Photo", Selected=false },
            new SelectListItem { Text = "Aadhar Card", Value = "Aadhar Card", Selected=false },
            new SelectListItem { Text = "Police Verification form", Value = "Police Verification form", Selected=false },
            new SelectListItem { Text = "Others", Value = "Others", Selected=false },
            };
            ViewBag.AddPoliceMandatoryList = PoliceMandatoryList;
        }

        [NonAction]
        public void BindUniversityList()
        {
            ViewBag.UniversityList = repoDDL.GetUniversityForDDL();
        }

        [NonAction]
        public void BindDepartmentList()
        {
            ViewBag.DepartmentList = repoDDL.GetDepartmentsForDDL();
        }

        //public JsonResult BindPincode(int id = 0)
        //{
        //    var Pincodes = repoDDL.GetPincodesByLocationIdForDDL(id);

        //    return Json(new SelectList(Pincodes.ToArray(), "PincodeRowID", "PinCode"), JsonRequestBehavior.AllowGet);
        //}

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