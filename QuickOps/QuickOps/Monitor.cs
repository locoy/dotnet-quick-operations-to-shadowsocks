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
        public event EventHandler OutputChanged;
        public static StringBuilder output = new StringBuilder();
        public StringBuilder Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
                OnPropertyChanged(new EventArgs());
            }
        }

        public void StartPrintDateTime()
        {
            Thread th = new Thread(PrintDateTime);
            th.Start();
        }
        
        private static void PrintDateTime()
        {
            while (true)
            {
                output.Append(DateTime.Now.ToString());
                output.Append("\n");
                Thread.Sleep(1000);
            }
        }

        private void OnPropertyChanged(EventArgs e)
        {
            OutputChanged?.Invoke(this, e);
        }
    }
}
