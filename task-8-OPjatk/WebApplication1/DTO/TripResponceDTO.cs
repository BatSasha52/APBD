namespace WebApplication1.DTO;

public class TripResponseDTO
{
    public int PageNum { get; set; }
    public int PageSize { get; set; }
    public int AllPages { get; set; }
    public IEnumerable<TripDto> Trips { get; set; }
}