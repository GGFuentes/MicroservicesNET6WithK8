using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Notification.Data;
using MS.AFORO255.Notification.Persistences;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseMySQL(builder.Configuration["mariadb:cn"]);
    });
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

DbCreated.CreateDbIfNotExists(app);
app.Run();

