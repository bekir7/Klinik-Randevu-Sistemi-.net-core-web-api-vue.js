using Microsoft.EntityFrameworkCore;
using RandevuSistemiv2.Data;
using RandevuSistemiv2.DTOs;
using RandevuSistemiv2.Models;

namespace RandevuSistemiv2.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _context.Patients
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToListAsync();

            return patients.Select(MapToDto);
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return patient != null ? MapToDto(patient) : null;
        }

        public async Task<PatientDto?> GetPatientByTcNumberAsync(string tcNumber)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.TcNumber == tcNumber);
            return patient != null ? MapToDto(patient) : null;
        }

        public async Task<PatientDto> CreatePatientAsync(CreatePatientDto createPatientDto)
        {
            var patient = new Patient
            {
                FirstName = createPatientDto.FirstName,
                LastName = createPatientDto.LastName,
                TcNumber = createPatientDto.TcNumber,
                PhoneNumber = createPatientDto.PhoneNumber,
                Email = createPatientDto.Email,
                BirthDate = createPatientDto.BirthDate,
                Gender = createPatientDto.Gender,
                Address = createPatientDto.Address,
                CreatedAt = DateTime.UtcNow
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return MapToDto(patient);
        }

        public async Task<PatientDto?> UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return null;

            if (!string.IsNullOrEmpty(updatePatientDto.FirstName))
                patient.FirstName = updatePatientDto.FirstName;
            
            if (!string.IsNullOrEmpty(updatePatientDto.LastName))
                patient.LastName = updatePatientDto.LastName;
            
            if (!string.IsNullOrEmpty(updatePatientDto.PhoneNumber))
                patient.PhoneNumber = updatePatientDto.PhoneNumber;
            
            if (updatePatientDto.Email != null)
                patient.Email = updatePatientDto.Email;
            
            if (updatePatientDto.BirthDate.HasValue)
                patient.BirthDate = updatePatientDto.BirthDate.Value;
            
            if (!string.IsNullOrEmpty(updatePatientDto.Gender))
                patient.Gender = updatePatientDto.Gender;
            
            if (updatePatientDto.Address != null)
                patient.Address = updatePatientDto.Address;

            patient.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return MapToDto(patient);
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            // Check if patient has appointments
            var hasAppointments = await _context.Appointments
                .AnyAsync(a => a.PatientId == id);
            
            if (hasAppointments)
                return false; // Cannot delete patient with appointments

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PatientExistsAsync(int id)
        {
            return await _context.Patients.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> TcNumberExistsAsync(string tcNumber, int? excludeId = null)
        {
            var query = _context.Patients.Where(p => p.TcNumber == tcNumber);
            
            if (excludeId.HasValue)
                query = query.Where(p => p.Id != excludeId.Value);
            
            return await query.AnyAsync();
        }

        private static PatientDto MapToDto(Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                TcNumber = patient.TcNumber,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,
                Address = patient.Address,
                CreatedAt = patient.CreatedAt
            };
        }
    }
}

