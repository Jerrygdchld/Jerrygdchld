using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CulinaryAnalytics.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddingCommonSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CRM");

            migrationBuilder.CreateTable(
                name: "BusinessEntities",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AltPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BusinessEntityTypeId = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    Updator = table.Column<int>(type: "int", nullable: true),
                    Deletor = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    LookupCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessEntities_DictionaryListItems_BusinessEntityTypeId",
                        column: x => x.BusinessEntityTypeId,
                        principalSchema: "Common",
                        principalTable: "DictionaryListItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessEntityId = table.Column<long>(type: "bigint", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AltPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CompanyCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    Updator = table.Column<int>(type: "int", nullable: true),
                    Deletor = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    LookupCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_BusinessEntities_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalSchema: "CRM",
                        principalTable: "BusinessEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AltPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    Updator = table.Column<int>(type: "int", nullable: true),
                    Deletor = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "CRM",
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9811));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9845));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9847));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9854));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 16L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 17L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 18L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 19L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9868));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 20L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 21L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9872));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 22L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9901));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 23L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9904));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 24L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9906));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 25L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 26L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 27L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9912));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 28L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 29L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 30L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9918));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 31L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9920));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 32L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9922));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 33L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 34L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9926));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 35L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 36L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 37L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 38L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9934));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 39L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 40L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9938));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 41L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9940));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 42L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9942));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 43L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 44L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 45L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 46L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 47L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 48L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 49L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9956));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 50L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9958));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 51L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 52L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 53L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 54L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9966));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 55L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 56L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9970));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 57L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9972));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 58L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 59L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 60L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 61L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 62L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 63L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 64L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 65L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 66L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 67L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 68L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 69L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 70L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryLists",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryLists",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(6625));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryLists",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.InsertData(
                schema: "Common",
                table: "DictionaryLists",
                columns: new[] { "Id", "Active", "Creator", "DateCreated", "DateDeleted", "Deleted", "Deletor", "Description", "ExternalId", "LookupCode", "Name", "Updator" },
                values: new object[] { 4L, true, 9999, new DateTime(2024, 7, 13, 16, 41, 6, 587, DateTimeKind.Local).AddTicks(6630), null, false, null, "Business Entity Types", "", "BUSINESSENTITYTYPES", "Business Entity Types", null });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "DictionaryListItems",
                columns: new[] { "Id", "Active", "Creator", "DateCreated", "DateDeleted", "Deleted", "Deletor", "Description", "DictionaryListId", "ExternalId", "LookupCode", "Name", "Updator" },
                values: new object[,]
                {
                    { 71L, true, 9999, new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(25), null, false, null, "Restaurant", 4L, "", "RESTAURANT", "Restaurant", null },
                    { 72L, true, 9999, new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(27), null, false, null, "Supplier", 4L, "", "SUPPLIER", "Supplier", null },
                    { 73L, true, 9999, new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(29), null, false, null, "Corporate", 4L, "", "CORPORATE", "Corporate", null },
                    { 74L, true, 9999, new DateTime(2024, 7, 13, 16, 41, 6, 588, DateTimeKind.Local).AddTicks(31), null, false, null, "Reseller", 4L, "", "RESELLER", "Reseller", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntities_BusinessEntityTypeId",
                schema: "CRM",
                table: "BusinessEntities",
                column: "BusinessEntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BusinessEntityId",
                schema: "CRM",
                table: "Locations",
                column: "BusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_LocationId",
                schema: "CRM",
                table: "People",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "BusinessEntities",
                schema: "CRM");

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                schema: "Common",
                table: "DictionaryLists",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9061));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 5L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 6L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 7L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 8L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 9L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 10L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9106));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 11L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 12L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9110));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 13L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9112));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 14L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9114));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 15L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 16L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 17L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 18L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9122));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 19L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 20L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 21L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9128));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 22L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 23L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9131));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 24L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 25L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9135));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 26L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 27L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 28L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 29L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 30L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 31L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 32L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 33L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 34L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9153));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 35L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9155));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 36L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 37L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 38L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 39L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 40L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 41L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9166));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 42L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 43L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 44L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 45L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 46L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 47L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 48L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 49L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9180));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 50L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 51L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 52L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 53L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9188));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 54L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 55L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9192));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 56L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 57L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 58L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 59L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 60L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 61L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9247));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 62L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9248));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 63L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 64L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 65L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9254));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 66L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 67L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 68L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 69L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9262));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryListItems",
                keyColumn: "Id",
                keyValue: 70L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9264));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryLists",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(5499));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryLists",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(5584));

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "DictionaryLists",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(5587));
        }
    }
}
