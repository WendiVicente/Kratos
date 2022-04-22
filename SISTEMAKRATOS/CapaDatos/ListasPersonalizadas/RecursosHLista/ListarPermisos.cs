using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.RecursosHLista
{
    public class ListarPermisos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DPI { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraSalida { get; set; }
        public string HoraEntrada { get; set; }
        public string Descripcion { get; set; }
        public int MotivoPaseId { get; set; }
    }
}
