using AutoMapper;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.Entities.Utils;
using Sol.Galaxy.Data.ServicesData;
using Sol.Galaxy.Domain;
using Sol.Galaxy.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public class ArticuloApp : IArticuloApp
    {
        private readonly IArticuloData articuloData;
        private readonly IMapper mapper;


        public ArticuloApp(IArticuloData articuloData, IMapper mapper)
        {
            this.articuloData = articuloData;
            this.mapper = mapper;
        }

        public async Task<Articulo> GetArticulo(int id)
        {
            Product res = await articuloData.GetByIdAsync(id);
            Articulo articulo = null;

            if (res != null)
            {
                articulo = mapper.Map<Articulo>(res);

            }
            return articulo;
        }

        public async Task<List<ArticuloLista>> GetArticulos()
        {

            List<Product> res = await articuloData.ListAllAsync();

            List<ArticuloLista> articulos = mapper.Map<List<ArticuloLista>>(res);


            return articulos;
        }

        public async Task<Articulo> AddArticulo(Articulo articulo)
        {
            //Product p = new Product { ProductId = articulo.Codigo, ProductName = articulo.Nombre };
            Product p = mapper.Map<Product>(articulo);

            await articuloData.AddAsync(p);

            return articulo;
        }


        public async Task<Articulo> UpdateArticulo(Articulo articulo)
        {
            //Product p = new Product { ProductId = articulo.Codigo, ProductName = articulo.Nombre };
            Product p = mapper.Map<Product>(articulo);
            await articuloData.UpdateAsync(p);

            return articulo;
        }
        public async Task<ListaPaginada<ArticuloLista>> GetArticulosPaged(string filtro, int regxpag, int nropagina)
        {

            PaginatedList<Product> res = await articuloData.GetPagedReponseAsync(filtro, regxpag, nropagina);

            ListaPaginada<ArticuloLista> lista = mapper.Map<ListaPaginada<ArticuloLista>>(res);

            return lista;
        }
    }
}
