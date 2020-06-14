using SystemManagement.MethodParameters.Permission;
using System;

namespace SystemManagement.Business.Permission
{
    public class Permission
    {
        public CreatePermissionOut CreatePermission(CreatePermissionIn input)
        {
            var permission = new SystemManagement.DataAccess.Permission.Permission();
            return permission.CreatePermission(input);
        }

        public UpdatePermissionOut UpdatePermission(UpdatePermissionIn input)
        {
            var permission = new SystemManagement.DataAccess.Permission.Permission();
            return permission.UpdatePermission(input);
        }

        public GetPermissionByCodeOut GetPermissionByCode(GetPermissionByCodeIn input)
        {
            var permission = new SystemManagement.DataAccess.Permission.Permission();
            return permission.GetPermissionByCode(input);
        }        

        public GetPermissionByRoleOut GetPermissionByRole(GetPermissionByRoleIn input)
        {
            var permission = new SystemManagement.DataAccess.Permission.Permission();
            return permission.GetPermissionByRole(input);
        }        

    }
}
