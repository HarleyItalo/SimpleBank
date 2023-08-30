using SimpleBank.Context;
using SimpleBank.Repositories;
using SimpleBank.Repositories.AccountRepository;
using SimpleBank.Usercases.GetAccountById;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Context
builder.Services.AddDbContext<SimpleBankDbContext>();

// Repositories
builder.Services.AddScoped<IAccountRepository,AccountRepository>();

// Usercases
builder.Services.AddScoped<IGetAccountById,GetAccountByIdImpl>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
