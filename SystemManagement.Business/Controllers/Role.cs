using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role;

namespace SystemManagement.Business.Controllers
{
    public class Role
    {
        #region Properties

        #endregion

        #region Methods

        public CreateRoleOut Create(CreateRoleIn input)
        {
            var output = new CreateRoleOut() { result = Entities.Common.Result.Error };
            var request = new Business.Role.Role();
            var createRoletOut = request.CreateRole(new MethodParameters.Role.CreateRoleIn()
            {
                role = new Entities.Database.Role()
                {
                    rl_name = input.rl_name,
                    rl_creationUser = input.rl_creationUser
                }
            });

            if (createRoletOut.result == Entities.Common.Result.Success)
            {
                output.rlID = createRoletOut.rlID;
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }

        public CreateRolePermissionOut CreateRolePermission(CreateRolePermissionIn input)
        {
            var output = new CreateRolePermissionOut() { result = Entities.Common.Result.Error };
            var listresult = new List<MethodParameters.Controllers.SystemManagementApi.Role.CreateRolePermissionOut.CreateRolePermission>();
            var request = new Business.Role.Role();
            foreach (var item in input.listRolePermission)
            {
                var createRoletOut = request.CreateRolePermission(new MethodParameters.Role.CreateRolePermissionIn()
                {
                    rolePermission = new Entities.Database.RolePermission()
                    {
                        rl_code = item.rl_code,
                        pm_code = item.pm_code,
                        rp_creationUser = item.rp_creationUser
                    }
                });

                if (createRoletOut.result != Entities.Common.Result.Success)
                {
                    MethodParameters.Controllers.SystemManagementApi.Role.CreateRolePermissionOut.CreateRolePermission result = null;
                    result.rpID = createRoletOut.rpID;
                    result.deatil = createRoletOut.result;
                    listresult.Add(result);
                }


                if (listresult.Count() == 0)
                {
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public UpdateRoleOut Update(UpdateRoleIn input)
        {
            var output = new UpdateRoleOut() { result = Entities.Common.Result.Error };
            var request = new Business.Role.Role();
            var updateRoletOut = request.UpdateRole(new MethodParameters.Role.UpdateRoleIn()
            {
                role = new Entities.Database.Role()
                {
                    rl_code = input.rl_code,
                    rl_name = input.rl_name,
                    rl_modificationUser = input.rl_modificationUser,
                    rl_status = input.rl_status
                }
            });

            if (updateRoletOut.result == Entities.Common.Result.Success)
            {
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }

        public UpdateRolePermissionOut UpdateRolePermission(UpdateRolePermissionIn input)
        {
            var output = new UpdateRolePermissionOut() { result = Entities.Common.Result.Error };
            var request = new Business.Role.Role();
            var listresult = new List<MethodParameters.Controllers.SystemManagementApi.Role.UpdateRolePermissionOut.ResultUpdateRolePermission>();
            foreach (var item in input.listRolePermission)
            {
                var updateRolePermissionOut = request.UpdateRolePermission(new MethodParameters.Role.UpdateRolePermissionIn()
                {
                    rolePermission = new Entities.Database.RolePermission()
                    {
                        rpID = item.rpID,
                        rl_code = item.rl_code,
                        pm_code = item.pm_code,
                        rp_modificationUser = item.rp_modificationUser,
                        rp_status = item.rp_status
                    }
                });

                if (updateRolePermissionOut.result != Entities.Common.Result.Success)
                {
                    MethodParameters.Controllers.SystemManagementApi.Role.UpdateRolePermissionOut.ResultUpdateRolePermission result = null;
                    result.rpID = updateRolePermissionOut.rpID;
                    result.deatil = updateRolePermissionOut.result;
                    listresult.Add(result);
                }
            }

            if (listresult.Count() == 0)
            {
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }

        public GetRoleByCodeOut GetRoleByCode(GetRoleByCodeIn input)
        {
            var output = new GetRoleByCodeOut() { result = Entities.Common.Result.Error };
            var request = new Business.Role.Role();

            var getRoleByCodeOut = request.GetRoleByCode(new MethodParameters.Role.GetRoleByCodeIn()
            {
                role = new Entities.Database.Role()
                {
                    rl_code = input.rl_code
                }
            });

            if (getRoleByCodeOut.result == Entities.Common.Result.Success)
            {
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }


        #endregion
    }
}