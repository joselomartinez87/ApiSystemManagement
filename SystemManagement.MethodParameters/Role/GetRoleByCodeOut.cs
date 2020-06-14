using System.Collections.Generic;

namespace SystemManagement.MethodParameters.Role
{
    public class GetRoleByCodeOut : SystemManagement.MethodParameters.Common.BaseOut
    {
        public List<SystemManagement.Entities.Database.Role> listRole { get; set; }

    }
}
