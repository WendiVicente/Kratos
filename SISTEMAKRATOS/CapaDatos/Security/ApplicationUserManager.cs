using CapaDatos.Data;
using CapaDatos.Models.Usuarios;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos.Security
{
    public class ApplicationUserManager : UserManager<User>
    {
        private Context _context = new Context();

        public ApplicationUserManager(IUserStore<User> userStore)
            : base(userStore)
        {
           
        }


        //public IdentityUser FindByEmailAsync(string normalizedEmail, string password)
        //{
        //    return  _context.Users
        //        .Include(x => x.Sucursal)
        //        .Single(x => x.Email == normalizedEmail);
        //}
    }
}
