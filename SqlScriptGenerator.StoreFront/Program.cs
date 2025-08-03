using Microsoft.AspNetCore.Mvc;

namespace SqlScriptGenerator.StoreFront
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();
            var app = builder.Build();
            app.MapDefaultEndpoints();

            app.MapGet("/generator", async ([FromQuery] int quantity, [FromQuery] int databaseTypeId) =>
            {

            });

            app.Run();
        }
    }
}
