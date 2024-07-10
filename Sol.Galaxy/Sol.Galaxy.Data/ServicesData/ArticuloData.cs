using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sol.Galaxy.Data.Contexts;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.Entities.Utils;
using Sol.Galaxy.Data.ServicesData.RepoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace Sol.Galaxy.Data.ServicesData
{
    public class ArticuloData : BaseRepository<Product>, IArticuloData
    {
        private readonly VentasContext ventasContext;
        private readonly ILogger<ArticuloData> logger;

        public ArticuloData(VentasContext ventasContext, ILogger<ArticuloData> logger) : base(ventasContext)
        {
            this.ventasContext = ventasContext;
            this.logger = logger;

            logger.LogInformation("Hizo el instanciamiento de Articulo Data");
        }

        public async Task<PaginatedList<Product>> GetPagedReponseAsync(string filter, int pageSize, int pageIndex = 1)
        {
            PaginatedList<Product> paginatedList = new PaginatedList<Product>();
            var products = from x in ventasContext.Product select x;

            if (!string.IsNullOrEmpty(filter))
            {
                products = products.Where(t => t.ProductName.Contains(filter, StringComparison.InvariantCultureIgnoreCase));
            }
            paginatedList.TotalRows = await products.CountAsync();
            paginatedList.PageIndex = pageIndex;
            paginatedList.PageSize = pageSize;
            paginatedList.Items = await products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return paginatedList;
        }
    }
}
