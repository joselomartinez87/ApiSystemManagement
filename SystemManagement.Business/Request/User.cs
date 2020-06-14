using SystemManagement.MethodParameters.User;
using System;

namespace SystemManagement.Business.User
{
    public class User
    {
        public CreateUserOut CreateUser(CreateUserIn input)
        {
            var User = new SystemManagement.DataAccess.User.User();
            return User.CreateUser(input);
        }

        public UpdateUserOut UpdateUser(UpdateUserIn input)
        {
            var user = new SystemManagement.DataAccess.User.User();
            return user.UpdateUser(input);
        }

        public GetUserOut GetUser(GetUserIn input)
        {
            var user = new SystemManagement.DataAccess.User.User();
            return user.GetUser(input);
        }

        public GetUsersOut GetUsers(GetUsersIn input)
        {
            var user = new SystemManagement.DataAccess.User.User();
            return user.GetUsers(input);
        }

        public AddBalanceOut AddBalance(AddBalanceIn input)
        {
            var user = new SystemManagement.DataAccess.User.User();
            return user.AddBalance(input);
        }

        public DeleteBalanceOut DeleteBalance(DeleteBalanceIn input)
        {
            var user = new SystemManagement.DataAccess.User.User();
            return user.DeleteBalance(input);
        }

        public TransferBalanceOut TransferBalance(TransferBalanceIn input)
        {
            var user = new SystemManagement.DataAccess.User.User();
            return user.TransferBalance(input);
        }

    }
}
