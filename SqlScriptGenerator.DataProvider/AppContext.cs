using AspireApp.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace SqlScriptGenerator.DataProvider
{
    public class AppContext : DbContext
    {
        public DbSet<GenerationHistory> GenerationHistories { get; set; }
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
    }
}
