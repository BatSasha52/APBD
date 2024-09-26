using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace WebApplication1.Services
{
    public class MedService : IMedService
    {
        private readonly IMedRepository _repository;

        public MedService(IMedRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AllMedicamentsExist(List<int> idMedicaments)
        {
            return await _repository.AllMedicamentsExist(idMedicaments);
        }

        public async Task<bool> DoctorExists(Doctor doctor)
        {
            return await _repository.DoctorExists(doctor);
        }

        public async Task CreatePrescription(NewPrescriptionForm form)
        {
            var medicamentIds = form.Medicaments.Select(m => m.IdMedicament).ToList();
            if (!await _repository.AllMedicamentsExist(medicamentIds))
                throw new ArgumentException("One or more medicaments do not exist");
            
            if (form.DueDate < form.Date)
                throw new ArgumentException("DueDate must be greater than or equal to Date");
            
            if (form.Medicaments.Count > 10)
                throw new ArgumentException("A prescription cannot include more than 10 medications");
            
            if (!await _repository.DoctorExists(form.Doctor))
                throw new ArgumentException("Doctor does not exist");
            
            if (!await _repository.PatientExists(form.Patient))
            {
                await _repository.AddPatient(form.Patient);
            }
            
            var prescription = new Prescription
            {
                Date = form.Date,
                DueDate = form.DueDate,
                Doctor = form.Doctor,
                Patient = form.Patient
            };

            await _repository.AddPrescription(prescription, form.Medicaments);
        }

        public async Task<PatientDetailViewModel?> GetPatientAndPrescriptions(int patientId)
        {
            var patient = await _repository.GetPatientAndPRescriptions(patientId);
            if (patient == null)
                return null;

            return new PatientDetailViewModel
            {
                Patient = new PatientDTO { IdPatient = patient.IdPatient, FirstName = patient.FirstName },
                Prescriptions = patient.Prescriptions.Select(p => new PrescriptionDetailViewModel
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new DoctorDTO { IdDoctor = p.Doctor.IdDoctor, FirstName = p.Doctor.FirstName },
                    Medicaments = p.PrescriptionMedicaments.Select(pm => new MedicamentDTO
                    {
                        IdMedicament = pm.IdMedicament,
                        Dose = pm.Dose,
                        Details = pm.Details
                    }).ToList()
                }).ToList()
            };
        }
    }
}
