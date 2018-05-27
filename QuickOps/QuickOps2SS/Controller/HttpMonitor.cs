using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QuickOps2SS.Model;
using System.Windows.Forms;
using Fiddler;
using System.Text.RegularExpressions;

namespace QuickOps2SS.Controller
{
    public class HttpMonitor : IDisposable
    {
        public event EventHandler NewSessionHandler;
        Proxy SecureEndpoint;
        string SecureEndpointHostname = "localhost";
        int SecureEndpointPort = 7777;
        List<Session> oAllSessions = new List<Session>();

        public void DoQuit()
        {
            if (null != SecureEndpoint) SecureEndpoint.Dispose();
            FiddlerApplication.Shutdown();
            Thread.Sleep(500);
        }

        public void OnNewSession(object sender, EventArgs e)
        {
            NewSessionHandler?.Invoke(sender, e);
        }

        //https://www.cnblogs.com/jeffwongishandsome/archive/2010/10/14/1851217.html
        private string GetDomainName(string url)
        {
            if (url == null)
            {
                throw new Exception("empty url");
            }
            Regex reg = new Regex(@"(?<=://)([\w-]+\.)+[\w-]+(?<=/?)");
            return reg.Match(url, 0).Value.Replace("/", string.Empty);
        }
        
        public HttpMonitor()
        {
            FiddlerApplication.BeforeRequest += (Session oS) =>
            {
                oS.bBufferResponse = false;
                Monitor.Enter(oAllSessions);
                oAllSessions.Add(oS);
                OnNewSession(this, new EventArgs());
                Monitor.Exit(oAllSessions);
                if ((oS.oRequest.pipeClient.LocalPort == SecureEndpointPort) && (oS.hostname == SecureEndpointHostname))
                {
                    oS.utilCreateResponseAndBypassServer();
                    oS.oResponse.headers.SetStatus(200, "Ok");
                    oS.oResponse["Content-Type"] = "text/html; charset=UTF-8";
                    oS.oResponse["Cache-Control"] = "private, max-age=0";
                    oS.utilSetResponseBody("<html><body>Request for https://" + SecureEndpointHostname + ":" + SecureEndpointPort.ToString() + " received. Your request was:<br /><plaintext>" + oS.oRequest.headers.ToString());
                }
            };
            FiddlerApplication.AfterSessionComplete += (Session oS) => { };
            Application.ApplicationExit += (object senser, EventArgs e) => { DoQuit(); };
            CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);

            ushort iPort = 8877;
            FiddlerCoreStartupSettings startupSettings =
                new FiddlerCoreStartupSettingsBuilder()
                    .ListenOnPort(iPort)
                    .RegisterAsSystemProxy()
                    .DecryptSSL()
                    //.AllowRemoteClients()
                    //.ChainToUpstreamGateway()
                    //.MonitorAllConnections()
                    //.HookUsingPACFile()
                    .CaptureLocalhostTraffic()
                    //.CaptureFTP()
                    .OptimizeThreadPool()
                    //.SetUpstreamGatewayTo("http=CorpProxy:80;https=SecureProxy:443;ftp=ftpGW:20")
                    .Build();
            FiddlerApplication.Startup(startupSettings);

            FiddlerApplication.Log.LogFormat("Created endpoint listening on port {0}", iPort);
            FiddlerApplication.Log.LogFormat("Gateway: {0}", CONFIG.UpstreamGateway.ToString());
            SecureEndpoint = FiddlerApplication.CreateProxyEndpoint(SecureEndpointPort, true, SecureEndpointHostname);
            if (null != SecureEndpoint)
            {
                FiddlerApplication.Log.LogFormat($"Created secure endpoint listening on port {SecureEndpointPort}, using a HTTPS certificate for '{SecureEndpointHostname}'");
            }
        }

        public void Dispose()
        {
            DoQuit();
            this.Dispose();
        }
    }
}
