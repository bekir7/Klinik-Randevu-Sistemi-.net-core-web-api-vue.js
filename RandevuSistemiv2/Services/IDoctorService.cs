using RandevuSistemiv2.DTOs;

namespace RandevuSistemiv2.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<IEnumerable<DoctorDto>> GetActiveDoctorsAsync();
        Task<DoctorDto?> GetDoctorByIdAsync(int id);
        Task<DoctorDto?> GetDoctorByTcNumberAsync(string tcNumber);
        Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialtyAsync(string specialty);
        Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto createDoctorDto);
        Task<DoctorDto?> UpdateDoctorAsync(int id, UpdateDoctorDto updateDoctorDto);
        Task<bool> DeleteDoctorAsync(int id);
        Task<bool> DoctorExistsAsync(int id);
        Task<bool> TcNumberExistsAsync(string tcNumber, int? excludeId = null);
    }
}

