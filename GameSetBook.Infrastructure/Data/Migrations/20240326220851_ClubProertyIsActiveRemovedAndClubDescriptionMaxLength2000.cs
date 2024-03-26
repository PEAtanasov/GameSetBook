using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class ClubProertyIsActiveRemovedAndClubDescriptionMaxLength2000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clubs");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Clubs",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "Club description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Club description");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "2278b4d3-b875-4e4b-ae05-45d64615e974");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "79349b4b-2552-443e-8511-fe2fbff86abf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99f81d35-db5c-4e53-9fa6-40b507d95644", "AQAAAAEAACcQAAAAEBgREabN0s4WI+0EsNv5P2sSGXs7FwNK0ZUVBIt+rETrpJqPOTVvBLTSiLWqteWAVg==", "f9e1be73-1f60-47ae-bd07-8fbf4e53a1ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b65a49af-4f17-4f3d-a027-c10a812a6187", "AQAAAAEAACcQAAAAEHN+3hTztmVO2+8j8ukHpL10Ru6J8JKHk4Yj4TLBw44mr6bAZ6m6IpSLe+ou88it6Q==", "3e801916-4180-4769-871a-86ea21b58aa4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c76c60a0-a6bf-470b-8ab8-7691438c4a53", "AQAAAAEAACcQAAAAEDv/mxJUr3AtCgrM4ReyFpItBBGkp93g6fY6zw43QWgCpIZWpTn2v34cSNa3mjj0fw==", "0e0c88e2-4a90-4bf1-a92a-a40b6580f782" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Clubs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Club description",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "Club description");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clubs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the club active");

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

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }
    }
}
