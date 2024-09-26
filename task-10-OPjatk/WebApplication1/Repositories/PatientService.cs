namespace WebApplication1.Repositories;

public class PatientService : IPatientService
{
    private readonly IRepository<Patient> _patientRepository;

    public PatientService(IRepository<Patient> patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PatientDetailViewModel> GetPatientDetailsAsync(int id)
    {
        var patient = await _patientRepository.GetAsync(id);
        if (patient == null) return null;
        
    }
}
