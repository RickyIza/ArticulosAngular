using Sol.Galaxy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public interface IComprobantesApp
    {
        Task<List<Comprobante>> List();
    }
}
