using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Http.Src;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Withdrawal.Messages.CommandHandlers;
using MS.AFORO255.Withdrawal.Messages.Commands;
using MS.AFORO255.Withdrawal.Models;
using MS.AFORO255.Withdrawal.Persistences;
using MS.AFORO255.Withdrawal.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(
    options =>
    {
        options.UseNpgsql(builder.Configuration["postgres:cn"]);
    });
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAccountService, AccountService>();
/*Start RabbitMQ*/
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddRabbitMQ();
builder.Services.AddTransient<IRequestHandler<TransactionCreateCommand, bool>, TransactionCommandHandler>();
builder.Services.AddTransient<IRequestHandler<NotificationCreateCommand, bool>, NotificationCommandHandler>();
/*End RabbitMQ*/
builder.Services.AddProxyHttp();
var app = builder.Build();
// Configure the HTTP request pipeline.



app.MapPost("/api/transaction/withdrawal", (TransactionRequest request, ITransactionService transactionService,
    IEventBus eventBus, IAccountService accountService) =>
{
    TransactionModel transaction = new TransactionModel(request.Amount, request.AccountId);
    transaction = transactionService.Withdrawal(transaction);

    eventBus.SendCommand(new TransactionCreateCommand(transaction.Id, transaction.Amount, transaction.Type,
                  transaction.CreationDate, transaction.AccountId));
    eventBus.SendCommand(new NotificationCreateCommand(transaction.Id, transaction.Amount, transaction.Type,
                       $"Se proceso el {transaction.Type} con el monto de {transaction.Amount} de su cuenta {transaction.AccountId}",
                       "servicedesk@aforo255.com", transaction.AccountId));

    return transaction;
})
.Produces<List<TransactionModel>>()
.WithName("Withdrawal");

app.Run();

internal record TransactionRequest(int AccountId, decimal Amount);