using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class soldaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Baskets");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Solds",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Solds");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
