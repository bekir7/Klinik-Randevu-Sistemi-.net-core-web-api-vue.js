using Microsoft.AspNetCore.Mvc;
using RandevuSistemiv2.DTOs;
using RandevuSistemiv2.Services;

namespace RandevuSistemiv2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        /// <summary>
        /// Tüm doktorları getirir
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        /// <summary>
        /// Aktif doktorları getirir
        /// </summary>
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetActiveDoctors()
        {
            var doctors = await _doctorService.GetActiveDoctorsAsync();
            return Ok(doctors);
        }

        /// <summary>
        /// ID'ye göre doktor getirir
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        /// <summary>
        /// TC numarasına göre doktor getirir
        /// </summary>
        [HttpGet("tc/{tcNumber}")]
        public async Task<ActionResult<DoctorDto>> GetDoctorByTcNumber(string tcNumber)
        {
            var doctor = await _doctorService.GetDoctorByTcNumberAsync(tcNumber);
            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        /// <summary>
        /// Uzmanlık alanına göre doktorları getirir
        /// </summary>
        [HttpGet("specialty/{specialty}")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctorsBySpecialty(string specialty)
        {
            var doctors = await _doctorService.GetDoctorsBySpecialtyAsync(specialty);
            return Ok(doctors);
        }

        /// <summary>
        /// Yeni doktor oluşturur
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            // TC numarası kontrolü
            if (await _doctorService.TcNumberExistsAsync(createDoctorDto.TcNumber))
            {
                return BadRequest("Bu TC numarası zaten kayıtlı.");
            }

            var doctor = await _doctorService.CreateDoctorAsync(createDoctorDto);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        /// <summary>
        /// Doktor bilgilerini günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, UpdateDoctorDto updateDoctorDto)
        {
            if (!await _doctorService.DoctorExistsAsync(id))
                return NotFound();

            var doctor = await _doctorService.UpdateDoctorAsync(id, updateDoctorDto);
            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        /// <summary>
        /// Doktoru siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (!await _doctorService.DoctorExistsAsync(id))
                return NotFound();

            var result = await _doctorService.DeleteDoctorAsync(id);
            if (!result)
                return BadRequest("Bu doktorun randevuları bulunduğu için silinemez.");

            return NoContent();
        }
    }
}

