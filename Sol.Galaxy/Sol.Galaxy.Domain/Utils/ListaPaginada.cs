using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Domain.Utils
{
    public class ListaPaginada<T>
    {
        public int NroPagina { get; set; }
        public int RegPagina { get; set; }
        public int TotalRegistros { get; set; }
        public List<T> Registros { get; set; }
    }
}
