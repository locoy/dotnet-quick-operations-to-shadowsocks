using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using QuickOps2SS.Properties;
using QuickOps2SS.Model;

namespace QuickOps2SS.Controller
{
    public class RouterController
    {
        RouteTable table = new RouteTable();
        public RouterController()
        {

        }

        public RouteTable GetRouteTable()
        {
            return table;
        }

        public void InsertRoute(string url)
        {
            if (IsValidUrl(url))
            {
                table.Urls.Add(url);
            }
        }

        private bool IsValidServer(string server)
        {
            throw new NotImplementedException();
        }

        private bool IsValidUrl(string url)
        {
            throw new NotImplementedException();
        }

        private bool IsValidRoute(SingleRoute route)
        {
            string server = route.ForwardServer;
            string url = route.ForwardUrl;
            throw new NotImplementedException();
        }
    }
}
