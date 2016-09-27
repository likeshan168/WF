using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BindingDemo.ViewModels
{
    public class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double d = 0;
            if(double.TryParse(value.ToString(),out d))
            {
                if(d>0&&d<=100)
                {
                    return new ValidationResult(true, null);
                }
            }

            return new ValidationResult(false, "ErrorContent");
        }
    }
}
