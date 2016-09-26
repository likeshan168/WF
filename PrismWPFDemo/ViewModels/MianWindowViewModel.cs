using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using PrismWPFDemo.Models;
using PrismWPFDemo.Services;

namespace PrismWPFDemo.ViewModels
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class MianWindowViewModel : NotificationObject
#pragma warning restore CS0618 // Type or member is obsolete
    {
        private Restaurant restaurant;
        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                restaurant = value;
                RaisePropertyChanged("Restaurant");
            }
        }

        //private void RaisePropertyChanged(string v)
        //{
        //    throw new NotImplementedException();
        //}

        //外加的一个属性，点菜的数量
        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                RaisePropertyChanged("Count");
            }
        }

        private List<DishMenuItemViewModel> dishMenu;
        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                RaisePropertyChanged("DishMenu");
            }
        }

        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuCommand { get; set; }
        public MianWindowViewModel()
        {
            LoadDishMenu();
            LoadRestaurant();
            PlaceOrderCommand = new DelegateCommand(new Action(PlaceOrderCommandExecute));
            SelectMenuCommand = new DelegateCommand(new Action(SelectMenuCommandExecute));

        }

        private void SelectMenuCommandExecute()
        {
            Count = DishMenu.Count(n => n.IsSelected);
        }

        private void PlaceOrderCommandExecute()
        {
            var selectedDishes = dishMenu.Where(d => d.IsSelected).Select(d => d.Dish.Name).ToList();

            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功");
        }

        private void LoadRestaurant()
        {
            Restaurant = new Restaurant() { Name = "百年苏韵", Address = "江苏大学", PhoneNumber = "121212121212" };
        }

        private void LoadDishMenu()
        {
            DishMenu = new List<DishMenuItemViewModel>();
            IDataService ds = new XMLDataService();
            var dishes = ds.GetAllDishes();

            foreach (var d in dishes)
            {
                DishMenuItemViewModel item = new DishMenuItemViewModel() { Dish = d };
                DishMenu.Add(item);
            }
        }
    }
}
