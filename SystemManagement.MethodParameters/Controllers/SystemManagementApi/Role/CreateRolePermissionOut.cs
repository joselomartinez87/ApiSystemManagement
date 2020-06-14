using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role
{
    public class CreateRolePermissionOut : MethodParameters.Common.BaseOut
    {
        public List<CreateRolePermission> lisResultCreateRolePermission { set; get; }

        public class CreateRolePermission
        {
            public decimal rpID { set; get; }
            public Entities.Common.Result deatil { set; get; }

        }
    }
}
