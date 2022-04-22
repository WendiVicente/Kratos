using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
   public  class MotivoPase
    {
        public MotivoPase()
        {
            PaseEmpleados = new List<PaseEmpleado>();
        }
        public int Id { get; set; }
        public string Motivo { get; set; }
        ICollection<PaseEmpleado> PaseEmpleados { get; set; }
    }
}
