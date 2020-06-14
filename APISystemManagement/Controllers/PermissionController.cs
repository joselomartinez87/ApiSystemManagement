using SystemManagement.Business.Filters;
using SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;

namespace ManagerSystemAPI.Controllers
{

    /// <summary>
    /// Controlador de Permisos
    /// </summary>
    [RoutePrefix("api")]
    [CustomExceptionFilterAttribute]
    public class PermissionController : ApiController
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
        /// El permiso es creado
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del permiso creado</returns>
        [HttpPost]
        [Route("CreatePermission")]
        [ResponseType(typeof(CreatePermissionOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult CreateUser(CreatePermissionIn input)
        {
            if (ModelState.IsValid)
            {
                var permission = new SystemManagement.Business.Controllers.Permission();
                var createPermissionOut = permission.Create(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, createPermissionOut));
            }
            else
            {
                var output = new CreatePermissionOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// Actualizar información del permiso
        /// </summary>
        /// <remarks>
        /// Se actualiza la información del permiso según la información ingresada
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información del permiso creado</returns>
        [HttpPut]
        [Route("UpdatePermission")]
        [ResponseType(typeof(UpdatePermissionOut))]
        //[CustomAuthorizationFilterAttribute]
        public IHttpActionResult UpdatePermission(UpdatePermissionIn input)
        {
            if (ModelState.IsValid)
            {
                var permission = new SystemManagement.Business.Controllers.Permission();
                var updatePermissionOut = permission.Update(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, updatePermissionOut));
            }
            else
            {
                var output = new UpdatePermissionOut();
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
        [Route("GetPermissionByCode")]
        [ResponseType(typeof(GetPermissionByCodeOut))]
        public IHttpActionResult GetPermissionByCode(GetPermissionByCodeIn input)
        {
            if (ModelState.IsValid)
            {
                var permission = new SystemManagement.Business.Controllers.Permission();
                var getPermissionByCodeOut = permission.GetPermissionByCode(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, getPermissionByCodeOut));
            }
            else
            {
                var output = new GetPermissionByCodeOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

        /// <summary>
        /// Obtiene los permisos asociados a un rol
        /// </summary>
        /// <remarks>
        /// Se realiza la busqueda de permisos configurados al rol ingresado
        /// </remarks>
        /// <response code="200">Proceso exitoso</response>
        /// <response code="400">Error de validación en los parámetros de entrada</response>
        /// <response code="500">Excepción no controlada</response> 
        /// <returns>Retorna información de los permisos del rol</returns>
        [HttpPost]
        [Route("GetPermissionByRole")]
        [ResponseType(typeof(GetPermissionByRoleOut))]
        public IHttpActionResult GetPermissionByRole(GetPermissionByRoleIn input)
        {
            if (ModelState.IsValid)
            {
                var permission = new SystemManagement.Business.Controllers.Permission();
                var getPermissionByRoleOut = permission.GetPermissionByRole(input);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.OK, getPermissionByRoleOut));
            }
            else
            {
                var output = new GetPermissionByRoleOut();
                output.result = SystemManagement.Entities.Common.Result.Error;
                output.message = DetailErrorBadRequest(ModelState);
                return ResponseMessage(Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, output));
            }
        }

    }
}
