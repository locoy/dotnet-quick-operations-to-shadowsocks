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

namespace QuickOps2SS.Controller
{
    class Router
    {
        private class TableObject
        {
            public string[] urls { get; set; }
            public string[] servers { get; set; }
            public List<string[]> pairs { get; set; }
        }
        public List<string> Urls { get; set; }
        public List<string> Servers { get; set; }
        public Dictionary<string, string> BestRouteTable { get; private set; }
        public Router()
        {
            using (StreamReader sr = new StreamReader(@"..\..\Files\RouteTable.json"))
            {
                string jsontext = sr.ReadToEnd();
                Urls = new List<string>();
                Servers = new List<string>();
                BestRouteTable = new Dictionary<string, string>();
                if (!String.IsNullOrEmpty(jsontext))
                {
                    TableObject rr = JsonConvert.DeserializeObject<TableObject>(jsontext);
                    for (int i = 0; i < rr.urls.Length; i++)
                    {
                        Urls.Add(rr.urls[i]);
                    }
                }
            }
        }

        public Dictionary<string, string> RunAutoRouteConfig()
        {
            throw new NotImplementedException();
        }

        public void WriteToPacFile()
        {

        }

        public void WriteRouteTableToJson()
        {

        }
    }
}
