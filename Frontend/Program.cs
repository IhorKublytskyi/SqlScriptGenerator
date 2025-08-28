using Frontend.Clients;
using Frontend.Components;
using Frontend.Interfaces;
using Frontend.Models;
using Frontend.Services;
using Frontend.Validators;
using MudBlazor;
using MudBlazor.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add MudBlazor services
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.MaxDisplayedSnackbars = 5;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Outlined;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRefitClient<IScriptGeneratorApi>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https+http://storefront");
    });
builder.Services.AddScoped<IScriptGenerationService, ScriptGenerationService>();
builder.Services.AddSingleton<GenerationState>();
builder.Services.AddScoped<QueryParametersValidator>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();