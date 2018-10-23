using BAL.HRRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ViewModels.HRViewModels;
using WebAppBGV.CommonMethods;

namespace WebAppBGV
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string CookieHeaders = HttpContext.Current.Request.Headers["Cookie"];

            if ((null != CookieHeaders) && (CookieHeaders.IndexOf("ASP.NET_SessionId") >= 0))
            {
                // It is existing visitor, but ASP.NET session is expired
            }
            else
            {
                // It is a new visitor, session was not created before
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    try
                    {
                        string userName = FormsAuthentication.Decrypt(authCookie.Value).Name;
                        string roles = string.Empty;

                        //using (userDbEntities entities = new userDbEntities())
                        //{
                        //    User user = entities.Users.SingleOrDefault(u => u.username == username);

                        //    roles = user.Roles;
                        //}
                        //let us extract the roles from our own custom cookie


                        //Let us set the Pricipal with our user specific details
                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(userName, "Forms"), roles.Split(';'));


                        #region For Customer Authentication

                        //FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        //AdminUserViewModel serializeModel = JsonConvert.DeserializeObject<AdminUserViewModel>(authTicket.UserData);

                        //CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                        //newUser.UserId = serializeModel.UserId;
                        //newUser.UserName = serializeModel.UserName;
                        //newUser.Name = serializeModel.Name;
                        //newUser.Roles = serializeModel.Roles;

                        //HttpContext.Current.User = newUser; 

                        #endregion

                    }
                    catch (Exception Ex)
                    {
                        clsCommonMethods.ErrorLog(Server.MapPath("~\\ErrorLogs\\Logfiles"), Ex.Message, Ex.StackTrace);
                    }
                }               
            }
        }
    }
}
