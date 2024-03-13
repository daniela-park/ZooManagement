using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Data;
using ZooManagement.Models.Request;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/enclosures")]
public class EnclosuresController : Controller
{
    private readonly Zoo _zoo;

    public EnclosuresController(Zoo zoo)
    {
        _zoo = zoo;
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var matchingEnclosure = _zoo.Enclosures
            .Include(enclosure => enclosure.Name)
            .SingleOrDefault(enclosure => enclosure.Id == id);
        if (matchingEnclosure == null)
        {
            return NotFound();
        }
        return Ok(new GetEnclosure
        {
            Name = matchingEnclosure.Name,
            MaxNumOfAnimals = matchingEnclosure.MaxNumOfAnimals,
            // NumOfAnimals = matchingEnclosure.NumOfAnimals
        });
    }

}