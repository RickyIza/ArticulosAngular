using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Domain
{
    public class ClienteLista
    {
        public int IdCliente { get; set; }
        public string NombreCompleto { get; set; }
        public int TipoCliente { get; set; }
        public string TipoClienteDesc { get; set; }
    }
}
