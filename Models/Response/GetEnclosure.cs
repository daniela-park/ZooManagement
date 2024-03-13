using ZooManagement.Enums;

namespace ZooManagement.Models.Data;

public class GetEnclosure
{
    public int Id { get; set; }
    public required string Name { get; set;}
    public required int MaxNumOfAnimals { get; set; }
    // public required int NumOfAnimals { get; set; }
}