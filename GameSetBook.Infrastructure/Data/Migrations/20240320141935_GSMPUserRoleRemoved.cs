using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class GSMPUserRoleRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd40263e-6425-4dad-ada2-60e5813e5eb2", "83544abd-e9e2-4592-ad5e-23cd2f63e5a0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd40263e-6425-4dad-ada2-60e5813e5eb2");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "b5eb8f2e-bb64-49c6-a172-a99acfbe42fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "37cb352d-50ef-4291-8aa1-ca886e69888f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd40263e-6425-4dad-ada2-60e5813e5eb2", "bcf8ad63-8d77-403a-a49c-a79805b5fce0", "GSMUUser", "GSMUUSER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cd88aab-7bdd-4b25-85e3-6056a47ecd05", "AQAAAAEAACcQAAAAEMvqyofdOG9OG/ktaCCBIT/QuzJA+PhgNreVXdNiNkwbPE8469Hpu0JI30+5VpTD+g==", "4606e017-d48b-49d8-af7d-f0cd4505e52d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3622cab4-a69b-4ed4-9ee3-c9d4fabc13d5", "AQAAAAEAACcQAAAAEBMQDEf0Q2Bhu0jH6zch1ANDk0giT+W/o2EnvGeIBk5geUCabMpN6hDlw9RcILvvhg==", "377e5de2-7f03-4706-81d3-24cc1e945899" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53cdb969-3ef3-4e32-839a-91183d2a6541", "AQAAAAEAACcQAAAAEHt3tjA96sRtg6WMVhs5vh8fAv1OXLqLtijAu2CdUMxdxlq/lypF8GR2gHB3kcy63A==", "5bee27c3-3aea-486c-aab6-1d094fb7fa51" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cd40263e-6425-4dad-ada2-60e5813e5eb2", "83544abd-e9e2-4592-ad5e-23cd2f63e5a0" });
        }
    }
}
