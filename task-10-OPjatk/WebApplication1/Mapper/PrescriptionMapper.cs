using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Mapper;

public static class PrescriptionMapper
{
    public static Prescription ToPrescriptionEntity(this NewPrescriptionForm form)
    {
        return new Prescription
        {
            IdDoctor = form.Doctor.IdDoctor,
            IdPatient = form.Patient.IdPatient,
            Doctor = form.Doctor,
            Patient = form.Patient,
            Date = form.Date,
            DueDate = form.DueDate
        };
    }
}