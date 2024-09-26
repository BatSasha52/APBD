using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedController : ControllerBase
    {
        private readonly IMedService _medService;

        public MedController(IMedService medService)
        {
            _medService = medService;
        }

        [HttpPost]
        [Route("prescriptions")]
        public async Task<IActionResult> CreatePrescription([FromBody] NewPrescriptionForm formData)
        {
            var validationResults = await _medService.ValidateAndCreatePrescription(formData);
            if (!validationResults.IsSuccess)
            {
                return BadRequest(validationResults.Errors);
            }

            return CreatedAtAction(nameof(GetPatient), new { id = formData.Patient.IdPatient }, null);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _medService.FetchPatientDetails(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}