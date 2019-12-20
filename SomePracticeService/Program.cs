using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace PrintDaddyService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<PrintDaddy>(s =>
                {
                    s.ConstructUsing(pDaddy => new PrintDaddy());
                    s.WhenStarted(pDaddy => pDaddy.Start());
                    s.WhenStopped(pDaddy => pDaddy.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("PrintDaddy");
                x.SetDisplayName("Print Daddy");
                x.SetDescription("This service prints new documents as they become ready from the remote server.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
