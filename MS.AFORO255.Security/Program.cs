using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Token.Src;
using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Security.Data;
using MS.AFORO255.Security.Persistences;
using MS.AFORO255.Security.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    var c = builder.Build();    
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});
var config = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseMySQL(builder.Configuration["cn:mysql"]);
    });
builder.Services.AddScoped<IAccessService, AccessService>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("jwt"));

builder.Services.AddConsul();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();
app.UseConsul();

DbCreated.CreateDbIfNotExists(app);
app.Run();