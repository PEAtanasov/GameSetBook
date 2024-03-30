using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Services.Admin
{
    public class CourtServiceAdmin : ICourtServiceAdmin
    {
        private readonly IRepository repository;

        public CourtServiceAdmin(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
