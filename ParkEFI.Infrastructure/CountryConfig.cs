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
    public class CountryConfig : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(nameof(CountryEntity.CountryId));

            builder.Property(country => country.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion<string>();

            builder.Property(country => country.DateRegister)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasConversion<DateTime>();

            builder.Property(country => country.Status)
                .IsRequired()
                .HasDefaultValue(EntityStatus.Active)
                .HasConversion<byte>();

            builder.HasMany(country => country.Cities)
                .WithOne(city => city.Country)
                .IsRequired();
        }
    }
}
