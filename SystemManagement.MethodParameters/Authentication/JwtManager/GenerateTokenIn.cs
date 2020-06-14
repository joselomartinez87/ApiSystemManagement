using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Authentication.JwtManager
{
    public class GenerateTokenIn : SystemManagement.MethodParameters.Common.BaseIn
    {

        public string sessionId { get; set; }
        public decimal usrID { get; set; }

    }
}
