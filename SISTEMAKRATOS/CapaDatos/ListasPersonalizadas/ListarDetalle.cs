using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarDetalle
    {
        public int ProductoId { get; set; }
        public int DetalleId { get; set; }
        public string Detalle { get; set; }
        public int Cantidad { get; set; }        
        public bool Acciones { get; set; }
    }
}
