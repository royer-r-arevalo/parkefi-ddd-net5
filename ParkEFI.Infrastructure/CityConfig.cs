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
    public class CityConfig : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(nameof(CityEntity.CityId));

            builder.Property(city => city.Name)
               .IsRequired()
               .HasMaxLength(50)
               .HasConversion<string>();

            builder.Property(city => city.DateRegister)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasConversion<DateTime>();

            builder.Property(city => city.Status)
                .IsRequired()
                .HasDefaultValue(EntityStatus.Active)
                .HasConversion<byte>();

            builder.HasMany(city => city.Provinces)
                .WithOne(province => province.City)
                .IsRequired();
        }
    }
}
