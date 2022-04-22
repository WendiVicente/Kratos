using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
    public class TipoRetraso
    {
        public TipoRetraso()
        {
            Retrasos = new List<Retraso>();
        }
        public int Id { get; set; }
        public string Retraso { get; set; }

        public ICollection<Retraso> Retrasos  { get; set; }
    }
}
