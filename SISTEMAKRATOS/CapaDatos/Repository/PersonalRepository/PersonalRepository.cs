using CapaDatos.Data;
using CapaDatos.ListasPersonalizadas;
using CapaDatos.Models.Personal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repository.PersonalRepository
{
   public  class PersonalRepository
    {
        private Context _context = null;

        public PersonalRepository(Context context)
        {
            _context = context;

        }

        public void Add(Personal personal, bool saveChanges = true)
        {
            _context.Personals.Add(personal);

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public Personal Get(int id, bool includeRelatedEntities = true) 
        {
            var persona = _context.Personals.AsQueryable();

            if (includeRelatedEntities)
            {
                
            }

            return persona.Where(a => a.Id == id).SingleOrDefault();
        }




        public void Update(Personal persona, bool saveChanges = true)
        {
            _context.Entry(persona).State = System.Data.Entity.EntityState.Modified;

            if (saveChanges)
            {
                _context.SaveChanges();
            }
        }

        public IList<ListarPersonal>GetPersonals(int id)
        {
            var persona = _context.Personals.AsQueryable();
            if(id != 0)
            {
                persona = persona.Where(x => x.Id == id);
            }

            return persona
                .Include(r => r.Contrato)
                .Select(x => new ListarPersonal
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Direccion = x.Direccion,
                    Dpi = x.Dpi,
                    Contrato = x.Contrato.Descripcion,
                    Edad = x.Edad,
                    EstadoCivil = x.EstadoCivil,
                    FechaIngreso = x.FechaIngreso,
                    Nit = x.Nit,
                    Salario = x.Salario,
                    Sucursal = x.Sucursal.NombreSucursal,
                    Estado = x.IsActive == true ? "Inactivo" : "Activo",
                    Telefonos1 = x.Telefonos1,
                    Telefonos2 = x.Telefonos2,
                    Telefonos3 = x.Telefonos3,
                    Desactivar = x.IsActive,
                    Acciones=x.IsActive,

                }).ToList();
        }

        public IList<ListarPersonal> GetListaPersonal(int idsucursal, bool todasfechas, DateTime fechainicio,
            DateTime fechafin, bool activo, bool inactivo, bool allstate)
        {
            var personalLista = _context.Personals.AsQueryable();

            if (idsucursal != 0)
            {
                personalLista = personalLista.Where(a => a.SucursalId == idsucursal);

            }
            if (todasfechas == false)
            {
                personalLista = personalLista.Where(a => a.FechaIngreso > fechainicio && a.FechaIngreso <= fechafin);
            }

            if (allstate == false)
            {
                if (activo == true)
                {
                    personalLista = personalLista.Where(a => a.IsActive == false);
                }
                if (inactivo == true)
                {
                    personalLista = personalLista.Where(a => a.IsActive == true);
                }

            }
            return personalLista
                .Include(r => r.Contrato)
                .Select(x => new ListarPersonal
                {
                    Id= x.Id,
                    Nombres= x.Nombres,
                    Apellidos= x.Apellidos,
                    Direccion= x.Direccion,
                    Dpi= x.Dpi,
                    Contrato= x.Contrato.Descripcion,
                    Edad=x.Edad,
                    EstadoCivil=x.EstadoCivil,
                    FechaIngreso=x.FechaIngreso,
                    Nit=x.Nit,
                    Salario=x.Salario,
                    Sucursal=x.Sucursal.NombreSucursal,
                    Estado= x.IsActive==true? "Inactivo":"Activo",
                    Telefonos1=x.Telefonos1,
                    Telefonos2=x.Telefonos2,
                    Telefonos3=x.Telefonos3,
                    Desactivar=x.IsActive,
                   
                }).ToList();

        }




    }
}
