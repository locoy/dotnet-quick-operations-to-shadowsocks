using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Fiddler;

namespace QuickOps
{
    class Monitor
    {
        Thread th;
        public Monitor()
        {
            th = new Thread(PrintDateTime);
            th.Start();
            Application.ApplicationExit += new EventHandler(OnAppExit);
        }
        public event EventHandler OutputChanged;
        private StringBuilder output = new StringBuilder();
        public StringBuilder Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
                OnOutputChanged(new EventArgs());
            }
        }
        
        private void PrintDateTime()
        {
            while (true)
            {
                Output = Output.AppendLine(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }

        private void OnOutputChanged(EventArgs e)
        {
            OutputChanged?.Invoke(this, e);
        }

        private void OnAppExit(object sender, EventArgs e)
        {
            th.Abort();
        }
    }
}
