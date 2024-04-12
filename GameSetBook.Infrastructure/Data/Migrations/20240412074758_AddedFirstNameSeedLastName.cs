using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class AddedFirstNameSeedLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "b2a23e17-a717-4dd4-aaa9-49b210ee0d5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "9ab9f183-3056-41c8-b280-5582c8b75bc0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "cea279a1-42b5-4646-963b-3b5fb5e5ca90", "Petar", "Atanasov", "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEBSIdYkNQvZt6EAaBsUboL8nSVdi0+ovH0fTUalTEtE0yChU5ULdLuwJRA+bsnYsEg==", "0000000000", "fabe68a3-51d6-4003-bd4a-491fb45a3498" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "7940fead-1015-45c3-8f6a-d0cc62e818af", "Atanas", "Atanasov", "CLUBOWNER@MAIL.COM", "CLUBOWNER@MAIL.COM", "AQAAAAEAACcQAAAAEE58cVeLKbf7RE0RLgSaPZr2m7zXF2LvYXmZBVWlH8A9XyG31/xKzC3WgunCno8Viw==", "1111111111", "63a0b184-eb93-4062-8c90-ba579e88cfbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "d2784153-f6b4-44aa-9584-41abe99153a2", "Encho", "Georgiev", "USER@MAIL.COM", "USER@MAIL.COM", "AQAAAAEAACcQAAAAEA8m03p9tKuHpcwI5yCdKRlBiOlNvIJr+Ln2H/RtL6Irfu29gHnJEnTMTApuNxKsuQ==", "2222222222", "5d4a0bce-cd7f-471d-a7e1-8a3ee744b81f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "c120691c-61ee-46c5-9a53-3298600f2584", null, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFWWzABYxkX/5kVB0MjVDQDs386TIzdVqN74zXvu7JdYjUQ0yp7VxLI9f1OPw+K5xQ==", null, "46b894d9-8809-466e-9db2-421a44af56c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "d26e4920-fbfb-49db-9566-cc76d5fe62e1", null, null, "CLUBOWNER@GMAIL.COM", "CLUBOWNER@GMAIL.COM", "AQAAAAEAACcQAAAAEBvhpD+8feb7CfogzCm4kW7XoJLKbjIF9+71biyChmgtsEAzd/4LvSvncp8uYcINnA==", null, "a6f3842b-5611-49d9-ad38-a89600f71ef7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "0ddd8dae-582f-490e-bfbd-9f2b37eef7dc", null, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEM/STJ6qiulwW1VHOkm6qY4BywaCStdofTTTgBvGwnvGMf1eHcS9bQFa9qKdYbZOOg==", null, "dad65bc7-584e-4ea6-bfff-ffe713985cb6" });
        }
    }
}
