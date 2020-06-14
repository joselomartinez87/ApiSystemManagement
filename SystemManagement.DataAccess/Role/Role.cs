using SystemManagement.DataAccess.Helper;
using SystemManagement.DataAccess.Role.Model;
using SystemManagement.MethodParameters.Role;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SystemManagement.DataAccess.Role
{
    public class Role
    {

        public CreateRoleOut CreateRole(CreateRoleIn input)
        {
            CreateRoleOut output = new CreateRoleOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<RoleDataContext>())
            {
                var linqResult = dataContext.spr_setRole(input.role.rl_code,
                                                         input.role.rl_name,
                                                         input.role.rl_creationUser);
                if (linqResult > 0)
                {
                    output.rlID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public CreateRolePermissionOut CreateRolePermission(CreateRolePermissionIn input)
        {
            CreateRolePermissionOut output = new CreateRolePermissionOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<RoleDataContext>())
            {
                var linqResult = dataContext.spr_setRolePermission(input.rolePermission.rl_code,
                                                                   input.rolePermission.pm_code,
                                                                   input.rolePermission.rp_creationUser);
                if (linqResult > 0)
                {
                    output.rpID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public GetRoleByCodeOut GetRoleByCode(GetRoleByCodeIn input)
        {
            GetRoleByCodeOut output = new GetRoleByCodeOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<RoleDataContext>())
            {
                var linqResult = dataContext.spr_getRoleByCode(input.role.rl_code);
                if (linqResult.Count() > 0)
                {
                    foreach (var item in linqResult)
                    {
                        var role = new Entities.Database.Role()
                        {
                            rlID = item.rlID,
                            rl_code = item.rl_code,
                            rl_name = item.rl_name,
                            rl_creationUser = item.rl_creationUser,
                            rl_creationDate = item.rl_creationDate,
                            rl_modificationUser = item.rl_modificationUser,
                            rl_modificationDate = item.rl_modificationDate,
                            rl_status = item.rl_status
                        };
                        output.listRole.Add(role);
                    }

                    output.result = Entities.Common.Result.Success;
                }
                else
                {
                    output.result = Entities.Common.Result.NoRecords;
                }
            }
            return output;
        }
        
        public UpdateRoleOut UpdateRole(UpdateRoleIn input)
        {
            UpdateRoleOut output = new UpdateRoleOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<RoleDataContext>())
            {
                var linqResult = dataContext.spr_updateRole(input.role.rl_code
                                                            , input.role.rl_name
                                                            , input.role.rl_modificationUser
                                                            , input.role.rl_status
                                                            );
                if (linqResult == 1)
                {
                    output.rlID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public UpdateRolePermissionOut UpdateRolePermission(UpdateRolePermissionIn input)
        {
            UpdateRolePermissionOut output = new UpdateRolePermissionOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<RoleDataContext>())
            {
                var linqResult = dataContext.spr_updateRolePermission(
                                                                      input.rolePermission.rpID
                                                                    , input.rolePermission.rl_code
                                                                    , input.rolePermission.pm_code
                                                                    , input.rolePermission.rp_modificationUser
                                                                    , input.rolePermission.rp_status
                                                                    );
                if (linqResult == 1)
                {
                    output.rpID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

    }
}