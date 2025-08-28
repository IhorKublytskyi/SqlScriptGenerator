using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public sealed record ScriptGenerationHistory
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 100000)]
        public int Quantity { get; set; }
        [Required]
        public DatabaseDialect Dialect { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
