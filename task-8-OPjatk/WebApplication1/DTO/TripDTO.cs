namespace WebApplication1.DTO;

public class TripDto
{
    [JsonProperty("TripName")]
    public string Name { get; set; }
    [JsonProperty("Details")]
    public string Description { get; set; }
    public DateTime StartsOn { get; set; }
    public DateTime EndsOn { get; set; }
    public int Capacity { get; set; }
    public List<CountryDto> VisitingCountries { get; set; }
    public List<ClientDto> Participants { get; set; } 
}
