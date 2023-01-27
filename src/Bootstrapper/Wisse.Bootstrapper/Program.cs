using Wisse.Bootstrapper;
using Wisse.Shared.Infrastructure;
using Wisse.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();

var assemblies = ModuleLoader.LoadAssemblies(builder.Configuration);
var modules = ModuleLoader.LoadModules(assemblies);

#region services

var services = builder.Services;

services.AddInfrastructure(assemblies, modules);
foreach (var module in modules)
{
    module.RegisterModule(services);
}

#endregion

#region app

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

app.UseInfrastructure();
logger.LogInformation(message: @"Modules: [{ModuleNames}]", string.Join(", ", modules.Select(x => x.Name)));

foreach (var module in modules)
{
    module.UseModule(app);
}

app.MapControllers();
app.MapModuleInfo();
app.MapGet("/", context => context.Response.WriteAsync(
    $"Wisse API is running!\nGo to: {app.Urls.Select(x => x).First()}/docs"));

#endregion

assemblies.Clear();
modules.Clear();
app.Run();