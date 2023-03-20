using Chat.Domain.Entities;
using Chat.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Chat.Infrastructure.Mappings
{
    public class GroupChatMessageMapping : EntityBaseMapping<GroupChatMessage>
    {
        public override void Configure(EntityTypeBuilder<GroupChatMessage> builder)
        {
            base.Configure(builder);

            builder.ToTable(TableName.GroupChatMessage, SchemaName.Chat);
            builder.Property(x => x.Message)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(x => x.UserSender)
                .WithMany()
                .HasForeignKey(x => x.UserSenderId);
        }
    }
}
