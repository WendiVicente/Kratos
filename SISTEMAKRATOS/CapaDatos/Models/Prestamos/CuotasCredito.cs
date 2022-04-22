using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Prestamos
{
    public class CuotasCredito
    {

        public CuotasCredito()
        {
            RegistroPagoCuotas = new List<RegistroPagoCuota>();
        }


        [Key]
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
        public string Estado { get; set; }
        public decimal Parcial { get; set; }






        [ForeignKey("Prestamos")]
        public Guid PrestamosID { get; set; }
        public Prestamos Prestamos { get; set; }

        public ICollection<RegistroPagoCuota> RegistroPagoCuotas { get; set; }
    }
}
