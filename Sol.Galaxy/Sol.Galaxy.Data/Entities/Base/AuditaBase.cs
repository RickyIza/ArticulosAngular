using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Entities.Base
{
    public class AuditaBase
    {
        public string? UsuarioIngresa { get; set; }
        public DateTime FechaIngresa { get; set; }
        public string? UsuarioActualiza { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}
