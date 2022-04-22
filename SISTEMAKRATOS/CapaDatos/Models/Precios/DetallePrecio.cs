using CapaDatos.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Precios
{
    public class DetallePrecio
    {
        public Guid Id { get; set; }
        public Guid TipoPrecioId { get; set; }
        public int TiposId { get; set; }
        public string Escala { get; set; }
        public int RangoInicio { get; set; }
        public int RangoFinal { get; set; }
        public decimal Precio { get; set; }

        public Tipos Tipos { get; set; }

    }
}
