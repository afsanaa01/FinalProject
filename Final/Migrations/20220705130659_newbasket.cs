using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class newbasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Baskets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
