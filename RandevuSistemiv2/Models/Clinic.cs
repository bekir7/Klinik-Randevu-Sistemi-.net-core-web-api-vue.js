using System.ComponentModel.DataAnnotations;

namespace RandevuSistemiv2.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Address { get; set; }
        
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        
        [StringLength(200)]
        public string? Email { get; set; }
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}

