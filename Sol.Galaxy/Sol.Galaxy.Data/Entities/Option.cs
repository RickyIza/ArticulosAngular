using Sol.Galaxy.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Entities
{
    public class Option : AuditaBase
    {
        public int OptionId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public virtual List<UserOption> UserOption { get; set; }

    }
}
