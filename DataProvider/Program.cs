using DataProvider;
using DataProvider.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

//Вынеси строки подключения в secrets
builder.AddNpgsqlDbContext<AppDbContext>("postgres-db");

builder.AddServiceDefaults();

var app = builder.Build();

app.MapGrpcService<ScriptGenerationHistoriesRepository>();

app.MapDefaultEndpoints();

app.Run();
