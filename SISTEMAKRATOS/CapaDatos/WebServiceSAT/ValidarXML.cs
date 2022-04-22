using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.DocumentoSAT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace CapaDatos.WebServiceSAT
{
    public class ValidarXML
    {
        public static IList<ListarDetalleFacturas> _listadetalle = null;
        public static Emisor emi = new EmisorFEL(1).emi;
        public static string enviarxml(string tokenobtenido, RESPONSE cliente, IList<ListarDetalleFacturas> detalleFacturas, string nombreDoc)
        {

            var documentocertificado = "";
            _listadetalle = detalleFacturas;
            System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(TraerURL());
            request.Method = "post";
            request.Headers.Add("Authorization", tokenobtenido);
            request.ContentType = "application/json";

            var bodyxml = GeneraXML.XMLformato(cliente,_listadetalle);
           
          

            using (var streamWrite = new StreamWriter(request.GetRequestStream()))
            {
                streamWrite.Write(bodyxml);
                streamWrite.Flush();
                streamWrite.Close();
            }
            try
            {
                System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
                WebResponse response = request.GetResponse();//falla por aca
                Stream strReader = response.GetResponseStream();
                // if (strReader == null) return;
                var readerobj = new StreamReader(strReader);
                documentocertificado = readerobj.ReadToEnd().Trim();
                

            }
            catch (WebException ex) when (ex.Response is HttpWebResponse response)
            {
                
            }


            return documentocertificado;


        }
        public static string TraerURL()
        {

            string Tipo = "CERTIFICATE_DTE_XML_TOSIGN";
            string format = "XML";
            string resultado = emi.urlFel + "NIT=" + emi.usernameFel.Split('.').ElementAt(1) + "&TIPO=" + Tipo +  "&" + "FORMAT=" + format + "&" + "USERNAME=" + emi.usernameFel.Split('.').ElementAt(2);
            return resultado;

        }
        public static string UrlAnularFel()
        {
                        
            string Tipo = "ANULAR_FEL_TOSIGN";
            string format = "XML";
            string resultado = emi.urlFel + "NIT=" + emi.usernameFel.Split('.').ElementAt(1) + "&TIPO=" + Tipo + "&" + "FORMAT=" + format + "&" + "USERNAME=" + emi.usernameFel.Split('.').ElementAt(2);
            return resultado;

        }

        public static string EnviarXmlAnularFel(string token, DocumentoCertificadoSAT docToAnular, string motivo)
        {
            var documentocertificado = "";

            System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(UrlAnularFel());
            request.Method = "post";
            request.Headers.Add("Authorization", token);
            request.ContentType = "Application/json";

            var bodyxml = GeneraXML.FormatoAnularFel(docToAnular, motivo);



            using (var streamWrite = new StreamWriter(request.GetRequestStream()))
            {
                streamWrite.Write(bodyxml);
                streamWrite.Flush();
                streamWrite.Close();
            }
            try
            {
                System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
                WebResponse response = request.GetResponse();//falla por aca
                Stream strReader = response.GetResponseStream();
                // if (strReader == null) return;
                var readerobj = new StreamReader(strReader);
                documentocertificado = readerobj.ReadToEnd().Trim();

            }
            catch (WebException ex) when (ex.Response is HttpWebResponse response)
            {

            }

            return documentocertificado;


        }
        public static string EnviarXMLNCredito(RESPONSE cliente,string token,DocumentoCertificadoSAT certificadoOrigen, IList<ListarDetalleFacturas> detalleFacturas, string motivoajustes)
        {
            var documentoNcredito = "";

            System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(TraerURL());
            request.Method = "post";
            request.Headers.Add("Authorization", token);
            request.ContentType = "application/json";

            var bodyxml = GeneraNotasCDXML.XMLNotaCreditoFormat( cliente, detalleFacturas, certificadoOrigen , motivoajustes);



            using (var streamWrite = new StreamWriter(request.GetRequestStream()))
            {
                streamWrite.Write(bodyxml);
                streamWrite.Flush();
                streamWrite.Close();
            }
            try
            {
                System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;
                WebResponse response = request.GetResponse();//falla por aca
                Stream strReader = response.GetResponseStream();
                 
                var readerobj = new StreamReader(strReader);
                documentoNcredito = readerobj.ReadToEnd().Trim();


            }
            catch (WebException ex) when (ex.Response is HttpWebResponse response)
            {
                return response.StatusCode.ToString();
            }


            return documentoNcredito;

        }

    }
}
