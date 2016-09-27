using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BindingDemo.ViewModels
{
    public class ReportLocationEventArgs : RoutedEventArgs
    {
        public ReportLocationEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {

        }

        public string Location { get; set; }
    }
}
