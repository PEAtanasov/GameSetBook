using GameSetBook.Core.Contracts.Admin;
using GameSetBook.Infrastructure.Common;

namespace GameSetBook.Core.Services.Admin
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
