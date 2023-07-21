using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParkEFI.Domain.Entities;

namespace ParkEFI.Infrastructure
{
    public interface IParkEFIDbContext
    {
        Task<bool> CanConnectAsync();
    }

    public class ParkEFIDbContext : DbContext, IParkEFIDbContext
    {
        public const string SCHEMA = "ParkEFI";

        public ParkEFIDbContext(DbContextOptions<ParkEFIDbContext> options) : base (options)
        {
        }

        public async Task<bool> CanConnectAsync() => await Database.CanConnectAsync();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ParkEFIDbContext).Assembly);
            builder.HasDefaultSchema(SCHEMA);
        }

        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<ProvinceEntity> Provinces { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<GarageOwnerEntity> GarageOwners { get; set; }
        public DbSet<ParkingOwnerEntity> ParkingOwners { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ParkingEntity> Parkings { get; set; }
        public DbSet<PointEntity> Points { get; set; }
    }
}
