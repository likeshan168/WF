using System;
using System.Collections.Generic;
using System.Data;
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

namespace BindingDemo.BindingDataTable
{
    /// <summary>
    /// Interaction logic for Demo.xaml
    /// </summary>
    public partial class Demo : Window
    {
        public Demo()
        {
            InitializeComponent();
            GetData();
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("test");
            DataColumn[] cols = new DataColumn[] 
            {
                new DataColumn("Id"),
                new DataColumn("Name"),
                new DataColumn("Age"),
                new DataColumn("Sex")
            };

            dt.Columns.AddRange(cols);
            return dt;
        }

        private void GetData()
        {
            DataTable dtInfo = CreateDataTable();
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dtInfo.NewRow();
                dr[0] = i;
                dr[1] = "猴王" + i.ToString();
                dr[2] = i + 10;
                dr[3] = "男";
                dtInfo.Rows.Add(dr);
            }

            lstView.ItemsSource = dtInfo.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
