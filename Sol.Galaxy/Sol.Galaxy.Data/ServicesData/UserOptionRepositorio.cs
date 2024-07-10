using Microsoft.EntityFrameworkCore;
using Sol.Galaxy.Data.Contexts;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.ServicesData.RepoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.ServicesData
{
    public class UserOptionRepositorio : BaseRepository<UserOption>, IUserOptionRepositorio
    {
        private readonly VentasContext ventasContextp;
        public UserOptionRepositorio(VentasContext ventasContext) : base(ventasContext)
        {
            ventasContextp = ventasContext;
        }

        public async Task<List<Option>> getOptionByUser(int userId)
        {
            List<Option> result = await (from x in ventasContextp.Option
                                   join y in ventasContextp.UserOption
                                   on x.OptionId equals y.OptionId
                                   where y.UserId == userId
                                   select x
                                   ).ToListAsync();


            return result;
        }
    }
}
