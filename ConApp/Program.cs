using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConApp.ServiceReference1;

namespace ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppServerClient client = new AppServerClient();
            Console.WriteLine(client.GetStringFromWCF());
            Console.ReadLine();
        }
    }
}
