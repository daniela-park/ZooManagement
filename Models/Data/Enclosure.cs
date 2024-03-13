using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models.Data;

public class Enclosure
{
    public int Id { get; set;}
    public required string Name { get; set;}
    public required int MaxNumOfAnimals { get; set; }
    // public required List<int> NumOfAnimals { get; set; } = [];

    // public int EnclosureId { get; set;} // "EnclosureId" is FK in "Enclosures"
    // [ForeignKey(nameof(EnclosureId))]
    // public Enclosure Enclosures { get; set; } = null!;

}