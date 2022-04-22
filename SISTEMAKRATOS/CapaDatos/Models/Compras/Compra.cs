using CapaDatos.Models.Recepciones;
using CapaDatos.Models.Sucursales;
using sharedDatabase.Models.Caja;
using sharedDatabase.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sharedDatabase.Models.Compras
{
    public class Compra
    {
        public Compra()
        {
            DetalleCompras = new List<DetalleCompra>();
            DetalleCajas = new List<DetalleCaja>();
            recepciones = new List<Recepcion>();
        }

        public Guid Id { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaLimite { get; set; }
        public string NoComprobante { get; set; }
        public string NombreVendedor { get; set; }

        public DateTime FechaRecepcion { get; set; } // igual que fecha creacion
        public bool Estado { get; set; } // 0 en peticion y 1 comprado
        public bool IsActive { get; set; } // anulado o no
        public int? SucursalId { get; set; }

        public Sucursal Sucursal { get; set; }
        public Proveedor Proveedor { get; set; }
        public ICollection<DetalleCompra> DetalleCompras { get; set; }
        public ICollection<DetalleCaja> DetalleCajas { get; set; }
        public ICollection<Recepcion> recepciones { get; set; }

    }
}
