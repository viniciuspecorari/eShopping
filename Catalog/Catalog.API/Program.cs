using Catalog.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


// Startup program
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });


var app = builder.Build();

app.Run();
