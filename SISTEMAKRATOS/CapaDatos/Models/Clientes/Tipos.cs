using CapaDatos.Models.Precios;
using CapaDatos.Models.Vales;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Clientes
{
    public class Tipos
    {

        public Tipos()
        {
            Clientes = new List<Cliente>();
            DetallePrecios = new List<DetallePrecio>();
            Vales = new List<Vale>();
        }
        public int Id { get; set; }

        public string TipoCliente { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Cliente>Clientes { get; set; }
        public ICollection<DetallePrecio> DetallePrecios { get; set; }
        public ICollection<Vale> Vales { get; set; }

    }
}
