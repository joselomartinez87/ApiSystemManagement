using SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.Business.Controllers
{
    public class Permission
    {
        #region Properties

        #endregion

        #region Methods

        public CreatePermissionOut Create(CreatePermissionIn input)
        {
            var output = new CreatePermissionOut() { result = Entities.Common.Result.Error };
            var request = new Business.Permission.Permission();

            var createPermissionOut = request.CreatePermission(new MethodParameters.Permission.CreatePermissionIn()
            {
                permission = new Entities.Database.Permission()
                {
                    pm_name = input.pm_name,
                    pm_description = input.pm_description,
                    pm_creationUser = input.pm_creationUser
                }
            });

            if (createPermissionOut.result == Entities.Common.Result.Success)
            {
                output.pmID = createPermissionOut.pmID;
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }

        public UpdatePermissionOut Update(UpdatePermissionIn input)
        {
            var output = new UpdatePermissionOut() { result = Entities.Common.Result.Error };
            var request = new Business.Permission.Permission();

            var updatePermissiontOut = request.UpdatePermission(new MethodParameters.Permission.UpdatePermissionIn()
            {
                permission = new Entities.Database.Permission()
                {
                    pm_code = input.pm_code,
                    pm_name = input.pm_name,
                    pm_modificationUser = input.pm_modificationUser,
                    pm_status = input.pm_status
                }
            });

            if (updatePermissiontOut.result == Entities.Common.Result.Success)
            {
                output.pmID = updatePermissiontOut.pmID;
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }

        public GetPermissionByCodeOut GetPermissionByCode(GetPermissionByCodeIn input)
        {
            var output = new GetPermissionByCodeOut() { result = Entities.Common.Result.Error };
            var request = new Business.Permission.Permission();

            var getPermissionByCodeOut = request.GetPermissionByCode(new MethodParameters.Permission.GetPermissionByCodeIn()
            {
                pm_code = input.pm_code
            });

            if (getPermissionByCodeOut.result == Entities.Common.Result.Success)
            {
                output.permissions = getPermissionByCodeOut.permission;
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }

        public GetPermissionByRoleOut GetPermissionByRole(GetPermissionByRoleIn input)
        {
            var output = new GetPermissionByRoleOut() { result = Entities.Common.Result.Error };
            var request = new Business.Permission.Permission();

            var getPermissionByRole = request.GetPermissionByRole(new MethodParameters.Permission.GetPermissionByRoleIn()
            {
                role = input.role
            });

            if (getPermissionByRole.result == Entities.Common.Result.Success)
            {

                var listGetPermissionByRole = new List<MethodParameters.Controllers.SystemManagementApi.Permission.GetPermissionByRoleOut.PermissionByRole>();

                foreach (var item in getPermissionByRole.listPermissions)
                {
                    var role = new MethodParameters.Controllers.SystemManagementApi.Permission.GetPermissionByRoleOut.PermissionByRole()
                    {
                        rpID = item.rpID,
                        rl_code = item.rl_code,
                        rl_name = item.rl_name,
                        pm_code = item.pm_code,
                        pm_name = item.pm_name
                    };
                    listGetPermissionByRole.Add(role);
                }

                output.listPermissions = listGetPermissionByRole;
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }


        #endregion
    }
}
