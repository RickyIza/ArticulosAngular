using Sol.Galaxy.Data.Contexts;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.ServicesData.RepoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sol.Galaxy.Data.ServicesData
{
    public class UserRepositorio : BaseRepository<User>, IUserRepositorio
    {
        private readonly VentasContext ventasContext;

        public UserRepositorio(VentasContext ventasContext) : base(ventasContext)
        {
            this.ventasContext = ventasContext;
        }

        public Task<User> Autentica(string username, string clave)
        {
            return  (from x in ventasContext.User
                      where x.UserName == username
                      && x.UserPassword == clave select x).FirstOrDefaultAsync();
           
        }
    }
}
