using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Prestamos
{
    public class SolicitudCreditos
    {

        public Guid Id { get; set; }
        public string NoDocumento { get; set; }
        public decimal Monto { get; set; }
        public int TasaInteres { get; set; }
        public decimal ImporteFinanciado { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string UsuarioId { get; set; }
        public int ClienteId { get; set; }



    }
}
