using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkEFI.Infrastructure.Migrations
{
    public partial class CreatetablesCompaniesCoordinatesGaragesParkingBaseParkingsStreets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 390, DateTimeKind.Local).AddTicks(417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 403, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Provinces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 388, DateTimeKind.Local).AddTicks(3040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 402, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 385, DateTimeKind.Local).AddTicks(4352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 388, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.AddColumn<byte>(
                name: "ParkingOwnerType",
                schema: "ParkEFI",
                table: "ParkingOwners",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 346, DateTimeKind.Local).AddTicks(9660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 385, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 328, DateTimeKind.Local).AddTicks(592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 372, DateTimeKind.Local).AddTicks(194));

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "ParkEFI",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 338, DateTimeKind.Local).AddTicks(8362)),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CompanyOwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_ParkingOwners_CompanyOwnerId",
                        column: x => x.CompanyOwnerId,
                        principalSchema: "ParkEFI",
                        principalTable: "ParkingOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                schema: "ParkEFI",
                columns: table => new
                {
                    CoordinateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    CoordinateType = table.Column<byte>(type: "tinyint", nullable: false),
                    CoordinatePointType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.CoordinateId);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                schema: "ParkEFI",
                columns: table => new
                {
                    StreetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoogleStreetId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.StreetId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingBase",
                schema: "ParkEFI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParkingType = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 355, DateTimeKind.Local).AddTicks(1156)),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    CoordinateOfParkingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingBase_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "ParkEFI",
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingBase_Coordinates_CoordinateOfParkingId",
                        column: x => x.CoordinateOfParkingId,
                        principalSchema: "ParkEFI",
                        principalTable: "Coordinates",
                        principalColumn: "CoordinateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingBase_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "ParkEFI",
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParkingBase_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "ParkEFI",
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                schema: "ParkEFI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ElectricityBill = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GarageOwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garages_GarageOwners_GarageOwnerId",
                        column: x => x.GarageOwnerId,
                        principalSchema: "ParkEFI",
                        principalTable: "GarageOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Garages_ParkingBase_Id",
                        column: x => x.Id,
                        principalSchema: "ParkEFI",
                        principalTable: "ParkingBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingBaseStreets",
                schema: "ParkEFI",
                columns: table => new
                {
                    ParkingStreetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingBaseId = table.Column<int>(type: "int", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingBaseStreets", x => x.ParkingStreetId);
                    table.ForeignKey(
                        name: "FK_ParkingBaseStreets_ParkingBase_ParkingBaseId",
                        column: x => x.ParkingBaseId,
                        principalSchema: "ParkEFI",
                        principalTable: "ParkingBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingBaseStreets_Streets_StreetId",
                        column: x => x.StreetId,
                        principalSchema: "ParkEFI",
                        principalTable: "Streets",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                schema: "ParkEFI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InfraestructureType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    ParkingOwnerId = table.Column<int>(type: "int", nullable: true),
                    CompanyEntityCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parkings_Companies_CompanyEntityCompanyId",
                        column: x => x.CompanyEntityCompanyId,
                        principalSchema: "ParkEFI",
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parkings_ParkingBase_Id",
                        column: x => x.Id,
                        principalSchema: "ParkEFI",
                        principalTable: "ParkingBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parkings_ParkingOwners_ParkingOwnerId",
                        column: x => x.ParkingOwnerId,
                        principalSchema: "ParkEFI",
                        principalTable: "ParkingOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyOwnerId",
                schema: "ParkEFI",
                table: "Companies",
                column: "CompanyOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_GarageOwnerId",
                schema: "ParkEFI",
                table: "Garages",
                column: "GarageOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingBase_CityId",
                schema: "ParkEFI",
                table: "ParkingBase",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingBase_CoordinateOfParkingId",
                schema: "ParkEFI",
                table: "ParkingBase",
                column: "CoordinateOfParkingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingBase_CountryId",
                schema: "ParkEFI",
                table: "ParkingBase",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingBase_ProvinceId",
                schema: "ParkEFI",
                table: "ParkingBase",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingBaseStreets_ParkingBaseId",
                schema: "ParkEFI",
                table: "ParkingBaseStreets",
                column: "ParkingBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingBaseStreets_StreetId",
                schema: "ParkEFI",
                table: "ParkingBaseStreets",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_CompanyEntityCompanyId",
                schema: "ParkEFI",
                table: "Parkings",
                column: "CompanyEntityCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_ParkingOwnerId",
                schema: "ParkEFI",
                table: "Parkings",
                column: "ParkingOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garages",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "ParkingBaseStreets",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Parkings",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Streets",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "ParkingBase",
                schema: "ParkEFI");

            migrationBuilder.DropTable(
                name: "Coordinates",
                schema: "ParkEFI");

            migrationBuilder.DropColumn(
                name: "ParkingOwnerType",
                schema: "ParkEFI",
                table: "ParkingOwners");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 403, DateTimeKind.Local).AddTicks(6153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 390, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Provinces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 402, DateTimeKind.Local).AddTicks(7123),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 388, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 388, DateTimeKind.Local).AddTicks(9031),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 385, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 385, DateTimeKind.Local).AddTicks(2336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 346, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                schema: "ParkEFI",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 24, 18, 18, 5, 372, DateTimeKind.Local).AddTicks(194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 13, 0, 33, 47, 328, DateTimeKind.Local).AddTicks(592));
        }
    }
}
