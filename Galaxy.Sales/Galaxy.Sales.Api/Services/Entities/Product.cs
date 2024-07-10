using System.ComponentModel.DataAnnotations;

namespace Galaxy.Sales.Api.Services.Entities
{
    public class Product
    {
        //[Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
