using Comunes;
using Galaxy.Sales.Api.Application.ApplicationDomain;
using Galaxy.Sales.Api.Application.Domain;
using Galaxy.Sales.Api.Services.Contexts;
using Galaxy.Sales.Api.Services.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cuando haga referencia a IArticuloApp, por debajo usarara Articulo App
builder.Services.AddScoped<IArticuloApp, ArticuloApp>();
builder.Services.AddScoped<IAlumnoProc,  AlumnoProc>();

//SQL Server
builder.Services.AddDbContext<SalesContext>(opcion => { 
    opcion.UseSqlServer("Data Source=.;Initial Catalog=Sales;Integrated Security=True;Encrypt=False");
});


//Activar el uso de Controladoras
//builder.Services.AddControllers().AddJsonOptions(option => {
//    option.JsonSerializerOptions.PropertyNamingPolicy = null;
//});


//builder permite la configuracion Inyeccion de dependencia, Redis, Cnn BD, Usare Autenticacion

// Add services to the container.

var app = builder.Build();
//app.MapControllers();
if (app.Environment.IsDevelopment() && app.Environment.EnvironmentName =="qa") //uat
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapGet("/articulodb", (SalesContext salesContext) => {

    //Product p = new Product { ProductId = 3, ProductName = "Demo PC" };
    //salesContext.Product.Add(p);
    //salesContext.SaveChanges();
    List<Product> res =  salesContext.Product.ToList();
    return res;
}).WithOpenApi();


app.MapGet("/articulos", (IArticuloApp articuloApp) =>
{

    return articuloApp.GetArticulos();

}).WithOpenApi();
//app alinear lo configuracion agregue filtros

// Configure the HTTP request pipeline.


app.Run();


public interface IVenta { 

    int Sumar(int i, int j);

    int Restar(int i, int j);
}


public class VentaComercial : IVenta
{
    public int Restar(int i, int j)
    {
        throw new NotImplementedException();
    }

    public int Sumar(int i, int j)
    {
        throw new NotImplementedException();
    }
}

public class VentaEmpresarial : IVenta
{
    public int Restar(int i, int j)
    {
        throw new NotImplementedException();
    }

    public int Sumar(int i, int j)
    {
        throw new NotImplementedException();
    }
}


public class Test {


    public void TestearInterface() {

        VentaEmpresarial venta = new VentaEmpresarial();
        Procesar(venta);



    }

    public int Procesar(IVenta venta) {

        return venta.Sumar(10, 10);
    }

}