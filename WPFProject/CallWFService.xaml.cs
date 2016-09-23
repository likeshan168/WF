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
using WPFProject.ServiceReference;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for CallWFService.xaml
    /// </summary>
    public partial class CallWFService : Window
    {
        public CallWFService()
        {
            InitializeComponent();
            SetDataSource();
            
        }

        private void SetDataSource()
        {
            Service1Client client = new Service1Client();
            var results = client.GetCustomers();
            this.dataGrid.DataContext = results;
        }
    }
}
