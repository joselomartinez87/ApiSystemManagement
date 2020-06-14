using System;
using System.ComponentModel.DataAnnotations;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.User
{
    public class UpdateUserIn : MethodParameters.Common.BaseIn
    {
        [Required]
        public string usr_userName { get; set; }
        [Required]
        public string usr_password { get; set; }
        [Required]
        public string usr_fullName { get; set; }
        [Required]
        public string usr_documentType { get; set; }
        [Required]
        public string usr_numberDocument { get; set; }
        [Required]
        public string usr_email { get; set; }
        [Required]
        public System.Nullable<int> usr_companyID { get; set; }
        [Required]
        public System.Nullable<int> usr_type { get; set; }
        [Required]
        public string usr_role { get; set; }
        [Required]
        public string usr_modificationUser { get; set; }

    }
}
