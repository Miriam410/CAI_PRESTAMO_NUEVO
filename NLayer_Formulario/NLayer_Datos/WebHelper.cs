using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer_Entidades;
using System.Collections.Specialized;
using System.Net;
using System.Configuration;

namespace NLayer_Datos
{
    public class WebHelper
    {
        static WebClient client;
        static string rutaBase;
        static WebHelper()
        {
            client = new WebClient();
            client.Encoding = Encoding.UTF8;
            rutaBase = ConfigurationManager.AppSettings["URL_API"];
            client.Headers.Add("ContentType", "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public static string Get(string url)
        {
            var uri = rutaBase + url;
            var responseString = client.DownloadString(uri);
            return responseString;
        }
        public static string Post(string url, NameValueCollection parametro)
        {
            string uri = rutaBase + url;
            try
            {
                var response = client.UploadValues(uri, parametro);
                var responseString = Encoding.Default.GetString(response);
                return responseString;
            }
            catch (Exception)
            {
                return "{\"isOk\":false, \"id\":-1,\"error\":\"Error en el llamado al servicio\"}";
            }
        }
    }
}
