using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarDetalleRebajas
    {
        public Guid Id { get; set; }
        public Guid ValesId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
    }
}
