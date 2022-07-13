using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class solditems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solds_AspNetUsers_AppUserId",
                table: "Solds");

            migrationBuilder.DropIndex(
                name: "IX_Solds_AppUserId",
                table: "Solds");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Solds");

            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "Solds");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Solds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoldItemId",
                table: "Solds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "BillingAddresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SoldItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoldItems_BillingAddresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "BillingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solds_ProductId",
                table: "Solds",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Solds_SoldItemId",
                table: "Solds",
                column: "SoldItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_AppUserId",
                table: "BillingAddresses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldItems_AppUserId",
                table: "SoldItems",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldItems_BillingAddressId",
                table: "SoldItems",
                column: "BillingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddresses_AspNetUsers_AppUserId",
                table: "BillingAddresses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solds_Products_ProductId",
                table: "Solds",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Solds_SoldItems_SoldItemId",
                table: "Solds",
                column: "SoldItemId",
                principalTable: "SoldItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingAddresses_AspNetUsers_AppUserId",
                table: "BillingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Solds_Products_ProductId",
                table: "Solds");

            migrationBuilder.DropForeignKey(
                name: "FK_Solds_SoldItems_SoldItemId",
                table: "Solds");

            migrationBuilder.DropTable(
                name: "SoldItems");

            migrationBuilder.DropIndex(
                name: "IX_Solds_ProductId",
                table: "Solds");

            migrationBuilder.DropIndex(
                name: "IX_Solds_SoldItemId",
                table: "Solds");

            migrationBuilder.DropIndex(
                name: "IX_BillingAddresses_AppUserId",
                table: "BillingAddresses");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Solds");

            migrationBuilder.DropColumn(
                name: "SoldItemId",
                table: "Solds");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BillingAddresses");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Solds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "Solds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solds_AppUserId",
                table: "Solds",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solds_AspNetUsers_AppUserId",
                table: "Solds",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
