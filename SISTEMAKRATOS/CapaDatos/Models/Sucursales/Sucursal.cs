
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.Personal;
using CapaDatos.Models.Productos.Combos;
using CapaDatos.Models.Productos.Promocion;
using CapaDatos.Models.Transacciones;
using CapaDatos.Models.Usuarios;
using CapaDatos.Models.Vales;
using sharedDatabase.Models;
using sharedDatabase.Models.Caja;
//using sharedDatabase.Models.Caja;
using sharedDatabase.Models.Compras;
using sharedDatabase.Models.Proveedores;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos.Models.Sucursales
{
    public class Sucursal
    {


        public Sucursal()
        {
            Users = new List<User>();
            Productos = new List<Producto>();
            Compras = new List<Compra>();
            //Cajas = new List<Caja>();
            Combos = new List<Combo>();
            Clientes = new List<Cliente>();
            Personals = new List<Personal.Personal>();
            Proveedores = new List<Proveedor>();
            Transacciones = new List<Transaccion>();
            Vales = new List<Vale>();
            Cotizaciones = new List<Cotizacion.Cotizacion>();
            Promociones = new List<Promocion>();
            CuentaCBs = new List<CuentaCB>();
        }


        public int Id { get; set; }

        public string NombreSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NombreEncargado { get; set; }


        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Caja> Cajas { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public ICollection<Compra> Compras { get; set; }
        public ICollection<Combo> Combos { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Proveedor> Proveedores { get; set; }
        public ICollection<Personal.Personal> Personals { get; set; }
        public ICollection<Transaccion> Transacciones { get; set; }
        public ICollection<Vale> Vales { get; set; }

        public ICollection<Cotizacion.Cotizacion> Cotizaciones { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Promocion>Promociones { get; set; }
        public ICollection<CuentaCB> CuentaCBs { get; set; }
    }
}
