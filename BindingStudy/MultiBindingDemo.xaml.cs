using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingStudy
{
    /// <summary>
    /// Interaction logic for MultiBindingDemo.xaml
    /// </summary>
    public partial class MultiBindingDemo : Window
    {
        public MultiBindingDemo()
        {
            InitializeComponent();
            SetMultiBinding();
        }

        private void SetMultiBinding()
        {
            Binding b1 = new Binding("Text") { Source = txtBox1 };
            Binding b2 = new Binding("Text") { Source = txtBox2 };
            Binding b3 = new Binding("Text") { Source = txtBox3 };
            Binding b4 = new Binding("Text") { Source = txtBox4 };

            MultiBinding mb = new MultiBinding() { Mode = BindingMode.OneWay };

            mb.Bindings.Add(b1);
            mb.Bindings.Add(b2);
            mb.Bindings.Add(b3);
            mb.Bindings.Add(b4);

            mb.Converter =new LogonMultiBindingConverter();

            button1.SetBinding(IsEnabledProperty, mb);

        }
    }

    public class LogonMultiBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Cast<string>().Any(text => string.IsNullOrWhiteSpace(text)) && values[0].ToString() == values[1].ToString()&&values[2].ToString()==values[3].ToString())
            {
                return true;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
