using BAL.HRRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.HRViewModels;
using WebAppBGV.CommonMethods;
using WebAppBGV.Security;

namespace WebAppBGV.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        ITeamDepartmentRepository repoTeamDept;
        public HomeController(ITeamDepartmentRepository _repoTeamDept)
        {
            repoTeamDept = _repoTeamDept;
        }

        // GET: Home
        [SessionExpireFilterAttribute]
        public ActionResult SelectDesignation()
        {
            //List<TeamDepartmentViewModel> model = repoTeamDept.GetTeamDepartmentsWithDesignationsById(Convert.ToInt16(Session["TeamMemberRowID"])).ToList();
            ViewBag.TeamDepartments = repoTeamDept.GetTeamDepartmentsWithDesignationsById(Convert.ToInt16(Session["TeamMemberRowID"])).ToList();
            return View();
        }

        // GET: Home
        [SessionExpireFilterAttribute]
        public ActionResult Index()
        {            
            return View();
        }

        [SessionExpireFilterAttribute]
        public ActionResult RedirectToDashboard(short teamdeptid = 0)
        {
            try
            {
                var model = repoTeamDept.GetDepartmentWithDesignationById(teamdeptid);
                if (model != null)
                {
                    Session["DepartmentRowID"] = model.DepartmentRowID;
                    Session["Department"] = model.DepartmentName.Trim();
                    Session["DesignationRowID"] = model.DesignationRowID;
                    Session["Designation"] = model.DesignationName.Trim();

                    if (model.DepartmentName == "Admin" || Session["Department"].ToString() == "HR")
                    {
                        return RedirectToAction("Index");
                    }
                    else if (model.DepartmentName == "Data Entry")
                    {
                        return RedirectToAction("Index", "ProvidedInfo");
                    }
                    else if (model.DesignationName == "Team Member-Edu-Research")
                    {
                        return RedirectToAction("ManageResearchEducationChecks", "ProvidedInfo");
                    }
                    else if (model.DesignationName == "Team Member-Emp-Research")
                    {
                        return RedirectToAction("ManageResearchEmploymentChecks", "ProvidedInfo");
                    }
                    else if (model.DepartmentName == "Address" || model.DepartmentName == "Education" || model.DepartmentName == "Employment" || model.DepartmentName == "Reference" || model.DepartmentName == "Criminal" || model.DepartmentName == "National Identity" || model.DepartmentName == "Special Check")
                    {
                        return RedirectToAction("Index", "Verification");
                    }
                    else if (model.DepartmentName == "Physical Verification")
                    {
                        return RedirectToAction("Index", "PVerification");
                    }
                    else if (model.DepartmentName == "Report QC")
                    {
                        return RedirectToAction("Index", "ReportQC");
                    }
                    else if (model.DepartmentName == "Client Servicing")
                    {
                        return RedirectToAction("Index", "ClientServicing");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }                     
               
            }
            catch (Exception Ex)
            {
                TempData["ErrorMsg"] = Ex.Message;
                clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
            }
            return RedirectToAction("SelectDesignation");
        }
    }
}