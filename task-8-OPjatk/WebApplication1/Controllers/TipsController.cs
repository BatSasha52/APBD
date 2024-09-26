using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/trips")]
public class TripsController : Controller
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }
    
    [HttpGet]
    public IActionResult GetTrips(int page = 1, int pageSize = 10)
    {
        var trips = _tripService.GetTrips(page, pageSize);
        return Ok(trips);
    }
    
}