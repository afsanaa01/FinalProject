using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class ends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Solds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Solds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
