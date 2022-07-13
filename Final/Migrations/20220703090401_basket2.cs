using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class basket2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "Baskets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
