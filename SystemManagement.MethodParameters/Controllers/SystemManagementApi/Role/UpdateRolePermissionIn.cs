using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role
{
    public class UpdateRolePermissionIn : MethodParameters.Common.BaseIn
    {
        public List<RolePermissionUpdate> listRolePermission { set; get; }
        public class RolePermissionUpdate
        {
            [Required]
            public decimal rpID { set; get; }
            [Required]
            public string rl_code { set; get; }
            [Required]
            public string pm_code { set; get; }
            [Required]
            public string rp_modificationUser { set; get; }
            [Required]
            public string rp_status { set; get; }
        }

    }
}
