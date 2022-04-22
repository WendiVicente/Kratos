using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
   public class EmpleadoAusencia
    {
        public int Id { get; set; }
        public int AusenciaId { get; set; }
        public int PersonalId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Motivo { get; set; }
        
        public Ausencia Aunsencia { get; set; }
        public Personal.Personal Personal { get; set; }
    }
}
