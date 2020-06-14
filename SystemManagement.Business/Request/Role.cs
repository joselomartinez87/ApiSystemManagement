using SystemManagement.MethodParameters.Role;
using System;

namespace SystemManagement.Business.Role
{
    public class Role
    {
        public CreateRoleOut CreateRole(CreateRoleIn input)
        {
            var permission = new SystemManagement.DataAccess.Role.Role();
            return permission.CreateRole(input);
        }

        public CreateRolePermissionOut CreateRolePermission(CreateRolePermissionIn input)
        {
            var rolePermission = new SystemManagement.DataAccess.Role.Role();
            return rolePermission.CreateRolePermission(input);
        }

        public UpdateRoleOut UpdateRole(UpdateRoleIn input)
        {
            var permission = new SystemManagement.DataAccess.Role.Role();
            return permission.UpdateRole(input);
        }

        public GetRoleByCodeOut GetRoleByCode(GetRoleByCodeIn input)
        {
            var permission = new SystemManagement.DataAccess.Role.Role();
            return permission.GetRoleByCode(input);
        }

        public UpdateRolePermissionOut UpdateRolePermission(UpdateRolePermissionIn input)
        {
            var permission = new SystemManagement.DataAccess.Role.Role();
            return permission.UpdateRolePermission(input);
        }

    }
}
