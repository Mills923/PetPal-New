using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetPal_New_.Models;

namespace PetPal_New_.Data
{
    public class PetPalContext : DbContext
    {
        public PetPalContext(DbContextOptions<PetPalContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Users = modelBuilder.Entity<UserAccount>();
            var UsersDog = modelBuilder.Entity<OwnerDog>();
            var DogBreeds = modelBuilder.Entity<DogBreed>();

            Users.Property(p => p.UserID).IsRequired().ValueGeneratedOnAdd();
            Users.HasKey(p => p.UserID);
            Users.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            Users.Property(p => p.LastName).IsRequired().HasMaxLength(30);
            Users.Property(p => p.UserName).IsRequired().HasMaxLength(20);
            Users.Property(p => p.Password).IsRequired().HasMaxLength(30);
            Users.Property(p => p.Email).IsRequired().HasMaxLength(100);

            UsersDog.Property(p => p.Breed).IsRequired();
            UsersDog.Property(p => p.DogID).IsRequired().ValueGeneratedOnAdd();
            UsersDog.HasKey(p => p.DogID);

            DogBreeds.HasKey(p => p.Breed);
            DogBreeds.Property(p => p.GroomingRequirements).HasDefaultValue(0);
            DogBreeds.Property(p => p.Size).HasDefaultValue(0);
            DogBreeds.Property(p => p.ExerciseRequirement).HasDefaultValue(0);
            DogBreeds.Property(p => p.FamilyFriendly).HasDefaultValue(0);
            DogBreeds.Property(p => p.DogFriendly).HasDefaultValue(0);


        }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<OwnerDog> UsersDog { get; set; }
        public DbSet<DogBreed> DogBreeds { get; set; }
    }
}
