using WebApplication1.Models;

namespace WebApplication1.DTO;

public class NewPrescriptionForm
{
    public Patient Patient { get; set; }
    
    public Doctor Doctor { get; set; }
    
    public List<MedicamentDTO> Medicaments { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
}