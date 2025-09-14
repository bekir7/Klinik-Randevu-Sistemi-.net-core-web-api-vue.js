using System.ComponentModel.DataAnnotations;

namespace RandevuSistemiv2.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string DoctorSpecialty { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateAppointmentDto
    {
        [Required]
        public int PatientId { get; set; }
        
        [Required]
        public int DoctorId { get; set; }
        
        [Required]
        public DateTime AppointmentDate { get; set; }
        
        [Required]
        public string StartTime { get; set; } = string.Empty; // String olarak alıp TimeSpan'a çevireceğiz
        
        [StringLength(500)]
        public string? Notes { get; set; }
    }

    public class UpdateAppointmentDto
    {
        public DateTime? AppointmentDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }
    }

    public class AvailableTimeSlotDto
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}

