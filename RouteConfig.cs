using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAppBGV
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebAppBGV.Controllers" }
            );

            routes.MapRoute(
               "DataEntry",
               "{controller}/{action}/client/{ClientRowId}/candidate/{PersonalRowID}/check/{ChFamilRowId}/{subCheckId}",
              new
              {
                  controller = "ProvidedInfo",
                  action = "Index",
                  ClientRowId = UrlParameter.Optional,
                  PersonalRowID = UrlParameter.Optional,
                  ChFamilRowId = UrlParameter.Optional,
                  subCheckId = UrlParameter.Optional
              }
          );

           // routes.MapRoute(
           //    "AddAddressInfo",
           //    "{ProvidedInfo}/{AddAddressInfo}/client/{ClientRowId}/candidate/{PersonalRowID}/check/{ChFamilRowId}/{subCheckId}",
           //    new
           //    {
           //        controller = "ProvidedInfo",
           //        action = "AddAddressInfo",
           //        ClientRowId = UrlParameter.Optional,
           //        PersonalRowID = UrlParameter.Optional,
           //        ChFamilRowId = UrlParameter.Optional,
           //        subCheckId = UrlParameter.Optional
           //    }
           //);
        }
    }
}
