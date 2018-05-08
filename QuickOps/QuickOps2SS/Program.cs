using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickOps2SS.View;
using QuickOps2SS.Model;

namespace QuickOps2SS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TrayIconForm trayIconForm = new TrayIconForm();
            Application.Run();
        }
    }
}
