using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;

namespace NetMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            FiddlerCoreStartupSettings setting = new FiddlerCoreStartupSettingsBuilder().ListenOnPort(1080).DecryptSSL().OptimizeThreadPool().Build();
            FiddlerApplication.Startup(setting);
            FiddlerApplication.Log.OnLogString += (object sender, LogEventArgs e) =>
            {
                Console.WriteLine(e.ToString());
            };
            FiddlerApplication.BeforeRequest += (Session ss) =>
            {
                FiddlerApplication.Log.LogString(ss.ToString());
            };
        }
    }
}
