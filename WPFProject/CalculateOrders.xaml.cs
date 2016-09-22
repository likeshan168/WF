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
using System.Windows.Shapes;
using DataModel;
using WFProject;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for CalculateOrders.xaml
    /// </summary>
    public partial class CalculateOrders : Window
    {

        private WorkflowApplication wfApp;
        public CalculateOrders()
        {
            InitializeComponent();
            cmdApprove.IsEnabled = false;
        }

        private UnhandledExceptionAction OnUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs uh)
        {
            return UnhandledExceptionAction.Terminate;
        }

        private void OnWorkflowIdle(WorkflowApplicationIdleEventArgs e)
        {
            cmdApprove.IsEnabled = true;
        }

        private void OnWorkflowCompleted(WorkflowApplicationCompletedEventArgs wc)
        {
            foreach (var arg in wc.Outputs)
            {
                if (arg.Key.Equals("argOutCustomers"))
                {
                    var customers = arg.Value as Customers;
                    foreach (var cust in customers)
                    {
                        foreach (var order in cust.CustomerOrders)
                        {
                            MessageBox.Show(string.Format(" Approved: {2}, Total Order Price: {0} with Tax: {1}", string.Format("{0:C}", order.TotalPrice), string.Format("{0:C}", order.Tax), order.OrderApproved.ToString()));
                        }
                    }
                }

                cmdRuntime.IsEnabled = true;
            }


        }

        private void cmdRuntime_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderingActivity orderingActivity = new OrderingActivity();
                wfApp = new WorkflowApplication(orderingActivity);
                wfApp.SynchronizationContext = SynchronizationContext.Current;
                wfApp.OnUnhandledException = OnUnhandledException;
                wfApp.Completed = OnWorkflowCompleted;
                wfApp.Idle = OnWorkflowIdle;
                wfApp.Run();
                cmdRuntime.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmdApprove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wfApp.ResumeBookmark("ApproveOrder", chkApprove.IsChecked);
                cmdApprove.IsEnabled = false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
