using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAppBGV.CommonMethods
{
    public class clsGlobalCommon
    {
        private static string pageSize = ConfigurationManager.AppSettings["PagingSize"].ToString();
        public static int PageSize
        {
            get
            {
                if (!string.IsNullOrEmpty(pageSize) && Convert.ToInt32(pageSize) > 0)
                {
                    return Convert.ToInt32(pageSize);
                }
                else
                {
                    return 50;
                }
            }
        }
    }
}