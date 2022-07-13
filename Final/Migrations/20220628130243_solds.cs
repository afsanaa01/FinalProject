using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class solds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Solds",
                newName: "TotalPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Solds",
                newName: "Price");
        }
    }
}
