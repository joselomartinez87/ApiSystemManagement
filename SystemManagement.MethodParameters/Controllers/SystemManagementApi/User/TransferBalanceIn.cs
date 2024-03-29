﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.User
{
    public class TransferBalanceIn : SystemManagement.MethodParameters.Common.BaseIn
    {

        [Required]
        public string usr_userNameOrigin { get; set; }

        [Required] 
        public string usr_userNameDestiny { get; set; }

        [Required] 
        public decimal valueTransfer { get; set; }

    }
}
