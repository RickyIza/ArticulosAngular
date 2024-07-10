using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Domain
{
    public class Comprobante
    {
        public int NroComprobante { get; set; }
        public DateTime FechaVcmto { get; set; }
        public string NombreCliente { get; set; }
        public decimal Monto { get; set; }
        public string TipoComprobante { get; set; }
    }
}
