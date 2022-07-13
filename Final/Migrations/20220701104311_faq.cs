using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class faq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Blogs_BlogId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_FaqCategories_FaqCategoryId",
                table: "Faqs");

            migrationBuilder.DropTable(
                name: "FaqCategories");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_FaqCategoryId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_BlogId",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "FaqCategoryId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogComments");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Faqs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Faqs");

            migrationBuilder.AddColumn<int>(
                name: "FaqCategoryId",
                table: "Faqs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "BlogComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FaqCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_FaqCategoryId",
                table: "Faqs",
                column: "FaqCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogId",
                table: "BlogComments",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Blogs_BlogId",
                table: "BlogComments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_FaqCategories_FaqCategoryId",
                table: "Faqs",
                column: "FaqCategoryId",
                principalTable: "FaqCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
