using System;
using System.Linq;
using SystemManagement.DataAccess.Authentication.Models;
using SystemManagement.DataAccess.Helper;
using SystemManagement.MethodParameters.Authentication;

namespace SystemManagement.DataAccess.Authentication
{
    public class Authentication
    {

        public CreateSessionOut CreateSession(CreateSessionIn input)
        {
            CreateSessionOut output = new CreateSessionOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<AuthenticationDataContext>())
            {
                var linqResult = dataContext.spr_createSession(input.sessionId, input.userId);
                if (linqResult == 1)
                {
                    output.result = SystemManagement.Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public ValidateSessionOut ValidateSession(ValidateSessionIn input)
        {
            ValidateSessionOut output = new ValidateSessionOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<AuthenticationDataContext>())
            {
                var linqResult = dataContext.spr_validateSession(input.sessionId, input.userId).FirstOrDefault();
                if (linqResult != null)
                {
                    output.session = new SystemManagement.Entities.Database.Session()
                    {
                        sesID = linqResult.sesID,
                        usrID = linqResult.usrID,
                        ses_status = linqResult.ses_status,
                        ses_date = linqResult.ses_date
                    };
                    output.result = SystemManagement.Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public CloseSessionOut CloseSession(CloseSessionIn input)
        {
            CloseSessionOut output = new CloseSessionOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<AuthenticationDataContext>())
            {
                var linqResult = dataContext.spr_closeSession(input.currentSesId);
                if (linqResult == 1)
                {
                    output.result = SystemManagement.Entities.Common.Result.Success;
                }
            }
            return output;
        }

    }
}