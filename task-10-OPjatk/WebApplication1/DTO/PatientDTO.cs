namespace WebApplication1.DTO
{
    public class PatientDTO
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class DoctorDTO
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class PrescriptionDetailViewModel
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public List<MedicamentDTO> Medicaments { get; set; }
        public DoctorDTO Doctor { get; set; }
    }

    public class PatientDetailViewModel
    {
        public PatientDTO Patient { get; set; }
        public List<PrescriptionDetailViewModel> Prescriptions { get; set; }
    }
}