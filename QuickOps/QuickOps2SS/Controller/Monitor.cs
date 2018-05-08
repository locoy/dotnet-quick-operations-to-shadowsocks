using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickOps2SS.Model;
using System.Threading;
using System.Windows.Forms;

namespace QuickOps2SS.Controller
{
    class Monitor
    {
        public Monitor()
        {
            Thread th = new Thread(UpdateStatistics);
            th.Start();
            Application.ApplicationExit += (object sender, EventArgs e) =>
            {
                th.Abort();
            };
        }

        private void UpdateStatistics()
        {
            while (true)
            {
                HttpStatistics.InsertStatus(new HttpStatistics.SingleHttpStatus(DateTime.Now.ToString(), 244));
                Thread.Sleep(2000);
            }
        }
    }
}
