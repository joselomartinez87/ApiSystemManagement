using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.User
{
    public class GetUserIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public string usr_userName { set; get; }

    }
}
