using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IMedService
{
    Task<bool> AllMedicamentsExist(List<int> idMedicaments);
    Task<bool> DoctorExists(Doctor doctor);
    Task CreatePrescription(NewPrescriptionForm form);
    Task<Patient?> GetPatientAndPrescriptions(int patientId);
}