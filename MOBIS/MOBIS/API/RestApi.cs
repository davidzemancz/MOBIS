using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MOBIS.API
{
    public class RestApi
    {
        public static string Post(string url, string jsonData, out bool ok)
        {
            ok = false;

            var request = WebRequest.Create("http://10.0.0.5/" + url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            var response = request.GetResponse();
            ok = ((HttpWebResponse)response).StatusCode == HttpStatusCode.OK;

            var respStream = response.GetResponseStream();

            var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();

            return data;
        }
    }
}
