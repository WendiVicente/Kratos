using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.Prestamos
{
    public class ListarCuotas
    {
        public bool Seleccion { get; set; }
        public string Estado { get; set; }

        public int Id { get; set; }
        public int NoCuota { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal Amortizacion { get; set; }
        public decimal Interes { get; set; }
        public decimal MontoCuotas { get; set; }
        public string ITF { get; set; }
        public DateTime Vence { get; set; }
        public decimal Mora { get; set; }
        public decimal InteresesProyectados { get; set; }
       
        public Guid PrestamosID { get; set; }
    }
}
