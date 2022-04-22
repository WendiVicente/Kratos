using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
   public class ListarRecepciones
    {
        public string Solicitud { get; set; }
        public DateTime FechaPrevista { get; set; }
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string proveedor { get; set; }
        public Guid SolicitudCompra { get; set; }
        public string EstadoRecepcion { get; set; }
       
    }
}
