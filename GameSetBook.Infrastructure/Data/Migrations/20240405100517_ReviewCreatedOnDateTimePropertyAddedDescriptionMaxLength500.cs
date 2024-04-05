using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class ReviewCreatedOnDateTimePropertyAddedDescriptionMaxLength500 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Reviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Review description",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Review description");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date the reviews was added");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "c5f5c828-a004-4227-9783-0e87c07a2e0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "430a9fa9-88ef-42b3-beed-86329beda38f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c120691c-61ee-46c5-9a53-3298600f2584", "AQAAAAEAACcQAAAAEFWWzABYxkX/5kVB0MjVDQDs386TIzdVqN74zXvu7JdYjUQ0yp7VxLI9f1OPw+K5xQ==", "46b894d9-8809-466e-9db2-421a44af56c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d26e4920-fbfb-49db-9566-cc76d5fe62e1", "AQAAAAEAACcQAAAAEBvhpD+8feb7CfogzCm4kW7XoJLKbjIF9+71biyChmgtsEAzd/4LvSvncp8uYcINnA==", "a6f3842b-5611-49d9-ad38-a89600f71ef7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ddd8dae-582f-490e-bfbd-9f2b37eef7dc", "AQAAAAEAACcQAAAAEM/STJ6qiulwW1VHOkm6qY4BywaCStdofTTTgBvGwnvGMf1eHcS9bQFa9qKdYbZOOg==", "dad65bc7-584e-4ea6-bfff-ffe713985cb6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Reviews",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Review description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Review description");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "72daba78-99b5-4729-8c07-b4527a4923ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "d3daee26-a7ac-4360-8752-1785dc5ed72c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0888652-1ae5-4869-b8d4-058d5ee66778", "AQAAAAEAACcQAAAAEEMXvyZ+s+m3uOpPZXy0Jc/nhOoTBWs1BeE4XbmYYrlywKU/b9uFVHcPdicfXbYbLg==", "e86cf0de-8ae3-4e85-87b5-5d0d6b276985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5fd0bd0-3ee7-479d-80ef-d93ab2209bb3", "AQAAAAEAACcQAAAAEMW9AzBePmkqlWZKDaZrqxBv37C5nE9B6TvazZq+Ziq4PQJo/WlX60OscB1EpPxFHw==", "8e545a1b-cf60-414b-9686-cd23525b0c14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43794b26-4a2b-44b3-9e09-644d6c43a185", "AQAAAAEAACcQAAAAEJZGzzwlbFUVulP/2OH9ca/OH2TsdScJGndeRrlACtckRkaSA/BFrdbL/YQa6H7QOg==", "f880b1ac-32e5-47bf-bf91-e04d18e7c210" });
        }
    }
}
