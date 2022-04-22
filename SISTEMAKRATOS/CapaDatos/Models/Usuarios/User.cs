using CapaDatos.Models.CuentaCobrar;
using CapaDatos.Models.Sucursales;
using CapaDatos.Models.Transacciones;
using CapaDatos.Models.Vales;
using Microsoft.AspNet.Identity.EntityFramework;
using sharedDatabase.Models;
using sharedDatabase.Models.Caja;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Usuarios
{
    public class User : IdentityUser
    {
        public User()
        {
            Facturas = new List<Factura>();
            Transacciones = new List<Transaccion>();
            Vales = new List<Vale>();
            NotaPagos = new List<NotaPago>();
           // NotaCreditos = new List<NotaCredito>();

        }

        public static object Identity { get; internal set; }

        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public int SucursalId { get; set; }
        public string Privilegios { get; set; }


        public virtual Sucursal Sucursal { get; set; }

        public ICollection<Factura> Facturas { get; set; }
        public ICollection<Transaccion> Transacciones { get; set; }
        public ICollection<Vale>Vales { get; set; }
       public ICollection<NotaPago> NotaPagos { get; set; }
        //public ICollection<NotaCredito> NotaCreditos { get; set; }

    }
}
