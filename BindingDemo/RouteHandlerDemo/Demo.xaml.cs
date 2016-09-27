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

namespace BindingDemo.RouteHandlerDemo
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Window
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void btn_ReportTime(object sender, ReportLocationEventArgs e)
        {
            MessageBox.Show((sender as FrameworkElement).Name);
        }
    }
}
