using SystemManagement.Business.Filters;
using SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace SystemManagement.Controllers
{

    /// <summary>
    /// Controlador de Roles
    /// </summary>
    [RoutePrefix("api")]
    [CustomExceptionFilterAttribute]
    public class RoleController : ApiController
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

        /// <summary>
        /// Crea un rol
        /// </summary>
        /// <remarks>
        /// El rol es creado y queda listo para asociarle permisos
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del rol creado</returns>
        [HttpPost]
        [Route("CreateRole")]
        [ResponseType(typeof(CreateRoleOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult CreateUser(CreateRoleIn input)
        {
            if (ModelState.IsValid)
            {
                var role = new SystemManagement.Business.Controllers.Role();
                var createRoleOut = role.Create(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, createRoleOut));
            }
            else
            {
                var output = new CreateRoleOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// Creación de relación de permisos a un rol en particular
        /// </summary>
        /// <remarks>
        /// Seasocian permisos un rol
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información de los permisos asociados al rol</returns>
        [HttpPost]
        [Route("CreateRolePermission")]
        [ResponseType(typeof(CreateRolePermissionOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult CreateRolePermission(CreateRolePermissionIn input)
        {
            if (ModelState.IsValid)
            {
                var role = new SystemManagement.Business.Controllers.Role();
                var createRolePermissionOut = role.CreateRolePermission(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, createRolePermissionOut));
            }
            else
            {
                var output = new CreateRoleOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// Actualizar información del rol
        /// </summary>
        /// <remarks>
        /// Se actualiza la información del rol según la información ingresada
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del rol actualizado</returns>
        [HttpPut]
        [Route("UpdateRole")]
        [ResponseType(typeof(UpdateRoleOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult UpdateRole(UpdateRoleIn input)
        {
            if (ModelState.IsValid)
            {
                var role = new SystemManagement.Business.Controllers.Role();
                var updateRoleOut = role.Update(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, updateRoleOut));
            }
            else
            {
                var output = new UpdateRoleOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// Actualizar permisos de un rol
        /// </summary>
        /// <remarks>
        /// Se actualizan los permisos del rol según la información ingresada
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna los permisos delrolsegun la información actualizada</returns>
        [HttpPut]
        [Route("UpdateRolePermission")]
        [ResponseType(typeof(UpdateRolePermissionOut))]
        public IHttpActionResult UpdateRolePermission(UpdateRolePermissionIn input)
        {
            if (ModelState.IsValid)
            {
                var role = new SystemManagement.Business.Controllers.Role();
                var updateRolePermissionOut = role.UpdateRolePermission(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, updateRolePermissionOut));
            }
            else
            {
                var output = new UpdateRolePermissionOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// Obtiene el rol según el código ingresado
        /// </summary>
        /// <remarks>
        /// Se realiza la busqueda del rol segun la información ingresada
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del rol</returns>
        [HttpPost]
        [Route("GetRoleByCode")]
        [ResponseType(typeof(GetRoleByCodeOut))]
        public IHttpActionResult GetRoleByCode(GetRoleByCodeIn input)
        {
            if (ModelState.IsValid)
            {
                var role = new SystemManagement.Business.Controllers.Role();
                var getRoleByCodeOut = role.GetRoleByCode(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, getRoleByCodeOut));
            }
            else
            {
                var output = new GetRoleByCodeOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

    }
}
