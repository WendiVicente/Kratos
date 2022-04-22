using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recepciones
{
    public class EstadoRecepcion
    {
        public EstadoRecepcion()
        {
            recepciones = new List<Recepcion>();
        }
        public int Id { get; set; }
        public string Estado { get; set; }


        public ICollection<Recepcion> recepciones { get; set; }
    }
}
