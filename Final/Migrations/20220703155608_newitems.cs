using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class newitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solds_SoldItems_SoldItemId",
                table: "Solds");

            migrationBuilder.DropTable(
                name: "SoldItems");

            migrationBuilder.DropIndex(
                name: "IX_Solds_SoldItemId",
                table: "Solds");

            migrationBuilder.DropColumn(
                name: "SoldItemId",
                table: "Solds");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Solds",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Solds",
                type: "nvarchar(450)",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Solds",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<int>(
                name: "SoldItemId",
                table: "Solds",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Solds_SoldItemId",
                table: "Solds",
                column: "SoldItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldItems_AppUserId",
                table: "SoldItems",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldItems_BillingAddressId",
                table: "SoldItems",
                column: "BillingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solds_SoldItems_SoldItemId",
                table: "Solds",
                column: "SoldItemId",
                principalTable: "SoldItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
