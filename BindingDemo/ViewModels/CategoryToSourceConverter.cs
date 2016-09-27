using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BindingDemo.Models;

namespace BindingDemo.ViewModels
{
    public class CategoryToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Category category = (Category)value;
            switch(category)
            {
                case Category.Bomber:
                    return @"Images/Bomber.png";
                case Category.Fighter:
                    return @"Images/Fighter.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
