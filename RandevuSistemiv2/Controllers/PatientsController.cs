using Microsoft.AspNetCore.Mvc;
using RandevuSistemiv2.DTOs;
using RandevuSistemiv2.Services;

namespace RandevuSistemiv2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Tüm hastaları getirir
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        /// <summary>
        /// ID'ye göre hasta getirir
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        /// <summary>
        /// TC numarasına göre hasta getirir
        /// </summary>
        [HttpGet("tc/{tcNumber}")]
        public async Task<ActionResult<PatientDto>> GetPatientByTcNumber(string tcNumber)
        {
            var patient = await _patientService.GetPatientByTcNumberAsync(tcNumber);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        /// <summary>
        /// Yeni hasta oluşturur
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient(CreatePatientDto createPatientDto)
        {
            try
            {
                // TC numarası kontrolü
                if (await _patientService.TcNumberExistsAsync(createPatientDto.TcNumber))
                {
                    return BadRequest(new { message = "Bu TC numarası zaten kayıtlı." });
                }

                var patient = await _patientService.CreatePatientAsync(createPatientDto);
                return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Hasta oluşturulurken hata oluştu.", details = ex.Message });
            }
        }

        /// <summary>
        /// Hasta bilgilerini günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, UpdatePatientDto updatePatientDto)
        {
            if (!await _patientService.PatientExistsAsync(id))
                return NotFound();

            var patient = await _patientService.UpdatePatientAsync(id, updatePatientDto);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        /// <summary>
        /// Hastayı siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            if (!await _patientService.PatientExistsAsync(id))
                return NotFound();

            var result = await _patientService.DeletePatientAsync(id);
            if (!result)
                return BadRequest("Bu hastanın randevuları bulunduğu için silinemez.");

            return NoContent();
        }
    }
}

