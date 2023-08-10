using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyFastFoodSimpleApi.Migrations
{
    /// <inheritdoc />
    public partial class Dailyintake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyCaloricIntakeEntry",
                columns: table => new
                {
                    DailyCaloricIntakeEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaloriesConsumed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyCaloricIntakeEntry", x => x.DailyCaloricIntakeEntryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyCaloricIntakeEntry");
        }
    }
}
