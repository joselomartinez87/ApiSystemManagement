using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Authentication.JwtManager
{
    public class GenerateTokenOut : SystemManagement.MethodParameters.Common.BaseOut
    {

        public string token { get; set; }

    }
}
