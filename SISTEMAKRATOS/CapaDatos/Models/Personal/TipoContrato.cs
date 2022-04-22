using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Personal
{
   public  class TipoContrato
    {
        public TipoContrato()
        {
            Personals = new List<Personal>();
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool  IsActive { get; set; }

        public ICollection<Personal> Personals { get; set; }

    }
}
