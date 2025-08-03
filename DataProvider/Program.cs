using DataProvider;
using DataProvider.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AspireDb"));
});
builder.AddServiceDefaults();
var app = builder.Build();
app.MapGrpcService<ScriptGenerationHistoriesRepository>();
app.MapDefaultEndpoints();

app.MapGet("/", () => "Hello from dataprovider!");

app.Run();
