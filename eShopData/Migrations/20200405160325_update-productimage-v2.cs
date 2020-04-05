using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopData.Migrations
{
    public partial class updateproductimagev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("27435696-19a2-43a8-b628-ba0d569056d3"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("dc2fdcd5-0f24-4c7a-ae98-70267852eb18"), new Guid("27435696-19a2-43a8-b628-ba0d569056d3") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc2fdcd5-0f24-4c7a-ae98-70267852eb18"));

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 23, 3, 24, 941, DateTimeKind.Local).AddTicks(4384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 5, 12, 41, 14, 515, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ProductImages",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "ProductImages",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("b35e9758-c627-4136-8f9e-8f710852edd3"), "af1907a6-acec-470c-8869-f1a19aeb30ee", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("c70815f8-ec83-4566-92df-ee64fffa328d"), new Guid("b35e9758-c627-4136-8f9e-8f710852edd3") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c70815f8-ec83-4566-92df-ee64fffa328d"), 0, "1b5425c5-1b5e-4589-9581-9dcde2d0a495", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, "Dan", "Dan", false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEK5iwcSJhz0Qf8/bKMA7QWBJbDXvZo+tZvswz8XGniGMuLQ0PtCWH1PgK3jYj/Mk5A==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 5, 23, 3, 24, 961, DateTimeKind.Local).AddTicks(6638));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b35e9758-c627-4136-8f9e-8f710852edd3"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("c70815f8-ec83-4566-92df-ee64fffa328d"), new Guid("b35e9758-c627-4136-8f9e-8f710852edd3") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("c70815f8-ec83-4566-92df-ee64fffa328d"));

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImage");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 12, 41, 14, 515, DateTimeKind.Local).AddTicks(1858),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 23, 3, 24, 941, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("27435696-19a2-43a8-b628-ba0d569056d3"), "e7f70890-6f61-469c-993c-4c1e17bd4fcd", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("dc2fdcd5-0f24-4c7a-ae98-70267852eb18"), new Guid("27435696-19a2-43a8-b628-ba0d569056d3") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("dc2fdcd5-0f24-4c7a-ae98-70267852eb18"), 0, "7c7cc700-595c-4360-be5a-2bf9258b3bed", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, "Dan", "Dan", false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEFIIQoswJk6t0uKclaTrWY3iUgMYxbHW7228ZH/hpKKHZmPjwESu/+qK/0q07ARLQw==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 5, 12, 41, 14, 533, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
