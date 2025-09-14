using System.ComponentModel.DataAnnotations;

namespace RandevuSistemiv2.Models
{
    public class Patient
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(11)]
        public string TcNumber { get; set; } = string.Empty;
        
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? Email { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Address { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation properties
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

