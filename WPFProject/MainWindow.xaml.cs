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
            StartWFRuntime();
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
                    wfApp.Run();
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
            StartEngine();
        }

        private void cmdDrive_Click(object sender, RoutedEventArgs e)
        {
            GoForward();
        }

        private void cmdPark_Click(object sender, RoutedEventArgs e)
        {
            PutInNeutral();
        }

        private void cmdReverse_Click(object sender, RoutedEventArgs e)
        {
            PutInReverse();
        }

        private void cmdTurnOff_Click(object sender, RoutedEventArgs e)
        {
            TurnOffEngine();
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
            }
        }

        public void PutInNeutral()
        {
            try
            {
                ResumeBookmark("PutInPark");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GoForward()
        {
            try
            {
                ResumeBookmark("InGear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TurnOffEngine()
        {
            try
            {
                ResumeBookmark("TurnOff");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void StartEngine()
        {
            try
            {
                ResumeBookmark("StartEngine");
            }
            catch (Exception ex)
            {
                throw ex;
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

        private UnhandledExceptionAction OnUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs uh)
        {
            return UnhandledExceptionAction.Terminate;
        }

        private void OnWorkflowCompleted(WorkflowApplicationCompletedEventArgs wc)
        {
            DisableButtons();
        }

        private void OnWorkflowIdle(WorkflowApplicationIdleEventArgs args)
        {
            var bookmarkList = new StringBuilder();
            DisableButtons();

            foreach (var bk in args.Bookmarks)
            {
                DriveTransition ret;
                Enum.TryParse(bk.BookmarkName, out ret);
                switch (ret)
                {
                    case DriveTransition.StartEngine:
                        cmdStartEngine.IsEnabled = true;
                        break;
                    case DriveTransition.TurnOff:
                        cmdTurnOff.IsEnabled = true;
                        break;
                    case DriveTransition.InGear:
                        cmdDrive.IsEnabled = true;
                        break;
                    case DriveTransition.PutInReverse:
                        cmdReverse.IsEnabled = true;
                        break;
                    case DriveTransition.PutInPark:
                        cmdPark.IsEnabled = true;
                        break;
                }

                bookmarkList.Append(bk.BookmarkName);
            }
        }

        private void DisableButtons()
        {
            cmdDrive.IsEnabled = false;
            cmdPark.IsEnabled = false;
            cmdReverse.IsEnabled = false;
            cmdStartEngine.IsEnabled = false;
            cmdTurnOff.IsEnabled = false;
        }
    }
}
