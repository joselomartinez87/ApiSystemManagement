using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.Permission
{
    public class UpdatePermissionIn : MethodParameters.Common.BaseIn
    {
        public string pm_code { get; set; }
        public string pm_name { get; set; }
        public string pm_description { get; set; }
        public string pm_modificationUser { get; set; }
        public string pm_status { get; set; }

    }
}
