using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.ProductosToFacturar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Clientes
{
    public class ClienteCredito
    {
        public int Id { get; set; }
        public Guid CuentaCBId { get; set; }
        public Guid DocumentoId { get; set; }   
    }
}
