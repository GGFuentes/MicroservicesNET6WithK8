using MS.AFORO255.Account;
using MS.AFORO255.Account.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure the HTTP request pipeline.
// Manually create an instance of the Startup class
var startup = new Startup(builder.Configuration);
// Manually call ConfigureServices()
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
// Fetch all the dependencies from the DI container 
// var hostLifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
// As pointed out by DavidFowler, IHostApplicationLifetime is exposed directly on ApplicationBuilder

// Call Configure(), passing in the dependencies
startup.Configure(app, app.Lifetime);
// Call ConfigureEndpoints(), passing in the dependencies
startup.ConfigureEndpoints(app, app.Lifetime);

DbCreated.CreateDbIfNotExists(app);
app.Run();
