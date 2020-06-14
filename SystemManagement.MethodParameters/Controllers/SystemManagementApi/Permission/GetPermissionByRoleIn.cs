using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission
{
    public class GetPermissionByRoleIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public string role { set; get; }

    }
}
