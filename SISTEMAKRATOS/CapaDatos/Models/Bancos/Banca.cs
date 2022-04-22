using sharedDatabase.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Models.Bancos
{
  public   class Banca
    {
        public Banca()
        {
            Proveedores = new List<Proveedor>();
            CuentaBancos = new List<CuentaBanco>();
        }
        public int Id { get; set; }
        public string Entidad { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<Proveedor>Proveedores { get; set; }
        public ICollection<CuentaBanco> CuentaBancos { get; set; }
    }
}
