using SystemManagement.DataAccess.Helper;
using SystemManagement.DataAccess.Permission.Model;
using SystemManagement.MethodParameters.Permission;
using System.Collections.Generic;
using System.Linq;

namespace SystemManagement.DataAccess.Permission
{
    public class Permission
    {
        public CreatePermissionOut CreatePermission(CreatePermissionIn input)
        {
            CreatePermissionOut output = new CreatePermissionOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<PermissionDataContext>())
            {
                var linqResult = dataContext.spr_setPermission(input.permission.pm_code,
                                                                input.permission.pm_name,
                                                                input.permission.pm_description,
                                                                input.permission.pm_creationUser);
                if (linqResult > 0)
                {
                    output.pmID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public UpdatePermissionOut UpdatePermission(UpdatePermissionIn input)
        {
            UpdatePermissionOut output = new UpdatePermissionOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<PermissionDataContext>())
            {
                var linqResult = dataContext.spr_updatePermission(input.permission.pm_code
                                                                , input.permission.pm_name
                                                                , input.permission.pm_description
                                                                , input.permission.pm_modificationUser
                                                                , input.permission.pm_status
                                                            );
                if (linqResult == 1)
                {
                    output.pmID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public GetPermissionByCodeOut GetPermissionByCode(GetPermissionByCodeIn input)
        {
            GetPermissionByCodeOut output = new GetPermissionByCodeOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<PermissionDataContext>())
            {
                var linqResult = dataContext.spr_getPermissionByCode(input.pm_code).FirstOrDefault();
                output.permission = new Entities.Database.Permission();


                    var permission = new Entities.Database.Permission()
                    {
                        pmID = linqResult.pmID,
                        pm_code = linqResult.pm_code,
                        pm_name = linqResult.pm_name,
                        pm_description = linqResult.pm_description,
                        pm_creationUser = linqResult.pm_creationUser,
                        pm_creationDate = linqResult.pm_creationDate,
                        pm_modificationUser = linqResult.pm_modificationUser,
                        pm_modificationDate = linqResult.pm_modificationDate,
                        pm_status = linqResult.pm_status
                    };
                    output.permission = permission;
                
                output.result = Entities.Common.Result.Success;

            }
            return output;
        }
        public GetPermissionByRoleOut GetPermissionByRole(GetPermissionByRoleIn input)
        {
            GetPermissionByRoleOut output = new GetPermissionByRoleOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<PermissionDataContext>())
            {
                var linqResult = dataContext.spr_getPermissionByRole(input.role);
                output.listPermissions = new List<MethodParameters.Permission.GetPermissionByRoleOut.PermissionByRole>();

                foreach (var item in linqResult)
                {
                    var permission = new MethodParameters.Permission.GetPermissionByRoleOut.PermissionByRole()
                    {
                        pm_code = item.pm_code,
                        pm_name = item.pm_name,
                        rl_code = item.rl_code,
                        rl_name = item.rl_name,
                        rpID = item.rpID
                    };
                    output.listPermissions.Add(permission);
                }
                output.result = Entities.Common.Result.Success;
            }
            return output;
        }


    }
}
