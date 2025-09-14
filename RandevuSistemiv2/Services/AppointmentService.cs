using Microsoft.EntityFrameworkCore;
using RandevuSistemiv2.Data;
using RandevuSistemiv2.DTOs;
using RandevuSistemiv2.Models;

namespace RandevuSistemiv2.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.StartTime)
                .ToListAsync();

            return appointments.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == patientId)
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.StartTime)
                .ToListAsync();

            return appointments.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.DoctorId == doctorId)
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.StartTime)
                .ToListAsync();

            return appointments.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDateAsync(DateTime date)
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.AppointmentDate.Date == date.Date)
                .OrderBy(a => a.StartTime)
                .ToListAsync();

            return appointments.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.AppointmentDate.Date >= startDate.Date && a.AppointmentDate.Date <= endDate.Date)
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.StartTime)
                .ToListAsync();

            return appointments.Select(MapToDto);
        }

        public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.Id == id);

            return appointment != null ? MapToDto(appointment) : null;
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
        {
            // Parse start time from string to TimeSpan
            if (!TimeSpan.TryParse(createAppointmentDto.StartTime, out var startTime))
                throw new InvalidOperationException($"Invalid time format: {createAppointmentDto.StartTime}");

            // Get doctor's schedule for the appointment date
            var dayOfWeek = createAppointmentDto.AppointmentDate.DayOfWeek;
            var doctorSchedule = await _context.DoctorSchedules
                .FirstOrDefaultAsync(s => s.DoctorId == createAppointmentDto.DoctorId && 
                                        s.DayOfWeek == dayOfWeek && 
                                        s.IsActive);

            if (doctorSchedule == null)
                throw new InvalidOperationException("Doctor is not available on this day");

            // Calculate end time based on doctor's schedule duration
            var endTime = startTime.Add(TimeSpan.FromMinutes(doctorSchedule.DurationMinutes));

            // Check if time slot is available
            if (!await IsTimeSlotAvailableAsync(createAppointmentDto.DoctorId, createAppointmentDto.AppointmentDate, startTime, endTime))
                throw new InvalidOperationException("Time slot is not available");

            var appointment = new Appointment
            {
                PatientId = createAppointmentDto.PatientId,
                DoctorId = createAppointmentDto.DoctorId,
                AppointmentDate = createAppointmentDto.AppointmentDate,
                StartTime = startTime,
                EndTime = endTime,
                Notes = createAppointmentDto.Notes,
                Status = "Scheduled",
                CreatedAt = DateTime.UtcNow
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Reload with includes
            var createdAppointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstAsync(a => a.Id == appointment.Id);

            return MapToDto(createdAppointment);
        }

        public async Task<AppointmentDto?> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return null;

            if (updateAppointmentDto.AppointmentDate.HasValue)
                appointment.AppointmentDate = updateAppointmentDto.AppointmentDate.Value;
            
            if (updateAppointmentDto.StartTime.HasValue)
                appointment.StartTime = updateAppointmentDto.StartTime.Value;
            
            if (updateAppointmentDto.EndTime.HasValue)
                appointment.EndTime = updateAppointmentDto.EndTime.Value;
            
            if (updateAppointmentDto.Notes != null)
                appointment.Notes = updateAppointmentDto.Notes;
            
            if (!string.IsNullOrEmpty(updateAppointmentDto.Status))
                appointment.Status = updateAppointmentDto.Status;
            
            if (updateAppointmentDto.Diagnosis != null)
                appointment.Diagnosis = updateAppointmentDto.Diagnosis;
            
            if (updateAppointmentDto.Prescription != null)
                appointment.Prescription = updateAppointmentDto.Prescription;

            appointment.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Reload with includes
            var updatedAppointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstAsync(a => a.Id == appointment.Id);

            return MapToDto(updatedAppointment);
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AppointmentExistsAsync(int id)
        {
            return await _context.Appointments.AnyAsync(a => a.Id == id);
        }

        public async Task<bool> IsTimeSlotAvailableAsync(int doctorId, DateTime appointmentDate, TimeSpan startTime, TimeSpan endTime, int? excludeAppointmentId = null)
        {
            var query = _context.Appointments
                .Where(a => a.DoctorId == doctorId && 
                           a.AppointmentDate.Date == appointmentDate.Date &&
                           a.Status != "Cancelled" &&
                           (a.StartTime < endTime && a.EndTime > startTime));

            if (excludeAppointmentId.HasValue)
                query = query.Where(a => a.Id != excludeAppointmentId.Value);

            return !await query.AnyAsync();
        }

        public async Task<IEnumerable<AvailableTimeSlotDto>> GetAvailableTimeSlotsAsync(int doctorId, DateTime date)
        {
            var doctorSchedule = await _context.DoctorSchedules
                .Where(s => s.DoctorId == doctorId && 
                           s.DayOfWeek == date.DayOfWeek && 
                           s.IsActive)
                .FirstOrDefaultAsync();

            if (doctorSchedule == null)
                return new List<AvailableTimeSlotDto>();

            var existingAppointments = await _context.Appointments
                .Where(a => a.DoctorId == doctorId && 
                           a.AppointmentDate.Date == date.Date &&
                           a.Status != "Cancelled")
                .ToListAsync();

            var availableSlots = new List<AvailableTimeSlotDto>();
            var currentTime = doctorSchedule.StartTime;
            var endTime = doctorSchedule.EndTime;
            var duration = TimeSpan.FromMinutes(doctorSchedule.DurationMinutes);

            while (currentTime.Add(duration) <= endTime)
            {
                var slotEndTime = currentTime.Add(duration);
                var isAvailable = !existingAppointments.Any(a => 
                    (a.StartTime < slotEndTime && a.EndTime > currentTime));

                availableSlots.Add(new AvailableTimeSlotDto
                {
                    Date = date,
                    StartTime = currentTime,
                    EndTime = slotEndTime,
                    IsAvailable = isAvailable
                });

                currentTime = currentTime.Add(duration);
            }

            return availableSlots;
        }

        public async Task<bool> CancelAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            appointment.Status = "Cancelled";
            appointment.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CompleteAppointmentAsync(int id, string? diagnosis = null, string? prescription = null)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            appointment.Status = "Completed";
            appointment.Diagnosis = diagnosis;
            appointment.Prescription = prescription;
            appointment.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        private static AppointmentDto MapToDto(Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
                DoctorName = $"Dr. {appointment.Doctor.FirstName} {appointment.Doctor.LastName}",
                DoctorSpecialty = appointment.Doctor.Specialty,
                AppointmentDate = appointment.AppointmentDate,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                Notes = appointment.Notes,
                Status = appointment.Status,
                Diagnosis = appointment.Diagnosis,
                Prescription = appointment.Prescription,
                CreatedAt = appointment.CreatedAt
            };
        }
    }
}
