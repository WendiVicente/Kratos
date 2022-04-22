using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
    public class PaseEmpleado
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraSalida { get; set; }
        public string HoraEntrada { get; set; }
        public string Descripcion { get; set; }
        public int MotivoPaseId { get; set; }
        
        public MotivoPase MotivoPase { get; set; }
        public Personal.Personal Personal { get; set; }

    }
}
