using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
    public class Ausencia
    {
       public Ausencia()
        {
            EmpleadoAusencias = new List<EmpleadoAusencia>();
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<EmpleadoAusencia> EmpleadoAusencias { get; set; }
    }
}
