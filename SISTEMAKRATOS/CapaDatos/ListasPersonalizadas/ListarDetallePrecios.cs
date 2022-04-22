using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarDetallePrecios
    {
        public Guid Id { get; set; }
        public Guid TipoPrecioId { get; set; }
        public string Tipos { get; set; }
        public string Escala { get; set; }
       
        public int RangoInicio { get; set; }
        public int RangoFinal { get; set; }
        public decimal Precio { get; set; }
        public int TiposId { get; set; }
    }
}
