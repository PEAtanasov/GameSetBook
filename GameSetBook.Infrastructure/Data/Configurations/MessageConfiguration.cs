//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//using GameSetBook.Infrastructure.Models;

//namespace GameSetBook.Infrastructure.Data.Configurations
//{
//    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
//    {
//        public void Configure(EntityTypeBuilder<Message> builder)
//        {
//            builder
//                .HasOne(m => m.SenderProfile)
//                .WithMany(s => s.Messages)
//                .HasForeignKey(m => m.SenderProfileId)
//                .OnDelete(DeleteBehavior.NoAction);
//            builder.HasQueryFilter(c => !c.SenderProfile.IsDeleted);
//        }
//    }
//}
