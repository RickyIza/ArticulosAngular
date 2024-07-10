using Sol.Galaxy.Data.ServicesData;
using Sol.Galaxy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public class ComproanteApp : IComprobantesApp
    {
        private readonly IInvoiceRepositorio invoiceRepositorio;
   

        public ComproanteApp(IInvoiceRepositorio invoiceRepositorio)
        {
            this.invoiceRepositorio = invoiceRepositorio; 
        }
        public async Task<List<Comprobante>> List()
        {
            var res = await invoiceRepositorio.ListAllAsync();

            return new List<Comprobante>();
        }
    }
}
