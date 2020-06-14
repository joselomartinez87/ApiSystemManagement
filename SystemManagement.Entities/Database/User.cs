using System;

namespace SystemManagement.Entities.Database
{
    public class User
    {
        public decimal usrID { get; set; }
        public string usr_code { get; set; }
        public string usr_userName { get; set; }
        public string usr_password { get; set; }
        public string usr_fullName { get; set; }
        public string usr_documentType { get; set; }
        public string usr_numberDocument { get; set; }
        public string usr_email { get; set; }
        public System.Nullable<decimal> usr_balance { get; set; }
        public string usr_role { get; set; }
        public string usr_creationUser { get; set; }
        public System.Nullable<System.DateTime> usr_creationDate { get; set; }
        public string usr_modificationUser { get; set; }
        public System.Nullable<System.DateTime> usr_modificationDate { get; set; }
        public string usr_status { get; set; }
    }
}
