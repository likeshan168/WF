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
    public class StateToNullableBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            State state = (State)value;

            switch (state)
            {
                case State.Available:
                    return true;
                case State.Locked:
                    return false;
                case State.Unkown:
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? nb = (bool?)value;
            switch (nb)
            {
                case true:
                    return State.Available;
                case false:
                    return State.Locked;
                case null:
                default:
                    return State.Unkown;
            }
        }
    }
}
