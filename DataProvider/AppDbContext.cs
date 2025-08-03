using DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProvider
{
    public class AppDbContext : DbContext
    {
        public DbSet<ScriptGenerationHistory> ScriptGenerationHistories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
