using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class passwordIdentityUserSeedUpdatedInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Country identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false, comment: "Country name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                },
                comment: "Country entity");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "City identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "City name"),
                    CountryId = table.Column<int>(type: "int", nullable: false, comment: "Country identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "City entity");

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Club identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Club name"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Club description"),
                    WorkingTimeStart = table.Column<int>(type: "int", nullable: false, comment: "Club working time start"),
                    WorkingTimeEnd = table.Column<int>(type: "int", nullable: false, comment: "Club working time end"),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Address of the club"),
                    CityId = table.Column<int>(type: "int", nullable: false, comment: "Club's city identifier"),
                    NumberOfCoaches = table.Column<int>(type: "int", nullable: true, comment: "Number of coaches in the club"),
                    NumberOfCourts = table.Column<int>(type: "int", nullable: false, comment: "Numbber of courts in the club"),
                    HasParking = table.Column<bool>(type: "bit", nullable: false, comment: "Is car parking for clients available"),
                    HasShower = table.Column<bool>(type: "bit", nullable: false, comment: "Is shower for clients available"),
                    HasShop = table.Column<bool>(type: "bit", nullable: false, comment: "Is tennis shop available"),
                    LogoUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "Club's logo Url"),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, comment: "Club's email"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Club's phone number"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is the club active"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "IsDeleted the record deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deleted on date"),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time the club has been created"),
                    IsAproovedByAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "Is the club aprooved from app admin"),
                    ClubOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_AspNetUsers_ClubOwnerId",
                        column: x => x.ClubOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clubs_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Club entity");

            migrationBuilder.CreateTable(
                name: "GameSetMatchUpPlayerProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Profile identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "User first name"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "User last name"),
                    PlayerDescription = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Player description"),
                    PlayerLevel = table.Column<int>(type: "int", nullable: false, comment: "Player's level"),
                    PlayStyle = table.Column<int>(type: "int", nullable: false, comment: "Player's level"),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "Url reference to the profile image"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "IsDeleted the record deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deleted on date"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    CityId = table.Column<int>(type: "int", nullable: false, comment: "User's city")
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
                name: "ClubReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Review identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Review title"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Review description"),
                    Rate = table.Column<int>(type: "int", nullable: false, comment: "Review rating"),
                    ClubId = table.Column<int>(type: "int", nullable: false, comment: "Current review's club identifier"),
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Current review's reviewer identifier")
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

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Court identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Court name"),
                    Surface = table.Column<int>(type: "int", nullable: false, comment: "Court name"),
                    IsLighted = table.Column<bool>(type: "bit", nullable: false, comment: "Is the court lighted"),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price for renting court per one hour"),
                    IsIndoor = table.Column<bool>(type: "bit", nullable: false, comment: "Is the court indoor"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is the court enable"),
                    ClubId = table.Column<int>(type: "int", nullable: false, comment: "Club identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courts_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Court entity");

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Tournament identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Tournament name"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Tournament description"),
                    PlayerLevelRangeFrom = table.Column<int>(type: "int", nullable: false, comment: "Tournament players level range start from (including)"),
                    PlayerLevelRangeTo = table.Column<int>(type: "int", nullable: false, comment: "Tournament players level range end to (including)"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Tournament start date and time"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Tournament end date and time"),
                    NumberOfPlayersAllowed = table.Column<int>(type: "int", nullable: false, comment: "Number of allowed players to join the tournament"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "IsDeleted the record deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deleted on date"),
                    ClubId = table.Column<int>(type: "int", nullable: false, comment: "Current tournament's club identifier")
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
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Message title"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Message content"),
                    SenderProfileId = table.Column<int>(type: "int", nullable: false, comment: "Sender player profile identifier"),
                    ReceiverProfileId = table.Column<int>(type: "int", nullable: false, comment: "Receiver player profile identifier"),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time the message was sent"),
                    Read = table.Column<bool>(type: "bit", nullable: false, comment: "Is the the message read")
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
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Booking identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Booking price"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, comment: "is the the booking available"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "is the booking canceled"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Deleted on date and time"),
                    BookedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time booking is created"),
                    Hour = table.Column<int>(type: "int", nullable: false, comment: "Hour of the booking"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the booking"),
                    ClientName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Client's name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Client's phone number"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Client identifier"),
                    CourtId = table.Column<int>(type: "int", nullable: false, comment: "Court identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id");
                },
                comment: "Booking entity");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18906160-6956-4ecc-9b7c-fa5d0a4d0f82", "0101ce32-56cf-47c4-9112-883f30f57d7e", "Admin", "ADMIN" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "88aeac26-9101-4095-9a8a-390cff1ffd12", "ClubOwner", "CLUBOWNER" },
                    { "cd40263e-6425-4dad-ada2-60e5813e5eb2", "26e56ab7-c624-4cba-a9e7-cf3314b45582", "GSMUUser", "GSMUUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "65a12477-a9c9-48f1-a844-0ec223e1bca5", 0, "e06c5d37-4d94-49ec-b69c-e6eca66cc574", "admin@mail.com", false, false, null, "ADMIN@GMAIL.COM", null, "AQAAAAEAACcQAAAAEL58c4p4tLahuQOwbsPoQIhLcfFw3N6QI4Zlx3yEvf671Hg8k48cRNVTT63bDwAASQ==", null, false, "969b4e41-e7e3-414b-a0fc-400b817d6fe2", false, null },
                    { "82cd50ca-b023-42e5-8344-227d5c45877c", 0, "26de3351-08c9-4f7a-910f-f4b8b9787f85", "clubowner@mail.com", false, false, null, "CLUBOWNER@GMAIL.COM", null, "AQAAAAEAACcQAAAAELzj6JaqTk5qWv9kF+8Xd1IIYoSb22WMTKEnVXL0ZJrGZfPUg/BwM3wTk1iCiGDlGQ==", null, false, "fa5c329a-adb4-435d-9f26-82d533abb368", false, null },
                    { "83544abd-e9e2-4592-ad5e-23cd2f63e5a0", 0, "08069628-5845-469f-a0ed-bab5b3b7d696", "user@mail.com", false, false, null, "USER@GMAIL.COM", null, "AQAAAAEAACcQAAAAEH7c4Wy2Hx04tAFXrL2tfAJLbfCNj0+vRvldy42qO2UU3wf9b+F0YRImoqAjQLpYYg==", null, false, "0de0bada-f7c3-4dfa-8af3-5c2f54ecb7f5", false, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bulgaria" },
                    { 2, "Romania" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "18906160-6956-4ecc-9b7c-fa5d0a4d0f82", "65a12477-a9c9-48f1-a844-0ec223e1bca5" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "82cd50ca-b023-42e5-8344-227d5c45877c" },
                    { "cd40263e-6425-4dad-ada2-60e5813e5eb2", "83544abd-e9e2-4592-ad5e-23cd2f63e5a0" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Sofia" },
                    { 2, 1, "Plovdiv" },
                    { 3, 1, "Sofia" },
                    { 4, 2, "Bucharest" },
                    { 5, 2, "Constanta" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "CityId", "ClubOwnerId", "DeletedOn", "Description", "Email", "HasParking", "HasShop", "HasShower", "IsActive", "IsAproovedByAdmin", "IsDeleted", "LogoUrl", "Name", "NumberOfCoaches", "NumberOfCourts", "PhoneNumber", "RegisteredOn", "WorkingTimeEnd", "WorkingTimeStart" },
                values: new object[] { 1, "First Club Address", 1, "82cd50ca-b023-42e5-8344-227d5c45877c", null, "First Club Description", "firstClub@mail.com", true, true, true, true, true, false, "", "First Club", 2, 2, "+359123456", new DateTime(2024, 9, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 20, 8 });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "ClubId", "IsActive", "IsIndoor", "IsLighted", "Name", "PricePerHour", "Surface" },
                values: new object[] { 1, 1, true, false, false, "No.1", 20m, 3 });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "ClubId", "IsActive", "IsIndoor", "IsLighted", "Name", "PricePerHour", "Surface" },
                values: new object[] { 2, 1, true, false, false, "No.2", 20m, 2 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookedOn", "BookingDate", "ClientId", "ClientName", "CourtId", "DeletedOn", "Hour", "IsAvailable", "IsDeleted", "PhoneNumber", "Price" },
                values: new object[] { 1, new DateTime(2024, 3, 9, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 14, 17, 9, 0, 0, DateTimeKind.Unspecified), "83544abd-e9e2-4592-ad5e-23cd2f63e5a0", "Petar Atanasov", 1, null, 17, false, false, "+359000111", 20.00m });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CourtId",
                table: "Bookings",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubReviews_ClubId",
                table: "ClubReviews",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubReviews_ReviewerId",
                table: "ClubReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_CityId",
                table: "Clubs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_ClubOwnerId",
                table: "Clubs",
                column: "ClubOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_Name",
                table: "Clubs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courts_ClubId",
                table: "Courts",
                column: "ClubId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ClubReviews");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "TournamentsGSMUPlayerProfiles");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "GameSetMatchUpPlayerProfiles");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18906160-6956-4ecc-9b7c-fa5d0a4d0f82", "65a12477-a9c9-48f1-a844-0ec223e1bca5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "82cd50ca-b023-42e5-8344-227d5c45877c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd40263e-6425-4dad-ada2-60e5813e5eb2", "83544abd-e9e2-4592-ad5e-23cd2f63e5a0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd40263e-6425-4dad-ada2-60e5813e5eb2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c");
        }
    }
}
