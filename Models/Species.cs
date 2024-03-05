using Microsoft.OpenApi.Writers;
using ZooManagement.Enums;

namespace ZooManagement.Models;

public class Species
{
    public int Id { get; set; } // Db automatically allocates the id
    public required string Name { get; set; }
    public required Classification Classification { get; set; }
}