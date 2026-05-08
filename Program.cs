using GarageBudgetApi.Repositories;
using GarageBudgetApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IBudgetRepository, InMemoryBudgetRepository>();
builder.Services.AddScoped<IBudgetService, BudgetService>();

var app = builder.Build();

app.MapControllers();

app.Run();

public partial class Program;