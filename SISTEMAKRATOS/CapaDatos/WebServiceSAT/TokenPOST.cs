using CapaDatos.Data;
using CapaDatos.Models.DocumentoSAT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.WebServiceSAT
{
    public class TokenPOST 
    {
        public static string GetToken()
        {
            Emisor emi = new EmisorFEL(1).emi;
            string user = emi.usernameFel;
            string passw = emi.passwordFel;
            System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(emi.urlToken);
            string tokenBody = "";
            request.Method = "post";
            request.ContentType = "application/json";
            string json = $"{{\"Username\":\"{user}\",\"Password\":\"{passw}\"}}";

            using (var streamWrite = new StreamWriter(request.GetRequestStream()))
            {
                streamWrite.Write(json);
                streamWrite.Flush();
                streamWrite.Close();
            }
            try
            {
                System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                // if (strReader == null) return;
                var readerobj = new StreamReader(strReader);
                tokenBody = readerobj.ReadToEnd().Trim();

            }
            catch (WebException ex) when (ex.Response is HttpWebResponse response)
            {

            }

            return tokenBody;
        }
        public static string GetToken(int entorno)
        {
            Emisor emi = new EmisorFEL(entorno).emi;
            string user = emi.usernameFel;
            string passw = emi.passwordFel;
            System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(emi.urlToken);
            string tokenBody = "";
            request.Method = "post";
            request.ContentType = "application/json";
            string json = $"{{\"Username\":\"{user}\",\"Password\":\"{passw}\"}}";

            using (var streamWrite = new StreamWriter(request.GetRequestStream()))
            {
                streamWrite.Write(json);
                streamWrite.Flush();
                streamWrite.Close();
            }
            try
            {
                System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
                WebResponse response = request.GetResponse();
                Stream strReader = response.GetResponseStream();
                // if (strReader == null) return;
                var readerobj = new StreamReader(strReader);
                tokenBody = readerobj.ReadToEnd().Trim();

            }
            catch (WebException ex) when (ex.Response is HttpWebResponse response)
            {

            }

            return tokenBody;
        }

    }
}
