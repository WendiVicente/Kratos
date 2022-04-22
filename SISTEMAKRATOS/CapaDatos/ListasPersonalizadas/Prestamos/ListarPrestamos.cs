using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ListasPersonalizadas.Prestamos
{
    public class ListarPrestamos
    {     public Guid Id { get; set; }
        public string NoDocumento { get; set; }
        public decimal Monto { get; set; }
        public int TasaInteres { get; set; }
        public decimal ImporteFinanciado { get; set; }
        public int NoCuotas { get; set; }
        public decimal MontoCuotas { get; set; }
        public decimal DeudaActual { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaSolicitud { get; set; }

        public int TipoCreditoId { get; set; }
        public string Tipocredito { get; set; }

       
        public int AmortizacionId { get; set; }
        public string Amortizacion { get; set; }
        

        public string Empleado { get; set; }
        public int ClienteId { get; set; }
        public string Nombrescliente { get; set; }
    }
}
