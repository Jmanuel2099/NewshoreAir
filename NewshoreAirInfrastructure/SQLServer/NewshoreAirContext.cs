using Microsoft.EntityFrameworkCore;
using NewshoreAirInfrastructure.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirInfrastructure.SQLServer
{
    public class NewshoreAirContext : DbContext
    {
        //public NewshoreAirContext(DbContextOptions<NewshoreAirContext> options)
        //    : base(options) { }
        public NewshoreAirContext() { }

        public DbSet<TransportModel> Transports { get; set; }
        public DbSet<FlightModel> Flights { get; set; }
        public DbSet<JourneyModel> Journeys { get; set; }
        public DbSet<JourneyFlightModel> JourneyFlights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransportModel>().ToTable("Transport");
            modelBuilder.Entity<FlightModel>().ToTable("Flight");
            modelBuilder.Entity<JourneyModel>().ToTable("Journey");
            modelBuilder.Entity<JourneyFlightModel>().ToTable("JourneyFlight");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Jose0920\\SQLEXPRESS;DataBase=NewshoreAir;Trusted_Connection=True;MultipleActiveResultSets=True; TrustServerCertificate=True;");
        }
    }
}
