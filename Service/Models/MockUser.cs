using System.ComponentModel.DataAnnotations;

namespace Service.Models
{
    public class MockUser
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Firstname { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Lastname { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [Phone]
        [StringLength(12)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
