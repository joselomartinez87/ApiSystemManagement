using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Hosting;
using SystemManagement.MethodParameters.Authentication;
using SystemManagement.MethodParameters.Controllers.SystemManagementApi.Authentication;
using SystemManagement.MethodParameters.Controllers.SystemManagementApi.User;

namespace SystemManagement.Business.Controllers
{
    public class User
    {
        #region Properties

        private string ResetPasswordNotificationSubject
        {
            get { return ConfigurationManager.AppSettings["ResetPasswordNotificationSubject"]; }
        }

        private string EmailSender
        {
            get { return ConfigurationManager.AppSettings["EmailSender"]; }
        }

        private string UrlResetPassword
        {
            get { return ConfigurationManager.AppSettings["urlResetPassword"]; }
        }

        #endregion

        #region Methods

        public CreateUserOut Create(CreateUserIn input)
        {
            var output = new CreateUserOut() { result = Entities.Common.Result.Error };
            var request = new Business.User.User();

            var getUserInfoOut = request.GetUsers(new MethodParameters.User.GetUsersIn() { }).listUsers.FirstOrDefault(x => x.usrID == input.currentUser.usrID);
            var permissionRequest = new Business.Permission.Permission();
            var validateAccesFunctionOut = permissionRequest.GetPermissionByRole(new MethodParameters.Permission.GetPermissionByRoleIn()
            {
                role = getUserInfoOut.usr_role
            });

            if (validateAccesFunctionOut.result == Entities.Common.Result.Success &&
                validateAccesFunctionOut.listPermissions.FirstOrDefault(x => x.pm_code == "01") != null)
            {
                var password = Common.Security.Encryption.Encrypt(input.usr_password, input.usr_userName);
                var createUsertOut = request.CreateUser(new MethodParameters.User.CreateUserIn()
                {
                    user = new Entities.Database.User()
                    {
                        usr_userName = input.usr_userName,
                        usr_password = password,
                        usr_fullName = input.usr_fullName,
                        usr_documentType = input.usr_documentType,
                        usr_numberDocument = input.usr_numberDocument,
                        usr_email = input.usr_email,
                        usr_role = input.usr_role
                    }
                });

                if (createUsertOut.result == Entities.Common.Result.Success)
                {
                    output.result = Entities.Common.Result.Success;
                }
            }
            else if (validateAccesFunctionOut.result == Entities.Common.Result.Success)
            {
                output.message = "Esta funcionalidad no se encuentra disponible para usuarios no Administrador";
            }

            return output;
        }

        public UpdateUserOut Update(UpdateUserIn input)
        {
            var output = new UpdateUserOut() { result = Entities.Common.Result.Error };
            var request = new Business.User.User();

            var getUserInfoOut = request.GetUsers(new MethodParameters.User.GetUsersIn() { }).listUsers.FirstOrDefault(x => x.usrID == input.currentUser.usrID);
            var permissionRequest = new Business.Permission.Permission();
            var validateAccesFunctionOut = permissionRequest.GetPermissionByRole(new MethodParameters.Permission.GetPermissionByRoleIn()
            {
                role = getUserInfoOut.usr_role
            });

            if (validateAccesFunctionOut.result == Entities.Common.Result.Success &&
                validateAccesFunctionOut.listPermissions.FirstOrDefault(x => x.pm_code == "02") != null)
            {
                var password = Common.Security.Encryption.Encrypt(input.usr_password, input.usr_userName);
                var updateUsertOut = request.UpdateUser(new MethodParameters.User.UpdateUserIn()
                {
                    user = new Entities.Database.User()
                    {
                        usr_password = password,
                        usr_fullName = input.usr_fullName,
                        usr_documentType = input.usr_documentType,
                        usr_numberDocument = input.usr_numberDocument,
                        usr_email = input.usr_email,
                        usr_role = input.usr_role,
                        usr_modificationUser = input.usr_modificationUser
                    }
                });

                if (updateUsertOut.result == Entities.Common.Result.Success)
                {

                    output.result = Entities.Common.Result.Success;
                }
            }
            else if (validateAccesFunctionOut.result == Entities.Common.Result.Success)
            {
                output.message = "Esta funcionalidad no se encuentra disponible para usuarios no Administrador";
            }
            return output;
        }

        public LoginOut Login(LoginIn input)
        {
            var output = new LoginOut() { result = Entities.Common.Result.Error };
            var request = new Business.User.User();
            var getUserOut = request.GetUser(new MethodParameters.User.GetUserIn()
            {
                usr_userName = input.usr_userName
            });

            if (getUserOut.result == Entities.Common.Result.Success)
            {
                if (getUserOut.user.usr_userName == input.usr_userName)
                {
                    var passwordIn = Common.Security.Encryption.Encrypt(input.usr_password, getUserOut.user.usr_userName);
                    var passwordBd = getUserOut.user.usr_password;

                    if (passwordIn == passwordBd)
                    {
                        string sessionId = Guid.NewGuid().ToString();
                        var authentication = new SystemManagement.Business.Authentication.Authentication();
                        var createSessionOut = authentication.CreateSession(new MethodParameters.Authentication.CreateSessionIn()
                        {
                            sessionId = sessionId,
                            userId = getUserOut.user.usrID
                        });

                        if (createSessionOut.result == Entities.Common.Result.Success)
                        {
                            output.sessionId = sessionId;
                            output.user = getUserOut.user; ;

                            var jwtManager = new SystemManagement.Business.Authentication.JwtManager();
                            var generateTokenOut = jwtManager.GenerateToken(new MethodParameters.Authentication.JwtManager.GenerateTokenIn()
                            {
                                sessionId = sessionId,
                                usrID = getUserOut.user.usrID
                            });

                            if (generateTokenOut.result == Entities.Common.Result.Success)
                            {
                                output.token = generateTokenOut.token;
                                output.user = getUserOut.user;
                                output.result = Entities.Common.Result.Success;
                            }

                        }

                    }
                    else
                    {
                        output.message = "Credenciales incorrectas, verifique e intente nuevamente";
                    }

                }
                else
                {
                    output.message = "Credenciales incorrectas, verifique e intente nuevamente";
                }

            }
            else
            {
                output.message = "Credenciales incorrectas, verifique e intente nuevamente";
            }


            return output;
        }

        public GetUserOut GetUser(GetUserIn input)
        {
            var output = new GetUserOut() { result = Entities.Common.Result.Error };
            var request = new Business.User.User();
            var getUserByFilterOut = request.GetUser(new MethodParameters.User.GetUserIn()
            {
                usr_userName = input.usr_userName
            });

            if (getUserByFilterOut.user != null)
            {
                var user = new MethodParameters.Controllers.SystemManagementApi.User.GetUserOut.UserResult()
                {
                    usrID = getUserByFilterOut.user.usrID,
                    usr_code = getUserByFilterOut.user.usr_code,
                    usr_userName = getUserByFilterOut.user.usr_userName,
                    usr_password = getUserByFilterOut.user.usr_password,
                    usr_fullName = getUserByFilterOut.user.usr_fullName,
                    usr_documentType = getUserByFilterOut.user.usr_documentType,
                    usr_numberDocument = getUserByFilterOut.user.usr_numberDocument,
                    usr_email = getUserByFilterOut.user.usr_email,
                    usr_balance = getUserByFilterOut.user.usr_balance,
                    usr_role = getUserByFilterOut.user.usr_role,
                    usr_creationUser = getUserByFilterOut.user.usr_creationUser,
                    usr_creationDate = getUserByFilterOut.user.usr_creationDate,
                    usr_modificationUser = getUserByFilterOut.user.usr_modificationUser,
                    usr_modificationDate = getUserByFilterOut.user.usr_modificationDate,
                    usr_status = getUserByFilterOut.user.usr_status
                };
                output.resultGetUser = user;
            }

            if (getUserByFilterOut.result == Entities.Common.Result.Success)
            {
                output.result = Entities.Common.Result.Success;
            }

            return output;
        }

        public CloseSessionOut CloseSession(CloseSessionIn input)
        {
            var output = new CloseSessionOut() { result = Entities.Common.Result.Error };
            var request = new Business.Authentication.Authentication();
            request.CloseSession(new CloseSessionIn()
            {

            });

            return output;
        }

        public AddBalanceOut AddBalance(AddBalanceIn input)
        {
            var output = new AddBalanceOut() { result = Entities.Common.Result.Error };
            var request = new Business.User.User();

            var getUserOut = request.GetUsers(new MethodParameters.User.GetUsersIn(){}).listUsers.FirstOrDefault( x => x.usrID == input.currentUser.usrID);
            var permissionRequest = new Business.Permission.Permission();
            var validateAccesFunctionOut = permissionRequest.GetPermissionByRole(new MethodParameters.Permission.GetPermissionByRoleIn()
            {
                role = getUserOut.usr_role
            });

            if (validateAccesFunctionOut.result == Entities.Common.Result.Success &&
                validateAccesFunctionOut.listPermissions.FirstOrDefault(x => x.pm_code == "03") != null)
            {
                var createUsertOut = request.AddBalance(new MethodParameters.User.AddBalanceIn()
                {
                    usr_userNameDestiny = input.usr_userNameDestiny,
                    valueTransfer = input.valueTransfer
                });

                if (createUsertOut.result == Entities.Common.Result.Success)
                {
                    output.usrID = createUsertOut.usrID;
                    output.result = Entities.Common.Result.Success;
                }
            }
            else if (validateAccesFunctionOut.result == Entities.Common.Result.Success)
            {
                output.message = "Esta funcionalidad no se encuentra disponible para usuarios no Administrador";
            }
            return output;
        }

        public DeleteBalanceOut DeleteBalance(DeleteBalanceIn input)
        {
            var output = new DeleteBalanceOut() { result = Entities.Common.Result.Error };
            var request = new Business.User.User();

            var getUserInfoOut = request.GetUsers(new MethodParameters.User.GetUsersIn() { }).listUsers.FirstOrDefault(x => x.usrID == input.currentUser.usrID);
            var permissionRequest = new Business.Permission.Permission();
            var validateAccesFunctionOut = permissionRequest.GetPermissionByRole(new MethodParameters.Permission.GetPermissionByRoleIn()
            {
                role = getUserInfoOut.usr_role
            });

            if (validateAccesFunctionOut.result == Entities.Common.Result.Success &&
                validateAccesFunctionOut.listPermissions.FirstOrDefault(x => x.pm_code == "04") != null)
            {

                var getUserOut = request.GetUser(new MethodParameters.User.GetUserIn()
                {
                    usr_userName = input.usr_userNameDestiny
                });

                if (getUserOut.result == Entities.Common.Result.Success
                    && getUserOut.user.usr_balance >= input.valueTransfer)
                {

                    var deleteBalanceOut = request.DeleteBalance(new MethodParameters.User.DeleteBalanceIn()
                    {
                        usr_userNameDestiny = input.usr_userNameDestiny,
                        valueTransfer = input.valueTransfer
                    });

                    if (deleteBalanceOut.result == Entities.Common.Result.Success)
                    {
                        output.result = deleteBalanceOut.result;
                        output.result = Entities.Common.Result.Success;
                    }
                }
                else if (getUserOut.result == Entities.Common.Result.Success)
                {
                    output.message = "La operación que intenta realizar supera el balance actual";
                }
            }
            else if (validateAccesFunctionOut.result == Entities.Common.Result.Success)
            {
                output.message = "Esta funcionalidad no se encuentra disponible para usuarios no Administrador";
            }

            return output;
        }

        public TransferBalanceOut TransferBalance(TransferBalanceIn input)
        {
            var output = new TransferBalanceOut() { result = Entities.Common.Result.Error };
            var request = new Business.User.User();

            var getUserInfoOut = request.GetUsers(new MethodParameters.User.GetUsersIn() { }).listUsers.FirstOrDefault(x => x.usrID == input.currentUser.usrID);
            var permissionRequest = new Business.Permission.Permission();
            var validateAccesFunctionOut = permissionRequest.GetPermissionByRole(new MethodParameters.Permission.GetPermissionByRoleIn()
            {
                role = getUserInfoOut.usr_role
            });

            if (validateAccesFunctionOut.result == Entities.Common.Result.Success &&
                validateAccesFunctionOut.listPermissions.FirstOrDefault(x => x.pm_code == "06") != null)
            {

                var getUserOut = request.GetUser(new MethodParameters.User.GetUserIn()
                {
                    usr_userName = input.usr_userNameOrigin
                });

                if (getUserOut.result == Entities.Common.Result.Success
                    && getUserOut.user.usr_balance >= input.valueTransfer)
                {
                    var transferBalanceOut = request.TransferBalance(new MethodParameters.User.TransferBalanceIn()
                    {
                        usr_userNameOrigin = input.usr_userNameOrigin,
                        usr_userNameDestiny = input.usr_userNameDestiny,
                        valueTransfer = input.valueTransfer
                    });

                    if (transferBalanceOut.result == Entities.Common.Result.Success)
                    {
                        output.message = "Transferencia realizada con exito";
                        output.result = Entities.Common.Result.Success;
                    }
                }
                else if (getUserOut.result == Entities.Common.Result.Success)
                {
                    output.message = "El valor a transferir supera el balance de la cuenta de origen";
                    output.result = Entities.Common.Result.Success;
                }
            }
            else if (validateAccesFunctionOut.result == Entities.Common.Result.Success)
            {
                output.message = "Esta funcionalidad no se encuentra disponible para no usuarios";
            }

            return output;
        }

        #endregion
    }
}
