using System;

namespace SystemManagement.Entities.Database
{
    public class RolePermission
    {
        public decimal rpID { get; set; }
        public string rl_code { get; set; }
        public string pm_code { get; set; }
        public string rp_creationUser { get; set; }
        public System.Nullable<System.DateTime> rp_creationDate { get; set; }
        public string rp_modificationUser { get; set; }
        public System.Nullable<System.DateTime> rp_modificationDate { get; set; }
        public string rp_status { get; set; }

    }
}
