using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SystemManagement.Business.Filters
{
    public class BasicAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {

        #region Properties

        private string authenticationUsername
        {
            get { return ConfigurationManager.AppSettings["AuthenticationUsername"]; }
        }

        private string authenticationPassword
        {
            get { return ConfigurationManager.AppSettings["AuthenticationPassword"]; }
        }

        #endregion Properties

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];
                if (!authenticationUsername.Equals(username)
                    || !authenticationPassword.Equals(password))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }

    }
}
