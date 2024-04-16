using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetBook.Data.Migrations
{
    public partial class newDataSeedAddedTransitToNewFreshDbWithSomeReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18906160-6956-4ecc-9b7c-fa5d0a4d0f82",
                column: "ConcurrencyStamp",
                value: "9a0e626b-2eb7-456c-b511-522a86f205f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "757178e3-b3c9-4414-8dd6-a72196f2b6d5",
                column: "ConcurrencyStamp",
                value: "4bb04e04-23ff-4c98-99d3-772e77ba83cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a12477-a9c9-48f1-a844-0ec223e1bca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90fd2c69-c933-4aef-99c5-bc089cc87a95", "AQAAAAEAACcQAAAAELmrUz3+p9zSI9GfrYwhWFMfHybv+LruszErbog7+ugmAcmA1c/jJdGNbzSAi2+0Pw==", "55fbbe53-5a0b-4ddd-8e40-f1f5b01f16b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22c72d7b-45fc-4ef9-8c91-fe3de6a1f6cb", "AQAAAAEAACcQAAAAELxYj5U9wrFWebLp/wdCMgPEaImQJhRmH7YAFW6bpa/fO4o2m1YIBLFepUtO/6wJbA==", "2951a4e4-3dca-485f-9390-81db79d813c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54591576-7f9f-4740-8b2f-b057cbee0403", "AQAAAAEAACcQAAAAEOpDWRDgC8aNc1crNMq/DxNjqeajEyWg21aKe22+zrJk6eiOAX1u5b9chQR3RO73Hw==", "312009d3-1c14-410d-b7cc-c82c2c606243" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "09ff5c8e-811b-404d-bf52-545f1100b31b", 0, "cdaeef1c-17f9-40cf-b5fc-25b1e0308533", "user3@example.com", false, "Atanas", "Atanasov", false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", "AQAAAAEAACcQAAAAEAUOTRbYGfWmNM3jKp0jgu+HKYrIiR1/TtU1vnLBu79/XpgEsfji7vTOIEuieYH5YQ==", "333333", false, "8d1fc10a-4839-47a7-b932-03c045853e81", false, "user3@example.com" },
                    { "0e0103e9-2f94-49de-8012-eba340f8e4cf", 0, "b603611e-a6c9-4bf2-8647-de24d7b6948f", "owner8@example.com", false, "owner8", "owner8", false, null, "OWNER8@EXAMPLE.COM", "OWNER8@EXAMPLE.COM", "AQAAAAEAACcQAAAAEPoMnL6HxLAbnObMuHaBADnGcMIDB6KUjKOEw4PgM0k/XoxolIwQm+v8rPVDjcHqWA==", "7777777", false, "117471ce-01c6-4532-9b4c-d284ea5af08e", false, "owner8@example.com" },
                    { "1c3c37d5-2189-4d71-96b5-27c0da3abde7", 0, "bb1747d9-84b6-4521-9a8e-6cfedee65a3c", "owner7@example.com", false, "owner7", "owner7", false, null, "OWNER7@EXAMPLE.COM", "OWNER7@EXAMPLE.COM", "AQAAAAEAACcQAAAAELtw+zn20Qn8glb7c5L9A8u1P6yIc5wUUtE79zoMTw8+B1eXUETquWt7oXwjHiVi2w==", "6666666", false, "f2910bef-85ca-44d0-b8bf-1dcd37677ade", false, "owner7@example.com" },
                    { "33104877-4d79-4194-b09a-9e75f1790ceb", 0, "f4a9aba5-c5f5-4929-8c9b-21588e46bd5d", "user4@example.com", false, "Natalia", "Atanasova", false, null, "USER4@EXAMPLE.COM", "USER4@EXAMPLE.COM", "AQAAAAEAACcQAAAAEPi2VpWh0Ucykrsscy4oG38sCny4clYD2lgR/mUSTUNwnRXL+L0xoev25k5NI3tgxQ==", "444444", false, "7540ca69-a720-4e2a-ad1c-d769dc47b7ba", false, "user4@example.com" },
                    { "3a9b86c8-1c51-4990-aafa-6c527abef86e", 0, "9cbff84f-ae55-4023-b34e-69c6aad400d9", "owner2@example.com", false, "owner2", "owner2", false, null, "OWNER2@EXAMPLE.COM", "OWNER2@EXAMPLE.COM", "AQAAAAEAACcQAAAAEOeWTW6tZoT8fWhQcKLxxDQVlPoFnw9XYHoMQ/Bp+dplHL/eG1MqWh74mJBVqEMgqg==", "1111111", false, "ebf02087-83a4-4bc2-9f34-5bdd3c36a77e", false, "owner2@example.com" },
                    { "4377278c-69e2-4269-b1c3-7e688ef5dcd4", 0, "1a2e087b-ea75-4ac7-b6aa-a370a2c48a22", "user9@example.com", false, "Martin", "Hristov", false, null, "USER9@EXAMPLE.COM", "USER9@EXAMPLE.COM", "AQAAAAEAACcQAAAAEAG7AnPiThDOUiP5mvism4GcSCyzT60rsbc9szPc75BNyTfbIOPo3IkAef+XuJs/Aw==", "999999", false, "9447c1ea-dfcc-4fa7-9733-536286c81e8c", false, "user9@example.com" },
                    { "4be73c85-8e2c-4553-8b17-5352c2a9d11f", 0, "cdf8bd7a-7a0a-455a-bb21-306c4acd0a04", "owner5@example.com", false, "owner5", "owner5", false, null, "OWNER5@EXAMPLE.COM", "OWNER5@EXAMPLE.COM", "AQAAAAEAACcQAAAAEM+p/Zl9huXwXWUAJyTTzx9BUZeQRxd0wfVQZ5qZn2VbvB6oxjDdt7fuFrqc38Rskg==", "4444444", false, "27831057-bfbe-4d15-b7e9-df40b04eda31", false, "owner5@example.com" },
                    { "537897c6-0554-4ed4-9331-be3c7d8607af", 0, "3b7650ba-fd0d-4aed-8869-9a97e55da6ba", "user6@example.com", false, "Plamen", "Plamenov", false, null, "USER6@EXAMPLE.COM", "USER6@EXAMPLE.COM", "AQAAAAEAACcQAAAAEM56QNZf4Lfzg1+umgMi2sHoUNIkSbsNWKdaummtjk0TSUZ7Jfd3P2I+lPCaPDEkWA==", "666666", false, "4004cd4a-68c2-40b7-88c3-4c827c34f056", false, "user6@example.com" },
                    { "53f6a3e4-df3b-4810-8ba0-83b9a57a379e", 0, "b732ffa7-3426-4bed-86b3-7508e018473d", "owner1@example.com", false, "owner1", "owner1", false, null, "OWNER1@EXAMPLE.COM", "OWNER1@EXAMPLE.COM", "AQAAAAEAACcQAAAAEITmqTlTeD7LueBPPbFuMNmw/aa+FmBgVSG5ZeTqLmqmI3G2fYH6BHxFz5vsPykDvA==", "0000000", false, "79a95389-a226-4b84-819c-a2109e04206c", false, "owner1@example.com" },
                    { "5813a55d-7cc0-4441-b5ed-27207a753a6d", 0, "4dbe58b1-d843-4abb-8e6c-24ab9b3f91d2", "owner6@example.com", false, "Petar", "Atanasov", false, null, "OWNER6@EXAMPLE.COM", "OWNER6@EXAMPLE.COM", "AQAAAAEAACcQAAAAEAh8umUBZeD7VQBIeAkxXNeuXJE2QacmcjqtKyPeZnth2h35Sj+AwP1sbc72FyljXA==", "5555555", false, "f6cfb2f8-a132-48c4-85b2-456dd995045d", false, "owner6@example.com" },
                    { "6449c49f-46d1-40ed-9ec1-da665101ec50", 0, "f0c7c249-f2e5-404d-8678-42933d32c461", "user7@example.com", false, "Nikolay", "Velinov", false, null, "USER7@EXAMPLE.COM", "USER7@EXAMPLE.COM", "AQAAAAEAACcQAAAAECJU3D15QRIwGVw028KX21L7XKNW/dYeNl+lVv2+mob7V8vYNM0BCdqn3VFopTz86Q==", "777777", false, "35f5664b-5a59-498c-ab2a-078c83ef17c6", false, "user7@example.com" },
                    { "78d95aa6-e1b2-499e-8b93-6dabcfdbc409", 0, "b3cfce3f-4b67-46d5-8d51-4e1d95ff208e", "owner3@example.com", false, "owner3", "owner3", false, null, "OWNER3@EXAMPLE.COM", "OWNER3@EXAMPLE.COM", "AQAAAAEAACcQAAAAEEYgiHTxQSy0J4npvsV4KM5w8UtNZCjaHN6UqpHJbcW10BYhdOXK3irP6trQDrb6xA==", "2222222", false, "7367ea53-4146-47c8-96be-5b53b0a3cc93", false, "owner3@example.com" },
                    { "a3070a05-d72b-4f5d-b4da-ee8ca88cd6c4", 0, "11f94bc3-70bc-4ed9-85f6-c98b20ac7f8b", "user5@example.com", false, "Gergana", "Ivanova", false, null, "USER5@EXAMPLE.COM", "USER5@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJVR158U0GrtWjn6ZEECD8tV37B2MEYGC/lnX4TnK6gGBUMadVh2mzvQ9Aha5x2Cmw==", "555555", false, "ac72d25d-cfc3-47db-8d06-9a53c6ba96f0", false, "user5@example.com" },
                    { "af0e6295-932f-4d03-b243-874cd538aa4b", 0, "e4f643aa-f98b-4a61-a446-b77c1d215c09", "owner4@example.com", false, "owner4", "owner4", false, null, "OWNER4@EXAMPLE.COM", "OWNER4@EXAMPLE.COM", "AQAAAAEAACcQAAAAENTD7iLy71ppzoM1Nzsedqa002B4giGyZ8eauWTFGKmatwssNl9dS2wrZDxIy9hmZQ==", "3333333", false, "d0b495bd-5bb1-4ed1-95f8-11668194ea09", false, "owner4@example.com" },
                    { "b49cdbae-fe47-4f91-82b2-746025d31476", 0, "cc8e4af6-fa5e-45b5-8cf0-d417160505dc", "notapproved@example.com", false, "not Approved owner", "not Approved owner", false, null, "NOTAPPROVED@EXAMPLE.COM", "NOTAPPROVED@EXAMPLE.COM", "AQAAAAEAACcQAAAAENZ6aM7lNs61fS5HOCYmain85iHqrZqoF9qhwOoFD9vZzhwA2MgF5n7Pu1Ews3SILA==", "99999991", false, "ff78195e-7507-4f65-978c-83dc47c5a30a", false, "notapproved@example.com" },
                    { "be5f9238-069b-441f-b920-3464ab6ffc21", 0, "e65a3e53-dbe2-4df8-91f3-76f9f9cb39c5", "user2@example.com", false, "Georgi", "Georgiev", false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "AQAAAAEAACcQAAAAEHnRmEaZOg8z/XPAFA53Z8LyyVy+6Te9EKx3OOPoH1FcD1f1464Prtq6BNhVykH80w==", "222222", false, "896c398a-33f6-4be7-9efe-411e70db0b04", false, "user2@example.com" },
                    { "c0bb387b-bfb2-48f0-895a-56394ae5c8c2", 0, "3b160d4d-1b9e-4a28-a8f2-d64ffd582725", "user8@example.com", false, "Veselin", "Hristov", false, null, "USER8@EXAMPLE.COM", "USER8@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGynhSk6VfNGphKDEirCUCtkhp4DgEGnCxis5Illk5B0oqAfna65HWkIWlwqWw2agg==", "888888", false, "4fe8c135-cf31-45ef-8495-8ebbafd5c8e5", false, "user8@example.com" },
                    { "d7fc7550-ed8f-4a86-acde-65c54168e949", 0, "eee04cda-8433-4229-b873-ca8f312384b8", "owner9@example.com", false, "owner9", "owner9", false, null, "OWNER9@EXAMPLE.COM", "OWNER9@EXAMPLE.COM", "AQAAAAEAACcQAAAAECp4hZxTHt4Xu+OwEqxBsaPXnwUqk5qm+bcnXeXPBdOFLkxqlp2aZh91R24Zq6xTKw==", "8888888", false, "d8b3eb06-4f55-4015-a0d7-4d653204e98d", false, "owner9@example.com" },
                    { "df044ba7-d51f-491d-8663-9ee9ddc57fb0", 0, "8250df78-0d9e-4e06-a911-14651b854375", "owner10@example.com", false, "owner10", "owner10", false, null, "OWNER10@EXAMPLE.COM", "OWNER10@EXAMPLE.COM", "AQAAAAEAACcQAAAAEBGQz5da1QPeSjcUCHhG84tAO8uhJWR6u8uUAqmc+MluY5uukXdXI29pF/Op1sH35w==", "9999999", false, "b830483f-3e07-41e8-bc69-38de85978f2d", false, "owner10@example.com" },
                    { "e4193a92-3a49-41eb-8920-280bbec55eeb", 0, "cccd5fb0-796b-4300-929f-287d71443752", "user10@example.com", false, "Dara", "Atanasova", false, null, "USER10@EXAMPLE.COM", "USER10@EXAMPLE.COM", "AQAAAAEAACcQAAAAELnnznXE9+fRvPK5Qu4l5iTP/7AR1M7+7Y1EJwq79Q1YV2Xp47xVMq6TgQMtCn3VpQ==", "000000", false, "16a4e516-2c02-4774-a208-956638d08170", false, "user10@example.com" },
                    { "f011047b-9d4a-4cb6-8125-56fcd52a572e", 0, "1a9d3af2-a66a-4c2f-94b8-9b74634d97de", "user1@example.com", false, "Petar", "Petrov", false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAEAACcQAAAAEOgO/GEIBV/FwdxJ/Z+q24pFhgj39sjmJzIqChlQ7dNjw8LSvT+VP7csivpWH+9NdA==", "111111", false, "6ebfa38e-51fc-4880-88d6-0d60483bfa00", false, "user1@example.com" }
                });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientName", "PhoneNumber" },
                values: new object[] { "Encho georgiev", "2222222222" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Varna");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Kavarna");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Greece" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "0e0103e9-2f94-49de-8012-eba340f8e4cf" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "1c3c37d5-2189-4d71-96b5-27c0da3abde7" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "3a9b86c8-1c51-4990-aafa-6c527abef86e" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "4be73c85-8e2c-4553-8b17-5352c2a9d11f" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "53f6a3e4-df3b-4810-8ba0-83b9a57a379e" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "5813a55d-7cc0-4441-b5ed-27207a753a6d" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "78d95aa6-e1b2-499e-8b93-6dabcfdbc409" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "af0e6295-932f-4d03-b243-874cd538aa4b" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "d7fc7550-ed8f-4a86-acde-65c54168e949" },
                    { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "df044ba7-d51f-491d-8663-9ee9ddc57fb0" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 6, 3, "Athens" });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "CityId", "ClubOwnerId", "DeletedOn", "Description", "Email", "HasParking", "HasShop", "HasShower", "IsAproovedByAdmin", "IsDeleted", "LogoUrl", "Name", "NumberOfCoaches", "NumberOfCourts", "PhoneNumber", "RegisteredOn", "WorkingTimeEnd", "WorkingTimeStart" },
                values: new object[,]
                {
                    { 2, "Address 0", 1, "53f6a3e4-df3b-4810-8ba0-83b9a57a379e", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club1@example.com", true, true, true, true, false, "LOGO", "TC Sofia", 2, 4, "00000001", new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 21, 8 },
                    { 3, "Address 1", 1, "3a9b86c8-1c51-4990-aafa-6c527abef86e", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club2@example.com", true, false, true, true, false, "LOGO2", "Forehand TC", 2, 3, "+35988800002", new DateTime(2024, 2, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 20, 7 },
                    { 4, "Address 2", 1, "78d95aa6-e1b2-499e-8b93-6dabcfdbc409", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club2@example.com", true, false, true, true, false, "LOGO3", "6-0 Sofia", 1, 2, "+35988800003", new DateTime(2024, 3, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 23, 7 },
                    { 5, "Address 3", 2, "af0e6295-932f-4d03-b243-874cd538aa4b", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club3@example.com", true, true, false, true, false, "LOGO4", "Match Point", 2, 3, "+35988800004", new DateTime(2024, 4, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 20, 7 },
                    { 6, "Address 4", 2, "4be73c85-8e2c-4553-8b17-5352c2a9d11f", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club4@example.com", false, true, true, true, false, "LOGO5", "TC Ace Varna", 2, 2, "+35988800005", new DateTime(2024, 1, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 22, 8 },
                    { 7, "Address 5", 3, "5813a55d-7cc0-4441-b5ed-27207a753a6d", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club5@example.com", true, true, true, true, false, "LOGO6", "BlackSeaRama TC", 2, 2, "+35988800006", new DateTime(2011, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 21, 7 },
                    { 8, "Address 6", 4, "1c3c37d5-2189-4d71-96b5-27c0da3abde7", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club6@example.com", true, true, true, true, false, "LOGO7", "Number One", 3, 3, "+35988800007", new DateTime(2023, 12, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 23, 7 },
                    { 9, "Address 7", 4, "0e0103e9-2f94-49de-8012-eba340f8e4cf", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club7@example.com", true, true, true, true, false, "LOGO8", "TC Simona Halep", 2, 2, "+35988800008", new DateTime(2023, 3, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 22, 8 },
                    { 10, "Address 8", 5, "d7fc7550-ed8f-4a86-acde-65c54168e949", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club8@example.com", true, true, false, true, false, "LOGO9", "Winner TC", 1, 2, "+35988800009", new DateTime(2023, 4, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 20, 7 },
                    { 12, "Address 101", 1, "b49cdbae-fe47-4f91-82b2-746025d31476", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club11@example.com", true, true, true, false, false, "LOGO11", "Top Tennis", 2, 2, "+35988800011", new DateTime(2023, 12, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), 21, 8 }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Address", "CityId", "ClubOwnerId", "DeletedOn", "Description", "Email", "HasParking", "HasShop", "HasShower", "IsAproovedByAdmin", "IsDeleted", "LogoUrl", "Name", "NumberOfCoaches", "NumberOfCourts", "PhoneNumber", "RegisteredOn", "WorkingTimeEnd", "WorkingTimeStart" },
                values: new object[] { 11, "Address 10", 6, "df044ba7-d51f-491d-8663-9ee9ddc57fb0", null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur venenatis quam purus, id lobortis purus efficitur eget. Cras sed dui a dui finibus condimentum. Quisque ut erat ut orci bibendum tincidunt. Aenean malesuada, augue nec facilisis porttitor, ante massa dignissim sapien, quis vulputate nisi magna id justo. Nunc placerat est ac viverra fringilla. Vestibulum mattis arcu nec lacus tempus, et ultricies nisi luctus. Ut semper scelerisque libero nec pellentesque. Aliquam commodo imperdiet felis, at eleifend diam eleifend porttitor. Cras lacus mi, tempus vitae consectetur ut, dapibus id quam. Aenean a finibus dolor, gravida euismod mauris. Quisque aliquet auctor turpis eu maximus. Duis feugiat augue vel faucibus venenatis.\r\n\r\nInteger nisl metus, aliquet et vulputate sit amet, hendrerit eget nulla. Vestibulum non convallis augue. Aenean ut egestas lacus. Sed pulvinar purus neque, at maximus nisi efficitur et. Etiam sed magna a felis rutrum lacinia a vel tortor. Class aptent taciti eu.", "club10@example.com", true, true, true, true, false, "LOGO10", "Zeus TC", 2, 2, "+35988800010", new DateTime(2023, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 21, 8 });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "ClubId", "IsActive", "IsIndoor", "IsLighted", "Name", "PricePerHour", "Surface" },
                values: new object[,]
                {
                    { 3, 2, true, false, false, "No1", 30m, 3 },
                    { 4, 2, true, false, true, "No2", 35m, 3 },
                    { 5, 2, true, false, true, "No3", 35m, 3 },
                    { 6, 2, true, true, true, "No4", 45m, 4 },
                    { 7, 3, true, false, true, "Court 1", 30m, 2 },
                    { 8, 3, true, false, true, "Court 2", 30m, 2 },
                    { 9, 3, true, false, true, "Court 3", 40m, 2 },
                    { 10, 4, true, false, true, "Number 1", 35m, 1 },
                    { 11, 4, true, false, true, "Number 2", 35m, 1 },
                    { 12, 5, true, false, true, "First", 35m, 3 },
                    { 13, 5, true, false, true, "Second", 35m, 3 },
                    { 14, 5, true, false, true, "Third", 40m, 2 },
                    { 15, 6, true, true, true, "No 1", 40m, 4 },
                    { 16, 6, true, true, true, "No 2", 40m, 4 },
                    { 17, 7, true, false, false, "No1", 50m, 2 },
                    { 18, 7, true, false, false, "No2", 50m, 2 },
                    { 19, 8, true, false, true, "Court 1", 30m, 3 },
                    { 20, 8, true, false, true, "Court 2", 30m, 3 },
                    { 21, 8, true, false, true, "Court 3", 30m, 3 },
                    { 22, 9, true, false, true, "Court 1", 30m, 2 },
                    { 23, 9, true, false, true, "Court 2", 30m, 2 },
                    { 24, 10, true, false, true, "Court No1", 35m, 1 },
                    { 25, 10, true, false, true, "Court No2", 35m, 1 },
                    { 28, 12, false, false, false, "1st", 20m, 3 },
                    { 29, 12, false, false, false, "2nd", 20m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookedOn", "BookingDate", "ClientId", "ClientName", "CourtId", "DeletedOn", "Hour", "IsAvailable", "IsBookedByOwnerOrAdmin", "IsDeleted", "PhoneNumber", "Price" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Petar Petrov", 3, null, 10, false, false, false, "111111", 30m },
                    { 3, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Petar Petrov", 3, null, 11, false, false, false, "111111", 30m },
                    { 4, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), "be5f9238-069b-441f-b920-3464ab6ffc21", "Georgi Georgiev", 4, null, 10, false, false, false, "222222", 35m },
                    { 5, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), "be5f9238-069b-441f-b920-3464ab6ffc21", "Georgi Georgiev", 4, null, 11, false, false, false, "222222", 35m },
                    { 6, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "09ff5c8e-811b-404d-bf52-545f1100b31b", "Atanas Atanasov", 5, null, 10, false, false, false, "333333", 35m },
                    { 7, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), "09ff5c8e-811b-404d-bf52-545f1100b31b", "Atanas Atanasov", 5, null, 11, false, false, false, "333333", 35m },
                    { 8, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "09ff5c8e-811b-404d-bf52-545f1100b31b", "Atanas Atanasov", 6, null, 10, false, false, false, "333333", 45m },
                    { 9, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), "09ff5c8e-811b-404d-bf52-545f1100b31b", "Atanas Atanasov", 6, null, 11, false, false, false, "333333", 45m },
                    { 10, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "33104877-4d79-4194-b09a-9e75f1790ceb", "Natalia Atanasova", 7, null, 10, false, false, false, "333333", 30m },
                    { 11, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), "33104877-4d79-4194-b09a-9e75f1790ceb", "Natalia Atanasova", 7, null, 11, false, false, false, "333333", 30m },
                    { 12, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Petar Petrov", 3, new DateTime(2024, 4, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 10, true, false, true, "111111", 30m },
                    { 13, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Petar Petrov", 3, new DateTime(2024, 4, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 11, true, false, true, "111111", 30m },
                    { 14, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Petar Petrov", 3, null, 13, false, false, false, "111111", 30m },
                    { 15, new DateTime(2024, 1, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Petar Petrov", 3, null, 14, false, false, false, "111111", 30m }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "ClubId", "IsActive", "IsIndoor", "IsLighted", "Name", "PricePerHour", "Surface" },
                values: new object[,]
                {
                    { 26, 11, true, false, true, "Olymp 1", 60m, 2 },
                    { 27, 11, true, false, true, "Olymp 2", 60m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookingId", "ClubId", "CreatedOn", "Description", "Rate", "ReviewerId", "Title" },
                values: new object[,]
                {
                    { 1, 2, 2, new DateTime(2023, 4, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "The best cluib ever", 10, "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Super" },
                    { 2, 3, 2, new DateTime(2023, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "The best cluib ever", 9, "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Well Done" },
                    { 3, 14, 2, new DateTime(2023, 4, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "The best cluib ever", 9, "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Super" },
                    { 4, 15, 2, new DateTime(2023, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "The best cluib ever", 7, "f011047b-9d4a-4cb6-8125-56fcd52a572e", "Well Done" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "0e0103e9-2f94-49de-8012-eba340f8e4cf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "1c3c37d5-2189-4d71-96b5-27c0da3abde7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "3a9b86c8-1c51-4990-aafa-6c527abef86e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "4be73c85-8e2c-4553-8b17-5352c2a9d11f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "53f6a3e4-df3b-4810-8ba0-83b9a57a379e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "5813a55d-7cc0-4441-b5ed-27207a753a6d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "78d95aa6-e1b2-499e-8b93-6dabcfdbc409" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "af0e6295-932f-4d03-b243-874cd538aa4b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "d7fc7550-ed8f-4a86-acde-65c54168e949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "757178e3-b3c9-4414-8dd6-a72196f2b6d5", "df044ba7-d51f-491d-8663-9ee9ddc57fb0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4377278c-69e2-4269-b1c3-7e688ef5dcd4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "537897c6-0554-4ed4-9331-be3c7d8607af");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6449c49f-46d1-40ed-9ec1-da665101ec50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3070a05-d72b-4f5d-b4da-ee8ca88cd6c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0bb387b-bfb2-48f0-895a-56394ae5c8c2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4193a92-3a49-41eb-8920-280bbec55eeb");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09ff5c8e-811b-404d-bf52-545f1100b31b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33104877-4d79-4194-b09a-9e75f1790ceb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be5f9238-069b-441f-b920-3464ab6ffc21");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e0103e9-2f94-49de-8012-eba340f8e4cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c3c37d5-2189-4d71-96b5-27c0da3abde7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4be73c85-8e2c-4553-8b17-5352c2a9d11f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5813a55d-7cc0-4441-b5ed-27207a753a6d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78d95aa6-e1b2-499e-8b93-6dabcfdbc409");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af0e6295-932f-4d03-b243-874cd538aa4b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b49cdbae-fe47-4f91-82b2-746025d31476");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7fc7550-ed8f-4a86-acde-65c54168e949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df044ba7-d51f-491d-8663-9ee9ddc57fb0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f011047b-9d4a-4cb6-8125-56fcd52a572e");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a9b86c8-1c51-4990-aafa-6c527abef86e");

            migrationBuilder.DeleteData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53f6a3e4-df3b-4810-8ba0-83b9a57a379e");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cea279a1-42b5-4646-963b-3b5fb5e5ca90", "AQAAAAEAACcQAAAAEBSIdYkNQvZt6EAaBsUboL8nSVdi0+ovH0fTUalTEtE0yChU5ULdLuwJRA+bsnYsEg==", "fabe68a3-51d6-4003-bd4a-491fb45a3498" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82cd50ca-b023-42e5-8344-227d5c45877c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7940fead-1015-45c3-8f6a-d0cc62e818af", "AQAAAAEAACcQAAAAEE58cVeLKbf7RE0RLgSaPZr2m7zXF2LvYXmZBVWlH8A9XyG31/xKzC3WgunCno8Viw==", "63a0b184-eb93-4062-8c90-ba579e88cfbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83544abd-e9e2-4592-ad5e-23cd2f63e5a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2784153-f6b4-44aa-9584-41abe99153a2", "AQAAAAEAACcQAAAAEA8m03p9tKuHpcwI5yCdKRlBiOlNvIJr+Ln2H/RtL6Irfu29gHnJEnTMTApuNxKsuQ==", "5d4a0bce-cd7f-471d-a7e1-8a3ee744b81f" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientName", "PhoneNumber" },
                values: new object[] { "Petar Atanasov", "+359000111" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Plovdiv");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Sofia");
        }
    }
}
