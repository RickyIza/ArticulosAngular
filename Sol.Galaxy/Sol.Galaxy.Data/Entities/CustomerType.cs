using Sol.Galaxy.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Entities
{
    public class CustomerType : AuditaBase
    {
        public int CustomerTypeId { get; set; }
        public string Description { get; set; }
        public virtual List<Customer> Customer { get; set; }

    }
}
