using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Domain
{
    public class ArticuloLista
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
