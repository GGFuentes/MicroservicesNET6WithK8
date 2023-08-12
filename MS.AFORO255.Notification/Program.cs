using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Event.Src;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Notification.Data;
using MS.AFORO255.Notification.Messages.EventHandlers;
using MS.AFORO255.Notification.Persistences;
using MS.AFORO255.Notification.Messages.Events;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration((host, builder) =>
{
    var c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

var config = builder.Configuration;

builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseMySQL(builder.Configuration["cn:mariadb"]);
    });
// Add services to the container.
/*Start - RabbitMQ*/
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<NotificationEventHandler>();
builder.Services.AddTransient<IEventHandler<NotificationCreatedEvent>, NotificationEventHandler>();
/*End - RabbitMQ*/

var app = builder.Build();
ConfigureEventBus(app);
// Configure the HTTP request pipeline.

DbCreated.CreateDbIfNotExists(app);
app.Run();


void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<NotificationCreatedEvent, NotificationEventHandler>();
}

