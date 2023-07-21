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
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(nameof(UserEntity.UserId));

            builder.Property(user => user.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion<string>();

            builder.Property(user => user.DateRegister)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasConversion<DateTime>();

            builder.Property(user => user.Status)
                .IsRequired()
                .HasDefaultValue(EntityStatus.Active)
                .HasConversion<byte>();
        }
    }
}
