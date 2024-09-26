using Microsoft.AspNetCore.Authorization;
using Task5OP.Models;

namespace Task5OP.Repositories;
public class IAnimalRepository
{
    public IEnumerable<Animals> GetAnimalsOrderedBy(string OrderBy);
    public Animals AddAnimal(Animals animal);
    public int EditAnimal(int id, Animals animal);
    public int DeleteAnimal(int id);
}