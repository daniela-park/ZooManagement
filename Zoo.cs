using Microsoft.EntityFrameworkCore;
using ZooManagement.Enums;
using ZooManagement.Models;

namespace ZooManagement;

public class Zoo : DbContext
{
    public DbSet<Animal> Animals { get; set; } = null!;
    public DbSet<Species> Species { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=zoo; Username=zoo; Password=zoo;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var lion = new Species
        {
            Id = -1,
            Name = "lion",
            Classification = Classification.Mammal,
        };

        modelBuilder.Entity<Species>().HasData(lion);

        var simba = new Animal
        {
            Id = -1,
            Name = "simba",
            SpeciesId = -1,
            Sex = Sex.Male,
            DateOfBirth = new DateOnly(1997, 10, 16),
            DateOfAcquisition = new DateOnly(2000, 1, 1),
        };
        var nala = new Animal
        {
            Id = -2,
            Name = "nala",
            SpeciesId = -1,
            Sex = Sex.Female,
            DateOfBirth = new DateOnly(1997, 9, 10),
            DateOfAcquisition = new DateOnly(2001, 2, 3),
        };

        modelBuilder.Entity<Animal>().HasData(simba, nala);
    }
}