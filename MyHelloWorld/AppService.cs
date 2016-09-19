using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHelloWorld
{
    public class AppServer: IAppServer
    {
        public string GetStringFromWCF()
        {
            return string.Format("hello world");
        }
    }
}
