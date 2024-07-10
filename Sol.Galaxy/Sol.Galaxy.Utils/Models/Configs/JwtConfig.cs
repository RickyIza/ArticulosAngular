using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Utils.Models.Configs
{
    public class JwtConfig
    {
        public string Semilla { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Minutos { get; set; }

    }
}
