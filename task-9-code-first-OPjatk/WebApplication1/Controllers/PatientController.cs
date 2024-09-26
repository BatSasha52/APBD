namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDetailViewModel>> GetPatientDetails(int id)
    {
        var patientDetails = await _patientService.GetPatientDetailsAsync(id);
        if (patientDetails == null)
            return NotFound();
        return Ok(patientDetails);
    }
}
