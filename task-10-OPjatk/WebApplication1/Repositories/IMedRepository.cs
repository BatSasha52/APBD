﻿using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IMedRepository
{
    public Task<bool> AllMedicamentsExist(List<int> idMedicaments);
    Task<bool> DoctorExists(Doctor doctor);
    Task<bool> PatientExists(Patient patient);
    Task AddPatient(Patient patient);
    Task AddPrescription(Prescription prescription, List<MedicamentDTO> medicaments);
    Task<Patient?> GetPatientAndPRescriptions(int patientId);
}