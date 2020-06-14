using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role
{
    public class CreateRolePermissionIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public List<RolePermission> listRolePermission { get; set; }
        
        public class RolePermission
        {
            [Required]
            public string rl_code { get; set; }
            [Required]
            public string pm_code { get; set; }
            public string rp_creationUser { get; set; }

        }
    }
}
