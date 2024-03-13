using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Data;
using ZooManagement.Models.Request;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/animals")]
public class AnimalsController : Controller
{
    private readonly Zoo _zoo;

    public AnimalsController(Zoo zoo)
    {
        _zoo = zoo;
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var matchingAnimal = _zoo.Animals
            .Include(animal => animal.Species)
            .SingleOrDefault(animal => animal.Id == id);
        if (matchingAnimal == null)
        {
            return NotFound();
        }
        return Ok(new GetAnimal
        {
            Name = matchingAnimal.Name,
            SpeciesName = matchingAnimal.Species.Name,
            Classification = matchingAnimal.Species.Classification.ToString().ToLower(),
            Sex = matchingAnimal.Sex.ToString().ToLower(),
            // DateOfBirth = matchingAnimal.DateOfBirth,
            // DateOfAcquisition = matchingAnimal.DateOfAcquisition,
        });
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] AddAnimal addAnimal)
    {
        var newAnimal = _zoo.Animals.Add(new Animal
        {
            Name = addAnimal.Name,
            SpeciesId = addAnimal.SpeciesId,
            Sex = addAnimal.Sex,
            // DateOfBirth = addAnimal.DateOfBirth,
            // DateOfAcquisition = addAnimal.DateOfAcquisition,
        }).Entity;
        _zoo.SaveChanges();
        return Ok(newAnimal);
    }

    [HttpGet]
    public IActionResult GetByPageAndSize([FromQuery] int page=1, int pageSize=10)
    {
        var animalsList = _zoo.Animals.Include(animal => animal.Species)
                                    .OrderBy(animal => animal.Species.Name)
                                    .ThenBy(animal => animal.Name)
                                    .ToList();
        var animalsData = animalsList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return Ok(animalsData);
    }
}