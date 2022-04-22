using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.VentasAcumuladas
{
    public class ListarAcumuladasEncabezado
    {
        public Guid Id { get; set; }
        public string NoSolicitud { get; set; }
        public string NitCliente { get; set; }
        public string NombreCliente { get; set; }
        public string UserId { get; set; }
        public string Vendedor { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Estado { get; set; }
        public int ClienteId { get; set; }

        public bool _State { get; set; }
        public bool Temporales { get; set; }
    }
}
