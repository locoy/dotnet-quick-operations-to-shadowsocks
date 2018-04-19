using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using Fiddler;

namespace QuickOps
{
    class Monitor
    {
        public Monitor()
        {
            Thread th = new Thread(PrintDateTime);
            th.Start();
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
                Output.AppendLine(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }

        private void OnOutputChanged(EventArgs e)
        {
            OutputChanged?.Invoke(this, e);
        }
    }
}
