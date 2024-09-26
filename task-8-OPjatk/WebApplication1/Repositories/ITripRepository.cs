using WebApplication1.DTO;

namespace WebApplication1.Repositories;

public interface ITripRepository
{
    public IEnumerable<TripResponseDto> GetTrips(int page, int pageSize);
    bool IfClientHasTrip(int id);
}