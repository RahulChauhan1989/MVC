using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppBGV.Security
{
    public class CustomAuthorize : AuthorizeAttribute
    {        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //Pick Roles from Db
                //Permission Table for Pages
                //if (!CurrentUser.IsInRole(Roles))
                //{
                //    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "WebAdmin", action = "UnAuthorize", area = "" }));
                //    return;
                //}
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Index", area = "" }));
                return;
            }
        }
    }
}