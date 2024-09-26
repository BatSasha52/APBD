using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Task5OP.Models;
using Task5OP.Repositories;

namespace Task5OP.Controllers;
[Route("api/animals")]
[ApiController]

public class AnimalController : ControllerBase
{
    private IAnimalRepository _animalRepository;

    public AnimalController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    [HttpGet]
    public IActionResult GetAnimalsOrderedBy([FromQuery] string orderBy = "Name")
    {
        return Ok(_animalRepository.GetAnimalsOrderedBy(orderBy));
    }
    
    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animals animal)
    {
        return Ok(_animalRepository.AddAnimal(animal));
    }

    [HttpPut("{id}")] 
    public IActionResult EditAnimal([FromRoute] int id, [FromBody] Animals animal)
    {
        return Ok(_animalRepository.EditAnimal(id , animal));
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal([FromRoute] int id)
    {
        return Ok(_animalRepository.DeleteAnimal(id));
    }
}