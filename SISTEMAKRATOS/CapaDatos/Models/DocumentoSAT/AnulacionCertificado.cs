using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.DocumentoSAT
{
    public class AnulacionCertificado
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public string AcuseReciboSAT { get; set; }
        public string CodigosSAT { get; set; }
        public string ResponseDATA1 { get; set; }
        public string ResponseDATA2 { get; set; }
        public string ResponseDATA3 { get; set; }
        public string Autorizacion { get; set; }
        public string Serie { get; set; }
        public string NUMERO { get; set; }
        public DateTime Fecha_DTE { get; set; }
        public string NIT_EFACE { get; set; }
        public string NOMBRE_EFACE { get; set; }
        public string NIT_COMPRADOR { get; set; }
        public string NOMBRE_COMPRADOR { get; set; }
        public string BACKPROCESOR { get; set; }
    }
}
