using Galaxy.Sales.Api.Application.Domain;

namespace Galaxy.Sales.Api.Application.ApplicationDomain
{
    public class ArticuloApp : IArticuloApp
    {
        public Articulo GetArticulo(int id)
        {
            throw new NotImplementedException();
        }

        public List<Articulo> GetArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            lista.Add(new Articulo { Codigo = 1, Nombre = "Monitor", Precio = 100 });
            lista.Add(new Articulo { Codigo = 2, Nombre = "Celular", Precio = 5000 });

            return lista;
        }
    }
}
