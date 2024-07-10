using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sol.Galaxy.Data.Entities.Base;

namespace Sol.Galaxy.Data.Entities
{
    public class Product : AuditaBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public decimal Cost { get; set; }
    }
}
