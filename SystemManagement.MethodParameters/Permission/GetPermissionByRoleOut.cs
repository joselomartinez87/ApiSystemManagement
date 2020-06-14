using System.Collections.Generic;

namespace SystemManagement.MethodParameters.Permission
{
    public class GetPermissionByRoleOut : SystemManagement.MethodParameters.Common.BaseOut
    {
        public List<PermissionByRole> listPermissions { get; set; }

        public class PermissionByRole
        {
            public string pm_code { set; get; }

            public string pm_name { set; get; }

            public string rl_code { set; get; }

            public string rl_name { set; get; }

            public decimal rpID { set; get; }
        }
    }
}
