using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.Entities.Utils;
using Sol.Galaxy.Data.ServicesData.RepoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.ServicesData
{
    public interface IArticuloData : IRepositorioBase<Product>
    {
        Task<PaginatedList<Product>> GetPagedReponseAsync(string filter, int pageSize, int pageNumber);
    }
}
