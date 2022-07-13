using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class wishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "Wishs");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Wishs");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Wishs");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Wishs");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Wishs");

            migrationBuilder.DropColumn(
                name: "Store",
                table: "Wishs");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Wishs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Wishs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Wishs_ProductId",
                table: "Wishs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishs_Products_ProductId",
                table: "Wishs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishs_Products_ProductId",
                table: "Wishs");

            migrationBuilder.DropIndex(
                name: "IX_Wishs_ProductId",
                table: "Wishs");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Wishs");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Wishs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "Wishs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDate",
                table: "Wishs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Wishs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Wishs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Wishs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Store",
                table: "Wishs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
