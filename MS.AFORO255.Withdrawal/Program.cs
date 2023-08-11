using Microsoft.EntityFrameworkCore;
using MS.AFORO255.Withdrawal.Services;
using MS.AFORO255.Withdrawal.Models;
using MS.AFORO255.Withdrawal.Persistences;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDatabase>(
    options =>
    {
        options.UseNpgsql(builder.Configuration["postgres:cn"]);
    });
builder.Services.AddScoped<ITransactionService, TransactionService>();


var app = builder.Build();
// Configure the HTTP request pipeline.



app.MapPost("/api/transaction/withdrawal" ,(TransactionRequest request, ITransactionService transactionService) =>
{
    TransactionModel transaction = new TransactionModel(request.Amount, request.AccountId);
    transaction = transactionService.Withdrawal(transaction);
    return transaction;
})
.Produces<List<TransactionModel>>()
.WithName("Withdrawal");

app.Run();

internal record TransactionRequest(int AccountId, decimal Amount);