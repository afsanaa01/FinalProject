using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldItems_BillingAddresses_BillingAddressId",
                table: "SoldItems");

            migrationBuilder.DropIndex(
                name: "IX_SoldItems_BillingAddressId",
                table: "SoldItems");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "SoldItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "SoldItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoldItems_BillingAddressId",
                table: "SoldItems",
                column: "BillingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldItems_BillingAddresses_BillingAddressId",
                table: "SoldItems",
                column: "BillingAddressId",
                principalTable: "BillingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
