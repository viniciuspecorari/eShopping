using Catalog.API;

var builder = WebApplication.CreateBuilder(args);

// Chame o Startup para configurar os serviços e o pipeline de middleware
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
