using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class sold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Wishs",
                newName: "DeliveryDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Solds",
                newName: "DeliveryDate");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Wishs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "Wishs",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "IX_Wishs_AppUserId",
                table: "Wishs",
                column: "AppUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Wishs_AspNetUsers_AppUserId",
                table: "Wishs",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Wishs_AspNetUsers_AppUserId",
                table: "Wishs");

            migrationBuilder.DropIndex(
                name: "IX_Wishs_AppUserId",
                table: "Wishs");

            migrationBuilder.DropIndex(
                name: "IX_Solds_AppUserId",
                table: "Solds");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Wishs");

            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "Wishs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Solds");

            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "Solds");

            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "Wishs",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "Solds",
                newName: "Date");
        }
    }
}
