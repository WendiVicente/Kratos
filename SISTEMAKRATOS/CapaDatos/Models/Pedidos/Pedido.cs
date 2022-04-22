using CapaDatos.Models.Sucursales;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Pedidos
{
   public  class Pedido
    {
        public Pedido()
        {
            DetallePedidos = new List<DetallePedidos>();

        }

        public Guid Id { get; set; }
      
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Nit { get; set; }
        public string NombreVendedor { get; set; }
        public bool Estado { get; set; } // 0 en peticion y 1 comprado

        public int? SucursalId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaLimite { get; set; }
        public bool IsActive { get; set; } // anulado o no
        public Sucursal Sucursal { get; set; }
        public Cliente Cliente { get; set; }
        public string NoPedido { get; set; }
        
        public ICollection<DetallePedidos> DetallePedidos { get; set; }


    }
}
