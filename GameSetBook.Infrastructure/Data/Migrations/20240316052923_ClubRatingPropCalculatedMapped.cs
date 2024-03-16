using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class ClubRatingPropCalculatedMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Surface",
                table: "Courts",
                type: "int",
                nullable: false,
                comment: "Court surface",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Court name");

            migrationBuilder.AlterColumn<string>(
                name: "ClubOwnerId",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Club owner's identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "85aa3681-8b7e-4e9e-9f68-f4631e3d9778");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "c2bdc9fd-a3ad-4a02-9298-dd26343461f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd40263e-6425-4dad-ada2-60e5813e5eb2",
                column: "ConcurrencyStamp",
                value: "d60c562a-b220-4019-aa8f-9c883d858e10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "55b1135b-e217-4029-9be6-dca910f0944c", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPvFDFEGU/ljDRNN+pLyzsL/odSaQDFHo/b15empWPlnVBN1UzcRcN8ZgTAIhFQEBQ==", "035fda56-92a6-404a-83d1-ad3978296ddd", "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "830e8b60-150e-4a5e-ba3a-4ab0862eee97", "CLUBOWNER@GMAIL.COM", "AQAAAAEAACcQAAAAEGcx7vMMJUUJ57do6je4SNsYOTJkM8NqwjL3W/0zy5g/9BTIOVMONItoxW/w1Myteg==", "6e7c1f1d-f1db-4888-a6c6-f59bc6d091e7", "clubowner@mail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8919d6ca-f297-444f-b018-92065c59fd71", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEPzSX8/yuGkvsf0N+nEf7tRYWbd/icJ9vibGeurZYgabJUtDhdP3qXqUCVT8VdAjow==", "21148cac-868f-4a09-8ba5-48c244844d83", "user@mail.com" });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "images/club_logo/default_club_logo.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Surface",
                table: "Courts",
                type: "int",
                nullable: false,
                comment: "Court name",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Court surface");

            migrationBuilder.AlterColumn<string>(
                name: "ClubOwnerId",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Club owner's identifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "0101ce32-56cf-47c4-9112-883f30f57d7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "88aeac26-9101-4095-9a8a-390cff1ffd12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd40263e-6425-4dad-ada2-60e5813e5eb2",
                column: "ConcurrencyStamp",
                value: "26e56ab7-c624-4cba-a9e7-cf3314b45582");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e06c5d37-4d94-49ec-b69c-e6eca66cc574", null, "AQAAAAEAACcQAAAAEL58c4p4tLahuQOwbsPoQIhLcfFw3N6QI4Zlx3yEvf671Hg8k48cRNVTT63bDwAASQ==", "969b4e41-e7e3-414b-a0fc-400b817d6fe2", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "26de3351-08c9-4f7a-910f-f4b8b9787f85", null, "AQAAAAEAACcQAAAAELzj6JaqTk5qWv9kF+8Xd1IIYoSb22WMTKEnVXL0ZJrGZfPUg/BwM3wTk1iCiGDlGQ==", "fa5c329a-adb4-435d-9f26-82d533abb368", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "08069628-5845-469f-a0ed-bab5b3b7d696", null, "AQAAAAEAACcQAAAAEH7c4Wy2Hx04tAFXrL2tfAJLbfCNj0+vRvldy42qO2UU3wf9b+F0YRImoqAjQLpYYg==", "0de0bada-f7c3-4dfa-8af3-5c2f54ecb7f5", null });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "");
        }
    }
}
