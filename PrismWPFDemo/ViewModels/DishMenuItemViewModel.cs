using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;
using PrismWPFDemo.Models;

namespace PrismWPFDemo.ViewModels
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class DishMenuItemViewModel : NotificationObject
#pragma warning restore CS0618 // Type or member is obsolete
    {
        public Dish Dish { get; set; }
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; RaisePropertyChanged("IsSelected"); }
        }
    }

}
