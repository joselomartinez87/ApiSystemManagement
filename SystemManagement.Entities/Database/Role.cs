using System;

namespace SystemManagement.Entities.Database
{
    public class Role
    {
        public decimal rlID { get; set; }
        public string rl_code { get; set; }
        public string rl_name { get; set; }
        public string rl_creationUser { get; set; }
        public System.Nullable<System.DateTime> rl_creationDate { get; set; }
        public string rl_modificationUser { get; set; }
        public System.Nullable<System.DateTime> rl_modificationDate { get; set; }
        public string rl_status { get; set; }

    }
}
