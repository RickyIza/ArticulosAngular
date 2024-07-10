using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Utils.Logged
{
    public interface ILoggedService
    {
        public string UsuarioCodigo { get; }
        public string UsuarioRol { get; }
    }
}
