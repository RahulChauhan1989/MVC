﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAppBGV.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class SessionExpireFilterAttributeCandidate : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;

            // If the browser session or authentication session has expired...
            //if (ctx.Session["CRPUserName"] == null || !filterContext.HttpContext.Request.IsAuthenticated)
            //{
            //    if (filterContext.HttpContext.Request.IsAjaxRequest())
            //    {
            //        // For AJAX requests, we're overriding the returned JSON result with a simple string,
            //        // indicating to the calling JavaScript code that a redirect should be performed.
            //        filterContext.Result = new JsonResult { Data = "_Logon_" };
            //    }
            //    else
            //    {
            //        // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/, which
            //        // simply displays a temporary 5 second notification that they have timed out, and
            //        // will, in turn, redirect to the logon page.
            //        filterContext.Result = new RedirectToRouteResult(
            //            new RouteValueDictionary {
            //            { "Controller", "EdakHome" },
            //            { "Action", "TimeoutRedirect" }
            //            //{ "message","Your Session has been expired." }
            //        });
            //    }
            //}

            if (ctx.Session["CadidateUserName"] == null)
            {
                // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/, which
                // simply displays a temporary 5 second notification that they have timed out, and
                // will, in turn, redirect to the logon page.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "Account" },
                        { "Action", "CandidateTimeoutRedirect" },
                        { "area", "" }
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}