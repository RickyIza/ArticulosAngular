using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sol.Galaxy.Data.Entities.Base;

namespace Sol.Galaxy.Data.Entities
{
    public class Invoice : AuditaBase
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
