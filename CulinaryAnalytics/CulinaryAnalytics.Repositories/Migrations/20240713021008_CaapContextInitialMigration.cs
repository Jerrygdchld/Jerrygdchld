using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CulinaryAnalytics.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class CaapContextInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.CreateTable(
                name: "DictionaryLists",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_DictionaryLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryListItems",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictionaryListId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_DictionaryListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictionaryListItems_DictionaryLists_DictionaryListId",
                        column: x => x.DictionaryListId,
                        principalSchema: "Common",
                        principalTable: "DictionaryLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "DictionaryLists",
                columns: new[] { "Id", "Active", "Creator", "DateCreated", "DateDeleted", "Deleted", "Deletor", "Description", "ExternalId", "LookupCode", "Name", "Updator" },
                values: new object[,]
                {
                    { 1L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(5499), null, false, null, "States", "", "STATES", "States", null },
                    { 2L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(5584), null, false, null, "Units of Measure", "", "UOM", "Units of Measure", null },
                    { 3L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(5587), null, false, null, "Ingredient Types", "", "INGREDIENTTYPES", "Ingredient Types", null }
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "DictionaryListItems",
                columns: new[] { "Id", "Active", "Creator", "DateCreated", "DateDeleted", "Deleted", "Deletor", "Description", "DictionaryListId", "ExternalId", "LookupCode", "Name", "Updator" },
                values: new object[,]
                {
                    { 1L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9044), null, false, null, "", 1L, "AL", "AL", "Alabama", null },
                    { 2L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9061), null, false, null, "", 1L, "AK", "AK", "Alaska", null },
                    { 3L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9064), null, false, null, "", 1L, "AZ", "AZ", "Arizona", null },
                    { 4L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9066), null, false, null, "", 1L, "AR", "AR", "Arkansas", null },
                    { 5L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9068), null, false, null, "", 1L, "CA", "CA", "California", null },
                    { 6L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9097), null, false, null, "", 1L, "CZ", "CZ", "Canal Zone", null },
                    { 7L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9100), null, false, null, "", 1L, "CO", "CO", "Colorado", null },
                    { 8L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9102), null, false, null, "", 1L, "CT", "CT", "Connecticut", null },
                    { 9L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9104), null, false, null, "", 1L, "DE", "DE", "Delaware", null },
                    { 10L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9106), null, false, null, "", 1L, "DC", "DC", "District of Columbia", null },
                    { 11L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9108), null, false, null, "", 1L, "FL", "FL", "Florida", null },
                    { 12L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9110), null, false, null, "", 1L, "GA", "GA", "Georgia", null },
                    { 13L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9112), null, false, null, "", 1L, "GU", "GU", "Guam", null },
                    { 14L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9114), null, false, null, "", 1L, "HI", "HI", "Hawaii", null },
                    { 15L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9116), null, false, null, "", 1L, "ID", "ID", "Idaho", null },
                    { 16L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9118), null, false, null, "", 1L, "IL", "IL", "Illinois", null },
                    { 17L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9119), null, false, null, "", 1L, "IN", "IN", "Indiana", null },
                    { 18L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9122), null, false, null, "", 1L, "IA", "IA", "Iowa", null },
                    { 19L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9124), null, false, null, "", 1L, "KS", "KS", "Kansas", null },
                    { 20L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9126), null, false, null, "", 1L, "KY", "KY", "Kentucky", null },
                    { 21L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9128), null, false, null, "", 1L, "LA", "LA", "Louisiana", null },
                    { 22L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9129), null, false, null, "", 1L, "ME", "ME", "Maine", null },
                    { 23L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9131), null, false, null, "", 1L, "MD", "MD", "Maryland", null },
                    { 24L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9133), null, false, null, "", 1L, "MA", "MA", "Massachusetts", null },
                    { 25L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9135), null, false, null, "", 1L, "MI", "MI", "Michigan", null },
                    { 26L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9137), null, false, null, "", 1L, "MN", "MN", "Minnesota", null },
                    { 27L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9139), null, false, null, "", 1L, "MS", "MS", "Mississippi", null },
                    { 28L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9141), null, false, null, "", 1L, "MO", "MO", "Missouri", null },
                    { 29L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9143), null, false, null, "", 1L, "MT", "MT", "Montana", null },
                    { 30L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9145), null, false, null, "", 1L, "NE", "NE", "Nebraska", null },
                    { 31L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9146), null, false, null, "", 1L, "NV", "NV", "Nevada", null },
                    { 32L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9148), null, false, null, "", 1L, "NH", "NH", "New Hampshire", null },
                    { 33L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9150), null, false, null, "", 1L, "NJ", "NJ", "New Jersey", null },
                    { 34L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9153), null, false, null, "", 1L, "NM", "NM", "New Mexico", null },
                    { 35L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9155), null, false, null, "", 1L, "NY", "NY", "New York", null },
                    { 36L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9156), null, false, null, "", 1L, "NC", "NC", "North Carolina", null },
                    { 37L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9158), null, false, null, "", 1L, "ND", "ND", "North Dakota", null },
                    { 38L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9160), null, false, null, "", 1L, "OH", "OH", "Ohio", null },
                    { 39L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9162), null, false, null, "", 1L, "OK", "OK", "Oklahoma", null },
                    { 40L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9164), null, false, null, "", 1L, "OR", "OR", "Oregon", null },
                    { 41L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9166), null, false, null, "", 1L, "PA", "PA", "Pennsylvania", null },
                    { 42L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9168), null, false, null, "", 1L, "PR", "PR", "Puerto Rico", null },
                    { 43L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9170), null, false, null, "", 1L, "RI", "RI", "Rhode Island", null },
                    { 44L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9171), null, false, null, "", 1L, "SC", "SC", "South Carolina", null },
                    { 45L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9173), null, false, null, "", 1L, "SD", "SD", "South Dakota", null },
                    { 46L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9175), null, false, null, "", 1L, "TN", "TN", "Tennessee", null },
                    { 47L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9177), null, false, null, "", 1L, "TX", "TX", "Texas", null },
                    { 48L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9179), null, false, null, "", 1L, "UT", "UT", "Utah", null },
                    { 49L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9180), null, false, null, "", 1L, "VT", "VT", "Vermont", null },
                    { 50L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9182), null, false, null, "", 1L, "VI", "VI", "Virgin Islands", null },
                    { 51L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9184), null, false, null, "", 1L, "VA", "VA", "Virginia", null },
                    { 52L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9186), null, false, null, "", 1L, "WA", "WA", "Washington", null },
                    { 53L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9188), null, false, null, "", 1L, "WV", "WV", "West Virginia", null },
                    { 54L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9190), null, false, null, "", 1L, "WI", "WI", "Wisconsin", null },
                    { 55L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9192), null, false, null, "", 1L, "WY", "WY", "Wyoming", null },
                    { 56L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9194), null, false, null, "Milligram", 2L, "", "mg", "Milligram", null },
                    { 57L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9195), null, false, null, "Gram", 2L, "", "g", "Gram", null },
                    { 58L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9197), null, false, null, "Kilogram", 2L, "", "kg", "Kilogram", null },
                    { 59L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9242), null, false, null, "Ounce", 2L, "", "oz", "Ounce", null },
                    { 60L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9245), null, false, null, "Pound", 2L, "", "lb", "Pound", null },
                    { 61L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9247), null, false, null, "Ton", 2L, "", "ton", "Ton", null },
                    { 62L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9248), null, false, null, "Cup", 2L, "", "cup", "Cup", null },
                    { 63L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9250), null, false, null, "Table Spoon", 2L, "", "ts", "Table Spoon", null },
                    { 64L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9252), null, false, null, "Unit", 2L, "", "unit", "Unit", null },
                    { 65L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9254), null, false, null, "Vegetable", 3L, "", "VEG", "Vegetable", null },
                    { 66L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9256), null, false, null, "Meat", 3L, "", "MEAT", "Meat", null },
                    { 67L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9258), null, false, null, "Herb", 3L, "", "HERB", "Herb", null },
                    { 68L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9260), null, false, null, "Fruit", 3L, "", "FRUIT", "Fruit", null },
                    { 69L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9262), null, false, null, "Grain", 3L, "", "GRAIN", "Grain", null },
                    { 70L, true, 9999, new DateTime(2024, 7, 12, 21, 10, 6, 892, DateTimeKind.Local).AddTicks(9264), null, false, null, "Spice", 3L, "", "SPICE", "Spice", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryListItems_DictionaryListId",
                schema: "Common",
                table: "DictionaryListItems",
                column: "DictionaryListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictionaryListItems",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "DictionaryLists",
                schema: "Common");
        }
    }
}
