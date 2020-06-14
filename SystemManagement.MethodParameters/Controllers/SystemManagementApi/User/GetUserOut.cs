using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.MethodParameters.Controllers.SystemManagementApi.User
{
    public class GetUserOut : MethodParameters.Common.BaseOut
    {
		public UserResult resultGetUser { set; get; }
		public class UserResult
        {
			public decimal usrID {set; get;}
			public string usr_code {set; get;}
			public string usr_userName {set; get;}
			public string usr_password {set; get;}
			public string usr_fullName {set; get;}
			public string usr_documentType {set; get;}
			public string usr_numberDocument {set; get;}
			public string usr_email {set; get;}
			public System.Nullable<Decimal> usr_balance { set; get;}
			public string usr_role {set; get;}
			public string usr_creationUser {set; get;}
			public System.Nullable<System.DateTime> usr_creationDate { get; set; }
			public string usr_modificationUser { get; set; }
			public System.Nullable<System.DateTime> usr_modificationDate { get; set; }
			public string usr_status { get; set; }

		}
	}
}
