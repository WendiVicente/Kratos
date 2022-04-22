using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Clientes;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos.Repository
{
    public class ClientesRepository
    {
        private Context _context = null;

        public ClientesRepository(Context context)
        {
            _context = context;
        }


        public int Add(Cliente cliente, bool saveChanges = true)
        {
            _context.Clientes.Add(cliente);

            if (saveChanges)
            {
                _context.SaveChanges();
               
            }
            return cliente.Id;
        }
       

        // podes usar esto ok de acuerdo
        public IList<ListarClientes> GetList(int tipocliente=0)
        {
            var clienteslista = _context.Clientes.AsQueryable();

            if (tipocliente != 0)
            {
                clienteslista = clienteslista.Where(a => a.TiposId == tipocliente);
                   
            }

            return clienteslista
                 .Include(r => r.Tipos)
                 .OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                  .Where(a=> a.IsActive == false)
                 .Select(x => new ListarClientes
                 {
                     Codigo = x.Id,
                     CodigoCliente = x.CodigoCliente,
                     Nombres = x.Nombres,
                     Apellidos = x.Apellidos,
                     Telefonos = x.Telefonos,
                     Nit = x.Nit,
                     Direccion = x.Direccion,
                     Alias = x.Alias,
                     Tipo_Cliente = x.Tipos.TipoCliente,
                     FechaCreacion = x.FechaCreacion,
                     Desactivado = x.IsActive,
                     Credito = x.PermitirCredito == true ? "Sí":"No",
                  Sucursal = x.Sucursal.NombreSucursal



                 })
              .ToList();

        }

        public IList<ListarClientes> GetListTodos()
        {
            return  _context.Clientes
                 .Include(r => r.Tipos)
                 .OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                  .Where(a => a.IsActive == false)
                 .Select(x => new ListarClientes
                 {
                     Codigo = x.Id,
                     CodigoCliente = x.CodigoCliente,
                     Nombres = x.Nombres,
                     Apellidos = x.Apellidos,
                     Telefonos = x.Telefonos,
                     Nit = x.Nit,
                     Direccion = x.Direccion,
                     Alias = x.Alias,
                     Tipo_Cliente = x.Tipos.TipoCliente,
                     FechaCreacion = x.FechaCreacion,
                     Desactivado = x.IsActive,
                     Credito = x.PermitirCredito == true ? "Sí" : "No",
                     Sucursal = x.Sucursal.NombreSucursal

                 })
              .ToList();

        }

        // obtener por fechas
        public IList<ListarClientes> GetListCleintesFecha(DateTime fechainicio, DateTime fechafin)
        {
            return _context.Clientes
                 .Include(r => r.Tipos)
               .OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
               .Where(a=> a.IsActive==false)
              .Select(x => new ListarClientes
              {
                  Codigo = x.Id,
                  Nombres = x.Nombres,
                  CodigoCliente= x.CodigoCliente,
                  Apellidos = x.Apellidos,
                  Telefonos = x.Telefonos,
                  Sucursal = x.Sucursal.NombreSucursal,
                  Nit = x.Nit,
                  Direccion = x.Direccion,
                  Alias = x.Alias,
                  Tipo_Cliente = x.Tipos.TipoCliente,
                  Credito = x.PermitirCredito == true ? "Sí" : "No",
                  FechaCreacion = x.FechaCreacion

              })
              .Where(a=> a.FechaCreacion >fechainicio && a.FechaCreacion < fechafin)
              .ToList();

        }
       


        public IList<Cliente> GetClientes()
        {
            return _context.Clientes
                .Where(a => a.IsActive == false)
                .OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                .ToList();
        }
       
        //obtener tipos de cliente lista
        public IList<Tipos> GetTipos()
        {
            return _context.Tipos
                .Where(a => a.IsActive == false)
                .OrderBy(a => a.TipoCliente)
                .ToList();
        }
       

        public Cliente Get(int id, bool includeRelatedEntities = true) // true es por defecto
        {
            var cliente = _context.Clientes.AsQueryable();

            if (includeRelatedEntities)
            {
                // pendiente, aqui incluir las relacioens cuando hagamos reportes
            }

            return cliente.Where(a => a.Id == id).SingleOrDefault();
        }
      


        public void Update(Cliente cliente, bool saveChanges = true)
        {
            _context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
      
        public IList<ListarClientes> GetlistaReporte(int idsucursal,int tipocliente, bool todasfechas,
            DateTime fechainicio, DateTime fechafin, bool desc, bool asc,bool activo, bool inactivo,
            bool todosclientes,int categoria)//,List<Tipos> tiposLista)
        {
            var clienteslista = _context.Clientes.AsQueryable();
            
            if (categoria != 0)
            {
                clienteslista = clienteslista.Where(a => a.CategoriaId == categoria);

            }
            if (idsucursal != 0)
            {
                clienteslista = clienteslista.Where(a => a.SucursalId == idsucursal);

            }
            if (tipocliente != 0)
            {
                clienteslista = clienteslista.Where(a => a.TiposId == tipocliente);

            }
            if (todasfechas == false)
            {
                clienteslista = clienteslista.Where(a => a.FechaCreacion > fechainicio && a.FechaCreacion <= fechafin);
            }

            if (desc == true)
            {
                clienteslista = clienteslista.OrderByDescending(a => a.Nombres).ThenBy(a => a.Apellidos);
            }
            if (asc == true)
            {
                clienteslista = clienteslista.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos);
            }

            if(todosclientes==false)
            {
                if (activo == true)
                {
                    clienteslista = clienteslista.Where(a => a.IsActive == false);
                }
                if (inactivo == true)
                {
                    clienteslista = clienteslista.Where(a => a.IsActive == true);
                }

            }

            return clienteslista
                 .Include(r => r.Tipos)

                 .Select(x => new ListarClientes
                 {
                     Codigo = x.Id,
                     CodigoCliente= x.CodigoCliente,
                     Nombres = x.Nombres,
                     Apellidos = x.Apellidos,
                     Telefonos = x.Telefonos,
                     Nit = x.Nit,
                     Direccion = x.Direccion,
                     Alias = x.Alias,
                     Tipo_Cliente = x.Tipos.TipoCliente,
                     FechaCreacion = x.FechaCreacion,
                     Sucursal = x.Sucursal.NombreSucursal,
                     EstadoActual= x.IsActive==true? "Inactivo" : "Activo",
                      Credito = x.PermitirCredito == true ? "Sí" : "No"

                 })
              .ToList();

        }

        public IList<ListarClientes> ObtenerClientesSelected()
        {
            var clienteslista = _context.Clientes.AsQueryable();
            return clienteslista
                 .Include(r => r.Tipos)

                 //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                 // .Where(a=> a.IsActive==false)
                 .Select(x => new ListarClientes
                 {
                     Codigo = x.Id,
                     CodigoCliente = x.CodigoCliente,
                     Nombres = x.Nombres,
                     Apellidos = x.Apellidos,
                     Telefonos = x.Telefonos,
                     Nit = x.Nit,
                     Direccion = x.Direccion,
                     Alias = x.Alias,
                     Tipo_Cliente = x.Tipos.TipoCliente,
                     FechaCreacion = x.FechaCreacion,
                     Sucursal = x.Sucursal.NombreSucursal,
                     EstadoActual = x.IsActive == true ? "Inactivo" : "Activo"

                 })
              .ToList();
        }

        public List<Cliente> GetClientesbyCredi()
        {
            return _context.Clientes.Where(x => x.PermitirCredito == true).ToList();
        }
        public IList<ListarClientes> GetclientesCredito()//int id, bool includeRelatedEntities = true) // true es por defecto
        {
            var clienteslista = _context.Clientes.AsQueryable();
            /*
            if (id != 0)
            {
                clienteslista = clienteslista.Where(a => a.Id == id);
            }
            */
            return clienteslista
                 .Include(r => r.Tipos)

                 //.OrderBy(a => a.Nombres).ThenBy(a => a.Apellidos)
                  .Where(a=> a.PermitirCredito==true)
                 .Select(x => new ListarClientes
                 {
                     Codigo = x.Id,
                     CodigoCliente = x.CodigoCliente,
                     Nombres = x.Nombres,
                     Apellidos = x.Apellidos,
                     Telefonos = x.Telefonos,
                     Nit = x.Nit,
                     Direccion = x.Direccion,
                     Alias = x.Alias,
                     Tipo_Cliente = x.Tipos.TipoCliente,
                     FechaCreacion = x.FechaCreacion,
                     Sucursal = x.Sucursal.NombreSucursal,
                     DPI = x.DPI,
                     EstadoActual = x.IsActive == true ? "Inactivo" : "Activo"

                 }).ToList();
        }

        public Cliente GetByCodigoNew(string codigo)
        {
            return _context.Clientes.Where(x => x.CodigoCliente == codigo).FirstOrDefault();
        }

        public Cliente GetClienteByNit(string Nit)
        {
            return _context.Clientes
                .Where(a => a.IsActive == false && a.Nit == Nit)
                .ToList().FirstOrDefault();
        }
        public string GetLastCliente(int sucursal)
        {
            var listado = _context.Clientes.ToList();
            if (listado.Count() > 0)
            {
                listado = listado.Where(x => x.SucursalId == sucursal).ToList();
                listado = listado.OrderByDescending(x => x.CodigoCliente).ToList();
                if (listado.Count() > 0)
                {
                    string no = (string)listado.FirstOrDefault().CodigoCliente;
                    return no;
                }
                else
                {
                    return "";
                }

            }
            else
            {
                return "";
            }
        }
    }
}
