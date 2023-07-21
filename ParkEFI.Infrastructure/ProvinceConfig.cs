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
    public class ProvinceConfig : IEntityTypeConfiguration<ProvinceEntity>
    {
        public void Configure(EntityTypeBuilder<ProvinceEntity> builder)
        {
            builder.ToTable("Provinces");

            builder.HasKey(nameof(ProvinceEntity.ProvinceId));

            builder.Property(province => province.Name)
             .IsRequired()
             .HasMaxLength(50)
             .HasConversion<string>();

            builder.Property(province => province.DateRegister)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasConversion<DateTime>();

            builder.Property(province => province.Status)
                .IsRequired()
                .HasDefaultValue(EntityStatus.Active)
                .HasConversion<byte>();
        }
    }
}
