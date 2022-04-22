using CapaDatos.Models.Bancos;
using CapaDatos.Models.Sucursales;
using CapaDatos.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Transacciones
{
    public class Transaccion
    {
        public Guid Id { get; set; }
        public DateTime FechaSolicitud { get; set; }
      
        public decimal Monto { get; set; } 
        public int EstadosTransacId { get; set; }
        public string Observaciones { get; set; }
      
        public bool IsActive { get; set; }
        public int TipoMovimientoId { get; set; }

     
        public Guid? CuentaOrigenId { get; set; }
        public int? CajaId { get; set; }
        public Guid? CuentaBancoId { get; set; }
        public int? SucursalId { get; set; }
        public string  UsuarioId { get; set; }
        public string Responsable { get; set; }


        public Sucursal Sucursal { get; set; }
        public CuentaBanco CuentaBanco { get; set; }
       
        public TipoMovimiento TipoMovimiento { get; set; }
        public EstadosTransac EstadosTransac { get; set; }
        public User Usuario { get; set; }

    }
}
