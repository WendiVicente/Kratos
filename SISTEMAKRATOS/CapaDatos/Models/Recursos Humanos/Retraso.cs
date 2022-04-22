using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
    public class Retraso
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public int TipoRetrasoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Minutos { get; set; }
        public string Observacion { get; set; }
        public Personal.Personal Personal { get; set; }
        public TipoRetraso TipoRetraso { get; set; }

    }
}
