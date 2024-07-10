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
    public class CustomerRepositorio : BaseRepository<Customer>, ICustomerRepositorio
    {
        private VentasContext _ventasContext;
        public CustomerRepositorio(VentasContext ventasContext) : base(ventasContext)
        {
            this._ventasContext = ventasContext;
        }

        public async Task<List<Customer>> GetAllRepositorio()
        {
            return await (from x in _ventasContext.Customer.Include(t => t.CustomerType)
                    select x).ToListAsync();
        }
    }
}
