using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Authentication
{
    public class LoginOut : MethodParameters.Common.BaseOut
    {
        public string sessionId { get; set; }
        public Entities.Database.User user { get; set; }
        public string token { get; set; }

    }

}
