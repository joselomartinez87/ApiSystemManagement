

using System;
using System.ComponentModel.DataAnnotations;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role
{
    public class CreateRoleIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public string rl_name { get; set; }
        public string rl_creationUser { get; set; }

    }
}
