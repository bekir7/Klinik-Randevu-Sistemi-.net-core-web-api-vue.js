using RandevuSistemiv2.DTOs;

namespace RandevuSistemiv2.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto?> GetPatientByIdAsync(int id);
        Task<PatientDto?> GetPatientByTcNumberAsync(string tcNumber);
        Task<PatientDto> CreatePatientAsync(CreatePatientDto createPatientDto);
        Task<PatientDto?> UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto);
        Task<bool> DeletePatientAsync(int id);
        Task<bool> PatientExistsAsync(int id);
        Task<bool> TcNumberExistsAsync(string tcNumber, int? excludeId = null);
    }
}

