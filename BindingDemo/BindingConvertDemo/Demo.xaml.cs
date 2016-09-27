using System;
using System.Collections.Generic;
using System.IO;
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
using BindingDemo.Models;

namespace BindingDemo.BindingConvertDemo
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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> infos = new List<Plane>()
            {
                new Plane() {category=Category.Bomber,name="B-1",state=State.Unkown },
                new Plane() {category=Category.Bomber,name="B-2",state=State.Unkown },
                new Plane() {category=Category.Fighter,name="F-22",state=State.Locked },
                new Plane() {category=Category.Bomber,name="Su-47",state=State.Unkown },
                new Plane() {category=Category.Fighter,name="B-52",state=State.Available },
                new Plane() {category=Category.Bomber,name="J-10",state=State.Unkown }
            };

            listBox1.ItemsSource = infos;

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Plane item in listBox1.Items)
            {
                sb.AppendLine(string.Format("Category = {0}, State = {1}, Name = {2}", item.category, item.state, item.name));
            }

            File.WriteAllText("PlaneList.txt", sb.ToString());
        }
    }
}
