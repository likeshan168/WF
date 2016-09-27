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

namespace BindingDemo.ObjectDataProviderBinding
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Window
    {
        public Demo()
        {
            InitializeComponent();
            SetBinding();
        }

        private void SetBinding()
        {
            ObjectDataProvider objPro = new ObjectDataProvider();
            objPro.ObjectInstance = new Calculate();
            objPro.MethodName = "Add";
            objPro.MethodParameters.Add("0");
            objPro.MethodParameters.Add("0");

            Binding bindingArg1 = new Binding("MethodParameters[0]") { Source = objPro ,BindsDirectlyToSource = true,UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged};
            Binding bindingArg2 = new Binding("MethodParameters[1]") { Source = objPro ,BindsDirectlyToSource = true,UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged};

            Binding bindingToResult = new Binding(".") { Source = objPro };

            textBox1.SetBinding(TextBox.TextProperty, bindingArg1);
            textBox2.SetBinding(TextBox.TextProperty, bindingArg2);
            textBox3.SetBinding(TextBox.TextProperty, bindingToResult);
        }
    }
}
