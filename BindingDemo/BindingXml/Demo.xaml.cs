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

namespace BindingDemo.BindingXml
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Window
    {
        public Demo()
        {
            InitializeComponent();
            BindInfo();
        }
        private void BindInfo()
        {
            XmlDataProvider dp = new XmlDataProvider();
            dp.Source = new Uri(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Data.xml"));

            dp.XPath = @"StudentList/Student";
            lstView.DataContext = dp;
            lstView.SetBinding(ItemsControl.ItemsSourceProperty, new Binding());
        }
    }
}
