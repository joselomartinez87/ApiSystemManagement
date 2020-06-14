using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission
{
    public class GetPermissionByRoleOut : MethodParameters.Common.BaseOut
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
