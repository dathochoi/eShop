using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopData.Migrations
{
    public partial class createImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3fb501f-deda-4172-a175-763b2ac8c31f"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("1e8d8fbb-04e8-4fad-bc57-7b29d0c41199"), new Guid("c3fb501f-deda-4172-a175-763b2ac8c31f") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("1e8d8fbb-04e8-4fad-bc57-7b29d0c41199"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 12, 41, 14, 515, DateTimeKind.Local).AddTicks(1858),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 1, 15, 1, 5, 461, DateTimeKind.Local).AddTicks(4742));

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    IsDefaul = table.Column<bool>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 1, 15, 1, 5, 461, DateTimeKind.Local).AddTicks(4742),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 12, 41, 14, 515, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("c3fb501f-deda-4172-a175-763b2ac8c31f"), "d901728b-9062-4658-9928-c6b5be8297f6", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("1e8d8fbb-04e8-4fad-bc57-7b29d0c41199"), new Guid("c3fb501f-deda-4172-a175-763b2ac8c31f") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1e8d8fbb-04e8-4fad-bc57-7b29d0c41199"), 0, "307dcdb1-30ab-4f4c-9b0f-79cdc3ee0726", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, "Dan", "Dan", false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEOAWRU0Tyks07b6c9UNQY3C3c+C0d+SWwdgZNW7aObzcKq0EZdobaxWwADXCZKT2sA==", null, false, "", false, "admin" });

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
                value: new DateTime(2020, 4, 1, 15, 1, 5, 479, DateTimeKind.Local).AddTicks(2002));
        }
    }
}
