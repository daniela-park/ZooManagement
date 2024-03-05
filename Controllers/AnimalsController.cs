using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        return Ok(matchingAnimal);
    }

        [HttpGet("/{page}&size={PageSize}")]
        public IActionResult GetByPageAndSize([FromRoute] int page = 0, int PageSize=10)
        {
            // PageSize = 2;
            //var defaultPageSize = PageSize==null?3:PageSize;
            var animalsList = _zoo.Animals.Include(animal => animal.Species).ToList();
            var count = animalsList.Count();
            var animalsData = animalsList.Skip(page * PageSize).Take(PageSize).ToList();
            return Ok(animalsData);
        }
}