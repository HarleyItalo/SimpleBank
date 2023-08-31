using SimpleBank.Context;
using SimpleBank.Repositories.AccountRepository;
using SimpleBank.Repositories.TransactionRepository;
using SimpleBank.Usercases.CreateAccount;
using SimpleBank.Usercases.CreateCreditTransaction;
using SimpleBank.Usercases.CreateDebitTransaction;
using SimpleBank.Usercases.GetAccountById;
using SimpleBank.Usercases.GetBalanceFromAccountId;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Context
builder.Services.AddDbContext<SimpleBankDbContext>();

// Repositories
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<ITransactionRepository,TransactionRepository>();
// Usercases
builder.Services.AddScoped<IGetAccountById,GetAccountByIdImpl>();
builder.Services.AddScoped<ICreateCreditTransaction,CreateCreditTransactionImpl>();
builder.Services.AddScoped<ICreateDebitTransaction,CreateDebitTransactionImpl>();
builder.Services.AddScoped<IGetBalanceFromAccountId,GetBalanceFromAccountIdImpl>();
builder.Services.AddScoped<ICreateAccount,CreateAccountImpl>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
