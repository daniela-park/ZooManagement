using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.OpenApi.Writers;
using ZooManagement.Enums;

namespace ZooManagement.Models;

public class Animal
{
    public int Id { get; set; } // Db automatically allocates the id
    public required string Name { get; set; }
    public int SpeciesId { get; set; }

    [ForeignKey(nameof(SpeciesId))] // Foreign key between "SpeciesId" and "Species"
    public Species Species { get; set; } = null!; // Non-null
    public required Sex Sex { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public required DateOnly DateOfAcquisition { get; set; }

}