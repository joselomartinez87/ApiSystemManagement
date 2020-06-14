using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SystemManagement.Business.Filters;
using SystemManagement.MethodParameters.Controllers.SystemManagementApi.User;

namespace SystemManagement.Controllers
{

    /// <summary>
    /// Controlador de usuario
    /// </summary>
    [RoutePrefix("api")]
    [CustomExceptionFilterAttribute]
    public class AdminController : ApiController
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
        /// CreateUser
        /// </summary>
        /// <remarks>
        /// El usuario queda asociado a un rol y los permisos del mismo
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del usuario creado</returns>
        [HttpPost]
        [Route("CreateUser")]
        [ResponseType(typeof(CreateUserOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult CreateUser(CreateUserIn input)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemManagement.Business.Controllers.User();
                var createUserOut = user.Create(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, createUserOut));
            }
            else
            {
                var output = new CreateUserOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// UpdateUser
        /// </summary>
        /// <remarks>
        /// Se actualiza la información del usuario segun la información ingresada
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Se actualiza la información del usuario segun la información ingresada</returns>
        [HttpPut]
        [Route("UpdateUser")]
        [ResponseType(typeof(UpdateUserOut))]
        public IHttpActionResult UpdateUser(UpdateUserIn input)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemManagement.Business.Controllers.User();
                var updateUserOut = user.Update(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, updateUserOut));
            }
            else
            {
                var output = new UpdateUserOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

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
        /// AddBalance
        /// </summary>
        /// <remarks>
        /// Usuarios administradores adicionan balance a un usuario con el nombre de usuario
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información de la operación</returns>
        [HttpPost]
        [Route("AddBalance")]
        [ResponseType(typeof(AddBalanceOut))]
        [CustomAuthorizationFilterAttribute]
        [SessionRequired]
        public IHttpActionResult AddBalance(AddBalanceIn input)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemManagement.Business.Controllers.User();
                var addBalanceOut = user.AddBalance(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, addBalanceOut));
            }
            else
            {
                var output = new AddBalanceOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// DeleteBalance
        /// </summary>
        /// <remarks>
        /// Usuarios administradores eliminan balance a un usuario con el nombre de usuario
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información de la operación</returns>
        [HttpPost]
        [Route("DeleteBalance")]
        [ResponseType(typeof(DeleteBalanceOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult DeleteBalance(DeleteBalanceIn input)
        {
            if (ModelState.IsValid)
            {
                var user = new SystemManagement.Business.Controllers.User();
                var deleteBalanceOut = user.DeleteBalance(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, deleteBalanceOut));
            }
            else
            {
                var output = new DeleteBalanceOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        #endregion
    }
}
