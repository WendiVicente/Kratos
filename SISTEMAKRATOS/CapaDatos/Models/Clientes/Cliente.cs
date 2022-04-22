using CapaDatos.Models.Clientes;
using CapaDatos.Models.Cotizacion;
using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Pedidos;
using CapaDatos.Models.Sucursales;
using CapaDatos.Models.Vales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharedDatabase.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Facturas = new List<Factura>();
            AsignacionVales = new List<AsignacionVale>();
            Cotizaciones = new List<Cotizacion>();
            CuentaCBs = new List<CuentaCB>();
           // NotaCreditos = new List<NotaCredito>();
        }

        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }
        public string CodigoCliente { get; set; }
        public string Apellidos { get; set; }
        public string Telefonos { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
        public string Alias { get; set; }
        public int TiposId { get; set; }

        [ForeignKey("CategoriaCliente")]
        public int? CategoriaId { get; set; }
        public int? SucursalId { get; set; }
        public bool IsActive { get; set; }

        public DateTime FechaCreacion { get; set; }
        public bool PermitirCredito { get; set; }
        public Tipos Tipos { get; set; }
        public Sucursal Sucursal { get; set; }
        public CategoriaCliente CategoriaCliente { get; set; }
        public ICollection<Factura> Facturas { get; set; }
        public ICollection<AsignacionVale> AsignacionVales { get; set; }
        public ICollection<Cotizacion>Cotizaciones { get; set; }
        public ICollection<Pedido>Pedidos { get; set; }
        public ICollection<CuentaCB> CuentaCBs { get; set; }
        public string DPI { get; set; }
       // public ICollection<NotaCredito> NotaCreditos { get; set; }
    }
}
