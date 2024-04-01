using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class ClubReviewChangedNameToReviewBookingIdForeignKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubReviews");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Review identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Review title"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Review description"),
                    Rate = table.Column<int>(type: "int", nullable: false, comment: "Review rating"),
                    ClubId = table.Column<int>(type: "int", nullable: false, comment: "Current review's club identifier"),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Current review's reviewer identifier"),
                    BookingId = table.Column<int>(type: "int", nullable: false, comment: "Current review's booking identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                },
                comment: "Club's review entity");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookingId",
                table: "Reviews",
                column: "BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClubId",
                table: "Reviews",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.CreateTable(
                name: "ClubReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Review identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false, comment: "Current review's club identifier"),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Current review's reviewer identifier"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Review description"),
                    Rate = table.Column<int>(type: "int", nullable: false, comment: "Review rating"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Review title")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubReviews_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubReviews_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                },
                comment: "Club's review entity");

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

            migrationBuilder.CreateIndex(
                name: "IX_ClubReviews_ClubId",
                table: "ClubReviews",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubReviews_ReviewerId",
                table: "ClubReviews",
                column: "ReviewerId");
        }
    }
}
