using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarDetalleColorTallas
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }

        public int Stock { get; set; }
        public string Color { get; set; }
        public string Talla { get; set; }
        public bool Acciones { get; set; }
    }
}
