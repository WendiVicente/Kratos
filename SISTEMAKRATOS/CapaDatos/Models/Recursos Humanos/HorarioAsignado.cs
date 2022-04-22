using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
    public class HorarioAsignado
    {
        public int Id { get; set; }
        public Guid HorarioEId { get; set; }
        public int PersonalId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public string CausaHorario { get; set; }

        //relaciones
        public Personal.Personal Personal { get; set; }
        public HorarioE HorarioE { get; set; }
        
    }
}
