using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models.Data;

public class Animal
{
    public int Id { get; set;}
    public required string Name { get; set;}

    // Lines 12-14 are linked
    public int SpeciesId { get; set;}
    [ForeignKey(nameof(SpeciesId))]
    public Species Species { get; set; } = null!;

    public required Sex Sex {get; set;}

    // public DateTime? DateOfBirth { get; set;}

    // public required DateTime DateOfAcquisition { get; set;}

    public int EnclosureId { get; set;} // "EnclosureId" is FK in "Enclosures"
    [ForeignKey(nameof(EnclosureId))]
    public Enclosure Enclosures { get; set; } = null!;

}