using Comunes;
using Galaxy.Sales.Api.Application.ApplicationDomain;
using Galaxy.Sales.Api.Application.Domain;
using Microsoft.AspNetCore.Mvc;
 

namespace Galaxy.Sales.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private IArticuloApp _articuloapp;

        public ArticuloController(IArticuloApp articuloApp, IAlumnoProc alumnoProc)
        {
            _articuloapp = articuloApp;
        }


        public List<Articulo> ListaArticulo() {

            return _articuloapp.GetArticulos();
        }
    }
}
