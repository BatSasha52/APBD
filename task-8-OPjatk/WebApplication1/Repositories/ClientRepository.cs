using WebApplication1.Context;

namespace WebApplication1.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly TripsContext _contextTrips;

    public ClientRepository(TripsContext contextTrips)
    {
        _contextTrips = contextTrips;
    }

    public int? DeleteClient(int clientId)
    {
        var foundClient = _contextTrips.Clients.Find(clientId);
        if (foundClient == null) return null; 
        _contextTrips.Clients.Remove(foundClient);
        return _contextTrips.SaveChanges();
    }
}
