using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Personal
{
    public class Puesto
    {
        public Puesto()
        {
            Personals = new List<Personal>();
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool IsActive { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Personal> Personals { get; set; }
    }
}
