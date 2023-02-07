using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace supernaturalsightings_olivia.Migrations
{
    public partial class ReviewMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Reviews");
        }
    }
}
