using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameSetBook.Infrastructure.Models;

namespace GameSetBook.Infrastructure.Data.Configurations
{
    internal class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasQueryFilter(c => !c.IsDeleted);
            
        }

        //private IList<Club> ClubSeed()
        //{
        //    var clubs = new List<Club>()
        //    {
        //        new Club()
        //        {
                   
        //        }
        //    };
        //    return default;
        //}
    }
}
