using Microsoft.AspNetCore.Mvc;
using RandevuSistemiv2.DTOs;
using RandevuSistemiv2.Services;

namespace RandevuSistemiv2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Tüm randevuları getirir
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        /// <summary>
        /// ID'ye göre randevu getirir
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        /// <summary>
        /// Hasta ID'sine göre randevuları getirir
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByPatient(int patientId)
        {
            var appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(patientId);
            return Ok(appointments);
        }

        /// <summary>
        /// Doktor ID'sine göre randevuları getirir
        /// </summary>
        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId);
            return Ok(appointments);
        }

        /// <summary>
        /// Tarihe göre randevuları getirir
        /// </summary>
        [HttpGet("date/{date:datetime}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByDate(DateTime date)
        {
            var appointments = await _appointmentService.GetAppointmentsByDateAsync(date);
            return Ok(appointments);
        }

        /// <summary>
        /// Tarih aralığına göre randevuları getirir
        /// </summary>
        [HttpGet("daterange")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByDateRange(
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate)
        {
            var appointments = await _appointmentService.GetAppointmentsByDateRangeAsync(startDate, endDate);
            return Ok(appointments);
        }

        /// <summary>
        /// Doktor için müsait zaman dilimlerini getirir
        /// </summary>
        [HttpGet("available/{doctorId}")]
        public async Task<ActionResult<IEnumerable<AvailableTimeSlotDto>>> GetAvailableTimeSlots(
            int doctorId, 
            [FromQuery] DateTime date)
        {
            var timeSlots = await _appointmentService.GetAvailableTimeSlotsAsync(doctorId, date);
            return Ok(timeSlots);
        }

        /// <summary>
        /// Yeni randevu oluşturur
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> CreateAppointment(CreateAppointmentDto createAppointmentDto)
        {
            try
            {
                var appointment = await _appointmentService.CreateAppointmentAsync(createAppointmentDto);
                return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message, details = ex.StackTrace });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Randevu oluşturulurken beklenmeyen bir hata oluştu.", details = ex.Message });
            }
        }

        /// <summary>
        /// Randevu bilgilerini günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, UpdateAppointmentDto updateAppointmentDto)
        {
            if (!await _appointmentService.AppointmentExistsAsync(id))
                return NotFound();

            var appointment = await _appointmentService.UpdateAppointmentAsync(id, updateAppointmentDto);
            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        /// <summary>
        /// Randevuyu iptal eder
        /// </summary>
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            if (!await _appointmentService.AppointmentExistsAsync(id))
                return NotFound();

            var result = await _appointmentService.CancelAppointmentAsync(id);
            if (!result)
                return BadRequest("Randevu iptal edilemedi.");

            return Ok(new { message = "Randevu başarıyla iptal edildi." });
        }

        /// <summary>
        /// Randevuyu tamamlar
        /// </summary>
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteAppointment(int id, [FromBody] CompleteAppointmentRequest request)
        {
            if (!await _appointmentService.AppointmentExistsAsync(id))
                return NotFound();

            var result = await _appointmentService.CompleteAppointmentAsync(id, request.Diagnosis, request.Prescription);
            if (!result)
                return BadRequest("Randevu tamamlanamadı.");

            return Ok(new { message = "Randevu başarıyla tamamlandı." });
        }

        /// <summary>
        /// Randevuyu siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            if (!await _appointmentService.AppointmentExistsAsync(id))
                return NotFound();

            var result = await _appointmentService.DeleteAppointmentAsync(id);
            if (!result)
                return BadRequest("Randevu silinemedi.");

            return NoContent();
        }
    }

    public class CompleteAppointmentRequest
    {
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }
    }
}

