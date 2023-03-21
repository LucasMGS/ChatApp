using Chat.Domain.Entities;
using Chat.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infrastructure.Mappings
{
    public class ChatRoomMapping : EntityBaseMapping<ChatRoom>
    {
        public override void Configure(EntityTypeBuilder<ChatRoom> builder)
        {
            base.Configure(builder);

            builder.ToTable(TableName.ChatRoom, SchemaName.Chat);
            builder.Property(cr => cr.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey(x => x.OwnerId);

            builder.HasMany(x => x.Messages)
                .WithOne(x => x.ChatRoom)
                .HasForeignKey(x => x.ChatRoomId);
        }
    }
}
