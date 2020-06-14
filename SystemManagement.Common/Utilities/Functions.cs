using System;

namespace SystemManagement.Common.Utilities
{
    public class Functions
    {

        public string GetUserIP()
        {
            string ipList = System.Web.HttpContext.Current == null ? "" : System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }
            return System.Web.HttpContext.Current == null ? "" :  System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

    }
}
