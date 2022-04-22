using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.WebServiceSAT
{
    public class Internet
    {
        public bool conectado { get; }
        public TokenSAT TokenObtenidoSat { get; }
        public Internet()
        { }

        public Internet(int EntornoDev)
        {
            conectado = Conectado();
            if (conectado)
            {
                TokenObtenidoSat = JsonConvert.DeserializeObject<TokenSAT>(TokenPOST.GetToken(EntornoDev));
            }
            else
            {
                TokenObtenidoSat = null;
            }
        }

        public bool Conectado()
        {
            bool Estado = false;
            System.Uri Url = new System.Uri("https://www.google.com/");

            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objetoResp;

            try
            {
                objetoResp = WebRequest.GetResponse();
                Estado = true;
                objetoResp.Close();
            }
            catch
            {
                Estado = false;
            }
            WebRequest = null;
            return Estado;
        }
    }
}
