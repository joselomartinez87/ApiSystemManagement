using SystemManagement.Business.Filters;
using SystemManagement.MethodParameters.Controllers.SystemManagementApi.User;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace SystemManagement.Controllers
{

    /// <summary>
    /// Controlador de usuario
    /// </summary>
    [RoutePrefix("api")]
    [CustomExceptionFilterAttribute]
    public class UserController : ApiController
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

        #region

        /// <summary>
        /// GetUser
        /// </summary>
        /// <remarks>
        /// Consulta los usuarios del sistema por el userName
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del usuario buscado por userName</returns>
        [HttpPost]
        [Route("GetUser")]
        [ResponseType(typeof(GetUserOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult GetUser(GetUserIn input)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemManagement.Business.Controllers.User();
                var getUserOut = user.GetUser(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, getUserOut));
            }
            else
            {
                var output = new GetUserOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// TransferBalance
        /// </summary>
        /// <remarks>
        /// Consulta los usuarios del sistema por el userName
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del usuario buscado por userName</returns>
        [HttpPost]
        [Route("TransferBalance")]
        [ResponseType(typeof(TransferBalanceOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult TransferBalance(TransferBalanceIn input)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemManagement.Business.Controllers.User();
                var transferBalanceOut = user.TransferBalance(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, transferBalanceOut));
            }
            else
            {
                var output = new TransferBalanceOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        #endregion
    }
}