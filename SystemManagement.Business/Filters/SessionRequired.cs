using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Unity;

namespace SystemManagement.Business.Filters
{
    public class SessionRequired : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext context)
        {
            var request = HttpContext.Current.Request.InputStream;
            string input = new System.IO.StreamReader(request).ReadToEnd();
            JObject inputJson = JObject.Parse(input);
            string sesId = (string)inputJson["currentSesId"];
            decimal userId = (decimal)inputJson["currentUser"]["usrID"];

            if (!ValidateSession(sesId, userId))
            {
                //var output = Activator.CreateInstance(context.ActionDescriptor.ReturnType);
                var output = new MethodParameters.Common.BaseOut();
                ((MethodParameters.Common.BaseOut)output).result = Entities.Common.Result.InvalidSession;
                ((MethodParameters.Common.BaseOut)output).message = "Información de la sessión de usuario no valida";
                context.Response = context.Request.CreateResponse(HttpStatusCode.OK, output);
                return;
            }
        }

        private bool ValidateSession(string sesId, decimal userId)
        {
            bool sessionValid = false;
            UnityContainer container = new UnityContainer();
            var authentication = new SystemManagement.Business.Authentication.Authentication();
            var validateSession = authentication.ValidateSession(new MethodParameters.Authentication.ValidateSessionIn()
            {
                sessionId = sesId,
                userId = userId
            });
            sessionValid = validateSession.result == Entities.Common.Result.Success;
            return sessionValid;
        }

    }
}