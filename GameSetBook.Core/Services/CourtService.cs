using GameSetBook.Core.Contracts;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Services
{
    public class CourtService : ICourtService
    {
        public readonly IRepository repository;
        public CourtService(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
