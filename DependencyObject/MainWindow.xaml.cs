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

namespace DependencyObjectDemo
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
            Binding binding = new Binding("Text") { Source = txtBox1};
            //BindingOperations.SetBinding(stu, Student.NameProperty, binding);
            stu.SetBinding(Student.NameProperty, binding);

            Binding bd2 = new Binding("Name") { Source = stu };
            txtBox2.SetBinding(TextBox.TextProperty, bd2);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(stu.Name);
        }
    }
}
