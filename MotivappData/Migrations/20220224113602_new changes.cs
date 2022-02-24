using Microsoft.EntityFrameworkCore.Migrations;

namespace MotivappData.Migrations
{
    public partial class newchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeededPoints",
                table: "Categories",
                nullable: false,
                defaultValue: 0);            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeededPoints",
                table: "Categories");
        }
    }
}
