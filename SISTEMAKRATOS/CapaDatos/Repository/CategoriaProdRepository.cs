using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using sharedDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository
{
    
    public class CategoriaProdRepository
    {
        private Context _context = null;

        public CategoriaProdRepository(Context context)
        {
            _context = context;
        }
        public void Add(Categoria categoria, bool saveChanges = true)
        {
            _context.Categorias.Add(categoria);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }


        public IList<ListarCategoriaProd> GetListcategoria()
        {
            return _context.Categorias
                .Select(x => new ListarCategoriaProd
                {
                    Id = x.Id,
                    Categoria = x.Nombre,
                    Estado = x.Inactivo == true ? "Inactiva" : "Activa",



                }).ToList();
        }

        public IList<ListarCategoriaProd> GetListcategoriaToButton()
        {
            return _context.Categorias
                .Select(x => new ListarCategoriaProd
                {
                    Id = x.Id,
                    Categoria = x.Nombre,
                    Estado = x.Inactivo == true ? "Inactiva" : "Activa",



                }).Where(x=>x.Estado=="Activa").ToList();
        }


        public Categoria GetCategoria(int id)
        {
            return _context.Categorias
              .Where(a => a.Id == id).FirstOrDefault();
        }
        public Categoria GetCategoriaByName(string Name)
        {
            return _context.Categorias
              .Where(a => a.Nombre == Name).FirstOrDefault();
        }


        public void Update(Categoria categoria, bool saveChanges = true)
        {
            _context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }


    }
}
