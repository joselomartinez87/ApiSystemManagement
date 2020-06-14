using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Authentication.JwtManager
{
    public class ValidateTokenIn : SystemManagement.MethodParameters.Common.BaseIn
    {

        public string token { get; set; }

    }
}
