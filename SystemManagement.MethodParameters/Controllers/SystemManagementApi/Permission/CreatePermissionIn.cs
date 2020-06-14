using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission
{
    public class CreatePermissionIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public string pm_name { get; set; }
        [Required]
        public string pm_description { get; set; }
        [Required]
        public string pm_creationUser { get; set; }

    }
}
