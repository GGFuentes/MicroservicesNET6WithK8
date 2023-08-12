using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Account.Persistences;
using MS.AFORO255.Account.Service;

namespace MS.AFORO255.Account;

public class Startup
{
    public Startup(IConfigurationRoot configuration) => Configuration = configuration;

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<ContextDatabase>(
          options =>
          {
              options.UseSqlServer(Configuration["sql:cn"]);
          });

        services.AddScoped<IAccountService, AccountService>();
        services.AddConsul();
        services.AddFabio();
    }

    public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
    {
        app.UseAuthorization();
        app.UseConsul();
    }

    public void ConfigureEndpoints(IEndpointRouteBuilder app, IHostApplicationLifetime lifetime)
    {
        app.MapControllers();
    }
}

