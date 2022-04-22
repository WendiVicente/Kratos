using CapaDatos.Models.Clientes;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Precios
{
    public class TipoPrecio
    {
        public  TipoPrecio()
        {
            DetallePrecios = new List<DetallePrecio>();
        }
        public Guid Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public int ProductoId { get; set; }
      //  public int? TipoId { get; set; }

        public Producto  Producto { get; set; }
       // public Tipos Tipos { get; set; }

        public ICollection<DetallePrecio>DetallePrecios { get; set; }
    }
}
