using System.ComponentModel.DataAnnotations;

namespace SystemManagement.Common.CustomValidations
{
    public class MobileValidation : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            string mobile = value != null ? value.ToString() : null;
            if (!string.IsNullOrEmpty(mobile)
                && (mobile.Length != 10 || !mobile.StartsWith("3") || mobile.IndexOf('0', 3, 1) != -1))
            {
                return false;
            }
            return true;
        }

    }
}
