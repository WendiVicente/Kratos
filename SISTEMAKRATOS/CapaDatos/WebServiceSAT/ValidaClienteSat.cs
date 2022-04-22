using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.WebServiceSAT
{
    public class ValidaClienteSat
    {
        public static string GetClientbyNit(string tokenobtenido, string nitbuscado)
        {
            System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
            WebRequest request = WebRequest.Create(TraerURL(nitbuscado));
            request.Method = "get";
            request.Headers.Add("Authorization", tokenobtenido);            
            WebResponse response = request.GetResponse();
            StreamReader strReader = new StreamReader(response.GetResponseStream());
            var cadena = strReader.ReadToEnd();
            return cadena;


        }


        public static string TraerURL(string nitbuscado)
        {
            string url = "https://felgtaws.digifact.com.gt/felapiv2/api/sharedInfo?";
            string nit = "000086689126";
            string modulo = "SHARED_GETINFONITcom";
            //string nitbuscado = "5382076";
            string user = "86689126";
            string resultado = url + "NIT=" + nit + "&DATA1=" + modulo + "&" + "DATA2=NIT|" + nitbuscado + "&" + "USERNAME=" + user + "&=";
            return resultado;


        }



    }
}
