using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Controls;
using ValidationResult = System.Windows.Controls.ValidationResult;

namespace WpfApp2.Validation
{
    internal class ValidationEmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        { 
            if (new EmailAddressAttribute().IsValid(value.ToString())) 
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Email is invalid.");
        }
    }
}

    
