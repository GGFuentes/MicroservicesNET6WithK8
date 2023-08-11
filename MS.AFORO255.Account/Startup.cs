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
    }

    public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
    {
        app.UseAuthorization();
    }

    public void ConfigureEndpoints(IEndpointRouteBuilder app, IHostApplicationLifetime lifetime)
    {
        app.MapControllers();
    }
}

