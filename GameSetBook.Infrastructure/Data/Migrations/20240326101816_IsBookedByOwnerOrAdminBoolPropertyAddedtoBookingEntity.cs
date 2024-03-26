using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class IsBookedByOwnerOrAdminBoolPropertyAddedtoBookingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBookedByOwnerOrAdmin",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the booking created by administrator or club owner");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "fd90d286-2f08-4d76-b810-bcda999b1e60");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "c1dc73e2-bf19-4ea8-a469-1a6bc7bff1ef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "650a0e38-1aa0-4eb5-8532-e37377ec7fa7", "AQAAAAEAACcQAAAAEM1YKC04htYxPcQVm7OYcuvw5pp3nn79E6x1x/UbWMVYm2rQbuuh7DenCRyA8g2WUQ==", "0a45138d-6bcb-4763-8c4e-4a84afaada4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92242c07-e991-443f-8f8e-8b49b3d0ea1a", "AQAAAAEAACcQAAAAEP+dyip31p9yOUS3W5CTHuxDZzM1DIl+xHylY7JCIDRMvzWPfNEf70PL2RFMpPs7tg==", "67cfd4ef-9c72-48f8-9f0c-f178be32b07a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a87b366-2ccc-4d20-a4d3-154b45276940", "AQAAAAEAACcQAAAAECNJ3F9anf3fF4mlVIEcMZ1PrPJLxJ9wp5G2lUZZNW7n1chSCuqcPJoPP6JoJ7kCPA==", "be77edd3-f2d6-48b9-98ef-16a2c09ca52b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBookedByOwnerOrAdmin",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "0f4abe77-c20a-45cd-aca5-55164f9fac2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "7eeabd57-749e-4702-8428-45f010a6ae37");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74a26133-b09c-42b8-b988-1c0f45cf6e98", "AQAAAAEAACcQAAAAENN03EJdXNNq4p0JSy/7M/7j/Uwsxb7+EI/dAMmmQuAoAQTTGNimkKsPQB7ufHBZ5Q==", "9e466e42-f565-40da-a7eb-402dfc9b349b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2439589e-41ce-41f5-9e09-aedb55d2c454", "AQAAAAEAACcQAAAAEMCIukVUDHX8gOocmHw0M8kfU9sSUmYsc0zm020DMt3YRqs+8lOA5ZRbpwsicMZgNA==", "3434ff52-b027-4dd0-a0e6-42ac05eb3878" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b84ad23-669d-47be-af70-bb213e2f2c02", "AQAAAAEAACcQAAAAEHcjYaQbCkFjmLiLhYXSM+bzUtKeY93JYdoqiwJuK/KDxSh34yaIZ2pied4X9RztOQ==", "db65b1d8-8dc3-4e5e-93b0-2b9bb8d3fce7" });
        }
    }
}
