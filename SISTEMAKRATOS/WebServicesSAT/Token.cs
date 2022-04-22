using System;
using System.IO;
using System.Net;

namespace WebServicesSAT
{
    public class Token
    {
        static void Main(string[] args)
        {

            GetToken();
        }

        public static string GetToken()
        {
            string url = "https://felgttestaws.digifact.com.gt/felapiv2/api/login/get_token";
            string user = "GT.000044653948.REDOWLTEST";
            string passw = "Ah?3rb4!";
            var request = (HttpWebRequest)WebRequest.Create(url);
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
