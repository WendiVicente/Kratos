using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using sharedDatabase.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class ProveedoresRepository
    {
        private Context _context = null;

        public ProveedoresRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Agregar un cliente.
        /// </summary>
        /// <param name="cliente">El cliente.</param>
        /// <param name="saveChanges">guardar o no guardar.</param>
        public void Add(Proveedor proveedor, bool saveChanges = true)
        {
            _context.Proveedores.Add(proveedor);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }


        public IList<Proveedor> GetList()
        {
            return _context.Proveedores
                .Where(a => a.IsActive == false)
                .OrderBy(a => a.Nombre)
                .ToList();
        }

        public IList<Proveedor> GetProveedores()
        {
            return _context.Proveedores
                .Where(a => a.IsActive == false)
                .OrderBy(a => a.Nombre)
                .ToList();
        }

        public Proveedor Get(int id, bool includeRelatedEntities = true)
        {
            var cliente = _context.Proveedores.AsQueryable();

            if (includeRelatedEntities)
            {
                // pendiente, aqui incluir las relacioens cuando hagamos reportes
            }

            return cliente.Where(a => a.Id == id).SingleOrDefault();
        }

        public void Update(Proveedor proveedor, bool saveChanges = true)
        {
            _context.Entry(proveedor).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<ListarProveedores> GetlistaProvs(int idsucursal,bool todasfechas, DateTime fechainicio,
            DateTime fechafin, bool activo,bool inactivo, bool allstate)
        {
            var proveedores = _context.Proveedores.AsQueryable();

            if (idsucursal != 0)
            {
                proveedores = proveedores.Where(a => a.SucursalId == idsucursal);

            }
            if (todasfechas == false)
            {
                proveedores = proveedores.Where(a => a.Ingreso > fechainicio && a.Ingreso <= fechafin);
            }

            if (allstate == false)
            {
                if (activo == true)
                {
                    proveedores = proveedores.Where(a => a.IsActive == false);
                }
                if (inactivo == true)
                {
                    proveedores = proveedores.Where(a => a.IsActive == true);
                }

            }


            return proveedores
                //.Include(x=> x.)
                .Select(x => new ListarProveedores
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,
                    Telefonos = x.Telefonos,
                    Estado = x.IsActive == true ? "Inactivo" : "Activo",
                    Desactivar= x.IsActive,
                    SucursalId= x.Sucursal.NombreSucursal,
                    Ingreso=x.Ingreso,
                    Celular= x.Celular,
                    Celular2= x.Celular,
                    Correo= x.Correo,
                    NoCuentaBancaria= x.NoCuentaBancaria,
                    Banco= x.Banco.Entidad,
                    Nit= x.Nit,
                    Frecuencia= x.Frecuencia.Periodo,
                    Observaciones= x.Observaciones,
                    Rubro= x.Rubro.Descripcion,
                    Telefonos2= x.Telefonos2,
                    TipoProveedor=x.TipoProveedor.Descripcion
                    

                }).ToList();

        }

        public IList<ListarProveedores> GetListGenerales(int sucursalId)
        {

            var proveedores = _context.Proveedores.AsQueryable();
            if (sucursalId != 0)
            {
                proveedores = proveedores.Where(a => a.SucursalId == sucursalId);
            }

            return proveedores
                //.Include(x=> x.)
                .Select(x => new ListarProveedores
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,
                    Telefonos = x.Telefonos,
                    Estado = x.IsActive == true ? "Inactivo" : "Activo",
                    Desactivar = x.IsActive,
                    SucursalId = x.Sucursal.NombreSucursal,
                    Ingreso = x.Ingreso,
                    Celular = x.Celular,
                    Celular2 = x.Celular,
                    Correo = x.Correo,
                    NoCuentaBancaria = x.NoCuentaBancaria,
                    Banco = x.Banco.Entidad,
                    Nit = x.Nit,
                    Frecuencia = x.Frecuencia.Periodo,
                    Observaciones = x.Observaciones,
                    Rubro = x.Rubro.Descripcion,
                    Telefonos2 = x.Telefonos2,
                    TipoProveedor = x.TipoProveedor.Descripcion


                }).ToList();

        }
        public IList<ListarProveedores> GetList(int idSucursal)
        {

            return _context.Proveedores
              .Include(r => r.TipoProveedor)
              .Where(a => a.IsActive == false && a.SucursalId == idSucursal)
              .OrderBy(a => a.Id).ThenByDescending(a => a.Id)
              .Select(x => new ListarProveedores
              {
                  Id = x.Id,
                  Nombre = x.Nombre,
                  Direccion = x.Direccion,
                  NoCuentaBancaria = x.NoCuentaBancaria,
                  Telefonos = x.Telefonos,
                  Telefonos2 = x.Telefonos2,
                  Celular = x.Celular,
                  Nit=x.Nit,
                  Rubro=Convert.ToString(x.RubroId),
                  Frecuencia=Convert.ToString(x.Frecuencia),
                  Banco=Convert.ToString(x.Banco),


              })
.ToList();

        }

    }

    }

