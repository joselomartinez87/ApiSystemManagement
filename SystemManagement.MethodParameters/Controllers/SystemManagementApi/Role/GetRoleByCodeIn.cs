using System.ComponentModel.DataAnnotations;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role
{
    public class GetRoleByCodeIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public string rl_code { get; set; }

    }

}
