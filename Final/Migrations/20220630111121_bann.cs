using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class bann : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BannerImage",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BannerImage",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
