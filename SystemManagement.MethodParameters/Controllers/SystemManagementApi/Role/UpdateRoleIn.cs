using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Role
{
    public class UpdateRoleIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public string rl_code { set; get; }

        [Required]
        public string rl_name { get; set; }

        [Required]
        public string rl_modificationUser { get; set; }
        
        [Required]
        public string rl_status { get; set; }
    }
}
