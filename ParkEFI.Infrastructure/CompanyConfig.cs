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
    public class CompanyConfig : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(nameof(CompanyEntity.CompanyId));

            builder.Property(comp => comp.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasConversion<string>();

            builder.Property(comp => comp.Nit)
                .IsRequired()
                .HasMaxLength(20)
                .HasConversion<string>();

            builder.Property(comp => comp.DateRegister)
               .IsRequired()
               .HasDefaultValue(DateTime.Now)
               .HasConversion<DateTime>();

            builder.Property(comp => comp.Status)
                .IsRequired()
                .HasDefaultValue(EntityStatus.Active)
                .HasConversion<byte>();

            builder.HasMany(comp => comp.Parkings)
                .WithOne(parking => parking.Company);
        }
    }
}
