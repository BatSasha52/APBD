using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;


[ApiController]
[Route("api/client")]
public class ClientController : Controller
{
    private readonly IClientService _serviceClient;

    public ClientController(IClientService serviceClient)
    {
        _serviceClient = serviceClient;
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveClient(int id)
    {
        var operationResult = _serviceClient.RemoveClient(id);
        if (!operationResult.HasValue) return NotFound(new { Message = "Client not found" });
        if (operationResult.Value == -1) return BadRequest(new { Message = "Client has trips and cannot be deleted" });
        return NoContent();
    }
}
