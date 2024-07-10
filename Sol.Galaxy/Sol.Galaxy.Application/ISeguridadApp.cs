using Sol.Galaxy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Application
{
    public interface ISeguridadApp
    {
        Task<UserAutenticateResponse> Autentica(UserAutenticaRequest userAutenticaRequest);

        Task<List<Opcion>> OpcionesPorUsuario(int userId);
    }
}
