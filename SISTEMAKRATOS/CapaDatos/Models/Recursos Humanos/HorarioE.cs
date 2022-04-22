using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Recursos_Humanos
{
    public class HorarioE
    {
        public HorarioE()
        {
            HorarioAsignados = new List<HorarioAsignado>();
        }
        
     
        [Key,Required]
        public Guid IdHorario { get; set; }
        public string Descripcion { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }


        public ICollection<HorarioAsignado> HorarioAsignados { get; set; }

    }
}
