using CapaDatos.Models.Clientes;
using CapaDatos.Models.Sucursales;
using CapaDatos.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Vales
{
    public class Vale
    {
        public Vale()
        {
            AsignacionVales = new List<AsignacionVale>();
            //DetalleRebajas = new List<DetalleRebajas>();
        }
        public Guid Id { get; set; }
        public String Descripcion { get; set; }
        public DateTime FechaRecepcion { get; set; }

        public decimal Monto { get; set; }
        public int? SucursalId { get; set; }
        public string UserId { get; set; }
        public int TiposId { get; set; }

        public Sucursal Sucursal { get; set; }
        public User User { get; set; }
        public Tipos Tipos { get; set; }
        public ICollection<AsignacionVale> AsignacionVales { get; set; }
        public bool IsActive { get; set; }
        public string NoVale { get; set; }
       
        //  public ICollection<DetalleRebajas> DetalleRebajas { get; set; }

    }
}
