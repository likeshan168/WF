using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismWPFDemo.Models;

namespace PrismWPFDemo.Services
{
    interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
