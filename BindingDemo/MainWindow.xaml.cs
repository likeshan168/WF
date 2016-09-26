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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BindingDemo.Models;

namespace BindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Student stu;
        public MainWindow()
        {
            InitializeComponent();
            stu = new Student();
            Binding bind = new Binding();
            bind.Source = stu;
            bind.Path = new PropertyPath("Name");
            //this.textbox1.SetBinding(TextBox.TextProperty, bind);


            List<Student> infos = new List<Student>()
            {
                new Student() {Id =1,Age=11,Name="Tom" },
                new Student() {Id =2,Age=12,Name="Darren" },
                new Student() {Id =3,Age=13,Name="Jacky" },
                new Student() {Id =4,Age=14,Name="Andy" }
            };

            lbStudent.ItemsSource = infos;
            //lbStudent.DisplayMemberPath = "Name";

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            stu.Name += "f";
            //new Window().Show();
        }
    }
}
