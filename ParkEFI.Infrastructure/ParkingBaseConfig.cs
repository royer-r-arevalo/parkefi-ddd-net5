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
    public class ParkingBaseConfig : IEntityTypeConfiguration<ParkingBaseEntity>
    {
        public void Configure(EntityTypeBuilder<ParkingBaseEntity> builder)
        {
            builder.ToTable("ParkingBase");

            builder.HasKey(nameof(ParkingBaseEntity.Id));

            builder.Property(parking => parking.Description)
                .HasMaxLength(255)
                .HasConversion<string>();

            builder.Property(parking => parking.PostalCode)
                .HasMaxLength(100)
                .HasConversion<string>();

            builder.Property(parking => parking.ParkingType)
                .IsRequired()
                .HasConversion<byte>();

            builder.Property(parking => parking.Status)
                .IsRequired()
                .HasDefaultValue(EntityStatus.Active)
                .HasConversion<byte>();

            builder.Property(parking => parking.DateRegister)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasConversion<DateTime>();

            builder.Property(parking => parking.Description)
                .HasMaxLength(255)
                .HasConversion<string>();

            builder.HasOne(parking => parking.Country)
                .WithMany(country => country.Parkings);

            builder.HasOne(parking => parking.City)
                .WithMany(city => city.Parkings);

            builder.HasOne(parking => parking.Province)
                .WithMany(province => province.Parkings);
        }
    }
}
