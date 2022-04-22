using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    public class TiposClienteRepository
    {
        private Context _context = null;

        public TiposClienteRepository(Context context)
        {
            _context = context;
        }

        public void AddTipos(Tipos tipo, bool saveChanges = true)
        {
            _context.Tipos.Add(tipo);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void AddCategoriaCliente(CategoriaCliente categoria, bool saveChanges = true)
        {
            _context.CategoriaClientes.Add(categoria);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void UpdateTipos(Tipos tipo, bool saveChanges = true)
        {
            _context.Entry(tipo).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }
        public void UpdateCategoria(CategoriaCliente categoria, bool saveChanges = true)
        {
            _context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<ListaDeCategoriaCliente> GetCategoria()
        {
            return _context.CategoriaClientes
                .Select(x => new ListaDeCategoriaCliente
                {
                    Id = x.Id,
                    Categoria = x.Categoria,
                    Estado = x.IsActive == true ? "Inactiva":"Activa",



                }).ToList();
                
        }
        public IList<ListaDeTiposCliente> GettiposCliente()
        {
            return _context.Tipos
                .Select(x => new ListaDeTiposCliente
                {
                    Id= x.Id,
                    TipoCliente= x.TipoCliente,
                    Estado= x.IsActive == true? "Inactiva":"Activa"

                }).ToList();
        }
        
        public Tipos GetTipo(int id, bool includerelated = true)
        {
            var tipo = _context.Tipos.AsQueryable();
            if (includerelated)
            {
            }
            return tipo.Where(a => a.Id == id).SingleOrDefault();

        }
        public Tipos GetTipoName(string namne, bool includerelated = true)
        {
            var tipo = _context.Tipos.AsQueryable();
            if (includerelated)
            {
            }
            return tipo.Where(a => a.TipoCliente == namne).SingleOrDefault();

        }
        public CategoriaCliente GetCategoria(int id, bool includerelated = true)
        {
            var categoria = _context.CategoriaClientes.AsQueryable();
            if (includerelated)
            {


            }
            return categoria.Where(a => a.Id == id).SingleOrDefault();

        }






    }
}
