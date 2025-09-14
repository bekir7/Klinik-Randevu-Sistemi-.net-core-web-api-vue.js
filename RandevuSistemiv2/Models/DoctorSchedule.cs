using System.ComponentModel.DataAnnotations;

namespace RandevuSistemiv2.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        
        [Required]
        public int DoctorId { get; set; }
        
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        
        [Required]
        public TimeSpan StartTime { get; set; }
        
        [Required]
        public TimeSpan EndTime { get; set; }
        
        public int DurationMinutes { get; set; } = 30; // Varsayılan randevu süresi
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Navigation properties
        public virtual Doctor Doctor { get; set; } = null!;
    }
}

