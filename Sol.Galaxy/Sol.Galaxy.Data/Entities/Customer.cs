using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sol.Galaxy.Data.Entities.Base;

namespace Sol.Galaxy.Data.Entities
{
    public class Customer: AuditaBase 
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerTypeId { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
        public virtual CustomerType CustomerType { get; set; }
    }
}
