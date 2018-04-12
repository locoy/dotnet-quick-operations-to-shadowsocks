using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace QuickOps
{
    class Monitor
    {
        public Stream output;

        public void CaptureHttp()
        {
            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add("http://*:80");
                listener.Prefixes.Add("https://*:80");
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                // Obtain a response object.
                HttpListenerResponse response = context.Response;
                // Construct a response.
                string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                
                // You must close the output stream.
                //output.Close();
                //listener.Stop();
            }
        }
    }
}
