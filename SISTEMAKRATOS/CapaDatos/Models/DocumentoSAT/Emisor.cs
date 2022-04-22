using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.DocumentoSAT
{
    public class Emisor
    {
        public int Id { get; set; }
        //Los comentarios son un ejemplo de un emisor de Pruebas

        public string direccionEmisor { get; set; }   // = "5A AVENIDA 16-62 302 EDIFICIO PLATINA Z. 10";
        public string codpostalEmisor { get; set; } // = "0100";
        public string muniEmisor { get; set; } //= "GUATEMALA";
        public string DeptoEmisor { get; set; } // = "GUATEMALA";
        public string paisEmisor { get; set; } //= "GT";
        public string nitemisor { get; set; } //= "44653948";
        public string nombreemisor { get; set; } //= "TEST";
        public string codestable { get; set; }//= "1";
        public string namecomercial { get; set; }//= "TEST";
        public string tipoafiliacion { get; set; } //= "GEN";
        public string urlFel { get; set; } //https://felgttestaws.digifact.com.gt/gt.com.fel.api.v3/api/FelRequestV2?
        public string urlToken { get; set; } //https://felgttestaws.digifact.com.gt/gt.com.fel.api.v3/api/login/get_token
        public string usernameFel { get; set; } //GT.000044653948.REDOWLTEST
        public string passwordFel { get; set; } //Encrypt MD5
        public int entorno { get; set; } //0 = pruebas, 1 = produccion

    }
}
