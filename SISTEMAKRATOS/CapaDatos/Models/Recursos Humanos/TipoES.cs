using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
    public class TipoES
    {
        public TipoES()
        {
            EntradaSalidas = new List<EntradaSalida>();
        }
        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<EntradaSalida> EntradaSalidas { get; set; }
    }
}
