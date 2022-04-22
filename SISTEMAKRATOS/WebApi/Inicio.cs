using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WebApi
{
    class Inicio
    {
        static  void Main(string[] args)
        {
            string url = "https://felgttestaws.digifact.com.gt/felapiv2/api/login/get_token";
            string user = "GT.000044653948.REDOWLTEST";
            string passw = "Ah?3rb4!";

             TokenSAT TokenObtenido= JsonConvert.DeserializeObject<TokenSAT>(GetToken(url, user, passw));

            //    Console.WriteLine(TokenObtenido.otorgado_a +"\n" + TokenObtenido.expira_en +"\n" + TokenObtenido.Token);



            var nitObtenido =  GetClientbyNit(TokenObtenido.Token);

          //  RESPONSE clienteSAT = JsonConvert.DeserializeObject<RESPONSE>(nitObtenido.ToString());
            Root clienteSAT = JsonConvert.DeserializeObject<Root>(nitObtenido);


            foreach (var item in clienteSAT.RESPONSE)
            {
                Console.WriteLine(item.NOMBRE);
                Console.WriteLine(item.NIT);
                Console.WriteLine(item.DEPARTAMENTO);
                Console.WriteLine(item.Direccion);
            }

          
            

        }

        public static string GetToken(string url,string user,string passw)
        {
            
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

        
        public static   string GetClientbyNit(string tokenobtenido)
        {
           
            WebRequest request = WebRequest.Create(TraerURL());
            request.Method = "get";
            request.Headers.Add("Authorization", tokenobtenido);
           
            WebResponse response = request.GetResponse();
            StreamReader strReader = new StreamReader(response.GetResponseStream());
            var cadena= strReader.ReadToEnd();
            return cadena;

        }

     
        public static string TraerURL()
        {
            string url = "https://felgttestaws.digifact.com.gt/felapiv2/api/sharedInfo?";
            string nit = "000044653948";
            string modulo = "SHARED_GETINFONITcom";
            string nitbuscado = "5382076";
            string user = "REDOWLTEST";
            string resultado = url + "NIT=" + nit + "&DATA1=" + modulo + "&" + "DATA2=NIT|" + nitbuscado + "&" + "USERNAME=" + user + "&=";
            return resultado;


        }


    }
}
