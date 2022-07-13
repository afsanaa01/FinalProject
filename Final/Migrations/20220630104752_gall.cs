using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class gall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceGalleries");

            migrationBuilder.AddColumn<string>(
                name: "Gallery1",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gallery2",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gallery3",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gallery1",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Gallery2",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Gallery3",
                table: "Services");

            migrationBuilder.CreateTable(
                name: "ServiceGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceGalleries", x => x.Id);
                });
        }
    }
}
