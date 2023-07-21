using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkEFI.Domain.Entities;
using ParkEFI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Infrastructure
{
    public class ParkingOwnerConfig : IEntityTypeConfiguration<ParkingOwnerEntity>
    {
        public void Configure(EntityTypeBuilder<ParkingOwnerEntity> builder)
        {
            builder.ToTable("ParkingOwners");

            builder.Property(owner => owner.ParkingOwnerType)
                .IsRequired()
                .HasDefaultValue(ParkingOwnerTypes.ParkingOwner)
                .HasConversion<byte>();

            builder.HasMany(owner => owner.Companies)
                .WithOne(company => company.CompanyOwner);

            builder.HasMany(owner => owner.Parkings)
                .WithOne(parking => parking.ParkingOwner);
        }
    }
}
