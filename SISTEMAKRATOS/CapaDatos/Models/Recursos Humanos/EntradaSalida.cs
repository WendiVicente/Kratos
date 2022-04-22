using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
   public  class EntradaSalida
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public int TipoESId { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public TipoES TipoES { get; set; }

    }
}
