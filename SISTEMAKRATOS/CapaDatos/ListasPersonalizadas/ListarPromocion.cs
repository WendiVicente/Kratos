using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas
{
    public class ListarPromocion
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string  Sucursal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Estado { get; set; }
    }
}
