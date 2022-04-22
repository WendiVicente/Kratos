using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Sucursales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class SucursalesRepository
    {

        private Context _context = null;

        public SucursalesRepository(Context context)
        {
            _context = context;
        }


        public void Add(Sucursal sucursal, bool saveChanges = true)
        {
            _context.Sucursales.Add(sucursal);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        
        public IList<ListarSucursales> GetList()
        {
            return _context.Sucursales
              .Where(a => a.IsActive == false)
              .OrderBy(a => a.NombreSucursal).ThenBy(a => a.Direccion)
              .Select(x => new ListarSucursales
              {
                  Id = x.Id,
                  NombreSucursal = x.NombreSucursal,
                  NombreEncargado = x.NombreEncargado,
                  Telefono = x.Telefono,
                  Direccion = x.Direccion,
                  
              })
              .ToList();

        }
        /*
        public IList<Sucursal> Getsucursales()
        {
            return _context.Sucursales
                .Where(a => a.IsActive == false)
                .OrderBy(a => a.NombreSucursal).ThenBy(a => a.NombreEncargado)
                .ToList();
        }*/

        public Sucursal Get(int id, bool includeRelatedEntities = true)
        {
            var sucursal = _context.Sucursales.AsQueryable();

            if (includeRelatedEntities)
            {
                // pendiente, aqui incluir las relacioens cuando hagamos reportes
            }

            return sucursal.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Update(Sucursal sucursal, bool saveChanges = true)
        {
            _context.Entry(sucursal).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }



    }
}
