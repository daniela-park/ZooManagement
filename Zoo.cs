using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Enums;
using ZooManagement.Models.Data;

namespace ZooManagement;

public class Zoo : DbContext
{
    public DbSet<Animal> Animals { get; set;} =null!;
    public DbSet<Species> Species { get; set;} = null!;
    public DbSet<Enclosure> Enclosures { get; set;} = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=zoo; Username=zoo; Password=zoo;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CREATING THE SPECIES (Id, Name, Classification)
        var speciesList = new List<Species> // Species: Mammal, Reptile, Bird, Insect, Fish, Invertebrate,
        {
            new Species { Id = -1, Name = "lion", Classification = Classification.Mammal },
            new Species { Id = -2, Name = "giraffe", Classification = Classification.Mammal },
            new Species { Id = -3, Name = "hippo", Classification = Classification.Mammal },
            new Species { Id = -4, Name = "eagle", Classification = Classification.Bird },
            new Species { Id = -5, Name = "swan", Classification = Classification.Bird },
            new Species { Id = -6, Name = "python", Classification = Classification.Reptile },
            new Species { Id = -7, Name = "tortoise", Classification = Classification.Reptile },
            new Species { Id = -8, Name = "jellyfish", Classification = Classification.Fish },
            new Species { Id = -9, Name = "seahorse", Classification = Classification.Fish },
            new Species { Id = -10, Name = "octopus", Classification = Classification.Invertebrate},
            new Species { Id = -11, Name = "startfish", Classification = Classification.Invertebrate},
            new Species { Id = -12, Name = "ladybug", Classification = Classification.Insect},
            new Species { Id = -13, Name = "bumblebee", Classification = Classification.Insect},
        };
        // POPULATING THE DB WITH SPECIES
        modelBuilder.Entity<Species>().HasData(speciesList.ToArray());


        // CREATING THE ANIMALS (Id, Name, SpeciesId, Sex, DOF, DOA, EnclosureId)
        // var simba = new Animal
        // {
        //     Id = -1,
        //     Name = "simba",
        //     SpeciesId = -1,
        //     Sex = Sex.Male,
        //     DateOfBirth = new DateOnly(1998,10,13),
        //     DateOfAcquisition = new DateOnly(2000,1,1),
        //     EnclosureId = -1,
        // };

        // var nala = new Animal
        // {
        //     Id = -2,
        //     Name = "nala",
        //     SpeciesId = -1,
        //     Sex = Sex.Female,
        //     DateOfBirth = new DateOnly(1997,9,18),
        //     DateOfAcquisition = new DateOnly(2001,2,3),
        //     EnclosureId = -1,
        // };

        // modelBuilder.Entity<Animal>().HasData(simba,nala);
        // animals.Add(simba);
        // animals.Add(nala);

        var animals = new List<Animal>(); // List of animals
        int animalId = -1;
        Random randomEnclosure = new Random();
        Random rnd = new Random();
        // DateTime RandomDate(int startYear, int endYear) =>
        //     new DateTime(rnd.Next(startYear, endYear), rnd.Next(1, 13), rnd.Next(1, 29));

        foreach (var species in speciesList) // 13
        {
            for (int i = 0; i < 10; i++)
            {
                animals.Add(new Animal
                {
                    Id = animalId--,
                    Name = $"{species.Name}{animalId}",
                    SpeciesId = species.Id,
                    Sex = (Sex)rnd.Next(0, 2),
                    // DateOfBirth = RandomDate(2010, 2020),
                    // DateOfAcquisition = RandomDate(2020, 2023),
                    EnclosureId = -6,
                });
            }
        }
        // POPULATING THE DB WITH ANIMALS
        modelBuilder.Entity<Animal>().HasData(animals.ToArray());


        // CREATING THE ENCLOSURES (Id, Name, MaxNumOfAnimals, AnimalsInTheEnclosure)
        var firstEnclosure = new Enclosure
        {
            Id = -6,
            Name = "First Enclosure",
            MaxNumOfAnimals = 500,
            // NumOfAnimals = [],
        };

        // var lionEnclosure = new Enclosure
        // {
        //     Id = -1,
        //     Name = "Lions",
        //     MaxNumOfAnimals = 10,
        //     NumOfAnimals = [],
        // };
        
        // foreach(var animal in animals)
        // {
        //     if(animal.SpeciesId == -1)
        //     {
        //         if (animals.Count(animal => animal.EnclosureId == -1) <= lionEnclosure.MaxNumOfAnimals)
        //         {
        //             lionEnclosure.NumOfAnimals.Add(1);                    
        //         }
        //     }
        // }

        // var lionEnclosure = new Enclosure
        // {
        //     Id = -1,
        //     Name = "lions",
        //     MaxNumOFAnimals = 10
        // };
        // if (lionEnclosure.MaxNumOFAnimals <= 10)
        // {
        //     // lionEnclosure.Animals.Add(simba);
        //     // lionEnclosure.Animals.Add(nala);
        //     foreach(var animal in animals)
        //     {
        //         if (animal.SpeciesId == -1)
        //         {
        //             lionEnclosure.Animals.Add(animal);
        //             animal.EnclosureId = -1;
        //         }
        //     }
        // }

        // var aviaryEnclosure = new Enclosure
        // {
        //     Id = -2,
        //     Name = "aviary",
        // };
        // if (aviaryEnclosure.NumOfAnimals <= 50)
        // {
        //     foreach(var animal in animals)
        //     {
        //         if (animal.SpeciesId == -4 || animal.SpeciesId == -5)
        //         {
        //             aviaryEnclosure.Animals.Add(animal);
        //             animal.EnclosureId = -2;
        //         }
        //     }
        // }

        // var reptileEnclosure = new Enclosure
        // {
        //     Id = -3,
        //     Name = "reptile",
        // };
        // if (reptileEnclosure.NumOfAnimals <= 40)
        // {
        //     foreach(var animal in animals)
        //     {
        //         if (animal.SpeciesId == -6 || animal.SpeciesId == -7)
        //         {
        //             reptileEnclosure.Animals.Add(animal);
        //             animal.EnclosureId = -3;
        //         }
        //     }
        // }

        // var giraffeEnclosure = new Enclosure
        // {
        //     Id = -4,
        //     Name = "giraffe",
        // };
        // if (giraffeEnclosure.NumOfAnimals <= 6)
        // {
        //     foreach(var animal in animals)
        //     {
        //         if (animal.SpeciesId == -2)
        //         {
        //             giraffeEnclosure.Animals.Add(animal);
        //             animal.EnclosureId = -4;
        //         }
        //     }
        // }

        // var hippoEnclosure = new Enclosure
        // {
        //     Id = -5,
        //     Name = "hippo",
        // };
        // if (hippoEnclosure.NumOfAnimals <= 10)
        // {
        //     foreach(var animal in animals)
        //     {
        //         if (animal.SpeciesId == -3 )
        //         {
        //             hippoEnclosure.Animals.Add(animal);
        //             animal.EnclosureId = -5;
        //         }
        //     }
        // }

        // var remainingAnimalsEnclosure = new Enclosure
        // {
        //     Id = -6,
        //     Name = "remaining animals",
        // };

        // foreach(var animal in animals)
        // {
        //     if (animal.EnclosureId == -6 )
        //     {
        //         remainingAnimalsEnclosure.Animals.Add(animal);
        //     }
        // }
        // }
        // POPULATING THE DB WITH ENCLOSURES
        // modelBuilder.Entity<Enclosure>().HasData(lionEnclosure, aviaryEnclosure, reptileEnclosure, giraffeEnclosure, hippoEnclosure, remainingAnimalsEnclosure);
        modelBuilder.Entity<Enclosure>().HasData(firstEnclosure);
    }
}