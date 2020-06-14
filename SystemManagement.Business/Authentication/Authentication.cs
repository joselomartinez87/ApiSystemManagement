using SystemManagement.MethodParameters.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.Business.Authentication
{
    public class Authentication
    {
        public CreateSessionOut CreateSession(CreateSessionIn input)
        {
            var authentication = new SystemManagement.DataAccess.Authentication.Authentication();
            return authentication.CreateSession(input);
        }

        public ValidateSessionOut ValidateSession(ValidateSessionIn input)
        {
            var authentication = new SystemManagement.DataAccess.Authentication.Authentication();
            return authentication.ValidateSession(input);
        }

        public CloseSessionOut CloseSession(CloseSessionIn input)
        {
            var authentication = new SystemManagement.DataAccess.Authentication.Authentication();
            return authentication.CloseSession(input);
        }

    }
}
