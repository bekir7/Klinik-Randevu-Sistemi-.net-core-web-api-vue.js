using Microsoft.EntityFrameworkCore;
using RandevuSistemiv2.Data;
using RandevuSistemiv2.DTOs;
using RandevuSistemiv2.Models;

namespace RandevuSistemiv2.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _context.Doctors
                .OrderBy(d => d.LastName)
                .ThenBy(d => d.FirstName)
                .ToListAsync();

            return doctors.Select(MapToDto);
        }

        public async Task<IEnumerable<DoctorDto>> GetActiveDoctorsAsync()
        {
            var doctors = await _context.Doctors
                .Where(d => d.IsActive)
                .OrderBy(d => d.LastName)
                .ThenBy(d => d.FirstName)
                .ToListAsync();

            return doctors.Select(MapToDto);
        }

        public async Task<DoctorDto?> GetDoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            return doctor != null ? MapToDto(doctor) : null;
        }

        public async Task<DoctorDto?> GetDoctorByTcNumberAsync(string tcNumber)
        {
            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.TcNumber == tcNumber);
            return doctor != null ? MapToDto(doctor) : null;
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialtyAsync(string specialty)
        {
            var doctors = await _context.Doctors
                .Where(d => d.Specialty.Contains(specialty) && d.IsActive)
                .OrderBy(d => d.LastName)
                .ThenBy(d => d.FirstName)
                .ToListAsync();

            return doctors.Select(MapToDto);
        }

        public async Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            var doctor = new Doctor
            {
                FirstName = createDoctorDto.FirstName,
                LastName = createDoctorDto.LastName,
                TcNumber = createDoctorDto.TcNumber,
                PhoneNumber = createDoctorDto.PhoneNumber,
                Email = createDoctorDto.Email,
                Specialty = createDoctorDto.Specialty,
                LicenseNumber = createDoctorDto.LicenseNumber,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return MapToDto(doctor);
        }

        public async Task<DoctorDto?> UpdateDoctorAsync(int id, UpdateDoctorDto updateDoctorDto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return null;

            if (!string.IsNullOrEmpty(updateDoctorDto.FirstName))
                doctor.FirstName = updateDoctorDto.FirstName;
            
            if (!string.IsNullOrEmpty(updateDoctorDto.LastName))
                doctor.LastName = updateDoctorDto.LastName;
            
            if (!string.IsNullOrEmpty(updateDoctorDto.PhoneNumber))
                doctor.PhoneNumber = updateDoctorDto.PhoneNumber;
            
            if (updateDoctorDto.Email != null)
                doctor.Email = updateDoctorDto.Email;
            
            if (!string.IsNullOrEmpty(updateDoctorDto.Specialty))
                doctor.Specialty = updateDoctorDto.Specialty;
            
            if (updateDoctorDto.LicenseNumber != null)
                doctor.LicenseNumber = updateDoctorDto.LicenseNumber;
            
            if (updateDoctorDto.IsActive.HasValue)
                doctor.IsActive = updateDoctorDto.IsActive.Value;

            doctor.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return MapToDto(doctor);
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            // Check if doctor has appointments
            var hasAppointments = await _context.Appointments
                .AnyAsync(a => a.DoctorId == id);
            
            if (hasAppointments)
                return false; // Cannot delete doctor with appointments

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DoctorExistsAsync(int id)
        {
            return await _context.Doctors.AnyAsync(d => d.Id == id);
        }

        public async Task<bool> TcNumberExistsAsync(string tcNumber, int? excludeId = null)
        {
            var query = _context.Doctors.Where(d => d.TcNumber == tcNumber);
            
            if (excludeId.HasValue)
                query = query.Where(d => d.Id != excludeId.Value);
            
            return await query.AnyAsync();
        }

        private static DoctorDto MapToDto(Doctor doctor)
        {
            return new DoctorDto
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                TcNumber = doctor.TcNumber,
                PhoneNumber = doctor.PhoneNumber,
                Email = doctor.Email,
                Specialty = doctor.Specialty,
                LicenseNumber = doctor.LicenseNumber,
                IsActive = doctor.IsActive,
                CreatedAt = doctor.CreatedAt
            };
        }
    }
}

