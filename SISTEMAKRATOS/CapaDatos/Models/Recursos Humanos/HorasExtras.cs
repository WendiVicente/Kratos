using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
   public  class HorasExtras
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public string Descripcion { get; set; }
        public string HoraInicio { get; set; }
        public string HorarioFinal { get; set; }
        public DateTime Fecha { get; set; }
        public bool DiaCompleto { get; set; }

        public Personal.Personal Personal { get; set; }
    }
}
