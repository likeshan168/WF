using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WFProject;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static WorkflowApplication wfApp = null;
        private void StartWFRuntime()
        {
            try
            {
                if (wfApp == null)
                {
                    wfApp = new WorkflowApplication(new Activity1());
                    wfApp.SynchronizationContext = SynchronizationContext.Current;
                    wfApp.OnUnhandledException = OnUnhandledException;
                    wfApp.Completed = OnWorkflowCompleted;
                    wfApp.Idle = OnWorkflowIdle;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IDictionary<string, object> results = WorkflowInvoker.Invoke(new Activity1());
                string result = results["returnValue"].ToString();
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdStartEngine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdDrive_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdNeutral_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdReverse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdTurnOff_Click(object sender, RoutedEventArgs e)
        {

        }

        public void PutInReverse()
        {
            try
            {
                ResumeBookmark("PutInReverse");
            }
            catch (Exception ex)
            {
                throw ex;
                throw;
            }
        }

        private void ResumeBookmark(string bookmark)
        {
            try
            {
                wfApp.ResumeBookmark(bookmark, string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
