using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebPruebaTecnica.Service
{
    public class ConsumoApi
    {
        public string GetApiHttpGet(string path)
        {
            var datos = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                datos = reader.ReadToEnd();
            }
            return datos;
        }

        public string GetApiHttpPost(string path, string valor)
        {
            string url = path;
            string postdata = valor;
            byte[] data = Encoding.UTF8.GetBytes(postdata);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            // turn our request string into a byte stream
            byte[] postBytes = Encoding.UTF8.GetBytes(postdata);

            // this is important - make sure you specify type this way
            request.ContentType = "application/json; charset=UTF-8";
            request.Accept = "application/json";
            request.ContentLength = postBytes.Length;
            //request.CookieContainer = Cookies;
            //request.UserAgent = currentUserAgent;
            Stream requestStream = request.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            // grab te response and print it out to the console along with the status code
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result;
            using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
            {
                result = rdr.ReadToEnd();
            }
            return result;
        }
    }
}