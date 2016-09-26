using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Fluent;

namespace Demo1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
            
        //}

        void OnStartup(object send, StartupEventArgs e)
        {
            ScreenTip.HelpPressed += ScreenTip_HelpPressed;
        }

        private void ScreenTip_HelpPressed(object sender, ScreenTipHelpEventArgs e)
        {
            MessageBox.Show(e.HelpTopic.ToString());
        }
    }
}
