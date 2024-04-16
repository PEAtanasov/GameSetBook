using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;
using GameSetBook.Common.Enums;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class CourtConfiguration : IEntityTypeConfiguration<Court>
    {
        public void Configure(EntityTypeBuilder<Court> builder)
        {
            builder.HasQueryFilter(c => !c.Club.IsDeleted);
            builder.HasData(CourtSeed());
        }

        private static IList<Court> CourtSeed()
        {
            var court1 = new Court()
            {
                Id = 1,
                ClubId = 1,
                Name = "No.1",
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 20m,
                Surface = Surface.Clay
            };

            var court2=new Court()
            {
                Id = 2,
                ClubId = 1,
                Name = "No.2",
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                PricePerHour = 20m,
                Surface = Surface.Hard
            };

            var tennisClubSfCourtNo1 = new Court()
            {
                Id = 3,
                Name = "No1",
                ClubId = 2,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                Surface = Surface.Clay,
                PricePerHour = 30
            };
            var tennisClubSfCourtNo2 = new Court()
            {
                Id = 4,
                Name = "No2",
                ClubId = 2,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Clay,
                PricePerHour = 35
            };
            var tennisClubSfCourtNo3 = new Court()
            {
                Id = 5,
                Name = "No3",
                ClubId = 2,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Clay,
                PricePerHour = 35
            };
            var tennisClubSfCourtNo4 = new Court()
            {
                Id = 6,
                Name = "No4",
                ClubId = 2,
                IsActive = true,
                IsIndoor = true,
                IsLighted = true,
                Surface = Surface.Carpet,
                PricePerHour = 45
            };

            //forehandTcSf
            var forehandTcSfCourtNo1 = new Court()
            {
                Id = 7,
                Name = "Court 1",
                ClubId = 3,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Hard,
                PricePerHour = 30
            };
            var forehandTcSfCourtNo2 = new Court()
            {
                Id = 8,
                Name = "Court 2",
                ClubId = 3,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Hard,
                PricePerHour = 30
            };
            var forehandTcSfCourtNo3 = new Court()
            {
                Id = 9,
                Name = "Court 3",
                ClubId = 3,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Hard,
                PricePerHour = 40
            };
            //sixZeroClubSf
            var sixZeroClubSfCourtNo1 = new Court()
            {
                Id = 10,
                Name = "Number 1",
                ClubId = 4,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.ArtificialGrass,
                PricePerHour = 35
            };
            var sixZeroClubSfCourtNo2 = new Court()
            {
                Id = 11,
                Name = "Number 2",
                ClubId = 4,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.ArtificialGrass,
                PricePerHour = 35
            };

            //matchPointTcVn
            var matchPointTcVnCourtNo1 = new Court()
            {
                Id = 12,
                Name = "First",
                ClubId = 5,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Clay,
                PricePerHour = 35
            };
            var matchPointTcVnCourtNo2 = new Court()
            {
                Id = 13,
                Name = "Second",
                ClubId = 5,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Clay,
                PricePerHour = 35
            };
            var matchPointTcVnCourtNo3 = new Court()
            {
                Id = 14,
                Name = "Third",
                ClubId = 5,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Hard,
                PricePerHour = 40
            };

            //AceTcVn
            var AceTcVnCourtNo1 = new Court()
            {
                Id = 15,
                Name = "No 1",
                ClubId = 6,
                IsActive = true,
                IsIndoor = true,
                IsLighted = true,
                Surface = Surface.Carpet,
                PricePerHour = 40
            };
            var AceTcVnCourtNo2 = new Court()
            {
                Id = 16,
                Name = "No 2",
                ClubId = 6,
                IsActive = true,
                IsIndoor = true,
                IsLighted = true,
                Surface = Surface.Carpet,
                PricePerHour = 40
            };

            //blackSeaRamaTcKvn
            var blackSeaRamaTcKvnCourtNo1 = new Court()
            {
                Id = 17,
                Name = "No1",
                ClubId = 7,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                Surface = Surface.Hard,
                PricePerHour = 50
            };
            var blackSeaRamaTcKvnCourtNo2 = new Court()
            {
                Id = 18,
                Name = "No2",
                ClubId = 7,
                IsActive = true,
                IsIndoor = false,
                IsLighted = false,
                Surface = Surface.Hard,
                PricePerHour = 50
            };

            //numberOneTcBc
            var numberOneTcBcCourtNo1 = new Court()
            {
                Id = 19,
                Name = "Court 1",
                ClubId = 8,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Clay,
                PricePerHour = 30,
            };
            var numberOneTcBcCourtNo2 = new Court()
            {
                Id = 20,
                Name = "Court 2",
                ClubId = 8,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Clay,
                PricePerHour = 30,
            };
            var numberOneTcBcCourtNo3 = new Court()
            {
                Id = 21,
                Name = "Court 3",
                ClubId = 8,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Clay,
                PricePerHour = 30,
            };

            //simonaHalepTcBc
            var simonaHalepTcBcCourtNo1 = new Court()
            {
                Id = 22,
                Name = "Court 1",
                ClubId = 9,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface =   Surface.Hard,
                PricePerHour = 30,
            };
            var simonaHalepTcBcCourtNo2 = new Court()
            {
                Id = 23,
                Name = "Court 2",
                ClubId = 9,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Hard,
                PricePerHour = 30,
            };

            //winnerTcCn
            var winnerTcCnCourtNo1 = new Court()
            {
                Id = 24,
                Name = "Court No1",
                ClubId = 10,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.ArtificialGrass,
                PricePerHour = 35,
            };
            var winnerTcCnCourtNo2 = new Court()
            {
                Id = 25,
                Name = "Court No2",
                ClubId = 10,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.ArtificialGrass,
                PricePerHour = 35,
            };

            //tennisGodTcGr
            var tennisGodTcGrCourtNo1 = new Court()
            {
                Id = 26,
                Name = "Olymp 1",
                ClubId = 11,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Hard,
                PricePerHour = 60,
            };
            var tennisGodTcGrCourtNo2 = new Court()
            {
                Id = 27,
                Name = "Olymp 2",
                ClubId = 11,
                IsActive = true,
                IsIndoor = false,
                IsLighted = true,
                Surface = Surface.Hard,
                PricePerHour = 60,
            };

            //notApprovedClubSf
            var notAproovedCourt1 = new Court()
            {
                Id = 28,
                Name = "1st",
                ClubId = 12,
                IsActive = false,
                IsIndoor = false,
                IsLighted = false,
                Surface = Surface.Clay,
                PricePerHour = 20,
            };
            var notAproovedCourt2 = new Court()
            {
                Id = 29,
                Name = "2nd",
                ClubId = 12,
                IsActive = false,
                IsIndoor = false,
                IsLighted = false,
                Surface = Surface.Clay,
                PricePerHour = 20,
            };

            var courts = new List<Court>()
            {
                court1,court2,tennisClubSfCourtNo1,tennisClubSfCourtNo2,tennisClubSfCourtNo3,tennisClubSfCourtNo4,
                forehandTcSfCourtNo1,forehandTcSfCourtNo2,forehandTcSfCourtNo3,
                sixZeroClubSfCourtNo1,sixZeroClubSfCourtNo2,matchPointTcVnCourtNo1,
                matchPointTcVnCourtNo2,matchPointTcVnCourtNo3,AceTcVnCourtNo1,AceTcVnCourtNo2,
                blackSeaRamaTcKvnCourtNo1,blackSeaRamaTcKvnCourtNo2,numberOneTcBcCourtNo1,
                numberOneTcBcCourtNo2,numberOneTcBcCourtNo3,simonaHalepTcBcCourtNo1,
                simonaHalepTcBcCourtNo2,winnerTcCnCourtNo1,winnerTcCnCourtNo2,tennisGodTcGrCourtNo1,
                tennisGodTcGrCourtNo2, notAproovedCourt1,notAproovedCourt2
            };

            return courts;
        }
    }
}
