using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.DTO;

namespace WebApplication1.Repositories;

public class TripRepository : ITripRepository
{
    private readonly TripsContext _tripsContext;

    public TripRepository(TripsContext tripsContext)
    {
        _tripsContext = tripsContext;
    }


    public IEnumerable<TripResponseDto> GetTrips(int page, int pageSize)
    {
        var query = _tripsContext.Trips
            .Include(t => t.IdCountries)
            .Include(t => t.ClientTrips).ThenInclude(ct => ct.IdClientNavigation)
            .OrderByDescending(t => t.DateFrom)
            .AsQueryable();
        
        
        var totalTrips = query.Count();
        var allPages = (int)Math.Ceiling((double)(totalTrips / (decimal)pageSize));
        var respnseList = new List<TripResponseDto>();

        for (int currentPage = 1; currentPage <= allPages; currentPage++)
        {
            var trips = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new TripDto
                {
                    Name = t.Name,
                    Description = t.Description,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    MaxPeople = t.MaxPeople,
                    Countries = t.IdCountries.Select(c => new CountryDto { Name = c.Name }).ToList(),
                    Clients = t.ClientTrips.Select(ct => new ClientDto
                    {
                        FirstName = ct.IdClientNavigation.FirstName,
                        LastName = ct.IdClientNavigation.LastName
                    }).ToList()
                }).ToList();
            
            var tripResponse = new TripResponseDto()
            {
                PageNum = currentPage,
                PageSize = pageSize,
                AllPages = allPages,
                Trips = trips
            };
            
            respnseList.Add(tripResponse);
        }
        
        return respnseList;
    }

    public bool IfClientHasTrip(int id)
    {
        return _tripsContext.ClientTrips.Any(ct => ct.IdClient == id);
    }
}