using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyFastFoodSimpleApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTableWithCalories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCaloriesConsumed",
                table: "UserLogins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCaloriesGoal",
                table: "UserLogins",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCaloriesConsumed",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UserCaloriesGoal",
                table: "UserLogins");
        }
    }
}
