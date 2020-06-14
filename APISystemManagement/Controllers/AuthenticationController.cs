using SystemManagement.Business.Filters;
using SystemManagement.MethodParameters.Authentication;
using SystemManagement.MethodParameters.Controllers.SystemManagementApi.Authentication;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace APISystemManagement.Controllers
{

    /// <summary>
    /// Controlador de autenticación
    /// </summary>
    [RoutePrefix("api")]
    [CustomExceptionFilterAttribute]
    public class AuthenticationController : ApiController
    {

        #region Properties

        private string DetailErrorBadRequest(System.Web.Http.ModelBinding.ModelStateDictionary model)
        {
            string errors = string.Empty;
            foreach (var modelStateItem in model.Values)
            {
                foreach (var modelErrorItem in modelStateItem.Errors)
                {
                    errors += string.Concat(modelErrorItem.ErrorMessage != null ? modelErrorItem.ErrorMessage : string.Empty,
                                            modelErrorItem.Exception != null ? modelErrorItem.Exception.Message : string.Empty);
                }
            }
            return errors;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// Se valida las credenciales ingresadas
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del usuario autenticado</returns>
        [HttpPost]
        [Route("Login")]
        [ResponseType(typeof(LoginOut))]
        public IHttpActionResult Login(LoginIn input)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemManagement.Business.Controllers.User();
                var loginOut = user.Login(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, loginOut));
            }
            else
            {
                var output = new LoginOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// CloseSession
        /// </summary>
        /// <remarks>
        /// Responsable de cambiar el estado de la sessión del usuario de activa a inactiva
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del usuario autenticado</returns>
        [HttpPost]
        [Route("CloseSession")]
        [ResponseType(typeof(CloseSessionOut))]
        public IHttpActionResult CloseSession(CloseSessionIn input)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemManagement.Business.Controllers.User();
                var closeSessionOut = user.CloseSession(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, closeSessionOut));
            }
            else
            {
                var output = new CloseSessionOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }
        
        #endregion
    }
}