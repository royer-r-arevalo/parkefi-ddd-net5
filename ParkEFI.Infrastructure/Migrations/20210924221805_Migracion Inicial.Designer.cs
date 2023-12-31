﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkEFI.Infrastructure;

namespace ParkEFI.Infrastructure.Migrations
{
    [DbContext(typeof(ParkEFIDbContext))]
    [Migration("20210924221805_Migracion Inicial")]
    partial class MigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ParkEFI")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkEFI.Domain.Entities.CityEntity", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegister")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 9, 24, 18, 18, 5, 372, DateTimeKind.Local).AddTicks(194));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.CountryEntity", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegister")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 9, 24, 18, 18, 5, 385, DateTimeKind.Local).AddTicks(2336));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DateRegister")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 9, 24, 18, 18, 5, 388, DateTimeKind.Local).AddTicks(9031));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstSurname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Gender")
                        .HasMaxLength(20)
                        .HasColumnType("tinyint");

                    b.Property<string>("Names")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte>("Persontype")
                        .HasMaxLength(20)
                        .HasColumnType("tinyint");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SecondSurname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.ProvinceEntity", b =>
                {
                    b.Property<int>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegister")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 9, 24, 18, 18, 5, 402, DateTimeKind.Local).AddTicks(7123));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

                    b.HasKey("ProvinceId");

                    b.HasIndex("CityId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegister")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 9, 24, 18, 18, 5, 403, DateTimeKind.Local).AddTicks(6153));

                    b.Property<int>("PersonOfUserId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("PersonOfUserId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.GarageOwnerEntity", b =>
                {
                    b.HasBaseType("ParkEFI.Domain.Entities.PersonEntity");

                    b.ToTable("GarageOwners");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.ParkingOwnerEntity", b =>
                {
                    b.HasBaseType("ParkEFI.Domain.Entities.PersonEntity");

                    b.ToTable("ParkingOwners");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.CityEntity", b =>
                {
                    b.HasOne("ParkEFI.Domain.Entities.CountryEntity", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.ProvinceEntity", b =>
                {
                    b.HasOne("ParkEFI.Domain.Entities.CityEntity", "City")
                        .WithMany("Provinces")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("ParkEFI.Domain.Entities.PersonEntity", "Person")
                        .WithOne("User")
                        .HasForeignKey("ParkEFI.Domain.Entities.UserEntity", "PersonOfUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.GarageOwnerEntity", b =>
                {
                    b.HasOne("ParkEFI.Domain.Entities.PersonEntity", null)
                        .WithOne()
                        .HasForeignKey("ParkEFI.Domain.Entities.GarageOwnerEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.ParkingOwnerEntity", b =>
                {
                    b.HasOne("ParkEFI.Domain.Entities.PersonEntity", null)
                        .WithOne()
                        .HasForeignKey("ParkEFI.Domain.Entities.ParkingOwnerEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.CityEntity", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.CountryEntity", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("ParkEFI.Domain.Entities.PersonEntity", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
