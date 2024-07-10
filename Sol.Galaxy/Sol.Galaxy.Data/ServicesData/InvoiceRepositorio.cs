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
    public class InvoiceRepositorio : BaseRepository<Invoice>, IInvoiceRepositorio
    {
        private readonly VentasContext ventasContext;

        public InvoiceRepositorio(VentasContext ventasContext) : base(ventasContext)
        {
            this.ventasContext = ventasContext;
        }

        public Task<List<Invoice>> FacturasConCliente()
        {
            return  (from x in ventasContext.Invoice.Include(t => t.Customer)
                       select x).ToListAsync();
   
        }
    }
}
