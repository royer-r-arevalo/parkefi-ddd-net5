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
    public class GarageConfig : IEntityTypeConfiguration<GarageEntity>
    {
        public void Configure(EntityTypeBuilder<GarageEntity> builder)
        {
            builder.ToTable("Garages");

            builder.Property(garage => garage.ElectricityBill)
                .HasMaxLength(100)
                .HasConversion<string>();
        }
    }
}
