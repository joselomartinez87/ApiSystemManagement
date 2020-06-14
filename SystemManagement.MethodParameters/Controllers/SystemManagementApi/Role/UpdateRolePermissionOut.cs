using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role
{
    public class UpdateRolePermissionOut : MethodParameters.Common.BaseOut
    {
        public List<ResultUpdateRolePermission> lisResultUpdateRolePermission { set; get; }

        public class ResultUpdateRolePermission
        {
            public decimal rpID { set; get; }
            public Entities.Common.Result deatil { set; get; }

        }
    }
}
