using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkEFI.Infrastructure.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ParkEFI");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "ParkEFI",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 385, DateTimeKind.Local).AddTicks(2336))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "ParkEFI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", maxLength: 20, nullable: false),
                    Persontype = table.Column<byte>(type: "tinyint", maxLength: 20, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 388, DateTimeKind.Local).AddTicks(9031))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "ParkEFI",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 372, DateTimeKind.Local).AddTicks(194)),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "ParkEFI",
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarageOwners",
                schema: "ParkEFI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GarageOwners_Persons_Id",
                        column: x => x.Id,
                        principalSchema: "ParkEFI",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingOwners",
                schema: "ParkEFI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingOwners_Persons_Id",
                        column: x => x.Id,
                        principalSchema: "ParkEFI",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "ParkEFI",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 403, DateTimeKind.Local).AddTicks(6153)),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    PersonOfUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonOfUserId",
                        column: x => x.PersonOfUserId,
                        principalSchema: "ParkEFI",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "ParkEFI",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 402, DateTimeKind.Local).AddTicks(7123)),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK_Provinces_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "ParkEFI",
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                schema: "ParkEFI",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CityId",
                schema: "ParkEFI",
                table: "Provinces",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonOfUserId",
                schema: "ParkEFI",
                table: "Users",
                column: "PersonOfUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GarageOwners",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "ParkingOwners",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "ParkEFI");
        }
    }
}
