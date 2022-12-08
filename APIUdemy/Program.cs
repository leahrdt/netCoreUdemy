using APIUdemy;

var builder = WebApplication.CreateBuilder(args);

//Se llevo varias cosas del program.cs a la clase startup
var startup = new Startup(builder.Configuration);

//Se configuro el program de maneje los servicios
startup.ConfigureServices(builder.Services);

var app = builder.Build();

//Se configuro el program de maneje los middlewares
startup.Configure(app, app.Environment);

app.Run();