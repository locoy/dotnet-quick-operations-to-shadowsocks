using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using QuickOps2SS.Model;

namespace QuickOps2SS.Controller
{
    class SSController
    {
        public HttpStatistics statistics;
        public SSController()
        {
            statistics = new HttpStatistics();
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
                statistics.InsertStatus(new HttpStatistics.SingleHttpStatus(DateTime.Now.ToString(), 100));
                Thread.Sleep(2000);
            }
        }
    }
}
