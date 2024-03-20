using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class TournamentGSMPlayerProfileTournamentMessagesGSMPProfileRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "TournamentsGSMUPlayerProfiles");

            migrationBuilder.DropTable(
                name: "GameSetMatchUpPlayerProfiles");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Bookings",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Client's phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Client's phone number");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd40263e-6425-4dad-ada2-60e5813e5eb2",
                column: "ConcurrencyStamp",
                value: "bcf8ad63-8d77-403a-a49c-a79805b5fce0");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Bookings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Client's phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Client's phone number");

            migrationBuilder.CreateTable(
                name: "GameSetMatchUpPlayerProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Profile identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false, comment: "User's city"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deleted on date"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "User first name"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "IsDeleted the record deleted"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "User last name"),
                    PlayStyle = table.Column<int>(type: "int", nullable: false, comment: "Player's level"),
                    PlayerDescription = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Player description"),
                    PlayerLevel = table.Column<int>(type: "int", nullable: false, comment: "Player's level"),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "Url reference to the profile image")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSetMatchUpPlayerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSetMatchUpPlayerProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSetMatchUpPlayerProfiles_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "GameSetMatchUp player profile entity");

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Tournament identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: false, comment: "Current tournament's club identifier"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deleted on date"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Tournament description"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Tournament end date and time"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "IsDeleted the record deleted"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Tournament name"),
                    NumberOfPlayersAllowed = table.Column<int>(type: "int", nullable: false, comment: "Number of allowed players to join the tournament"),
                    PlayerLevelRangeFrom = table.Column<int>(type: "int", nullable: false, comment: "Tournament players level range start from (including)"),
                    PlayerLevelRangeTo = table.Column<int>(type: "int", nullable: false, comment: "Tournament players level range end to (including)"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Tournament start date and time")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tournament entity class");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Message identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverProfileId = table.Column<int>(type: "int", nullable: false, comment: "Receiver player profile identifier"),
                    SenderProfileId = table.Column<int>(type: "int", nullable: false, comment: "Sender player profile identifier"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Message content"),
                    Read = table.Column<bool>(type: "bit", nullable: false, comment: "Is the the message read"),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time the message was sent"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Message title")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_GameSetMatchUpPlayerProfiles_ReceiverProfileId",
                        column: x => x.ReceiverProfileId,
                        principalTable: "GameSetMatchUpPlayerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_GameSetMatchUpPlayerProfiles_SenderProfileId",
                        column: x => x.SenderProfileId,
                        principalTable: "GameSetMatchUpPlayerProfiles",
                        principalColumn: "Id");
                },
                comment: "Message entity class");

            migrationBuilder.CreateTable(
                name: "TournamentsGSMUPlayerProfiles",
                columns: table => new
                {
                    PlayerProfileId = table.Column<int>(type: "int", nullable: false, comment: "Current player profile identifier"),
                    TournamentId = table.Column<int>(type: "int", nullable: false, comment: "Current tournament identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentsGSMUPlayerProfiles", x => new { x.PlayerProfileId, x.TournamentId });
                    table.ForeignKey(
                        name: "FK_TournamentsGSMUPlayerProfiles_GameSetMatchUpPlayerProfiles_PlayerProfileId",
                        column: x => x.PlayerProfileId,
                        principalTable: "GameSetMatchUpPlayerProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TournamentsGSMUPlayerProfiles_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55b1135b-e217-4029-9be6-dca910f0944c", "AQAAAAEAACcQAAAAEPvFDFEGU/ljDRNN+pLyzsL/odSaQDFHo/b15empWPlnVBN1UzcRcN8ZgTAIhFQEBQ==", "035fda56-92a6-404a-83d1-ad3978296ddd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "830e8b60-150e-4a5e-ba3a-4ab0862eee97", "AQAAAAEAACcQAAAAEGcx7vMMJUUJ57do6je4SNsYOTJkM8NqwjL3W/0zy5g/9BTIOVMONItoxW/w1Myteg==", "6e7c1f1d-f1db-4888-a6c6-f59bc6d091e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8919d6ca-f297-444f-b018-92065c59fd71", "AQAAAAEAACcQAAAAEPzSX8/yuGkvsf0N+nEf7tRYWbd/icJ9vibGeurZYgabJUtDhdP3qXqUCVT8VdAjow==", "21148cac-868f-4a09-8ba5-48c244844d83" });

            migrationBuilder.CreateIndex(
                name: "IX_GameSetMatchUpPlayerProfiles_CityId",
                table: "GameSetMatchUpPlayerProfiles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSetMatchUpPlayerProfiles_UserId",
                table: "GameSetMatchUpPlayerProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverProfileId",
                table: "Messages",
                column: "ReceiverProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderProfileId",
                table: "Messages",
                column: "SenderProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_ClubId",
                table: "Tournaments",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentsGSMUPlayerProfiles_TournamentId",
                table: "TournamentsGSMUPlayerProfiles",
                column: "TournamentId");
        }
    }
}
