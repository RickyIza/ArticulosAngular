using Microsoft.EntityFrameworkCore;
using Sol.Galaxy.Application;
using Sol.Galaxy.Data.Contexts;
using Sol.Galaxy.MinimalApi.Extensions;
using System.Reflection;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Sol.Galaxy.Utils.Models.Configs;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (HostBuilderContext context, LoggerConfiguration loggerConfiguration) => {
        loggerConfiguration.ReadFrom
        .Configuration(context.Configuration.GetSection("Logging"));
    }
    );

#region Autorizacion

JwtConfig jwtConfig = new JwtConfig();
builder.Configuration.GetSection("JwtConfig").Bind(jwtConfig);

string semilla = jwtConfig.Semilla;
byte[] semillaByte = Encoding.UTF8.GetBytes(semilla);
SymmetricSecurityKey key = new SymmetricSecurityKey(semillaByte);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => {
        opt.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = key,
            ValidateLifetime = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            ValidateAudience = true,
            ValidateIssuer = true

        };
    
    
    });


#endregion


builder.Services.AddHttpContextAccessor();

builder.Services.AddInjections();
builder.Services.AddCors(options =>
{

    options.AddPolicy("PublicApi", builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    //options.AddPolicy("Internas", b =>
    //{
    //    b.WithOrigins("http://localhost:4200").WithMethods(new string[] { "Get", "Post" }).AllowAnyHeader();
    //});

});

string cadena = builder.Configuration.GetValue<string>("CnnSQL");

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddDbContext<VentasContext>(option => {

    option.UseSqlServer(cadena);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PublicApi");
app.UseAuthentication();
app.UseAuthorization();

app.ConfigureMethods();


app.Run();

 
