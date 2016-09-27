using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BindingDemo.ViewModels
{
    public class ReportLocation : Button
    {
        public static readonly RoutedEvent ReportLocationEvent = EventManager.RegisterRoutedEvent("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportLocationEventArgs>),typeof(ReportLocation));

        public event RoutedEventHandler ReportTime
        {
            add { AddHandler(ReportLocationEvent, value); }
            remove { RemoveHandler(ReportLocationEvent, value); }
        }

        public new void OnClick()
        {
            //base.OnClick();

            ReportLocationEventArgs args = new ReportLocationEventArgs(ReportLocationEvent, this);
            args.Location = Name;
            RaiseEvent(args);
        }
    }
}
