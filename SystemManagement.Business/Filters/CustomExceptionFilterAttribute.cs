using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace SystemManagement.Business.Filters
{

    /// <summary>
    /// Filtro de captura de excepciones no controladas por el API
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {

        /// <summary>
        /// Captura de excepciones no controladas en el API
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            RecordLog(context.Exception);
            //var output = Activator.CreateInstance(context.ActionContext.ActionDescriptor.ReturnType);
            //((MethodParameters.General.BaseOut)output).result = SD.Entities.General.Result.GenericError;
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError);
            return;
        }

        /// <summary>
        /// Graba el log de las excepciones no controlada en el API
        /// </summary>
        /// <param name="exception"></param>
        private void RecordLog(Exception exception)
        {
            //TODO Fedex Implementar log4net o revisar si se graba en base de datos=
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(string.Concat("Message: ", exception.Message, "\nStackTrace: ", exception.StackTrace), EventLogEntryType.Error);
            }
        }

    }
}
