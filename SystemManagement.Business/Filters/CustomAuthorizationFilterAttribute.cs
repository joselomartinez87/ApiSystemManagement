using SystemManagement.Business.Authentication;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SystemManagement.Business.Filters
{

    /// <summary>
    /// 
    /// </summary>
    public class CustomAuthorizationFilterAttribute : AuthorizeAttribute
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            bool isAuthorized = false;
            var autorizacion = HttpContext.Current.Request.Headers["Authorization"];
            if (autorizacion != null && autorizacion.StartsWith("Bearer") && autorizacion.Length > 7)
            {
                var jwtManager = new JwtManager();
                var token = autorizacion.Substring(7, autorizacion.Length - 7);
                var validateTokenOut = jwtManager.ValidateToken(new MethodParameters.Authentication.JwtManager.ValidateTokenIn()
                {
                    token = token
                });
                if (validateTokenOut.tokenInformation != null)
                {
                    var claims = new List<System.Security.Claims.Claim>
                    {
                        new System.Security.Claims.Claim("sessionId", validateTokenOut.tokenInformation.sessionId),
                        new System.Security.Claims.Claim("usrID", validateTokenOut.tokenInformation.usrID)
                    };
                    var identity = new System.Security.Claims.ClaimsIdentity(claims, "Jwt");
                    HttpContext.Current.User = new System.Security.Claims.ClaimsPrincipal(identity);
                    isAuthorized = true;
                }
            }
            return isAuthorized;
        }

    }
}
