using WebApplication1.DTO;
using WebApplication1.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/medications")]
    public class MedController : ControllerBase
    {
        private readonly IMedService _medService;

        public MedController(IMedService medService)
        {
            _medService = medService;
        }

        [HttpGet("/{id:int}")]
        public async Task<IActionResult> getPatient(int id)
        {
            var patient = await _medService.FetchPatientDetails(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> createPrescription([FromBody] NewPrescriptionForm formData)
        {
            var validationResults = await _medService.ValidateAndCreatePrescription(formData);
            if (!validationResults.IsSuccess)
            {
                return BadRequest(validationResults.Errors);
            }

            return Created($"api/medications/{formData.Patient.IdPatient}", null);
        }
    }
}