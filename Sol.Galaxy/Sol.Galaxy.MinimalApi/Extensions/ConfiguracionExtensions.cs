using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Sol.Galaxy.Application;
using Sol.Galaxy.Data.ServicesData;
using Sol.Galaxy.Domain;
using Sol.Galaxy.Utils.Logged;
using System.Runtime.CompilerServices;

namespace Sol.Galaxy.MinimalApi.Extensions
{
    public static class ConfiguracionExtensions
    {
        /// <summary>
        /// Contador de Palabras Galaxy
        /// </summary>
        /// <param name="cadena">Palabra a contar</param>
        /// <returns>Numero de letras</returns>
        public static int ContadorPalabras(this string cadena)
        {

            int cantidad = cadena.Length;
            return cantidad;

        }


        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddTransient<IArticuloApp, ArticuloApp>();
            services.AddTransient<IArticuloData, ArticuloData>();
            services.AddTransient<ISeguridadApp, SeguridadApp>();
            services.AddTransient<IUserRepositorio, UserRepositorio>();
            services.AddTransient<IInvoiceRepositorio, InvoiceRepositorio>();
            services.AddTransient<IComprobantesApp, ComproanteApp>();
            services.AddTransient<ILoggedService, LoggerServices>();
            services.AddTransient<IUserOptionRepositorio, UserOptionRepositorio>();
            services.AddTransient<ICustomerRepositorio, CustomerRepositorio>();
            services.AddTransient<IClienteApp, ClienteApp>();
            return services;
        }


        public static WebApplication ConfigureMethods(this WebApplication app)
        {


            app.MapGet("/comprobantes", [Authorize] async (IComprobantesApp comprobantes) =>
            {
                return await comprobantes.List();
            });

            #region Articulos

            app.MapGet("/articulos", [Authorize]
            async (IArticuloApp articuloApp, IHttpContextAccessor httpContextAccessor) =>
            {

                //string value = httpContextAccessor.HttpContext.User.FindFirst("user").Value;
                return await articuloApp.GetArticulos();
            });


            app.MapGet("/articulospage", [Authorize]
            async (IArticuloApp articuloApp, IHttpContextAccessor httpContextAccessor, int nropagina, int regpagina) =>
            {

                //string value = httpContextAccessor.HttpContext.User.FindFirst("user").Value;
                return await articuloApp.GetArticulosPaged("", regpagina, nropagina);
            });

            app.MapGet("/articulos/{id}", [Authorize] async (IArticuloApp articuloApp, int id = 0) =>
            {

                Articulo a = await articuloApp.GetArticulo(id);

                if (a == null)
                {
                    return Results.BadRequest("No se encontro el articulo");
                }

                return Results.Ok(a);

            });


            app.MapPost("/articulos", [Authorize] async (IArticuloApp articuloApp, Articulo articulo) =>
            {
                return Results.Ok(await articuloApp.AddArticulo(articulo));
            });


            app.MapPut("/articulos", [Authorize] async (IArticuloApp articuloApp, Articulo articulo) =>
            {
                return Results.Ok(await articuloApp.UpdateArticulo(articulo));
            });

            #endregion

            #region Seguridad

            app.MapPost("/auth", async (ISeguridadApp seguridadApp, UserAutenticaRequest request) =>
            {
                UserAutenticateResponse resp = await seguridadApp.Autentica(request);
                if (resp == null)
                {
                    return Results.BadRequest("Credenciales no validar");
                }

                return Results.Ok(resp);

            });

            app.MapGet("/opciones", [Authorize] async (IHttpContextAccessor httpContextAccessor, ISeguridadApp seguridadApp) =>
            {
                List<Opcion> opciones = new List<Opcion>();
                int userId = 0;
                string value = httpContextAccessor.HttpContext?.User?.FindFirst("id")?.Value;

                if (int.TryParse(value, out userId))
                {
                    opciones = await seguridadApp.OpcionesPorUsuario(userId);
                }

                return Results.Ok(opciones);

            });

            #endregion

            #region Clientes

            app.MapGet("/clientes", [Authorize] async (IClienteApp clienteApp) =>
            {
                return Results.Ok(await clienteApp.GetAll());
            });

            app.MapGet("/clientes/{id}", [Authorize] async (IClienteApp clienteApp, int id = 0) =>
            {

                Cliente a = await clienteApp.GetById(id);

                if (a == null)
                {
                    return Results.BadRequest("No se encontro el articulo");
                }

                return Results.Ok(a);

            });

            app.MapPost("/clientes", [Authorize] async (IClienteApp clienteApp, Cliente cliente) =>
            {
                return Results.Ok(await clienteApp.Add(cliente));
            });


            app.MapPut("/clientes", [Authorize] async (IClienteApp clienteApp, Cliente cliente) =>
            {
                return Results.Ok(await clienteApp.Update(cliente));
            });

            app.MapDelete("/clientes/{id}", [Authorize] async (IClienteApp clienteApp , int id = 0) =>
            {
                return Results.Ok(await clienteApp.Delete(id));
            });

            #endregion

            return app;
        }

    }
}
