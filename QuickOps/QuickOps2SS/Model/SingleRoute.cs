using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOps2SS.Model
{
    public class SingleRoute
    {
        public string ForwardServer { get; private set; }
        public string ForwardUrl { get; private set; }
        public SingleRoute(string server, string url)
        {
            if (IsValidUrl(url))
            {
                ForwardUrl = url;
            }
            if (IsValidServer(server))
            {
                ForwardServer = server;
            }
        }

        public new string ToString()
        {
            return ForwardUrl + "\t" + ForwardServer;
        }

        private bool IsValidUrl(string url)
        {
            throw new NotImplementedException();
        }

        private bool IsValidServer(string server)
        {
            throw new NotImplementedException();
        }

    }
}
