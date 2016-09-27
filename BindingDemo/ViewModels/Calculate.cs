using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingDemo.ViewModels
{
    public class Calculate
    {
        public string Add(string arg1, string arg2)
        {
            double x;
            double y;
            double z;
            if(double.TryParse(arg1, out x)&&double.TryParse(arg2,out y))
            {
                z = x + y;
                return z.ToString();
            }

            return "Input Error";
        }
    }
}
