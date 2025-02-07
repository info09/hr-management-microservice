using Common.Logging;
using Employee.API.Extensions;
using Employee.API.Persistance;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


Log.Information($"Start {builder.Environment.ApplicationName} up");

try
{
    builder.Host.UseSerilog(Serilogger.Configure);
    builder.Host.AddAppConfigurations();
    builder.Services.AddInfrastructure(builder.Configuration);

    var app = builder.Build();

    app.UseInfrastructure();
    app.MigrateDatabase<EmployeeContext>((context, _) =>
    {
        EmployeeContextSeed.SeedEmployeeAsync(context, Log.Logger).Wait();
    }).Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }

    Log.Fatal(ex, $"Unhandled exception: {ex.Message}");
}
finally
{
    Log.Information($"Shut down {builder.Environment.ApplicationName} complete");
    Log.CloseAndFlush();
}

