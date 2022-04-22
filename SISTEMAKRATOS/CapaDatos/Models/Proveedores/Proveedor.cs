using CapaDatos.Models.Bancos;
using CapaDatos.Models.Proveedores;
using CapaDatos.Models.Sucursales;
using sharedDatabase.Models.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models.Proveedores
{
   public class Proveedor
    {
        public Proveedor()
        {
            Compras = new List<Compra>();
            Productos = new List<Producto>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }
        
        public string Direccion { get; set; }
        public string Correo { get; set; }
        
        public string Telefonos { get; set; }
        public string Telefonos2 { get; set; }
        public string Celular  { get; set; }
        public string Celular2 { get; set; }
        public string Nit { get; set; }
        public string NoCuentaBancaria { get; set; }
       
        public DateTime Ingreso { get; set; }
       
        public string Observaciones { get; set; }
        public bool IsActive { get; set; }
        public int? SucursalId { get; set; }
        public int BancoId { get; set; }
        public int RubroId { get; set; }
        public int FrecuenciaId { get; set; }
        public int TipoProveedorId { get; set; }
       
        public Sucursal Sucursal { get; set; }
        public Banca Banco { get; set; }
        public Frecuencia Frecuencia { get; set; }
        public Rubro Rubro { get; set; }
        public TipoProveedor TipoProveedor { get; set; }
        public ICollection<Compra> Compras { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public string RazonSocial { get; set; }
        public decimal Saldo { get; set; }
        public int Moneda { get; set; }

    }
}
