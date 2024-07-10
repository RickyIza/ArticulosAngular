using Sol.Galaxy.Domain;
using Sol.Galaxy.Domain.Utils;

namespace Sol.Galaxy.Application
{
    public interface IArticuloApp
    {
        Task<List<ArticuloLista>> GetArticulos();

        Task<Articulo> GetArticulo(int id);

        Task<Articulo> AddArticulo(Articulo articulo);

        Task<Articulo> UpdateArticulo(Articulo articulo);

        Task<ListaPaginada<ArticuloLista>> GetArticulosPaged(string filtro, int regxpag, int nropagina);
    }
}
