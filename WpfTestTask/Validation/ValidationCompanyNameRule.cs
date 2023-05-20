using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ValidationResult = System.Windows.Controls.ValidationResult;

namespace WpfApp2.Validation
{
    internal class ValidationCompanyNameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length<=40)
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Company Name is too long");
        }
    }
}