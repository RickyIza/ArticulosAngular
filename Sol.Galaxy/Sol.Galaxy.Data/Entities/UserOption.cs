using Sol.Galaxy.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Entities
{
    public class UserOption : AuditaBase
    {
        public int UserOptionId { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }

        public virtual User User { get; set; }
        public virtual Option Option { get; set; }

    }
}
