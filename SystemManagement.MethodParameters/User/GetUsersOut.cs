
using System.Collections.Generic;

namespace SystemManagement.MethodParameters.User
{
    public class GetUsersOut : SystemManagement.MethodParameters.Common.BaseOut
    {
        public List<SystemManagement.Entities.Database.User> listUsers { get; set; }
    }
}
