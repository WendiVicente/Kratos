using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarPedidos
    {
        public DateTime FechaRecepcion { get; set; } // igual que fecha creacion
        public DateTime FechaLimite { get; set; }

        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public string NombreVendedor { get; set; }
        public string NoPedido { get; set; }
        public string NoPedidoDoc { get; set; }
        public string Sucursal { get; set; }
        public decimal? Total { get; set; }
        public string Estado { get; set; } // 0 en peticion y 1 compradotxt
        
    }
}
