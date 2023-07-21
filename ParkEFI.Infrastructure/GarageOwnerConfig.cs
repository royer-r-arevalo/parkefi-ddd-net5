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
    public class GarageOwnerConfig : IEntityTypeConfiguration<GarageOwnerEntity>
    {
        public void Configure(EntityTypeBuilder<GarageOwnerEntity> builder)
        {
            builder.ToTable("GarageOwners");

            builder.HasMany(owner => owner.Garages)
                .WithOne(garage => garage.GarageOwner)
                .IsRequired();
        }
    }
}
