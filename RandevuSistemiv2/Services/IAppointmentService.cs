using RandevuSistemiv2.DTOs;

namespace RandevuSistemiv2.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDateAsync(DateTime date);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
        Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto);
        Task<AppointmentDto?> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto);
        Task<bool> DeleteAppointmentAsync(int id);
        Task<bool> AppointmentExistsAsync(int id);
        Task<bool> IsTimeSlotAvailableAsync(int doctorId, DateTime appointmentDate, TimeSpan startTime, TimeSpan endTime, int? excludeAppointmentId = null);
        Task<IEnumerable<AvailableTimeSlotDto>> GetAvailableTimeSlotsAsync(int doctorId, DateTime date);
        Task<bool> CancelAppointmentAsync(int id);
        Task<bool> CompleteAppointmentAsync(int id, string? diagnosis = null, string? prescription = null);
    }
}

