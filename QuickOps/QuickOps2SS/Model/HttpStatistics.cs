using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickOps2SS.Model
{
    public class HttpStatistics
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
        public event EventHandler StatusChanged;
        public void OnStatusChanged(EventArgs e)
        {
            StatusChanged?.Invoke(this, e);
        }

        public List<SingleHttpStatus> Statuses { get; set; }
        public int StatusCount
        {
            get
            {
                return Statuses.Count;
            }
        }
        public HttpStatistics()
        {
            Statuses = new List<SingleHttpStatus>();
        }
        public void InsertStatus(SingleHttpStatus singleHttpStatus)
        {
            if (!Statuses.Contains(singleHttpStatus))
            {
                Statuses.Add(singleHttpStatus);
                OnStatusChanged(new EventArgs());
            }
        }
        public void DeleteStatus(SingleHttpStatus singleHttpStatus)
        {
            if (Statuses.Contains(singleHttpStatus))
            {
                Statuses.Remove(singleHttpStatus);
                OnStatusChanged(new EventArgs());
            }
        }
    }
}
