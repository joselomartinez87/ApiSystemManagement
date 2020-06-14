using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Authentication
{
    public class LoginIn
    {
        [Required]
        public string usr_userName { get; set; }
        [Required]
        public string usr_password { get; set; }

    }
}
