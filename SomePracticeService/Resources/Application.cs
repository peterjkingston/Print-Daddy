using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDaddyService
{
    public class Application : IApplication
    {
        IPrintDaddy _printDaddy;

        public Application(IPrintDaddy printDaddy)
        {
            _printDaddy = printDaddy;
        }

        public void Start()
        {
            _printDaddy.Start();
        }

        public void Stop()
        {
            _printDaddy.Stop();
        }
    }
}
