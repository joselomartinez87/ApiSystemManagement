using SystemManagement.DataAccess.Helper;
using SystemManagement.DataAccess.User.Model;
using SystemManagement.MethodParameters.User;
using System.Collections.Generic;
using System.Linq;

namespace SystemManagement.DataAccess.User
{
    public class User
    {
        public CreateUserOut CreateUser(CreateUserIn input)
        {
            CreateUserOut output = new CreateUserOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<UserDataContext>())
            {
                var linqResult = dataContext.spr_setUser(input.user.usr_userName,
                                                         input.user.usr_password,
                                                         input.user.usr_fullName,
                                                         input.user.usr_documentType,
                                                         input.user.usr_numberDocument,
                                                         input.user.usr_email,
                                                         input.user.usr_role,
                                                         input.user.usr_creationUser);
                if (linqResult > 0)
                {
                    output.usrID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public UpdateUserOut UpdateUser(UpdateUserIn input)
        {
            UpdateUserOut output = new UpdateUserOut() { result = Entities.Common.Result.Error };

            string status = string.Empty;
            if (input.user.usr_status == null) { status = "V"; }
            else
            { status = input.user.usr_status; }

            using (var dataContext = DataContextHelper.GetDataContext<UserDataContext>())
            {
                var linqResult = dataContext.spr_updateUser(input.user.usr_userName
                                                            , input.user.usr_password
                                                            , input.user.usr_fullName
                                                            , input.user.usr_documentType
                                                            , input.user.usr_numberDocument
                                                            , input.user.usr_email
                                                            , input.user.usr_role
                                                            , input.user.usr_modificationUser
                                                            , status);
                if (linqResult == 1)
                {
                    output.usrID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public GetUserOut GetUser(GetUserIn input)
        {
            GetUserOut output = new GetUserOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<UserDataContext>())
            {
                var linqResult = dataContext.spr_getUser(input.usr_userName).FirstOrDefault();
                if (linqResult != null)
                {
                    output.user = new Entities.Database.User()
                    {
                        usrID = linqResult.usrID,
                        usr_code = linqResult.usr_code,
                        usr_userName = linqResult.usr_userName,
                        usr_password = linqResult.usr_password,
                        usr_fullName = linqResult.usr_fullName,
                        usr_documentType = linqResult.usr_documentType,
                        usr_numberDocument = linqResult.usr_numberDocument,
                        usr_email = linqResult.usr_email,
                        usr_balance = linqResult.usr_balance,
                        usr_role = linqResult.usr_role,
                        usr_status = linqResult.usr_status
                    };
                    output.result = Entities.Common.Result.Success;
                }
                else
                {
                    output.result = Entities.Common.Result.NoRecords;
                }
            }
            return output;
        }

        public GetUsersOut GetUsers(GetUsersIn input)
        {
            GetUsersOut output = new GetUsersOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<UserDataContext>())
            {
                var linqResult = dataContext.spr_getUsers();
                output.listUsers = new List<Entities.Database.User>();
                foreach (var item in linqResult)
                {
                    var user = new Entities.Database.User()
                    {
                        usrID = item.usrID,
                        usr_code = item.usr_code,
                        usr_userName = item.usr_userName,
                        usr_password = item.usr_password,
                        usr_fullName = item.usr_fullName,
                        usr_documentType = item.usr_documentType,
                        usr_numberDocument = item.usr_numberDocument,
                        usr_email = item.usr_email,
                        usr_balance = item.usr_balance,
                        usr_role = item.usr_role,
                        usr_status = item.usr_status
                    };
                    output.listUsers.Add(user);
                }
                output.result = Entities.Common.Result.Success;

            }
            return output;
        }

        public AddBalanceOut AddBalance(AddBalanceIn input)
        {
            AddBalanceOut output = new AddBalanceOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<UserDataContext>())
            {
                var linqResult = dataContext.spr_setAddBalance(
                    input.usr_userNameDestiny,
                    input.valueTransfer
                    );
                if (linqResult > 0)
                {
                    output.usrID = linqResult;
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public DeleteBalanceOut DeleteBalance(DeleteBalanceIn input)
        {
            DeleteBalanceOut output = new DeleteBalanceOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<UserDataContext>())
            {
                var linqResult = dataContext.spr_setDeleteBalance(
                    input.usr_userNameDestiny,
                    input.valueTransfer
                    );
                if (linqResult.FirstOrDefault().result > 0)
                {
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

        public TransferBalanceOut TransferBalance(TransferBalanceIn input)
        {
            TransferBalanceOut output = new TransferBalanceOut() { result = Entities.Common.Result.Error };
            using (var dataContext = DataContextHelper.GetDataContext<UserDataContext>())
            {
                var linqResult = dataContext.spr_setTransferBalance(
                    input.usr_userNameOrigin,
                    input.usr_userNameDestiny,
                    input.valueTransfer
                    );
                if (linqResult.FirstOrDefault().result > 0)
                {
                    output.result = Entities.Common.Result.Success;
                }
            }
            return output;
        }

    }
}
