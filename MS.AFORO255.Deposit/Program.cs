using Aforo255.Cross.Event.Src;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Deposit.Data;
using MS.AFORO255.Deposit.Messages.CommandHandlers;
using MS.AFORO255.Deposit.Messages.Commands;
using MS.AFORO255.Deposit.Persistences;
using MS.AFORO255.Deposit.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureConfiguration(builder.Configuration);
ConfigureServices(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureMiddleware(app, app.Services);
ConfigureEndpoints(app, app.Services);

DbCreated.CreateDbIfNotExists(app);
app.Run();


//Local methods
void ConfigureConfiguration(ConfigurationManager configuration)
{

}
void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddDbContext<ContextDatabase>(
        options =>
        {
            options.UseNpgsql(builder.Configuration["postgres:cn"]);
        });
    services.AddScoped<ITransactionService, TransactionService>();
    /*Start RabbitMQ*/
    services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
    services.AddRabbitMQ();
    services.AddTransient<IRequestHandler<TransactionCreateCommand, bool>, TransactionCommandHandler>();
    /*End RabbitMQ*/
}
void ConfigureMiddleware(IApplicationBuilder app, IServiceProvider services)
{
    app.UseAuthorization();
}
void ConfigureEndpoints(IEndpointRouteBuilder app, IServiceProvider services)
{
    app.MapControllers();
}
