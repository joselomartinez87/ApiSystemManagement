using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission
{
    public class GetPermissionByCodeOut : MethodParameters.Common.BaseOut
    {
        public Entities.Database.Permission permissions { get; set; }

    }
}
