using Galaxy.Sales.Api.Application.Domain;

namespace Galaxy.Sales.Api.Application.ApplicationDomain
{
    public interface IArticuloApp
    {
        List<Articulo> GetArticulos();

        Articulo GetArticulo(int id);
    }
}
