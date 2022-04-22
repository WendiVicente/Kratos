using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Personal
{
   public class Horario
    {
        public Horario()
        {
            Personals = new List<Personal>();
        }
        public int Id { get; set; }
        public string Periodo { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<Personal> Personals { get; set; }
    }
}
