﻿//using Microsoft.EntityFrameworkCore.Migrations;

//namespace Final.Migrations
//{
//    public partial class price : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.AlterColumn<int>(
//                name: "Price",
//                table: "Products",
//                type: "int",
//                nullable: false,
//                oldClrType: typeof(string),
//                oldType: "nvarchar(max)");

//            migrationBuilder.AlterColumn<int>(
//                name: "Price",
//                table: "Baskets",
//                type: "int",
//                nullable: false,
//                defaultValue: 0,
//                oldClrType: typeof(string),
//                oldType: "nvarchar(max)",
//                oldNullable: true);
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.AlterColumn<string>(
//                name: "Price",
//                table: "Products",
//                type: "nvarchar(max)",
//                nullable: false,
//                oldClrType: typeof(int),
//                oldType: "int");

//            migrationBuilder.AlterColumn<string>(
//                name: "Price",
//                table: "Baskets",
//                type: "nvarchar(max)",
//                nullable: true,
//                oldClrType: typeof(int),
//                oldType: "int");
//        }
//    }
//}
