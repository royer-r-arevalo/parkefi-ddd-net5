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
    public class PersonConfig : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("Persons");

            builder.HasKey(nameof(PersonEntity.Id));

            builder.Property(person => person.Names)
                .IsRequired()
                .HasMaxLength(150)
                .HasConversion<string>();

            builder.Property(person => person.FirstSurname)
                .IsRequired()
                .HasMaxLength(100)
                .HasConversion<string>();

            builder.Property(person => person.SecondSurname)
                .HasMaxLength(100)
                .HasConversion<string>();

            builder.Property(person => person.BirthDate)
                .IsRequired()
                .HasConversion<DateTime>();

            builder.Property(person => person.Email)
                .HasMaxLength(50)
                .HasConversion<string>();

            builder.Property(person => person.PhoneNumber)
                .HasMaxLength(20)
                .HasConversion<string>();

            builder.Property(person => person.Cedula)
                .IsRequired()
                .HasMaxLength(15)
                .HasConversion<string>();

            builder.Property(person => person.Gender)
                .IsRequired()
                .HasMaxLength(20)
                .HasConversion<byte>();

            builder.Property(person => person.Persontype)
                .IsRequired()
                .HasMaxLength(20)
                .HasConversion<byte>();

            builder.Property(person => person.Status)
                .IsRequired()
                .HasDefaultValue(EntityStatus.Active)
                .HasConversion<byte>();

            builder.Property(person => person.DateRegister)
                .IsRequired()
                .HasDefaultValue(DateTime.Now)
                .HasConversion<DateTime>();

            builder.HasOne(person => person.User)
                .WithOne(user => user.Person)
                .HasForeignKey<UserEntity>(user => user.PersonOfUserId);
        }
    }
}
