using System.Text.Json.Serialization;

namespace Galaxy.Sales.Api.Application.Domain
{
    public class Articulo
    {

        public int Codigo { get; set; }
        //[JsonPropertyName("Name")]
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

    }
}
