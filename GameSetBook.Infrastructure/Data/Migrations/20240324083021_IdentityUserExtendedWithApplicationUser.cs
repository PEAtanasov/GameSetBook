using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class IdentityUserExtendedWithApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clubs_ClubOwnerId",
                table: "Clubs");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "Extension of the identoty user");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Bookings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Client's name",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Client's name");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "User first name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "User last name");

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

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubOwnerId",
                table: "Clubs",
                column: "ClubOwnerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clubs_ClubOwnerId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "Extension of the identoty user");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Bookings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Client's name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Client's name");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "ab90ab9f-1aef-49c1-8772-126879cc1efe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "b077c123-5b5b-4ae5-a1b2-9c5e7a6932a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db6f411d-8944-4c0c-a4df-0b0b2a22ee9c", "AQAAAAEAACcQAAAAECffY3dyPPXBl2Kv7BZ1kyNYn9F8uniRHXjUMDVVJlZEwkIp7UaoihBdJDbybplkkw==", "1ed24539-47cc-4abe-98c3-f233b0fa37df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1384a6ef-488e-49b0-bf00-2736f2d9cebc", "AQAAAAEAACcQAAAAEOBHYAaOKYGr/xv2wMAitrGRidJPmSTcUJR7GCEaCFv/hlVUUIu6jfEZ9NVU/QGRdg==", "41f81520-750c-405f-9a87-f1f9e8f53e52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de83bc55-98b5-462e-8d71-2e6389e33d95", "AQAAAAEAACcQAAAAELmKHQnU/flKyrdnNVCBHOdZSB+TGmVvQwMNvFwgQ1kf4xHgfzmHzG67xnvc77rZNA==", "f045d052-56d8-4ebb-b9e8-7725aefcce08" });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubOwnerId",
                table: "Clubs",
                column: "ClubOwnerId");
        }
    }
}
