using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkEFI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEFI.Infrastructure
{
    public class PointConfig : IEntityTypeConfiguration<PointEntity>
    {
        public void Configure(EntityTypeBuilder<PointEntity> builder)
        {
            builder.ToTable("Points");

            builder.HasKey(nameof(PointEntity.PointId));

            builder.Property(point => point.Latitude)
                .IsRequired()
                .HasConversion<decimal>()
                .HasPrecision(15, 2);

            builder.Property(point => point.Longitude)
                .IsRequired()
                .HasConversion<decimal>()
                .HasPrecision(15, 2);

            builder.HasOne(point => point.ParkingBase)
                .WithOne(parking => parking.Point)
                .HasForeignKey<PointEntity>(point => point.ParkingBaseId);
        }
    }
}
