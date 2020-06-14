using SystemManagement.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Authentication.JwtManager
{
    public class ValidateTokenOut : SystemManagement.MethodParameters.Common.BaseOut
    {

        public TokenInformation tokenInformation { get; set; }

    }
}
