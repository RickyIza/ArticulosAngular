using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

// See https://aka.ms/new-console-template for more information

var configura = new LoggerConfiguration()
    .WriteTo.Console(
        Serilog.Events.LogEventLevel.Information
    )
    .WriteTo.File("MiLogs.txt", Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 10)
    .WriteTo.MSSqlServer("Data Source=.;Initial Catalog=SalesGalaxy1;Integrated Security=True;Encrypt=False", new MSSqlServerSinkOptions
    {
        TableName = "eventos",
        SchemaName = "logs",
        AutoCreateSqlTable = true
    });


var logger = configura.CreateLogger();

logger.Information("Estamos aca de nuevo");
try
{
    throw new Exception("Division entre cero");
}
catch (Exception ex)
{
    logger.Error(ex, "no pudimos procesar");
}


Console.WriteLine("Hello, World!");

Console.ReadKey();
