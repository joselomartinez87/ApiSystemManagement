using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagement.Common.CustomValidations
{
    public class VehicleModelValidation : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            int? mobile = null;
            if (value != null)
            {
                mobile = int.Parse(value.ToString());
            }
            if (mobile != null)
            {
                int maxModel = DateTime.Now.Year + 1;
                if (mobile < 1900 || mobile > maxModel)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
