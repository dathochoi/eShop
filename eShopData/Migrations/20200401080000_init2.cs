using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopData.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShownOnHome",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "Categories",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "AppConfigs",
                newName: "Value");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 1, 14, 59, 59, 895, DateTimeKind.Local).AddTicks(9447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 1, 14, 45, 21, 173, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.AddColumn<bool>(
                name: "IsShowOnHome",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowOnHome",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Categories",
                newName: "ParentID");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "AppConfigs",
                newName: "value");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 1, 14, 45, 21, 173, DateTimeKind.Local).AddTicks(6925),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 1, 14, 59, 59, 895, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.AddColumn<bool>(
                name: "IsShownOnHome",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
