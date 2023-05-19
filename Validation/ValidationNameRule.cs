using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp2.DbRepository;
using WpfApp2.Model;

namespace WpfApp2.Validation
{
    internal class ValidationNameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            List<Customer> customers = DbRepositorySingelton.GetInstance().GetDbRepository().FetchData();
            if (!customers.Any(t=>t.Name.Equals(value.ToString())))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Name is already in used.");
        }
   }
}
