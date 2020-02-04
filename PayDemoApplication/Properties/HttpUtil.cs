using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace PayDemoApplication.Properties
{
    /**
     * Http Request Tools 
     */
    public class HttpUtil
    {
        public static string Put(string data, string uri)
        {
            return CommonHttpRequest(data, uri, "PUT");
        }

        private static string CommonHttpRequest(string data, string uri, string type)
        {
            uri = SignUtil.AddSignToUri(uri);
            var myRequest = (HttpWebRequest) WebRequest.Create(uri);
            var buf = Encoding.GetEncoding("UTF-8").GetBytes(data);
            myRequest.Method = type;
            myRequest.ContentLength = buf.Length;
            myRequest.ContentType = "application/json;charset=utf-8";
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;
            var newStream = myRequest.GetRequestStream();
            newStream.Write(buf, 0, buf.Length);
            newStream.Close();
            var myResponse = (HttpWebResponse) myRequest.GetResponse();
            var reader = new StreamReader(myResponse.GetResponseStream() ?? throw new NoNullAllowedException(),
                Encoding.UTF8);
            var returnXml = reader.ReadToEnd();
            reader.Close();
            myResponse.Close();
            return returnXml;
        }

        public static string Get(string uri)
        {
            uri = SignUtil.AddSignToUri(uri);
            var myRequest = (HttpWebRequest) WebRequest.Create(uri);
            myRequest.ContentType = "application/json;charset=utf-8";
            var myResponse = (HttpWebResponse) myRequest.GetResponse();
            var reader = new StreamReader(myResponse.GetResponseStream() ?? throw new NoNullAllowedException(),
                Encoding.UTF8);
            var returnJson = reader.ReadToEnd();
            reader.Close();
            myResponse.Close();
            return returnJson;
        }
    }
}