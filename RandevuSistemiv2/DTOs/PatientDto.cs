using System.ComponentModel.DataAnnotations;

namespace RandevuSistemiv2.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string TcNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreatePatientDto
    {
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
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Address { get; set; }
    }

    public class UpdatePatientDto
    {
        [StringLength(100)]
        public string? FirstName { get; set; }
        
        [StringLength(100)]
        public string? LastName { get; set; }
        
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        
        [StringLength(200)]
        [EmailAddress]
        public string? Email { get; set; }
        
        public DateTime? BirthDate { get; set; }
        
        [StringLength(10)]
        public string? Gender { get; set; }
        
        [StringLength(500)]
        public string? Address { get; set; }
    }
}

