using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission
{
    public class CreatePermissionOut : MethodParameters.Common.BaseOut
    {
        public decimal pmID { get; set; }

    }
}
