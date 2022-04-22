using CapaDatos.Models.Usuarios;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Prestamos
{
    public class Prestamos
    {

        public Prestamos()
        {
            CuotasCreditos = new List<CuotasCredito>();
            RegistroPagoCuotas = new List<RegistroPagoCuota>();
        }


        [Key]
        public Guid Id { get; set; }
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

        [ForeignKey("MetodoAmortizacion")]
        public int AmortizacionId { get; set; }

        

        [ForeignKey("User")]
        public string UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public User User { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public MetodoAmortizacion MetodoAmortizacion { get; set; }
        public ICollection<CuotasCredito> CuotasCreditos { get; set; }
        public ICollection<RegistroPagoCuota> RegistroPagoCuotas { get; set; }
       
    }
}
