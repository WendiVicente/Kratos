using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Personal
{
   public class Departamento
    {
        public Departamento()
        {
            Puestos = new List<Puesto>();
        }
        public int Id { get; set; }
        public string Area { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Puesto> Puestos { get; set; }
    }
}
