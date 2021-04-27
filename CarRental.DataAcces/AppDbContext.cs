using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRental.DataAcces
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().
                HasMany(c => c.Rentals).
                WithOne(r => r.Client);

            modelBuilder.Entity<Vehicle>().
                HasMany(v => v.Rentals).
                WithOne(r => r.Vehicle);

            modelBuilder.Entity<Rental>().
                HasOne(r => r.Client).
                WithMany(c => c.Rentals);

            modelBuilder.Entity<Rental>().
                HasOne(r => r.Vehicle).
                WithMany(v => v.Rentals);

            // I Can't use this metod because of unit tests

            //modelBuilder.Entity<Client>().HasData(
            //    new Client { Id = 1, Name = "Andres", LastName = "Jimenez" },
            //    new Client { Id = 2, Name = "Ivan", LastName = "Martinez" },
            //    new Client { Id = 3, Name = "Juan", LastName = "Ramirez" }
            //);

            //modelBuilder.Entity<Vehicle>().HasData(
            //    new Vehicle { Id = 1, Description = "Ford Fiesta", PricePerDay = 20 },
            //    new Vehicle { Id = 2, Description = "Ford Focus", PricePerDay = 25 },
            //    new Vehicle { Id = 3, Description = "Ford Mustang", PricePerDay = 50 },
            //    new Vehicle { Id = 4, Description = "VW Golf", PricePerDay = 25 }
            //);

            //modelBuilder.Entity<Rental>().HasData(

            //    new Rental
            //    {
            //        Id = 1,
            //        ClientId = 1,
            //        VehicleId = 2,
            //        StartDate = new DateTime(2021, 04, 01),
            //        EndDate = new DateTime(2021, 04, 10)
            //    },
            //    new Rental
            //    {
            //        Id = 2,
            //        ClientId = 2,
            //        VehicleId = 1,
            //        StartDate = new DateTime(2021, 04, 05),
            //        EndDate = new DateTime(2021, 04, 10)
            //    },
            //    new Rental
            //    {
            //        Id = 3,
            //        ClientId = 1,
            //        VehicleId = 2,
            //        StartDate = new DateTime(2021, 05, 01),
            //        EndDate = new DateTime(2021, 05, 10)
            //    },
            //    new Rental
            //    {
            //        Id = 4,
            //        ClientId = 3,
            //        VehicleId = 4,
            //        StartDate = new DateTime(2021, 04, 05),
            //        EndDate = new DateTime(2021, 04, 15)
            //    }
            //);

        }
    }
}