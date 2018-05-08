using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOps2SS.Model
{
    static class HttpStatistics
    {
        public enum HttpStatusCode
        {
            Message = 100,
            Success = 200,
            Redirected = 300,
            BadRequest = 400,
            Unauthorized = 500,
            Unknown = 000
        }
        public class SingleHttpStatus
        {
            public string Url { get; set; }
            public HttpStatusCode StatusCode { get; set; }
            public SingleHttpStatus(string url, int code)
            {
                Url = url;
                switch(code / 100)
                {
                    case 1:
                        StatusCode = HttpStatusCode.Message;
                        break;
                    case 2:
                        StatusCode = HttpStatusCode.Success;
                        break;
                    case 3:
                        StatusCode = HttpStatusCode.Redirected;
                        break;
                    case 4:
                        StatusCode = HttpStatusCode.BadRequest;
                        break;
                    case 5:
                        StatusCode = HttpStatusCode.Unauthorized;
                        break;
                    default:
                        StatusCode = HttpStatusCode.Unknown;
                        break;
                }
            }
        }
        public static event EventHandler StatusChanged;
        private static void OnStatusChanged(EventArgs e)
        {

        }

        public static List<SingleHttpStatus> Statuses { get; set; }
        static HttpStatistics()
        {
            Statuses = new List<SingleHttpStatus>();
        }
        public static void InsertStatus(SingleHttpStatus singleHttpStatus)
        {
            if (!Statuses.Contains(singleHttpStatus))
            {
                Statuses.Add(singleHttpStatus);
                OnStatusChanged(new EventArgs());
            }
        }
        public static void DeleteStatus(SingleHttpStatus singleHttpStatus)
        {
            if (Statuses.Contains(singleHttpStatus))
            {
                Statuses.Remove(singleHttpStatus);
                OnStatusChanged(new EventArgs());
            }
        }
    }
}
