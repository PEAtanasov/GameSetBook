using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Services.Admin
{
    public class ClubServiceAdmin : IClubServiceAdmin
    {
        private readonly IRepository repository;

        public ClubServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
