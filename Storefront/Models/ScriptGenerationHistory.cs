
namespace Storefront.Models
{
    public class ScriptGenerationHistory
    {
        public int Quantity { get; set; }
        public DatabaseDialect Dialect { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
