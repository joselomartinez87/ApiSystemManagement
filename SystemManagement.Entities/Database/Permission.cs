using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.Entities.Database
{
    public class Permission
    {
        public decimal pmID { get; set; }
        public string pm_code { get; set; }
        public string pm_name { get; set; }
        public string pm_description { get; set; }
        public string pm_creationUser { get; set; }
        public System.Nullable<System.DateTime> pm_creationDate { get; set; }
        public string pm_modificationUser { get; set; }
        public System.Nullable<System.DateTime> pm_modificationDate { get; set; }
        public string pm_status { get; set; }

    }
}
