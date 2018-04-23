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
        private readonly ICollection<Session> oAllSessions = new List<Session>();
        private Proxy oSecureEndpoint;

        public Monitor()
        {
            StartCapture();
            FiddlerApplication.Log.OnLogString += (object sender, LogEventArgs e) =>
            {
                Output = new StringBuilder(e.LogString);
            };
        }

        public event EventHandler OutputChanged;
        private StringBuilder output = new StringBuilder();
        public StringBuilder Output
        {
            get
            {
                return output;
            }
            private set
            {
                output = value;
                OnOutputChanged(new EventArgs());
            }
        }
        
        private void PrintOutput(string s)
        {
            Output = Output.AppendLine(s);
        }

        private void OnOutputChanged(EventArgs e)
        {
            OutputChanged?.Invoke(this, e);
        }

        private void StartCapture()
        {
            FiddlerApplication.Log.OnLogString += (object sender, LogEventArgs e) =>
            {
                PrintOutput("** LogString: " + e.LogString);
            };
            FiddlerApplication.BeforeRequest += (Session oS) =>
            {
                oS.bBufferResponse = false;
                lock (oAllSessions)
                {
                    oAllSessions.Add(oS);
                }
                if ((oS.oRequest.pipeClient.LocalPort == 80) && (oS.hostname == "baidu.com"))
                {
                    oS.utilCreateResponseAndBypassServer();
                    oS.oResponse.headers.SetStatus(200, "Ok");
                    oS.oResponse["Content-Type"] = "text/html; charset=UTF-8";
                    oS.oResponse["Cache-Control"] = "private, max-age=0";
                    oS.utilSetResponseBody("<html><body>Request for httpS://" + "baidu.com" + ":" + 80.ToString() + " received. Your request was:<br /><plaintext>" + oS.oRequest.headers.ToString());
                }
            };
            FiddlerApplication.AfterSessionComplete += (Session oS) =>
            {
                int count;
                lock (oAllSessions)
                {
                    count = oAllSessions.Count;
                }
                //Console.Title = $"Session list contains: {count} sessions";
            };
            CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            ushort iPort = 8877;
            FiddlerCoreStartupSettings startupSettings = new FiddlerCoreStartupSettingsBuilder().ListenOnPort(iPort).DecryptSSL().OptimizeThreadPool().Build();
            FiddlerApplication.Startup(startupSettings);
            FiddlerApplication.Log.LogFormat("Created endpoint listening on port {0}", iPort);
            FiddlerApplication.Log.LogFormat("Gateway: {0}", CONFIG.UpstreamGateway.ToString());
            oSecureEndpoint = FiddlerApplication.CreateProxyEndpoint(80, true, "baidu.com");
            if (null != oSecureEndpoint)
            {
                FiddlerApplication.Log.LogFormat("Created secure endpoint listening on port {0}, using a HTTPS certificate for '{1}'", 80, "baidu.com");
            }
        }

    }
}
