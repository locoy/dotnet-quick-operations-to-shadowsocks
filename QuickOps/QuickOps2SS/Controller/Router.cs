using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using QuickOps2SS.Properties;

namespace QuickOps2SS.Controller
{
    class Router
    {
        public List<string> Urls { get; set; }
        public List<string> Servers { get; set; }
        public Dictionary<string, string> BestRouteTable { get; private set; }
        public Router()
        {
            using (StreamReader sr = new StreamReader("Files/RouteTable.json"))
            {
                string jsontext = sr.ReadToEnd();
                if (String.IsNullOrEmpty(jsontext))
                {
                    Urls = new List<string>();
                    Servers = new List<string>();
                    BestRouteTable = new Dictionary<string, string>();
                }
                else
                {
                    //??
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
