using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BindingDemo.ViewModels;

namespace BindingDemo.ValidateBinding
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Window
    {
        public Demo()
        {
            InitializeComponent();

            Binding binding = new Binding("Value")
            {
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Source = slider1,
                Mode = BindingMode.TwoWay
            };

            ValidationRule rule = new RangeValidationRule();
            rule.ValidatesOnTargetUpdated = true;
            binding.ValidationRules.Add(rule);
            binding.NotifyOnValidationError = true;

            textBox1.SetBinding(TextBox.TextProperty, binding);
            textBox1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(ValidateError));
        }

        private void ValidateError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(textBox1).Count > 1)
            {
                textBox1.ToolTip = Validation.GetErrors(textBox1)[0].ErrorContent.ToString();
            }
            else
            {
                textBox1.ToolTip = "";
            }


        }
    }
}
