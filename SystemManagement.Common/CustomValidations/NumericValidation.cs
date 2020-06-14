using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SystemManagement.Common.CustomValidations
{

    public class NumericValidation : ValidationAttribute
    {

        /// <summary>
        /// Longitud
        /// </summary>
        public int length { get; private set; }

        /// <summary>
        /// Decimales
        /// </summary>
        public int decimals { get; private set; }

        public NumericValidation(int length, int decimals)
        {
            this.length = length;
            this.decimals = decimals;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string decimalSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                string decimalRegex = decimals > 0 ? string.Concat("(", decimalSeparator, "[0-9]{1,", decimals, "}){0,1}") : string.Concat("(", decimalSeparator, "[0]{1,}){0,1}");
                string regex = string.Concat("^[0-9]{1,", length - decimals, "}", decimalRegex, "$");
                var match = Regex.Match(value.ToString(), regex, RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
