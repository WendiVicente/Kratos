using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.RecursosHLista
{
    public class ListarAusencias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DPI { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public string Ausencia { get; set; }
       
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Motivo { get; set; }
    }
}
