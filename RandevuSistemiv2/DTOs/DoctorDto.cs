using System.ComponentModel.DataAnnotations;

namespace RandevuSistemiv2.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string TcNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Specialty { get; set; } = string.Empty;
        public string? LicenseNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateDoctorDto
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
        [StringLength(100)]
        public string Specialty { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string? LicenseNumber { get; set; }
    }

    public class UpdateDoctorDto
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
        
        [StringLength(100)]
        public string? Specialty { get; set; }
        
        [StringLength(20)]
        public string? LicenseNumber { get; set; }
        
        public bool? IsActive { get; set; }
    }
}

