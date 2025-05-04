using CatalogoApi;

var builder = Host.CreateDefaultBuilder(args);


builder.ConfigureWebHostDefaults(WebHostBuilder =>
{
    WebHostBuilder.UseStartup<Startup>();
});

var app = builder.Build();

app.Run();
