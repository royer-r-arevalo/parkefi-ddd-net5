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
    public class ParkingConfig : IEntityTypeConfiguration<ParkingEntity>
    {
        public void Configure(EntityTypeBuilder<ParkingEntity> builder)
        {
            builder.ToTable("Parkings");

            builder.Property(parking => parking.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasConversion<string>();

            builder.Property(parking => parking.InfraestructureType)
                .IsRequired()
                .HasDefaultValue(InfraestructureTypes.Lot)
                .HasConversion<byte>();
        }
    }
}
