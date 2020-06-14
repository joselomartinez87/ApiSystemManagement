using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission
{
    public class GetPermissionByCodeIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public string pm_code { set; get; }

    }
}
