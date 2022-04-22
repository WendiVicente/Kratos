using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Prestamos
{
    public class RegistroPagoCuota
    {
        public Guid Id { get; set; }
        public string Nopago { get; set; }
        public DateTime FechaPago { get; set; }

       
        public decimal Importe { get; set; }
        public decimal Mora { get; set; }
        public Guid? PrestamosId { get; set; }
        public int CuotasCreditoId { get; set; }

        public Prestamos Prestamos { get; set; }
        public CuotasCredito CuotasCredito { get; set; }
    }
}
